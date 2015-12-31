using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ctl_IncrDecrControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtQty.Text == "")
        {
            txtQty.Text = "0";
        }

    }
    protected void imgIncr_Click(object sender, ImageClickEventArgs e)
    {
        if (txtQty.Text == "")
        {
            txtQty.Text = "0";
        }

        if (int.Parse(txtQty.Text.ToString()) >= 0)
        {
            txtQty.Text = (int.Parse(txtQty.Text.ToString()) + 1).ToString();
        }
         
    }
    protected void imgDecr_Click(object sender, ImageClickEventArgs e)
    {

        if (txtQty.Text == "")
        {
            txtQty.Text = "0";
        }
        if (int.Parse(txtQty.Text.ToString()) > 0)
        {
            txtQty.Text = (int.Parse(txtQty.Text.ToString()) - 1).ToString();
             
        }
    }

    public int Quantity
    {
        get
        {
            return int.Parse(txtQty.Text.Trim());
        }
        set
        {
            this.txtQty.Text = value.ToString();
        }
    }
}