/// <reference path="../Resources/dynamsoft.webtwain.intellisense.js" />
/// <reference path="../Resources/addon/dynamsoft.webtwain.addon.webcam.intellisense.js" />
/// <reference path="../Resources/addon/dynamsoft.webtwain.addon.barcode.intellisense.js" />

var _iLeft, _iTop, _iRight, _iBottom; //These variables are used to remember the selected area
            
function pageonload() {
   
    InitMessageBody();
    initMessageBox(false);  //Messagebox
    initCustomScan();       //CustomScan

    initiateInputs();
}

function pageonloadforWebcam() {
    
    InitMessageBody();
    initMessageBox(false);  //Messagebox
    initCustomScan();       //CustomScan

    initiateInputs(true);
}


function InitMessageBody() {

    var MessageBody = document.getElementById("divNoteMessage");
    if (MessageBody) {
        var ObjString = "<div class='divinput' style='line-height: 18px;background-color: #C1E5F0;border-radius: 4px;color: #30768D;'><b style='color: #1E586B;'>Note:</b> This online demo application uses JavaScript + ASP.NET (C#). If you use other server-side language (JSP, PHP, ASP.NET (VB.NET), ASP etc.), you can visit the ";
        ObjString += "<a href='http://www.dynamsoft.com/Downloads/WebTWAIN-Sample-Download.aspx' target='_blank' >sample gallery page";
        ObjString += "</a>";
        ObjString += ".</div>";

        MessageBody.style.display = "";
        MessageBody.innerHTML = ObjString;
    }
}

function initMessageBox(bNeebBack) {
    var objString = "";

    // The container for navigator, view mode and remove button
    objString += "<div style='text-align:center; width:580px; background-color:#FFFFFF;display:block'>";
    objString += "<div style='position:relative; background:white; float:left; width:422px; height:35px;'>";
    objString += "<input id='DW_btnFirstImage' onclick='btnFirstImage_onclick()' type='button' value=' |&lt; '/>&nbsp;";
    objString += "<input id='DW_btnPreImage' onclick='btnPreImage_onclick()' type='button' value=' &lt; '/>&nbsp;&nbsp;";
    objString += "<input type='text' size='2' id='DW_CurrentImage' readonly='readonly'/>/";
    objString += "<input type='text' size='2' id='DW_TotalImage' readonly='readonly'/>&nbsp;&nbsp;";
    objString += "<input id='DW_btnNextImage' onclick='btnNextImage_onclick()' type='button' value=' &gt; '/>&nbsp;";
    objString += "<input id='DW_btnLastImage' onclick='btnLastImage_onclick()' type='button' value=' &gt;| '/></div>";
    objString += "<div style='position:relative; background:white; float:left; width:150px; height:35px;'>Preview Mode";
    objString += "<select size='1' id='DW_PreviewMode' onchange ='setlPreviewMode();'>";
    objString += "    <option value='0'>1X1</option>";
    objString += "</select><br /></div>";
    objString += "<div><input id='DW_btnRemoveCurrentImage' onclick='btnRemoveCurrentImage_onclick()' type='button' value='Remove Selected Images'/>";
    if (bNeebBack) {
        objString += "<input id='DW_btnRemoveAllImages' onclick='btnRemoveAllImages_onclick()' type='button' value='Remove All Images'/><br /><br />";
        objString += "<span style=\"font-size:larger\"><a href =\"online_demo_list.aspx\"><b>Back</b></a></span><br /></div>";
    }
    else {
        objString += "<input id='DW_btnRemoveAllImages' onclick='btnRemoveAllImages_onclick()' type='button' value='Remove All Images'/><br /></div>";
    }
    objString += "</div>";

    // The container for the error message
    objString += "<div id='DWTdivMsg' style='width:580px;display:inline;'>";
    objString += "Message:<br/>"
    objString += "<div id='DWTemessage' style='width:560px; padding:30px 0 0 3px; height:80px; margin-top:5px; overflow:auto; background-color:#ffffff; border:1px #303030; border-style:solid; text-align:left; position:relative' >";
    objString += "</div></div>";

    var DWTemessageContainer = document.getElementById("DWTemessageContainer");
    DWTemessageContainer.innerHTML = objString;

    // Fill the init data for preview mode selection
    var varPreviewMode = document.getElementById("DW_PreviewMode");
    varPreviewMode.options.length = 0;
    varPreviewMode.options.add(new Option("1X1", 0));
    varPreviewMode.options.add(new Option("2X2", 1));
    varPreviewMode.options.add(new Option("3X3", 2));
    varPreviewMode.options.add(new Option("4X4", 3));
    varPreviewMode.options.add(new Option("5X5", 4));
    varPreviewMode.selectedIndex = 0;

    var _divMessageContainer = document.getElementById("DWTemessage");
    _divMessageContainer.ondblclick = function() {
        this.innerHTML = "";
        _strTempStr = "";
    }

}

