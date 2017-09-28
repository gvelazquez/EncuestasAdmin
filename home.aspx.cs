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


public partial class home : System.Web.UI.Page
{

    public HttpCookie _sesion;
    //public String idHotelSelected; 
    //public int sdepto;

    static public String idhotel;

    protected void Page_Load(object sender, EventArgs e)
    {

        _sesion = Request.Cookies["UserInfo"];

        if (_sesion != null)
        {
            //HttpCookie myCookie = new HttpCookie("Mi Cookie");
            DateTime now = DateTime.Now;

            String nombre = _sesion["Nombre"];
            String paterno = _sesion["ApPaterno"];
            int sdepto;
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

        if (MessageBox.Show("¿Seguro que desea salir?", "Alerta", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _sesion.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(_sesion);
            Response.Redirect("login.aspx");
        }
      
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {

        String idhotel      = ddlHotel.Text;
        String idusaurio    = txtUsuario.Text;
        String iddepto      = ddlDepartamento.Text;
        int idperiodo    = int.Parse(txtPeriodo.Text);
        int anio         = int.Parse(txtAnio.Text);

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

}
