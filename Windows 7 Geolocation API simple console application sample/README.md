# Windows 7 Geolocation API simple console application sample
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Windows 7 Sensors API
## Topics
- Geolocation
- SensorsAndLocation
- Sensors
## Updated
- 11/02/2011
## Description

<h1>Introduction</h1>
<p><em>If you&nbsp; running a Windows 7 machine (even without GPS) you can detect computer location, thanks to Windows 7 Sensors API. So you can create geolocation-enabled applications that can find your computer accurately. To do this Window 7 needs a sensor
 installed to provide the services with information pertinent to the service.&nbsp; One such sensor is
<strong>Geosense</strong>.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Just compile provided Visual Studio 2010 Solution and press CTRL&#43;F5 to run console application.</em></p>
<p><span style="font-size:20px; font-weight:bold">Running sample</span></p>
<p><br>
To run sample on computer without GPS you need to install geolocation sensor, for example<br>
Geosence (<a href="http://www.bing.com/search?q=geosence&go=&form=QBLH&filt=all">http://www.bing.com/search?q=geosence&amp;go=&amp;form=QBLH&amp;filt=all</a>). Then installed don&rsquo;t forget to enable it at control panel.</p>
<p>Then you run console app, it will try to detect your location via Sensors API and if success prints your coordinates that you can use later.</p>
<p><img src="45544-07a2f30c2fc2b186377d6d232bd1c474.png" alt="" width="542" height="461"></p>
<h1>More Information</h1>
<p><em>Windows 7 includes native support for sensors, expanded by a new development platform for working with sensors. The Windows Sensor and Location platform provides a standard way for device manufacturers to expose sensor devices to software developers
 and consumers, while providing developers with a standardized application programming interface (API) for working with sensors and sensor data.</em></p>
<p><em>Read more about Windows 7 Sensors API at <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/dd318953(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/dd318953(v=vs.85).aspx</a>?</em></p>
