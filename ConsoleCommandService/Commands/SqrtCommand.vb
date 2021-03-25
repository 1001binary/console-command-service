<Command(DisplayName:="Sqrt Command")>
Public Class SqrtCommand
    Implements ICommand

    Public Sub Execute() Implements ICommand.Execute
        Console.WriteLine("Sqrt Command.")
    End Sub
End Class
