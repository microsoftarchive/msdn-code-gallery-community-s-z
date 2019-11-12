# Triangle Solver – An exercise in Functions, the use of the Sine rule and the Cos
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Basic Express 2010
## Topics
- Use of Functions
- Using the Sin and Cos rule in Visual Basic
- Basic graphing methods
## Updated
- 11/15/2013
## Description

<h1>Introduction</h1>
<h1><span>Building the Sample</span></h1>
<p><em>There are no special requirements in building the sample. All controls used in the program are created at run time.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This program, Triangle Solver, while practical, inasmuch as it will solve for all angles and side of a triangle, demonstrates the use of calling functions while passing variables to the function and returning a value. There are four functions used in this
 program, two of which employ the Cos Rule, one to find the value of an unknown angle and one to find the value of an unknown side, and two of which employ the Sine Rule, again one of which will find an unknown angle and the other to find an unknown side.</p>
<p>The program starts by initiating variables used in the program then presents the User Interface to allow the user to input known values of sides and angles of a triangle. (See image below.)</p>
<p>The program first uses the TryParse method to determine if the values entered are indeed numeric. A check is also made to ensure the values are not negative.</p>
<p>If all value entered are valid the TextBox values are assigned to the sides and angles.</p>
<p>Standard convention is used to name the sides a, b and c (lower case) and the angles A, B and C (upper case). Standard convention is also used in naming angle A as opposite to side a, angle B as opposite to side b and angle C as opposite to side c.</p>
<p>The program then looks for certain combinations of sides and angles. The first of which is to check to see that there are at least three know variables entered. The next checks to see if at least one side is entered.</p>
<p>The program then systematically checks for different combinations of sides and angles. The first check is made to see if 3 sides are entered and are also valid. (One side cannot be longer than the sum of the other two sides.)</p>
<p>If the three sides are valid then three different calls are made to the function CosRule1 to calculate the three unknown angles. The values of which are returned to the caller:</p>
<p>(See code snippets below for examples of the calls to a function and the functions. The full code listing can be downloaded from the link above)</p>
<p>The returned values are then assigned to the relevant TextBoxes and the triangle is drawn.</p>
<p>If the three sides are not assigned values then the program checks for two sides and one angles in different combinations. E.g. abA = sides a and sides b and angle A.</p>
<p>The program then checks for two angles and a side. E.g.&nbsp; ABa = angle A and Angle B and side A. An example of calling the relevant function for two sides and an angle is:</p>
<p>&nbsp;<span style="text-decoration:underline">Calculate Triangle:</span></p>
<p>When all six properties of the triangle are calculated and known the screen X and Y co-ordinates are calculated. A scaling function is used to ensure that no matter what size the triangle is (according to its side dimensions) the triangle will always be
 drawn to scale in the drawing area. The factor is determined by the length of the longest side. For example, a triangle with sides in the ratio of 3:4:5 (a right angled triangle) will be the same size (on screen)&nbsp; as one with sides 3000:4000:5000. Any
 unit type can be used e.g. millimetres, feet or even miles!</p>
<p>Side a will always be drawn at the bottom of the screen horizontally. Side b is drawn joining side a at its left most point and uses the Trig function for converting polar co-ordinates to rectangular co-ordinates to calculate the X,Y co-ordinates of its
 end point:</p>
