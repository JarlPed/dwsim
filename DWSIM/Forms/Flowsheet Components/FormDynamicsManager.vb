﻿Imports DWSIM.DynamicsManager
Imports DWSIM.ExtensionMethods
Imports DWSIM.Interfaces
Imports System.Linq

Public Class FormDynamicsManager

    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Public Flowsheet As FormFlowsheet

    Private Manager As DynamicsManager.Manager

    Private Adding As Boolean = False

    Private Sub FormDynamicsManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Manager = Flowsheet.DynamicsManager

        UpdateSelectables()

        UpdateAllPanels()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkDynamics.CheckedChanged
        If chkDynamics.Checked Then
            chkDynamics.Text = DWSIM.App.GetLocalString("Deactivate")
            lblStatus.Text = DWSIM.App.GetLocalString("DynEnabled")
            Flowsheet.DynamicMode = True
            chkDynamics.ForeColor = Color.White
            chkDynamics.BackColor = Color.DarkGreen
        Else
            chkDynamics.Text = DWSIM.App.GetLocalString("Activate")
            lblStatus.Text = DWSIM.App.GetLocalString("DynDisabled")
            Flowsheet.DynamicMode = False
            chkDynamics.ForeColor = Color.White
            chkDynamics.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Flowsheet.FormIntegratorControls.Show(Flowsheet.GetDockPanel)
        'Flowsheet.dckPanel.SaveAsXml("C:\Users\Daniel\Desktop\layout.xml")
    End Sub

    Sub UpdateSelectables()

        Dim cbobjects = New DataGridViewComboBoxCell
        cbobjects.Items.Add("")
        cbobjects.Items.AddRange(Flowsheet.SimulationObjects.Values.Select(Function(x) x.GraphicObject.Tag).ToArray)

        Dim cbindicators = New DataGridViewComboBoxCell
        cbindicators.Items.Add("")
        cbindicators.Items.AddRange(Flowsheet.SimulationObjects.Values.Where(Function(x0) TypeOf x0 Is IIndicator).Select(Function(x) x.GraphicObject.Tag).ToArray)

        Dim cbeventtype = New DataGridViewComboBoxCell
        cbeventtype.Items.Add(Flowsheet.GetTranslatedString1("ChangeProperty"))
        cbeventtype.Items.Add(Flowsheet.GetTranslatedString1("RunScript"))

        Dim cbalarmtypes = New DataGridViewComboBoxCell
        cbalarmtypes.Items.AddRange(New Object() {"LL", "L", "H", "HH"})

        gridselectedset.Columns(4).CellTemplate = cbeventtype

        gridselectedset.Columns(5).CellTemplate = cbobjects

        grdiselmatrix.Columns(3).CellTemplate = cbindicators

        grdiselmatrix.Columns(4).CellTemplate = cbalarmtypes

        grdiselmatrix.Columns(5).CellTemplate = cbobjects

    End Sub

    Sub UpdateAllPanels()

        'events list
        For Each ev In Manager.EventSetList.Values
            gridsets.Rows.Add(New Object() {ev.ID, ev.Description})
        Next

    End Sub

    Private Sub btnAddEventSet_Click(sender As Object, e As EventArgs) Handles btnAddEventSet.Click

        Dim f As New FormEnterName

        If f.ShowDialog(Me) = DialogResult.OK Then
            Dim name = f.tbName.Text
            If name <> "" Then
                If Not Manager.EventSetList.ContainsKey(name) Then
                    Dim es = New EventSet With {.ID = Guid.NewGuid.ToString, .Description = name}
                    Manager.EventSetList.Add(es.ID, es)
                    gridsets.Rows.Add(New Object() {es.ID, es.Description})
                Else
                    MessageBox.Show(Flowsheet.GetTranslatedString1("InvalidName"), Flowsheet.GetTranslatedString1("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show(Flowsheet.GetTranslatedString1("InvalidName"), Flowsheet.GetTranslatedString1("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub gridsets_SelectionChanged(sender As Object, e As EventArgs) Handles gridsets.SelectionChanged

        PopulateEventsFromSelectedSet()

    End Sub

    Sub PopulateEventsFromSelectedSet()

        Adding = True

        Dim es = Manager.EventSetList(gridsets.Rows(gridsets.SelectedCells(0).RowIndex).Cells(0).Value)

        gridselectedset.Rows.Clear()

        For Each ev In es.Events.Values
            With ev
                Dim etype As String
                If ev.EventType = Dynamics.DynamicsEventType.ChangeProperty Then
                    etype = Flowsheet.GetTranslatedString1("ChangeProperty")
                Else
                    etype = Flowsheet.GetTranslatedString1("RunScript")
                End If
                Dim obj, prop As String
                gridselectedset.Rows.Add(New Object() { .ID, .Enabled, .Description, .TimeStamp, etype, "", "", "", ""})
                Dim addedrow = gridselectedset.Rows(gridselectedset.Rows.Count - 1)
                If Flowsheet.SimulationObjects.ContainsKey(ev.SimulationObjectID) Then
                    obj = Flowsheet.SimulationObjects(ev.SimulationObjectID).GraphicObject.Tag
                    addedrow.Cells(5).Value = obj
                    Dim props = Flowsheet.SimulationObjects(ev.SimulationObjectID).GetProperties(PropertyType.WR)
                    Dim cbcell = DirectCast(addedrow.Cells(6), DataGridViewComboBoxCell)
                    cbcell.Items.Clear()
                    cbcell.Items.AddRange("")
                    cbcell.Items.AddRange(props.Select(Function(p) Flowsheet.GetTranslatedString1(p)).ToArray)
                    If props.Contains(ev.SimulationObjectProperty) Then
                        prop = Flowsheet.GetTranslatedString1(ev.SimulationObjectProperty)
                        addedrow.Cells(6).Value = prop
                    End If
                End If
                addedrow.Cells(7).Value = .SimulationObjectPropertyValue
                addedrow.Cells(8).Value = .SimulationObjectPropertyUnits
            End With
        Next

        Adding = False

    End Sub

    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        Dim es = Manager.EventSetList(gridsets.Rows(gridsets.SelectedCells(0).RowIndex).Cells(0).Value)

        Dim ev As New DynamicEvent With {.ID = Guid.NewGuid.ToString}

        es.Events.Add(ev.ID, ev)

        With ev
            Dim etype As String
            If .EventType = Dynamics.DynamicsEventType.ChangeProperty Then
                etype = Flowsheet.GetTranslatedString1("ChangeProperty")
            Else
                etype = Flowsheet.GetTranslatedString1("RunScript")
            End If
            gridselectedset.Rows.Add(New Object() { .ID, .Enabled, .Description, .TimeStamp, etype, "", "", "", ""})
        End With

    End Sub

    Private Sub gridselectedset_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gridselectedset.CellValueChanged

        If e.RowIndex < 0 Or Adding Then Exit Sub

        Dim es = Manager.EventSetList(gridsets.Rows(gridsets.SelectedCells(0).RowIndex).Cells(0).Value)

        Dim ev = es.Events(gridselectedset.Rows(e.RowIndex).Cells(0).Value)

        Dim value = gridselectedset.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        Try
            Select Case e.ColumnIndex
                Case 1
                    ev.Enabled = value
                Case 2
                    ev.Description = value
                Case 3
                    ev.TimeStamp = value
                Case 4
                    If value = Flowsheet.GetTranslatedString1("ChangeProperty") Then
                        ev.EventType = Dynamics.DynamicsEventType.ChangeProperty
                    Else
                        ev.EventType = Dynamics.DynamicsEventType.RunScript
                    End If
                Case 5
                    If value <> "" Then
                        ev.SimulationObjectID = Flowsheet.GetFlowsheetGraphicObject(value).Name
                        Dim props = Flowsheet.SimulationObjects(ev.SimulationObjectID).GetProperties(PropertyType.WR)
                        Dim cbcell = DirectCast(gridselectedset.Rows(e.RowIndex).Cells(6), DataGridViewComboBoxCell)
                        cbcell.Items.Clear()
                        cbcell.Items.AddRange("")
                        cbcell.Items.AddRange(props.Select(Function(p) Flowsheet.GetTranslatedString1(p)).ToArray)
                    End If
                Case 6
                    If value <> "" Then
                        Dim props = Flowsheet.SimulationObjects(ev.SimulationObjectID).GetProperties(PropertyType.WR)
                        Dim cbcell = DirectCast(gridselectedset.Rows(e.RowIndex).Cells(6), DataGridViewComboBoxCell)
                        ev.SimulationObjectProperty = props(cbcell.Items.IndexOf(value))
                    End If
                Case 7
                    ev.SimulationObjectPropertyValue = value
                Case 8
                    ev.SimulationObjectPropertyUnits = value
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, Flowsheet.GetTranslatedString1("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub grdiselmatrix_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdiselmatrix.CellValueChanged

        If e.RowIndex < 0 Then Exit Sub

    End Sub

    Private Sub gridsets_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gridsets.CellValueChanged

        If e.RowIndex < 0 Then Exit Sub

        Dim es = Manager.EventSetList(gridsets.Rows(gridsets.SelectedCells(0).RowIndex).Cells(0).Value)

        es.Description = gridsets.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

    End Sub
End Class