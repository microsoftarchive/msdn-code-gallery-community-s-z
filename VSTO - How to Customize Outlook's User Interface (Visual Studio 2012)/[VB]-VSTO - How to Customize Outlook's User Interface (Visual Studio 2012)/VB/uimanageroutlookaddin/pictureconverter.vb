' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Friend Class PictureConverter
    Inherits AxHost

    Private Sub New()
        MyBase.New("")
    End Sub

    Public Shared Function ImageToPictureDisp(ByVal image As Image) As stdole.IPictureDisp
        Return CType(GetIPictureDispFromPicture(image), stdole.IPictureDisp)
    End Function
End Class



