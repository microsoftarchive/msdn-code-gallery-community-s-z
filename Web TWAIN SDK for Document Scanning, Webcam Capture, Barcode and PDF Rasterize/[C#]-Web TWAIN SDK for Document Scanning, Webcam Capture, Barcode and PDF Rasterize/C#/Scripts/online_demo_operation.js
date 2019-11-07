/// <reference path="../Resources/dynamsoft.webtwain.intellisense.js" />
/// <reference path="../Resources/addon/dynamsoft.webtwain.addon.barcode.intellisense.js" />
/// <reference path="../Resources/addon/dynamsoft.webtwain.addon.webcam.intellisense.js" />
/// <reference path="../Resources/addon/dynamsoft.webtwain.addon.pdf.intellisense.js" />

//--------------------------------------------------------------------------------------
//************************** Import Image*****************************
//--------------------------------------------------------------------------------------
/*-----------------select source---------------------*/
function source_onchange(bWebcam) {
    if(bWebcam)
    {
         if (document.getElementById("divWebcamType"))
            document.getElementById("divWebcamType").style.display = "";
            
        DWObject.Addon.Webcam.SelectSource(document.getElementById("webcamsource").options[document.getElementById("webcamsource").selectedIndex].text);
       
       var countMediaType = -1;
       var countResolution = -1;
        var MediaType = document.getElementById("MediaType");
        if (MediaType) {
            MediaType.options.length = 0;
            var aryMediaType = DWObject.Addon.Webcam.GetMediaType();
            countMediaType = aryMediaType.GetCount();
            var i;
            var value;
            for (i = 0; i < countMediaType; i++) {
                value = aryMediaType.Get(i);
                MediaType.options.add(new Option(value, value));
            }
        }

        var ResolutionWebcam = document.getElementById("ResolutionWebcam");
        if (ResolutionWebcam) {
            ResolutionWebcam.options.length = 0;
            var aryResolution = DWObject.Addon.Webcam.GetResolution();
            countResolution = aryResolution.GetCount();
            for (i = 0; i < countResolution; i++) {
                value = aryResolution.Get(i);
                ResolutionWebcam.options.add(new Option(value, value));
            }
        }
        
        if(Dynamsoft.Lib.env.bWin)
        {
            if(countMediaType <=0 || countResolution <= 0)
            {
                appendMessage('<b>Webcam source is currently occupied by other program.</b>');
            }
        }
        
        DWObject.Addon.Webcam.CloseSource();
    }
    else
    {
        if (document.getElementById("divTwainType"))
            document.getElementById("divTwainType").style.display = "";

        if (document.getElementById("source"))
            DWObject.SelectSourceByIndex(document.getElementById("source").selectedIndex);
    }
}


/*-----------------Acquire Image---------------------*/

function acquireImageByWebcam()
{
    DWObject.Addon.Webcam.SelectSource(document.getElementById("webcamsource").options[document.getElementById("webcamsource").selectedIndex].text);
    var valueMediaType = "";
    var MediaType = document.getElementById("MediaType");
    if(MediaType && MediaType.options.length > 0)
    {
        valueMediaType = MediaType.options[MediaType.selectedIndex].text;
        if(valueMediaType != "")
            if(!DWObject.Addon.Webcam.SetMediaType(valueMediaType))
            {
        	    appendMessage('<b>Error setting MediaType value: </b>');
		        appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
            }
    }

    var valueResolution = "";
    var ResolutionWebcam = document.getElementById("ResolutionWebcam");
    if(ResolutionWebcam && ResolutionWebcam.options.length > 0)
    {
        valueResolution = ResolutionWebcam.options[ResolutionWebcam.selectedIndex].text;
        if(valueResolution != "")
        DWObject.Addon.Webcam.SetResolution(valueResolution);
        var aryResolution = DWObject.Addon.Webcam.GetResolution();
        if(valueResolution != aryResolution.GetCurrent())
        {
    	    appendMessage('<b>Error setting Resolution value: </b>');
		    appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
        }
    }
    
    var showUI = document.getElementById("ShowUIForWebcam").checked;

    // optional
    var OnCaptureStart = function () {
    }
    // optional
    var OnCaptureSuccess = function () {
    }
    // optional
    var OnCaptureError = function (error, errorstr) {
        alert(errorstr);
    }
    // optional
    var OnCaptureEnd = function () {
        //Call DWObject.Addon.Webcam.CloseSource() to release webcam.
        DWObject.Addon.Webcam.CloseSource();
        updatePageInfo();
    }

    DWObject.Addon.Webcam.CaptureImage(showUI, OnCaptureStart, OnCaptureSuccess, OnCaptureError, OnCaptureEnd);
    
}

function acquireImage()
{
    DWObject.SelectSourceByIndex(document.getElementById("source").selectedIndex);
    DWObject.CloseSource();
    DWObject.OpenSource();
    DWObject.IfShowUI = document.getElementById("ShowUI").checked;

    var i;
    for (i = 0; i < 3; i++) {
        if (document.getElementsByName("PixelType").item(i).checked == true)
            DWObject.PixelType = i;
    }
	if(DWObject.ErrorCode != 0)
	{
		appendMessage('<b>Error setting PixelType value: </b>');
		appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
	}
    DWObject.Resolution = document.getElementById("Resolution").value;
	if(DWObject.ErrorCode != 0)
	{
		appendMessage('<b>Error setting Resolution value: </b>');
		appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
	}
	
	var bADFChecked = document.getElementById("ADF").checked;
    DWObject.IfFeederEnabled = bADFChecked;
	if(bADFChecked == true && DWObject.ErrorCode != 0)
	{
		appendMessage('<b>Error setting ADF value: </b>');
		appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
	}
	
	var bDuplexChecked = document.getElementById("Duplex").checked;
    DWObject.IfDuplexEnabled = bDuplexChecked;
	if(bDuplexChecked == true && DWObject.ErrorCode != 0)
	{
		appendMessage('<b>Error setting Duplex value: </b>');
		appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
	}
    if (Dynamsoft.Lib.env.bWin || (!Dynamsoft.Lib.env.bWin && DWObject.ImageCaptureDriverType == 0))
        appendMessage("Pixel Type: " + DWObject.PixelType + "<br />Resolution: " + DWObject.Resolution + "<br />");
    DWObject.IfDisableSourceAfterAcquire = true;
    DWObject.AcquireImage();
}

/*-----------------Load Image---------------------*/
function btnLoad_onclick() {
    var OnSuccess = function() {
        appendMessage("Loaded an image successfully.<br/>");
        updatePageInfo();
    };

    var OnFailure = function(errorCode, errorString) {
        checkErrorStringWithErrorCode(errorCode, errorString);
    };
    
    DWObject.IfShowFileDialog = true;
    DWObject.LoadImageEx("", EnumDWT_ImageType.IT_ALL, OnSuccess, OnFailure);
}

function btnLoadPDF_onclick() {     
      var OnPDFSuccess = function() {
            appendMessage("Loaded an image successfully.<br/>");
            updatePageInfo();
      };

      var OnPDFFailure = function(errorCode, errorString) {
            checkErrorStringWithErrorCode(errorCode, errorString);
      };
        
     
     var OnSuccess = function () {  
        DWObject.IfShowFileDialog = true;
        DWObject.Addon.PDF.SetResolution(300);
        DWObject.Addon.PDF.SetConvertMode(EnumDWT_ConverMode.CM_RENDERALL);
        DWObject.LoadImageEx("", EnumDWT_ImageType.IT_PDF, OnPDFSuccess, OnPDFFailure);

    };

    var OnFailure = function(errorCode, errorString) {
        appendMessage(errorString);
    };

    var strhttp = "http:";
	if("https:" == document.location.protocol) 
		strhttp = "https:";

    if(Dynamsoft.Lib.env.bMac)
    {
        DWObject.IfShowFileDialog = true;
        DWObject.Addon.PDF.SetResolution(300);
        DWObject.Addon.PDF.SetConvertMode(EnumDWT_ConverMode.CM_RENDERALL);
        DWObject.LoadImageEx("", EnumDWT_ImageType.IT_PDF, OnPDFSuccess, OnPDFFailure);
    }
    else
    {
        DWObject.Addon.PDF.Download(strhttp + "//www.dynamsoft.com/Demo/DWT/Resources/addon/Pdf.zip", OnSuccess, OnFailure); 
    }  
   }

function loadSampleImage(nIndex) {
    var ImgArr;

    switch (nIndex) {
        case 1:
            ImgArr = "/Images/twain_associate1.png";
            break;
        case 2:
            ImgArr = "/Images/twain_associate2.png";
            break;
        case 3:
            ImgArr = "/Images/twain_associate3.png";
            break;
    }

    if (location.hostname != '') {

        var OnSuccess = function() {
            appendMessage('Loaded a demo image successfully. (Http Download)<br/>');
            updatePageInfo();
        };

        var OnFailure = function(errorCode, errorString) {
            checkErrorStringWithErrorCode(errorCode, errorString);
        };
        
        DWObject.IfSSL = DynamLib.detect.ssl;
        var _strPort = location.port == "" ? 80 : location.port;
        if (DynamLib.detect.ssl == true)
            _strPort = location.port == "" ? 443 : location.port;
        DWObject.HTTPPort = _strPort;

        DWObject.HTTPDownload(location.hostname, DynamLib.getRealPath(ImgArr), OnSuccess, OnFailure);
    }
    else {
        var OnSuccess = function() {
            DWObject.IfShowFileDialog = true;

            appendMessage('Loaded a demo image successfully.');
            updatePageInfo();
        };

        var OnFailure = function(errorCode, errorString) {
            DWObject.IfShowFileDialog = true;
            checkErrorStringWithErrorCode(errorCode, errorString);
        };
        
        DWObject.IfShowFileDialog = false;
        DWObject.LoadImage(DynamLib.getRealPath(ImgArr), OnSuccess, OnFailure);
    }
}

//--------------------------------------------------------------------------------------
//************************** Edit Image ******************************

//--------------------------------------------------------------------------------------
function btnShowImageEditor_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.ShowImageEditor();
}

