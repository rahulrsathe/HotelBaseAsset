using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if  (!Page.IsPostBack ) {
            populateTables();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }

     protected void populateTables()
    {
        try
        {
            Orders clsOrders = new Orders();
            dlTables.DataSource  = clsOrders.getTableList(int.Parse(Session[Constants.SVAR_HOTEL_ID].ToString()));
            dlTables.DataBind();
        }
        
        finally
        {
            
        }
    }

    protected void dlTables_ItemDataBound(object sender, DataListItemEventArgs e)
     {
         try
         {
             if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
             {
                 LinkButton btndlMenuItem = e.Item.FindControl("btnEditOrder") as LinkButton;
                 btndlMenuItem.CommandArgument = ((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString() + "|"
                                                + ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString() + "|" 
                                                + ((DataRowView)e.Item.DataItem).Row.ItemArray[6].ToString();
                 btndlMenuItem.CommandName = Constants.CTRL_ORDR_ID;

                 Label  lblTblID = e.Item.FindControl("lblTableID") as Label;

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
     protected void dlTables_ItemCommand(object source, DataListCommandEventArgs e)
     { 
         string[] s;
         try
         {
             s = new string[2];
             if (e.CommandName == Constants.CTRL_ORDR_ID)
             {
                    s=e.CommandArgument.ToString().Split('|');
              }

             Response.Redirect("~/Web/OrderDetail.aspx?"+ Constants.CTRL_ORDR_ID+"=" + Server.UrlEncode(s[1].ToString()) +
                                    "&" + Constants.CTRL_TBL_ID + "=" + Server.UrlEncode(s[0]) + "&" 
                                    + Constants.CTRL_BILL_ID + "=" + Server.UrlEncode(s[2]), false);
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
