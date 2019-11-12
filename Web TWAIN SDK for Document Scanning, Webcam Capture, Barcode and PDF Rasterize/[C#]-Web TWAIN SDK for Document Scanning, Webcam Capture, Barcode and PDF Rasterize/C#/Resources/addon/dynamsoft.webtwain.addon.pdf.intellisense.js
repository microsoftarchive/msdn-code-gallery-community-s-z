/*!
* Dynamsoft JavaScript Library
/*!
* Dynamsoft WebTwain Addon PDF JavaScript Intellisense
* Product: Dynamsoft Web Twain Addon
* Web Site: http://www.dynamsoft.com
*
* Copyright 2016, Dynamsoft Corporation 
* Author: Dynamsoft Support Team
* Version: 11.3
*/

var EnumDWT_ConverMode = {
	CM_DEFAULT: 0,
	CM_RENDERALL : 1, 
	CM_AUTO : 2
};

var PDF = {};
WebTwainAddon.PDF = PDF;

PDF.Download = function(remoteFile, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
    /// <summary> Download and install pdf rasterizer add-on on the local system. </summary>
    /// <param name="remoteFile" type="string">specifies the value of which frame to get.</param>
    /// <param name="optionalAsyncSuccessFunc" type="function">optional. The function to call when the download succeeds. Please refer to the function prototype OnSuccess.</param>
    /// <param name="optionalAsyncFailureFunc" type="function">optional. The function to call when the download fails. Please refer to the function prototype OnFailure.</param>
    /// <returns type="bool"></returns>   
};


PDF.SetPassword = function(password) {
	/// <summary>Input the password to decrypt PDF files using PDF Rasterizer add-on. </summary> 
	/// <param name="password" type="string">Specifies the PDF password.</param>
	/// <returns type="bool"></returns>
};

PDF.SetConvertMode = function(convertMode) {
    /// <summary> Set the image convert mode for PDF Rasterizer in Dynamic Web TWAIN. </summary>
    /// <param name="convertMode" type="EnumDWT_ConverMode">Specifies the image convert mode.</param>
    /// <returns type="bool"></returns>   
};

PDF.SetResolution = function(fResolution) {
    /// <summary> Set the output resolution for the PDF Rasterizer in Dynamic Web TWAIN. </summary>
    /// <param name="fResolution" type="float">Specifies the resolution for convertting image from PDF file.</param>
    /// <returns type="bool"></returns>   
};

PDF.IsTextBasedPDF = function(localFile) {
    /// <summary>Judges whether the local PDF is text-based or not.</summary>
    /// <param name="localFile" type="string">specifies the local path of the target PDF.</param>
    /// <returns type="bool"></returns>   
};


