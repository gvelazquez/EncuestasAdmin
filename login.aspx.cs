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
using System.Windows.Forms;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void BttnLogin_Click(object sender, EventArgs e)
    {

        String user = this.txtUsuario.Text.ToString();
        String pass = this.TxtPwd.Text.ToString();
        
        DataSet ds;
        getData obj = new getData();

        obj.SeccionConnStr = "DSNCONN";
        ds = obj.getLogIn(user,pass);
        
        // trae valores 
        if (ds.Tables[0].Rows.Count > 0) {

            string estatus = ds.Tables[0].Rows[0]["estatus"] as string;
            //if (user == txtUsuario.Text.ToString() && pass == TxtPwd.Text.ToString() && estatus == "1")
            if(estatus == "1")
            {
                MessageBox.Show("Entraste");
                // acceso = true 
                // Creating a Cookie Object //
                HttpCookie _userInfoCokies = new HttpCookie("UserInfo");
                // Setting values inside it //
                Int32 idUsuarioValue = Convert.ToInt32(ds.Tables[0].Rows[0]["idusuario"].ToString());
                string NombreValue = ds.Tables[0].Rows[0]["nombre"] as string;

                _userInfoCokies["idUsuario"] = idUsuarioValue.ToString();  //ds.Tables[0].Rows[1]["idusuario"] as string;
                _userInfoCokies["Nombre"] = NombreValue;
                Response.Cookies.Add(_userInfoCokies);

                Response.Redirect("home.aspx");
            }
            else {
                MessageBox.Show("Usuario no activo en el sistema"+estatus);
            }

        }

    }
}
