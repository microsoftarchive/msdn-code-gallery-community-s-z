Imports System
Imports System.Xml.Linq
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Samples.SqlServer.SSIS.SharePointUtility
Imports Microsoft.Samples.SqlServer.SSIS.SharePointUtility.DataObject




'''<summary>
'''This is a test class for ListsServiceUtilityTest and is intended
'''to contain all ListsServiceUtilityTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ListsServiceUtilityTest

    Private testContextInstance As TestContext

    ''' <summary>
    ''' Folder where files will be loaded from for testing
    ''' </summary>
    ''' <remarks></remarks>
    Private testLocalFolderWithFiles As String = "C:\source\Code"

    ''' <summary>
    ''' SharePoint list which has at least one element used for testing
    ''' </summary>
    ''' <remarks></remarks>
    Private testSitePath As String = "http://TESTSERVER"
    Private testSiteListName As String = "Some Crazy List"
    Private testSiteListViewName As String = "Other View"
    Private testSiteDocumentLibraryName As String = "Documents"
    Private testSiteListSurveyName As String = "Test Survey"

    ''' <summary>
    ''' SharePoint list that uses HTTPS, will NOT be modified, used for verifying access to list
    ''' </summary>
    ''' <remarks></remarks>
    Private testSslSitePath As String = "https://TESTSITE/sites/site"
    Private testSslSiteListName As String = "List Name"
    Private testSslSiteListViewName As String = "View Name"

    Private testSslSubSitePath As String = "https://TESTSITE/sites/site2"
    Private testSslSubSiteListName As String = "Product Map Sample"

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property


    '''<summary>
    '''A test for UploadFiles
    '''</summary>
    <TestMethod()> _
    Public Sub UploadFilesTest()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteDocumentLibraryName

        Dim fullPathList = New List(Of String)(System.IO.Directory.GetFiles(testLocalFolderWithFiles))
        Dim uploadResults = ListServiceUtility.UploadFiles(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, fullPathList)
        If ((From result In uploadResults Where result.Value = False).Count() > 0) Then
            Assert.Fail("Uploads to SharePoint had a failure.")
        End If
        Assert.IsTrue(uploadResults.Count <> 0, "# of items from SharePoint should not be empty.")
    End Sub

    '''<summary>
    '''A test for UpdateListItems
    '''</summary>
    <TestMethod()> _
    Public Sub UpdateListItemsTestUsingList()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim fields = From f In ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing) _
                      Where f.IsHidden = False _
                      Select f.Name
        Dim data = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, fields, <Query/>, False, 50)
        data(0)("Title") = "Updated title: " + New Random().Next().ToString()
        Dim updateOutput = ListServiceUtility.UpdateListItems(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, data, 2)
        If ((From item In updateOutput...<action> Where item.Value = "Failure").Count() > 0) Then
            Assert.Fail("Updating the title on SharePoint failed.")
        End If
        Assert.IsTrue(updateOutput.Elements.Count <> 0, "# of items from sharepoint should not be empty.")

    End Sub

    '''<summary>
    '''A test for UpdateListItems
    '''</summary>
    <TestMethod()> _
    Public Sub UpdateListViewItemsTestUsingList()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim fields = From f In ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, testSiteListViewName) _
                      Where f.IsHidden = False _
                      Select f.Name
        Dim data = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, testSiteListViewName, fields, <Query/>, False, 50)
        data(0)("Title") = "Updated title: " + New Random().Next().ToString()
        Dim updateOutput = ListServiceUtility.UpdateListItems(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, testSiteListViewName, data, 2)
        If ((From item In updateOutput...<action> Where item.Value = "Failure").Count() > 0) Then
            Assert.Fail("Updating the title on SharePoint failed.")
        End If
        Assert.IsTrue(updateOutput.Elements.Count <> 0, "# of items from sharepoint should not be empty.")

    End Sub

    '''<summary>
    '''A test for UpdateListItems
    '''</summary>
    <TestMethod()> _
    Public Sub UpdateListItemsTestUsingListOnId()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim fields = From f In ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing) _
                      Where f.IsHidden = False _
                      Select f.Name
        Dim data = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, fields, <Query/>, False, 50)
        data(0)("ID") = "~!#@#!" + New Random().Next().ToString()
        Dim updateOutput = ListServiceUtility.UpdateListItems(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, data, 2)
        If ((From item In updateOutput...<action> Where item.Value = "Failure").Count() = 0) Then
            Assert.Fail("Did not receive an expected error updating the id on sharepoint.")
        End If
        Assert.IsTrue(updateOutput.Elements.Count <> 0, "# of items from sharepoint should not be empty.")

    End Sub

    Public Sub InsertListItemsTest()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim fields = From f In ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing) _
                      Where f.IsHidden = False _
                      Select f.Name
        Dim originalData = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, fields, <Query/>, False, 50)
        originalData(0).Remove("ID")
        Dim updateOutput = ListServiceUtility.UpdateListItems(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, originalData, 1)
        If ((From item In updateOutput...<action> Where item.Value = "Failure").Count() > 0) Then
            Assert.Fail("Updating the title on sharepoint failed.")
        End If
        Assert.IsTrue(updateOutput.Elements.Count <> 0, "# of items from sharepoint should not be empty.")

    End Sub

    '''<summary>
    '''A test for RemoveFiles
    '''</summary>
    <TestMethod()> _
    Public Sub RemoveFilesTestWithList()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteDocumentLibraryName

        ' First we need to upload the files
        UploadFilesTest()

        ' Now remove them.
        Dim fullPathList = New List(Of String)(System.IO.Directory.GetFiles(testLocalFolderWithFiles))
        Dim fileNameList = From f In fullPathList _
                               Select System.IO.Path.GetFileName(f)
        Dim removeResults = ListServiceUtility.RemoveFiles(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, fileNameList.ToList())
        If ((From item In removeResults...<action> Where item.Value = "Failure").Count() > 0) Then
            Assert.Fail("Updating the title on sharepoint failed.")
        End If
        Assert.IsTrue(removeResults.Elements.Count <> 0, "# of items from sharepoint should not be empty.")

    End Sub

    <TestMethod()> _
    Public Sub RemoveFilesTestWithArray()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteDocumentLibraryName

        ' First we need to upload the files
        UploadFilesTest()

        ' Now remove them.
        Dim fullPathList = New List(Of String)(System.IO.Directory.GetFiles(testLocalFolderWithFiles))
        Dim fileNameList = From f In fullPathList _
                               Select System.IO.Path.GetFileName(f)
        Dim removeResults = ListServiceUtility.RemoveFiles(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, fileNameList.ToArray())
        If ((From item In removeResults...<action> Where item.Value = "Failure").Count() > 0) Then
            Assert.Fail("Updating the title on sharepoint failed.")
        End If
        Assert.IsTrue(removeResults.Elements.Count <> 0, "# of items from sharepoint should not be empty.")

    End Sub

    '''<summary>
    '''A test for GetListItemData
    '''</summary>
    <TestMethod()> _
    Public Sub GetListItemDataTestNonSsl()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim fieldNames As IEnumerable(Of String) = New List(Of String)(New String() {"Id"})
        Dim isRecursive As Boolean = False
        Dim pagingSize As Short = 50
        Dim actual As IEnumerable(Of Dictionary(Of String, String))

        actual = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, listName, Nothing, fieldNames, <Query/>, isRecursive, pagingSize)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If (actual(0).ContainsKey("Id")) Then
            Assert.Fail("ID Field Column has not been found.")
        End If


    End Sub

    '''<summary>
    '''A test for GetListItemData
    '''</summary>
    <TestMethod()> _
    Public Sub GetListItemDataTestSurvey()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListSurveyName

        Dim listName As String = TEST_LIST_NAME
        Dim isRecursive As Boolean = False
        Dim pagingSize As Short = 50
        Dim actual As IEnumerable(Of Dictionary(Of String, String))

        Dim fields = From col In ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing) Select col.Name

        actual = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, listName, Nothing, fields, <Query/>, isRecursive, pagingSize)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If (actual(0).ContainsKey("Id")) Then
            Assert.Fail("ID Field Column has not been found.")
        End If


    End Sub

    <TestMethod()> _
    Public Sub GetListViewItemDataTestSsl()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSslSitePath + "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSslSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim fieldNames As IEnumerable(Of String) = New List(Of String)(New String() {"Id"})
        Dim isRecursive As Boolean = False
        Dim pagingSize As Short = 50
        Dim actual As IEnumerable(Of Dictionary(Of String, String))

        actual = ListServiceUtility.GetListItemData( _
            TEST_SHAREPOINTSITE_URL, listName, testSslSiteListViewName, fieldNames, <Query/>, isRecursive, pagingSize)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If (actual(0).ContainsKey("Id")) Then
            Assert.Fail("ID Field Column has not been found.")
        End If


    End Sub


    <TestMethod()> _
    Public Sub GetListItemDataTestSsl()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSslSitePath + "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSslSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim fieldNames As IEnumerable(Of String) = New List(Of String)(New String() {"Id"})
        Dim isRecursive As Boolean = False
        Dim pagingSize As Short = 50
        Dim actual As IEnumerable(Of Dictionary(Of String, String))

        actual = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, listName, Nothing, fieldNames, <Query/>, isRecursive, pagingSize)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If (actual(0).ContainsKey("Id")) Then
            Assert.Fail("ID Field Column has not been found.")
        End If


    End Sub

    '''<summary>
    '''A test for GetFields
    '''</summary>
    <TestMethod()> _
    Public Sub GetFieldsTestSsl()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSslSitePath + "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSslSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From fld In actual Where fld.Name = "Id").Count() = 1) Then
            Assert.Fail("ID Field Column has not been found.")
        End If
        Dim column = (From a In actual Where a.Name = "ID").Single()
        Assert.AreEqual(column.IsHidden, False)
        Assert.AreEqual(column.IsReadOnly, True)
        Assert.AreEqual(column.MaxLength, 25)

    End Sub

 

    '''<summary>
    '''A test for GetFields
    '''</summary>
    <TestMethod()> _
    Public Sub GetFieldsTestSslSubSite()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSslSubSitePath)
        Dim TEST_LIST_NAME As String = testSslSubSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From fld In actual Where fld.Name = "Id").Count() = 1) Then
            Assert.Fail("ID Field Column has not been found.")
        End If
        Dim column = (From a In actual Where a.Name = "ID").Single()
        Assert.AreEqual(column.IsHidden, False)
        Assert.AreEqual(column.IsReadOnly, True)
        Assert.AreEqual(column.MaxLength, 25)

    End Sub

    <TestMethod()> _
    Public Sub GetFieldsTestNonSsl()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From fld In actual Where fld.Name = "Id").Count() = 1) Then
            Assert.Fail("ID Field Column has not been found.")
        End If
        Dim column = (From a In actual Where a.Name = "ID").Single()
        Assert.AreEqual(column.IsHidden, False)
        Assert.AreEqual(column.IsReadOnly, True)
        Assert.AreEqual(column.MaxLength, 25)

    End Sub

    <TestMethod()> _
