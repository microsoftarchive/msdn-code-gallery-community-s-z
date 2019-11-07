# Using MVVM in WPF with ADO.NET Entity Framework 4 and Visual Basic 2010
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
- LINQ
- WPF
- Visual Studio 2010
- VB.Net
## Topics
- MVVM
## Updated
- 06/23/2011
## Description

<p><span style="font-size:small">Model-View-ViewModel is an architectural pattern for WPF and Silverlight that helps abstracting the presentation layer from other layers such as the data access and the business logic.</span></p>
<p>You can successfully use MVVM against the ADO.NET Entity Framework, but there's one thing that you must be aware of: the ViewModel must not know what the underlying data access engine is. For this reason, a good approach is implementing a service layer that
 will be responsible of interacting with the data source. If one day you'll decide to change the data store, you will edit the service layer but the ViewModel remains unchanged.</p>
<p>There is also another problem with MVVM: opening dialogs; commands are exposed by the ViewModel but this cannot open UI elements, so you need something to solve this problem. You could implement events, but there is another way through messages.</p>
<p>Finally, notice that MVVM makes easier unit testing</p>
<p>This is an advanced&nbsp;example, since&nbsp;you learn:</p>
<ul>
<li>how to implement the MVVM pattern in a WPF application </li><li>how to create a service layer that the ViewModel interacts with, and that is responsible for working with data. So the ViewModel invokes the service layer, without knowing that data come from the Entity Framework
</li><li>how to implement messages in order to be able of showing dialogs </li><li>how to run unit tests against the ViewModel, not the View </li></ul>
<p>&nbsp;</p>
<p>The source code is in Visual Basic 2010 only. The reason is that the availability of MVVM material in VB has to grow yet.</p>
<p>This is a picture from the final result:</p>
<p><img src="23812-o_mvvm_final1%5b1%5d.jpg" alt=""></p>
