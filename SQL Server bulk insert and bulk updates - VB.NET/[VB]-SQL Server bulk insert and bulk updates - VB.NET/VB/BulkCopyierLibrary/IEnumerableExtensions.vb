Imports System.ComponentModel

Public Module IEnumerableExtensions
    <System.Runtime.CompilerServices.Extension>
    Public Function AsDataTable(Of T)(ByVal data As IEnumerable(Of T)) As DataTable
        Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim table = New DataTable()

        For Each prop As PropertyDescriptor In pdc
            table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next

        For Each item As T In data
            Dim row As DataRow = table.NewRow()
            For Each prop As PropertyDescriptor In pdc
                row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
            Next

            table.Rows.Add(row)
        Next

        Return table

    End Function
End Module