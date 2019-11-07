Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.LightSwitch
Imports Microsoft.LightSwitch.Security.Server
Imports Microsoft.SharePoint.Client
Imports System.Linq.Expressions

Namespace LightSwitchApplication
    Public Class PhotoListHelper
        Public Shared Sub DeletePhoto(url As String, siteContext As ClientContext)
            If String.IsNullOrEmpty(url) Then
                Throw New ArgumentNullException("url")
            End If
            If siteContext Is Nothing Then
                Throw New InvalidOperationException("Could not retrieve the Sharepoint context")
            End If

            Dim appWeb = siteContext.Web
            Dim webLists = appWeb.Lists
            Dim appPicList = webLists.GetByTitle("Photos")
            Dim appPicListFolder = appPicList.RootFolder
            Dim appPicListPictures = appPicListFolder.Files
            Dim picture = appPicListPictures.GetByUrl(url)
            siteContext.Load(picture)
            siteContext.ExecuteQuery()

            If (picture IsNot Nothing AndAlso picture.Exists) Then
                picture.DeleteObject()
                siteContext.ExecuteQuery()
            End If
        End Sub

        Public Shared Function AddPhoto(fileData As Byte(), name As String, siteContext As ClientContext) As String
            If fileData Is Nothing OrElse fileData.Length <= 0 Then
                Throw New ArgumentNullException("fileData")
            End If
            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentNullException("name")
            End If
            If siteContext Is Nothing Then
                Throw New InvalidOperationException("Could not retrieve the Sharepoint context")
            End If

            Dim appWeb = siteContext.Web
            siteContext.Load(appWeb)
            Dim webLists = appWeb.Lists
            Dim appPicList = webLists.GetByTitle("Photos")
            Dim appPicListFolder = appPicList.RootFolder
            Dim appPicListPictures = appPicListFolder.Files
            siteContext.Load(appPicListPictures)
            siteContext.ExecuteQuery()

            Dim createPicFileInfo = New FileCreationInformation()
            createPicFileInfo.Content = fileData
            createPicFileInfo.Url = String.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + "_" + name
            createPicFileInfo.Overwrite = True
            Try
                Dim myFile = appPicListPictures.Add(createPicFileInfo)
                siteContext.Load(myFile)
                siteContext.ExecuteQuery()

                Dim relativePhotoPathUri = myFile.ServerRelativeUrl
                Dim photoPathUri = New Uri(New Uri(siteContext.Web.Url), relativePhotoPathUri).AbsoluteUri
                Return photoPathUri
            Catch e As Exception
                ' Some browsers do not handle Http errors returned from POST request gracefully (IE, for example),
                ' so we're sticking the error message in the result.  
                Return "FAILED::" + e.Message
            End Try

        End Function
    End Class
End Namespace