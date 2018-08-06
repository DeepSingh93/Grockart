using Grockart.BUSINESSLAYER;
using Grockart.CRYPTOGRAPHY;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        UserProfile UserProfileObj = new UserProfile();
        UserProfileObj.SetEmail(TxtEmail.Value);
        APIResponse response = new UserActions(UserProfileObj).RecoverPasswordAction();
        if (response == APIResponse.OK)
        {
            LoginMessage.Visible = true;
            LoginMessage.InnerHtml = "Password reset link has been sent to your registered email address.";
        }
    }
}