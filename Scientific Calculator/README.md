# Scientific Calculator
## License
- Apache License, Version 2.0
## Technologies
- Graphics
- Class Library
- Java
- Graphs
- Javascript
- Library
- Classes
- WinForms
- functions
- My.Computer
- NoSql
- apps for SharePoint
- Javascript with Windows RT
- C++/CX
- Geolocator
## Topics
- Graphics
- Calculator Application
- radio button customization
- Programming Tips
- Object Oriented Programming
- Timer
- Classes
- Borderless Form
- Button
- TextBox
- Installing Java
- Radio Buttons
- math rounding
## Updated
- 08/24/2014
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">It is solve many problems and consume less time and provide result.</span><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>No Special requirment but you have Jdk install on your operating system its all work.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<ul>
<li>Basic Functions ( &#43;, -, X, / ) </li><li>Simple functions (sine, cosine, tangent, log, exponentials etc., transendental numbers) Sexagisimal Number functions (Degree, Minute, Sec, Hour, Minute Second)Complex number functions(imaginary number operations)
</li><li>Fractions </li><li>Algebraic expression evaluation </li><li>Input/Output </li><li>Programmability </li><li>Alphanumeric functions (manipulate strings of characters) </li></ul>
<table>
<tbody>
<tr>
<td>Addition</td>
<td>x&#43;y</td>
<td>Sum of two operands</td>
</tr>
<tr>
<td>Subtraction</td>
<td>x-y</td>
<td>Difference of two operands</td>
</tr>
<tr>
<td>Multiplication</td>
<td>x*y</td>
<td>Multiplication of two operands</td>
</tr>
<tr>
<td>Division</td>
<td>x/y</td>
<td>Dividing value of first operand by value of second operand</td>
</tr>
<tr>
<td>Power</td>
<td>x^y</td>
<td>Raise value of the first operand to a power determined by value of second operand</td>
</tr>
<tr>
<td>Integer part</td>
<td>[x]</td>
<td>Integer part of number</td>
</tr>
</tbody>
</table>
<p>Scientific electronic calculators are accurate. The precision of a calculator should be measured, rather than taking it for granted. Problems in accuracy can arise when repeated calculations are made on a single result. The nature of computational environment
 will determine the ultimate accuracy of long calculation. Precision is very important when doing division. Let's take a look at a quick example.</p>
<p>x = 1/3/3/3/3/3/3*3*3*3*3*3*3*3</p>
<p>by definition, this value should equal 1. We have divided 1 by 3, 6 times and then multiply it by 3, six times. The problem with division by three stems from the fact that it is a repeating fraction that can never be represented with absolute accuracy. Multiple
 operations begin to accumulate errors.</p>
<p>&nbsp;</p>
<p><img id="124250" src="http://i1.code.msdn.s-msft.com/scientific-calculator-48f03779/image/file/124250/1/untitled.png" alt="" width="493" height="231"><br>
<em>&nbsp;&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Java</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">java</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;actionPerformed(ActionEvent&nbsp;e)&nbsp;
{&nbsp;
String&nbsp;s=e.getActionCommand();&nbsp;
&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;Exit&quot;</span>))&nbsp;
{&nbsp;
System.exit(<span class="cs__number">0</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;1&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;1&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;1&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;2&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;2&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;2&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;3&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;3&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;3&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;4&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;4&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;4&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;5&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;5&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;5&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;6&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;6&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;6&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;7&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;7&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;7&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;8&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;8&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;8&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;9&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;9&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;9&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}&nbsp;
}&nbsp;
<span class="cs__keyword">if</span>(s.equals(<span class="cs__string">&quot;0&quot;</span>))&nbsp;
{&nbsp;
<span class="cs__keyword">if</span>(z==<span class="cs__number">0</span>)&nbsp;
{&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;0&quot;</span>);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
jtx.setText(<span class="cs__string">&quot;&quot;</span>);&nbsp;
jtx.setText(jtx.getText()&#43;<span class="cs__string">&quot;0&quot;</span>);&nbsp;
z=<span class="cs__number">0</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - </em><a id="124249" href="/site/view/file/124249/1/calculator.java">calculator.java</a>
</li></ul>
<h1>More Informatio<em>n</em></h1>
<ul>
<li>inverse (1/x) </li><li>sine / arc sine </li><li>cos/ arc cos </li><li>tan/ arc tan </li><li>exponential / logs (base ten and natural) </li><li>hyperbolic trig functions (sinh, cosh, etc. </li></ul>
