using System;
using System.Data;
using System.IO;

namespace Sample2
{
    /// <summary>
    /// Mocked states, would normally come
    /// from a database reference table.
    /// </summary>
    public class States
    {
        public DataTable Read()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn() { ColumnName = "Id", DataType = typeof(int) });
            dt.Columns.Add(new DataColumn() { ColumnName = "Name", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn() { ColumnName = "Abbr", DataType = typeof(string) });

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "States.txt");
            var data = File.ReadAllLines(fileName);

            string[] items = new string[3];

            dt.Rows.Add(new object[] { 0, "", "Select" });

            foreach (string line in data)
            {
                items = line.Split(',');
                dt.Rows.Add(new object[] { Convert.ToInt32(items[0]),items[1],items[2] });
            }

            return dt;
        }
    }
}
