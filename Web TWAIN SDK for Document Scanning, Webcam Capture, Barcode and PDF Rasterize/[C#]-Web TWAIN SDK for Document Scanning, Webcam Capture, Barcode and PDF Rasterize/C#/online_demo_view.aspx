<%@ Page Language="C#"%>
<%
	//get temp file name 
        
    System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
	
    String strImageName;
    String strImageExtName;
    String strImageID;
	String strImageFileType;

    strImageName = request["ImageName"];
    strImageExtName = request["ImageExtName"];
    strImageID = request["iImageIndex"];
    strImageFileType = "1";
    
    if(strImageExtName == "bmp"){
        strImageFileType = "0";
    }else if(strImageExtName == "jpg"){
        strImageFileType = "1";
    }else if(strImageExtName == "tif"){
        strImageFileType = "2";
    }else if(strImageExtName == "png"){
        strImageFileType = "3";
    }else if(strImageExtName == "pdf"){
        strImageFileType = "4";
    }
    
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title><%= Common.DW_Title%></title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <meta http-equiv="Content-Language" content="en-us"/>
    <meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
    <meta name="viewport" content="width=device-width, maximum-scale=1.0" />
    <%= Common.DW_Description%>
    <%= Common.DW_Keyword%>
    <link href="Styles/style.css" type="text/css" rel="stylesheet" />
</head>

<body>

<div id="container" class="body_Broad_width" style="margin:0 auto;">

<div class="DWTHeader">
    <!-- header.aspx is used to initiate the head of the sample page. Not necessary!-->
    <!-- #include file=includes/PageHead.aspx -->
</div>

<div id="DWTcontainer" class="body_Broad_width" style="background-color:#ffffff; height:900px; border:0;">
<div id="dwtcontrolContainer" style="padding-left: 150px; height:605px;"></div>
<div id="DWTNonInstallContainerID" style="width:580px"></div>
<div id="DWTemessageContainer" style="margin-left:40px;padding-left: 150px;width:580px"></div>
</div>

 <div class="DWTTail">
    <!-- #include file=includes/PageTail.aspx -->
</div>


</div>
<div class="narrow-screen">
        <div class="tips-header"><a href="http://www.dynamsoft.com/Products/WebTWAIN_Overview.aspx"><img src="images/DWT icon logo.png" border="0" /></a><h1>Online Demo</h1></div>
        <div class="tips-desktop"><img src="images/sc-desktop-only.png" border="0" alt="" width="280"/></div>
        <p class="tips">Sorry! <br /> This page is an online demo of Dynamic Web TWAIN which runs in browsers on Windows and Mac OS X only, for now. Thanks! </p>
</div>
</body>
    <script type="text/javascript" language="javascript" src="Resources/dynamsoft.webtwain.initiate.js"></script>
    <script type="text/javascript" language="javascript" src="Resources/dynamsoft.webtwain.config.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/online_demo_operation.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/online_demo_initpage.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/jquery.js"></script>
    
<script type="text/javascript" language="javascript">

function pageonloadForView() {
    initMessageBox(true);
}


// Check if the control is fully loaded.
function Dynamsoft_OnReady() {
    // If the ErrorCode is 0, it means everything is fine for the control. It is fully loaded.
     DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');  
    if (DWObject) {
        if (DWObject.ErrorCode == 0) {
            DWObject.LogLevel = 1;
            DWObject.IfAllowLocalCache = true;

    	   
            if (Dynamsoft.Lib.env.bWin)
                DWObject.MouseShape = false;
                
             var CurrentPathName,CurrentPath,strActionPage,strHTTPServer,downloadsource;
	        if(location.port==''){
		        DWObject.HTTPPort = DynamLib.detect.ssl? 443 : 80;
	        } else {
		        DWObject.HTTPPort = location.port;
	        }
        	
	        DWObject.IfSSL = DynamLib.detect.ssl;
    	    
	        CurrentPathName = unescape(location.pathname);	// get current PathName in plain ASCII	
	        CurrentPath = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1);			
	        strActionPage = CurrentPath + "online_demo_download.aspx"; //the ActionPage's file path
	        strHTTPServer = location.hostname;
	        downloadsource = strActionPage + "?iImageIndex=<%=strImageID%>&ImageName=<%=strImageName%>&ImageExtName=<%=strImageExtName%>";
        	
	        var sFun = function(){
	            updatePageInfo();
	        };
	        var OnSuccess = function() {
                updatePageInfo();
            };

            var OnFailure = function(errorCode, errorString) {
                updatePageInfo();
            };

	        DWObject.HTTPDownloadEx(strHTTPServer, downloadsource, <%=strImageFileType %>, OnSuccess, OnFailure);

            
            DWObject.RegisterEvent("OnPostTransfer", Dynamsoft_OnPostTransfer);
            DWObject.RegisterEvent("OnPostLoadfunction", Dynamsoft_OnPostLoadfunction);
            DWObject.RegisterEvent("OnPostAllTransfers", Dynamsoft_OnPostAllTransfers);
            DWObject.RegisterEvent("OnMouseClick", Dynamsoft_OnMouseClick);            
            DWObject.RegisterEvent("OnImageAreaSelected", Dynamsoft_OnImageAreaSelected);
            DWObject.RegisterEvent("OnImageAreaDeSelected", Dynamsoft_OnImageAreaDeselected);
            DWObject.RegisterEvent("OnTopImageInTheViewChanged", Dynamsoft_OnTopImageInTheViewChanged);
        }
    }
}


 $(function() {
        pageonloadForView();
    });

</script>  
<%=Common.DW_LiveChatJS %>
</html>