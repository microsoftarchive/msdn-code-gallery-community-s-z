' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports Office = Microsoft.Office


' This interface is not CLS compliant because of its Office property.
<ComVisible(True)> _
<InterfaceType(ComInterfaceType.InterfaceIsDual)> _
<Guid("43189577-8667-4c8f-8167-EBF23CC285CB")> _
<CLSCompliant(False)> _
Public Interface IRibbonConnector
    Property Ribbon() As Office.Core.IRibbonUI
End Interface


' Regasm won't register an assembly that only contains interfaces.
' We need to define a COM-createable class in order to get a typelib.
' We don't want to use this class for anything, because we're
' implementing the interface in another assembly.
<ComVisible(True)> _
<ClassInterface(ClassInterfaceType.None)> _
<CLSCompliant(False)> _
Public Class RibbonConnectorPlaceholder
    Implements IRibbonConnector

    Public Property Ribbon() As Office.Core.IRibbonUI Implements IRibbonConnector.Ribbon
        Get
            Return Nothing
        End Get
        Set(ByVal value As Office.Core.IRibbonUI)
        End Set
    End Property

End Class
