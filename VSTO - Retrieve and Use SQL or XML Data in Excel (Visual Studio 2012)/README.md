# VSTO - Retrieve and Use SQL or XML Data in Excel (Visual Studio 2012)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Microsoft Office Excel 2010
- .NET Framework 4.0
## Topics
- SQL
- Excel
- VSTO
- XML
- Data Access
## Updated
- 09/07/2012
## Description

<h1>Введение</h1>
<p>Данный при&#1084;ер работает в Microsoft Office Excel 2010.</p>
<p>В данно&#1084; при&#1084;ере де&#1084;онстрируется извлечение данных из реляционной базы данных или XML-файла и использование этих данных в приложении Excel.</p>
<p>В при&#1084;ере используется лист выполнения заказа. В листе отображаются подробности заказов клиентов, что позволяет объединить позиции для поставки. В листе также выводятся сведения о наличии каждой позиции на складе, чтобы пользователь знал, &#1084;ожно ли выполнить
 заказ.</p>
<h4>При&#1084;ечание по безопасности.</h4>
<p>Этот при&#1084;ер кода приведен для иллюстрации концепции, в не&#1084; приведен код, который относится только к данной концепции. При&#1084;ер &#1084;ожет не отвечать требования&#1084; безопасности для определенной среды, и его не следует использовать в точности в то&#1084; виде, в которо&#1084;
 он приведен. Чтобы сделать проект более безопасны&#1084; и надежны&#1084;, реко&#1084;ендуется добавить в него код обеспечения безопасности и код обработки ошибок. Корпорация Майкрософт предоставляет этот образец кода на условиях &quot;КАК ЕСТЬ&quot;, без каких-либо гарантий.</p>
<p>Сведения об установке проекта при&#1084;ера на ко&#1084;пьютере с&#1084;. в разделе &laquo;Инструкции: установка и использование файлов при&#1084;еров, включенных в справку&raquo;.</p>
<h1><span>Построение при&#1084;ера</span></h1>
<div class="subSection">
<ol>
<li>
<p>Наж&#1084;ите клавишу F5.</p>
</li><li>
<p>Выберите в списке <span class="ui">Выбор клиента</span> и&#1084;я клиента.</p>
<p>В списке <span class="ui">Невыполненные заказы</span> находятся но&#1084;ера заказов без от&#1084;етки
<span class="ui">Выполнен</span>.</p>
</li><li>
<p>Выберите в списке <span class="ui">Невыполненные заказы</span> но&#1084;ер заказа.</p>
<p>На лист будут выведены подробности заказа.</p>
</li><li>
<p>В списке <span class="ui">Состояние заказа</span> выберите пункт <span class="ui">
Выполнен</span>.</p>
<p>После из&#1084;енение состояния на <span class="ui">Выполнен</span> выполните указанные ниже действия.</p>
<ul>
<li>
<p>Состояние заказа сохраняется обратно в хранящийся в па&#1084;яти набор данных.</p>
</li><li>
<p>Количество единиц каждого заказанного продукта в заказе вычитается из значения пара&#1084;етра
<span class="ui">UnitsInStock</span> для этого продукта в храняще&#1084;ся в па&#1084;яти наборе данных. Это гарантирует правильное значение пара&#1084;етра
<span class="ui">UnitsInStock</span> для каждого продукта при следующе&#1084; заказе.</p>
</li><li>
<p>Заказ удаляется из списка <span class="ui">Невыполненные заказы</span>.</p>
</li></ul>
</li></ol>
</div>
<h1>Описание</h1>
<div class="section" id="demonstratesSection">
<p>В данно&#1084; при&#1084;ере де&#1084;онстрируются указанные ниже воз&#1084;ожности:</p>
<ul>
<li>
<p>Загрузка и использование данных из XML-файла, извлеченного из базы данных SQL Server.</p>
</li><li>
<p>Вывод данных с по&#1084;ощью привязанных к данны&#1084; эле&#1084;ентов управления Excel.</p>
</li><li>
<p>Работа с нескольки&#1084;и набора&#1084;и основных/подробных данных .</p>
</li></ul>
</div>
<h1>&nbsp;При&#1084;ер кода</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енить</span>|<span class="pluginRemoveHolderLink">Удалить</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Ensures&nbsp;data&nbsp;is&nbsp;read&nbsp;in&nbsp;from&nbsp;data&nbsp;source&nbsp;so&nbsp;the&nbsp;sample&nbsp;will&nbsp;run&nbsp;properly.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;LoadCompanyData()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Assert(<span class="cs__keyword">this</span>.currentCompanyData&nbsp;==&nbsp;<span class="cs__keyword">null</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.currentCompanyData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CompanyData();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.currentCompanyData.DataSetName&nbsp;=&nbsp;<span class="cs__string">&quot;CompanyData&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.currentCompanyData.Locale&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ru-RU/library/System.Globalization.CultureInfo.aspx" target="_blank" title="Auto generated link to System.Globalization.CultureInfo">System.Globalization.CultureInfo</a>(<span class="cs__string">&quot;ru-ru&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.currentCompanyData.RemotingFormat&nbsp;=&nbsp;System.Data.SerializationFormat.Xml;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;fileLocation&nbsp;=&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ru-RU/library/System.IO.Path.Combine.aspx" target="_blank" title="Auto generated link to System.IO.Path.Combine">System.IO.Path.Combine</a>(<span class="cs__keyword">this</span>.Path,<span class="cs__string">&quot;data.xml&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.Assert(<a class="libraryLink" href="http://msdn.microsoft.com/ru-RU/library/System.IO.File.Exists.aspx" target="_blank" title="Auto generated link to System.IO.File.Exists">System.IO.File.Exists</a>(fileLocation),&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Format(<span class="cs__string">&quot;Sample&nbsp;data&nbsp;file&nbsp;{0}&nbsp;does&nbsp;not&nbsp;exist.&quot;</span>,&nbsp;fileLocation));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.currentCompanyData.ReadXml(fileLocation,&nbsp;XmlReadMode.IgnoreSchema);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.currentCompanyData.AcceptChanges();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<h1>Дополнительные сведения</h1>
<p>Дополнительные сведения об инстру&#1084;ентах разработчика Office в Visual Studio с&#1084;
<a href="http://msdn.microsoft.com/ru-ru/office/hh133430">http://msdn.microsoft.com/ru-ru/office/hh133430</a>.</p>
