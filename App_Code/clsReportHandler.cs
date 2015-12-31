using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Configuration;

/// <summary>
/// Summary description for clsReportHandler
/// </summary>
public class ReportHandler
{
    DataSet _dsReportData = new DataSet();
    int _iOrderID;
    //string _sReportName;
    LocalReport _lr;

    public ReportHandler()
    { 

    }

    public void LoadReport(CDTReportDataIn objCDTReportDataIn)
    { 
        Orders objOrders ;
        try
        {
            string [] sOrderTax_Discnt;
          
            switch (objCDTReportDataIn.ReportName)
            {
                case Constants.RPT_CUSTBILL:

                    _lr.ReportPath = ConfigurationManager.AppSettings["reportPath"].ToString() + "rptCustBill.rdlc";

                    objOrders = new Orders();
                    sOrderTax_Discnt=objOrders.getOrderTaxForBill(objCDTReportDataIn.OrderID);
                    //Set the parameters
                    ReportParameter p1 = new ReportParameter("HotelName", objCDTReportDataIn.HotelName);
                    _lr.SetParameters(new ReportParameter[] { p1 });

                    ReportParameter p2 = new ReportParameter("OrderID", objCDTReportDataIn.OrderID.ToString());
                    _lr.SetParameters(new ReportParameter[] { p2 });

                    ReportParameter p3 = new ReportParameter("TotalTax",sOrderTax_Discnt[0]);
                    _lr.SetParameters(new ReportParameter[] { p3 });

                    ReportParameter p4 = new ReportParameter("DiscountPrcnt",sOrderTax_Discnt[1]);
                    _lr.SetParameters(new ReportParameter[] { p4 });

                    Microsoft.Reporting.WebForms.ReportDataSource rds;
                    rds = null;
                    rds = new Microsoft.Reporting.WebForms.ReportDataSource();
                    rds.Name = "dsCustBill";
                    rds.Value = objOrders.getCustBill(objCDTReportDataIn.OrderID).Tables[0];

                    _lr.DataSources.Add(rds);
                    break;

            }
        }
        finally
        {
            objOrders = null;
        }
    }


    private void LoadReportParams()
    {

    }

    

    public LocalReport rptLocalRpt
    {
        get
        {
            return _lr;
        }
        
        set
        {
           _lr =value;
        }
    }

    public int OrderID
    {
        get
        {
            return _iOrderID;
        }
        set
        {
            _iOrderID = value;
        }
    }
     
}