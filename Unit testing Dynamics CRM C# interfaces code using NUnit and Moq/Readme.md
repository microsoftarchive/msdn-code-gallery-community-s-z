# Unit testing Dynamics CRM C# interfaces code using NUnit and Moq
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Dynamics CRM
- Microsoft Dynamics CRM 2011
- Moq Framework
- NUnit
- Microsoft Dynamics CRM 2013
## Topics
- Unit Testing
- Development
## Updated
- 04/11/2014
## Description

<h3><span style="color:#ff0000">Updated - May 1, 2013</span></h3>
<p><em><span style="color:#000000">I've updated the sample to a Visual Studio 2012 solution and created a separate test project (LucasDemoCrm.Test) that contains the NUnit tests. Additionally I have created another test project (LucasDemoCrm.VSTest) that has
 the same unit tests written to use the Visual Studio Unit Testing Framework. If you are looking for the original VS2010 version, you can download it here:&nbsp;<a id="81504" href="/Unit-testing-Dynamics-CRM-967a04ec/file/81504/1/LucasDemoCrm.zip">LucasDemoCrm.zip</a>.</span></em></p>
<h1>Introduction</h1>
<p>This sample contains the solution I used for my three-part <a href="http://alexanderdevelopment.net/post/2013/01/13/How-to-unit-test-C-Dynamics-CRM-interface-code-part-III.aspx" target="_blank">
blog series</a> on unit testing C# interfaces with Dynamics CRM 2011 using NUnit and Moq. There are three methods in the MockDemo class:</p>
<ol>
<li>CreateCrmAccount </li><li>CreateCrmAccount2 </li><li>GetPicklistOptionCount </li></ol>
<p>These methods and their corresponding tests show how to unit test CRM interfacing code in&nbsp;progressively more advanced scenarios.</p>
<h1><span>Building the Sample</span></h1>
<p>The sample builds a class library that can then be tested using the NUnit GUI or command-line interface. To build the sample you will need:</p>
<ol>
<li>The Dynamics CRM 2011 SDK </li><li>Moq </li><li>NUnit </li></ol>
<p>All three are included in the &quot;references&quot; directory in the solution archive. To execute the tests, see the &quot;Running the test&quot; section toward the end of
<a href="http://alexanderdevelopment.net/post/2013/01/06/How-to-unit-test-C-sharp-Dynamics-CRM-interfaces-code.aspx" target="_blank">
this article</a>.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Each test in this sample demonstrates how to unit test a Dynamics CRM interface without actually needing to connect to a live CRM system.</p>
<ol>
<li>The CreateCrmAccount test demonstrates a simple use of object mocks as an introduction.
</li><li>The CreateCrmAccount2 test demonstrates a more complex use of object mocks as a way to test code that is more realistic.
</li><li>The GetPicklistOptionCount test demonstrates the use of wrapper classes to unit test interfaces that work with sealed classes.
</li></ol>
<ul>
</ul>
<h1>More Information</h1>
<p>A detailed overview of the contents of this sample can be found in the original blog posts:</p>
<ol>
<li><a href="http://alexanderdevelopment.net/post/2013/01/06/How-to-unit-test-C-sharp-Dynamics-CRM-interfaces-code.aspx" target="_blank">Part I</a>&nbsp;- Introduction to unit testing, NUnit and Moq
</li><li><a href="http://alexanderdevelopment.net/post/2013/01/09/How-to-unit-test-C-Dynamics-CRM-interface-code-part-II.aspx" target="_blank">Part II</a>&nbsp;- Testing a real-world CRM interface scenario
</li><li><a href="http://alexanderdevelopment.net/post/2013/01/13/How-to-unit-test-C-Dynamics-CRM-interface-code-part-III.aspx" target="_blank">Part III</a>&nbsp;- Testing CRM SDK responses that use sealed classes
</li></ol>
