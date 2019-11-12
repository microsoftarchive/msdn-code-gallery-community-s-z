Public Module MockData
    ''' <summary>
    ''' Returns a simple set of data for this demo
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetData() As DataTable
        Dim dt As New DataTable With {.TableName = "MyNames"}

        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier", .DataType = GetType(Int32),
                                            .AutoIncrement = True,
                                            .AutoIncrementSeed = 1,
                                            .ColumnMapping = MappingType.Hidden
                                           }
                                       )
        dt.Columns.Add(New DataColumn With {.ColumnName = "FirstName", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "LastName", .DataType = GetType(String)})

        dt.Rows.Add(New Object() {Nothing, "Mary", "Jones"})
        dt.Rows.Add(New Object() {Nothing, "Bob", "Adams"})
        dt.Rows.Add(New Object() {Nothing, "Henry", "Smith"})

        ' Not needed if loading from a database
        dt.AcceptChanges()

        Return dt

    End Function
End Module
