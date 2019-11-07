using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Register : System.Web.UI.Page
{
    DataBaseClass dbClass = new DataBaseClass();
    DataTable dt = new DataTable();
    string ToSaveImageName;
    string sImageFileExtension;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonMakeProfile_Click(object sender, EventArgs e)
    {
        string chkUser = "Select * FROM [User] where Email='" + TextBoxEmail.Text + "'";
        dt = dbClass.ConnectDataBaseReturnDT(chkUser);
        if (dt.Rows.Count > 0)
        {

        }
        else
        {
            if (UploadUserPhoto.PostedFile != null)
            {
                string myMap = MapPath("~/").ToLower();
                Random r = new Random();
                int next = r.Next();
                string ImageName = UploadUserPhoto.PostedFile.FileName;
                // ToSaveImageName = DateTime.Now.ToString("yyyy-MM-ddTmm:hh:ss");
                //ToSaveImageName.Replace('-', '1');
                //ToSaveImageName.Replace(':', '2');  
                //Directory.CreateDirectory(myMap + ToSaveImageName);
                sImageFileExtension = ImageName.Substring(ImageName.LastIndexOf(".")).ToLower();
                if (sImageFileExtension == ".gif" || sImageFileExtension == ".png" || sImageFileExtension == ".jpg" || sImageFileExtension == ".jpeg" || sImageFileExtension == ".bmp")
                {
                    string ImageSaveURL = myMap + "UserImage/" + next + sImageFileExtension;
                    try
                    {
                        UploadUserPhoto.PostedFile.SaveAs(ImageSaveURL);
                        string RegisterQuery = "INSERT INTO [User] (Email,Password,Name,Country,Description,ImageName) VALUES('" + TextBoxEmail.Text + "','" + TextBoxPassword.Text + "','" + TextBoxName.Text + "','" + TextBoxCountry.Text + "','" + TextBoxComment.Text + "','" + next + sImageFileExtension + "')";
                        dbClass.ConnectDataBaseToInsert(RegisterQuery);
                        Response.Redirect("~/Login.aspx");
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
                ToSaveImageName = "No";
                sImageFileExtension = "Image";
            }

        }
    }
}