function initCustomScan() {
    var ObjString = "";

     if (Dynamsoft.Lib.env.bWin)
        ObjString += "<ul id='divWebcamType' style='height:75px; background:#f0f0f0;'>";
    else
        ObjString += "<ul id='divWebcamType' style='height:20px; background:#f0f0f0;'>";
    ObjString += "<li style='padding-left:12px;'>";
    ObjString += "<label for = 'ShowUIForWebcam'><input type='checkbox' id='ShowUIForWebcam' />Show UI&nbsp;</label></li>";
    if (Dynamsoft.Lib.env.bWin) {
        ObjString += "<li style='padding-left:15px;'>";
        ObjString += "<label for='MediaType'>Media Type:<select size='1' id='MediaType'><option value = ''></option></select></label></li>";
        ObjString += "<li style='padding-left:15px;'>";
        ObjString += "<label for='Resolution'>Resolution:&nbsp;<select size='1' id='ResolutionWebcam'><option value = ''></option></select></label></li>";
    }
    ObjString += "</ul>";
    
    if (document.getElementById("divWebcamDetail"))
        document.getElementById("divWebcamDetail").innerHTML = ObjString;
    
    ObjString = "";
    ObjString += "<ul id='divTwainType' style='height:70px; background:#f0f0f0;'> ";
    ObjString += "<li style='padding-left:12px;'>";
    ObjString += "<label id ='lblShowUI' for = 'ShowUI'><input type='checkbox' id='ShowUI' />Show UI&nbsp;</label>";
    ObjString += "<label for = 'ADF'><input type='checkbox' id='ADF' />AutoFeeder&nbsp;</label>";
    ObjString += "<label for = 'Duplex'><input type='checkbox' id='Duplex'/>Duplex</label></li>";
    ObjString += "<li style='padding-left:15px;'>Pixel Type:";
    ObjString += "<label for='BW'><input type='radio' id='BW' name='PixelType'/>B&amp;W </label>";
    ObjString += "<label for='Gray'><input type='radio' id='Gray' name='PixelType'/>Gray</label>";
    ObjString += "<label for='RGB'><input type='radio' id='RGB' name='PixelType'/>Color</label></li>";
    ObjString += "<li style='padding-left:15px;'>";
    ObjString += "<label for='Resolution'>Resolution:<select size='1' id='Resolution'><option value = ''></option></select></label></li>";
    ObjString += "</ul>";
    
    if (document.getElementById("divProductDetail"))
        document.getElementById("divProductDetail").innerHTML = ObjString;
    
    var vResolution = document.getElementById("Resolution");
    if (vResolution) {
        vResolution.options.length = 0;
        vResolution.options.add(new Option("100", 100));
        vResolution.options.add(new Option("150", 150));
        vResolution.options.add(new Option("200", 200));
        vResolution.options.add(new Option("300", 300));

        vResolution.options[3].selected = true; 
    }
  
}

function initiateInputs(bWebcam) {

    var allinputs = document.getElementsByTagName("input");
    for (var i = 0; i < allinputs.length; i++) {
        if (allinputs[i].type == "checkbox") {
            allinputs[i].checked = false;
        }
        else if (allinputs[i].type == "text") {
            allinputs[i].value = "";
        }
    }

   /* if (!Dynamsoft.Lib.env.bWin) {
        document.getElementById("btnEditor").style.display = "none";
        document.getElementById("tblLoadImage").style.height = "170";
        document.getElementById("notformac1").style.display = "none";
    }
*/
    if(!bWebcam)
    {
        if (Dynamsoft.Lib.env.bIE == true && Dynamsoft.Lib.env.bWin64 == true) {
            document.getElementById("samplesource64bit").style.display = "inline";
            document.getElementById("samplesource32bit").style.display = "none";
        }
    }
    else
    {
        document.getElementById("samplesource64bit").style.display = "none";
        document.getElementById("samplesource32bit").style.display = "none";
    }
}



