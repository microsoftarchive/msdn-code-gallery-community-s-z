using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MsSqlCeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            Model.DataContex dbContex = new Model.DataContex();
            Model.Manga manga = new Model.Manga();

            Console.WriteLine("Welcome a manga editor. Please write the name of manga: ");
            manga.title = Console.ReadLine();
            Console.WriteLine("\nCool! And what is the number of pages? ");
            manga.pages = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nWow! And who is the mangaka? ");
            manga.mangaka = Console.ReadLine();

            dbContex.mangas.Add(manga);
            dbContex.SaveChanges();

            var ma = (from m in dbContex.mangas select m).ToList();
            Console.WriteLine(ma[0].title);

            Console.WriteLine("\nTanks, the manga is save.");
            Console.ReadKey();
        }
    }
}
