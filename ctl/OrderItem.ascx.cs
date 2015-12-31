using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ctl_OrderItem : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (txtQty.Text == "")
        {
            txtQty.Text = "0";

        }
        if (lblMenuCost.Text == "")
        {
            lblMenuCost.Text = "0";
        }
        txtTotal.Text = Convert.ToString((int.Parse(txtQty.Text.ToString())) * decimal.Parse(lblMenuCost.Text.Trim().ToString()));
        txtTotal.Text = Convert.ToString((int.Parse(txtQty.Text.ToString())) * decimal.Parse(lblMenuCost.Text.Trim().ToString()));

    }
    protected void Incr_Click(object sender, EventArgs e)
    {
        if (txtQty.Text == "")
        {
            txtQty.Text = "0";
        }

        if (int.Parse(txtQty.Text.ToString()) >= 0)
        {
            txtQty.Text = (int.Parse(txtQty.Text.ToString()) + 1).ToString();
            txtTotal.Text = Convert.ToString((int.Parse(txtQty.Text.ToString())) * decimal.Parse(lblMenuCost.Text.Trim().ToString()));
        }
    }
    protected void Decr_Click(object sender, EventArgs e)
    {
        if (txtQty.Text == "")
        {
            txtQty.Text = "0";
        }
        if (int.Parse(txtQty.Text.ToString()) > 0)
        {
            txtQty.Text = (int.Parse(txtQty.Text.ToString()) - 1).ToString();
            txtTotal.Text = Convert.ToString((int.Parse(txtQty.Text.ToString())) * decimal.Parse(lblMenuCost.Text.Trim().ToString()));
        }
    }

    public string MenuItemID
    {
        get
        {
            return hidMenuItemID.Value;
        }
        set
        {
            hidMenuItemID.Value = value;
        }
    }

    public string MenuItemQty
    {
        get
        {
            return txtQty.Text.Trim();
        }
        set
        {
            this.txtQty.Text = value;
        }
    }


    public string MenuItemName
    {
        get
        {
            return this.lblMenuName.Text.Trim();
        }
        set
        {
            this.lblMenuName.Text = value;
        }
    }

    public string MenuItemCost
    {
        get
        {
            return this.lblMenuCost.Text.Trim();
        }
        set
        {
            this.lblMenuCost.Text = value;
        }
    }

    public string OrderDetailID
    {
        get
        {
            return this.hidOrderDetailID.Value.ToString();
        }
        set
        {
            this.hidOrderDetailID.Value = value;
        }
    }

    public string TaxID
    {
        get
        {
            return this.hidTaxID.Value.ToString();
        }
        set
        {
            this.hidTaxID.Value = value;
        }
    }

    public string TotalCost
    {
        get
        {
            return this.txtTotal.Text.ToString();
        }
        set
        {
            this.txtTotal.Text = value;
        }
    }

    
}