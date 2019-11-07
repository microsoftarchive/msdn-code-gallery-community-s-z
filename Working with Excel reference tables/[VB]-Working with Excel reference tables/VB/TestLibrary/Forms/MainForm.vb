Imports ExcelHelperLibrary
Imports System.Data.OleDb
Public Class frmMainForm
    Dim Builder As New OleDbConnectionStringBuilder With {.Provider = "Microsoft.ACE.OLEDB.12.0"}
    WithEvents bsReferenceTables As New BindingSource

    Private Sub cmdRunDemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRunDemo.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            DataGridView1.DataSource = Nothing
            bsReferenceTables.DataSource = Nothing

            cmdFetchReferenceTable.Enabled = False

            ListBox1.DataSource = Nothing
            ListBox2.DataSource = Nothing

            Dim MyLib As New ExcelInfo(OpenFileDialog1.FileName)

            Select Case MyLib.GetInformation
                Case ResultReason.Success

                    bsReferenceTables.DataSource = MyLib.ReferenceTables
                    cmdFetchReferenceTable.Enabled = bsReferenceTables.Count > 0
                    DataGridView1.DataSource = bsReferenceTables

                    For Each col As DataGridViewColumn In DataGridView1.Columns
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Next

                    ListBox1.DataSource = MyLib.Sheets
                    ListBox2.DataSource = MyLib.NameRanges

                Case ResultReason.FailedToOpenFile

                    MessageBox.Show("Failed to open selected file.")

                Case ResultReason.ExcelInternalFailure

                    MessageBox.Show("Encountered issues after opening selected file.")

            End Select
        End If

    End Sub
    ''' <summary>
    ''' Used to indicate if Excel was left in memory. It does not
    ''' account for Excel started outside this project so if you had
    ''' it open prior to running the project it will show just the same.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If ExcelInMemory() Then
            Me.ToolStripSplitButton1.Image = My.Resources.Excel1
        Else
            Me.ToolStripSplitButton1.Image = My.Resources.Excel2
        End If

        Me.ToolStripSplitButton1.Invalidate()
        Application.DoEvents()

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True

        Builder.Add("Extended Properties", "Excel 12.0; HDR=Yes")

        cmdCopyReferenceRows.DataBindings.Add("Enabled", Me.cmdFetchReferenceTable, "Enabled")

        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.FileName = ""

    End Sub
    Private Sub cmdFetchReferenceTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFetchReferenceTable.Click
        Dim CurrentRow As ExcelReferenceTable = CType(bsReferenceTables.Current, ExcelReferenceTable)

        Builder.DataSource = OpenFileDialog1.FileName

        Dim dt As New DataTable

        Using cn As New OleDbConnection With
            {
                .ConnectionString = Builder.ConnectionString
            }

            Using cmd As New OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = CurrentRow.SelectString
                }

                cn.Open()


                dt.Load(cmd.ExecuteReader)

                Dim f As New frmViewDataForm

                Try
                    f.DataGridView1.DataSource = dt
                    f.ShowDialog()
                Finally
                    f.Dispose()
                End Try

            End Using

        End Using

    End Sub
    Private Sub cmdCopyReferenceRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyReferenceRows.Click
        Dim lines = DataGridView1.ExportRows("(Empty)")
        Dim f As New frmViewDefinitionsForm

        Try
            f.TextBox1.Lines = lines
            f.TextBox1.Select(0, 0)
            f.ShowDialog()
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
