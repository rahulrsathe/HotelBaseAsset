using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ctl_PaymentAmounts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtNote.Text == "")
        {
            txtNote.Text = "0";

        }
    }
    protected void imgIncr_Click(object sender, ImageClickEventArgs e)
    {
        if (txtNote.Text == "")
        {
            txtNote.Text = "0";
        }

        if (int.Parse(txtNote.Text.ToString()) >= 0)
        {
            txtNote.Text = (int.Parse(txtNote.Text.ToString()) + 1).ToString();             
        }
    }
    protected void imgDecr_Click(object sender, ImageClickEventArgs e)
    {

        if (txtNote.Text == "")
        {
            txtNote.Text = "0";
        }

        if (int.Parse(txtNote.Text.ToString()) > 0)
        {
            txtNote.Text = (int.Parse(txtNote.Text.ToString()) - 1).ToString();
        }
    }

    public int NotesQty
    {
        get
        {
            return int.Parse(txtNote.Text.Trim());
        }
        set
        {
            this.txtNote.Text = value.ToString();
        }
    }
    public string NotesLabel
    {
        get
        {
            return lblNoteAmt.Text.Trim();
        }
        set
        {
            this.lblNoteAmt.Text = value;
        }
    }
    public int Multiplier
    {
        get
        {
            return int.Parse(hidMultiplier.Value.Trim());
        }
        set
        {
            this.hidMultiplier.Value= value.ToString();
        }
    }

    public decimal Cost
    {
        get
        {
            return TotalCost();
        }
        set
        {
            txtNote.Text = "";            
        }
    }

    private decimal TotalCost()
    {
        if (txtNote.Text == "" )
        {
            return 0;
        }
        else
        {
            return (int.Parse(txtNote.Text.ToString()) * Multiplier);
        }
        

    }
}