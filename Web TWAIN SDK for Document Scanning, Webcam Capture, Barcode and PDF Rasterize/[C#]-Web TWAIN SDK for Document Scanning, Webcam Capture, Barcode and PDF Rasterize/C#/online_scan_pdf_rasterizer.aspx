<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page Language="C#"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title>Convert text-over-image PDF to images | Online PDF Rasterizer</title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <meta http-equiv="Content-Language" content="en-us"/>
    <meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
    <meta name="viewport" content="width=device-width, maximum-scale=1.0" />
    <meta name="description" content="This online demo application shows how to use Dynamsoft PDF library (an add-on to Dynamic Web TWAIN) to convert text-over-image PDF files to images." />
    <%= Common.DW_Keyword%>
    <link href="Styles/style.css" type="text/css" rel="stylesheet" />
    <script>
     // JavaScript Document
     var _gaq = _gaq || [];
     _gaq.push(['_setAccount', 'UA-19660825-1']);
     _gaq.push(['_setDomainName', 'dynamsoft.com']);
     _gaq.push(['_trackPageview']);
     (function() {
         var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
         ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
         var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
     })();
    </script>
    <script type="text/javascript">
        window.history.forward();
        function noBack() { window.history.forward(); }

</script>
</head>

<body onpageshow="if (event.persisted) noBack();" onunload="">
    
<div id="container" class="body_Broad_width" style="margin:0 auto;">

<div class="DWTHeader">
    <!-- header.aspx is used to initiate the head of the sample page. Not necessary!-->
    <!-- #include file=includes/PageHead.aspx -->
    <script src="Scripts/PageMenu.js?Type=3"></script>
</div>

<div id="DWTcontainer" class="body_Broad_width" style="background-color:#ffffff; height:920px; border:0;">

<div id="dwtcontrolContainer" style="height:605px;"></div>
<div id="DWTNonInstallContainerID" style="width:580px"></div>

<div id="ScanWrapper">
<div id="divScanner" class="divinput">
    <ul class="PCollapse"> 
    <li>
        <div class="divType"><div class="mark_arrow expanded"></div>Load a Local PDF/Image</div>
        <div id="div_LoadLocalImage" class="divTableStyle">
            <ul>
                <li style="text-align: center; height:35px; padding-top:10px;">
                    <input class="btn-loadImg" type="button" value="Load File" style="width: 130px; height:31px; font-size:medium;" onclick="return btnLoadPDF_onclick()" />
                </li>
            </ul>
        </div>
    </li>
   
    </ul>

</div>

<div id="divBlank" style="height:20px">
<ul>
    <li></li>
</ul>
</div>

<div id="divSave" class="divinput" style="position:relative">
<ul>
    <li><img alt="arrow" src="Images/arrow.gif" width="9" height="12"/><b>Save Image</b></li>
    <li style="padding-left:15px;">
        <label for="txt_fileNameforSave">File Name: <input type="text" size="20" id="txt_fileNameforSave"/></label></li>
    <li style="padding-left:12px;">
        <label for="imgTypebmp">
            <input type="radio" value="bmp" name="imgType_save" id="imgTypebmp" onclick ="rdsave_onclick();"/>BMP</label>
	    <label for="imgTypejpeg">
		    <input type="radio" value="jpg" name="imgType_save" id="imgTypejpeg" onclick ="rdsave_onclick();"/>JPEG</label>
	    <label for="imgTypetiff">
		    <input type="radio" value="tif" name="imgType_save" id="imgTypetiff" onclick ="rdTIFFsave_onclick();"/>TIFF</label>
	    <label for="imgTypepng">
		    <input type="radio" value="png" name="imgType_save" id="imgTypepng" onclick ="rdsave_onclick();"/>PNG</label>
	    <label for="imgTypepdf">
		    <input type="radio" value="pdf" name="imgType_save" id="imgTypepdf" onclick ="rdPDFsave_onclick();"/>PDF</label></li>
    <li style="padding-left:12px;">
        <label for="MultiPageTIFF_save"><input type="checkbox" id="MultiPageTIFF_save"/>Multi-Page TIFF</label>
        <label for="MultiPagePDF_save"><input type="checkbox" id="MultiPagePDF_save"/>Multi-Page PDF </label></li>
    <li style="text-align: center">
        <input id="btnSave" type="button" value="Save Image" onclick ="btnSave_onclick()"/></li>
</ul>
</div>

<div id="divNoteMessage"  >
</div>

</div>
<div id="DWTemessageContainer" style="float:left; margin-left:40px; width:580px"></div>
</div>


<div class="DWTTail">
    <!-- #include file=includes/PageTail.aspx -->
</div>



</div>

<div id="ImgSizeEditor" style="visibility:hidden; text-align:left;">	
<ul>
    <li><label for="img_height"><b>New Height :</b>
        <input type="text" id="img_height" style="width:50%;" size="10"/>pixel</label></li>
    <li><label for="img_width"><b>New Width :</b>&nbsp;
        <input type="text" id="img_width" style="width:50%;" size="10"/>pixel</label></li>
    <li>Interpolation method:
        <select size="1" id="InterpolationMethod"><option value = ""></option></select></li>
    <li style="text-align:center;">
        <input type="button" value="   OK   " id="btnChangeImageSizeOK" onclick ="btnChangeImageSizeOK_onclick();"/>
        <input type="button" value=" Cancel " id="btnCancelChange" onclick ="btnCancelChange_onclick();"/></li>
</ul>
</div>
 <div class="narrow-screen">
        <div class="tips-header"><a href="http://www.dynamsoft.com/Products/WebTWAIN_Overview.aspx"><img src="images/DWT icon logo.png" border="0" /></a><h1>Online Demo</h1></div>
        <div class="tips-desktop"><img src="images/sc-desktop-only.png" border="0" alt="" width="280"/></div>
        <p class="tips">Sorry! <br /> This page is an online demo of Dynamic Web TWAIN which runs in browsers on Windows and Mac OS X only, for now. Thanks! </p>
</div>
<script type="text/javascript" language="javascript" src="Resources/dynamsoft.webtwain.initiate.js?t=150418"></script>
<script type="text/javascript" language="javascript" src="Resources/dynamsoft.webtwain.config.js"></script>
<script type="text/javascript" language="javascript" src="Resources/addon/dynamsoft.webtwain.addon.pdf.js"> </script>
<script type="text/javascript" language="javascript" src="Scripts/online_demo_operation.js"></script>
<script type="text/javascript" language="javascript" src="Scripts/online_demo_initpage.js"></script>
<script type="text/javascript" language="javascript" src="Scripts/jquery.js"></script>
<%=Common.DW_LiveChatJS %>
<script type="text/javascript">
    $("ul.PCollapse li>div").click(function() {
        if ($(this).next().css("display") == "none") {
            $(".divType").next().hide("normal");
            $(".divType").children(".mark_arrow").removeClass("expanded");
            $(".divType").children(".mark_arrow").addClass("collapsed");
            $(this).next().show("normal");
            $(this).children(".mark_arrow").removeClass("collapsed");
            $(this).children(".mark_arrow").addClass("expanded");
        }
    });
</script>
<script type="text/javascript" language="javascript">
    // Assign the page onload fucntion.
    $(function() {
        pageonload();
    });

    $('#DWTcontainer').hover(function() {
        $(document).bind('mousewheel DOMMouseScroll', function(event) {
            stopWheel(event);
        });
    }, function() {
        $(document).unbind('mousewheel DOMMouseScroll');
    });
</script>
</body>
</html>

