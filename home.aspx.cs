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


public partial class home : System.Web.UI.Page
{

    public HttpCookie _sesion;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        _sesion = Request.Cookies["UserInfo"];

        if (_sesion != null)
        {
            //HttpCookie myCookie = new HttpCookie("Mi Cookie");
            DateTime now = DateTime.Now;

            String nombre = _sesion["Nombre"];
            String paterno = _sesion["ApPaterno"];

            Response.Write("Usuario: "+nombre+" "+paterno);

            //Procedimiento almacenado
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
                {
                    conn.ConnectionString = "Data Source=SIEM;Initial Catalog=DevClimaLaboral2;User ID=sa;Password=siem2000";
                    using (System.Data.SqlClient.SqlCommand command = conn.CreateCommand())
                    {
                        conn.Open();
                        // Create the sample database
                        command.CommandText = "SpDatosJefes";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        this.gvJefes.DataSource = command.ExecuteReader();
                        this.gvJefes.DataBind();
                        conn.Close();
                    }
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }   
        else {
            Response.Redirect("login.aspx");
        }
    }
    protected void salirBtn_Click(object sender, EventArgs e)
    {

        if (MessageBox.Show("¿Seguro que desea salir?", "Alerta", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _sesion.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(_sesion);
            Response.Redirect("login.aspx");
        }
      
    }
}