<p>The co-ordinates for side c are the co-ordinates of the end points of side a and side b. Effectively, side c joins side a and side b.</p>
<p>I&rsquo;ve used the DrawPolygon method to draw the triangle rather than using the DrawLine method as it produces a neater triangle.</p>
<p>The various sides and angles of the triangle are then labelled using the DrawString method.</p>
<p>To round off the calculations, area of the triangle is calculated and drawn on screen.</p>
<p>All controls used in the program are created at run time so to use the program simply download it, load it into VB then run it!</p>
<p>&nbsp;<img id="101211" src="101211-triangle%20solver.jpg" alt="" width="671" height="451"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__com">'Call&nbsp;the&nbsp;CosRule1&nbsp;Function&nbsp;to&nbsp;calculate&nbsp;the&nbsp;angles</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Angle_A&nbsp;=&nbsp;CosRule1(Side_a,&nbsp;Side_b,&nbsp;Side_c)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Angle_B&nbsp;=&nbsp;CosRule1(Side_b,&nbsp;Side_a,&nbsp;Side_c)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Angle_C&nbsp;=&nbsp;CosRule1(Side_c,&nbsp;Side_a,&nbsp;Side_b)&nbsp;
&nbsp;
<span class="visualBasic__com">'The&nbsp;CosRule1&nbsp;Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CosRule1(<span class="visualBasic__keyword">ByVal</span>&nbsp;a&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;b&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Return&nbsp;angle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Math.Acos((b&nbsp;^&nbsp;<span class="visualBasic__number">2</span>&nbsp;&#43;&nbsp;c&nbsp;^&nbsp;<span class="visualBasic__number">2</span>&nbsp;-&nbsp;a&nbsp;^&nbsp;<span class="visualBasic__number">2</span>)&nbsp;/&nbsp;(<span class="visualBasic__number">2</span>&nbsp;*&nbsp;b&nbsp;*&nbsp;c))&nbsp;/&nbsp;Convert&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Calling&nbsp;the&nbsp;CosRule2&nbsp;Function&nbsp;and&nbsp;the&nbsp;SinRule1&nbsp;Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;Side_a&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;Side_b&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;Angle_C&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'abC&nbsp;&nbsp;=&nbsp;2&nbsp;sides&nbsp;and&nbsp;angle&nbsp;C</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Side_c&nbsp;=&nbsp;CosRule2(Side_a,&nbsp;Side_b,&nbsp;Angle_C)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Angle_A&nbsp;=&nbsp;SinRule1(Side_c,&nbsp;Side_a,&nbsp;Angle_C)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Angle_B&nbsp;=&nbsp;<span class="visualBasic__number">180</span>&nbsp;-&nbsp;Angle_A&nbsp;-&nbsp;Angle_C&nbsp;
&nbsp;
<span class="visualBasic__com">'The&nbsp;CosRule2&nbsp;Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CosRule2(<span class="visualBasic__keyword">ByVal</span>&nbsp;a&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;b&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;A1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Return&nbsp;side</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Math.Sqrt(a&nbsp;^&nbsp;<span class="visualBasic__number">2</span>&nbsp;&#43;&nbsp;b&nbsp;^&nbsp;<span class="visualBasic__number">2</span>&nbsp;-&nbsp;<span class="visualBasic__number">2</span>&nbsp;*&nbsp;a&nbsp;*&nbsp;b&nbsp;*&nbsp;Math.Cos(A1&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'The&nbsp;SinRule1&nbsp;Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;SinRule1(<span class="visualBasic__keyword">ByVal</span>&nbsp;a&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;b&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;A1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Return&nbsp;angle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Math.Asin(b&nbsp;*&nbsp;Math.Sin(A1&nbsp;*&nbsp;Convert)&nbsp;/&nbsp;a)&nbsp;/&nbsp;Convert&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Use&nbsp;Polar&nbsp;to&nbsp;rectangular&nbsp;conversion&nbsp;to&nbsp;calculate&nbsp;X,Y&nbsp;cordinates</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x2&nbsp;=&nbsp;x0&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">CSng</span>(b_side&nbsp;*&nbsp;Math.Cos(Angle_C&nbsp;*&nbsp;Convert))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y2&nbsp;=&nbsp;y0&nbsp;-&nbsp;<span class="visualBasic__keyword">CSng</span>(b_side&nbsp;*&nbsp;Math.Sin(Angle_C&nbsp;*&nbsp;Convert))&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
