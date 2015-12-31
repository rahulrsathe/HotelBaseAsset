using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsConstants
/// </summary>
public static  class Constants
{
    public  const string SVAR_HOTEL_ID = "HOTEL_ID";
    public  const string SVAR_HOTEL_NM = "HOTEL_NAME";
    public  const string SVAR_ROLE_ID = "ROLE_ID";
    public  const string SVAR_USER_ID = "USER_ID";
    public  const string SVAR_USER_NM = "USER_NM";
    public const string SVAR_USER_FULLNM = "USER_FULLNM";
    public const string CTRL_DELORDER_ID = "DeleteOrderDetail";
    public const string CTRL_CMPLMNTRY_ID = "CmplmntryMnuItm";
    public const string CTRL_MNU_CAT = "MenuCategoryCode";
    public const string CTRL_MNU_ITM = "MenuItem";
    public const string CTRL_ORDR_ID = "OrderID";
    public const string CTRL_TBL_ID = "TableID";
    public const string MNU_CAT_STARTERS = "STRT";
    public const string CTRL_BILL_ID = "BillID";
    public const string CDT_RPT_DATA_IN = "cdtReportDataIn";
public const string RPT_CUSTBILL = "CUSTBILL";
    public const int INCREASE_MNU_QTY_BY_ONE = 1;
    public const int DECREASE_MNU_QTY_BY_ONE = -1;
    public const int DELETE_MNU = 0;
    public const int INVNTRY_CATCODE = 8;
    public const string CTRL_RECIPE_EDIT = "RecipeAssnID";
    

    public enum OrderStatus
    {
        NEW=14,
        INPROC=16, 
        VOID=17,
        PAID=20,
    } ;

    public enum InventoryAction
    {
        NEW = 1,
        WASTE = 2,
        USED=3,
        DELETED=4,
    } ;


    public enum OrderType
    {
        INHSE = 20,
        DLVRY = 21,
    } ;


    public enum BillStatus
    {
        GENERATED = 22,
        PAID = 23,
        VOID=24,
    } ;

    public enum PaymentType
    {
        CASH = 3,
        CREDITCRD = 1,
        DEBITCRD = 2,
        CHEK=4,
    } ; 
    static  Constants()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}