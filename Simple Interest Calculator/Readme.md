# Simple Interest Calculator
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
## Topics
- desktop
## Updated
- 11/14/2014
## Description

<h1><span style="font-size:small">Introduction</span></h1>
<h1><span style="font-size:small">According to wikipedia, &quot;<strong>Interest</strong>&nbsp;is a&nbsp;fee&nbsp;paid by a borrower of&nbsp;assets&nbsp;to the owner as a form of compensation for the use of the assets. It is most commonly the price paid for the
 use of borrowed money,&nbsp;or money earned by deposited funds.</span></h1>
<p><span style="font-size:small">When money is borrowed, interest is typically paid to the lender as a percentage of the&nbsp;principal, the amount owed to the lender<br>
</span></p>
<p><span style="font-size:small"><em>This is a simple c# application which helps user to calculate the simple interest and the total amount. Simple Interest is the calculated based on the Rate Time and Principal entered by the user.&nbsp;</em></span></p>
<p><span style="font-size:small">After accepting the values for Principal, Time an Interest from user it&rsquo;s time to calculate simple interest and total amount.</span></p>
<p><span style="font-size:small">Simple interest (i) = (Principal (p) * Time (t) * Rate(r))/100</span></p>
<p><span style="font-size:small">Amount (a) = Interest (i) &#43;Principal (p)</span></p>
<p><span style="font-size:small"><em><br>
</em></span></p>
<p><span style="font-size:small"><img id="129699" src="129699-simple%20interest%20calculator.png" alt="" width="421" height="295"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small; font-weight:bold">Description</span></p>
<p><span style="font-size:small"><em>This application is easy to use and user friendly. using this sample is very easy all you need to do is debug the application and run. A form will appear where user can input the required values and calculate Simple Interest
 and total amount at a time.</em>This application calculates simple interest and amount based on the value provided by user for&nbsp;principal, time, rate.</span></p>
<p><span style="font-size:small">After providing following Input:</span></p>
<p><span style="font-size:small">Principal=5000</span></p>
<p><span style="font-size:small">Time=5 (in years)</span></p>
<p><span style="font-size:small">Rate= 5 (in %)</span></p>
<p><span style="font-size:small">You will get the output as:</span></p>
<p><span style="font-size:small">Interest = 1250</span></p>
<p><span style="font-size:small">Amount=6250</span></p>
<p><span style="font-size:small"><img id="129702" src="129702-simple%20interest%20calculator%20result.png" alt="" width="419" height="453"></span></p>
<p><span style="font-size:small"><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Interest_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float interest, Amount;

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text != &quot;&quot; &amp; textBox2.Text != &quot;&quot; &amp; textBox3.Text != &quot;&quot;)
            {
                interest = Convert.ToSingle(textBox1.Text) * Convert.ToSingle(textBox2.Text) * Convert.ToSingle(textBox3.Text);
                Amount = interest &#43; Convert.ToSingle(textBox1.Text);
                MessageBox.Show(&quot; simple interest =&quot; &#43; &quot; &quot; &#43; interest &#43; &quot; &quot; &#43; &quot;Amount =&quot; &#43; Amount);
            }
            else
            {
                MessageBox.Show(&quot;please enter the value&quot;);
            }
            

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
</span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Simple_Interest_calculator&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;interest,&nbsp;Amount;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBox1.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&nbsp;textBox2.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&nbsp;textBox3.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;interest&nbsp;=&nbsp;Convert.ToSingle(textBox1.Text)&nbsp;*&nbsp;Convert.ToSingle(textBox2.Text)&nbsp;*&nbsp;Convert.ToSingle(textBox3.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Amount&nbsp;=&nbsp;interest&nbsp;&#43;&nbsp;Convert.ToSingle(textBox1.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;&nbsp;simple&nbsp;interest&nbsp;=&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;interest&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;Amount&nbsp;=&quot;</span>&nbsp;&#43;&nbsp;Amount);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;please&nbsp;enter&nbsp;the&nbsp;value&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;textBox1_TextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</span></pre>
</div>
</div>
</div>
<ul>
</ul>
<h1><span style="font-size:small">More Information</span></h1>
<p><span style="font-size:small"><em>For more information ,discussion and other application samples and source code visit
<a title="Shrijanshil.com" href="Shrijanshil.com" target="_blank">www.shrijanshil.com</a></em></span></p>