function btnRotateRight_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RotateRight(DWObject.CurrentImageIndexInBuffer);
    appendMessage('<b>Rotate right: </b>');
    if (checkErrorString()) {
        return;
    }
}
function btnRotateLeft_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RotateLeft(DWObject.CurrentImageIndexInBuffer);
    appendMessage('<b>Rotate left: </b>');
    if (checkErrorString()) {
        return;
    }
}

function btnRotate180_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.Rotate(DWObject.CurrentImageIndexInBuffer, 180, true);
    appendMessage('<b>Rotate 180: </b>');
    if (checkErrorString()) {
        return;
    }
}

function btnMirror_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.Mirror(DWObject.CurrentImageIndexInBuffer);
    appendMessage('<b>Mirror: </b>');
    if (checkErrorString()) {
        return;
    }
}
function btnFlip_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.Flip(DWObject.CurrentImageIndexInBuffer);
    appendMessage('<b>Flip: </b>');
    if (checkErrorString()) {
        return;
    }
}

/*----------------------Crop Method---------------------*/
function btnCrop_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    if (_iLeft != 0 || _iTop != 0 || _iRight != 0 || _iBottom != 0) {
        DWObject.Crop(
            DWObject.CurrentImageIndexInBuffer,
            _iLeft, _iTop, _iRight, _iBottom
        );
        _iLeft = 0;
        _iTop = 0;
        _iRight = 0;
        _iBottom = 0;
        appendMessage('<b>Crop: </b>');
        if (checkErrorString()) {
            return;
        }
        return;
    } else {
    appendMessage("<b>Crop: </b>failed. Please first select the area you'd like to crop.<br />");
    }
}
/*----------------Change Image Size--------------------*/
function btnChangeImageSize_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    switch (document.getElementById("ImgSizeEditor").style.visibility) {
        case "visible": document.getElementById("ImgSizeEditor").style.visibility = "hidden"; break;
        case "hidden": document.getElementById("ImgSizeEditor").style.visibility = "visible"; break;
        default: break;
    }
    document.getElementById("ImgSizeEditor").style.top = ds_gettop(document.getElementById("btnChangeImageSize")) + document.getElementById("btnChangeImageSize").offsetHeight + "px";
    document.getElementById("ImgSizeEditor").style.left = ds_getleft(document.getElementById("btnChangeImageSize")) - 30 + "px";

    var iWidth = DWObject.GetImageWidth(DWObject.CurrentImageIndexInBuffer);
    if (iWidth != -1)
        document.getElementById("img_width").value = iWidth;
    var iHeight = DWObject.GetImageHeight(DWObject.CurrentImageIndexInBuffer);
    if (iHeight != -1)
        document.getElementById("img_height").value = iHeight;
}
function btnCancelChange_onclick() {
    document.getElementById("ImgSizeEditor").style.visibility = "hidden";
}