Public Sub GetFieldsOfViewTestNonSsl()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, testSiteListViewName)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From fld In actual Where fld.Name = "Id").Count() = 1) Then
            Assert.Fail("ID Field Column has not been found.")
        End If
        Dim column = (From a In actual Where a.Name = "ID").Single()
        Assert.AreEqual(column.IsHidden, False)
        Assert.AreEqual(column.IsReadOnly, True)
        Assert.AreEqual(column.MaxLength, 25)

    End Sub
    <TestMethod()> _
    Public Sub GetFieldsTestNonSslCheckMaxLength()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath & "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        Dim fldNoSize = From fld In actual Where fld.MaxLength = 0
        If (fldNoSize.Count() <> 0) Then
            Assert.Fail("Length is not specified on some fields.")
        End If

    End Sub


    <TestMethod()> _
    Public Sub GetFieldsTestUrlSiteUrlWithSlash()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath)
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From fld In actual Where fld.Name = "Id").Count() = 1) Then
            Assert.Fail("ID Field Column has not been found.")
        End If

    End Sub

    <TestMethod()> _
    Public Sub GetFieldsTestUrlSiteUrlWithNoSlash()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath)
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim listName As String = TEST_LIST_NAME
        Dim actual As List(Of ColumnData)

        actual = ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, listName, Nothing)
        Assert.IsTrue(actual.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From fld In actual Where fld.Name = "Id").Count() = 1) Then
            Assert.Fail("ID Field Column has not been found.")
        End If

    End Sub

    '''<summary>
    '''Removing items from a list
    '''</summary>
    <TestMethod()> _
    Public Sub DeleteListItemsTest()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath + "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        ' First we need to insert an item
        InsertListItemsTest()

        Dim fields = From f In ListServiceUtility.GetFields(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing) _
              Where f.IsHidden = False _
              Select f.Name

        Dim dataForDelete = ListServiceUtility.GetListItemData(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, fields, <Query/>, False, 50)
        Dim deleteIds = New List(Of String)
        deleteIds.Add(dataForDelete(dataForDelete.Count - 1)("ID"))
        ListServiceUtility.DeleteListItems(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, deleteIds)


        Dim actual As XElement
        actual = ListServiceUtility.DeleteListItems(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, deleteIds)
        Assert.IsTrue(actual.Elements.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From item In actual...<action> Where item.Value = "Failure").Count() = 0) Then
            Assert.Fail("Did not receive an expected error updating the id on sharepoint.")
        End If

    End Sub

    '''<summary>
    ''' Test Creating folders within a list
    '''</summary>
    <TestMethod()> _
    Public Sub CreateFoldersTest()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath + "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim folderList As String() = {"test2", "teast"}
        Dim actual As XElement
        actual = ListServiceUtility.CreateFolders(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, folderList)
        Assert.IsTrue(actual.Elements.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From item In actual...<action> Where item.Value = "Failure").Count() = 0) Then
            Assert.Fail("Did not receive an expected error updating the id on sharepoint.")
        End If

    End Sub

    '''<summary>
    ''' Test Creating folders within a list
    '''</summary>
    <TestMethod()> _
    Public Sub CreateFoldersTestDuplicate()
        Dim TEST_SHAREPOINTSITE_URL As Uri = New Uri(testSitePath + "/_vti_bin/lists.asmx")
        Dim TEST_LIST_NAME As String = testSiteListName

        Dim folderList As String() = {"test2", "test2"}
        Dim actual As XElement
        actual = ListServiceUtility.CreateFolders(TEST_SHAREPOINTSITE_URL, TEST_LIST_NAME, Nothing, folderList)
        Assert.IsTrue(actual.Elements.Count <> 0, "# of items from sharepoint should not be empty.")
        If ((From item In actual...<action> Where item.Value = "Failure").Count() = 0) Then
            Assert.Fail("Did not receive an expected error updating the id on sharepoint.")
        End If

    End Sub

End Class
