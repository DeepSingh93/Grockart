using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPages_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        foreach (string key in CookieProxy.Instance().GetAllKeys())
        {
            CookieProxy.Instance().RemoveKey(key);
        }

        // abandon the session
        Session.Abandon();
    }
}