# Singleton Pattern with C# using different ways to create Singleton Instance.
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework 4.0
## Topics
- Singleton Pattern
- Eager Initialization
- Synchronized Methods
## Updated
- 08/22/2012
## Description

<h1>Introduction</h1>
<p><em>Singleton Pattern with C#<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Build the sample and Run, By default it uses Eager Initialization for instantiating the Singleton Object.</em></p>
<p><em>Please uncomment the other methods in Create() method under Simulator Class to demo the others.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample Demonstrate the multiple ways of writing Singleton Class in C#.<br>
</em></p>
<p><em>It also demonstrate the Singleton class with Thread Safety.</em></p>
<p><img id="65209" src="65209-cd_singleton.png" alt="" width="523" height="297"></p>
<p>&nbsp;</p>
<p>There are Four methods to create the Singleton Instance :</p>
<p>1. GetInstance() :-&nbsp; A Normal way which is not thread safe.</p>
<p>2. GetInstanceEager() :- eager initialization of Singleton instance, Thread safety provided by Framework</p>
<p>3. GetInstanceSynchronized() :- Using Synchronized method.</p>
<p>4. GetInstanceVolatile() :- using Volatile instance &amp; lock mechanism.</p>
<p>&nbsp;</p>
<p>SINGLETON PATTERN ensures a class has only one instance, and provides a global point of access to it.</p>
<p>1. The Singleton Pattern ensures that you have at most one instance of a class in your application.<br>
2. Provides Global Access point to that instance.<br>
3. Private Constructor &#43;&nbsp; Static Method or Getter &#43; Static Variable</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public sealed class Singleton
    {
        private static readonly Singleton uniqueInstanceEager = new Singleton();


        //Construction
        private Singleton() 
        {
            Console.WriteLine(&quot;Singleton Instance Created.&quot;);
        }

      public static Singleton GetInstance()
      {
          return uniqueInstanceEager ;
       }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Singleton&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;Singleton&nbsp;uniqueInstanceEager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Singleton();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Construction</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Singleton()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Singleton&nbsp;Instance&nbsp;Created.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Singleton&nbsp;GetInstance()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;uniqueInstanceEager&nbsp;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Singleton.cs : Singleton Class with diiferent methods for Initialization of Singleton object.</em>
</li><li><em><em>Simulator.cs : Simulation class to demontrate the behavior of Singleton class.</em></em>
</li></ul>
<h1>More Information</h1>
<p>http://msdn.microsoft.com/en-us/library/ff650316.aspx</p>
