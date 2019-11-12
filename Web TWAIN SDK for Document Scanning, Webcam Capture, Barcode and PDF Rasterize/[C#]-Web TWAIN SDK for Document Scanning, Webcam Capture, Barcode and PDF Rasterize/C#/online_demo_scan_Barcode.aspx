<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page Language="C#"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">
    <title>Online QR Code Reader – scan barcode from scanners and webcams</title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <meta http-equiv="Content-Language" content="en-us"/>
    <meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
    <meta name="viewport" content="width=device-width, maximum-scale=1.0" />
    <meta name="description" content="This online demo application (JavaScript + ASP.NET-C#) shows how to use Dynamsoft barcode SDK to scan barcode on images captured from scanners or webcams. " />
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
    <script src="Scripts/PageMenu.js?Type=2"></script>
</div>

<div id="DWTcontainer" class="body_Broad_width" style="background-color:#ffffff; height:920px; border:0;">

<div id="dwtcontrolContainer" style="height:605px;"></div>
<div id="DWTNonInstallContainerID" style="width:580px"></div>

<div id="ScanWrapper">
                <div id="divList" class="divinput">
                    <ul class="PCollapse">
                        <li>
                            <div class="divType"><div class="mark_arrow expanded"></div>Sample Images</div>
                            <div id="div_SampleImage" class="divTableStyle">
                                <ul>
                                <li></li>
                                    <li style="text-align: center;">
                                        <table style="border-spacing: 2px; width: 100%; margin-top = 5px;">
                                            <tr>
                                                 <td style="width: 25%">
                                                    <input name="code39Sample" type="image" src="Images/code-39.png" style="width: 50px;
                                                        height: 50px" onclick="LoadBarcodeDemoImage(1);" onmouseover="Over_Out_DemoImage(this,'Images/code-39_hover.png');"
                                                        onmouseout="Over_Out_DemoImage(this,'Images/code-39.png');" />
                                                </td>
                                                <td style="width: 25%">
                                                    <input name="code128Sample" type="image" src="Images/code-128.png" style="width: 50px;
                                                        height: 50px" onclick="LoadBarcodeDemoImage(2);" onmouseover="Over_Out_DemoImage(this,'Images/code-128_hover.png');"
                                                        onmouseout="Over_Out_DemoImage(this,'Images/code-128.png');" />
                                                </td>
                                                <td style="width: 25%">
                                                    <input name="qrcodeSample" type="image" src="Images/qrcode.png" style="width: 50px;
                                                        height: 50px" onclick="LoadBarcodeDemoImage(3);" onmouseover="Over_Out_DemoImage(this,'Images/qrcode_hover.png');"
                                                        onmouseout="Over_Out_DemoImage(this,'Images/qrcode.png');" />
                                                </td>

                                                <td>
                                                    <input name="upcaSample" type="image" src="Images/UPC-A.png" style="width: 50px;
                                                        height: 50px" onclick="LoadBarcodeDemoImage(4);" onmouseover="Over_Out_DemoImage(this,'Images/UPC-A_hover.png');"
                                                        onmouseout="Over_Out_DemoImage(this,'Images/UPC-A.png');" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Code 39
                                                </td>
                                                <td>
                                                    Code 128
                                                </td>
                                                <td>
                                                    QR Code
                                                </td>
                                                <td>
                                                    UPC-A
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="divType"><div class="mark_arrow collapsed"></div>Local Images</div>
                            <div id="div_LoadLocalImage" style="display: none" class="divTableStyle">
                                <ul>
                                    <li style="text-align: center; height:35px; padding-top:8px;">
                                        <input class="btn-loadImg" type="button" value="Load Image" style="width: 130px; height:31px; font-size:medium;" onclick="return btnLoad_onclick()" />
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="divType"><div class="mark_arrow collapsed"></div>Custom Scan</div>
                            <div id="div_ScanImage" style="display: none" class="divTableStyle">
                                <ul id="ulScaneImageHIDE" >
                                    <li style="padding-left: 15px;">
                                        <label for="source">Select Source:</label>
                                        <select size="1" id="source" style="position:relative;width: 220px;" onchange="source_onchange(false)">
                                            <option value = ""></option>    
                                        </select>&nbsp;<a href="http://kb.dynamsoft.com/questions/541/Why+is+my+scanner+not+shown+or+not+responding+in+the+browser%3F" target="_blank"><img title = "Why is my scanner not shown or not responding in the browser?" alt = "Why is my scanner not shown or not responding in the browser?" style="border:none;" src="Images/faq 16.png"/></a></li>
                                         <li style="display:none;" id="pNoScanner">
                                            <a href="javascript: void(0)" class="ShowtblLoadImage" style="font-size: 11px; background-color:#f0f0f0; position:relative" id="aNoScanner"><b>What if I don't have a scanner/webcam connected?</b>
                                        </a></li>
                                        <li id="divProductDetail"></li>
                                    <li style="text-align:center;">
                                        <input id="btnScan" class="bigbutton" style="color:#C0C0C0;" disabled="disabled" type="button" value="Scan" onclick ="acquireImage();"/>&nbsp;&nbsp;<a id="showDetail"  style="display:none;" href="javascript: void(0)" class="ShowtblCanNotScan">Can't Scan</a></li>
                                </ul>
                            </div>
                        </li>
                          <li>
                            <div class="divType"><div class="mark_arrow collapsed"></div>Custom Webcam</div>
                            <div id="div_webcam" style="display: none" class="divTableStyle">
                                <ul id="ulWebcamHIDE" >
                                    <li style="padding-left: 15px;">
                                        <label for="source">Select Source:</label>
                                        <select size="1" id="webcamsource" style="position:relative;width: 220px;" onchange="source_onchange(true)"> 
                                        </select></li>
                                        <li id="divWebcamDetail"></li>
                                    <li style="text-align:center;">
                                        <input id="btnWebcam" class="bigbutton" style="color:#C0C0C0;" disabled="disabled" type="button" value="Grab" onclick ="acquireImageByWebcam();"/>&nbsp;&nbsp;<a id="A2"  style="display:none;" href="javascript: void(0)" class="ShowtblCanNotScan">Can't Scan</a></li>
                                </ul>
                            </div>
                        </li>
                    </ul>
                </div>
                
                <div id="tblLoadImage" style="visibility:hidden;height:80px">
                <ul>
                    <li><b>You can:</b><a href="javascript: void(0)" style="text-decoration:none; padding-left:200px" class="ClosetblLoadImage">X</a></li>
                </ul>
                <div id="notformac1" style="background-color:#f0f0f0; padding:5px;">
                <ul>
                    <li><img alt="arrow" src="Images/arrow.gif" width="9" height="12"/><b>Install a Virtual Scanner:</b></li>
                    <li style="text-align:center;"><a id="samplesource32bit" href="http://www.dynamsoft.com/demo/DWT/Sources/twainds.win32.installer.2.1.3.msi">32-bit Sample Source</a>
                        <a id="samplesource64bit" style="display:none;" href="http://www.dynamsoft.com/demo/DWT/Sources/twainds.win64.installer.2.1.3.msi">64-bit Sample Source</a>
                        from <a href="http://www.twain.org">TWG</a></li>
                </ul>
                </div>
                </div>
                    
                 <div id="div_BARCODE" class="divinput">               
                        <div style="font-weight: bold;font-size: 12px;  height: 25px;  cursor: pointer;"><div class="mark_arrow collapsed"></div>Read Barcode</div>
                        <ul>
                        <li  style="text-align: left">
                            <table class="tableStyle">
                                <tr>
                                    <td>
                                        Barcode Format:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 400px">
                                        <select id="ddl_barcodeFormat" style="width: 250px">
                                         </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;height:35px;">
                                        <input id="btnReadBarcode" type="button" value="Read Barcode" style="width: 130px; height:30px; font-size:medium; margin-top:5px;" onclick="btnScanReadBarcode_onclick()" />
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ul>
                </div>
                <div id="divNoteMessage"  >
                </div>
            </div>
<div id="DWTemessageContainer" style="float:left; margin-left:40px;width:580px"></div>
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
<script type="text/javascript" language="javascript" src="Resources/addon/dynamsoft.webtwain.addon.webcam.js?t=150418"></script>
<script type="text/javascript" language="javascript" src="Resources/addon/dynamsoft.webtwain.addon.barcode.js"> </script>
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
    var BarcodeInfo = 
    [
       { desc: "All", val: EnumDWT_BarcodeFormat.All },
       { desc: "1D Barcodes", val: EnumDWT_BarcodeFormat.OneD },
       { desc: "QR Code", val: EnumDWT_BarcodeFormat.QR_CODE },
       { desc: "PDF417", val: EnumDWT_BarcodeFormat. PDF417},
       { desc: "Data Matrix", val: EnumDWT_BarcodeFormat.DATAMATRIX },
       { desc: "CODE_39", val: EnumDWT_BarcodeFormat.CODE_39 },
       { desc: "CODE_128", val: EnumDWT_BarcodeFormat.CODE_128 },
       { desc: "CODE_93", val: EnumDWT_BarcodeFormat.CODE_93 },
       { desc: "CODABAR", val: EnumDWT_BarcodeFormat.CODABAR },
       { desc: "EAN_13", val: EnumDWT_BarcodeFormat.EAN_13 },
       { desc: "EAN_8", val: EnumDWT_BarcodeFormat.EAN_8 },
       { desc: "UPC_A", val: EnumDWT_BarcodeFormat.UPC_A },
       { desc: "UPC_E", val: EnumDWT_BarcodeFormat.UPC_E },
       { desc: "Interleaved 2 of 5", val: EnumDWT_BarcodeFormat.ITF },
       { desc: "Industrial 2 of 5", val: EnumDWT_BarcodeFormat.INDUSTRIAL_25 }
    ];
            
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

