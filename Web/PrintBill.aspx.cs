using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Web_PrintBill : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // int.Parse(Request.QueryString[Constants.CTRL_ORDR_ID].ToString());
            if (!Page.IsPostBack)
            {
                ReportHandler objReports = new ReportHandler();

                CDTReportDataIn objCDTReportDataIn = (CDTReportDataIn)Session[Constants.CDT_RPT_DATA_IN];

                vwrBill.LocalReport.DataSources.Clear();
                vwrBill.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //objReports.ReportName = Constants.RPT_CUSTBILL;
                //objReports.OrderID = objCDTReportDataIn.OrderID;

                objReports.rptLocalRpt = vwrBill.LocalReport;
                objReports.LoadReport(objCDTReportDataIn);
              
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Web/error.aspx?msg=" + Server.UrlEncode(ex.Message.ToString()).ToString(), false);
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {

        try
        {
           
        }
        finally
        {

            //
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
       Session.Remove(Constants.CDT_RPT_DATA_IN);
    }

    
}