function btnChangeImageSizeOK_onclick() {
    document.getElementById("img_height").className = "";
    document.getElementById("img_width").className = "";
    if (!re.test(document.getElementById("img_height").value)) {
        document.getElementById("img_height").className += " invalid";
        document.getElementById("img_height").focus();
        appendMessage("Please input a valid <b>height</b>.<br />");
        return;
    }
    if (!re.test(document.getElementById("img_width").value)) {
        document.getElementById("img_width").className += " invalid";
        document.getElementById("img_width").focus();
        appendMessage("Please input a valid <b>width</b>.<br />");
        return;
    }
    DWObject.ChangeImageSize(
        DWObject.CurrentImageIndexInBuffer,
        document.getElementById("img_width").value,
        document.getElementById("img_height").value,
        document.getElementById("InterpolationMethod").selectedIndex + 1
    );
    appendMessage('<b>Change Image Size: </b>');
    if (checkErrorString()) {
        document.getElementById("ImgSizeEditor").style.visibility = "hidden";
        return;
    }
}
//--------------------------------------------------------------------------------------
//************************** Save Image***********************************
//--------------------------------------------------------------------------------------
function btnSave_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    var i, strimgType_save;
    var NM_imgType_save = document.getElementsByName("imgType_save");
    for (i = 0; i < 5; i++) {
        if (NM_imgType_save.item(i).checked == true) {
            strimgType_save = NM_imgType_save.item(i).value;
            break;
        }
    }
    DWObject.IfShowFileDialog = true;
    var _txtFileNameforSave = document.getElementById("txt_fileNameforSave");
    if(_txtFileNameforSave)
        _txtFileNameforSave.className = "";
    var bSave = false;

    var strFilePath = _txtFileNameforSave.value + "." + strimgType_save;

    var OnSuccess = function() {
        appendMessage('<b>Save Image: </b>');
        checkErrorStringWithErrorCode(0, "Successful.");
    };

    var OnFailure = function(errorCode, errorString) {
        checkErrorStringWithErrorCode(errorCode, errorString);
    };

    var _chkMultiPageTIFF_save = document.getElementById("MultiPageTIFF_save");
    var vAsyn = false;
    if (strimgType_save == "tif" && _chkMultiPageTIFF_save && _chkMultiPageTIFF_save.checked) {
        vAsyn = true;
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            bSave = DWObject.SaveAllAsMultiPageTIFF(strFilePath, OnSuccess, OnFailure);
        }
        else {
            bSave = DWObject.SaveSelectedImagesAsMultiPageTIFF(strFilePath, OnSuccess, OnFailure);
        }
    }
    else if (strimgType_save == "pdf" && document.getElementById("MultiPagePDF_save").checked) {
        vAsyn = true;
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            bSave = DWObject.SaveAllAsPDF(strFilePath, OnSuccess, OnFailure);
        }
        else {
            bSave = DWObject.SaveSelectedImagesAsMultiPagePDF(strFilePath, OnSuccess, OnFailure);
        }
    }
    else {
        switch (i) {
            case 0: bSave = DWObject.SaveAsBMP(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 1: bSave = DWObject.SaveAsJPEG(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 2: bSave = DWObject.SaveAsTIFF(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 3: bSave = DWObject.SaveAsPNG(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 4: bSave = DWObject.SaveAsPDF(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
        }
    }

    if (vAsyn == false) {
        if (bSave)
            appendMessage('<b>Save Image: </b>');
        if (checkErrorString()) {
            return;
        }
    }
}
//--------------------------------------------------------------------------------------
//************************** Upload Image***********************************
//--------------------------------------------------------------------------------------
function btnUpload_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    var i, strHTTPServer, strActionPage, strImageType;

    var _txtFileName = document.getElementById("txt_fileName");
    if(_txtFileName)
        _txtFileName.className = "";
  
    //DWObject.MaxInternetTransferThreads = 5;
    strHTTPServer = location.hostname;
    DWObject.IfSSL = DynamLib.detect.ssl;
    var _strPort = location.port == "" ? 80 : location.port;
    if (DynamLib.detect.ssl == true)
        _strPort = location.port == "" ? 443 : location.port;
    DWObject.HTTPPort = _strPort;
    
    
    var CurrentPathName = unescape(location.pathname); // get current PathName in plain ASCII	
    var CurrentPath = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1);
    strActionPage = CurrentPath + "SaveToFile.aspx"; //the ActionPage's file path , Online Demo:"SaveToDB.aspx" ;Sample: "SaveToFile.aspx";
    var redirectURLifOK = CurrentPath + "online_demo_list.aspx";
    for (i = 0; i < 4; i++) {
        if (document.getElementsByName("ImageType").item(i).checked == true) {
            strImageType = i + 1;
            break;
        }
    }

	var fileName = _txtFileName.value;
	var replaceStr = "<";
	fileName = fileName.replace(new RegExp(replaceStr,'gm'),'&lt;');
    var uploadfilename = fileName + "." + document.getElementsByName("ImageType").item(i).value;

    var OnSuccess = function(httpResponse) {
        appendMessage('<b>Upload: </b>');
        checkErrorStringWithErrorCode(0, "Successful.");
        if (strActionPage.indexOf("SaveToFile") != -1) {
            alert("Successful")//if save to file.
        } else {
            window.location.href = redirectURLifOK;
        }
    };

    var OnFailure = function(errorCode, errorString, httpResponse) {
        checkErrorStringWithErrorCode(errorCode, errorString, httpResponse);
    };
    
    if (strImageType == 2 && document.getElementById("MultiPageTIFF").checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            DWObject.HTTPUploadAllThroughPostAsMultiPageTIFF(
                strHTTPServer,
                strActionPage,
                uploadfilename,
                OnSuccess, OnFailure
            );
        }
        else {
            DWObject.HTTPUploadThroughPostAsMultiPageTIFF(
                strHTTPServer,
                strActionPage,
                uploadfilename,
                OnSuccess, OnFailure
            );
        }
    }
    else if (strImageType == 4 && document.getElementById("MultiPagePDF").checked) {
    if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            DWObject.HTTPUploadAllThroughPostAsPDF(
                strHTTPServer,
                strActionPage,
                uploadfilename,
                OnSuccess, OnFailure
            );
        }
        else {
            DWObject.HTTPUploadThroughPostAsMultiPagePDF(
                strHTTPServer,
                strActionPage,
                uploadfilename,
                OnSuccess, OnFailure
            );
        }
    }
    else {
        DWObject.HTTPUploadThroughPostEx(
            strHTTPServer,
            DWObject.CurrentImageIndexInBuffer,
            strActionPage,
            uploadfilename,
            strImageType,
            OnSuccess, OnFailure
        );
    }
}

