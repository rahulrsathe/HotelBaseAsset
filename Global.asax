﻿<%@ Application Language="C#" %>
<%@ Import Namespace ="System.Security.Principal" %>

<script runat="server">


    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        try {
            System.Web.HttpContext context = HttpContext.Current;
            System.Exception ex= Context.Server.GetLastError();
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        catch (Exception ex)
        {
                      

        }
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {

    }

</script>
