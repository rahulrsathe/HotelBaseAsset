using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Session[Constants.SVAR_HOTEL_ID] = "";
        Session[Constants.SVAR_ROLE_ID] = "";
        Session[Constants.SVAR_HOTEL_NM] = "";
        Session[Constants.SVAR_USER_FULLNM] ="";
        Session[Constants.SVAR_USER_ID] = "";
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();
    }
}
