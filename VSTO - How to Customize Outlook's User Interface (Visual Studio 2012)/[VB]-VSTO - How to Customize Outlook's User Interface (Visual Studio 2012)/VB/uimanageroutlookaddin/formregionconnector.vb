' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Vbe.Interop.Forms
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Reflection

' Need to add reference to Microsoft.Vbe.Interop.Forms.
' COM tab: Microsoft Forms 2.0 Object Library (the first one if there are more than one).
<ComVisible(True)> _
<Guid("38F28415-204F-479a-B9B2-A386A462F7DE")> _
<ProgId("UiManager.FormRegionConnector")> _
Public Class FormRegionConnector
    Implements Outlook.FormRegionStartup

    Private _formRegionName As String = "SimpleFormRegion"

    ' This method is not CLSCompliant because of its Office parameters.
    <CLSCompliant(False)> _
    Public Function GetFormRegionStorage( _
    ByVal FormRegionName As String, ByVal Item As Object, ByVal LCID As Integer, _
    ByVal FormRegionMode As Outlook.OlFormRegionMode, _
    ByVal FormRegionSize As Outlook.OlFormRegionSize) _
        As Object Implements Outlook.FormRegionStartup.GetFormRegionStorage

        Application.DoEvents()
        Select Case (FormRegionName)
            Case _formRegionName
                Return My.Resources.SimpleFormRegionOfs
            Case Else
                Return Nothing
        End Select

    End Function

    ' This method is not CLSCompliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Function GetFormRegionIcon( _
    ByVal FormRegionName As String, _
    ByVal LCID As Integer, _
    ByVal Icon As Outlook.OlFormRegionIcon) _
        As Object Implements Outlook.FormRegionStartup.GetFormRegionIcon

        Return PictureConverter.ImageToPictureDisp( _
            My.Resources.espressoCup)
    End Function

    Public Function GetFormRegionManifest( _
    ByVal FormRegionName As String, ByVal LCID As Integer) As Object _
    Implements Outlook.FormRegionStartup.GetFormRegionManifest
        Return My.Resources.SimpleFormRegionXml
    End Function


    ' This method is not CLSCompliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Sub BeforeFormRegionShow(ByVal FormRegion As Outlook.FormRegion) _
    Implements Outlook.FormRegionStartup.BeforeFormRegionShow
        If (Not FormRegion Is Nothing) Then
            ' Create a new wrapper for the form region controls, 
            ' and add it to our collection.
            Globals.ThisAddIn._uiElements.AttachFormRegion( _
                FormRegion.Inspector, New FormRegionControls(FormRegion))
        End If
    End Sub

End Class


