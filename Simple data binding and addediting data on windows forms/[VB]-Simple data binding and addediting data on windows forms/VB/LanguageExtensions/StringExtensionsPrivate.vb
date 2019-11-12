''' <summary>
''' Code in this module is only for the project this module is in.
''' Why? Well there will be times when you need code available to 
''' several modules or classes in a project, this is an easy way
''' to do this. We simply do not pre-fix Module with Public as done
''' in StringExtensionsPublic.vb
''' </summary>
''' <remarks></remarks>
Module StringExtensionsPrivate
    <System.Diagnostics.DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function ProperCaseEnglish(ByVal sender As String) As String
        Return ProperCase(sender, "en-US")
    End Function
End Module
