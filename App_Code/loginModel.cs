using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for loginModel
/// </summary>
public class loginModel
{
    private string _usuario;
    private string _password;
    private string _nombre;

	public loginModel()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }

    public string password
    {
        get { return _password; }
        set { _password = value; }
    }

    public string nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

}
