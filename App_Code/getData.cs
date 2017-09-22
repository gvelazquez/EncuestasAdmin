using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Web.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for getData
/// </summary>
public class getData
{
	public getData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string ConnStr;
    private string SeccionCnStr;

    public string SeccionConnStr
    {
        get { return SeccionCnStr; }
        set
        {
            SeccionCnStr = value;
            ConnStr = WebConfigurationManager.ConnectionStrings[value].ConnectionString;
        }
    }

    /// <summary>
    /// -----------------
    /// ---- LOG IN  ----
    /// ----------------- 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    /// <returns></returns>
    public DataSet getLogIn(String user, String pass)
    {

        //DataSet ds;
        DataSet ds = new DataSet();
        //eConnect.DataBase Conn;
        eConnect.DataBase Conn = default(eConnect.DataBase);

        Conn = new eConnect.DataBase(ConnStr);
        Conn.TimeOut = 420;
        Conn.Open();

        try
        {
            ds = Conn.GetDataSetBySP("sp", user, pass);
        }
        catch (Exception ex) { }
        finally
        {
            if (Conn.Connection.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Dispose();
            ds.Dispose();
        }

        return ds;
    }
}
