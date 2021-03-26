<Command(DisplayName:="Sqrt Command")>
Public Class SqrtCommand
    Implements ICommand

    Public Sub Execute() Implements ICommand.Execute
        Console.WriteLine("Sqrt(9) = {0}", Math.Sqrt(9))
    End Sub
End Class
