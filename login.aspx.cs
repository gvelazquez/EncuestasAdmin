using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BttnLogin_Click(object sender, EventArgs e)
    {
        DataSet ds;
        getData obj = new getData();

        obj.SeccionConnStr = "CadenaConexion";
        ds = obj.getLogIn("cc", "fgg");

        // trae valores 
        if (ds.Tables[0].Rows.Count > 0) {

            string estatus = ds.Tables[0].Rows[0]["estatus"] as string;

            if (estatus == "1")
            {
                // acceso = true 
                // Creating a Cookie Object //
                HttpCookie _userInfoCokies = new HttpCookie("UserInfo");
                // Setting values inside it //
                Int32 idUsuarioValue = Convert.ToInt32(ds.Tables[0].Rows[0]["idusuario"].ToString());
                string NombreValue = ds.Tables[0].Rows[0]["nombre"] as string;

                _userInfoCokies["idUsuario"] = idUsuarioValue.ToString();  //ds.Tables[0].Rows[1]["idusuario"] as string;
                _userInfoCokies["Nombre"] = NombreValue;
                Response.Cookies.Add(_userInfoCokies);

                Response.Redirect("AltaReporte.aspx");
            }
            else { 
                // acceso = false
            }

        }

    }
}
