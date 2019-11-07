@echo off

SET VER=2.0.1.41412
SET NUGET_KEY=cc384668-80a9-4273-bc60-c17223e87302
SET MYGET_KEY=75a16c9c-8070-4f18-865e-961c5976a35d

IF NOT "%1" == "" (
   SET VER=%1
)

echo.
echo ================================================================================
echo Timeline Version %VER%. Package and publish. 
echo.
echo Press Ctrl-C to abort.
echo.
echo ================================================================================
echo.
pause

echo.
echo --------------------------------------------------------------------------------
echo XCopy Sources
echo --------------------------------------------------------------------------------
echo.
rmdir /s /q src
mkdir src
mkdir src\Silverlight
mkdir src\WPF

xcopy ..\..\Library\Silverlight\*.cs src\Silverlight /S
xcopy ..\..\Library\WPF\*.cs src\WPF /S
xcopy ..\..\Library\Silverlight\*.xaml src\Silverlight /S
xcopy ..\..\Library\WPF\*.xaml src\WPF /S

xcopy ..\..\Library\Silverlight\TimelineExLib\Bin\Release\Timeline*.* lib\sl5 /S
xcopy ..\..\Library\WPF\TimelineExLib\Bin\Release\Timeline*.* lib\net40 /S

echo.
echo --------------------------------------------------------------------------------
echo Update NuGet
echo --------------------------------------------------------------------------------
echo.
del *.nupkg
nuget Update -self
nuget setApiKey %NUGET_KEY%

echo.
echo --------------------------------------------------------------------------------
echo Create packages
echo --------------------------------------------------------------------------------
echo.
nuget pack Timeline.nuspec -Symbols

echo.
echo --------------------------------------------------------------------------------
echo Publishing to Public Store at www.nuget.org
echo --------------------------------------------------------------------------------
echo.
NuGet Push Timeline.%VER%.nupkg
NuGet Push Timeline.%VER%.symbols.nupkg

echo.
echo --------------------------------------------------------------------------------
echo Publishing to private myget.org http://nuget.gw.symbolsource.org/MyGet/vizdata
echo --------------------------------------------------------------------------------
echo.

nuget push Timeline.%VER%.nupkg %MYGET_KEY% -Source http://www.myget.org/F/vizdata/api/v2/package
nuget push Timeline.%VER%.symbols.nupkg %MYGET_KEY% -Source http://nuget.gw.symbolsource.org/MyGet/vizdata