//--------------------------------------------------------------------------------------
//************************** Navigator functions***********************************
//--------------------------------------------------------------------------------------

function btnFirstImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = 0;
    updatePageInfo();
}

function btnPreImage_wheel() {
    if (DWObject.HowManyImagesInBuffer != 0)
        btnPreImage_onclick()
}

function btnNextImage_wheel() {
    if (DWObject.HowManyImagesInBuffer != 0)
        btnNextImage_onclick()
}

function btnPreImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    else if (DWObject.CurrentImageIndexInBuffer == 0) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = DWObject.CurrentImageIndexInBuffer - 1;
    updatePageInfo();
}
function btnNextImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    else if (DWObject.CurrentImageIndexInBuffer == DWObject.HowManyImagesInBuffer - 1) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = DWObject.CurrentImageIndexInBuffer + 1;
    updatePageInfo();
}


function btnLastImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = DWObject.HowManyImagesInBuffer - 1;
    updatePageInfo();
}

function btnRemoveCurrentImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RemoveAllSelectedImages();
    if (DWObject.HowManyImagesInBuffer == 0) {
        document.getElementById("DW_TotalImage").value = DWObject.HowManyImagesInBuffer;
        document.getElementById("DW_CurrentImage").value = "";
        return;
    }
    else {
        updatePageInfo();
    }
}


