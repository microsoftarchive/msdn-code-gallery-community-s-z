using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using AjaxControlToolkit;

namespace AJAXFileUploadSQL
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["preview"] == "1" && !string.IsNullOrEmpty(Request.QueryString["fileId"]))
            {
                var fileId = Request.QueryString["fileId"];
                var fileContentType = (string)Session["fileContentType_" + fileId];
                var fileName = (string)Session["fileName_" + fileId];
                byte[] imageBytes = File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath("~") + "file.png");
                var fileContents = imageBytes;

                string ct = (string)Session["fileContentType_" + fileId];
                if (ct.Contains("jpg") || ct.Contains("gif") || ct.Contains("png") || ct.Contains("jpeg"))
                    fileContents = (byte[])Session["fileContents_" + fileId];

                using (SqlConnection _con = new SqlConnection("Data Source=.;Initial Catalog=AJAXFileUploadSQL;Integrated Security=True"))
                using (SqlCommand _cmd = new SqlCommand("UploadFile", _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@FileName", fileName);
                    _cmd.Parameters.AddWithValue("@FileType", fileContentType);
                    _cmd.Parameters.AddWithValue("@FileContent", (byte[])Session["fileContents_" + fileId]);

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }

                Response.Clear();
                Response.ContentType = fileContentType;
                Response.BinaryWrite(fileContents);
                Response.End();
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs file)
        {
            Session["fileContentType_" + file.FileId] = file.ContentType;
            Session["fileContents_" + file.FileId] = file.GetContents();

            Session["fileName_" + file.FileId] = file.FileName.Split('\\').Last();

            file.PostedUrl = string.Format("?preview=1&fileId={0}", file.FileId);
        }
    }
}
