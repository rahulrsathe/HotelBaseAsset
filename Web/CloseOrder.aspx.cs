using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_CloseOrder : System.Web.UI.Page
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
                populateOrderAmounts(int.Parse(hidBillID.Value.ToString()), int.Parse(hidOrderID.Value.ToString()));
                populateDiscountReasons();
                
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }

    private void populateOrderAmounts(int iBillID, int iOrderID)
    {
        Orders objOrders = new Orders();
        lblOrderTotal.Text =  objOrders.getOrderAmount(iBillID, iOrderID)[2];
        hidOrgBillAmt.Value = lblOrderTotal.Text;
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        decimal dTotalPaid = 0;
        decimal dReturn = 0;
        try
        {
            dTotalPaid = (ucNotes500.Cost + ucNotes50.Cost + ucNotes100.Cost + ucNotes1000.Cost + ucNotes10.Cost + ucNotes20.Cost);
            lblTotalPaid.Text = dTotalPaid.ToString();
            dReturn = (dTotalPaid - decimal.Parse(lblOrderTotal.Text.ToString()));

            if (dReturn > 0)
            {
                lblReturn.Text = dReturn.ToString();
            }
            else
            {
                lblReturn.Text = "0";
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }
    protected void btnClearNotes_Click(object sender, EventArgs e)
    {
        try
        {
            ucNotes10.Cost = 0;
            ucNotes20.Cost = 0;
            ucNotes100.Cost = 0;
            ucNotes1000.Cost = 0;
            ucNotes500.Cost = 0;
            ucNotes50.Cost = 0;
            lblTotalPaid.Text = "0";
            lblReturn.Text = "0";
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }

    protected bool updateOrderStatus(int iOrderStatus, int iBillStatus)
    {
        Orders objOrder;
        try
        {
            if (validateData())
            {
                int iPaymentTyp = 1;
                if (rdrCash.Checked)
                {
                    iPaymentTyp = (int)Constants.PaymentType.CASH;
                }
                if (rdrCreditCard.Checked)
                {
                    iPaymentTyp = (int)Constants.PaymentType.CREDITCRD;
                }
                if (rdrDebit.Checked)
                {
                    iPaymentTyp = (int)Constants.PaymentType.DEBITCRD;
                }


                objOrder = new Orders();
                objOrder.updateOrderTransaction(int.Parse(hidOrderID.Value.ToString()),
                                                    int.Parse(hidBillID.Value.ToString()),
                                                    int.Parse(Session[Constants.SVAR_USER_ID].ToString()),
                                                    iPaymentTyp, ucNotes10.NotesQty, ucNotes20.NotesQty,
                                                    ucNotes50.NotesQty, ucNotes100.NotesQty,
                                                    ucNotes500.NotesQty, ucNotes1000.NotesQty,
                                                    decimal.Parse(txtDiscount.Text),
                                                    dlDiscountCode.SelectedValue.ToString(),
                                                    decimal.Parse(lblOrderTotal.Text), iOrderStatus,iBillStatus);

                Response.Redirect("~/Default.aspx", false);
                return true;
            }
            else
            {
                return false;
            }
        }
         
        finally
        {
            objOrder = null;
        }
    }
    protected void btnCloseOrder_Click(object sender, EventArgs e)
    {
        try
        {
            updateOrderStatus((int)Constants.OrderStatus.PAID, (int)Constants.BillStatus.PAID);
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
         
    }
    protected void btnPrintBill_Click(object sender, EventArgs e)
    {
        try
        {
            if (updateOrderStatus((int)Constants.OrderStatus.INPROC,(int)Constants.BillStatus.GENERATED)){
                CDTReportDataIn objCDTReportDataIn = new CDTReportDataIn();
                objCDTReportDataIn.ReportName = Constants.RPT_CUSTBILL;
                objCDTReportDataIn.OrderID = int.Parse(hidOrderID.Value.ToString());
                objCDTReportDataIn.HotelName = Session[Constants.SVAR_HOTEL_NM].ToString();
                objCDTReportDataIn.WaiterName = Session[Constants.SVAR_USER_NM].ToString();

                Session[Constants.CDT_RPT_DATA_IN] = objCDTReportDataIn;

                Response.Redirect("~/Web/PrintBill.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
        finally{

            
        }

    }

    protected bool validateData()
    {
        lblValSummary.Text = "";
        bool bValidated = true;

        if (rdrCash.Checked == false && rdrCreditCard.Checked == false && rdrDebit.Checked == false)
        {
            lblValSummary.Text = lblValSummary.Text + "<li> Please provide payment type </li>";
            bValidated = false;
        }
        
        if (decimal.Parse(lblOrderTotal.Text) > decimal.Parse(lblTotalPaid.Text)){

            lblValSummary.Text = lblValSummary.Text + "<li> Please provide payment amount more than order total</li>";
            bValidated = false;
        }


        return bValidated;

    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Decimal dOrderAmt = Decimal.Parse(hidOrgBillAmt.Value);
            lblOrderTotal.Text = (dOrderAmt - (dOrderAmt * Decimal.Parse(txtDiscount.Text) / 100)).ToString();

           
                populateDiscountReasons();
             
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
         
    }

    protected void populateDiscountReasons()
    {
        try
        {
             if (Decimal.Parse(txtDiscount.Text) > 0){

                    lblDisReason.Visible = true;
                    dlDiscountCode.Visible = true;
                    dlDiscountCode.DataSource = clsUtil.getCodesByCategory(9);
                    dlDiscountCode.DataBind();
             }
        }
        finally
        {
        }
    }
}