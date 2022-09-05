﻿Imports DWSIM.Drawing.SkiaSharp.GraphicObjects
Imports DWSIM.Interfaces.Enums.GraphicObjects
Imports DWSIM.DrawingTools.Point

Namespace GraphicObjects.Shapes

    Public Class EnergySwitchGraphic

        Inherits ShapeGraphic

        Public gp_update As New SKPath()

#Region "Constructors"

        Public Sub New()
            Me.ObjectType = DWSIM.Interfaces.Enums.GraphicObjects.ObjectType.EnergySwitch
            Me.Description = "Energy Stream Splitter"
            Me.DrawingState = DrawState.FALSE_STATE
        End Sub

        Public Sub New(ByVal graphicPosition As SKPoint)
            Me.New()
            Me.SetPosition(graphicPosition)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer)
            Me.New(New SKPoint(posX, posY))
        End Sub

        Public Sub New(ByVal graphicPosition As SKPoint, ByVal graphicSize As SKSize)
            Me.New(graphicPosition)
            Me.SetSize(graphicSize)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As SKSize)
            Me.New(New SKPoint(posX, posY), graphicSize)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer)
            Me.New(New SKPoint(posX, posY), New SKSize(width, height))
        End Sub

#End Region

        Public Overrides Sub PositionConnectors()

            CreateConnectors(0, 0)

        End Sub

        Public Overrides Sub CreateConnectors(InCount As Integer, OutCount As Integer)

            Dim myIC1 As New ConnectionPoint
            myIC1.Position = New Point(X, Y + 0.5 * Height)
            myIC1.Type = ConType.ConEn

            Dim myOC1 As New ConnectionPoint
            myOC1.Position = New Point(X + Width, Y)
            myOC1.Type = ConType.ConEn

            Dim myOC2 As New ConnectionPoint
            myOC2.Position = New Point(X + Width, Y + 0.5 * Height)
            myOC2.Type = ConType.ConEn

            With InputConnectors

                If .Count <> 0 Then
                    .Item(0).Position = New Point(X, Y + 0.5 * Height)
                Else
                    .Add(myIC1)
                End If
                .Item(0).ConnectorName = "Inlet"

            End With

            With OutputConnectors

                If .Count <> 0 Then
                    .Item(0).Position = New Point(X + Width, Y)
                    .Item(1).Position = New Point(X + Width, Y + Height)
                Else
                    .Add(myOC1)
                    .Add(myOC2)
                End If
                .Item(0).ConnectorName = "Outlet 1"
                .Item(1).ConnectorName = "Outlet 2"

            End With

            Me.EnergyConnector.Active = False

        End Sub

        Public Overrides Sub Draw(ByVal g As Object)

            Dim canvas As SKCanvas = DirectCast(g, SKCanvas)

            CreateConnectors(0, 0)
            UpdateStatus()

            MyBase.Draw(g)

            Dim rect As New SKRect(X, Y, X + Width, X + Height)

            Dim gp As New SKPath()
            gp.MoveTo(Convert.ToInt32(X), Convert.ToInt32(Y))
            gp.LineTo(Convert.ToInt32(X + Width), Convert.ToInt32(Y))
            gp.LineTo(Convert.ToInt32(X + Width), Convert.ToInt32(Y + Height))
            gp.LineTo(Convert.ToInt32(X), Convert.ToInt32(Y + Height))
            gp.LineTo(Convert.ToInt32(X), Convert.ToInt32(Y))

            With gp
                .MoveTo(Convert.ToInt32(X), Convert.ToInt32(Y + 0.5 * Height))
                If DrawingState = DrawState.TRUE_STATE Then
                    .LineTo(Convert.ToInt32(X + Width), Convert.ToInt32(Y))
                ElseIf DrawingState = DrawState.FALSE_STATE Then
                    .LineTo(Convert.ToInt32(X + Width), Convert.ToInt32(Y + Height))
                End If
                .Close()
            End With




            Select Case DrawMode

                Case 0

                    'default

                    Dim myPen As New SKPaint()
                    With myPen
                        .Color = LineColor
                        .StrokeWidth = LineWidth
                        .IsStroke = True
                        .IsAntialias = GlobalSettings.Settings.DrawingAntiAlias
                    End With

                    Dim gradPen As New SKPaint()
                    With gradPen
                        .Color = SKColors.Yellow.WithAlpha(50)
                        .StrokeWidth = LineWidth
                        .IsStroke = False
                        .IsAntialias = GlobalSettings.Settings.DrawingAntiAlias
                    End With

                    canvas.DrawPath(gp, gradPen)

                    canvas.DrawPath(gp, myPen)

                Case 1

                    'b/w

                    Dim myPen As New SKPaint()
                    With myPen
                        .Color = SKColors.Black
                        .StrokeWidth = LineWidth
                        .IsStroke = True
                        .IsAntialias = GlobalSettings.Settings.DrawingAntiAlias
                    End With

                    canvas.DrawPath(gp, myPen)

                Case 2

                    'Gas/Liquid Flows

                Case 3

                    'Temperature Gradients

                Case 4

                    'Pressure Gradients

                Case 5

                    'Temperature/Pressure Gradients

            End Select

        End Sub

        'Public Sub UpdateDraw(ByVal g As Object, booleanExp As Boolean)
        '    Dim canvas As SKCanvas = DirectCast(g, SKCanvas)
        '
        '
        '    Dim myPen As New SKPaint()
        '    Select Case DrawMode
        '        Case 0
        '            With myPen
        '                .Color = LineColor
        '                .StrokeWidth = LineWidth
        '                .IsStroke = True
        '                .IsAntialias = GlobalSettings.Settings.DrawingAntiAlias
        '            End With
        '        Case 1
        '            With myPen
        '                .Color = SKColors.Black
        '                .StrokeWidth = LineWidth
        '                .IsStroke = True
        '                .IsAntialias = GlobalSettings.Settings.DrawingAntiAlias
        '            End With
        '        Case 2
        '
        '            'Gas/Liquid Flows
        '
        '        Case 3
        '
        '            'Temperature Gradients
        '
        '        Case 4
        '
        '            'Pressure Gradients
        '
        '        Case 5
        '
        '            'Temperature/Pressure Gradients
        '
        '    End Select
        '
        '
        '
        '    gp_update.Dispose()
        '    gp_update = New SKPath()
        '
        '    canvas.Clear()
        '    g.Draw()
        '
        '
        '    With gp_update
        '        .MoveTo(Convert.ToInt32(X), Convert.ToInt32(Y + 0.5 * Height))
        '        If booleanExp Then
        '            .LineTo(Convert.ToInt32(X + Width), Convert.ToInt32(Y))
        '        Else
        '            .LineTo(Convert.ToInt32(X + Width), Convert.ToInt32(Y + Height))
        '        End If
        '        .Close()
        '    End With
        '    canvas.DrawPath(gp_update, myPen)
        '
        '
        '
        '
        'End Sub


    End Class

End Namespace