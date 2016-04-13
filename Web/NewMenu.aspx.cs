using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_NewMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int[] selectedIndexesOfCheckBoxList(CheckBoxList chkList)
    {
        List<int> selectedIndexes = new List<int>();

        foreach (ListItem item in chkList.Items)
        {
            if (item.Selected)
            {
                selectedIndexes.Add(chkList.Items.IndexOf(item));
            }
        }

        return selectedIndexes.ToArray();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            HotelMenu objHotelMenu = new HotelMenu();
            try
            {
                //validate
                if (txtMenuName.Text != "" && txtCost.Text !="")
                {
                    objHotelMenu.insertNewMenuItem(
                        Convert.ToInt16(dlMenuType.SelectedValue),
                        txtMenuName.Text.Trim(),
                        Convert.ToDecimal(txtCost.Text),
                        Convert.ToInt16(Session[Constants.SVAR_USER_ID]),
                        int.Parse(Session[Constants.SVAR_HOTEL_ID].ToString()),
                        selectedIndexesOfCheckBoxList(chkTaxMaster)) ;
                    txtCost.Text = "";
                    chkTaxMaster.ClearSelection();
                    //show success
                    lblValidation.Text = "Save Success";
                    lblValidation.ForeColor = System.Drawing.Color.Green;
                    lblValidation.Font.Bold = true;

                }
                else {
                    lblValidation.Text = "You must provide menu name, cost and tax code associated with it.";
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
}