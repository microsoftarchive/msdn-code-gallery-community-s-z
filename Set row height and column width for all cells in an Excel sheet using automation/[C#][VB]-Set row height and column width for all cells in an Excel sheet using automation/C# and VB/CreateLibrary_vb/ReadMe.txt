You can do this in C# too, just did not see the reason to do so for this sample.


xlCells = xlWorkSheet.Cells
Dim EntireRow As Excel.Range = xlCells.EntireRow
EntireRow.RowHeight = RowHeight
EntireRow.ColumnWidth = ColumnHeight