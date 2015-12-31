using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/// <summary>
/// Summary description for clsCDTOrder
/// </summary>
public class CDTOrderOut
{
    DataSet _dsTaxData = new DataSet();
    int _iBillID;
    decimal _orderTotal;
    public CDTOrderOut()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet TaxDetail
    {
        get
        {
            return new DataSet();
        }
        set
        {
            _dsTaxData= value;
        }
    }

    public int BillID
    {
        get
        {
            return _iBillID;
        }
        set
        {
            _iBillID=value;
        }
    }

    
    public decimal OrderTotal
    {
        get
        {
            return _orderTotal;
        }
        set
        {
            _orderTotal=value;
        }
    }
}