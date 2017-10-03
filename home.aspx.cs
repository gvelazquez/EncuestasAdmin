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
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;


public partial class home : System.Web.UI.Page
{

    public HttpCookie _sesion;
    static public String idhotel;
    public static Dictionary<string, int> diccJefeProspecto;

    protected void Page_Load(object sender, EventArgs e)
    {

        _sesion = Request.Cookies["UserInfo"];

        if (_sesion != null)
        {
            //HttpCookie myCookie = new HttpCookie("Mi Cookie");
            DateTime now = DateTime.Now;

            String nombre = _sesion["Nombre"];
            String paterno = _sesion["ApPaterno"];
           
            txtAnio.Text = "2017";

            Response.Write("Usuario: "+nombre+" "+paterno);

                if (!Page.IsPostBack)
                {
                    //Llenado de combobox de hoteles
                    obtenerHoteles();
                    //Despliegue de la tabla con los usuarios existentes
                    despliegueGrid();
                }
                //
                else
                {
                    //if (ddlDepartamento.SelectedValue != "" && idHotelSelected == ddlHotel.SelectedValue.ToString()) 
                    //    {
                    //        sdepto = Convert.ToInt32(ddlDepartamento.SelectedValue); 
                    //    }
                    //idHotelSelected = ddlHotel.SelectedValue;
                    
                    if (idhotel != ddlHotel.SelectedValue){
                        obtenerDepartamentos(ddlHotel.SelectedValue);
                        idhotel = ddlHotel.SelectedValue.ToString();
                    }

                    //ddlDepartamento.SelectedValue = selectedValueDepto.ToString();

                 
                    //if (sdepto != 0)
                    //    ddlDepartamento.SelectedValue = sdepto.ToString();
                    
                }

        }   
        else {
            Response.Redirect("login.aspx");
        }
    }
    protected void salirBtn_Click(object sender, EventArgs e)
    {
          
        _sesion.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(_sesion);
        Response.Redirect("login.aspx");

        //if (MessageBox.Show("¿Seguro que desea salir?", "Alerta", MessageBoxButtons.YesNo,
        //    MessageBoxIcon.Question) == DialogResult.Yes)
        //{
        //    _sesion.Expires = DateTime.Now.AddDays(-1);
        //    Response.Cookies.Add(_sesion);
        //    Response.Redirect("login.aspx");
        //}
      
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        String idhotel      = ddlHotel.Text;
        String idusaurio    = txtUsuario.Text;
        String iddepto      = ddlDepartamento.Text;
        String idperiodo    = txtPeriodo.Text;
        String anio         = txtAnio.Text;

        DataSet ds;
        getData obj = new getData();

        obj.SeccionConnStr = "DSNCONN";
        ds = obj.insertJefe(idhotel, idusaurio, iddepto, idperiodo, anio);


        if (ds.Tables[0].Rows.Count > 0) {
            String insert = ds.Tables[0].Rows[0]["inserta"] as string;


            if (insert == "1" ) {
                MessageBox.Show("Usuario Agregado Correctamente");
            }
            else{
                MessageBox.Show("Usuario Ya existe");
            }

        }
/*
        String conexion = "Data Source=SIEM;Initial Catalog=DevClimaLaboral2;User ID=sa;Password=siem2000";
        SqlConnection cnn = new SqlConnection(conexion);

        cnn.Open();
        SqlCommand cmd=new SqlCommand("SpAgregarJefe",cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@IDHOTEL", SqlDbType.VarChar).Value = txtHotel.Text;
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = txtUsuario.Text;
        cmd.Parameters.Add("@IDDEPTO", SqlDbType.Int).Value = txtDepartamento.Text;
        cmd.Parameters.Add("@IDPERIODO", SqlDbType.Int).Value = txtPeriodo.Text;
        cmd.Parameters.Add("@AÑO", SqlDbType.Int).Value = txtAnio.Text;
        cmd.ExecuteNonQuery();

        MessageBox.Show("Usuario Agregado Correctamente");
        txtHotel.Text = "";
        txtUsuario.Text = "";
        txtDepartamento.Text = "";
        txtPeriodo.Text = "";
        txtAnio.Text = "";
*/
    }

    public void obtenerHoteles(){

        DataSet ds;
        getData obj = new getData();

        obj.SeccionConnStr = "DSNCONN";
        ds = obj.getHoteles();

        if (ds.Tables[0].Rows.Count > 0) {

            ddlHotel.DataSource = ds.Tables[0];
            ddlHotel.DataTextField = "nombre";
            ddlHotel.DataValueField = "idhotel";
            ddlHotel.DataBind();

        }
    
    }
   
    public void obtenerDepartamentos(String idhotel){

        DataSet ds;
        getData obj = new getData();
        //idhotel = ddlHotel.SelectedValue;

        obj.SeccionConnStr = "DSNCONN";
        ds = obj.getDepartamentos(idhotel);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDepartamento.DataSource = ds.Tables[0];
            ddlDepartamento.DataTextField = "depto";
            ddlDepartamento.DataValueField = "iddepto";
            ddlDepartamento.DataBind();
        }
        //int sdepto = Convert.ToInt32(ddlDepartamento.SelectedValue);
    }

    public void despliegueGrid()
    {
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
        catch (Exception ex)
        {
            throw ex;
        }
    }



    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetNombreProspectoJefeList(string prefixText, int count, string contextKey)
    {

        string connectionString = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        // Try to use parameterized inline query/sp to protect sql injection
        //Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        SqlCommand cmd = new SqlCommand("SELECT TOP " + count + " t1.nombre_completo, t1.idusuario " + " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " + "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE Undone = 'FALSE' " + "           AND CASE t2.acronimo WHEN 'CORP' THEN 'CORPORATIVO' ELSE T2.Acronimo END = '" + contextKey + "' " + "           AND t1.idhotel = t2.idhotel )t1 " + " WHERE nombre_completo LIKE '%" + prefixText + "%'", conn);

        conn.Open();
        List<string> CompletionSet = new List<string>();
        diccJefeProspecto = new Dictionary<string, int>();
        SqlDataReader oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        
while (oReader.Read()) {
	if (!CompletionSet.Contains(oReader.GetString("nombre_completo").Trim().ToString())) {
		CompletionSet.Add(oReader("nombre_completo".Trim().ToString()));
		diccJefeProspecto.Add((oReader("nombre_completo".Trim().ToString())),Convert.ToInt32(oReader("idusuario")));
	}
	//CompletionSet.Add(oReader("nombre_completo").ToString())
	//diccJefeProspecto.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
}
        //    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close();
        return CompletionSet.ToArray();
    }


}
