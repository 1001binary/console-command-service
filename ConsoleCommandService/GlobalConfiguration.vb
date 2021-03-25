Imports System.Reflection

Friend Module GlobalConfiguration
    Public ReadOnly Property CommandList As IEnumerable(Of ICommand)

    Public ReadOnly Property NormalCommandList As IEnumerable(Of ICommand)
        Get
            If _CommandList Is Nothing Then
                Return New List(Of ICommand)
            End If

            Return _CommandList.Where(Function(C) Not ReflectionHelper.GetAttributeByObject(Of CommandAttribute)(C).IsStartup)
        End Get
    End Property

    Private Property _StartupCommand As ICommand

    Public ReadOnly Property StartupCommand As ICommand
        Get
            If _StartupCommand Is Nothing Then
                _StartupCommand = _CommandList.FirstOrDefault(Function(I) ReflectionHelper.GetAttributeByObject(Of CommandAttribute)(I).IsStartup)
            End If

            Return _StartupCommand
        End Get
    End Property

    Public Sub LoadCommands()
        Dim InterfaceType As Type = GetType(ICommand)

        _CommandList = Assembly.GetExecutingAssembly.GetTypes().Where(Function(P) InterfaceType.IsAssignableFrom(P) And P <> GetType(ICommand)).Select(Of ICommand)(Function(T) Activator.CreateInstance(T))
    End Sub
End Module
