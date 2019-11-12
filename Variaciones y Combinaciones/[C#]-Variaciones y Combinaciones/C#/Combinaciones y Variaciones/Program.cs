using System;
using System.Collections.Generic;
using System.Text;

namespace Combinaciones_y_Variaciones
{
        class Program
        {
            #region ( Variaciones con repeticion )
            //Portal
            public static List<T[]> VarConRep<T>(T[] original, int largo)
            {
                List<T[]> lista = new List<T[]>();
                ImplementVarConRep<T>(original, new T[largo], lista, 0);
                return lista;
            }
            //Recursivo
            private static void ImplementVarConRep<T>(T[] original, T[] temp, List<T[]> lista, int pos)
            {
                if (pos == temp.Length)
                {
                    T[] copia = new T[pos];
                    Array.Copy(temp, copia, pos);
                    lista.Add(copia);
                }
                else
                    for (int i = 0; i < original.Length; i++)
                    {
                        temp[pos] = original[i];
                        ImplementVarConRep<T>(original, temp, lista, pos + 1);
                    }
            }
            #endregion

            #region ( Variaciones sin repeticion )
            //Portal
            public static List<T[]> VarSinRep<T>(T[] original, int largo)
            {
                List<T[]> lista = new List<T[]>();
                ImplementVarSinRep<T>(original, 0, largo, lista);
                return lista;
            }
            //Recursivo
            private static void ImplementVarSinRep<T>(T[] original, int pos, int largo, List<T[]> lista)
            {
                if (pos == largo)
                {
                    T[] copia = new T[pos];
                    Array.Copy(original, copia, pos);
                    lista.Add(copia);
                }
                else
                    for (int i = pos; i < original.Length; i++)
                    {
                        Swap(ref original[i], ref original[pos]);
                        ImplementVarSinRep<T>(original, pos + 1, largo, lista);
                        Swap(ref original[i], ref original[pos]);
                    }
            }
            //Cambia
            private static void Swap<T>(ref T p, ref T p_2)
            {
                T aux = p;
                p = p_2;
                p_2 = aux;
            }
            #endregion

            #region ( Combinaciones )
            public static List<T[]> Combinaciones<T>(T[] original, int largo)
            {
                List<T[]> lista = new List<T[]>();
                ImplementCombinaciones<T>(original, new T[largo], 0, 0, lista);
                return lista;
            }
            private static void ImplementCombinaciones<T>(T[] original, T[] temp, int posorig, int postemp, List<T[]> lista)
            {
                if (postemp == temp.Length)
                {
                    T[] copia = new T[postemp];
                    Array.Copy(temp, copia, postemp);
                    lista.Add(copia);
                }
                else if (posorig == original.Length) return;
                else
                {
                    temp[postemp] = original[posorig];
                    ImplementCombinaciones<T>(original, temp, posorig + 1, postemp + 1, lista);
                    ImplementCombinaciones<T>(original, temp, posorig + 1, postemp, lista);
                }
            }
            #endregion

            #region ( Print )
            public static void Imprime<T>(List<T[]> lista)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    for (int j = 0; j < lista[i].Length; j++)
                        Console.Write(lista[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine("Cantidad: {0}", lista.Count);
            }
            #endregion
            static void Main(string[] args)
            {
                Imprime<int>(VarConRep<int>(new int[] { 1, 2, 3, 4, 5 }, 3));

                //(Las permutaciones son todas las posibles formas de poner 5 numeros del 1 al 5)
                //Si en vez de 3 ponemos 5 estariamos hablando de permutaciones:
                Imprime<int>(VarSinRep<int>(new int[] { 1, 2, 3, 4, 5 }, 3));

                Imprime<int>(Combinaciones<int>(new int[] { 1, 2, 3, 4, 5 }, 3));
                Console.ReadKey();
            }
    }
}
