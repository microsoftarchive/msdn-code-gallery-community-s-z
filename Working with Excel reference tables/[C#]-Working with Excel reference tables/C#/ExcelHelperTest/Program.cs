using ExcelHelper;
using System;

namespace ExcelHelperTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ExcelInfo Helper = new ExcelInfo();
            Helper.FileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File1.xlsx");
            Console.WriteLine(Helper.FileName);
            if (Helper.GetInformation())
            {
                var SheetNames = Helper.Sheets;
                Console.WriteLine("Sheet names");
                foreach (var Sheet in SheetNames)
                {
                    Console.WriteLine(Sheet);
                }
                Console.WriteLine();
                var ReferenceTables = Helper.ReferenceTables;
                if (ReferenceTables !=null)
                {
                    Console.WriteLine("Reference tables");
                    foreach (var item in ReferenceTables)
                    {
                        Console.WriteLine(item);
                    }                    
                }
                else
            	{
                    Console.WriteLine("No reference tables found");
	            }

            }
            Console.ReadLine();
        }
    }
}