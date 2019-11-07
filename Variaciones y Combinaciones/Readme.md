# Variaciones y Combinaciones
## Requires
- Visual Studio 2005
## License
- MS-LPL
## Technologies
- Console
- Math.NET Numerics
## Topics
- Console Application
- Console Window
## Updated
- 04/15/2012
## Description

<h1>Introduccion</h1>
<p><em>Metodos utiles para aprender variaciones y combinaciones matematicas</em></p>
<h1>Descripcion</h1>
<p><em>Variaciones con repeticiones, variaciones sin repeticiones y combinaciones.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Variaciones_y_Combinaciones
{
    class Program
    {
        #region ( Variaciones con repeticion )
        //Portal
        public static List&lt;T[]&gt; VarConRep&lt;T&gt;(T[] original, int largo)
        {
            List&lt;T[]&gt; lista = new List&lt;T[]&gt;();
            ImplementVarConRep&lt;T&gt;(original, new T[largo], lista, 0);
            return lista;
        }
        //Recursivo
        private static void ImplementVarConRep&lt;T&gt;(T[] original, T[] temp, List&lt;T[]&gt; lista, int pos)
        {
            if (pos == temp.Length)
            {
                T[] copia = new T[pos];
                Array.Copy(temp, copia, pos);
                lista.Add(copia);
            }
            else
                for (int i = 0; i &lt; original.Length; i&#43;&#43;)
                {
                    temp[pos] = original[i];
                    ImplementVarConRep&lt;T&gt;(original, temp, lista, pos &#43; 1);
                }
        }
        #endregion

        #region ( Variaciones sin repeticion )
        //Portal
        public static List&lt;T[]&gt; VarSinRep&lt;T&gt;(T[] original, int largo)
        {
            List&lt;T[]&gt; lista = new List&lt;T[]&gt;();
            ImplementVarSinRep&lt;T&gt;(original, 0, largo, lista);
            return lista;
        }
        //Recursivo
        private static void ImplementVarSinRep&lt;T&gt;(T[] original, int pos, int largo, List&lt;T[]&gt; lista)
        {
            if (pos == largo)
            {
                T[] copia = new T[pos];
                Array.Copy(original, copia, pos);
                lista.Add(copia);
            }
            else
                for (int i = pos; i &lt; original.Length; i&#43;&#43;)
                {
                    Swap(ref original[i], ref original[pos]);
                    ImplementVarSinRep&lt;T&gt;(original, pos &#43; 1, largo, lista);
                    Swap(ref original[i], ref original[pos]);
                }
        }
        //Cambia
        private static void Swap&lt;T&gt;(ref T p, ref T p_2)
        {
            T aux = p;
            p = p_2;
            p_2 = aux;
        }
        #endregion

        #region ( Combinaciones )
        public static List&lt;T[]&gt; Combinaciones&lt;T&gt;(T[] original, int largo)
        {
            List&lt;T[]&gt; lista = new List&lt;T[]&gt;();
            ImplementCombinaciones&lt;T&gt;(original, new T[largo], 0, 0, lista);
            return lista;
        }
        private static void ImplementCombinaciones&lt;T&gt;(T[] original, T[] temp, int posorig, int postemp, List&lt;T[]&gt; lista)
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
                ImplementCombinaciones&lt;T&gt;(original, temp, posorig &#43; 1, postemp &#43; 1, lista);
                ImplementCombinaciones&lt;T&gt;(original, temp, posorig &#43; 1, postemp, lista);
            }
        }
        #endregion

        #region ( Print )
        public static void Imprime&lt;T&gt;(List&lt;T[]&gt; lista)
        {
            for (int i = 0; i &lt; lista.Count; i&#43;&#43;)
            {
                for (int j = 0; j &lt; lista[i].Length; j&#43;&#43;)
                    Console.Write(lista[i][j]);
                Console.Write(&quot; &quot;);
            }
            Console.WriteLine();
            Console.WriteLine(&quot;Cantidad: {0}&quot;,lista.Count);
        }
        #endregion
        static void Main(string[] args)
        {
            Imprime&lt;int&gt;(VarConRep&lt;int&gt;(new int[] { 1, 2, 3, 4, 5 }, 3));

            //(Las permutaciones son todas las posibles formas de poner 5 numeros del 1 al 5)
            //Si en vez de 3 ponemos 5 estariamos hablando de permutaciones:
            Imprime&lt;int&gt;(VarSinRep&lt;int&gt;(new int[] { 1, 2, 3, 4, 5 }, 3));

            Imprime&lt;int&gt;(Combinaciones&lt;int&gt;(new int[] { 1, 2, 3, 4, 5 }, 3));
            Console.ReadKey();
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Variaciones_y_Combinaciones&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;(&nbsp;Variaciones&nbsp;con&nbsp;repeticion</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Portal</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;T[]&gt;&nbsp;VarConRep&lt;T&gt;(T[]&nbsp;original,&nbsp;<span class="cs__keyword">int</span>&nbsp;largo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;T[]&gt;&nbsp;lista&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;T[]&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementVarConRep&lt;T&gt;(original,&nbsp;<span class="cs__keyword">new</span>&nbsp;T[largo],&nbsp;lista,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lista;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Recursivo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ImplementVarConRep&lt;T&gt;(T[]&nbsp;original,&nbsp;T[]&nbsp;temp,&nbsp;List&lt;T[]&gt;&nbsp;lista,&nbsp;<span class="cs__keyword">int</span>&nbsp;pos)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(pos&nbsp;==&nbsp;temp.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T[]&nbsp;copia&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;T[pos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Array.Copy(temp,&nbsp;copia,&nbsp;pos);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lista.Add(copia);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;original.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp[pos]&nbsp;=&nbsp;original[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementVarConRep&lt;T&gt;(original,&nbsp;temp,&nbsp;lista,&nbsp;pos&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;(&nbsp;Variaciones&nbsp;sin&nbsp;repeticion</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Portal</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;T[]&gt;&nbsp;VarSinRep&lt;T&gt;(T[]&nbsp;original,&nbsp;<span class="cs__keyword">int</span>&nbsp;largo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;T[]&gt;&nbsp;lista&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;T[]&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementVarSinRep&lt;T&gt;(original,&nbsp;<span class="cs__number">0</span>,&nbsp;largo,&nbsp;lista);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lista;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Recursivo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ImplementVarSinRep&lt;T&gt;(T[]&nbsp;original,&nbsp;<span class="cs__keyword">int</span>&nbsp;pos,&nbsp;<span class="cs__keyword">int</span>&nbsp;largo,&nbsp;List&lt;T[]&gt;&nbsp;lista)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(pos&nbsp;==&nbsp;largo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T[]&nbsp;copia&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;T[pos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Array.Copy(original,&nbsp;copia,&nbsp;pos);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lista.Add(copia);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;pos;&nbsp;i&nbsp;&lt;&nbsp;original.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Swap(<span class="cs__keyword">ref</span>&nbsp;original[i],&nbsp;<span class="cs__keyword">ref</span>&nbsp;original[pos]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementVarSinRep&lt;T&gt;(original,&nbsp;pos&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;largo,&nbsp;lista);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Swap(<span class="cs__keyword">ref</span>&nbsp;original[i],&nbsp;<span class="cs__keyword">ref</span>&nbsp;original[pos]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Cambia</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Swap&lt;T&gt;(<span class="cs__keyword">ref</span>&nbsp;T&nbsp;p,&nbsp;<span class="cs__keyword">ref</span>&nbsp;T&nbsp;p_2)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T&nbsp;aux&nbsp;=&nbsp;p;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p&nbsp;=&nbsp;p_2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p_2&nbsp;=&nbsp;aux;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;(&nbsp;Combinaciones</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;T[]&gt;&nbsp;Combinaciones&lt;T&gt;(T[]&nbsp;original,&nbsp;<span class="cs__keyword">int</span>&nbsp;largo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;T[]&gt;&nbsp;lista&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;T[]&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementCombinaciones&lt;T&gt;(original,&nbsp;<span class="cs__keyword">new</span>&nbsp;T[largo],&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;lista);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lista;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ImplementCombinaciones&lt;T&gt;(T[]&nbsp;original,&nbsp;T[]&nbsp;temp,&nbsp;<span class="cs__keyword">int</span>&nbsp;posorig,&nbsp;<span class="cs__keyword">int</span>&nbsp;postemp,&nbsp;List&lt;T[]&gt;&nbsp;lista)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(postemp&nbsp;==&nbsp;temp.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T[]&nbsp;copia&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;T[postemp];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Array.Copy(temp,&nbsp;copia,&nbsp;postemp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lista.Add(copia);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(posorig&nbsp;==&nbsp;original.Length)&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;temp[postemp]&nbsp;=&nbsp;original[posorig];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementCombinaciones&lt;T&gt;(original,&nbsp;temp,&nbsp;posorig&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;postemp&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;lista);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImplementCombinaciones&lt;T&gt;(original,&nbsp;temp,&nbsp;posorig&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;postemp,&nbsp;lista);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;(&nbsp;Print</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Imprime&lt;T&gt;(List&lt;T[]&gt;&nbsp;lista)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;lista.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;lista[i].Length;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(lista[i][j]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Cantidad:&nbsp;{0}&quot;</span>,lista.Count);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Imprime&lt;<span class="cs__keyword">int</span>&gt;(VarConRep&lt;<span class="cs__keyword">int</span>&gt;(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">5</span>&nbsp;},&nbsp;<span class="cs__number">3</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//(Las&nbsp;permutaciones&nbsp;son&nbsp;todas&nbsp;las&nbsp;posibles&nbsp;formas&nbsp;de&nbsp;poner&nbsp;5&nbsp;numeros&nbsp;del&nbsp;1&nbsp;al&nbsp;5)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Si&nbsp;en&nbsp;vez&nbsp;de&nbsp;3&nbsp;ponemos&nbsp;5&nbsp;estariamos&nbsp;hablando&nbsp;de&nbsp;permutaciones:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Imprime&lt;<span class="cs__keyword">int</span>&gt;(VarSinRep&lt;<span class="cs__keyword">int</span>&gt;(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">5</span>&nbsp;},&nbsp;<span class="cs__number">3</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Imprime&lt;<span class="cs__keyword">int</span>&gt;(Combinaciones&lt;<span class="cs__keyword">int</span>&gt;(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">5</span>&nbsp;},&nbsp;<span class="cs__number">3</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Program</em> </li></ul>
<p>*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************</p>
<p>*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************</p>
<p>*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************</p>
