using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }

    protected void LoginUser_LoginIn(object sender, EventArgs e)
    {

    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {

    }

    protected void LoginUser_OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        try
        { 
            FormsAuthentication.Initialize();

            UserAuth objUsers = new UserAuth();
            string[] userDetails
                    = objUsers.validateLogin(LoginUser.UserName.ToString(), LoginUser.Password.ToString());
            if (userDetails != null)
            {
                e.Authenticated = true;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                        userDetails[1],
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(120),
                                                        true,
                                                        userDetails[2].ToString(),
                                                        FormsAuthentication.FormsCookiePath);
                 
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket

                if (ticket.IsPersistent) 
                { 
                    cookie.Expires = ticket.Expiration; 
                }

                // Add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);

                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)
                {
                    //Response.Redirect("~/Web/USERS/TablesHome.aspx");
                }
                else
                {
                    //Response.Redirect(returnUrl);
                }

                Session[Constants.SVAR_HOTEL_ID] = userDetails[5];
                Session[Constants.SVAR_ROLE_ID ] = userDetails[2].ToString();
                Session[Constants.SVAR_HOTEL_NM ] = userDetails[4].ToString();
                Session[Constants.SVAR_USER_FULLNM] = userDetails[3].ToString();
                Session[Constants.SVAR_USER_NM] = userDetails[1].ToString();
                Session[Constants.SVAR_USER_ID] = userDetails[0].ToString();

            }
            else
            {
                e.Authenticated = false;
                LoginUser.FailureText = Resources.AppMessages.AUTH_FAILED.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void LoginUser_Error(object sender, EventArgs e)
    {
        Session["employee_id"] = null;
        Session["FullName"] = null;
        Session["role_id"] = null;
        Session["role_desc"] = null;
        //Server.Transfer("error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()));
    }

}
