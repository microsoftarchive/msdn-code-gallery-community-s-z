Imports Microsoft.Reporting.WebForms
Imports System.Data.Common

Public Class Report
    Inherits System.Web.UI.Page



    Private Const strCustomerID As String = "SELECT ""CustomerID"", ""CompanyName"", ""ContactName"", ""ContactTitle"" FROM  `Customers` "
    Private Const strCustomerAddress As String = "SELECT ""Address"", ""City"", ""Region"", ""PostalCode"", ""Country"", ""Phone"", ""Fax"" FROM  `Customers` "


    Private Const strOrderID As String = "SELECT ""OrderID"", ""CustomerID"", ""EmployeeID"", Date(""OrderDate"") AS ""OrderDate"",Date(""RequiredDate"") AS ""RequiredDate"" , DATE(""ShippedDate"") AS ""ShippedDate"", ""ShipVia"", ""Freight"", ""ShipName"", ""ShipAddress"", ""ShipCity"", ""ShipRegion"", ""ShipPostalCode"", ""ShipCountry"" FROM `Orders`  "

    Private strConnection = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory.ToString() + "Northwind.sl3"

    Private strError As String = ""
    Private dc As New DataCommon
    Private cmd As DbCommand


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If InitDataBase() Then
                LoadReport()
            Else
                Alert("Data Base does not Exist. \nPlease verify Name/location! \nOr install SQLite provider! ")
            End If

        End If

    End Sub

    'Private Const strMaster = "SELECT * FROM sqlite_master"
    'For Debug purpose added SHEMA - please make sure that you use existed database ....
    'Dim dtMaster As DataTable = db.FindDataSet(New StringBuilder(strMaster), strConnection).Tables(0)
    Protected Function InitDataBase() As Boolean
        Try
            dc = New DataCommon
            dc.connectionString = strConnection
            cmd = dc.commandDB
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'How To Report itself - http://rohit-developer.blogspot.com/2015/02/sub-report-in-rdlc-report-viewer.html

    'http://stackoverflow.com/questions/456982/microsoft-reporting-setting-subreport-parameters-in-code
    'https://blogs.msdn.microsoft.com/sqlforum/2011/01/02/walkthrough-add-a-subreport-in-local-report-in-reportviewer/

    'How to Run Subreport
    'https://msdn.microsoft.com/en-us/library/microsoft.reporting.webforms.localreport.subreportprocessing.aspx?cs-save-lang=1&cs-lang=vb#code-snippet-1

    Private Sub LoadReport()

        InitDataBase()

        cmd.CommandText = strCustomerID
        Dim dtCustomer As DataTable = dc.GetDataSet(cmd).Tables(0)

        Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
        Dim streamIds As String() = Nothing
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        ' ActivityCodeDescriptions.rdlc
        Dim reportPath As String = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Rdls\ReportCustomers.rdlc"

        '//Create MS Report object
        rv.Reset()
        rv.LocalReport.ReportPath = reportPath
        rv.ProcessingMode = ProcessingMode.Local
        rv.LocalReport.SetBasePermissionsForSandboxAppDomain(New System.Security.PermissionSet(System.Security.Permissions.PermissionState.Unrestricted))

        rv.LocalReport.DataSources.Clear()   ' MUST CLEAR DATA 

        rv.LocalReport.DataSources.Add(New ReportDataSource("dtCustomer", dtCustomer))

        Dim param As List(Of ReportParameter) = New List(Of ReportParameter)
        param.Add(New ReportParameter("pNameReport", "Customer Report"))
        rv.LocalReport.SetParameters(param)

        rv.AsyncRendering = True
        rv.DataBind()

        'Process subreport(s) which you include in main report (from ToolBox)
        AddHandler rv.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        rv.LocalReport.Refresh()
        rv.Visible = True

    End Sub

    'Process subreport(s) which you include in main report (from ToolBox)
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)

        Dim infoParam As ReportParameterInfoCollection = e.Parameters()
        Dim strCaseId As String = infoParam.First.Values(0).ToString()


        Select Case e.ReportPath
            Case "subreport1"    '  just example - how to manage multiply subreports ...

            Case "ReportCustomersAddress"
                cmd.CommandText = strCustomerAddress + " where ""CustomerID"" = '" + strCaseId + "'"
                Dim dtCustomersAddress As DataTable = dc.GetDataSet(cmd).Tables(0)
                e.DataSources.Add(New ReportDataSource("dtCustomersAddress", dtCustomersAddress))

            Case "subreport3"
        End Select

    End Sub





    Protected Sub Alert(ByVal message As String)

        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")

        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    'https://msdn.microsoft.com/en-us/library/dn154769.aspx
    Protected Sub rv_Drillthrough(sender As Object, e As DrillthroughEventArgs) Handles rv.Drillthrough
        'Get the instance of the Target report.


        Select Case e.ReportPath
            Case "subreport1"    '  just example - how to manage multiply subreports ...

            Case "ReportOrder"
                Dim report As LocalReport = e.Report
                Dim list As IList(Of ReportParameter) = report.OriginalParametersToDrillthrough
                Dim strCaseId As String = list.Item(0).Values(0).ToString
                InitDataBase()
                cmd.CommandText = strOrderID + " where ""CustomerID"" = '" + strCaseId + "'"
                Dim dtOrders As DataTable = dc.GetDataSet(cmd).Tables(0)
                report.DataSources.Add(New ReportDataSource("dtOrders", dtOrders))

            Case "subreport3"
        End Select


    End Sub

    Protected Sub btnMainReport_Click(sender As Object, e As EventArgs) Handles btnMainReport.Click
        LoadReport()
    End Sub
End Class