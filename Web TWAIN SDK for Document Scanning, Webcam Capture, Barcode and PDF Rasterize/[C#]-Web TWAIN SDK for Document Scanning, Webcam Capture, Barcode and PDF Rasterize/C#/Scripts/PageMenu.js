var GetParameter = function() {
    var map = new Array();
    var tgs = document.getElementsByTagName('script');
    if (tgs.length <= 0) { return null; }
    var src = tgs.item(tgs.length - 1).src;
    var pos = src.indexOf('?');
    if (-1 == pos) { return null; }
    var paras = src.substring(pos + 1);
    paras = paras.split('&');
    for (var n = 0; n < paras.length; n++) {
        _ParseParameter(map, paras[n]);
    }
    return map;
};

var _ParseParameter = function(map, para) {
    var pos = para.indexOf('=');
    var key = para.substring(0, pos);
    var value = para.substring(pos + 1);
    map[key] = value;
};

var paras = GetParameter();
var paraValue = -1;
if (paras != null)
 paraValue = paras['Type'];

document.write('<div id="divmenu"><div id="menu"><ul>');
var ua = navigator.userAgent.toLowerCase();
var _platform = navigator.platform.toLowerCase();
var _bMac = (_platform == 'mac68k') || (_platform == 'macppc') || (_platform == 'macintosh') || (_platform == 'macintel');
var _indexOfChrome = ua.indexOf('chrome');
var _bChrome = _indexOfChrome != -1;
var _nFirefox = ua.indexOf('firefox');
var _bFirefox = _nFirefox != -1;
var _bSafari = ua.match(/version\/([\d.]+).*safari/);
var _tmp;
var _bPluginEdition = false;
if(_bChrome || _bFirefox){
		if(_bChrome){
			_tmp = ua.slice(_indexOfChrome + 7);
			_tmp = _tmp.slice(0, _tmp.indexOf(' '));
			_tmp = _tmp.slice(0, _tmp.indexOf('.'));
			if(_tmp < 27){
				_bPluginEdition = true;
			}
		} else {	// FF
			_tmp = ua.slice(_nFirefox + 8);
			_tmp = _tmp.slice(0, _tmp.indexOf(' '));
			_tmp = _tmp.slice(0, _tmp.indexOf('.'));
			if(_tmp < 27){
				_bPluginEdition = true;
			}
		}

	} 

if(_bMac || _bPluginEdition || _bSafari)
{	
    if (paraValue == 0)
		document.write('<li class="D_menu_item_select" style="width:204px"><div class="menubar_split"></div><a class="nohref" href="online_demo_scan.aspx">Document Scanning</a></li>');
	else
		document.write('<li class="D_menu_item" style="width:204px"><div class="menubar_split"></div><a class="nohref" href="online_demo_scan.aspx">Document Scanning</a></li>');
		
	if(paraValue == 1)
		document.write('<li class="D_menu_item_select" style="width:249px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Webcam.aspx">Webcam Capture</a></li>');
	else
		document.write('<li class="D_menu_item" style="width:249px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Webcam.aspx">Webcam Capture</a></li>');
	  
	if(paraValue == 2)  
		document.write('<li class="D_menu_item_select" style="width:248px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Barcode.aspx">Read Barcode</a></li>');
	else
		document.write('<li class="D_menu_item" style="width:248px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Barcode.aspx">Read Barcode</a></li>');
}
else
{
    if (paraValue == 0)
        document.write('<li class="D_menu_item_select" style="width:204px"><div class="menubar_split"></div><a class="nohref" href="online_demo_scan.aspx">Document Scanning</a></li>');
    else
        document.write('<li class="D_menu_item" style="width:204px"><div class="menubar_split"></div><a class="nohref" href="online_demo_scan.aspx">Document Scanning</a></li>');
        
    if(paraValue == 1)
        document.write('<li class="D_menu_item_select" style="width:166px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Webcam.aspx">Webcam Capture</a></li>');
    else
        document.write('<li class="D_menu_item" style="width:166px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Webcam.aspx">Webcam Capture</a></li>');
      
    if(paraValue == 2)  
        document.write('<li class="D_menu_item_select" style="width:166px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Barcode.aspx">Read Barcode</a></li>');
    else
        document.write('<li class="D_menu_item" style="width:166px"><div class="menubar_split" ></div><a class="nohref" href="online_demo_scan_Barcode.aspx">Read Barcode</a></li>');

    if(paraValue == 3)  
        document.write('<li class="D_menu_item_select" style="width:166px"><div class="menubar_split" ></div><a class="nohref" href="online_scan_pdf_rasterizer.aspx">PDF Rasterizer</a></li>');
    else
        document.write('<li class="D_menu_item" style="width:166px"><div class="menubar_split" ></div><a class="nohref" href="online_scan_pdf_rasterizer.aspx">PDF Rasterizer</a></li>');
}
document.write('<li class="D_menu_item dwt-link" style="width:283px;" title="Includes Source Code of Current Page"><div class="menubar_split" ></div><div class="menubar_split_last"></div><a class="nohref" target="_blank" href="http://www.dynamsoft.com/Products/WebTWAIN_Overview.aspx">About Dynamic Web TWAIN</a></li></ul></div></div>');


