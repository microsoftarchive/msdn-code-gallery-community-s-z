# Weather app for Windows Store
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Store app
## Topics
- Cross Platform Code Reuse
## Updated
- 07/17/2013
## Description

<p>I converted the Windows Phone weather app to Windows Store.</p>
<p>The Windows Phone version is here:</p>
<p><a href="http://code.msdn.microsoft.com/wpapps/Weather-Forecast-Sample-586ef733">http://code.msdn.microsoft.com/wpapps/Weather-Forecast-Sample-586ef733</a></p>
<p>It&rsquo;s a simple app that calls the National Weather Service to get the current weather forecast. Here&rsquo;s an example of a query string that returns the weather for Redmond, Washington in an XML file:
<a href="http://forecast.weather.gov/MapClick.php?lat=47.67&lon=-122.12&FcstType=dwml">
http://forecast.weather.gov/MapClick.php?lat=47.67&amp;lon=-122.12&amp;FcstType=dwml</a>.</p>
<p>The steps to create this project are described in the CuratedAnswer titled &quot;Converting Windows Phone apps to Windows Store apps:</p>
<ul>
<li>Migrating the UI and code </li><li>Passing data between pages </li></ul>
<p style="padding-left:60px">This is probably the trickiest part of the conversion. Windows Phone apps use a query string, much like a web call, to pass data between pages. Windows Store uses an object parameter. The object parameter can be any type you like.
 You pass it in the call to LoadState, and then cast it back to use it &ndash; but beware of the usual pitfalls of casting. The LoadState method is defined in the LayoutAwarePage in your Windows Store project and is called by Page.OnNavigatedTo under the covers.
 Hence LoadState is not part of the Windows API, so you won&rsquo;t find a doc page for it. You will find references to Page.OnNavigatedTo throughout the documentation.</p>
<ul>
<li>OnNavigatedFrom </li><li>HttpClient </li></ul>
<p><br>
<span style="line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:small">The converted app represents the minimum level of work to get the job done. There are a lot more options for Windows Store apps that would have improved the UI considerably.</span></p>
<p>&nbsp;</p>
