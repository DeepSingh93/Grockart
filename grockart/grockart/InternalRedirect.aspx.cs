using System;
using Grockart.STORAGE;

public partial class InternalRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // internal redirect
        // check if the cookies exists
        object OInternalRedirectCookie = CookieProxy.Instance().GetValue("InternalRedirect");

        if(OInternalRedirectCookie == null)
        {
            // redirect to home
            Response.Redirect("/");
        }

        string InternalRedirectCookie = OInternalRedirectCookie.ToString();

        // check for logic whether is there a suspicous link
        // end of check

        // remove the cookie
        CookieProxy.Instance().RemoveKey("InternalRedirect");
        Response.Redirect(InternalRedirectCookie);
    }
}