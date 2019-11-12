Imports System.Net
Imports Microsoft.Samples.SqlServer.SSIS.SharePointUtility.Adapter

''' <summary>
''' Class to wrap the basic functionality to get information from Sharpoint
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class ListServiceUtility

    ''' <summary>
    ''' Making Constructor Private
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Gets the fields in a target SharePoint list
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Name of a list to load from SharePoint</param>
    ''' <returns>A list of SharepoingField objects that describe the field</returns>
    ''' <remarks></remarks>
    Public Shared Function GetFields(ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, ByVal listName As String, ByVal viewName As String) As List(Of DataObject.ColumnData)

        Using listsProxy = New ListsAdapter(sharepointUri, credentials)
            Dim viewId As String = listsProxy.LookupViewName(listName, viewName)
            Return listsProxy.GetSharePointFields(listName, viewId)
        End Using

    End Function

    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="viewName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFields(ByVal sharepointUri As Uri, ByVal listName As String, ByVal viewName As String) As List(Of DataObject.ColumnData)
        Return GetFields(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, viewName)
    End Function

    ''' <summary>
    ''' Get the list items of a SharePoint List
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Name of list to get data for</param>
    ''' <param name="fieldNames">Names of fields to retrieve from list</param>
    ''' <param name="query">&lt;Query&gt;caml query code&lt;/Query&gt; If this is invalid, it will be ignored.</param>
    ''' <param name="isRecursive">Whether to get all items in the target folder and subfolders</param>
    ''' <param name="pagingSize"># of records to retrieve at a time as the full list loads</param>
    ''' <returns>A list containing all of the records. Each item in the list is a dictionary of all the fields and values</returns>
    ''' <remarks></remarks>
    Public Shared Function GetListItemData(ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, _
                ByVal listName As String, _
                ByVal viewName As String, ByVal fieldNames As IEnumerable(Of String), _
                ByVal query As XElement, ByVal isRecursive As Boolean, ByVal pagingSize As Short) _
            As IEnumerable(Of Dictionary(Of String, String))

        Using listsProxy = New ListsAdapter(sharepointUri, credentials)
            Dim viewId As String = listsProxy.LookupViewName(listName, viewName)
            Return listsProxy.GetSharePointListItemData(listName, viewId, fieldNames, query, isRecursive, pagingSize)
        End Using

    End Function

    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="viewName"></param>
    ''' <param name="fieldNames"></param>
    ''' <param name="query"></param>
    ''' <param name="isRecursive"></param>
    ''' <param name="pagingSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListItemData(ByVal sharepointUri As Uri, _
                ByVal listName As String, _
                ByVal viewName As String, ByVal fieldNames As IEnumerable(Of String), _
                ByVal query As XElement, ByVal isRecursive As Boolean, ByVal pagingSize As Short) _
            As IEnumerable(Of Dictionary(Of String, String))

        Return GetListItemData(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, viewName, fieldNames, query, isRecursive, pagingSize)
    End Function


    ''' <summary>
    ''' Create a subfolder on a SharePoint site
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">List to create a subfolder in</param>
    ''' <param name="folderList">List of foldernames to create</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateFolders(ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, ByVal listName As String, ByVal viewName As String, ByVal folderList As IEnumerable(Of String)) As XElement

        Const ITEMTYPE_FOLDER As Short = 1

        Using listsProxy = New ListsAdapter(sharepointUri, credentials)

            Dim viewId As String = listsProxy.LookupViewName(listName, viewName)

            Dim batchItems = From f In folderList _
                             Select _
                                <Method Cmd="New">
                                    <Field Name="ID">New</Field>
                                    <Field Name="FSObjType"><%= ITEMTYPE_FOLDER %></Field>
                                    <Field Name="BaseName"><%= f %></Field>
                                </Method>
            Dim batchXml = <batch><%= batchItems %></batch>

            Return listsProxy.ExecuteSharePointUpdateBatch(listName, viewId, batchXml, 250)
        End Using

    End Function

    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="viewName"></param>
    ''' <param name="folderList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateFolders( _
                ByVal sharepointUri As Uri, ByVal listName As String, ByVal viewName As String, _
                ByVal folderList As IEnumerable(Of String)) As XElement

        Return CreateFolders(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, viewName, folderList)
    End Function
    ''' <summary>
    ''' Update list items on a SharePoint List
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Name of List to update </param>
    ''' <param name="fieldValueList">List of Items to update. Each item is a Dictionary representing the fields to 
    ''' modify. If updating an existing row, an ID MUST be within the list, or else a new row will be created.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateListItems( _
            ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, ByVal listName As String, ByVal viewName As String, _
            ByVal fieldValueList As IEnumerable(Of Dictionary(Of String, String)), ByVal batchSize As Short) As XElement

        Using listsProxy = New ListsAdapter(sharepointUri, credentials)

            Dim viewId As String = listsProxy.LookupViewName(listName, viewName)

            ' Get the public fields
            Dim fields = listsProxy.GetSharePointFields(listName, viewId)
            Dim availableFields = From f In fields _
                               Where f.IsHidden = False And f.IsReadOnly = False

            ' Make sure there are no 'duplicate' fields being updated in the set, such as a lookup raw field and a lookup id field.
            Dim uniqueFieldNames = (From row In fieldValueList
                                   From col In row.Keys
                                   Select col).Distinct()

            ' Determining the active fields used in the dataset will make the pre-process much easier and not cause it to scan the dataset again
            Dim activeFields = From col In uniqueFieldNames
                                Join fld In availableFields On fld.Name Equals col _
                                Select fld

            If (fieldValueList.Count() > 0) Then
                Dim dupeCheck = From fld In activeFields
                                Group By fld.SourceFieldName Into g = Count() _
                                Where g > 1 _
                                Select SourceFieldName

                If (dupeCheck.Count() > 0) Then
                    Dim dupeValues = String.Join(",", dupeCheck.ToArray())
                    Throw New SharePointUnhandledException( _
                        "A Lookup raw field and a lookup ID virtual field are detected. Remove the one not being edited:" & dupeValues)
                End If
            End If

            ' Reformat any lookup fields and such to make SharePoint happy
            listsProxy.PreProcessDataForSharePoint(activeFields, fieldValueList)

            ' Build up the linq query for the inserts
            Dim batchInsertItems = From row In fieldValueList _
                                   Where Not row.ContainsKey("ID") _
                                   Select _
                                     <Method Cmd="New">
                                         <Field Name="ID">New</Field>
                                         <%= From col In row.Keys _
                                             Join fld In activeFields On fld.Name Equals col _
                                             Select <Field Name=<%= fld.SourceFieldName %>><%= row(col) %></Field> _
                                         %>
                                     </Method>

            ' Build up the linq query for the updates
            Dim batchUpdateItems = From row In fieldValueList _
                                   Where row.ContainsKey("ID") _
                                   Select _
                                     <Method Cmd="Update">
                                         <Field Name="ID"><%= row("ID") %></Field>
                                         <%= From col In row.Keys _
                                             Join fld In activeFields On fld.Name Equals col _
                                             Where col <> "ID" _
                                             Select <Field Name=<%= fld.SourceFieldName %>><%= row(col) %></Field> _
                                         %>
                                     </Method>

            ' Join them together for processing
            Dim batchXml = <batch><%= batchInsertItems.Union(batchUpdateItems) %></batch>
            Return listsProxy.ExecuteSharePointUpdateBatch(listName, viewId, batchXml, batchSize)
        End Using

    End Function

    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="viewName"></param>
    ''' <param name="fieldValueList"></param>
    ''' <param name="batchSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateListItems( _
        ByVal sharepointUri As Uri, ByVal listName As String, ByVal viewName As String, _
        ByVal fieldValueList As IEnumerable(Of Dictionary(Of String, String)), ByVal batchSize As Short) As XElement

        Return UpdateListItems(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, viewName, fieldValueList, batchSize)
    End Function

    ''' <summary>
    ''' Create a batch XML structure to delete items from SharePoint
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Name of list to delete items from</param>
    ''' <param name="idList">List of sharepoitn Row IDs to delete</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteListItems(ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, ByVal listName As String, ByVal viewName As String, ByVal idList As IEnumerable(Of String)) As XElement

        Using listsProxy = New ListsAdapter(sharepointUri, credentials)

            Dim viewId As String = listsProxy.LookupViewName(listName, viewName)

            ' Build up the linq query for the deletes
            Dim batchDelete = From row In idList _
                               Select _
                                 <Method Cmd="Delete">
                                     <Field Name="ID"><%= row %></Field>
                                 </Method>

            ' Join them together for processing
            Dim batchXml = <batch><%= batchDelete %></batch>
            Return listsProxy.ExecuteSharePointUpdateBatch(listName, viewId, batchXml, 250)
        End Using

    End Function

    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="viewName"></param>
    ''' <param name="idList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteListItems( _
                ByVal sharepointUri As Uri, ByVal listName As String, ByVal viewName As String, _
                ByVal idList As IEnumerable(Of String)) As XElement
        Return DeleteListItems(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, viewName, idList)
    End Function

    ''' <summary>
    ''' Upload files to a SharePoint document library
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Name of Document Library list name</param>
    ''' <param name="localFilePathList">Name of local file paths to upload</param>
    ''' <returns>Dictionary of all files with a status indicating if the upload was successful</returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFiles(ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, ByVal listName As String, ByVal localFilePathList As IEnumerable(Of String)) _
            As IDictionary(Of String, Boolean)

        ' Get the target URI to upload the files to
        Dim targetUri = GetSharePointTargetUri(sharepointUri, listName)
        Return ListsAdapter.UploadFilesToSharePoint(targetUri, credentials, localFilePathList)

    End Function

    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="localFilePathList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFiles(ByVal sharepointUri As Uri, ByVal listName As String, ByVal localFilePathList As IEnumerable(Of String)) _
        As IDictionary(Of String, Boolean)
        Return UploadFiles(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, localFilePathList)

    End Function

    ''' <summary>
    ''' Remove files from a SharePoint Document Library
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Document Library List Name</param>
    ''' <param name="localFilePathList">List of local full paths of files to remove</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveFiles( _
            ByVal sharepointUri As Uri, ByVal credentials As NetworkCredential, ByVal listName As String, ByVal viewName As String, _
            ByVal localFilePathList As IEnumerable(Of String)) _
        As XElement

        Using listsProxy = New ListsAdapter(sharepointUri, credentials)

            ' Get the target URI to upload the files to
            Dim targetUri = GetSharePointTargetUri(sharepointUri, listName)

            Dim viewId As String = listsProxy.LookupViewName(listName, viewName)

            ' Get the list items to match against the file ref in order to get the ID needed for deleting the files
            Dim data = listsProxy.GetSharePointListItemData( _
                listName, viewId, New String() {"FileRef", "ID"}, <Query/>, False, 300)

            ' Join the files in the list with the fileref field from SharePoint.
            ' The fileref field is in the format [version]#[listname]/[filename], so we need to do a bit of work to get something that joins
            Dim batchItems = From fn In localFilePathList _
                            Join sf In data On sf("FileRef").Substring(sf("FileRef").LastIndexOf("/") + 1) Equals fn _
                            Select _
                            <Method Cmd="Delete">
                                <Field Name="ID"><%= sf("ID") %></Field>
                                <Field Name="FileRef"><%= targetUri.AbsoluteUri + fn %></Field>
                            </Method>
            Dim batchXml = <batch><%= batchItems %></batch>

            ' Do an UpdateBatch ONLY if there are items to process
            If batchItems.Elements.Count > 0 Then
                Return listsProxy.ExecuteSharePointUpdateBatch(listName, viewId, batchXml, 250)
            End If
        End Using

        Return Nothing

    End Function


    ''' <summary>
    ''' Pass through method for legacy purposes which will use default credentials
    ''' </summary>
    ''' <param name="sharepointUri"></param>
    ''' <param name="listName"></param>
    ''' <param name="viewName"></param>
    ''' <param name="localFilePathList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveFiles( _
            ByVal sharepointUri As Uri, ByVal listName As String, ByVal viewName As String, _
            ByVal localFilePathList As IEnumerable(Of String)) _
        As XElement
        Return RemoveFiles(sharepointUri, CredentialCache.DefaultNetworkCredentials, listName, viewName, localFilePathList)
    End Function

    ''' <summary>
    ''' Returns the URI pointing to the SharePoint List path (not the ASMX)
    ''' </summary>
    ''' <param name="sharepointUri">URL to the SharePoint site or subsite that has the list</param>
    ''' <param name="listName">Name of the list to get the path for</param>
    ''' <returns>URI location of the SharePoint Site</returns>
    ''' <remarks></remarks>
    Private Shared Function GetSharePointTargetUri(ByVal sharepointUri As Uri, ByVal listName As String) As Uri

        Dim targetUri As String = _
            sharepointUri.Scheme & Uri.SchemeDelimiter & sharepointUri.Authority & _
            String.Join("", sharepointUri.Segments.Take(sharepointUri.Segments.Length - 2).ToArray()) & listName.Trim() & "/"

        Return New Uri(targetUri)

    End Function

End Class
