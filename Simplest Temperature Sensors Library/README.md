# Simplest Temperature Sensors Library
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- .NET Micro Framework
## Topics
- Sensors
## Updated
- 11/03/2014
## Description

<h1>Introduction</h1>
<p><em>Very simple Temperature sensor libray written in .NET Micro Framework. The purpose of this application is to show how to use basic .NET framework devices peripherials.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Sample was build using Visual Studio 2012 and .NET Micro Framework 4.3. For deploying driver on the hardware the I2C and OneWire protocol support is required.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Library function is only reading temperaure from sensors without any sophisticated configuration. Library contatins drivers for the following sensors:</em></p>
<p><em>Texas Instruments LM35DZ - Analog sensor</em></p>
<p><em>Dallas DS81B20 - OneWire sensor</em></p>
<p><em>Texas Instruments TM102 - I2C sensor</em></p>
<p><em>Be aware that most recent .NET ports does not contatin implementation of OneWire protocol which is required to use&nbsp;<em>BS81B20 sensor.</em></em></p>
<p><em>Displaying temperature in both Celcius and Kelvins is possible.</em></p>
<h1><em>Files</em></h1>
<p><em>TemperatureSensor.cs - base class for Temperatue Sensor unifying their interfaces</em></p>
<p><em>DS18B20.cs - class for&nbsp;DS18B20 One Wire sensor&nbsp;</em></p>
<p><em>LM35.cs - class for LM35 Analog Sensor</em></p>
<p><em>TMP102.cs - class for TMP102 I2C sensor</em></p>
<p><em>TemperatureFormat.cs - class contatins definitions of temperature display formats<br>
</em></p>
<h1><em>Example use</em></h1>
<p><em>Sensor Initializaton:</em></p>
<p><em>&nbsp;</em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">TemperatureSensor[]&nbsp;sensors&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TemperatureSensor[<span class="cs__number">3</span>];&nbsp;
sensors[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LM35DZ(ADC.Channel1_PA7,&nbsp;<span class="cs__number">3.3</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">12</span>);&nbsp;
sensors[<span class="cs__number">1</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DS18B20(<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SPOT.Hardware.OutputPort.aspx" target="_blank" title="Auto generated link to Microsoft.SPOT.Hardware.OutputPort">Microsoft.SPOT.Hardware.OutputPort</a>(Cpu.Pin.GPIO_Pin2,&nbsp;<span class="cs__keyword">false</span>));&nbsp;
sensors[<span class="cs__number">2</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TMP102();</pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode"><em>&nbsp;Reading temperature:</em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode"><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">LM35Temperature&nbsp;=&nbsp;sensors[<span class="cs__number">0</span>].ReadTemperature(TemperatureFormat.CELSIUS);&nbsp;
DS18B20Temperature&nbsp;=&nbsp;sensors[<span class="cs__number">1</span>].ReadTemperature(TemperatureFormat.CELSIUS);&nbsp;
TMP120Temperature&nbsp;=&nbsp;sensors[<span class="cs__number">2</span>].ReadTemperature(TemperatureFormat.KELVIN);</pre>
</div>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
<h1>More information</h1>
<p><em><a href="http://datasheets.maximintegrated.com/en/ds/DS18B20.pdf">DS81B20 Sensor datasheet</a></em></p>
<p><em><em><a href="http://www.ti.com/lit/ds/symlink/lm35.pdf">LM35 datasheet</a></em></em></p>
<p><em><em><em><a href="http://www.ti.com.cn/cn/lit/ds/symlink/tmp102.pdf">TM102 &nbsp;datasheet</a></em><br>
</em></em></p>