function btnRemoveAllImages_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RemoveAllImages();
    document.getElementById("DW_TotalImage").value = "0";
    document.getElementById("DW_CurrentImage").value = "";
}
function setlPreviewMode() {
    var varNum = parseInt(document.getElementById("DW_PreviewMode").selectedIndex + 1);
    var btnCrop = document.getElementById("btnCrop");
    if (btnCrop) {
        var tmpstr = btnCrop.src;
        if (varNum > 1) {
            tmpstr = tmpstr.replace('Crop.', 'Crop_gray.');
            btnCrop.src = tmpstr;
            btnCrop.onclick = function() { };
        }
        else {
            tmpstr = tmpstr.replace('Crop_gray.', 'Crop.');
            btnCrop.src = tmpstr;
            btnCrop.onclick = function() { btnCrop_onclick(); };
        }
    }

    DWObject.SetViewMode(varNum, varNum);
    if (Dynamsoft.Lib.env.bMac) {
        return;
    }
    else if (document.getElementById("DW_PreviewMode").selectedIndex != 0) {
        DWObject.MouseShape = true;
    }
    else {
        DWObject.MouseShape = false;
    }
}

//--------------------------------------------------------------------------------------
//*********************************radio response***************************************
//--------------------------------------------------------------------------------------
function rdTIFFsave_onclick() {
    var _chkMultiPageTIFF_save = document.getElementById("MultiPageTIFF_save");
    if(_chkMultiPageTIFF_save)
    {
        _chkMultiPageTIFF_save.disabled = false;
        _chkMultiPageTIFF_save.checked = false;
    }

    var _chkMultiPagePDF_save = document.getElementById("MultiPagePDF_save");
    _chkMultiPagePDF_save.checked = false;
    _chkMultiPagePDF_save.disabled = true;
}
function rdPDFsave_onclick() {
    var _chkMultiPageTIFF_save = document.getElementById("MultiPageTIFF_save");
    _chkMultiPageTIFF_save.checked = false;
    _chkMultiPageTIFF_save.disabled = true;

    var _chkMultiPagePDF_save = document.getElementById("MultiPagePDF_save");
    if(_chkMultiPageTIFF_save)
    {
        _chkMultiPagePDF_save.disabled = false;
        _chkMultiPagePDF_save.checked = false;
    }
}
function rdsave_onclick() {
    var _chkMultiPageTIFF_save = document.getElementById("MultiPageTIFF_save");
    if(_chkMultiPageTIFF_save)
    {
        _chkMultiPageTIFF_save.checked = false;
        _chkMultiPageTIFF_save.disabled = true;
    }

    var _chkMultiPagePDF_save = document.getElementById("MultiPagePDF_save");
    _chkMultiPagePDF_save.checked = false;
    _chkMultiPagePDF_save.disabled = true;
}
function rdTIFF_onclick() {
    var _chkMultiPageTIFF = document.getElementById("MultiPageTIFF");
    _chkMultiPageTIFF.disabled = false;
    _chkMultiPageTIFF.checked = false;

    var _chkMultiPagePDF = document.getElementById("MultiPagePDF");
    _chkMultiPagePDF.checked = false;
    _chkMultiPagePDF.disabled = true;
}
function rdPDF_onclick() {
    var _chkMultiPageTIFF = document.getElementById("MultiPageTIFF");
    _chkMultiPageTIFF.checked = false;
    _chkMultiPageTIFF.disabled = true;
    
    var _chkMultiPagePDF = document.getElementById("MultiPagePDF");
    _chkMultiPagePDF.disabled = false;
    _chkMultiPagePDF.checked = false;

}
function rd_onclick() {
    var _chkMultiPageTIFF = document.getElementById("MultiPageTIFF");
    _chkMultiPageTIFF.checked = false;
    _chkMultiPageTIFF.disabled = true;
    
    var _chkMultiPagePDF = document.getElementById("MultiPagePDF");
    _chkMultiPagePDF.checked = false;
    _chkMultiPagePDF.disabled = true;
}



