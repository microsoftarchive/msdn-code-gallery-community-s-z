using System;
using System.IO;
using System.Text;

namespace Mm.ExportableDataGrid
{
    public class CsvExporter : IExporter
    {
        private readonly StringBuilder sb = new StringBuilder();
        private readonly string _delimiter;

        public CsvExporter(char delimiter)
        {
            _delimiter = delimiter.ToString();
        }

        public char Delimiter
        {
            get { return _delimiter[0]; }
        }

        public void AddColumn(string value)
        {
            sb.Append(value.Replace(_delimiter, 
                string.Format("\"{0}\"", _delimiter)));
            sb.Append(_delimiter);
        }

        public void AddLineBreak()
        {
            sb.Remove(sb.Length - 1, 1); //remove trailing delimiter
            sb.AppendLine();
        }

        public string Export(string exportPath)
        {
            if (string.IsNullOrEmpty(exportPath))
            {
                Random rnd = new Random();
                exportPath = string.Format("{0}.csv", rnd.Next());
            }
            else if (!Path.GetExtension(exportPath).ToLower().Equals(".csv"))
            {
                throw new ArgumentException("Invalid file extension.", "exportPath");
            }


            File.WriteAllText(exportPath, sb.ToString().Trim());
            sb.Clear();
            return exportPath;
        }
    }
}
