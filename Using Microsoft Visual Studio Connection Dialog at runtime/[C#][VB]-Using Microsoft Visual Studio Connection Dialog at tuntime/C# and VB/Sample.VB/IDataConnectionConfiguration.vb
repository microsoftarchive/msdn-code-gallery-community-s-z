'------------------------------------------------------------------------------ 
' <copyright company="Microsoft Corporation"> 
' Copyright (c) Microsoft Corporation. All rights reserved. 
' </copyright> 
'------------------------------------------------------------------------------ 

Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Microsoft.Data.ConnectionUI.VB

	Public Interface IDataConnectionConfiguration
		Function GetSelectedSource() As String
		Sub SaveSelectedSource(ByVal provider As String)

		Function GetSelectedProvider() As String
		Sub SaveSelectedProvider(ByVal provider As String)
	End Interface

End Namespace