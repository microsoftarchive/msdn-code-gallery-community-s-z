' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Office = Microsoft.Office

Public Class TaskPaneConnector
    Implements Office.Core.ICustomTaskPaneConsumer

    Friend _ctpFactory As Office.Core.ICTPFactory

    ' This method is not CLSCompliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Sub CTPFactoryAvailable( _
    ByVal CTPFactoryInst As Office.Core.ICTPFactory) _
    Implements Office.Core.ICustomTaskPaneConsumer.CTPFactoryAvailable
        ' All we need do here is to cache the CTPFactory object, 
        ' so that we can create custom taskpanes later on.
        _ctpFactory = CTPFactoryInst
    End Sub

End Class



