<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page Language="C#"%>
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title><%= Common.DW_Title%></title>
    <meta http-equiv="Content-type" content="text/html;charset=UTF-8" />
    <meta http-equiv="Content-Language" content="en-us"/>
    <meta http-equiv="X-UA-Compatible" content="requiresActiveX=true" />
    <%= Common.DW_Description%>
    <%= Common.DW_Keyword%>
    <link href="Styles/style.css" type="text/css" rel="stylesheet" />
    <script>
    // JavaScript Document
    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-19660825-1']);
    _gaq.push(['_setDomainName', 'dynamsoft.com']);
    _gaq.push(['_trackPageview']);
    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();
    </script>
</head>

<%
	System.Web.HttpRequest request;
	System.Data.SqlClient.SqlDataReader sqlSdr;
	
	request = System.Web.HttpContext.Current.Request;
	
    String strImageID;
    strImageID = request["iImageIndex"];
	
    String strConnString;

    strConnString = Common.DW_ConnString;

	System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString);
	
	sqlConnection.Open();
	
	String SqlCmdText;
	
	if(strImageID != ""){
        SqlCmdText = "delete from " + Common.DW_SaveTable + " where iImageID='" + strImageID + "'";
		System.Data.SqlClient.SqlCommand sqlCmdObj = new System.Data.SqlClient.SqlCommand(SqlCmdText, sqlConnection);
		sqlCmdObj.ExecuteNonQuery();
	}


    SqlCmdText = "select strImageName,iImageID from " + Common.DW_SaveTable + " order by strImageName";
    System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand(SqlCmdText, sqlConnection);

	sqlSdr = sqlCmd.ExecuteReader();

%>	
<body>

<div id="container" class="body_Broad_width" style="margin:0 auto;">

<div class="DWTHeader">
    <!-- header.aspx is used to initiate the head of the sample page. Not necessary!-->
    <!-- #include file=includes/PageHead.aspx -->
</div>

<div class="body_Broad_width" style="background-color:#ffffff; border:0;">
<br />
<table style="width:100%; border: 0px;">
<tr>
    <th style="text-align:center; width:50%; font-size:larger; border-top: solid Gray thin; border-bottom: solid Gray thin;"><b>Image Name</b></th>
    <th style="text-align:center; width:50%; font-size:larger; border-top: solid Gray thin; border-bottom: solid Gray thin;"><b>Operation</b></th>
</tr>
<%
    while(sqlSdr.Read()){
        String strImageName;
        String strImageExtName;
        strImageName = sqlSdr.GetString(0);
        if (strImageName.Length > 80)
        {
            strImageName = strImageName.Substring(0, 67) + "..." + strImageName.Substring(strImageName.Length -10, 10);
        }
        strImageExtName = "";
			                       
        if(strImageName.Length > 3){
            strImageExtName = strImageName.Substring(strImageName.Length - 3, 3);
        }
        else{
            strImageExtName = "tif";
        }                    		
%>
<tr>
<td style="text-align:center;"><%=strImageName%></td>
<td style="text-align:center;">
    <a href = "online_demo_list.aspx?iImageIndex=<%=sqlSdr.GetInt32(1)%>">Del</a>
    |
    <a href = "online_demo_download.aspx?iImageIndex=<%=sqlSdr.GetInt32(1)%>&ImageName=<%=strImageName%>&ImageExtName=<%=strImageExtName%>">Download</a>
    |
    <a href = "online_demo_view.aspx?iImageIndex=<%=sqlSdr.GetInt32(1)%>&ImageName=<%=strImageName%>&ImageExtName=<%=strImageExtName%>">View</a> 
</td>			 
</tr>
<%					
    }
    sqlSdr.Close();
    sqlConnection.Close();
%>
<tr>
    <td colspan = "2" style="text-align:center; font-size:larger; border-top: solid Gray thin;">
        <a href ="online_demo_scan.aspx"><b>Scan and Upload Another Image</b></a>
    </td>
</tr>
</table>
</div>

 <div class="DWTTail">
    <!-- #include file=includes/PageTail.aspx -->
</div>

</div> 
<%=Common.DW_LiveChatJS %>   
</body>
</html>