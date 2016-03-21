using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_ViewMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //Populate menu items
                populateMenus();

            }
            else
            {

            }

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }


    }

    public void populateMenus()
    {
        HotelMenu clsHotelMenu = new HotelMenu();
        try
        {
             
        }
        finally
        {
            clsHotelMenu = null;
        }

    }

    protected void populateRecipe()
    {

        HotelMenu clsHotelMenu = new HotelMenu();
        try
        {

            grdMenus.DataSource = null;
            grdMenus.DataSource = clsHotelMenu.getMenuForMgmt();
            grdMenus.DataBind();

        }
        finally
        {
            clsHotelMenu = null;
        }

    }



}