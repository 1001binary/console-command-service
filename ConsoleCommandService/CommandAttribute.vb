''' <summary>
''' Represents the command attribute to configure command's information and settings.
''' </summary>
Friend Class CommandAttribute
    Inherits Attribute

    ''' <summary>
    ''' Gets the display name.
    ''' </summary>
    ''' <returns></returns>
    Property DisplayName As String

    ''' <summary>
    ''' Determines whether the current command is run at startup.
    ''' </summary>
    ''' <returns></returns>
    Property IsStartup As Boolean

    ''' <summary>
    ''' Determines whether the current command is enabled to run.
    ''' </summary>
    ''' <returns></returns>
    Property IsEnabled As Boolean = True

    ''' <summary>
    ''' Gets or sets the current option parameter.
    ''' </summary>
    ''' <returns></returns>
    Property OptionParam As String

    ''' <summary>
    ''' Gets or sets the command description.
    ''' </summary>
    ''' <returns></returns>
    Property Description As String

End Class
