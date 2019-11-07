Imports <xmlns:z="#RowsetSchema">
Imports <xmlns:rs="urn:schemas-microsoft-com:rowset">
Imports <xmlns:t="http://schemas.microsoft.com/sharepoint/soap/">

Imports System.ComponentModel
Imports System.Net
Imports System.Security.Principal
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports Microsoft.Samples.SqlServer.SSIS.SharePointUtility.DataObject
Imports System.Xml
Imports Microsoft.SharePoint.Client
Imports System.Security



Namespace Adapter

    ''' <summary>
    ''' Performs common operations against the SharePoint Lists Service. Provices pooling of connection information when necessary
    ''' among all related calls.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 




    Friend Class ListsAdapter : Implements IDisposable

        Private _disposed As Boolean
        Private _sharepointClient As ListsService.Lists

        Private _sharepointUri As Uri
        Private _sharepointBaseUri As Uri
        Private _webserviceUrl As String = "/_vti_bin/lists.asmx"
        Private _credential As System.Net.NetworkCredential

        ''' <summary>
        ''' Constructor keeps an instance of the lists Service handy using passed in network credential
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sharepointUri As Uri, ByVal credential As NetworkCredential)
            InitializeObject(sharepointUri, credential)
        End Sub


        Public Shared Function GetXmlNode(element As XElement) As XmlNode
            Using xmlReader As XmlReader = element.CreateReader()
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(xmlReader)
                Return xmlDoc
            End Using
        End Function


        Public Shared Function GetXElement(node As XmlNode) As XElement
            Dim xDoc As New XDocument()
            Using xmlWriter As XmlWriter = xDoc.CreateWriter()
                node.WriteTo(xmlWriter)
            End Using
            Return xDoc.Root
        End Function

        ''' <summary>
        ''' Method to centralize all initializations of this private object
        ''' </summary>
        ''' <param name="sharepointUri">Path to SharePoint</param>
        ''' <param name="credential">Network Credential of User to use</param>
        ''' <remarks></remarks>
        Public Sub InitializeObject(ByVal sharepointUri As Uri, ByVal credential As NetworkCredential)
            Dim sharePointPath As String = sharepointUri.AbsoluteUri.ToLower()
            If (Not sharePointPath.EndsWith(_webserviceUrl)) Then
                _sharepointUri = New Uri(sharePointPath.TrimEnd("/") + _webserviceUrl)
            Else
                _sharepointUri = New Uri(sharePointPath)
            End If
            _sharepointBaseUri = New Uri(_sharepointUri.AbsoluteUri.Replace(_webserviceUrl, ""))
            If (credential Is Nothing) Then
                _credential = CredentialCache.DefaultNetworkCredentials()
            Else
                _credential = credential
            End If

            ResetConnection()
        End Sub

        ''' <summary>
        ''' Resets the conneciton for the current client which is used for the lists service
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResetConnection()

            _sharepointClient = New ListsService.Lists()
            Dim Password__1 As New SecureString()
            For Each c As Char In _credential.Password.ToCharArray()
                Password__1.AppendChar(c)
            Next


            Dim creds = New SharePointOnlineCredentials(_credential.UserName, Password__1)

            Dim authCookie = creds.GetAuthenticationCookie(_sharepointBaseUri)
            Dim fedAuthString = authCookie.TrimStart("SPOIDCRL=".ToCharArray())
            Dim cookieContainer = New CookieContainer()
            cookieContainer.Add(_sharepointBaseUri, New Cookie("SPOIDCRL", fedAuthString))


            _sharepointClient.CookieContainer = cookieContainer
            _sharepointClient.Url = _sharepointUri.AbsoluteUri






        End Sub

        ''' <summary>
        ''' Adds header property to state that forms based auth is accepted
        ''' </summary>
        ''' <param name="scope"></param>
        ''' <remarks></remarks>
        Private Sub AddCustomHeader(ByVal scope As System.ServiceModel.OperationContextScope)

            Dim reqProp = New System.ServiceModel.Channels.HttpRequestMessageProperty()
            reqProp.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f")
            System.ServiceModel.OperationContext.Current.OutgoingMessageProperties(System.ServiceModel.Channels.HttpRequestMessageProperty.Name) = reqProp

        End Sub

        ''' <summary>
        ''' Gets the fields in a target SharePoint list
        ''' </summary>
        ''' <param name="listName">Name of a list to load from SharePoint</param>
        ''' <returns>A list of SharepoingField objects that describe the field</returns>
        ''' <remarks></remarks>
        Public Function GetSharePointFields(ByVal listName As String, ByVal viewId As String) As List(Of ColumnData)

            Try
                Dim listData = GetSharePointList(listName, viewId)

                ' Return the columns, but put the view columns in the List's specified order and then
                ' add the others after in the list.
                Dim fieldInfo = _
                    ( _
                        From l In listData...<t:Fields>.<t:Field> _
                        Join m In listData...<t:ViewFields>.<t:FieldRef> _
                            On l.@Name Equals m.@Name _
                        Select New ColumnData With _
                        { _
                            .Name = l.@Name, _
                            .DisplayName = l.@DisplayName, _
                            .SharePointType = l.@Type, _
                            .IsReadOnly = Boolean.Parse(IIf(l.@ReadOnly Is Nothing, False, l.@ReadOnly)), _
                            .IsHidden = Boolean.Parse(IIf(l.@Hidden Is Nothing, False, l.@Hidden)), _
                            .MaxLength = l.@MaxLength, _
                            .IsInView = True, _
                            .LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayRaw, _
                            .Choices = _
                            ( _
                                From c In l.<t:CHOICES>.<t:CHOICE> _
                                Select New ColumnChoiceData(c.Value) _
                            ).ToList() _
                       } _
                    ).Union _
                    ( _
                        From l In listData...<t:Fields>.<t:Field> _
                        Where Not (From x In listData...<t:ViewFields>.<t:FieldRef> Where x.@Name = l.@Name).Count() = 1 _
                        Select New ColumnData With _
                        { _
                            .Name = l.@Name, _
                            .DisplayName = l.@DisplayName, _
                            .SharePointType = l.@Type, _
                            .IsReadOnly = Boolean.Parse(IIf(l.@ReadOnly Is Nothing, False, l.@ReadOnly)), _
                            .IsHidden = Boolean.Parse(IIf(l.@Hidden Is Nothing, False, l.@Hidden)), _
                            .MaxLength = l.@MaxLength, _
                            .IsInView = False, _
                            .LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayRaw, _
                            .Choices = _
                            ( _
                                From c In l.<t:CHOICES>.<t:CHOICE> _
                                Select New ColumnChoiceData(c.Value) _
                            ).ToList() _
                       } _
                    )

                '' ONLY choice fields which are editable are those that are not keyed by ID (those must be updated by id)
                '' If a choice column has an ID or is a Lookup, then it is not editable by the value
                Dim fieldLookupSimpleChoices = _
                    From f In fieldInfo
                    Where (f.Choices.Count() > 0 And Not f.DoChoicesHaveID() _
                           And f.LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayRaw)
                    Select New ColumnData With _
                        { _
                            .Name = f.Name, _
                            .DisplayName = f.DisplayName, _
                            .SharePointType = f.SharePointType, _
                            .IsReadOnly = f.IsReadOnly, _
                            .IsHidden = f.IsHidden, _
                            .MaxLength = f.MaxLength, _
                            .IsInView = f.IsInView, _
                            .LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayNonKeyedValue, _
                            .Choices = _
                            ( _
                                From c In f.Choices _
                                Select New ColumnChoiceData(c.ToString()) _
                            ).ToList() _
                        }

                Dim fieldLookupValues = _
                       From f In fieldInfo
                        Where (f.SharePointType.StartsWith("Lookup") _
                        And f.LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayRaw)
                        Select New ColumnData With _
                            { _
                                .Name = f.Name, _
                                .DisplayName = f.DisplayName, _
                                .SharePointType = f.SharePointType, _
                                .IsReadOnly = True, _
                                .IsHidden = f.IsHidden, _
                                .MaxLength = f.MaxLength, _
                                .IsInView = f.IsInView, _
                                .LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayKeyedValue, _
                                .Choices = _
                                ( _
                                    From c In f.Choices _
                                    Select New ColumnChoiceData(c.ToString()) _
                                ).ToList() _
                            }
                Dim fieldLookupIDs = _
                       From f In fieldInfo
                        Where ((f.DoChoicesHaveID() Or (f.SharePointType.StartsWith("Lookup"))) _
                               And f.LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayRaw)
                        Select New ColumnData With _
                            { _
                                .Name = f.Name, _
                                .DisplayName = f.DisplayName, _
                                .SharePointType = f.SharePointType, _
                                .IsReadOnly = f.IsReadOnly, _
                                .IsHidden = f.IsHidden, _
                                .MaxLength = f.MaxLength, _
                                .IsInView = f.IsInView, _
                                .LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayID, _
                                .Choices = _
                                ( _
                                    From c In f.Choices _
                                    Select New ColumnChoiceData(c.ToString()) _
                                ).ToList() _
                            }

                Dim fieldChoiceValues = fieldLookupSimpleChoices.Union(fieldLookupValues).Union(fieldLookupIDs)
                Return fieldInfo.Union(fieldChoiceValues).ToList()
            Catch ex As System.ServiceModel.FaultException
                Throw New SharePointUnhandledException("Unhandled SharePoint Exception", ex)
            End Try

        End Function


        ''' <summary>
        ''' Upload files to a SharePoint document library
        ''' </summary>
        ''' <param name="localFilePathList">Name of local file paths to upload</param>
        ''' <returns>Dictionary of all files with a status indicating if the upload was successful</returns>
        ''' <remarks></remarks>
        Public Shared Function UploadFilesToSharePoint( _
                ByVal targetListUri As Uri, _
                ByVal credentials As NetworkCredential, _
                ByVal localFilePathList As IEnumerable(Of String)) _
                As IDictionary(Of String, Boolean)

            ' Format the structure which will have the local and remote paths
            ' Need to make this a list, vs deferred execution so changes to the list get stored
            Dim filesToUpload = (From file In localFilePathList _
                                Select New With _
                                { _
                                    .LocalPath = file, _
                                    .RemotePath = New Uri(targetListUri, System.IO.Path.GetFileName(file)), _
                                    .IsSuccess = False _
                                }).ToList()

            ' Execute the upload
            Using webClient As New System.Net.WebClient
                If (credentials Is Nothing) Then
                    webClient.UseDefaultCredentials = True
                Else
                    webClient.Credentials = credentials
                End If
                For Each file In filesToUpload
                    file.IsSuccess = True
                    Try
                        ' Not using wrapper method because we ant to use one WebClient connection per run, if possible for perf.
                        ' Error conditions will make a new one by default to 0 it out.
                        webClient.UploadFile(file.RemotePath.AbsoluteUri, "PUT", file.LocalPath)
                    Catch exFirst As System.Net.WebException
                        Trace.WriteLine("Error Performing Update (try 1 of 3)")
                        Try
                            ' When retrying, reset the webclient and do a completely new request after a delay
                            ExecuteUploadSharePointFile(file.RemotePath.AbsoluteUri, credentials, file.LocalPath, True)
                        Catch exSecond As System.Net.WebException
                            Trace.WriteLine("Error Performing Update (try 2 of 3)")
                            Try
                                ' When retrying, reset the webclient and do a completely new request after a delay
                                ExecuteUploadSharePointFile(file.RemotePath.AbsoluteUri, credentials, file.LocalPath, True)
                            Catch ex As System.Net.WebException
                                Trace.WriteLine("Error Performing Update (try 3 of 3) Skipping file.")
                                file.IsSuccess = False
                            End Try
                        End Try
                    End Try
                Next
            End Using


            ' Remove the anonymous stuff and just make a dictionary for each item and if the upload was a success
            Return filesToUpload.ToDictionary(Function(x) x.LocalPath, Function(x) x.IsSuccess)

        End Function

        ''' <summary>
        ''' Perform the actual upload of a file to SharePoint
        ''' </summary>
        ''' <param name="remotePath">Target full web url path of file</param>
        ''' <param name="localPath">Local full path of file to upload</param>
        ''' <param name="doPause">Whether to inject a 30 second pause</param>
        ''' <remarks></remarks>
        Private Shared Sub ExecuteUploadSharePointFile( _
            ByVal remotePath As String, ByVal credentials As NetworkCredential, ByVal localPath As String, ByVal doPause As Boolean)

            If (doPause) Then
                System.Threading.Thread.Sleep(30000)
            End If

            Using webClient As New System.Net.WebClient
                If (credentials Is Nothing) Then
                    webClient.UseDefaultCredentials = True
                Else
                    webClient.Credentials = credentials
                End If
                webClient.UploadFile(remotePath, "PUT", localPath)
            End Using

        End Sub

        ''' <summary>
        ''' Wrapper to get SharePoint list items from webservice for a given list
        ''' </summary>
        ''' <param name="listName">Name of list to get items for</param>
        ''' <param name="queryXml">XML Query structure for API</param>
        ''' <param name="viewXml">XML View structure for API</param>
        ''' <param name="pagingSize"># of records to get at a time</param>
        ''' <param name="queryOptionsXml">XML Query Options structure for API</param>
        ''' <returns>XML from SharePoint API</returns>
        ''' <remarks></remarks>
        Private Function GetSharePointListItems( _
                ByVal listName As String, ByVal viewId As String, ByVal queryXml As XElement, _
                ByVal viewXml As XElement, ByVal pagingSize As Short, _
                ByVal queryOptionsXml As XElement) As XElement

            Dim client = _sharepointClient



            Try
                Return GetXElement(client.GetListItems(listName.Trim(), viewId, GetXmlNode(queryXml), GetXmlNode(viewXml), pagingSize, GetXmlNode(queryOptionsXml), Nothing))
            Catch ex As System.ServiceModel.FaultException
                Throw New SharePointUnhandledException("Unspecified SharePoint Error.  A possible reason might be you are trying to retrieve too many items at a time (Batch size)", ex)
            End Try

        End Function

        ''' <summary>
        ''' Get the list items of a SharePoint List
        ''' </summary>
        ''' <param name="listName">Name of list to get data for</param>
        ''' <param name="fieldNames">Names of fields to retrieve from list</param>
        ''' <param name="query">&lt;Query&gt;caml query code&lt;/Query&gt; If this is invalid, it will be ignored.</param>
        ''' <param name="isRecursive">Whether to get all items in the target folder and subfolders</param>
        ''' <param name="pagingSize"># of records to retrieve at a time as the full list loads</param>
        ''' <returns>A list containing all of the records. Each item in the list is a dictionary of all the fields and values</returns>
        ''' <remarks></remarks>
        Public Function GetSharePointListItemData( _
                ByVal listName As String, ByVal viewId As String, ByVal fieldNames As IEnumerable(Of String), _
                ByVal query As XElement, ByVal isRecursive As Boolean, ByVal pagingSize As Short) _
                As IEnumerable(Of Dictionary(Of String, String))

            Dim nextPosition = String.Empty
            Dim xmlResults = <data/>

            ' If the query is invalid, then reset it.
            If (query.Name <> "Query") Then
                query = <Query/>
            End If

            ' Find the virtual fields created to store IDs or Values for a encoded field
            Dim vf = From f In fieldNames _
                     Where f.EndsWith(ColumnData.SUFFIX_LOOKUPVALUE) _
                     Or f.EndsWith(ColumnData.SUFFIX_LOOKUPID) _
                     Or f.EndsWith(ColumnData.SUFFIX_SIMPLELOOKUP)

            Dim xmlViewFields = _
                <ViewFields>
                    <%= From f In fieldNames _
                        Select <FieldRef Name=<%= f %>/> _
                    %>
                    <%= From f In vf _
                        Where f.EndsWith(ColumnData.SUFFIX_LOOKUPVALUE)
                        Select <FieldRef Name=<%= f.Replace(ColumnData.SUFFIX_LOOKUPVALUE, "") %>/> _
                    %>
                    <%= From f In vf _
                        Where f.EndsWith(ColumnData.SUFFIX_LOOKUPID)
                        Select <FieldRef Name=<%= f.Replace(ColumnData.SUFFIX_LOOKUPID, "") %>/> _
                    %>
                    <%= From f In vf _
                        Where f.EndsWith(ColumnData.SUFFIX_SIMPLELOOKUP)
                        Select <FieldRef Name=<%= f.Replace(ColumnData.SUFFIX_SIMPLELOOKUP, "") %>/> _
                    %>
                </ViewFields>

            Do
                Dim xmlQueryOptions = _
                    <QueryOptions>
                        <IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns>
                        <IncludeAttachmentUrls>FALSE</IncludeAttachmentUrls>
                        <Paging ListItemCollectionPositionNext=<%= nextPosition %>/>
                        <ViewAttributes Scope=<%= IIf(isRecursive, "RecursiveAll", "") %>></ViewAttributes>
                    </QueryOptions>

                Dim listItemData = GetSharePointListItems(listName, viewId, query, xmlViewFields, pagingSize, xmlQueryOptions)
                xmlResults.Add(listItemData...<z:row>)
                nextPosition = listItemData...<rs:data>.@ListItemCollectionPositionNext
            Loop Until nextPosition Is Nothing

            ' We only want to return fields where we have field meta information loaded, and where the field is not hidden.
            Dim outputData = From row In xmlResults.Elements() _
                             Select ( _
                                (From attr In row.Attributes _
                                Join field In fieldNames.Except(vf) On "ows_" + field Equals attr.Name.LocalName _
                                Where attr.Value.Trim().Length > 0 _
                                Select field, Value = attr.Value).Union _
 _
                                (From attr In row.Attributes _
                                Join field In fieldNames On "ows_" + field.Replace(ColumnData.SUFFIX_SIMPLELOOKUP, "") Equals attr.Name.LocalName _
                                Where attr.Value.Trim().Length > 0 _
                                And field.EndsWith(ColumnData.SUFFIX_SIMPLELOOKUP) _
                                Select field, Value = DecodeValue(attr.Value, 0, 1)).Union _
 _
                                (From attr In row.Attributes _
                                Join field In fieldNames On "ows_" + field.Replace(ColumnData.SUFFIX_LOOKUPVALUE, "") Equals attr.Name.LocalName _
                                Where attr.Value.Trim().Length > 0 _
                                And field.EndsWith(ColumnData.SUFFIX_LOOKUPVALUE) _
                                Select field, Value = DecodeValue(attr.Value, 1, 2)).Union _
 _
                                (From attr In row.Attributes _
                                Join field In fieldNames On "ows_" + field.Replace(ColumnData.SUFFIX_LOOKUPID, "") Equals attr.Name.LocalName _
                                Where attr.Value.Trim().Length > 0 _
                                And field.EndsWith(ColumnData.SUFFIX_LOOKUPID) _
                                Select field, Value = DecodeValue(attr.Value, 0, 2)) _
                                .ToDictionary(Function(x) x.field, Function(x) x.Value))

            Return outputData.ToList()

        End Function

        ''' <summary>
        ''' Decode the data from the sharepoint list to make it easier to understand 
        ''' </summary>
        ''' <param name="encodedData"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="stepIndex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DecodeValue(ByVal encodedData As String, ByVal startIndex As Integer, ByVal stepIndex As Integer) As String

            Dim workingData As String = encodedData
            If (workingData.StartsWith(";#")) Then
                workingData = workingData.Remove(0, 2)
            End If
            If (workingData.EndsWith(";#")) Then
                workingData = workingData.Remove(workingData.Length - 2)
            End If

            Dim valArray = workingData.Split({";#"}, StringSplitOptions.None)
            If valArray.Length >= stepIndex Then
                Dim decodedValueString As String = ""
                For i = startIndex To valArray.Length - 1 Step stepIndex
                    decodedValueString += valArray(i)
                    If (i + stepIndex <= (valArray.Length - 1)) Then
                        decodedValueString += Environment.NewLine
                    End If
                Next
                Return decodedValueString
            Else
                Return encodedData
            End If

        End Function

        ''' <summary>
        ''' Find the view and return the ID to continue the load
        ''' </summary>
        ''' <param name="listName"></param>
        ''' <param name="viewName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LookupViewName(ByVal listName As String, ByVal viewName As String) As String

            If ((viewName IsNot Nothing) AndAlso (viewName.Length > 0)) Then
                Using viewAdapter = New ViewsAdapter(_sharepointBaseUri, _credential)

                    Dim viewData = viewAdapter.GetViewList(listName.Trim())
                    Dim viewId = From x In viewData Where x.DisplayName.ToUpper() = viewName.ToUpper() Select x.Name

                    If (viewId.Count() = 1) Then
                        Return viewId(0)
                    Else
                        Throw New SharePointUtility.SharePointUnhandledException( _
                            String.Format("List '{0}' does not contain a view named '{1}'", listName, viewName))
                    End If
                End Using
            Else
                Return Nothing
            End If


        End Function


        ''' <summary>
        ''' Return the elements within a SharePoint list
        ''' </summary>
        ''' <param name="listName">Name of list to grab items for</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetSharePointList(ByVal listName As String, ByVal viewId As String) As XElement
            Dim client = _sharepointClient
            Return GetXElement(client.GetListAndView(listName.Trim(), viewId))
        End Function

        ''' <summary>
        ''' Update the data to conform to Sharepoint Rules, in particular for Lookups
        ''' </summary>
        ''' <param name="activeFields"></param>
        ''' <param name="fieldValueList"></param>
        ''' <remarks></remarks>
        Public Sub PreProcessDataForSharePoint(ByVal activeFields As IEnumerable(Of ColumnData), ByVal fieldValueList As IEnumerable(Of Dictionary(Of String, String)))

            If (fieldValueList.Count() > 0) Then
                Dim choiceDataElements = (From fld In activeFields
                                         Where fld.LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayNonKeyedValue
                                         Select fld.Name).ToArray()

                Dim lookupDataElements = (From fld In activeFields
                                         Where fld.LookupFieldDisplay = ColumnData.EncodedFieldDisplayEnum.DisplayID
                                         Select fld.Name).ToArray()

                For Each dataRow In fieldValueList
                    For Each k In choiceDataElements
                        If (dataRow.ContainsKey(k)) Then
                            If (dataRow(k).Contains(Environment.NewLine)) Then
                                dataRow(k) = ";#" & dataRow(k).Replace(Environment.NewLine, ";#") & ";#"
                            End If
                        End If

                    Next

                    For Each k In lookupDataElements
                        If (dataRow.ContainsKey(k)) Then
                            If (dataRow(k).Contains(Environment.NewLine)) Then
                                dataRow(k) = dataRow(k).Replace(Environment.NewLine, ";#TEXT;#")
                            End If
                        End If
                    Next

                Next

            End If


        End Sub


        ''' <summary>
        ''' Perform updates in batches to SharePoint
        ''' </summary>
        ''' <param name="listName">Name of list to submit updates to</param>
        ''' <param name="batchXml">SharePoint Batch XML Structure</param>
        ''' <returns>XElement structure with results.</returns>
        ''' <remarks></remarks>
        Public Function ExecuteSharePointUpdateBatch(ByVal listName As String, ByVal viewId As String, ByVal batchXml As XElement, ByVal batchSize As Short) As XElement

            ' Generate an ID for all of th ebatch items
            Dim idGen As Short = 0
            For Each batchNode In batchXml.Elements
                idGen += 1
                batchNode.@ID = idGen
            Next
            If (idGen = 0) Then
                Throw New ArgumentException("There must be elements to process.")
            End If

            Dim xmlResults As XElement = <results/>
            Dim batchGroupMax As Short = Math.Ceiling(batchXml.Elements.Count / batchSize)
            For i = 0 To batchGroupMax - 1
                Dim batchGroupXml = (From element In batchXml.Elements _
                                     Select element).Skip(batchSize * i).Take(batchSize)

                Dim batchWrapper = <Batch OnError="Continue" ListVersion="1" ViewName=<%= viewId %>><%= batchGroupXml %></Batch>

                '
                ' Perform the update
                '
                Dim queryResult = <t:Result/>
                Try
                    ' Make the call, capturing any results
                    queryResult = ExecuteUpdateSharePointList(listName, batchWrapper, False)

                Catch ex As System.ServiceModel.FaultException

                    Try
                        ' If an exception occurs, try it again...
                        Trace.WriteLine("Error Performing Update (try 2 of 2)")
                        queryResult = ExecuteUpdateSharePointList(listName, batchXml, True)

                    Catch Any As System.ServiceModel.FaultException
                        ' If this is a bad failure, then we want to mark that all of the items failed to update. Since the error
                        ' message from SharePoint is useless, we just give an unspecified error.
                        queryResult = <Results>
                                          <%= _
                                              From origItem In batchXml.Elements() _
                                              Select _
                                              <t:Result ID=<%= origItem.@ID & ",Update" %>> _
                                                      <t:ErrorCode>0x1</t:ErrorCode> _
                                                      <z:row/>
                                              </t:Result> _
                                          %>
                                      </Results>
                        Trace.WriteLine("Error Performing Update - Entire batch aborted.")
                    End Try

                End Try
                xmlResults.Add(queryResult...<t:Result>)

            Next


            '
            ' Look for errors in the results and add them to the current results
            '
            ' Get the public fields to match against in the returned results
            Dim fields = GetSharePointFields(listName, viewId)
            Dim activeFields = From f In fields _
                               Where f.IsHidden = False

            Dim outputSuccessData = _
                From row In xmlResults.<t:Result> _
                Where row.<t:ErrorCode>.Value = "0x00000000" _
                Select _
                 <result ID=<%= row.@ID.Split(",")(0) %>>
                     <action>Success</action>
                     <row><%= _
                              From col In row.<z:row>.Attributes _
                              Join fld In activeFields On "ows_" + fld.SourceFieldName Equals col.Name _
                              Where fld.LookupFieldDisplay = SharePointUtility.DataObject.ColumnData.EncodedFieldDisplayEnum.DisplayRaw _
                              Select New XAttribute(fld.SourceFieldName, col.Value) _
                              Distinct
                          %></row>
                 </result>

            Dim outputFailedData = _
                 From row In xmlResults.<t:Result> _
                 Where row.<t:ErrorCode>.Value <> "0x00000000" _
                 Select _
                 <result ID=<%= row.@ID.Split(",")(0) %>>
                     <action>Failure</action>
                     <errorCode><%= row.<t:ErrorCode>.Value %></errorCode>
                     <errorDescription><%= LookupErrorCode(row.<t:ErrorCode>.Value) %></errorDescription>
                     <row><%= _
                              From col In row.<z:row>.Attributes _
                              Join fld In activeFields On "ows_" + fld.SourceFieldName Equals col.Name _
                              Where fld.LookupFieldDisplay = SharePointUtility.DataObject.ColumnData.EncodedFieldDisplayEnum.DisplayRaw _
                              Select New XAttribute(fld.SourceFieldName, col.Value) _
                              Distinct
                          %></row>
                 </result>


            Return <results><%= outputSuccessData.Union(outputFailedData) %></results>

        End Function


        ''' <summary>
        ''' Return the error description for a code as per the LISTS API Documentation
        ''' http://download.microsoft.com/download/8/5/8/858F2155-D48D-4C68-9205-29460FD7698F/%5BMS-LISTSWS%5D.PDF
        ''' </summary>
        ''' <param name="errorCode">ex:0x81020015</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function LookupErrorCode(ByVal errorCode As String) As String
            Dim hexNumber = errorCode.TrimStart("0", "x")

            Select Case Int32.Parse(hexNumber, Globalization.NumberStyles.AllowHexSpecifier)
                ' Errors from UpdateListItemsResponse
                Case SharePointUtility.SharePointResult.Success
                    Return "Success"
                Case SharePointUtility.SharePointResult.ChangeConflict
                    Return "The changes requested conflict with those made by another client."
                Case SharePointUtility.SharePointResult.InvalidValueForField
                    Return "A generic error has been encountered, such as an invalid value being specified for a Field."
                Case SharePointUtility.SharePointResult.InvalidFieldValue
                    Return "Invalid column value in the data being updated (ex: Date Time, Multiple Lookup value, Person, etc)."
                Case SharePointUtility.SharePointResult.InvalidDateTime
                    Return "Invalid Date/Time value in the data being updated."
                Case SharePointUtility.SharePointResult.InvalidNumber
                    Return "Invalid Number value in the data being updated."
                Case SharePointUtility.SharePointResult.InvalidCurrency
                    Return "Invalid Currency value in the data being updated."
                Case SharePointUtility.SharePointResult.InvalidHyperlink
                    Return "Invalid Hyperlink value in the data being updated."
                Case SharePointUtility.SharePointResult.InvalidBoolean
                    Return "Invalid boolean (0/1) value in the data being updated."
                Case SharePointUtility.SharePointResult.ItemDoesNotExist
                    Return "List item referred to in the request does not exist."
                Case SharePointUtility.SharePointResult.FolderAlreadyExists
                    Return "Folder already exists."
                Case SharePointUtility.SharePointResult.UnspecifiedError
                    Return "Unspecified error, such as too many items being updated at once (batch), or an invalid core field value."
                Case Else
                    Return "Unspecified Error - Check SharePoint Server Logs if possible."
            End Select
        End Function

        ''' <summary>
        ''' Wrapper to update the list during retry / error conditions
        ''' </summary>
        ''' <param name="listName">Name of the list to update</param>
        ''' <param name="batchXml">Update XML for webservice</param>
        ''' <param name="doPause">Whether to inject a 1 second pause before executing</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ExecuteUpdateSharePointList( _
                ByVal listName As String, ByVal batchXml As XElement, _
                ByVal doPause As Boolean) As XElement

            If (doPause) Then
                ResetConnection()
                System.Threading.Thread.Sleep(1000)
            End If

            Dim client = _sharepointClient
            Return GetXElement(client.UpdateListItems(listName.Trim(), GetXmlNode(batchXml)))

        End Function

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not _disposed Then
                If disposing Then
                    ' Free Managed Objects
                    Dim dispose As IDisposable
                    dispose = _sharepointClient
                    dispose.Dispose()
                    _sharepointClient = Nothing
                End If
                ' Free your own state (unmanaged objects).
                ' Set large fields to null.

            End If
            _disposed = True
        End Sub


#Region " IDisposable Support "

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overrides Sub Finalize()
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region



    End Class
End Namespace
