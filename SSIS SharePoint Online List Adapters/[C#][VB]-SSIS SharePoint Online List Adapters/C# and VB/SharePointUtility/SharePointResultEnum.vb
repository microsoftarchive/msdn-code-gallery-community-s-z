''' <summary>
''' Enums that SharePoint returns embedded in the XML for the UPDATE method on the 'Lists' webservice
''' </summary>
''' <remarks></remarks>
Public Enum SharePointResult
    UnspecifiedError = &H1
    Success = &H0
    FolderAlreadyExists = &H8107090D
    InvalidLookup = &H80020005
    InvalidNumber = &H8102001A
    InvalidCurrency = &H8102001B
    InvalidDateTime = &H8102001C
    InvalidFieldValue = &H8102001D
    InvalidBoolean = &H8102001F
    InvalidValueForField = &H81020014
    ChangeConflict = &H81020015
    ItemDoesNotExist = &H81020016
    InvalidHyperlink = &H81020020
End Enum