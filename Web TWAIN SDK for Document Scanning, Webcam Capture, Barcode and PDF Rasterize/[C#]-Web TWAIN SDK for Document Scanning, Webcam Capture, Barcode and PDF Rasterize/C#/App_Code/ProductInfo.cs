using System;
using System.Collections.Generic;
using System.Web;

public class ProductInfo
{
    //WebTwain
    public static string DW_Title = "Dynamic Web TWAIN Online Demo | Scan and upload documents in browsers";
    public static string DW_Description = "<meta name=\"description\" content=\"This online demo application (JavaScript + ASP.NET-C#) shows how to use Dynamic Web TWAIN SDK to control any TWAIN compatible device drivers - scanner, digital camera or capture card - in a web page to scan images, edit and then upload to web servers.\" />";
    public static string DW_Keyword = "<meta name=\"keyword\" content=\"Dynamsoft, TWAIN, Scanners, SDK, Scanning\"/>";
 

    //Online Demo
    public static string DW_LiveChatJS = "<script type='text/javascript'>var Comm100API=Comm100API||{chat_buttons:[]};Comm100API.chat_buttons.push({code_plan:5000143,div_id:'comm100-button-5000143'});</script>";
    public static string DW_SaveDB = "DemoWebTwain";
    public static string DW_SaveTable = "tblWebTwain4";
    //public static string DW_ConnString = "Server=localhost;Database=" + ProductInfo.DW_SaveDB + ";Integrated Security=SSPI";
    public static string DW_ConnString = "Server=localhost\\sqlexpress;Database=" + ProductInfo.DW_SaveDB + ";User ID=sa;Password=DefeGedetf;Trusted_Connection=False";
}
