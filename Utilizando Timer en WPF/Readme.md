# Utilizando Timer en WPF
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
- C# Language
- WPF Data Binding
- WPF Silverlight XAML
## Topics
- XAML
- WPF Data Binding
- Timer
## Updated
- 10/31/2014
## Description

<h1>Introducci&oacute;n</h1>
<p>Aveces tenemos la costumbre de utilizar Timers para, peri&oacute;dicamente, revisar el valor de alguna variable que pudo haber cambiado, o quiz&aacute; cambiar los valores de alguna variable. Sin embargo a la hora de utilizar WPF nos topamos que no existe
 el control de Timer como lo existe en Windows Forms.</p>
<p>Sin embargo, dejando a un lado el concepto de que Windows Forms ya es obsoleto, vamos a explicar como utilizar un temporizador program&aacute;ticamente en WPF. Y para ello vamos a utilizar toda la riqueza del enlace de datos como de en lenguaje de marcas
 XAML.</p>
<p>&nbsp;</p>
<h1>Construyendo la aplicaci&oacute;n</h1>
<p>Los primero que tenemos que hacer es abrir un nuevo proyecto de WPF en nuestro visual studio</p>
<p>Una vez abierto, no vamos al codebehind y escribimos en el evento Load de la pagina un nuevo objeto de la clase
<a title="DisptacherTimer msdn" href="http://msdn.microsoft.com/es-es/library/system.windows.threading.dispatchertimer(v=vs.110).aspx" target="_blank">
DispatcherTimer</a>. El cual tiene tres elementos principales.</p>
<p><strong>1.- Intervalo (propiedad):</strong></p>
<p><span>Obtiene o establece el per&iacute;odo de tiempo entre las indicaciones de temporizador.</span></p>
<p><span>&nbsp;</span>&nbsp;</p>
<p><strong>2.- Start() (metodo):</strong></p>
<p><span>Inicia&nbsp;</span><span>DispatcherTimer</span><span>.</span></p>
<p>&nbsp;</p>
<p><strong>3.- Stop() (metodo):</strong></p>
<p>D<span>etiene&nbsp;</span><span>DispatcherTimer</span><span>.</span></p>
<p>&nbsp;</p>
<p><strong>4.-Tick (evento) :</strong></p>
<p><span>Se produce cuando ha transcurrido el intervalo del temporizador.</span></p>
<p>&nbsp;</p>
<p><span>Cuando escribimos DispatcherTimer y no lo reconoce, le damos click derecho y resolvemos la libreria dando click en using System.Windows.Threading</span></p>
<p><span><img id="127954" src="127954-1.png" alt=""></span></p>
<p>&nbsp;</p>
<p><span><span>Y quedar&iacute;a de esta manera construido</span></span></p>
<p><span><span><img id="127955" src="127955-2.png" alt=""></span></span></p>
<p>&nbsp;</p>
<p>Y con esto ya puedes utilizar y manipulat el timer creado.</p>
<p>Yo voy a probarlo agregandole una coleccion de Guids cada ves que pase un segundo</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ObservableCollection&lt;string&gt; listaGuids = new ObservableCollection&lt;string&gt;();
            this.DataContext = listaGuids;
           
            //INSTANCIANDO EL TIMER CON LA CLASE DISPATCHERTIMER
            DispatcherTimer dispathcer = new DispatcherTimer();

            //EL INTERVALO DEL TIMER ES DE 0 HORAS,0 MINUTOS Y 1 SEGUNDO
            dispathcer.Interval = new TimeSpan(0, 0, 1);

            //EL EVENTO TICK SE SUBSCRIBE A UN CONTROLADOR DE EVENTOS UTILIZANDO LAMBDA
            dispathcer.Tick &#43;= (s, a) =&gt;
            {
                //AQUI VA LO QUE QUIERES QUE HAGA CADA 1 SEGUNDO
                listaGuids.Add(Guid.NewGuid().ToString());

            };
            dispathcer.Start();</pre>
<div class="preview">
<pre class="csharp">ObservableCollection&lt;<span class="cs__keyword">string</span>&gt;&nbsp;listaGuids&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.DataContext&nbsp;=&nbsp;listaGuids;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//INSTANCIANDO&nbsp;EL&nbsp;TIMER&nbsp;CON&nbsp;LA&nbsp;CLASE&nbsp;DISPATCHERTIMER</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DispatcherTimer&nbsp;dispathcer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DispatcherTimer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//EL&nbsp;INTERVALO&nbsp;DEL&nbsp;TIMER&nbsp;ES&nbsp;DE&nbsp;0&nbsp;HORAS,0&nbsp;MINUTOS&nbsp;Y&nbsp;1&nbsp;SEGUNDO</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dispathcer.Interval&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TimeSpan(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//EL&nbsp;EVENTO&nbsp;TICK&nbsp;SE&nbsp;SUBSCRIBE&nbsp;A&nbsp;UN&nbsp;CONTROLADOR&nbsp;DE&nbsp;EVENTOS&nbsp;UTILIZANDO&nbsp;LAMBDA</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dispathcer.Tick&nbsp;&#43;=&nbsp;(s,&nbsp;a)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//AQUI&nbsp;VA&nbsp;LO&nbsp;QUE&nbsp;QUIERES&nbsp;QUE&nbsp;HAGA&nbsp;CADA&nbsp;1&nbsp;SEGUNDO</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listaGuids.Add(Guid.NewGuid().ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dispathcer.Start();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><span>Y en XAML agregar&iacute;a un listbox tomando como ItemsSource la colecci&oacute;n de cadena</span></p>
<p><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid&gt;
        &lt;ListBox Width=&quot;200&quot; Height=&quot;auto&quot; ItemsSource=&quot;{Binding}&quot;/&gt;
    &lt;/Grid&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;auto&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span>
<p></p>
<p><span><span><br>
</span></span></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Resultado</span></p>
<p>Y quedar&iacute;a de estar manera en ejecuci&oacute;n</p>
<div class="scriptcode"><img id="127959" src="127959-execution.png" alt="" width="525" height="352"></div>
<p>&nbsp;</p>