function initDllForChangeImageSize() {

    var vInterpolationMethod = document.getElementById("InterpolationMethod");
    vInterpolationMethod.options.length = 0;
    vInterpolationMethod.options.add(new Option("NearestNeighbor", 1));
    vInterpolationMethod.options.add(new Option("Bilinear", 2));
    vInterpolationMethod.options.add(new Option("Bicubic", 3));

}

function setDefaultValue() {
    var vGray = document.getElementById("Gray");
    if(vGray)
        vGray.checked = true;
 
    var varImgTypepng2 = document.getElementById("imgTypepng2");
    if (varImgTypepng2)
        varImgTypepng2.checked = true;
    var varImgTypepng = document.getElementById("imgTypepng");
    if (varImgTypepng)
        varImgTypepng.checked = true;

    var _strDefaultSaveImageName = "WebTWAINImage";
    var _txtFileNameforSave = document.getElementById("txt_fileNameforSave");
    if(_txtFileNameforSave)
        _txtFileNameforSave.value = _strDefaultSaveImageName;

    var _txtFileName = document.getElementById("txt_fileName");
    if(_txtFileName)
        _txtFileName.value = _strDefaultSaveImageName;

    var _chkMultiPageTIFF_save = document.getElementById("MultiPageTIFF_save");
    if(_chkMultiPageTIFF_save)
        _chkMultiPageTIFF_save.disabled = true;
    var _chkMultiPagePDF_save = document.getElementById("MultiPagePDF_save");
    if(_chkMultiPagePDF_save)
        _chkMultiPagePDF_save.disabled = true;
    var _chkMultiPageTIFF = document.getElementById("MultiPageTIFF");
    if(_chkMultiPageTIFF)
        _chkMultiPageTIFF.disabled = true;
    var _chkMultiPagePDF = document.getElementById("MultiPagePDF");
    if(_chkMultiPagePDF)
        _chkMultiPagePDF.disabled = true;
}


