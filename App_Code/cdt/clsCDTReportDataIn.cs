using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsReportDataIn
/// </summary>
public class CDTReportDataIn
{
    string _ReportName;
    int _OrderID;
    string _HotelName;
    string _BSTNo;
    string _CSTNo;
    string _HotelShortAddr;

    string _WaiterName;

	public CDTReportDataIn()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int OrderID
    {
        get
        {
            return _OrderID ;
        }
        set
        {
            _OrderID = value;
        }
    }

    public string HotelName 
    {
        get
        {
            return _HotelName;
        }
        set
        {
            _HotelName = value;
        }
    }


    public string BSTNo
    {
        get
        {
            return _BSTNo;
        }
        set
        {
            _BSTNo = value;
        }
    }



    public string CSTNo
    {
        get
        {
            return _CSTNo;
        }
        set
        {
            _CSTNo = value;
        }
    }


    public string HotelShortAddr
    {
        get
        {
            return _HotelShortAddr;
        }
        set
        {
            _HotelShortAddr = value;
        }
    }

    public string WaiterName
    {
        get
        {
            return _WaiterName;
        }
        set
        {
            _WaiterName = value;
        }
    }


    public string ReportName
    {
        get
        {
            return _ReportName;
        }
        set
        {
            _ReportName = value;
        }
    }
}