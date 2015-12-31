using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Web_TablesHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString[Constants.CTRL_ORDR_ID] == "")
                {
                    hidOrderID.Value = "-1";
                }
                else
                {
                    hidOrderID.Value = Request.QueryString[Constants.CTRL_ORDR_ID].ToString();
                }

                if (Request.QueryString[Constants.CTRL_BILL_ID] == "")
                {
                    hidBillID.Value = "-1";
                }
                else
                {
                    hidBillID.Value = Request.QueryString[Constants.CTRL_BILL_ID].ToString();
                }

                hidTableID.Value = Request.QueryString[Constants.CTRL_TBL_ID].ToString();

                populateMenuCategory();
                populateMenus(Constants.MNU_CAT_STARTERS);
                populateOrderDetail(int.Parse(hidOrderID.Value.ToString()));

                populateOrderTax(int.Parse(hidOrderID.Value.ToString()), int.Parse(hidBillID.Value.ToString()));
            }


        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }


    protected void populateMenuCategory()
    {
        try
        {
            dlMenuCat.DataSource = clsUtil.getCodesByCategory(4);
            dlMenuCat.DataBind();
        }
        finally
        {
        }

    } 
    public void populateMenus(string sMenuType)
    {
        HotelMenu clsHotelMenu = new HotelMenu();
        try
        {

            dlMenuItems.DataSource = clsHotelMenu.getMenuItemsByType(sMenuType);
            dlMenuItems.DataBind();
        }
        finally
        {
            clsHotelMenu = null;
        }

    }

    protected void populateOrderDetail(int orderID)
    {
        Orders clsOrders = new Orders();
        try
        {
            dlOrderItems.DataSource = clsOrders.getOrderDetail(orderID);
            dlOrderItems.DataBind();
        }
        finally
        {
            clsOrders = null;

        }

    }
    protected void dlOrderItems_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ctl_OrderItem orderItem = e.Item.FindControl("OrderItem1") as ctl_OrderItem;
                orderItem.MenuItemName = ((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString();
                orderItem.MenuItemCost = ((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString();
                orderItem.MenuItemID = ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString();
                orderItem.MenuItemQty = ((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString();
                orderItem.OrderDetailID = ((DataRowView)e.Item.DataItem).Row.ItemArray[5].ToString();
                orderItem.TaxID = ((DataRowView)e.Item.DataItem).Row.ItemArray[6].ToString();
                if (orderItem.MenuItemQty == "")
                {
                    orderItem.MenuItemQty = "0";
                }
                orderItem.TotalCost = (decimal.Parse(orderItem.MenuItemQty) * decimal.Parse(orderItem.MenuItemCost)).ToString();
                     

                ImageButton btnDelOrderDetail = e.Item.FindControl("btnDelOrderItem") as ImageButton;
                btnDelOrderDetail.CommandName = Constants.CTRL_DELORDER_ID;
                btnDelOrderDetail.CommandArgument = ((DataRowView)e.Item.DataItem).Row.ItemArray[5].ToString();


                ImageButton btnCmplmntry = e.Item.FindControl("chkCmplmntry") as ImageButton;
                btnCmplmntry.CommandName = Constants.CTRL_CMPLMNTRY_ID;
                btnCmplmntry.CommandArgument = ((DataRowView)e.Item.DataItem).Row.ItemArray[5].ToString();
                if (((DataRowView)e.Item.DataItem).Row.ItemArray[7].ToString() == "Y")
                {
                    btnCmplmntry.CommandArgument = "N" + btnCmplmntry.CommandArgument  ;
                    btnCmplmntry.ImageUrl = "~/img/freeY.jpeg";
                }else{
                    btnCmplmntry.CommandArgument  = "Y" + btnCmplmntry.CommandArgument;
                    btnCmplmntry.ImageUrl = "~/img/FreeN.jpeg";
                }
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

    protected void dlOrderItems_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Orders clsOrders = new Orders();
        try
        {
            if (e.CommandName == Constants.CTRL_DELORDER_ID)
            {
                int i = clsOrders.delOrderDetail(int.Parse(e.CommandArgument.ToString()));
                populateOrderDetail(int.Parse(hidOrderID.Value.ToString()));
            }

            if (e.CommandName == Constants.CTRL_CMPLMNTRY_ID)
            {
                int i = clsOrders.saveCmplmntryItem(int.Parse(e.CommandArgument.ToString().Substring(1, e.CommandArgument.ToString().Length-1)), e.CommandArgument.ToString().Substring(0,1));
                populateOrderDetail(int.Parse(hidOrderID.Value.ToString()));
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally
        {
            clsOrders = null;
        }
    }
    protected void dlMenuCat_ItemCommand(object source, DataListCommandEventArgs e)
    {

        try
        {
            if (e.CommandName.ToString() == Constants.CTRL_MNU_CAT.ToString())
            {
                populateMenus(e.CommandArgument.ToString());
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

    protected void dlMenuCat_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnMenuCat1 = e.Item.FindControl("btnMenuCat") as LinkButton;
                btnMenuCat1.CommandArgument = ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString();
                btnMenuCat1.CommandName = Constants.CTRL_MNU_CAT;


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
    protected void dlMenuItems_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == Constants.CTRL_MNU_ITM.ToString())
            {
                saveNewOrderDetail(int.Parse(e.CommandArgument.ToString()));
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

    protected void dlMenuItems_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      
            {
                Button btndlMenuItem = e.Item.FindControl("btnMenuItem") as Button;
                btndlMenuItem.CommandArgument = ((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString();
                btndlMenuItem.CommandName = Constants.CTRL_MNU_ITM;
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

    protected void saveNewOrderDetail(int iMenuItemId)
    {
        string sOrder_BillId="";
        try
        { 
            Orders clsOrders = new Orders();

           sOrder_BillId = (clsOrders.updateOrderDetail(int.Parse(hidTableID.Value.ToString()),
                                                            int.Parse(hidOrderID.Value.ToString()),
                                                            Convert.ToInt32(Constants.OrderType.INHSE),
                                                            Convert.ToInt32(Constants.OrderStatus.INPROC),
                                                            iMenuItemId,int.Parse(hidBillID.Value.ToString()),
                                                             int.Parse(Session[Constants.SVAR_HOTEL_ID].ToString()), 
                                                            Convert.ToInt32(Session[Constants.SVAR_USER_ID].ToString()), 
                                                            Constants.INCREASE_MNU_QTY_BY_ONE).ToString());

           hidOrderID.Value = sOrder_BillId.Split('|')[0];
           hidBillID.Value= sOrder_BillId.Split('|')[1];

            populateOrderDetail(int.Parse(hidOrderID.Value.ToString()));

            populateOrderTax(int.Parse(hidOrderID.Value.ToString()), int.Parse(hidBillID.Value.ToString()));


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
    //    DataTable tblOrdDetail;
    //    ctl_OrderItem ct;
    //    Orders objOrders;
    //    try
    //    {
    //        tblOrdDetail = new DataTable();
    //        //Create datatable to hold data
    //        DataColumn col1 = new DataColumn("OrderDetailID");
    //        col1.DataType = System.Type.GetType("System.Int32");

    //        DataColumn col2 = new DataColumn("MenuItemID");
    //        col2.DataType = System.Type.GetType("System.Int32");

    //        DataColumn col3 = new DataColumn("MenuItemQty");
    //        col3.DataType = System.Type.GetType("System.Int32");

    //        DataColumn col4 = new DataColumn("TaxID");
    //        col4.DataType = System.Type.GetType("System.Int32");

    //        DataColumn col5 = new DataColumn("MenuItemCost");
    //        col5.DataType = System.Type.GetType("System.Decimal");

    //        tblOrdDetail.Columns.Add(col1);
    //        tblOrdDetail.Columns.Add(col2);
    //        tblOrdDetail.Columns.Add(col3);
    //        tblOrdDetail.Columns.Add(col4);
    //        tblOrdDetail.Columns.Add(col5);

    //        foreach (DataListItem dlItem in dlOrderItems.Items)
    //        {

    //            ct = (ctl_OrderItem)dlItem.FindControl("OrderItem1");

    //            DataRow dr = tblOrdDetail.NewRow();
    //            dr[col1] = Convert.ToInt32(ct.OrderDetailID.ToString());
    //            dr[col2] = Convert.ToInt32(ct.MenuItemID.ToString());
    //            dr[col3] = Convert.ToInt32(ct.MenuItemQty.ToString());
    //            dr[col4] = Convert.ToInt32(ct.TaxID.ToString());
    //            dr[col5] = Convert.ToInt32(ct.MenuItemCost.ToString());
    //            tblOrdDetail.Rows.Add(dr);
    //        }

    //        objOrders = new Orders();

    //        hidBillID.Value = objOrders.updateOrderDetail(int.Parse(hidTableID.Value.ToString()), 
    //            int.Parse(hidOrderID.Value.ToString()),
    //            (int)Constants.OrderType.INHSE,
    //                                                int.Parse(Session[Constants.SVAR_HOTEL_ID].ToString()),
    //                                                int.Parse(Session[Constants.SVAR_USER_ID].ToString()),
                                                    
    //                                                -1, int.Parse(hidBillID.Value.ToString()),
    //                                                tblOrdDetail,true).ToString();

    //        populateOrderTax(int.Parse(hidOrderID.Value.ToString()), int.Parse(hidBillID.Value.ToString()));
    //        //dlOrderTax.DataSource = orderOut.TaxDetail;
    //        //dlOrderTax.DataBind();

    //        //txtTotalBill.Text = orderOut.OrderTotal.ToString();


    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
    //    }
    //    finally
    //    {
    //        tblOrdDetail = null;
    //        ct = null;
    //    }
    }
    protected void dlOrderTax_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblTaxName1 = e.Item.FindControl("lblTaxName") as Label;
                lblTaxName1.Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString();

                TextBox txtTaxAmt1 = e.Item.FindControl("txtTaxAmt") as TextBox;
                txtTaxAmt1.Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[4].ToString();

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
    protected void populateOrderTax(int iOrderID, int iBillID)
    {
        Orders objOrders = new Orders();
        dlOrderTax.DataSource = objOrders.getOrderTax(iOrderID);
        dlOrderTax.DataBind();
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Web/CloseOrder.aspx?" + Constants.CTRL_ORDR_ID + "=" + Server.UrlEncode(hidOrderID.Value.ToString()) +
                                   "&" + Constants.CTRL_BILL_ID + "=" + Server.UrlEncode(hidBillID.Value.ToString()), false);
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