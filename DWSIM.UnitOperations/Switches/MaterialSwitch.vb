'    Splitter Calculation Routines 
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

    <System.Serializable()> Public Class MaterialSwitch

        Inherits UnitOperations.UnitOpBaseClass
        Public Overrides Property ObjectClass As SimulationObjectClass = SimulationObjectClass.MixersSplitters

        <NonSerialized> <Xml.Serialization.XmlIgnore> Public f As EditingForm_MaterialSwitch

        Public Overrides ReadOnly Property SupportsDynamicMode As Boolean = True

        Public Overrides ReadOnly Property HasPropertiesForDynamicMode As Boolean = False

        Public OutCount As Integer = 0

        Public BooleanExpression As String

        <NonSerialized> <Xml.Serialization.XmlIgnore> Private MEngine As Mages.Core.Engine

        <NonSerialized> <Xml.Serialization.XmlIgnore> Public _ExpressionChanged As Boolean = False

        <NonSerialized> <Xml.Serialization.XmlIgnore> Private bFunc As Mages.Core.Function


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

            'Me.m_ratios = New ArrayList
            '
            'For Each xel As XElement In (From xel2 As XElement In data Select xel2 Where xel2.Name = "SplitRatios").SingleOrDefault.Elements.ToList
            '    m_ratios.Add(Double.Parse(xel.Value, ci))
            'Next

            Dim xel = From xel2 As XElement In data Select xel2 Where xel2.Name = "SwithConfigs"

            BooleanExpression = xel.First().Value ' data.Elements("SwithConfigs").FirstOrDefault().Element("BooleanExpression").Value


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
                '.Add(New XElement("SplitRatios"))
                'For Each d As Double In m_ratios
                '    .Item(.Count - 1).Add(New XElement("SplitRatio", d.ToString(ci)))
                'Next
                .Add(New XElement("SwithConfigs"))
                .Item(.Count - 1).Add(New XElement("BooleanExpression"), BooleanExpression)
                '.Item(1).Add(New XElement("BooleanExpression"), BooleanExpression)
            End With

            Return elements

        End Function

        'Public ReadOnly Property Ratios() As System.Collections.ArrayList
        '    Get
        '        'Return Me.m_ratios
        '    End Get
        'End Property

        Public Sub New(ByVal Name As String, ByVal Description As String)

            MyBase.CreateNew()
            Me.ComponentName = Name
            Me.ComponentDescription = Description
            'Me.m_ratios.Add(1.0#)
            'Me.m_ratios.Add(0.0#)
            'Me.m_ratios.Add(0.0#)
            Me.BooleanExpression = "1 > 0"


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

            IObj?.Paragraphs.Add("The switch is a material stream directing unit operation - the stream
                                    is transfered to port 1 if true; and to port 2 if false.")

            If Not Me.GraphicObject.InputConnectors(0).IsAttached Then
                Throw New Exception(FlowSheet.GetTranslatedString("Verifiqueasconexesdo"))
            End If

            OutCount = 0
            Dim cp As IConnectionPoint
            For Each cp In GraphicObject.OutputConnectors
                If cp.IsAttached Then OutCount += 1
            Next

            If OutCount > 0 And GetOutletMaterialStream(0) Is Nothing Or
            (OutCount > 1 And GetOutletMaterialStream(0) Is Nothing) Or
            (OutCount > 1 And GetOutletMaterialStream(1) Is Nothing) Then
                Throw New Exception("Outlet Material streams must be connected sequentially (first one to the first port, second one to the second port and so on)")
            End If

            Dim i As Integer = 0

            Dim ms As MaterialStream

            Dim wn(OutCount) As Double

            Dim matIn = GetInletMaterialStream(0)

            GetInletMaterialStream(0).Validate()

            Dim W As Double = GetInletMaterialStream(0).GetMolarFlow()


            'Variables (Inlet Stream)
            'T = Temperature (K)
            'P = Pressure (Pa)
            'W = Mass Flow (kg/s)
            'M = Molar Flow (mol/s)
            'Q = Volumetric Flow (m3/s)
            'VF = Vapor Phase Molar Fraction
            'LF = Liquid Phase Molar Fraction
            'SF = Solid Phase Molar Fraction
            'If the expression is evaluated as TRUE, the Inlet Stream will be routed to Outlet Stream 1

            Dim VF, LF, SF As Double
            Try
                VF = matIn.GetPhase("Vapor").Properties.molarfraction
            Catch ex As Exception

            End Try
            Try
                LF = matIn.GetPhase("OverallLiquid").Properties.molarfraction
            Catch ex As Exception

            End Try
            Try
                SF = matIn.GetPhase("Solid").Properties.molarfraction
            Catch ex As Exception

            End Try


            Dim vars As Object() = {matIn.GetTemperature(), matIn.GetPressure(), matIn.GetMassFlow(), matIn.GetMolarFlow(), matIn.GetVolumetricFlow(), VF, LF, SF}

            'matIn.GetPropertyValue("Vapor Phase Molar Fraction"), matIn.GetPropertyValue("Liquid Phase Molar Fraction"), matIn.GetPropertyValue("Solid Phase Molar Fraction")}

            If MEngine Is Nothing Then
                MEngine = New Mages.Core.Engine()
                bFunc = MEngine.Interpret("( T, P, W, M, Q, VF, LF, SF ) => " + BooleanExpression)
            End If
            If _ExpressionChanged Then
                _ExpressionChanged = False
                bFunc = MEngine.Interpret("( T, P, W, M, Q, VF, LF, SF ) => " + BooleanExpression)
            End If
            Dim BoleanVal As Boolean = bFunc.Invoke(vars)






            i = 0
            For Each cp In Me.GraphicObject.OutputConnectors
                If cp.IsAttached Then
                    ms = FlowSheet.SimulationObjects(cp.AttachedConnector.AttachedTo.Name)
                    ms.SetOverallComposition(matIn.GetOverallComposition())
                    ms.SetTemperature(matIn.GetTemperature())
                    ms.SetPressure(matIn.GetPressure())
                    If BoleanVal Then
                        If i = 0 Then
                            ms.SetMolarFlow(W)
                        Else
                            ms.SetMolarFlow(1.0E-200)
                        End If
                    Else
                        If i = 1 Then
                            ms.SetMolarFlow(W)
                        Else
                            ms.SetMolarFlow(1.0E-200)
                        End If
                    End If
                End If
                i += 1
            Next


            If (BoleanVal) Then
                GraphicObject.DrawingState = 0
            Else
                GraphicObject.DrawingState = 1
            End If


            IObj?.Close()

        End Sub

        Public Overrides Sub DeCalculate()

            Dim ms As MaterialStream

            Dim cp As IConnectionPoint
            For Each cp In Me.GraphicObject.OutputConnectors
                ms = FlowSheet.SimulationObjects(cp.AttachedConnector.AttachedTo.Name)
                ms.SetMolarFlow(0.0)
            Next

        End Sub

        Public Overrides Function GetPropertyValue(ByVal prop As String, Optional ByVal su As Interfaces.IUnitsOfMeasure = Nothing) As Object

            'If prop = "PROP_EXPR" Then Return BooleanExpression
            '
            '
            'Dim val0 As Object = MyBase.GetPropertyValue(prop, su)
            '
            'If Not val0 Is Nothing Then
            '    Return val0
            'Else
            '    If su Is Nothing Then su = New SystemsOfUnits.SI
            '    Dim cv As New SystemsOfUnits.Converter
            '    Dim value As Double = 0
            '    Return value
            'End If
            Return Nothing
        End Function

        Public Overloads Overrides Function GetProperties(ByVal proptype As Interfaces.Enums.PropertyType) As String()
            Dim proplist As New ArrayList
            Dim basecol = MyBase.GetProperties(proptype)
            If basecol.Length > 0 Then proplist.AddRange(basecol)

            'proplist.Add("PROP_EXPR")

            'If GraphicObject IsNot Nothing Then
            '    OutCount = 0
            '    For Each cp In GraphicObject.OutputConnectors
            '        If cp.IsAttached Then OutCount += 1
            '    Next
            'End If

            'Select Case proptype
            '    Case PropertyType.RW
            '        For i = 1 To OutCount - 1
            '            proplist.Add("SR" + CStr(i))
            '        Next
            '    Case PropertyType.WR
            '        For i = 1 To OutCount - 1
            '            proplist.Add("SR" + CStr(i))
            '        Next
            '    Case PropertyType.ALL
            '        For i = 1 To OutCount
            '            proplist.Add("SR" + CStr(i))
            '        Next
            '    Case PropertyType.RO
            '        proplist.Add("SR" + CStr(OutCount))
            'End Select

            Return proplist.ToArray(GetType(System.String))
        End Function

        Public Overrides Function SetPropertyValue(ByVal prop As String, ByVal propval As Object, Optional ByVal su As Interfaces.IUnitsOfMeasure = Nothing) As Boolean

            'If GraphicObject IsNot Nothing Then
            '    OutCount = 0
            '    For Each cp In GraphicObject.OutputConnectors
            '        If cp.IsAttached Then OutCount += 1
            '    Next
            'End If
            '
            'If MyBase.SetPropertyValue(prop, propval, su) Then Return True
            '
            'If su Is Nothing Then su = New SystemsOfUnits.SI
            'Dim cv As New SystemsOfUnits.Converter

            ''BooleanExpression

            Return 1
        End Function

        Public Overrides Function GetPropertyUnit(ByVal prop As String, Optional ByVal su As Interfaces.IUnitsOfMeasure = Nothing) As String
            '    Dim u0 As String = MyBase.GetPropertyUnit(prop, su)
            '
            '    If u0 <> "NF" Then
            '        Return u0
            '    Else
            '        If su Is Nothing Then su = New SystemsOfUnits.SI
            '        Dim value As String = ""
            '        If prop.StartsWith("PROP_EXPR") Then
            '            value = su.
            '        Else
            '            value = ""
            '        End If
            '        Return value
            '    End If
            Return Nothing
        End Function

        Public Overrides Sub DisplayEditForm()

            If f Is Nothing Then
                f = New EditingForm_MaterialSwitch With {.SimObject = Me}
                f.ShowHint = GlobalSettings.Settings.DefaultEditFormLocation
                f.Tag = "ObjectEditor"
                Me.FlowSheet.DisplayForm(f)
            Else
                If f.IsDisposed Then
                    f = New EditingForm_MaterialSwitch With {.SimObject = Me}
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
            Return My.Resources.switch_material
        End Function

        Public Overrides Function GetDisplayDescription() As String
            Return ResMan.GetLocalString("MASW_Desc")
        End Function

        Public Overrides Function GetDisplayName() As String
            Return ResMan.GetLocalString("MASW_Name")
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
            'If p.Equals("PROP_EXPR") Then
            '    Return "Define how you will specify the boolean expression. True outputs to Outlet 2, False outputs to Outlet 1"
            'Else
            '    Return p
            'End If
            Return Nothing
        End Function

    End Class

End Namespace
