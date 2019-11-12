# SharePoint REST API Extension
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SharePoint Server 2013
- SharePoint Foundation 2013
- SharePoint 2016
## Topics
- REST
- SharePoint 2013
- SharePoint 2016
## Updated
- 07/18/2016
## Description

<h1>Введение</h1>
<p><em>Создание REST-сервиса и публикация его в SharePoint 2013.</em></p>
<p><em><img id="153910" src="153910-api-note.png" alt="" width="815" height="192"><br>
</em></p>
<h1><span>Построение</span></h1>
<p><em>Решение создано в Visual Studio 2015 и предназначено для развертывания в фер&#1084;е SharePoint 2013 On-Premise. Для его открытия потребуется наличие установленного пакета Office Developer Tools.</em></p>
<p><em>Решение уровня фер&#1084;ы (farm solution) и не предназначено для его публикации в SharePoint Online либо в виде sandbox solution.</em></p>
<p><span style="font-size:20px; font-weight:bold">Описание</span></p>
<p><em>SharePoint позволяет публиковать свои REST-сервисы и обращаться к ни&#1084;, используя HTTP-запросы с префиксо&#1084; _api. По&#1084;и&#1084;о этого разработчика&#1084; доступна воз&#1084;ожность создавать свои собственные REST-сервисы и публиковать их в веб-приложениях SharePoint.</em></p>
<p><em>Такие сервисы доступны по HTTP-запроса&#1084; вида:</em></p>
<p><em>http://sharepoint/_api/<strong>YourServiceNamespace</strong></em></p>
<p><em>Публикуе&#1084;ые сервисы &#1084;огут содержать как свойства так и &#1084;етоды. Данные &#1084;огут быть представленны как в виде XML, так и в виде JSON. Для получения данных в фор&#1084;ате JSON в заголовок запроса достаточно добавить ключ&nbsp;<strong>Accept</strong>, со значение
<strong>application/json;odata=verbose</strong>.</em></p>
<h1><span>Подробное описание</span></h1>
<h1><em style="font-size:10px">Подробное описание решения доступно в &#1084;ое&#1084; блоге по адресу:&nbsp;<a href="http://blog.vitalyzhukov.ru/ru/sharepoint-custom-rest-api.aspx">http://blog.vitalyzhukov.ru/ru/sharepoint-custom-rest-api.aspx</a></em></h1>
