' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook


' This interface is not CLS compliant because of its Office property.
<ComVisible(True)> _
<InterfaceType(ComInterfaceType.InterfaceIsDual)> _
<Guid("53ED8FA5-DBAD-40c4-8068-F20E7858DEB6")> _
<CLSCompliant(False)> _
Public Interface IFormRegionControls
    Property Inspector() As Outlook.Inspector
    Sub SetControlText(ByVal controlName As String, ByVal text As String)
End Interface
