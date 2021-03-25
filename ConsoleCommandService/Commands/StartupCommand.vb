<Command(DisplayName:="Startup Command", IsStartup:=True)>
Public Class StartupCommand
    Implements ICommand

    Private CurrentSelectionIdx As Integer
    Private IsArrowKeyEnabled As Boolean = True

    Private Sub PrintCommands()
        Dim Idx As Integer = 0

        For Each Command As ICommand In GlobalConfiguration.NormalCommandList
            Dim CommandAttr As CommandAttribute = ReflectionHelper.GetAttributeByObject(Of CommandAttribute)(Command)
            If CommandAttr Is Nothing Then Exit Sub

            If CurrentSelectionIdx = Idx Then
                Console.BackgroundColor = ConsoleColor.Green
                Console.ForegroundColor = ConsoleColor.Black
                Console.WriteLine(CommandAttr.DisplayName)
                Console.ResetColor()
            Else
                Console.WriteLine(CommandAttr.DisplayName)
            End If
            Idx += 1
        Next
    End Sub

    Private Sub Startup()
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine("CONSOLE COMMAND SERVICE (Press E to exit)")
        Console.ResetColor()
        Console.WriteLine("===============================================")
        Console.WriteLine("Select one of the following options:")
        PrintCommands()
    End Sub

    Public Sub Execute() Implements ICommand.Execute
        Startup()

        While True
            Dim KeyInfo As ConsoleKeyInfo = Console.ReadKey

            Select Case KeyInfo.Key
                Case ConsoleKey.UpArrow
                    If Not IsArrowKeyEnabled Then Continue While
                    If CurrentSelectionIdx - 1 >= 0 Then
                        CurrentSelectionIdx -= 1
                    Else
                        CurrentSelectionIdx = GlobalConfiguration.NormalCommandList.Count - 1
                    End If
                    Console.SetCursorPosition(0, 3)
                    PrintCommands()
                Case ConsoleKey.DownArrow
                    If Not IsArrowKeyEnabled Then Continue While
                    If CurrentSelectionIdx + 1 < GlobalConfiguration.NormalCommandList.Count Then
                        CurrentSelectionIdx += 1
                    Else
                        CurrentSelectionIdx = 0
                    End If
                    Console.SetCursorPosition(0, 3)
                    PrintCommands()
                Case ConsoleKey.Enter
                    For Idx = 0 To GlobalConfiguration.NormalCommandList.Count
                        Console.SetCursorPosition(0, 2 + Idx)
                        Console.WriteLine(New String(" "c, Console.WindowWidth))
                    Next

                    Console.SetCursorPosition(0, 2)
                    Dim CurrentCommand As ICommand = GlobalConfiguration.NormalCommandList(CurrentSelectionIdx)
                    Dim CurrentCommandAttribute As CommandAttribute = ReflectionHelper.GetAttributeByObject(Of CommandAttribute)(CurrentCommand)

                    Console.WriteLine(CurrentCommandAttribute.DisplayName & ":")
                    IsArrowKeyEnabled = False
                    CurrentCommand.Execute()
                Case ConsoleKey.Escape
                    Console.Clear()
                    IsArrowKeyEnabled = True
                    Startup()
                Case ConsoleKey.E
                    Exit While
                Case Else
                    Console.Beep()
            End Select

        End While
    End Sub
End Class
