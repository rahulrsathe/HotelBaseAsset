using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Web_InventoryCentral : System.Web.UI.Page
{
    DataTable _tblInventoryItems; 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //1. Load Combos
            if (!Page.IsPostBack)
            {
                populateInventoryCategories();
                populateInventoryIetms(Convert.ToInt32(dlInventoryCategory.SelectedValue.ToString()));
                resetPage();            
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

    public void resetPage()
    {

        btnNewInventory.BackColor = System.Drawing.Color.White;
        btnRecordWaste.BackColor = System.Drawing.Color.White;
        ucInventoryCost.Quantity = 0;
        ucInventoryQty.Quantity = 0;
        hdInventoryAction.Value = "";

    }

    public void populateInventoryCategories()
    { 
            dlInventoryCategory.DataSource = clsUtil.getCodesByCategory(Constants.INVNTRY_CATCODE).Tables[0];
            dlInventoryCategory.DataBind();
        
    }
    protected void dlInventoryCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            populateInventoryIetms(Convert.ToInt32(dlInventoryCategory.SelectedValue.ToString()));
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
    }
    public void populateInventoryIetms(int iInventoryHeaderID)
    {
        Inventory objInventory = new Inventory();
        
        try
        {
            _tblInventoryItems = objInventory.getInventoryHeaderItemsbyCat(iInventoryHeaderID).Tables[0];
            dlInventoryItem.DataSource = null;
            dlInventoryItem.DataSource = _tblInventoryItems;
            dlInventoryItem.DataBind();
            setInventoryItemMeasurement();

           
        }
        finally
        {
            objInventory = null;

        }
    }
    private void setInventoryItemMeasurement()
    {
        //_tblInventoryItems = (DataTable)dlInventoryItem.DataSource;
        //string strFilter;
        //strFilter = "inventoryheaderid=" + dlInventoryItem.SelectedValue.ToString();
        //DataRow[] drInvForMnuItems;
        //drInvForMnuItems = _tblInventoryItems.Select(strFilter);
        //foreach (DataRow drInvForMnuItem in drInvForMnuItems)
        //{
        //    lblInventoryMeasure.Text = drInvForMnuItem["measure"].ToString();
        //}
    }
    protected void dlInventoryItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            setInventoryItemMeasurement();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
        
    }
    protected void btnNewInventory_Click(object sender, EventArgs e)
    {
        try
        {
            btnNewInventory.BackColor=System.Drawing.Color.Khaki;
            btnRecordWaste.BackColor = System.Drawing.Color.White;
            hdInventoryAction.Value = Convert.ToInt32(Constants.InventoryAction.NEW).ToString();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
        }
        
    }
    protected void btnRecordWaste_Click(object sender, EventArgs e)
    {
        try
        {
            btnNewInventory.BackColor = System.Drawing.Color.White;
            btnRecordWaste.BackColor = System.Drawing.Color.Khaki;
            hdInventoryAction.Value = Convert.ToInt32(Constants.InventoryAction.WASTE).ToString();
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
        Inventory objInventory = new Inventory();
        try
        {
            if (!validateInputData())
            {
                objInventory.saveInventory(int.Parse(dlInventoryItem.SelectedValue.ToString()),
                    decimal.Parse(ucInventoryQty.Quantity.ToString()),
                    hdInventoryAction.Value.ToString(),
                    decimal.Parse(ucInventoryCost.Quantity.ToString()),
                    clrInventoryBuyDt.SelectedDate,
                    Convert.ToInt32(Session[Constants.SVAR_USER_ID].ToString()));
                lblValSummary.Text = "Save Successful.";
                resetPage();
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
    private bool validateInputData()
    {
        bool bInValid=false;
        if (ucInventoryCost.Quantity.ToString() == "0")
        {
            bInValid=true;
            lblValSummary.Text = "Cost, ";
        }
         if (ucInventoryQty.Quantity.ToString() == "0")
        {
            bInValid=true;
            lblValSummary.Text = lblValSummary.Text + "Quantity, ";
        }
        if (clrInventoryBuyDt.SelectedDate.ToString() == "")
        {
            bInValid=true;
            lblValSummary.Text = lblValSummary.Text + "Purchase Date, ";
        }
        if (hdInventoryAction.Value == "")
        {
            bInValid = true;
            lblValSummary.Text = lblValSummary.Text + "Inventory New or Waste ";
        }
        if (lblValSummary.Text != "")
        {
            lblValSummary.Text = lblValSummary.Text + "cannot be blank.";
        }
        
        return bInValid;
    }
}