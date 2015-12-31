using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                applyRoleSecurity();
                lblHotelName.Text = Session[Constants.SVAR_HOTEL_NM].ToString();
                lblHotelNameFooter.Text = Session[Constants.SVAR_HOTEL_NM].ToString();
                imgLogo.ImageUrl = "~/img/"+Session[Constants.SVAR_HOTEL_ID].ToString()+".jpg";
            }
        }
        catch (Exception ex)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }

    private void applyRoleSecurity()
    {
        if (
                (Request.UrlReferrer != null) &&
                (Request.UrlReferrer.ToString().Contains("localhost"))
            ||
            (HttpContext.Current.User.Identity.IsAuthenticated == true))
        {


            //Extract page name:
            string pageName = Request.FilePath.ToString().Remove(
                                    0, Request.FilePath.ToString().LastIndexOf("/") + 1).ToUpper();
            pageName = pageName.Remove(pageName.LastIndexOf("."), pageName.Length - pageName.LastIndexOf("."));

            UserAuth objUsers = new UserAuth();
            if (objUsers.validateRoleAccess(pageName, long.Parse(Session[Constants.SVAR_ROLE_ID].ToString())) == false )
            {
                throw new Exception(Resources.AppMessages.NO_ACCESS.ToString());
            };


        }
        else
        {
            throw new Exception(Resources.AppMessages.NO_ACCESS.ToString());
        }

    }

}