//--------------------------------------------------------------------------------------
//************************** Dynamic Web TWAIN Events***********************************
//--------------------------------------------------------------------------------------

function Dynamsoft_OnPostTransfer() {
    updatePageInfo();
}

function Dynamsoft_OnPostLoadfunction(path, name, type) {
    updatePageInfo();
}

function Dynamsoft_OnPostAllTransfers() {
	DWObject.CloseSource();
    updatePageInfo();
    checkErrorString();
}

function Dynamsoft_OnMouseClick(index) {
    updatePageInfo();
}

function Dynamsoft_OnMouseRightClick(index) {
    // To add
}


function Dynamsoft_OnImageAreaSelected(index, left, top, right, bottom) {
    _iLeft = left;
    _iTop = top;
    _iRight = right;
    _iBottom = bottom;
}

function Dynamsoft_OnImageAreaDeselected(index) {
    _iLeft = 0;
    _iTop = 0;
    _iRight = 0;
    _iBottom = 0;
}

function Dynamsoft_OnMouseDoubleClick() {
    return;
}


function Dynamsoft_OnTopImageInTheViewChanged(index) {
    _iLeft = 0;
    _iTop = 0;
    _iRight = 0;
    _iBottom = 0;
    DWObject.CurrentImageIndexInBuffer = index;
    updatePageInfo();
}

