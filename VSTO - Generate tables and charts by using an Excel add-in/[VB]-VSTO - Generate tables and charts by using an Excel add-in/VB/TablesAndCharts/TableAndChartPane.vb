Imports System.Net

Public Class TableAndChartPane
    Public Sub New()
        InitializeComponent()
        PopulateListObjectHeaderCheckBoxList()

        'Populate the chart data source combo box.
        chartDataSourceComboBox.Items.Add("Open")
        chartDataSourceComboBox.Items.Add("High")
        chartDataSourceComboBox.Items.Add("Low")
        chartDataSourceComboBox.Items.Add("Close")
        chartDataSourceComboBox.Items.Add("Volume")
        chartDataSourceComboBox.Items.Add("Adj_Close")

        'Populate the chart style combo box.
        ChartStyleComboBox.Items.Add("line")
        ChartStyleComboBox.Items.Add("Column")
        ChartStyleComboBox.Items.Add("Area")

        'Populate the chart style combo box.
        ChartColorThemeComboBox.Items.Add("Gray background")
        ChartColorThemeComboBox.Items.Add("Blue background")
        ChartColorThemeComboBox.Items.Add("White background")

    End Sub

    Dim _vstoWorkSheet As Microsoft.Office.Tools.Excel.Worksheet
    Dim _worksheetInteropObject As Excel.Worksheet
    Dim _listObject As Microsoft.Office.Tools.Excel.ListObject = Nothing
    Dim _chart As Microsoft.Office.Tools.Excel.Chart = Nothing


    Public ReadOnly Property VstoWorksheet() As Microsoft.Office.Tools.Excel.Worksheet
        Get
            If _vstoWorkSheet Is Nothing Then
                If _worksheetInteropObject Is Nothing Then
                    _vstoWorkSheet = Globals.Factory.GetVstoObject(DirectCast(Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets(1), Excel.Worksheet))
                Else
                    _vstoWorkSheet = Globals.Factory.GetVstoObject(_worksheetInteropObject)
                End If
            End If

            _vstoWorkSheet.Activate()
            Return _vstoWorkSheet
        End Get
    End Property

    Public Sub SetWorksheet(worksheetInteropObject As Excel.Worksheet)
        _worksheetInteropObject = worksheetInteropObject
        _vstoWorkSheet = Nothing
    End Sub

    Private Sub PopulateListObjectHeaderCheckBoxList()
        ListObjectHeaders.Items.Add("Date", True)
        ListObjectHeaders.Items.Add("Open", True)
        ListObjectHeaders.Items.Add("High", True)
        ListObjectHeaders.Items.Add("Low", True)
        ListObjectHeaders.Items.Add("Close", True)
        ListObjectHeaders.Items.Add("Volume", True)
        ListObjectHeaders.Items.Add("Adj Close", True)
    End Sub

    ' When user chooses the checkbox, generate a new sheet, a table of data, and a chart.
    ' If the sheet, table, and chart already exist, delete them.
    Private Sub ListObject_Check(sender As Object, e As EventArgs) Handles ListObjectCheckBox.Click
        Dim listObjectName As String = "stockHistoryListObject"
        Dim chartName As String = "stockHistoryChart"

        If DirectCast(sender, System.Windows.Forms.CheckBox).Checked Then
            If dateTimePicker1.Value.[Date] >= DateTime.Now.[Date] Then

                MessageBox.Show("Please choose a starting date before today's date")
                DirectCast(sender, System.Windows.Forms.CheckBox).Checked = False
            Else
                Dim selection As Excel.Range = SelectedRange
                Dim tickerSymbol As String = selection.Value2

                Dim data As List(Of HistoricalStock) = Nothing
                Try
                    data = GetDataUpdatesFoOneDataSource(tickerSymbol, dateTimePicker1.Value.[Date].ToString())
                Catch generatedExceptionName As Exception
                    MessageBox.Show("Unable to return data. Please ensure that you select a valid stock ticker symbol" & " in your worksheet and then try again")
                    DirectCast(sender, System.Windows.Forms.CheckBox).Checked = False
                    Return
                End Try

                CreateNewSheet()

                If selection IsNot Nothing Then
                    _listObject = VstoWorksheet.Controls.AddListObject(Globals.ThisAddIn.Application.Range("A1"), listObjectName)
                    groupBox1.Enabled = True
                    groupBox2.Enabled = True
                    groupBox3.Enabled = True

                    _listObject.DataBindings.Clear()
                    _listObject.SetDataBinding(data)

                    Dim counter As Integer = 0

                    For Each range As Excel.Range In _listObject.HeaderRowRange.Cells
                        range.Value2 = ListObjectHeaders.Items(counter)
                        counter += 1
                    Next

                    AddChart(chartName)

                End If
            End If
        Else
            VstoWorksheet.Controls.Remove(listObjectName)
            VstoWorksheet.Controls.Remove(chartName)
            VstoWorksheet.Delete()
            SetWorksheet(Globals.ThisAddIn.Application.ActiveWorkbook.Sheets(1))

            groupBox1.Enabled = False
            groupBox2.Enabled = False
            groupBox3.Enabled = False
        End If
    End Sub

    Private Sub CreateNewSheet()

        Dim newWorksheet As Excel.Worksheet
        newWorksheet = DirectCast(Globals.ThisAddIn.Application.Worksheets.Add(), Excel.Worksheet)
        newWorksheet.Name = "Price history"
        SetWorksheet(newWorksheet)
    End Sub

    Private ReadOnly Property SelectedRange() As Excel.Range
        Get
            Dim selection As Excel.Range = TryCast(VstoWorksheet.Application.Selection, Excel.Range)

            If selection IsNot Nothing AndAlso selection.Worksheet.Name = VstoWorksheet.Name Then
                Return selection
            End If

            Return Nothing
        End Get
    End Property

    ' Define a class to hold information from the stock service.
    Public Class HistoricalStock
        Public Property [Date]() As DateTime
            Get
                Return m_Date
            End Get
            Set(value As DateTime)
                m_Date = value
            End Set
        End Property
        Private m_Date As DateTime
        Public Property Open() As Double
            Get
                Return m_Open
            End Get
            Set(value As Double)
                m_Open = value
            End Set
        End Property
        Private m_Open As Double
        Public Property High() As Double
            Get
                Return m_High
            End Get
            Set(value As Double)
                m_High = value
            End Set
        End Property
        Private m_High As Double
        Public Property Low() As Double
            Get
                Return m_Low
            End Get
            Set(value As Double)
                m_Low = value
            End Set
        End Property
        Private m_Low As Double
        Public Property Close() As Double
            Get
                Return m_Close
            End Get
            Set(value As Double)
                m_Close = value
            End Set
        End Property
        Private m_Close As Double
        Public Property Volume() As Double
            Get
                Return m_Volume
            End Get
            Set(value As Double)
                m_Volume = value
            End Set
        End Property
        Private m_Volume As Double
        Public Property AdjClose() As Double
            Get
                Return m_AdjClose
            End Get
            Set(value As Double)
                m_AdjClose = value
            End Set
        End Property
        Private m_AdjClose As Double
    End Class

    ' Query the stock service.
    Public Function GetDataUpdatesFoOneDataSource(ticker As String, mostRecentDate As String) As List(Of HistoricalStock)
        Dim _startDate As DateTime = DateTime.Now.[Date]
        Dim _endDate As DateTime
        _endDate = Convert.ToDateTime(mostRecentDate)

        Dim retval As New List(Of HistoricalStock)()

        If _startDate.[Date] <> _endDate.[Date] Then
            Dim _startMonthTemp As Integer = _startDate.Month - 1
            Dim _startMonth As String = _startMonthTemp.ToString()
            Dim _startDay As String = _startDate.Day.ToString()
            Dim _startYear As String = _startDate.Year.ToString()

            _endDate = _endDate.AddDays(1)
            Dim _endMonthTemp As Integer = _endDate.Month - 1
            Dim _endMonth As String = _endMonthTemp.ToString()
            Dim _endDay As String = _endDate.Day.ToString()
            Dim _endYear As String = _endDate.Year.ToString()

            Using web As New WebClient()
                Dim _inputString As String = "http://ichart.finance.yahoo.com/table.csv?s=" & ticker & "&d=" & _startMonth & "&e=" & _startDay & "&f=" & _startYear & "&g=d&a=" & _endMonth & "&b=" & _endDay & "&c=" & _endYear & "&ignore=.csv"

                Dim data As String = web.DownloadString(_inputString)

                data = data.Replace("r", "")
                Dim rows As String() = data.Split(ControlChars.Lf)

                'First row is headers so Ignore it                
                For i As Integer = 1 To rows.Length - 1
                    If rows(i).Replace("n", "").Trim() = "" Then
                        Continue For
                    End If
                    Dim cols As String() = rows(i).Split(","c)
                    Dim hs As New HistoricalStock()
                    hs.[Date] = Convert.ToDateTime(cols(0))
                    hs.Open = Convert.ToDouble(cols(1))
                    hs.High = Convert.ToDouble(cols(2))
                    hs.Low = Convert.ToDouble(cols(3))
                    hs.Close = Convert.ToDouble(cols(4))
                    hs.Volume = Convert.ToDouble(cols(5))
                    hs.AdjClose = Convert.ToDouble(cols(6))
                    retval.Add(hs)
                Next

                If retval.Count > 1 Then
                    If retval(0).[Date] = retval(1).[Date] Then
                        retval.RemoveAt(0)
                    End If
                End If
            End Using
        End If
        Return retval
    End Function

    Private Sub AddChart(chartName As String)

        Dim NativeWorksheet As Microsoft.Office.Interop.Excel.Worksheet =
            Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet

        Dim worksheet As Microsoft.Office.Tools.Excel.Worksheet =
            Globals.Factory.GetVstoObject(NativeWorksheet)

        Dim cells As Excel.Range = worksheet.Range("I1", "O22")
        Dim chart As Microsoft.Office.Tools.Excel.Chart = worksheet.Controls.AddChart(cells, chartName)
        chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine
        chart.SetSourceData(_listObject.ListColumns(5).Range.EntireColumn)
        _chart = chart
    End Sub

    Private Sub ListObjectHeaders_Click(sender As Object, e As EventArgs) Handles ListObjectHeaders.Click
        Dim columnToHide As Excel.Range = Nothing

        Select Case ListObjectHeaders.SelectedItem.ToString()
            Case "Date"
                columnToHide = _listObject.ListColumns(1).Range.EntireColumn
                Exit Select
            Case "Open"
                columnToHide = _listObject.ListColumns(2).Range.EntireColumn
                Exit Select
            Case "High"
                columnToHide = _listObject.ListColumns(3).Range.EntireColumn
                Exit Select
            Case "Low"
                columnToHide = _listObject.ListColumns(4).Range.EntireColumn
                Exit Select
            Case "Close"
                columnToHide = _listObject.ListColumns(5).Range.EntireColumn
                Exit Select
            Case "Volume"
                columnToHide = _listObject.ListColumns(6).Range.EntireColumn
                Exit Select
            Case "Adj Close"
                columnToHide = _listObject.ListColumns(7).Range.EntireColumn
                Exit Select
        End Select

        If columnToHide.Hidden = False Then
            columnToHide.Hidden = True
        Else
            columnToHide.Hidden = False
        End If

    End Sub
    Private Sub BlackStyle_CheckedChanged(sender As Object, e As EventArgs) Handles BlackStyle.CheckedChanged
        _listObject.TableStyle = "TableStyleMedium1"
    End Sub

    Private Sub BlueStyle_CheckedChanged(sender As Object, e As EventArgs) Handles BlueStyle.CheckedChanged
        _listObject.TableStyle = "TableStyleMedium2"
    End Sub

    Private Sub OrangeStyle_CheckedChanged(sender As Object, e As EventArgs) Handles OrangeStyle.CheckedChanged
        _listObject.TableStyle = "TableStyleMedium3"
    End Sub

    Private Sub GrayStyle_CheckedChanged(sender As Object, e As EventArgs) Handles GrayStyle.CheckedChanged
        _listObject.TableStyle = "TableStyleMedium4"
    End Sub

    Private Sub GreenStyle_CheckedChanged(sender As Object, e As EventArgs) Handles GreenStyle.CheckedChanged
        _listObject.TableStyle = "TableStyleMedium7"
    End Sub

    Private Sub chartDataSourceComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chartDataSourceComboBox.SelectedIndexChanged
        Select Case chartDataSourceComboBox.Text
            Case "Open"
                _chart.SetSourceData(_listObject.ListColumns(2).Range.EntireColumn)
                Exit Select
            Case "High"
                _chart.SetSourceData(_listObject.ListColumns(3).Range.EntireColumn)
                Exit Select
            Case "Low"
                _chart.SetSourceData(_listObject.ListColumns(4).Range.EntireColumn)
                Exit Select
            Case "Close"
                _chart.SetSourceData(_listObject.ListColumns(5).Range.EntireColumn)
                Exit Select
            Case "Volume"
                _chart.SetSourceData(_listObject.ListColumns(6).Range.EntireColumn)
                Exit Select
            Case "Adj_Close"
                _chart.SetSourceData(_listObject.ListColumns(7).Range.EntireColumn)
                Exit Select
            Case Else
                MessageBox.Show("Invalid Selection")
                Exit Select
        End Select
    End Sub

    Private Sub ChartStyleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChartStyleComboBox.SelectedIndexChanged
        Select Case ChartStyleComboBox.Text
            Case "Line"
                _chart.ChartType = Excel.XlChartType.xlLine
                Exit Select
            Case "Column"
                _chart.ChartType = Excel.XlChartType.xlColumnClustered
                Exit Select
            Case "Area"
                _chart.ChartType = Excel.XlChartType.xlArea
                Exit Select
            Case Else
                MessageBox.Show("Invalid Selection")
                Exit Select
        End Select
    End Sub

    Private Sub ChartColorThemeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChartColorThemeComboBox.SelectedIndexChanged
        Select Case ChartColorThemeComboBox.Text
            Case "White background"
                _chart.ChartStyle = 227
                Exit Select
            Case "Blue background"
                _chart.ChartStyle = 229
                Exit Select
            Case "Gray background"
                _chart.ChartStyle = 236
                Exit Select
            Case Else
                MessageBox.Show("Invalid Selection")
                Exit Select
        End Select
    End Sub




End Class
