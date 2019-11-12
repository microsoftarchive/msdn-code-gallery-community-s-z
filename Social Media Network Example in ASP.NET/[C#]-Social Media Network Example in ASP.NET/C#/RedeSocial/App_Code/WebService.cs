using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] GetSearch(string prefixText)
    {
        string conexaoSQL = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\aspn\RedeSocial\App_Data\RedeSocial.mdf;Integrated Security=True;User Instance=True";
        string sql = "Select * from User Where Name like @prefixText";
        SqlDataAdapter da = new SqlDataAdapter(sql, conexaoSQL);
        da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 100).Value = prefixText + "%";
        DataTable dt = new DataTable();
        da.Fill(dt);
        string[] items = new string[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            items.SetValue(dr["Name"].ToString(), i);
            i++;
        }
        return items;
    }

    
}