function Dynamsoft_OnGetFilePath(bSave, count, index, path, name) {

}

//--------------------------------------------------------------------------------------
//************************** Barcode Addon***********************************
//--------------------------------------------------------------------------------------
function LoadBarcodeDemoImage(nIndex) {
    var ImgArr;

    switch (nIndex) {
        case 1:
            ImgArr = "/Images/code-39.png";
            break;
        case 2:
            ImgArr = "/Images/code-128.png";
            break;
        case 3:
            ImgArr = "/Images/qrcode.png";
            break;
        case 4:
            ImgArr = "/Images/UPC-A.png";
            break;
    }
    
   if (location.hostname != '') {

        var OnSuccess = function() {
            appendMessage('Loaded a demo image successfully. (Http Download)<br/>');
            updatePageInfo();
        };

        var OnFailure = function(errorCode, errorString) {
            checkErrorStringWithErrorCode(errorCode, errorString);
        };
        
        DWObject.IfSSL = DynamLib.detect.ssl;
        var _strPort = location.port == "" ? 80 : location.port;
        if (DynamLib.detect.ssl == true)
            _strPort = location.port == "" ? 443 : location.port;
        DWObject.HTTPPort = _strPort;

        DWObject.HTTPDownload(location.hostname, DynamLib.getRealPath(ImgArr), OnSuccess, OnFailure);
    }
    else {
        var OnSuccess = function() {
            DWObject.IfShowFileDialog = true;

            appendMessage('Loaded a demo image successfully.');
            updatePageInfo();
        };

        var OnFailure = function(errorCode, errorString) {
            DWObject.IfShowFileDialog = true;
            checkErrorStringWithErrorCode(errorCode, errorString);
        };
        
        DWObject.IfShowFileDialog = false;
        DWObject.LoadImage(DynamLib.getRealPath(ImgArr), OnSuccess, OnFailure);
    }
}

function GetBacodeFormatDesc(format)
{
    for (var index = 0; index < BarcodeInfo.length; index ++)
    {
        if (BarcodeInfo[index].val == format)
            return BarcodeInfo[index].desc;
    }

    return "UNKNOWN";
}

function GetBarcodeInfo(sImageIndex, result) {//This is the function called when barcode is read successfully
    //Retrieve barcode details
    var count = result.GetCount();
     appendMessage('BarcodeCount: ' + count + '<br/>');
    if (count == 0) {
        alert("The barcode for the selected format is not found.");
        return;
    } else {
        for (i = 0; i < count; i++) {
            var text = result.GetContent(i);
            var x = result.GetX1(i);
            var y = result.GetY1(i);
            var format = result.GetFormat(i);
            var barcodeText = ("barcode[" + (i + 1) + "]: " + text + "<br/>");
            barcodeText += ("format:" + GetBacodeFormatDesc(format) + "<br/>");
            barcodeText += ("x: " + x + " y:" + y + "<br/>");
            appendMessage(barcodeText);
            
            var strBarcodeString = text + "\r\n" + GetBacodeFormatDesc(format);
            DWObject.AddText(DWObject.CurrentImageIndexInBuffer, x, y, strBarcodeString, 255, 4894463, 0, 1);
        }
    }
}

function GetErrorInfo (errorcode, errorstring) {//This is the function called when barcode reading fails
    alert(errorstring);
}
        
function btnScanReadBarcode_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    
     var OnSuccess = function () {
         //Get barcode result.
        DWObject.Addon.Barcode.Read(DWObject.CurrentImageIndexInBuffer, 
        BarcodeInfo[document.getElementById("ddl_barcodeFormat").selectedIndex].val, GetBarcodeInfo, GetErrorInfo);
    };

    var OnFailure = function(errorCode, errorString) {
        appendMessage(errorString);
    };

    var strhttp = "http:";
	if("https:" == document.location.protocol) 
		strhttp = "https:";

    if(Dynamsoft.Lib.env.bMac)
        DWObject.Addon.Barcode.Download(strhttp + "//www.dynamsoft.com/Demo/DWT/Resources/addon/MacBarcode.zip", OnSuccess, OnFailure);  
    else
    {
        DWObject.Addon.Barcode.Download(strhttp + "//www.dynamsoft.com/Demo/DWT/Resources/addon/Barcode.zip", OnSuccess, OnFailure); 
    }  
}
