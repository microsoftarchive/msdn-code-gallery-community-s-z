using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvString;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string text =
                " Hola, esta cadena tiene las primeras dos palabras separadas por dos separadores:  Una coma y un espacio";
            char[] separators = {' ', '.', ',', ':'};
            foreach (TokenInfo ti in Tokenize.GetTokens(text, separators))
            {
                Console.WriteLine("Token: {0}, {1}", text.Substring(ti.StartPosition, ti.Length), ti);
            }
            //Get the substring that contains the first 2 words (tokens):
            int tokens = 0;
            int start = 0;
            int end = 0;
            foreach (TokenInfo ti in Tokenize.GetTokens(text, separators))
            {
                if (++tokens == 1) start = ti.StartPosition;
                else if (tokens == 2) end = ti.StartPosition + ti.Length;
                else break;
            }
            Console.WriteLine();
            Console.WriteLine("Subcadena que contiene las 2 primeras palabras (tokens):  \"{0}\"", text.Substring(start, end - start));
        }
    }
}
