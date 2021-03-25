Friend Module ReflectionHelper

    Public Function GetAttributeByObject(Of TAttribute As Attribute)(Obj As Object) As TAttribute
        Return Obj.GetType.GetCustomAttributes(False).FirstOrDefault
    End Function

End Module
