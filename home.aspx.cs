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

public partial class home : System.Web.UI.Page
{

    public HttpCookie _sesion;

    protected void Page_Load(object sender, EventArgs e)
    {
        _sesion = Request.Cookies["UserInfo"];

        if (_sesion != null)
        {

        }   
        else {
            Response.Redirect(login.aspx);
        }
    }
}
