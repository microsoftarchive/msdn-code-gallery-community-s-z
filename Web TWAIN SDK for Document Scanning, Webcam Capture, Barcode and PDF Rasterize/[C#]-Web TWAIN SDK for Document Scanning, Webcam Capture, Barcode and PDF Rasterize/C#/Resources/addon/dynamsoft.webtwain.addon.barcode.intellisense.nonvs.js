/*!
* Dynamsoft JavaScript Library
/*!
* Dynamsoft WebTwain Addon Barcode JavaScript Intellisense
* Product: Dynamsoft Web Twain Addon
* Web Site: http://www.dynamsoft.com
*
* Copyright 2016, Dynamsoft Corporation 
* Author: Dynamsoft Support Team
* Version: 11.3.2
*/

/** this barcode format is different with twain defined */
var EnumDWT_BarcodeFormat = {
	All: 183806,
	OneD : 180702, 
	CODABAR: 2,   
    CODE_39: 4,
	CODE_93: 8,   
    CODE_128: 16,
	EAN_8: 64,
	EAN_13: 128,
	ITF: 256,
	UPC_A: 16384,
	UPC_E: 32768,
	INDUSTRIAL_25: 131072,
	QR_CODE: 2048,
	PDF417: 1024,
	DATAMATRIX: 32
};

var Barcode = {};
WebTwainAddon.Barcode = Barcode;

/**
 *  Download and install barcode add-on on the local system. 
 * @method Dynamsoft.WebTwain#Download 
 * @param {string} remoteFile specifies the value of which frame to get.
 * @param {function} optionalAsyncSuccessFunc optional. The function to call when the download succeeds. Please refer to the function prototype OnSuccess.
 * @param {function} optionalAsyncFailureFunc optional. The function to call when the download fails. Please refer to the function prototype OnFailure.
 * @return {bool}
 */
Barcode.Download = function(remoteFile, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
};

/**
 *  Read barcode on a specified image loaded in Dynamic Web TWAIN. 
 * @method Dynamsoft.WebTwain#Read 
 * @param {short} sImageIndex Specifies the index of the image.
 * @param {EnumDWT_BarcodeFormat} format Specifies the barcode format.
 * @param {function} optionalAsyncSuccessFunc optional. The function to call when barcode reading succeeds. Please refer to the function prototype OnBarcodeReadSuccess.
 * @param {function} optionalAsyncFailureFunc optional. The function to call when barcode reading fails. Please refer to the function prototype OnBarcodeReadFailure.
 * @return {bool}
 */
Barcode.Read = function(sImageIndex, format, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
};

/**
 *  Read barcode on a specified image loaded in Dynamic Web TWAIN. 
 * @method Dynamsoft.WebTwain#ReadRect 
 * @param {short} sImageIndex Specifies the index of the image.
 * @param {int} left specifies the x-coordinate of the upper-left corner of the rectangle.
 * @param {int} top specifies the y-coordinate of the upper-left corner of the rectangle.
 * @param {int} right specifies the x-coordinate of the lower-right corner of the rectangle.
 * @param {int} bottom specifies the y-coordinate of the lower-right corner of the rectangle.
 * @param {EnumDWT_BarcodeFormat} format Specifies the barcode format.
 * @param {function} optionalAsyncSuccessFunc optional. The function to call when barcode reading succeeds. Please refer to the function prototype OnBarcodeReadSuccess.
 * @param {function} optionalAsyncFailureFunc optional. The function to call when barcode reading fails. Please refer to the function prototype OnBarcodeReadFailure.
 * @return {bool}
 */
Barcode.ReadRect = function(sImageIndex, left, top, right, bottom, format, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
};



