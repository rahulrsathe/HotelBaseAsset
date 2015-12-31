using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Web_NewRecipes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                //Populate menu items
                populateMenus();
                populateInventoryCat();

            }
            else {


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

    public void populateInventoryCat()
    {
        try
        {
            dlInventCat.DataSource = clsUtil.getCodesByCategory(8);
            dlInventCat.DataBind();
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
            dlMenuItems.DataSource = clsHotelMenu.getMenuItemsForRecipe();
            dlMenuItems.DataBind();
        }
        finally
        {
            clsHotelMenu = null;
        }

    }


    protected void dlMenuItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            populateRecipe();

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        { }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
    }


    protected void populateRecipe()
    {

        HotelMenu clsHotelMenu = new HotelMenu();
        try
        {
            grdRecipe.DataSource = clsHotelMenu.getRecipeForMenu(Convert.ToInt16(dlMenuItems.SelectedValue.ToString()));
            grdRecipe.DataBind();
        }
        finally
        {
            clsHotelMenu = null;
        }

    }




    protected void grdRecipe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string[] index = e.CommandArgument.ToString().Split('|');

            ScriptManager.RegisterStartupScript(this, this.GetType(),
            "Message", "alert('Are you sure you want to delete - " + index[0] + "');", true);

            deleteInvMenuAssn(index[1]);
             
        }
    }

    protected void deleteInvMenuAssn(string sIndex)
    {


        resetControls();

    }

    protected void dlInventCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        Inventory objInventory = new Inventory();

        try
        {
            dlInvItem.DataSource = objInventory.getInventoryHeaderItemsbyCat(Convert.ToInt16(dlInventCat.SelectedValue));
            dlInvItem.DataBind();

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
    }

    protected void dlInvItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        Inventory objInventory = new Inventory();

        try
        {
            lblQtyMeasure.Text = objInventory.getInvMeasureByInvID(Convert.ToInt16(dlInvItem.SelectedValue));

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
    }

    private void resetControls()
    {
        lblQtyMeasure.Text = "";
        dlMenuItems.SelectedIndex = -1;
        dlInventCat.SelectedIndex = -1;
        dlInvItem.SelectedIndex = -1;
        txtQuantity.Text = "";
        hidNewEditFlag.Value = "";


    }
}