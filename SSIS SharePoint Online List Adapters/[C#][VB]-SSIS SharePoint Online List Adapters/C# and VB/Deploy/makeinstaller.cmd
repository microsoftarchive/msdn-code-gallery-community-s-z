REM Any existing installation of the adapters MUST be uninstalled before this executes
REM or else the installed GAC components will throw off the build.
msiexec /x {53623FF2-309D-44FA-86B7-19728C3D8CE3}

attrib -r /s
xcopy ..\Src\*.cs sql2005 /s /y /EXCLUDE:excludefilelist.txt
xcopy ..\Src\*.cs sql2008 /s /y /EXCLUDE:excludefilelist.txt
xcopy ..\Src\*.cs Sql2012 /s /y /EXCLUDE:excludefilelist.txt
xcopy ..\Src\SharePointUtility\*.vb SharePointUtility /s /y /EXCLUDE:excludefilelist.txt
del *.pdb /s
del *.dll /s
del *.msi /s


cd sql2005
copy ..\FindReplaceText.exe /Y
FindReplaceText "IDTSInputColumnCollection100" "IDTSInputColumnCollection90"
FindReplaceText "IDTSExternalMetadataColumn100" "IDTSExternalMetadataColumn90" 
FindReplaceText "IDTSInput100" "IDTSInput90" 
FindReplaceText "IDTSInputColumn100" "IDTSInputColumn90" 
FindReplaceText "IDTSCustomProperty100" "IDTSCustomProperty90" 
FindReplaceText "IDTSVirtualInputColumn100" "IDTSVirtualInputColumn90" 
FindReplaceText "IDTSOutput100" "IDTSOutput90" 
FindReplaceText "IDTSOutputColumn100" "IDTSOutputColumn90" 
FindReplaceText "IDTSRuntimeConnection100" "IDTSRuntimeConnection90" 
FindReplaceText "DtsConvert.GetWrapper" "DtsConvert.ToConnectionManager" 
FindReplaceText "1.0.0.0" "1.2005.0.0" 
cd..

cd sql2008
copy ..\FindReplaceText.exe /Y
FindReplaceText "IDTSInputColumnCollection90" "IDTSInputColumnCollection100"
FindReplaceText "IDTSExternalMetadataColumn90" "IDTSExternalMetadataColumn100" 
FindReplaceText "IDTSInput90" "IDTSInput100" 
FindReplaceText "IDTSInputColumn90" "IDTSInputColumn100" 
FindReplaceText "IDTSCustomProperty90" "IDTSCustomProperty100" 
FindReplaceText "IDTSVirtualInputColumn90" "IDTSVirtualInputColumn100" 
FindReplaceText "IDTSOutput90" "IDTSOutput100" 
FindReplaceText "IDTSOutputColumn90" "IDTSOutputColumn100" 
FindReplaceText "IDTSRuntimeConnection90" "IDTSRuntimeConnection100" 
cd ..

cd sql2012
copy ..\FindReplaceText.exe /Y
FindReplaceText "IDTSInputColumnCollection90" "IDTSInputColumnCollection100"
FindReplaceText "IDTSExternalMetadataColumn90" "IDTSExternalMetadataColumn100" 
FindReplaceText "IDTSInput90" "IDTSInput100" 
FindReplaceText "IDTSInputColumn90" "IDTSInputColumn100" 
FindReplaceText "IDTSCustomProperty90" "IDTSCustomProperty100" 
FindReplaceText "IDTSVirtualInputColumn90" "IDTSVirtualInputColumn100" 
FindReplaceText "IDTSOutput90" "IDTSOutput100" 
FindReplaceText "IDTSOutputColumn90" "IDTSOutputColumn100" 
FindReplaceText "IDTSRuntimeConnection90" "IDTSRuntimeConnection100" 
FindReplaceText "1.0.0.0" "1.2012.0.0" 
cd..

ECHO Clear the GAC of any components which may interfere with the deployment
gacutil /uf sharepointlistadapters
gacutil /uf sharepointlistconnectionmanager
gacutil /uf sharepointutility

ECHO Building the SharePointUtility First
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\msbuild SharePointUtility\SharePointUtility.vbproj /t:Rebuild /p:Configuration=Release
gacutil /i sharepointutility

ECHO Build the MSIs for Deployment...
FindReplaceText " Platform=""x86""" " Platform=""x64"""
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\msbuild DeploySSISAdapters.sln /t:Rebuild /p:Configuration=Release /p:OutputName=SharePointListAdapterSetup_x64

FindReplaceText " Platform=""x64""" " Platform=""x86"""
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\msbuild DeploySSISAdapters.sln /t:Rebuild /p:Configuration=Release /p:OutputName=SharePointListAdapterSetup_x86

