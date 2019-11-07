using System.Collections.Generic;
using System.Linq;


public static class ColumnInformationExtensions
{
    public static string SelectStatement(this List<ColumnInformation> sender, string TableName)
    {
        if (sender.Count == 0)
        {
            return $"SELECT * FROM {TableName}";
        }
        else
        {
            return "SELECT " + string.Join(",", sender.Select(col => $"[{col.Name}]").ToArray()) + $" FROM {TableName}";
        }
    }
}