var DWObject;            // The DWT Object
// Check if the control is fully loaded.
function Dynamsoft_OnReady() {

    var liNoScanner = document.getElementById("pNoScanner");
    // If the ErrorCode is 0, it means everything is fine for the control. It is fully loaded.
    DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');  
    if (DWObject) {
        if (DWObject.ErrorCode == 0) {                
            DWObject.LogLevel = 0;
            DWObject.IfAllowLocalCache = true;
	        DWObject.ImageCaptureDriverType = 3;
            setDefaultValue();
            
            var twainsource = document.getElementById("source");
            var webcamsource = document.getElementById("webcamsource");
            if (!twainsource && !webcamsource)
                return;
            
            if(webcamsource)
            {
                var strhttp = "http:";
	            if("https:" == document.location.protocol) 
		        strhttp = "https:";
                DWObject.Addon.Webcam.Download(strhttp + "//www.dynamsoft.com/Demo/DWT/Resources/addon/Webcam.zip");           
            }
           
             var vCount = DWObject.SourceCount;
            if(vCount == 0 && Dynamsoft.Lib.env.bMac)
            {
                DWObject.CloseSourceManager();
                DWObject.ImageCaptureDriverType = 0;
                DWObject.OpenSourceManager();
                vCount = DWObject.SourceCount;
            }
          
            // If source list need to be displayed, fill in the source items.
            if (vCount == 0) {
                if(liNoScanner)
                {
                    if (Dynamsoft.Lib.env.bWin) {

                            liNoScanner.style.display = "block";
                            liNoScanner.style.textAlign = "center";
                    }
                    else
                        liNoScanner.style.display = "none";
                }
            }
            
            var vWebcamCount = 0;
            if(webcamsource)
            { 
                var arySource = DWObject.Addon.Webcam.GetSourceList();
                vWebcamCount = arySource.length;
                for (var i = 0; i < vWebcamCount; i++)
                    webcamsource.options.add(new Option(arySource[i], i)); // Get Webcam Source names and put them in a drop-down box
                    
//               webcamsource.options[0].selected = true; 
            }
            
            if(twainsource)
            {
                twainsource.options.length = 0;
                for (var i = 0; i < vCount; i++) {
                    twainsource.options.add(new Option(DWObject.GetSourceNameItems(i), i));
                }
            }

            if (vCount > 0) {
                source_onchange(false);
            } 
            
            if(vWebcamCount > 0)
            {
                source_onchange(true);
            }

            if (Dynamsoft.Lib.env.bWin)
                DWObject.MouseShape = false;

            var btnScan = document.getElementById("btnScan");
            if(btnScan)
            {
                if (vCount == 0)
                    document.getElementById("btnScan").disabled = true;
                else {
                    document.getElementById("btnScan").disabled = false;
                    document.getElementById("btnScan").style.color = "#FE8E14";
                }
            }
            
            var btnWebcam = document.getElementById("btnWebcam");
            if(btnWebcam)
            {
                if (vWebcamCount == 0)
                    document.getElementById("btnWebcam").disabled = true;
                else {
                    document.getElementById("btnWebcam").disabled = false;
                    document.getElementById("btnWebcam").style.color = "#FE8E14";
                }
            }

            if (!Dynamsoft.Lib.env.bWin && DWObject.ImageCaptureDriverType != 0) {
                if (document.getElementById("lblShowUI"))
                    document.getElementById("lblShowUI").style.display = "none";
                if (document.getElementById("ShowUI"))
                document.getElementById("ShowUI").style.display = "none";
            }
            else {
                if(document.getElementById("lblShowUI"))
                    document.getElementById("lblShowUI").style.display = "";
                if (document.getElementById("ShowUI"))
                    document.getElementById("ShowUI").style.display = "";
            }

            initDllForChangeImageSize();
            
            if(document.getElementById("ddl_barcodeFormat"))
            {
                 for (var index = 0; index < BarcodeInfo.length; index ++)
                    document.getElementById("ddl_barcodeFormat").options.add(new Option(BarcodeInfo[index].desc, index));
                 document.getElementById("ddl_barcodeFormat").selectedIndex = 0;
            }


            re = /^\d+$/;
            strre = /^[\s\w]+$/;
            refloat = /^\d+\.*\d*$/i;

            _iLeft = 0;
            _iTop = 0;
            _iRight = 0;
            _iBottom = 0;

            for (var i = 0; i < document.links.length; i++) {
                if (document.links[i].className == "ShowtblLoadImage") {
                    document.links[i].onclick = showtblLoadImage_onclick;
                }
                if (document.links[i].className == "ClosetblLoadImage") {
                    document.links[i].onclick = closetblLoadImage_onclick;
                }
            }
            if (vCount == 0) {
                if (Dynamsoft.Lib.env.bWin) {
                    if(document.getElementById("aNoScanner"))
                    {
                        document.getElementById("aNoScanner").style.color = "Red";
                        document.getElementById("aNoScanner").innerHTML = "<b>No TWAIN compatible drivers detected:<b/>";
                        if(document.getElementById("div_ScanImage").style.display == "")
                            showtblLoadImage_onclick();
                    }
                    if(document.getElementById("Resolution"))
                        document.getElementById("Resolution").style.display = "none";

                }

            }
            else
            {
                var divBlank = document.getElementById("divBlank");
                if(divBlank)
                    divBlank.style.display = "none";
            }

            updatePageInfo();
            ua = (navigator.userAgent.toLowerCase());
            if (!ua.indexOf("msie 6.0")) {
                ShowSiteTour();
            }

            DWObject.RegisterEvent("OnPostTransfer", Dynamsoft_OnPostTransfer);
            DWObject.RegisterEvent("OnPostLoad", Dynamsoft_OnPostLoadfunction);
            DWObject.RegisterEvent("OnPostAllTransfers", Dynamsoft_OnPostAllTransfers);
            DWObject.RegisterEvent("OnMouseClick", Dynamsoft_OnMouseClick);            
            DWObject.RegisterEvent("OnImageAreaSelected", Dynamsoft_OnImageAreaSelected);
            DWObject.RegisterEvent("OnImageAreaDeSelected", Dynamsoft_OnImageAreaDeselected);
            DWObject.RegisterEvent("OnTopImageInTheViewChanged", Dynamsoft_OnTopImageInTheViewChanged);
            DWObject.RegisterEvent("OnGetFilePath", Dynamsoft_OnGetFilePath);
            

        }
    }
}


