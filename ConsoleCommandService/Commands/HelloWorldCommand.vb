<Command(DisplayName:="Hello World Command")>
Public Class HelloWorldCommand
    Implements ICommand

    Public Sub Execute() Implements ICommand.Execute
        Console.WriteLine("Hello World!")
    End Sub
End Class
