using System;
using System.Diagnostics;
using System.Linq;

namespace WindowsFormsApplication1_cs
{
    public class Exporter
    {
        public void ToCsv(string ServerName, string DatabaseName, string SelectStatement, string FileName)
        {
            string DoubleQuote = ((char)(34)).ToString();
            string QueryToExceute = DoubleQuote + SelectStatement + DoubleQuote;
            string ExportFileName = DoubleQuote + FileName + DoubleQuote;

            var Process = new Process();
            
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardOutput = true;
            Process.StartInfo.RedirectStandardError = true;
            Process.StartInfo.CreateNoWindow = true;
            Process.StartInfo.FileName = "SQLCMD.EXE";
            Process.StartInfo.Arguments = "-S " + ServerName + " -d " + DatabaseName + " -E -Q " + 
                QueryToExceute + " -o " + ExportFileName + "  -h-1 -s\",\" -w 700";
            Console.WriteLine($"SQLCMD.EXE {Process.StartInfo.Arguments}");
            Process.Start();
            Process.WaitForExit();

            if (System.IO.File.Exists(FileName))
            {
                var contents = System.IO.File.ReadAllLines(FileName)
                    .Where(line => !line.ToLower().Contains("rows affected") && !string.IsNullOrWhiteSpace(line)).ToArray();
                System.IO.File.WriteAllLines(FileName, contents);
            }
        }
    }
}