function showtblLoadImage_onclick() {
    switch (document.getElementById("tblLoadImage").style.visibility) {
        case "hidden": document.getElementById("tblLoadImage").style.visibility = "visible";
            document.getElementById("Resolution").style.visibility = "hidden";
            break;
        case "visible":
            document.getElementById("tblLoadImage").style.visibility = "hidden";
            document.getElementById("Resolution").style.visibility = "visible";
            break;
        default: break;
    }
    if(document.getElementById("pNoScanner"))
    {
        document.getElementById("tblLoadImage").style.top = ds_gettop(document.getElementById("pNoScanner")) + pNoScanner.offsetHeight + "px";
        document.getElementById("tblLoadImage").style.left = ds_getleft(document.getElementById("pNoScanner")) + 0 + "px";
    }
    return false;
}

function closetblLoadImage_onclick() {
    document.getElementById("tblLoadImage").style.visibility = "hidden";
    document.getElementById("Resolution").style.visibility = "visible";
    return false;
}

//--------------------------------------------------------------------------------------
//************************** Used a lot *****************************
//--------------------------------------------------------------------------------------
function updatePageInfo() {
    if(document.getElementById("DW_TotalImage"))
        document.getElementById("DW_TotalImage").value = DWObject.HowManyImagesInBuffer;
    if(document.getElementById("DW_CurrentImage"))
        document.getElementById("DW_CurrentImage").value = DWObject.CurrentImageIndexInBuffer + 1;
}


var _strTempStr = "";       // Store the temp string for display
function appendMessage(strMessage) {
    _strTempStr += strMessage;
    var _divMessageContainer = document.getElementById("DWTemessage");
    if (_divMessageContainer) {
        _divMessageContainer.innerHTML = _strTempStr;
        _divMessageContainer.scrollTop = _divMessageContainer.scrollHeight;
    }
}

function checkIfImagesInBuffer() {
    if (DWObject.HowManyImagesInBuffer == 0) {
        appendMessage("There is no image in buffer.<br />")
        return false;
    }
    else
        return true;
}

function checkErrorString() {
    return checkErrorStringWithErrorCode(DWObject.ErrorCode, DWObject.ErrorString);
}

function checkErrorStringWithErrorCode(errorCode, errorString, responseString) {
    if (errorCode == 0) {
        appendMessage("<span style='color:#cE5E04'><b>" + errorString + "</b></span><br />");

        return true;
    }
    if (errorCode == -2115) //Cancel file dialog
        return true;
    else {
        if (errorCode == -2003) {
            var ErrorMessageWin = window.open("", "ErrorMessage", "height=500,width=750,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no");
            ErrorMessageWin.document.writeln(responseString); //DWObject.HTTPPostResponseString);
        }
        appendMessage("<span style='color:#cE5E04'><b>" + errorString + "</b></span><br />");
        return false;
    }
}


//--------------------------------------------------------------------------------------
//************************** Used a lot *****************************
//--------------------------------------------------------------------------------------
function ds_getleft(el) {
    var tmp = el.offsetLeft;
    el = el.offsetParent
    while (el) {
        tmp += el.offsetLeft;
        el = el.offsetParent;
    }
    return tmp;
}
function ds_gettop(el) {
    var tmp = el.offsetTop;
    el = el.offsetParent
    while (el) {
        tmp += el.offsetTop;
        el = el.offsetParent;
    }
    return tmp;
}

function Over_Out_DemoImage(obj, url) {
    obj.src = url;
}


window.onload = function() {
    document.onscroll = MouseScroll;
}

function MouseScroll(evt) {
    var mousewheelevt = (/Firefox/i.test(navigator.userAgent)) ? "DOMMouseScroll" : "mousewheel";
    if (document.attachEvent)
        document.attachEvent("on" + mousewheelevt, NavigateImages);
    else if (document.addEventListener);
    document.addEventListener(mousewheelevt, NavigateImages, false)
}

function NavigateImages(e) {
    evt = window.event || e;
    var delta = evt.detail ? evt.detail * (-120) : evt.wheelDelta;
    if (delta < 0)
        btnNextImage_wheel();
    else if (delta > 0)
        btnPreImage_wheel();
}

function stopWheel(evt) {
    if (!evt) { /* IE7, IE8, Chrome, Safari */
        evt = window.event;
    }
    if (evt.preventDefault) { /* Chrome, Safari, Firefox */
        var ret = evt.preventDefault();
    }
    evt.returnValue = false; /* IE7, IE8 */
}


