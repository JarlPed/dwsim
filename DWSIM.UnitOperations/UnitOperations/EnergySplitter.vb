﻿'    Splitter Calculation Routines 
'    Copyright 2008 Daniel Wagner O. de Medeiros
'
'    This file is part of DWSIM.
'
'    DWSIM is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    DWSIM is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with DWSIM.  If not, see <http://www.gnu.org/licenses/>.


Imports DWSIM.Thermodynamics
Imports DWSIM.Thermodynamics.Streams
Imports DWSIM.SharedClasses
Imports DWSIM.Interfaces.Enums
Imports DWSIM.UnitOperations.Streams

Namespace UnitOperations

    <System.Serializable()> Public Class EnergySplitter

        Inherits UnitOperations.UnitOpBaseClass
        Public Overrides Property ObjectClass As SimulationObjectClass = SimulationObjectClass.MixersSplitters

        <NonSerialized> <Xml.Serialization.XmlIgnore> Public f As EditingForm_EnergySplitter

        Public Overrides ReadOnly Property SupportsDynamicMode As Boolean = True

        Public Overrides ReadOnly Property HasPropertiesForDynamicMode As Boolean = False

        Public Enum OpMode
            SplitRatios = 0
            StreamEnergySpec = 1
        End Enum

        Protected m_ratios As New System.Collections.ArrayList(3)

        Public OutCount As Integer = 0

        Public Property StreamEnergySpec As Double = 0.0#
        Public Property Stream2EnergySpec As Double = 0.0#

        Public Property OperationMode As OpMode = OpMode.SplitRatios

        Public Overrides Function CloneXML() As Object
            Dim obj As ICustomXMLSerialization = New Splitter()
            obj.LoadData(Me.SaveData)
            Return obj
        End Function

        Public Overrides Function CloneJSON() As Object
            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of Splitter)(Newtonsoft.Json.JsonConvert.SerializeObject(Me))
        End Function

        Public Overrides Function LoadData(data As System.Collections.Generic.List(Of System.Xml.Linq.XElement)) As Boolean

            Dim ci As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

            MyBase.LoadData(data)

            Me.m_ratios = New ArrayList

            For Each xel As XElement In (From xel2 As XElement In data Select xel2 Where xel2.Name = "SplitRatios").SingleOrDefault.Elements.ToList
                m_ratios.Add(Double.Parse(xel.Value, ci))
            Next

            If Not GraphicObject Is Nothing Then
                OutCount = 0
                For Each cp In GraphicObject.OutputConnectors
                    If cp.IsAttached Then OutCount += 1
                Next
            End If

            Return True

        End Function

        Public Overrides Function SaveData() As System.Collections.Generic.List(Of System.Xml.Linq.XElement)

            Dim elements As System.Collections.Generic.List(Of System.Xml.Linq.XElement) = MyBase.SaveData()
            Dim ci As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

            With elements
                .Add(New XElement("SplitRatios"))
                For Each d As Double In m_ratios
                    .Item(.Count - 1).Add(New XElement("SplitRatio", d.ToString(ci)))
                Next
            End With

            Return elements

        End Function

        Public ReadOnly Property Ratios() As System.Collections.ArrayList
            Get
                Return Me.m_ratios
            End Get
        End Property

        Public Sub New(ByVal Name As String, ByVal Description As String)

            MyBase.CreateNew()
            Me.ComponentName = Name
            Me.ComponentDescription = Description
            Me.m_ratios.Add(1.0#)
            Me.m_ratios.Add(0.0#)
            Me.m_ratios.Add(0.0#)


        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub PerformPostCalcValidation()
            MyBase.PerformPostCalcValidation()
        End Sub

        Public Overrides Sub RunDynamicModel()
            Calculate()
        End Sub

        Public Overrides Sub Calculate(Optional ByVal args As Object = Nothing)

            Dim IObj As Inspector.InspectorItem = Inspector.Host.GetNewInspectorItem()

            Inspector.Host.CheckAndAdd(IObj, "", "Calculate", If(GraphicObject IsNot Nothing, GraphicObject.Tag, "Temporary Object") & " (" & GetDisplayName() & ")", GetDisplayName() & " Calculation Routine", True)

            IObj?.SetCurrent()

            IObj?.Paragraphs.Add("The splitter is a energy balance unit operation - divides a 
                                    energy stream into two or three other streams with different overall energy rates.")

            If Not Me.GraphicObject.InputConnectors(0).IsAttached Then
                Throw New Exception(FlowSheet.GetTranslatedString("Verifiqueasconexesdo"))
            End If

            OutCount = 0
            Dim cp As IConnectionPoint
            For Each cp In GraphicObject.OutputConnectors
                If cp.IsAttached Then OutCount += 1
            Next

            If OutCount > 0 And GetOutletEnergyStream(0) Is Nothing Or
            (OutCount > 1 And GetOutletEnergyStream(0) Is Nothing) Or
            (OutCount > 1 And GetOutletEnergyStream(1) Is Nothing) Then
                Throw New Exception("Outlet energy streams must be connected sequentially (first one to the first port, second one to the second port and so on)")
            End If

            Dim i As Integer = 0
            Dim j As Integer = 0

            Dim ms As EnergyStream



            Dim w1, w2 As Double

            Dim wn(OutCount) As Double

            Dim W = GetInletEnergyStream(0).EnergyFlow

            Select Case Me.OperationMode

                Case OpMode.SplitRatios

                    Select Case OutCount
                        Case 1
                            Ratios(0) = 1.0
                            Ratios(1) = 0.0
                            Ratios(2) = 0.0
                            wn(0) = W
                        Case 2
                            Ratios(1) = 1.0 - Ratios(0)
                            Ratios(2) = 0.0
                            wn(0) = W * (1.0 - Ratios(1))
                            wn(1) = W * Ratios(1)
                        Case 3
                            Ratios(2) = 1.0 - Ratios(0) - Ratios(1)

                            wn(1) = W * Ratios(1)
                            wn(2) = W * Ratios(2)
                            wn(0) = W - wn(1) - wn(2)

                    End Select




                Case OpMode.StreamEnergySpec



                    Select Case OutCount
                        Case 1
                            w1 = Me.StreamEnergySpec
                            wn(0) = w1
                        Case 2
                            If W >= Me.StreamEnergySpec Then
                                w1 = Me.StreamEnergySpec
                                wn(0) = w1
                                wn(1) = W - w1
                            Else
                                Throw New Exception(FlowSheet.GetTranslatedString("Ovalorinformadonovli"))
                            End If
                        Case 3
                            If W >= Me.StreamEnergySpec + Me.Stream2EnergySpec Then
                                w1 = Me.StreamEnergySpec
                                w2 = Me.Stream2EnergySpec
                                wn(0) = w1
                                wn(1) = w2
                                wn(2) = W - w1 - w2
                            Else
                                Throw New Exception(FlowSheet.GetTranslatedString("Ovalorinformadonovli"))
                            End If
                    End Select
            End Select

            i = 0
            For Each cp In Me.GraphicObject.OutputConnectors
                If cp.IsAttached Then
                    ms = FlowSheet.SimulationObjects(cp.AttachedConnector.AttachedTo.Name)
                    With ms
                        ms.EnergyFlow = wn(i)
                    End With
                End If
                i += 1
            Next



            IObj?.Close()

        End Sub

        Public Overrides Sub DeCalculate()

            Dim i As Integer = 0
            Dim j As Integer = 0

            Dim ms As MaterialStream
            Dim cp As IConnectionPoint
            For Each cp In Me.GraphicObject.OutputConnectors

            Next

        End Sub

        Public Overrides Function GetPropertyValue(ByVal prop As String, Optional ByVal su As Interfaces.IUnitsOfMeasure = Nothing) As Object
            Dim val0 As Object = MyBase.GetPropertyValue(prop, su)

            If Not val0 Is Nothing Then
                Return val0
            Else
                If su Is Nothing Then su = New SystemsOfUnits.SI
                Dim cv As New SystemsOfUnits.Converter
                Dim value As Double = 0
                Select Case prop
                    Case "PROP_SP_1"
                        If Me.OperationMode = OpMode.StreamEnergySpec Then
                            value = SystemsOfUnits.Converter.ConvertFromSI(su.heatflow, Me.StreamEnergySpec)
                        Else
                            value = SystemsOfUnits.Converter.ConvertFromSI(su.heatflow, Me.StreamEnergySpec)
                        End If
                    Case "PROP_SP_2"
                        If Me.OperationMode = OpMode.StreamEnergySpec Then
                            value = SystemsOfUnits.Converter.ConvertFromSI(su.heatflow, Me.Stream2EnergySpec)
                        Else
                            value = SystemsOfUnits.Converter.ConvertFromSI(su.heatflow, Me.Stream2EnergySpec)
                        End If
                    Case "SR1"
                        If Me.Ratios.Count > 0 Then value = Me.Ratios(0)
                    Case "SR2"
                        If Me.Ratios.Count > 1 Then value = Me.Ratios(1)
                    Case "SR3"
                        If Me.Ratios.Count > 2 Then value = Me.Ratios(2)
                End Select
                Return value
            End If
        End Function

        Public Overloads Overrides Function GetProperties(ByVal proptype As Interfaces.Enums.PropertyType) As String()
            Dim proplist As New ArrayList
            Dim basecol = MyBase.GetProperties(proptype)
            If basecol.Length > 0 Then proplist.AddRange(basecol)

            proplist.Add("PROP_SP_1")
            proplist.Add("PROP_SP_2")

            If GraphicObject IsNot Nothing Then
                OutCount = 0
                For Each cp In GraphicObject.OutputConnectors
                    If cp.IsAttached Then OutCount += 1
                Next
            End If

            Select Case proptype
                Case PropertyType.RW
                    For i = 1 To OutCount - 1
                        proplist.Add("SR" + CStr(i))
                    Next
                Case PropertyType.WR
                    For i = 1 To OutCount - 1
                        proplist.Add("SR" + CStr(i))
                    Next
                Case PropertyType.ALL
                    For i = 1 To OutCount
                        proplist.Add("SR" + CStr(i))
                    Next
                Case PropertyType.RO
                    proplist.Add("SR" + CStr(OutCount))
            End Select

            Return proplist.ToArray(GetType(System.String))
        End Function

        Public Overrides Function SetPropertyValue(ByVal prop As String, ByVal propval As Object, Optional ByVal su As Interfaces.IUnitsOfMeasure = Nothing) As Boolean

            If GraphicObject IsNot Nothing Then
                OutCount = 0
                For Each cp In GraphicObject.OutputConnectors
                    If cp.IsAttached Then OutCount += 1
                Next
            End If

            If MyBase.SetPropertyValue(prop, propval, su) Then Return True

            If su Is Nothing Then su = New SystemsOfUnits.SI
            Dim cv As New SystemsOfUnits.Converter
            Select Case prop
                Case "PROP_SP_1"
                    If Me.OperationMode = OpMode.StreamEnergySpec Then
                        Me.StreamEnergySpec = SystemsOfUnits.Converter.ConvertToSI(su.heatflow, propval)
                    Else
                        Me.StreamEnergySpec = SystemsOfUnits.Converter.ConvertToSI(su.heatflow, propval)
                    End If
                Case "PROP_SP_2"
                    If Me.OperationMode = OpMode.StreamEnergySpec Then
                        Me.Stream2EnergySpec = SystemsOfUnits.Converter.ConvertToSI(su.massflow, propval)
                    Else
                        Me.Stream2EnergySpec = SystemsOfUnits.Converter.ConvertToSI(su.molarflow, propval)
                    End If
                Case "SR1"
                    If propval >= 0 And propval <= 1 Then
                        Me.Ratios(0) = propval
                        If OutCount = 2 Then Me.Ratios(1) = 1 - propval
                        If OutCount = 3 And Ratios(0) + Ratios(1) <= 1 Then Me.Ratios(2) = 1 - Me.Ratios(0) - Me.Ratios(1)
                    End If
                Case "SR2"
                    If propval >= 0 And propval <= 1 And Me.Ratios(0) + Me.Ratios(1) + propval <= 1 And OutCount = 3 Then
                        Me.Ratios(1) = propval
                        Me.Ratios(2) = 1 - Me.Ratios(0) - Me.Ratios(1)
                    End If
            End Select
            Return 1
        End Function

        Public Overrides Function GetPropertyUnit(ByVal prop As String, Optional ByVal su As Interfaces.IUnitsOfMeasure = Nothing) As String
            Dim u0 As String = MyBase.GetPropertyUnit(prop, su)

            If u0 <> "NF" Then
                Return u0
            Else
                If su Is Nothing Then su = New SystemsOfUnits.SI
                Dim value As String = ""
                If prop.StartsWith("P") Then
                    Select Case Me.OperationMode
                        Case OpMode.StreamEnergySpec
                            value = su.heatflow
                    End Select
                Else
                    value = ""
                End If
                Return value
            End If
        End Function

        Public Overrides Sub DisplayEditForm()

            If f Is Nothing Then
                f = New EditingForm_EnergySplitter With {.SimObject = Me}
                f.ShowHint = GlobalSettings.Settings.DefaultEditFormLocation
                f.Tag = "ObjectEditor"
                Me.FlowSheet.DisplayForm(f)
            Else
                If f.IsDisposed Then
                    f = New EditingForm_EnergySplitter With {.SimObject = Me}
                    f.ShowHint = GlobalSettings.Settings.DefaultEditFormLocation
                    f.Tag = "ObjectEditor"
                    Me.FlowSheet.DisplayForm(f)
                Else
                    f.Activate()
                End If
            End If

        End Sub

        Public Overrides Sub UpdateEditForm()
            If f IsNot Nothing Then
                If Not f.IsDisposed Then
                    f.UIThread(Sub() f.UpdateInfo())
                End If
            End If
        End Sub

        Public Overrides Function GetIconBitmap() As Object
            Return My.Resources.uo_esplit_32
        End Function

        Public Overrides Function GetDisplayDescription() As String
            Return ResMan.GetLocalString("ESPLIT_Desc")
        End Function

        Public Overrides Function GetDisplayName() As String
            Return ResMan.GetLocalString("ESPLIT_Name")
        End Function

        Public Overrides Sub CloseEditForm()
            If f IsNot Nothing Then
                If Not f.IsDisposed Then
                    f.Close()
                    f = Nothing
                End If
            End If
        End Sub

        Public Overrides ReadOnly Property MobileCompatible As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Function GetPropertyDescription(p As String) As String
            If p.Equals("Specification") Then
                Return "Define how you will specify this splitter block."
            ElseIf p.Equals("Split Ratio Stream 1") Then
                Return "If you chose 'Split Ratios' as the specification mode, enter the fraction of the inlet heat/energy flow that will be directed to the outlet stream 1."
            ElseIf p.Equals("Split Ratio Stream 2") Then
                Return "If you chose 'Split Ratios' as the specification mode, enter the fraction of the inlet heat/energy flow that will be directed to the outlet stream 2."
            ElseIf p.Equals("Split Ratio Stream 3") Then
                Return "If you chose 'Split Ratios' as the specification mode and have 3 outlet streams connected to this splitter, enter the fraction of the inlet mass flow that will be directed to the outlet stream 3."
            ElseIf p.Equals("Stream 1 Heat/Energy Flow Spec") Then
                Return "If you chose a Flow Spec as the specification mode, enter the flow amount of the stream 1. If only two outlet streams are connected, you don't need to specify a flow amount for the stream 2 as it will be calculated to close the mass balance."
            ElseIf p.Equals("Stream 2 Heat/Energy Flow Spec") Then
                Return "If you chose a Flow Spec as the specification mode, enter the flow amount of the stream 2. This is required only if you have 3 outlet streams connected to this splitter."
            Else
                Return p
            End If
        End Function

    End Class

End Namespace
