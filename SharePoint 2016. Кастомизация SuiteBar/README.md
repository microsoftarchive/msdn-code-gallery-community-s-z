# SharePoint 2016. Кастомизация SuiteBar
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SharePoint Server 2016
## Topics
- SharePoint Branding
- SharePoint SuiteBar
## Updated
- 07/12/2016
## Description

<h1>Введение</h1>
<p><span style="font-size:small"><em>Де&#1084;онстрационный проект, из&#1084;еняющий SuiteBar и AppLauncher в SharePoint 2016 OnPrem.</em></span></p>
<p><em><img id="155755" src="155755-suitebarmenu-note.png" alt="" width="815" height="475"><br>
</em></p>
<h1><span>Построение</span></h1>
<p><em>Р<span style="font-size:small">ешение создано в Visual Studio 2015 и предназначено для развертывания в фер&#1084;е SharePoint 2016 On-Premise. Для его открытия потребуется наличие установленного пакета Office Developer Tools.</span></em></p>
<p><span style="font-size:small"><em>Решение уровня фер&#1084;ы (farm solution) и не предназначено для его публикации в SharePoint Online либо в виде sandbox solution.</em></span></p>
<h1><span style="font-size:20px; font-weight:bold">Описание</span></h1>
<p><em style="font-size:small">В решение включены следующие артефакты:</em></p>
<h2><em><span style="font-size:15px">Классы для создание SuiteNav</span></em></h2>
<p><span style="font-size:small"><em>Класс-контейнер SuiteNav, содержит инфор&#1084;ацию о версии, воз&#1084;ожности кеширования и са&#1084;и данные (свойство NavBarData):</em></span></p>
<p><em><span style="font-size:15px">&nbsp;</span></em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SuiteNav&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;DoNotCache&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavBarData&nbsp;NavBarData&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;SPSuiteVersion&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode"><em><span style="font-size:small">&nbsp;Са&#1084;и данные для SuiteBar представленны классо&#1084; SuiteNavBarData:</span></em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;SuiteNavBarData&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavLink&nbsp;AboutMeLink&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ClientData&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;CurrentMainLinkElementID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavLink[]&nbsp;CurrentWorkloadHelpSubLinks&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavLink[]&nbsp;CurrentWorkloadSettingsSubLinks&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavLink[]&nbsp;CurrentWorkloadUserSubLinks&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavLink&nbsp;HelpLink&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsAuthenticated&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SuiteNavLink&nbsp;SignOutLink&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;&nbsp;StringsOverride&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;UserDisplayName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;SuiteNavLink&gt;&nbsp;WorkloadLinks&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><em><span style="font-size:small">Свойства класса SuiteNavBarData:</span></em></div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small"><strong>CurrentMainLinkElementID&nbsp;</strong>- просто указывае&#1084; &quot;ShellSharepoint&quot;;</span>
</li><li><span style="font-size:small"><strong>UserDisplayName&nbsp;</strong>- и&#1084;я текущего пользователя, &#1084;ожно указать любое значение;</span>
</li><li><span style="font-size:small"><strong>IsAuthenticated&nbsp;</strong>- авторизован ли пользователь;</span>
</li><li><span style="font-size:small"><strong>CurrentWorkloadHelpSubLinks&nbsp;</strong>- дополнительные пункты &#1084;еню&nbsp;<em>Справка</em>;</span>
</li><li><span style="font-size:small"><strong>CurrentWorkloadSettingsSubLinks&nbsp;</strong>- дополнительные пункты &#1084;еню&nbsp;<em>Настройка</em>;</span>
</li><li><span style="font-size:small"><strong>CurrentWorkloadUserSubLinks</strong>&nbsp;- дополнительные пункты &#1084;еню&nbsp;<em>Пользователя</em>;</span>
</li><li><span style="font-size:small"><strong>WorkloadLinks&nbsp;</strong>- App Launcher;</span>
</li></ul>
<p><em style="font-size:1.5em">&nbsp;</em></p>
<div class="endscriptcode" style="display:inline!important">
<p style="display:inline!important"><span style="font-size:small">Са&#1084;и ссылки описываются классо&#1084; SuiteNavLink:</span></p>
</div>
<h2><em>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;SuiteNavLink&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Text&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Title&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;Url&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
</em></h2>
<h2>REST API</h2>
<p><span style="font-size:small">В качестве источника данных для SuiteBar &#1084;ожет выступать только REST API. Для этого в решении описан сервис&nbsp;и, содержащий &#1084;етод&nbsp;<strong>GetSuiteNavData</strong>. Метод должен обязательно наызваться&nbsp;<strong>GetSuiteNavData</strong>,
 иначе решение не заработает.</span></p>
<h1><span style="font-size:small">Делегат контрол</span></h1>
<p><span style="font-size:small">Для регистрации сервиса в качестве источника данных для SuiteBar в решении присутствует эле&#1084;ент&nbsp;<strong>SuiteNavStapling</strong>:</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;Elements</span>&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/sharepoint/&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Control</span>&nbsp;<span class="xml__attr_name">Id</span>=<span class="xml__attr_value">&quot;SuiteBarDelegate&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">Sequence</span>=<span class="xml__attr_value">&quot;50&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">ControlClass</span>=<span class="xml__attr_value">&quot;Microsoft.SharePoint.WebControls.SuiteNavControl&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">ControlAssembly</span>=<span class="xml__attr_value">&quot;<a class="libraryLink" href="https://msdn.microsoft.com/ru-RU/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a>,&nbsp;Version=16.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">xmlns</span>=<span class="xml__attr_value">&quot;http://schemas.microsoft.com/sharepoint/&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Property</span>&nbsp;<span class="xml__attr_name">Name</span>=<span class="xml__attr_value">&quot;SuiteNavRestMethod&quot;</span><span class="xml__tag_start">&gt;</span>CustomSuiteNav/GetSuiteNavData<span class="xml__tag_end">&lt;/Property&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Control&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Elements&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<ul>
</ul>
<h1>Подробное описание</h1>
<p><span style="font-size:small"><em>Подробное описание доступно у &#1084;еня в блоге:&nbsp;<a href="http://blog.vitalyzhukov.ru/ru/sharepoint-2016-suitebar-menu.aspx" target="_blank">http://blog.vitalyzhukov.ru/ru/sharepoint-2016-suitebar-menu.aspx</a></em></span></p>
