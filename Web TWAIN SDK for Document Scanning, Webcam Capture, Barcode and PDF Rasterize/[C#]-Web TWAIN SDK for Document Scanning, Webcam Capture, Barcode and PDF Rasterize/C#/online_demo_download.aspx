<%@ Page Language="C#"%>

<%
	String strExc = "";
    try
    {
        //Get the image data from the database
        HttpRequest request = HttpContext.Current.Request;

        String strImageName;
        String strImageExtName;
        String strImageID;

        strImageName = request["ImageName"];
        strImageExtName = request["ImageExtName"];
        strImageID = request["iImageIndex"];

        String strConnString;

        strConnString = Common.DW_ConnString;

        System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString);
        System.Data.SqlClient.SqlCommand sqlCmdObj = new System.Data.SqlClient.SqlCommand("SELECT imgImageData FROM " + Common.DW_SaveTable + " WHERE iImageID= " + strImageID, sqlConnection);

        sqlConnection.Open();

        System.Data.SqlClient.SqlDataReader sdrRecordset = sqlCmdObj.ExecuteReader();

        sdrRecordset.Read();

        long iByteLength;
        iByteLength = sdrRecordset.GetBytes(0, 0, null, 0, int.MaxValue);

        byte[] byFileData = new byte[iByteLength];

        sdrRecordset.GetBytes(0, 0, byFileData, 0, Convert.ToInt32(iByteLength));

        sdrRecordset.Close();
        sqlConnection.Close();

        sdrRecordset = null;
        sqlConnection = null;

        Response.Clear();
        Response.Buffer = true;

        if (strImageExtName == "bmp")
        {
            Response.ContentType = "image/bmp";
        }
        else if (strImageExtName == "jpg")
        {
            Response.ContentType = "image/jpg";
        }
        else if (strImageExtName == "tif")
        {
            Response.ContentType = "image/tiff";
        }
        else if (strImageExtName == "png")
        {
            Response.ContentType = "image/png";
        }
        else if (strImageExtName == "pdf")
        {
            Response.ContentType = "application/pdf";
        }

        try
        {
            String fileNameEncode;
            fileNameEncode = HttpUtility.UrlEncode(strImageName, System.Text.Encoding.UTF8);
            fileNameEncode = fileNameEncode.Replace("+", "%20");
            String appendedheader = "attachment;filename=" + fileNameEncode;
            Response.AppendHeader("Content-Disposition", appendedheader);

            Response.OutputStream.Write(byFileData, 0, byFileData.Length);
        }
        catch (Exception exc)
        {
            strExc = exc.ToString();
            DateTime d1 = DateTime.Now;
            string logfilename = d1.Year.ToString() + d1.Month.ToString() + d1.Day.ToString() + d1.Hour.ToString() + d1.Minute.ToString() + d1.Second.ToString() + "log.txt";
            String strField1Path = HttpContext.Current.Request.MapPath(".") + "/" + logfilename;
            if (strField1Path != null)
            {
                System.IO.StreamWriter sw1 = System.IO.File.CreateText(strField1Path);
                sw1.Write(strExc);
                sw1.Close();
            }
            Response.Flush();
            Response.Close();
        }
    }
    catch (Exception ex)
    {
        strExc = ex.ToString();
        DateTime d1 = DateTime.Now;
        string logfilename = d1.Year.ToString() + d1.Month.ToString() + d1.Day.ToString() + d1.Hour.ToString() + d1.Minute.ToString() + d1.Second.ToString() + "log.txt";
        String strField1Path = HttpContext.Current.Request.MapPath(".") + "/" + logfilename;
        if (strField1Path != null)
        {
            System.IO.StreamWriter sw1 = System.IO.File.CreateText(strField1Path);
            sw1.Write(strExc);
            sw1.Close();
        }
        Response.Write(strExc);
    } 
%>