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

            }else
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
            dlMenuItems.Items.Clear();
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
            lblValidation.Text = "";

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
        {

            Recipe objRecipe = new Recipe();
            try
            {
                //validate
                if (txtQuantity.Text != "" && dlInvItem.SelectedIndex>0)
                {
                    objRecipe.saveRecipeInvAssn(
                        Convert.ToInt16(dlMenuItems.SelectedValue),
                        Convert.ToInt16(dlInvItem.SelectedValue),
                        Convert.ToDecimal(txtQuantity.Text),
                        Convert.ToInt16(Session[Constants.SVAR_USER_ID]));
                    txtQuantity.Text = "";
                    lblQtyMeasure.Text = "";
                    //show success
                    lblValidation.Text = "Save Success";
                    lblValidation.ForeColor = System.Drawing.Color.Green;
                    lblValidation.Font.Bold = true;

                }
                else {
                    lblValidation.Text = "Please provide quantity or select inventory item.";
                    lblValidation.ForeColor = System.Drawing.Color.Red;
                    lblValidation.Font.Bold = true;
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
            
            grdRecipe.DataSource = null;
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
        try {  
        if (e.CommandName == "Delete")
        {
            string[] index = e.CommandArgument.ToString().Split('|');
            //ScriptManager.RegisterStartupScript(this, this.GetType(),
            //"Message", "alert('Are you sure you want to delete - " + index[1] + "');", true);
            deleteInvMenuAssn(index[0]);
                lblValidation.Text = index[1] + " deleted successfully.";
                lblValidation.ForeColor = System.Drawing.Color.Green;
                lblValidation.Font.Bold = true;

        }
        if (e.CommandName == "Edit")
        {
            string[] index = e.CommandArgument.ToString().Split('|');
                
        } }

        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
    }

    protected void deleteInvMenuAssn(string sIndex)
    {
        Recipe objRecipe = new Recipe();
        try
        {
            objRecipe.deleteRecipeInvAssn(Convert.ToInt16(sIndex), Convert.ToInt16(Session[Constants.SVAR_USER_ID]));
            lblValidation.Text = "";
            
        }
        finally
        {
            objRecipe = null;

        }

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
        dlInvItem.SelectedIndex = -1;

        dlMenuItems.SelectedIndex = -1;
        
        dlInventCat.SelectedIndex = -1;
        
        txtQuantity.Text = "";
        hidNewEditFlag.Value = "";

        lblValidation.Text = "";
    }

    protected void UpdatePanel2_PreRender(object sender, EventArgs e)
    {
        populateRecipe();
                
    }

    protected void grdRecipe_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}