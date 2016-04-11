using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for clsOrders
/// </summary>
public class Orders
{
    public Orders()
    {

    }

    public DataSet getTableList(int sHotelID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getTableList");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = sHotelID;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = (int)Constants.OrderStatus.INPROC;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = (int)Constants.OrderType.INHSE;

            con = Connection.getConnection();
            command.Connection = con;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);

            return ds;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public DataSet getOrderDetail(int sOrderID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getOrderDetail");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = sOrderID;
            con = Connection.getConnection();
            command.Connection = con;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);

            return ds;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public int saveCmplmntryItem(int sOrderDetailID, string sCmplmntry)
    {
        MySqlConnection con = null;

        try
        {
            string[] strSQL = XMLWrapper.getSQLString("saveCmplmntryItem");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = sOrderDetailID;

            command.Parameters.Add(strSQL[2], MySqlDbType.VarChar);
            command.Parameters[strSQL[2]].Value = sCmplmntry;

            con = Connection.getConnection();
            command.Connection = con;
            int iRowsAffected = command.ExecuteNonQuery();
            return iRowsAffected;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public int delOrderDetail(int sOrderDetailID)
    {
        MySqlConnection con = null;

        try
        {
            string[] strSQL = XMLWrapper.getSQLString("delOrderDetail");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = sOrderDetailID;
            con = Connection.getConnection();
            command.Connection = con;
            int iRowsAffected = command.ExecuteNonQuery();
            return iRowsAffected;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public string updateOrderDetail(int iTableID, int iOrderID, int iOrderType, int iOrderStauts, int iMenuItemId, int iBillID, int iHotelID, int iModBy, int iOrderOperation)
    {
        MySqlConnection con = null;
        MySqlTransaction trTransaction;
        MySqlCommand command = new MySqlCommand();
        string[] strSQL;
        long iOrderHeaderID = -1;
        Dictionary<int, decimal> dctTax = new Dictionary<int, decimal>();
        decimal dTaxAmt = 0;
        decimal dTotalTax = 0;
        decimal dOrderTotal = 0;
        string sTaxIDs = "";
        string[] sTaxArray;
        con = Connection.getConnection();
        command.Connection = con;
        trTransaction = con.BeginTransaction();
        command.Transaction = trTransaction;
        string[] orderDetails;
        bool bInsertNewMenu = false;
        int iOrderDetailId = -1;
        MySqlDataAdapter da;
        DataSet ds;

        try
        {

            if (iOrderID == -1)
            {
                //Insert order header
                strSQL = XMLWrapper.getSQLString("insertOrderHeader");
                command.CommandText = strSQL[0];
                command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                command.Parameters[strSQL[1]].Value = iTableID;

                command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                command.Parameters[strSQL[2]].Value = iOrderStauts;

                command.Parameters.Add(strSQL[3], MySqlDbType.Int16);
                command.Parameters[strSQL[3]].Value = iOrderType;

                command.Parameters.Add(strSQL[4], MySqlDbType.Int16);
                command.Parameters[strSQL[4]].Value = iModBy;

                command.ExecuteNonQuery();
                iOrderHeaderID = command.LastInsertedId;

                //Set Order ID
                iOrderID = Convert.ToInt32(iOrderHeaderID);
            }

            //Clean command object
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;
            //Check if this should be insert or update. If the order id contains a menu item like this already, then this will be an update

            strSQL = XMLWrapper.getSQLString("getIfMenuAddedToOrder");
            command.CommandText = strSQL[0];

            command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
            command.Parameters[strSQL[1]].Value = iOrderID;

            command.Parameters.Add(strSQL[2], MySqlDbType.VarChar);
            command.Parameters[strSQL[2]].Value = iMenuItemId;

            MySqlDataReader reader = command.ExecuteReader();
            orderDetails = new string[3];
            while (reader.Read())
            {
                orderDetails[0] = reader["foodorderdetailid"].ToString();
                orderDetails[1] = reader["menuitemid"].ToString();
                orderDetails[2] = reader["menuitemqty"].ToString();
            }

            if (
                orderDetails[0] == null ||
                orderDetails[1] == null
            )
            {
                orderDetails = null;
                bInsertNewMenu = true;

            }
            else
            {
                iOrderDetailId = int.Parse(orderDetails[0].ToString());
            }
            reader.Close();

            //Get Menu - Inventory association data
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;

            strSQL = XMLWrapper.getSQLString("getMenuInvAssn");
            command.CommandText = strSQL[0];
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderID;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);

            //reduce inventory from table
            string strFilter;
            strFilter = "menuitemid=" + iMenuItemId.ToString();
            DataRow[] drInvForMnuItems;
            drInvForMnuItems = ds.Tables[0].Select(strFilter);
        
            //Clean command object
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;
            if (bInsertNewMenu == true)
            {
                //insert order detail
                strSQL = XMLWrapper.getSQLString("insertOrderDetail");
                command.CommandText = strSQL[0];
                command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                command.Parameters[strSQL[1]].Value = iOrderID;

                command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                command.Parameters[strSQL[2]].Value = iMenuItemId;

                command.Parameters.Add(strSQL[3], MySqlDbType.Int16);
                command.Parameters[strSQL[3]].Value = iModBy;


                command.Parameters.Add(strSQL[4], MySqlDbType.VarChar);
                command.Parameters[strSQL[4]].Value = 'N';

                command.ExecuteNonQuery();

                command.CommandText = "";
                command.Parameters.Clear();
                strSQL = null;

                foreach (DataRow drInvForMnuItem in drInvForMnuItems)
                {
                    //Cleanup
                    command.CommandText = "";
                    command.Parameters.Clear();
                    strSQL = null;

                    strSQL = XMLWrapper.getSQLString("insertInventoryIncrement");
                    command.CommandText = strSQL[0];

                    command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                    command.Parameters[strSQL[1]].Value = int.Parse(drInvForMnuItem["invheaderid"].ToString());

                    command.Parameters.Add(strSQL[2], MySqlDbType.Decimal);
                    command.Parameters[strSQL[2]].Value = decimal.Parse(drInvForMnuItem["reduceinvqty"].ToString());

                    command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                    command.Parameters[strSQL[3]].Value = iModBy;

                    command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                    command.Parameters[strSQL[4]].Value = iOrderID;

                    command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
                    command.Parameters[strSQL[5]].Value = iMenuItemId;

                    command.ExecuteNonQuery();
                }

            }
            else
            {
                //update the order detail
                switch (iOrderOperation)
                {
                    case Constants.INCREASE_MNU_QTY_BY_ONE:
                        strSQL = XMLWrapper.getSQLString("increaseMenuQty");
                        command.CommandText = strSQL[0];
                        command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                        command.Parameters[strSQL[1]].Value = iOrderDetailId;
                        command.ExecuteNonQuery();

                        //Decrease Inventory
                        command.CommandText = "";
                        command.Parameters.Clear();
                        strSQL = null;

                        foreach (DataRow drInvForMnuItem in drInvForMnuItems)
                        {
                            //Cleanup
                            command.CommandText = "";
                            command.Parameters.Clear();
                            strSQL = null;

                            strSQL = XMLWrapper.getSQLString("insertInventoryIncrement");
                            command.CommandText = strSQL[0];

                            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                            command.Parameters[strSQL[1]].Value = int.Parse(drInvForMnuItem["invheaderid"].ToString());

                            command.Parameters.Add(strSQL[2], MySqlDbType.Decimal);
                            command.Parameters[strSQL[2]].Value = decimal.Parse(drInvForMnuItem["reduceinvqty"].ToString());

                            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                            command.Parameters[strSQL[3]].Value = iModBy;

                            command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                            command.Parameters[strSQL[4]].Value = iOrderID;

                            command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
                            command.Parameters[strSQL[5]].Value = iMenuItemId;

                            command.ExecuteNonQuery();
                        }


                        break;


                    case Constants.DECREASE_MNU_QTY_BY_ONE:
                        strSQL = XMLWrapper.getSQLString("decreaseMenuQty");
                        command.CommandText = strSQL[0];
                        command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                        command.Parameters[strSQL[1]].Value = iOrderDetailId;
                        command.ExecuteNonQuery();

                        //Increase Inventory
                        command.CommandText = "";
                        command.Parameters.Clear();
                        strSQL = null;

                        foreach (DataRow drInvForMnuItem in drInvForMnuItems)
                        {
                            //Cleanup
                            command.CommandText = "";
                            command.Parameters.Clear();
                            strSQL = null;

                            strSQL = XMLWrapper.getSQLString("insertInventoryReduction");
                            command.CommandText = strSQL[0];

                            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                            command.Parameters[strSQL[1]].Value = int.Parse(drInvForMnuItem["invheaderid"].ToString());

                            command.Parameters.Add(strSQL[2], MySqlDbType.Decimal);
                            command.Parameters[strSQL[2]].Value = decimal.Parse(drInvForMnuItem["reduceinvqty"].ToString());

                            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                            command.Parameters[strSQL[3]].Value = iModBy;

                            command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                            command.Parameters[strSQL[4]].Value = iOrderID;

                            command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
                            command.Parameters[strSQL[5]].Value = iMenuItemId;

                            command.ExecuteNonQuery();
                        }


                        break;


                    case Constants.DELETE_MNU:
                        strSQL = XMLWrapper.getSQLString("deleteMenuQty");
                        command.CommandText = strSQL[0];
                        command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                        command.Parameters[strSQL[1]].Value = iOrderDetailId;
                        command.ExecuteNonQuery();

                        //Increase Inventory
                        command.CommandText = "";
                        command.Parameters.Clear();
                        strSQL = null;

                       
                        //Cleanup
                        command.CommandText = "";
                        command.Parameters.Clear();
                        strSQL = null;

                        strSQL = XMLWrapper.getSQLString("deleteInventoryData");
                        command.CommandText = strSQL[0];

                        command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                        command.Parameters[strSQL[1]].Value = iModBy;

                        command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                        command.Parameters[strSQL[2]].Value = iOrderID;

                        command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                        command.Parameters[strSQL[3]].Value = iMenuItemId;

                        command.ExecuteNonQuery();
                        
                        break;
                }

            }
            //reduce inventory
            //0 get menu inventory association data - for every individual menu, what all inventory to reduce.
            //Cleanup
            //command.CommandText = "";
            //command.Parameters.Clear();
            //strSQL = null;

            //strSQL = XMLWrapper.getSQLString("getMenuInvAssn");
            //command.CommandText = strSQL[0];
            //command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            //command.Parameters[strSQL[1]].Value = iOrderID;
            //da = new MySqlDataAdapter(command);
            //ds = new DataSet();
            //da.Fill(ds);

            ////reduce inventory from table
            //string strFilter;
            //strFilter = "menuitemid=" + iMenuItemId.ToString();
            //DataRow[] drInvForMnuItems;
            //drInvForMnuItems = ds.Tables[0].Select(strFilter);
            //foreach (DataRow drInvForMnuItem in drInvForMnuItems)
            //{
            //    //Cleanup
            //    command.CommandText = "";
            //    command.Parameters.Clear();
            //    strSQL = null;

            //    strSQL = XMLWrapper.getSQLString("insertInventoryReduction");
            //    command.CommandText = strSQL[0];

            //    command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            //    command.Parameters[strSQL[1]].Value = int.Parse(drInvForMnuItem["invheaderid"].ToString());

            //    command.Parameters.Add(strSQL[2], MySqlDbType.Decimal);
            //    command.Parameters[strSQL[2]].Value = decimal.Parse(drInvForMnuItem["reduceinvqty"].ToString());

            //    command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            //    command.Parameters[strSQL[3]].Value = iModBy;

            //    command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
            //    command.Parameters[strSQL[4]].Value = iOrderID;

            //    command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
            //    command.Parameters[strSQL[5]].Value = iMenuItemId;

            //    command.ExecuteNonQuery();
            //}

            /**************************************************/
            //cleanup
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;

            strSQL = XMLWrapper.getSQLString("getOrderDetailForBill");
            command.CommandText = strSQL[0];

            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderID;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                command.CommandText = "";
                command.Parameters.Clear();
                strSQL = null;
                //2. Select distinct tax ids for the order
                if (!dctTax.ContainsKey(int.Parse(dr["TaxID"].ToString())))
                {
                    dctTax.Add(int.Parse(dr["TaxID"].ToString()), 0);
                    if (dr["TaxID"].ToString() != "")
                    {
                        sTaxIDs = sTaxIDs + int.Parse(dr["TaxID"].ToString()) + ",";
                    }
                }

                dOrderTotal = dOrderTotal + (decimal.Parse(dr["MenuItemQty"].ToString())
                                                * decimal.Parse(dr["MenuItemCost"].ToString()));
            }


            //Remove last comma;
            sTaxIDs = sTaxIDs.Remove(sTaxIDs.LastIndexOf(','));

            sTaxArray = sTaxIDs.Split(',');
            //3. Get Tax percent for the order detail

            //Clean command object
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;

            strSQL = XMLWrapper.getSQLString("getTaxPercent");
            command.CommandText = strSQL[0];

            command = clsUtil.createInString(command, sTaxArray);

            command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
            command.Parameters[strSQL[1]].Value = iHotelID;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dctTax[int.Parse(reader["taxid"].ToString())] = decimal.Parse(reader["taxpercent"].ToString());

            }

            reader.Close();
            reader = null;

            foreach (KeyValuePair<int, decimal> entry in dctTax)
            {
                // do something with entry.Value or entry.Key

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //4. Loop through the order detail table.
                    //4. Total tax for a given tax type
                    if (int.Parse(entry.Key.ToString()) == int.Parse(dr["TaxID"].ToString()))
                    {
                        dTaxAmt = dTaxAmt + ((entry.Value / 100) * int.Parse(dr["MenuItemQty"].ToString())
                                                                    * int.Parse(dr["MenuItemCost"].ToString()));
                    }
                }
                try
                {
                    //5. Check if order tax detail exists for a given bill
                    //5. If no, order tax detail, if not - update bill detail

                    command.CommandText = "";
                    command.Parameters.Clear();
                    strSQL = null;
                    strSQL = XMLWrapper.getSQLString("insertOrderTax");
                    command.CommandText = strSQL[0];

                    command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
                    command.Parameters[strSQL[1]].Value = iOrderID;

                    command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                    command.Parameters[strSQL[2]].Value = (int.Parse(entry.Key.ToString()));

                    command.Parameters.Add(strSQL[3], MySqlDbType.Decimal);
                    command.Parameters[strSQL[3]].Value = dTaxAmt;

                    command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                    command.Parameters[strSQL[4]].Value = iModBy;

                    command.ExecuteNonQuery();

                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        command.CommandText = "";
                        command.Parameters.Clear();
                        strSQL = null;
                        strSQL = XMLWrapper.getSQLString("updateOrderTax");
                        command.CommandText = strSQL[0];

                        command.Parameters.Add(strSQL[1], MySqlDbType.Decimal);
                        command.Parameters[strSQL[1]].Value = dTaxAmt;

                        command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                        command.Parameters[strSQL[2]].Value = iModBy;

                        command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                        command.Parameters[strSQL[3]].Value = iOrderID;

                        command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                        command.Parameters[strSQL[4]].Value = (int.Parse(entry.Key.ToString()));

                        command.ExecuteNonQuery();
                    }
                }


                dTotalTax = dTaxAmt + dTotalTax;
            }

            //6. Check if bill header exists for given order ID
            //6. If yes - Insert bill header; if not - update bill header

            //try
            //{
            //    //5. Check if bill detail exists for a given bill
            //5. If no, Insert bill detail, if not - update bill detail
            if (iBillID == -1)
            {
                command.CommandText = "";
                command.Parameters.Clear();
                strSQL = null;
                strSQL = XMLWrapper.getSQLString("insertBillHeader");
                command.CommandText = strSQL[0];

                command.Parameters.Add(strSQL[1], MySqlDbType.Decimal);
                command.Parameters[strSQL[1]].Value = dOrderTotal + dTotalTax;

                command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                command.Parameters[strSQL[2]].Value = (Constants.BillStatus.GENERATED);

                command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                command.Parameters[strSQL[3]].Value = iModBy;

                command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                command.Parameters[strSQL[4]].Value = iModBy;

                command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
                command.Parameters[strSQL[5]].Value = iOrderID;

                command.ExecuteNonQuery();
                iBillID = int.Parse(command.LastInsertedId.ToString());
            }
            else
            {
                command.CommandText = "";
                command.Parameters.Clear();
                strSQL = null;
                strSQL = XMLWrapper.getSQLString("updateBillHeader");
                command.CommandText = strSQL[0];

                command.Parameters.Add(strSQL[1], MySqlDbType.Decimal);
                command.Parameters[strSQL[1]].Value = dOrderTotal + dTotalTax;

                command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
                command.Parameters[strSQL[2]].Value = iModBy;

                command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
                command.Parameters[strSQL[3]].Value = iBillID;

                command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
                command.Parameters[strSQL[4]].Value = iOrderID;

                command.ExecuteNonQuery();
            }
            //}
            //catch (MySqlException ex)
            //{
            //    if (ex.Number == 1062)
            //    {

            //    }
            //}
            //7. Complete transaction.

            //trTransaction.Commit();

             /********************************************************/
            //Call Save order method to update tax details
            //updateOrderDetail(iOrderID,iHotelID,
            //                                        iModBy,
            //                                        (int)Constants.OrderType.INHSE,
            //                                        -1, iBillID,
            //                                        tblOrderDetail, false).ToString();


            trTransaction.Commit();
            return  iOrderID + "|" + iBillID;

        }
        catch (Exception ex)
        {
            trTransaction.Rollback();
            throw ex;
        }

        finally
        {
            Connection.closeConnection(con);
        }

    }

    //public int depricatedOrderDetail(int iOrderID, int iHotelID, int iModBy,
    //                                    int iOrderType, int iCustID, int iBillID, int iOrderOperation)
    //{
    //    MySqlConnection con = null;
    //    //MySqlTransaction trTransaction;
    //    MySqlCommand command = new MySqlCommand();
    //    string[] strSQL;
    //    string sTaxIDs = "";
    //    string[] sTaxArray;
    //    con = Connection.getConnection();
    //    command.Connection = con;
    //    //trTransaction = con.BeginTransaction();
    //    //command.Transaction = trTransaction;
    //    Dictionary<int, decimal> dctTax = new Dictionary<int, decimal>();
    //    decimal dTaxAmt = 0;
    //    decimal dTotalTax = 0;
    //    decimal dOrderTotal = 0;
    //    try
    //    {


    //        //Initiate transaction
    //        //1. Update order qty
    //        foreach (DataRow dr in tblOrderDetail.Rows)
    //        {
    //            command.CommandText = "";
    //            command.Parameters.Clear();
    //            strSQL = null;
    //            if (bUpdateOrderDetail == true)
    //            {
    //                strSQL = XMLWrapper.getSQLString("updateOrderDetail");
    //                command.CommandText = strSQL[0];
    //                command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
    //                command.Parameters[strSQL[1]].Value = int.Parse(dr["MenuItemQty"].ToString());

    //                command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
    //                command.Parameters[strSQL[2]].Value = int.Parse(dr["OrderDetailID"].ToString());

    //                command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
    //                command.Parameters[strSQL[3]].Value = iOrderID;

    //                command.ExecuteNonQuery();
    //            }
    //            //next step - reduce inventory



    //            ////Loop thru the inventory association table and insert individual inventory item reduction entries
    //            //string strFilter;
    //            //strFilter= "menuitemid="+dr["MenuItemId"].ToString();
    //            //DataRow[] drInvForMnuItems;
    //            //drInvForMnuItems = ds.Tables[0].Select(strFilter);
    //            //foreach (DataRow drInvForMnuItem in drInvForMnuItems)
    //            //{
    //            //    //Cleanup
    //            //    command.CommandText = "";
    //            //    command.Parameters.Clear();
    //            //    strSQL = null;

    //            //    strSQL = XMLWrapper.getSQLString("insertInventoryReduction");
    //            //    command.CommandText = strSQL[0];

    //            //    command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
    //            //    command.Parameters[strSQL[1]].Value = int.Parse(drInvForMnuItem["invheaderid"].ToString());

    //            //    command.Parameters.Add(strSQL[2], MySqlDbType.Decimal);
    //            //    command.Parameters[strSQL[2]].Value = decimal.Parse(dr["MenuItemQty"].ToString()) * decimal.Parse(drInvForMnuItem["reduceinvqty"].ToString());

    //            //    command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
    //            //    command.Parameters[strSQL[3]].Value = iModBy;

    //            //    command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
    //            //    command.Parameters[strSQL[4]].Value = iOrderID;

    //            //    command.ExecuteNonQuery();
    //            //}

    //            //2. Select distinct tax ids for the order
    //            if (!dctTax.ContainsKey(int.Parse(dr["TaxID"].ToString())))
    //            {
    //                dctTax.Add(int.Parse(dr["TaxID"].ToString()), 0);
    //                if (dr["TaxID"].ToString() != "")
    //                {
    //                    sTaxIDs = sTaxIDs + int.Parse(dr["TaxID"].ToString()) + ",";
    //                }
    //            }

    //            dOrderTotal = dOrderTotal + (decimal.Parse(dr["MenuItemQty"].ToString())
    //                                            * decimal.Parse(dr["MenuItemCost"].ToString()));
    //        }

    //        //Remove last comma;
    //        sTaxIDs = sTaxIDs.Remove(sTaxIDs.LastIndexOf(','));

    //        sTaxArray = sTaxIDs.Split(',');
    //        //3. Get Tax percent for the order detail

    //        //Clean command object
    //        command.CommandText = "";
    //        command.Parameters.Clear();
    //        strSQL = null;

    //        strSQL = XMLWrapper.getSQLString("getTaxPercent");
    //        command.CommandText = strSQL[0];

    //        command = clsUtil.createInString(command, sTaxArray);

    //        command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
    //        command.Parameters[strSQL[1]].Value = iHotelID;

    //        MySqlDataReader reader = command.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            dctTax[int.Parse(reader["menutaxid"].ToString())] = decimal.Parse(reader["taxpercent"].ToString());

    //        }

    //        reader.Close();
    //        reader = null;

    //        foreach (KeyValuePair<int, decimal> entry in dctTax)
    //        {
    //            // do something with entry.Value or entry.Key

    //            foreach (DataRow dr in tblOrderDetail.Rows)
    //            {
    //                //4. Loop through the order detail table.
    //                //4. Total tax for a given tax type
    //                if (int.Parse(entry.Key.ToString()) == int.Parse(dr["TaxID"].ToString()))
    //                {
    //                    dTaxAmt = dTaxAmt + ((entry.Value / 100) * int.Parse(dr["MenuItemQty"].ToString())
    //                                                                * int.Parse(dr["MenuItemCost"].ToString()));
    //                }
    //            }
    //            try
    //            {
    //                //5. Check if bill detail exists for a given bill
    //                //5. If no, Insert bill detail, if not - update bill detail

    //                command.CommandText = "";
    //                command.Parameters.Clear();
    //                strSQL = null;
    //                strSQL = XMLWrapper.getSQLString("insertOrderTax");
    //                command.CommandText = strSQL[0];

    //                command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
    //                command.Parameters[strSQL[1]].Value = iOrderID;

    //                command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
    //                command.Parameters[strSQL[2]].Value = (int.Parse(entry.Key.ToString()));

    //                command.Parameters.Add(strSQL[3], MySqlDbType.Decimal);
    //                command.Parameters[strSQL[3]].Value = dTaxAmt;

    //                command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
    //                command.Parameters[strSQL[4]].Value = iModBy;

    //                command.ExecuteNonQuery();

    //            }
    //            catch (MySqlException ex)
    //            {
    //                if (ex.Number == 1062)
    //                {
    //                    command.CommandText = "";
    //                    command.Parameters.Clear();
    //                    strSQL = null;
    //                    strSQL = XMLWrapper.getSQLString("updateOrderTax");
    //                    command.CommandText = strSQL[0];

    //                    command.Parameters.Add(strSQL[1], MySqlDbType.Decimal);
    //                    command.Parameters[strSQL[1]].Value = dTaxAmt;

    //                    command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
    //                    command.Parameters[strSQL[2]].Value = iModBy;

    //                    command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
    //                    command.Parameters[strSQL[3]].Value = iOrderID;

    //                    command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
    //                    command.Parameters[strSQL[4]].Value = (int.Parse(entry.Key.ToString()));

    //                    command.ExecuteNonQuery();
    //                }
    //            }


    //            dTotalTax = dTaxAmt + dTotalTax;
    //        }

    //        //6. Check if bill header exists for given order ID
    //        //6. If yes - Insert bill header; if not - update bill header

    //        //try
    //        //{
    //        //    //5. Check if bill detail exists for a given bill
    //        //5. If no, Insert bill detail, if not - update bill detail
    //        if (iBillID == -1)
    //        {
    //            command.CommandText = "";
    //            command.Parameters.Clear();
    //            strSQL = null;
    //            strSQL = XMLWrapper.getSQLString("insertBillHeader");
    //            command.CommandText = strSQL[0];

    //            command.Parameters.Add(strSQL[1], MySqlDbType.Decimal);
    //            command.Parameters[strSQL[1]].Value = dOrderTotal + dTotalTax;

    //            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
    //            command.Parameters[strSQL[2]].Value = (Constants.BillStatus.GENERATED);

    //            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
    //            command.Parameters[strSQL[3]].Value = iCustID;

    //            command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
    //            command.Parameters[strSQL[4]].Value = iModBy;

    //            command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
    //            command.Parameters[strSQL[5]].Value = iOrderID;

    //            command.ExecuteNonQuery();
    //            iBillID = int.Parse(command.LastInsertedId.ToString());
    //        }
    //        else
    //        {
    //            command.CommandText = "";
    //            command.Parameters.Clear();
    //            strSQL = null;
    //            strSQL = XMLWrapper.getSQLString("updateBillHeader");
    //            command.CommandText = strSQL[0];

    //            command.Parameters.Add(strSQL[1], MySqlDbType.Decimal);
    //            command.Parameters[strSQL[1]].Value = dOrderTotal + dTotalTax;

    //            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
    //            command.Parameters[strSQL[2]].Value = iModBy;

    //            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
    //            command.Parameters[strSQL[3]].Value = iBillID;

    //            command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
    //            command.Parameters[strSQL[4]].Value = iOrderID;

    //            command.ExecuteNonQuery();
    //        }
    //        //}
    //        //catch (MySqlException ex)
    //        //{
    //        //    if (ex.Number == 1062)
    //        //    {

    //        //    }
    //        //}
    //        //7. Complete transaction.

    //        //trTransaction.Commit();

    //        return iBillID;

    //    }
    //    catch (Exception ex)
    //    {
    //        //trTransaction.Rollback();
    //        throw ex;
    //    }

    //    finally
    //    {
    //        Connection.closeConnection(con);
    //    }
    //}

    public DataSet getOrderTax(int iOrderID)
    {
        MySqlConnection con = null;
        MySqlTransaction trTransaction;
        MySqlCommand command = new MySqlCommand();
        string[] strSQL;
        MySqlDataAdapter da;
        DataSet ds;
        con = Connection.getConnection();
        command.Connection = con;
        trTransaction = con.BeginTransaction();
        command.Transaction = trTransaction;
        try
        {
            //8. Fetch and return tax detail and total cost and billid
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;
            strSQL = XMLWrapper.getSQLString("getOrderTax");
            command.CommandText = strSQL[0];

            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderID;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = iOrderID;


            command.Connection = con;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);
            //orderOutput.BillID = iBillID;
            //orderOutput.OrderTotal = dOrderTotal + dTotalTax;

            return ds;
        }
        finally
        {
            Connection.closeConnection(con);
        }
    }

    public string[] getOrderTaxForBill(int iOrderID)
    {
        string[] sTotalTax;
        MySqlConnection con = null;
        try
        {
            sTotalTax = new string[2];
            string[] strSQL = XMLWrapper.getSQLString("rptGetBillTax");

            MySqlCommand command = new MySqlCommand(strSQL[0]);

            command.CommandText = strSQL[0];

            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderID;

            con = Connection.getConnection();
            command.Connection = con;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sTotalTax[0] = reader["taxamt"].ToString();
            }

            reader.Close();

            //cleanup
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;
            reader = null;

            strSQL = XMLWrapper.getSQLString("rptGetOrderDscnt");

            command.CommandText = strSQL[0];

            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderID;

            con = Connection.getConnection();
            command.Connection = con;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                sTotalTax[1] = reader["discountpercent"].ToString();
            }

            reader.Close();



            return sTotalTax;
        }
        finally
        {
            Connection.closeConnection(con);
        }

    }


    public string[] getOrderAmount(int iBillID, int iOrderID)
    {
        MySqlConnection con = null;
        string[] sBillDetail;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getOrderAmount");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iBillID;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = iOrderID;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = (int)Constants.OrderStatus.INPROC;

            con = Connection.getConnection();
            command.Connection = con;

            MySqlDataReader reader = command.ExecuteReader();
            sBillDetail = new string[4];
            while (reader.Read())
            {
                sBillDetail[0] = reader["billid"].ToString();
                sBillDetail[1] = reader["billnumber"].ToString();
                sBillDetail[2] = reader["billamt"].ToString();
                sBillDetail[3] = iOrderID.ToString();

            }

            return sBillDetail;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public void updateOrderTransaction(int iOrderID, int iBillID, int iModBy,
                                            int iPaymenttype, int iNotes10,
                                            int iNotes20, int iNotes50,
                                            int iNotes100, int iNotes500,
                                            int iNotes1000, 
                                            decimal dDiscntPrcnt, 
                                            string sDiscntReason, 
                                            decimal dChargedAmt,
                                            int iOrderstatus,int iBillStatus)
    {
        MySqlConnection con = null;
        MySqlTransaction trTransaction;
        MySqlCommand command = new MySqlCommand();
        string[] strSQL;
        con = Connection.getConnection();
        command.Connection = con;
        trTransaction = con.BeginTransaction();
        command.Transaction = trTransaction;
        try
        {
            //Update orderheader status
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;

            strSQL = XMLWrapper.getSQLString("updateOrderStatus");
            command.CommandText = strSQL[0];
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderstatus;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = iModBy;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = iOrderID;

            command.ExecuteNonQuery();

            //Update bill detail
            command.CommandText = "";
            command.Parameters.Clear();
            strSQL = null;

            strSQL = XMLWrapper.getSQLString("updateBillStatus");
            command.CommandText = strSQL[0];
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iPaymenttype;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = iNotes10;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = iNotes20;

            command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
            command.Parameters[strSQL[4]].Value = iNotes50;

            command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
            command.Parameters[strSQL[5]].Value = iNotes100;

            command.Parameters.Add(strSQL[6], MySqlDbType.Int32);
            command.Parameters[strSQL[6]].Value = iNotes500;

            command.Parameters.Add(strSQL[7], MySqlDbType.Int32);
            command.Parameters[strSQL[7]].Value = iNotes1000;

            command.Parameters.Add(strSQL[8], MySqlDbType.Int32);
            command.Parameters[strSQL[8]].Value = iBillStatus;

            command.Parameters.Add(strSQL[9], MySqlDbType.Int32);
            command.Parameters[strSQL[9]].Value = iModBy;

            command.Parameters.Add(strSQL[10], MySqlDbType.Int32);
            command.Parameters[strSQL[10]].Value = iBillID;

            command.Parameters.Add(strSQL[11], MySqlDbType.Decimal);
            command.Parameters[strSQL[11]].Value = dDiscntPrcnt;
            
            command.Parameters.Add(strSQL[12], MySqlDbType.VarChar);
            command.Parameters[strSQL[12]].Value = sDiscntReason;

            command.Parameters.Add(strSQL[13], MySqlDbType.Decimal);
            command.Parameters[strSQL[13]].Value = dChargedAmt;

            command.ExecuteNonQuery();

            trTransaction.Commit();

        }
        catch (Exception ex)
        {
            trTransaction.Rollback();
            throw ex;
        }
        finally
        {
            Connection.closeConnection(con);
        }
    }

    public DataSet getCustBill(int iOrderID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("rptGetBill");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iOrderID;

            con = Connection.getConnection();
            command.Connection = con;
            da = new MySqlDataAdapter(command);
            ds = new DataSet("dsCustBill");

            da.Fill(ds);

            //strSQL = XMLWrapper.getSQLString("rptGetBillTax");
            //command.Parameters.Clear();
            //command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            //command.Parameters[strSQL[1]].Value = iOrderID;
            //da.Fill(ds);

            return ds;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public DataSet getTest1(int sHotelID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("FrozenColumns1");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = sHotelID;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = (int)Constants.OrderStatus.INPROC;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = (int)Constants.OrderType.INHSE;

            con = Connection.getConnection();
            command.Connection = con;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);

            return ds;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

    public DataSet getTest2(int sHotelID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("FrozenColumns2");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = sHotelID;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = (int)Constants.OrderStatus.INPROC;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = (int)Constants.OrderType.INHSE;

            con = Connection.getConnection();
            command.Connection = con;
            da = new MySqlDataAdapter(command);
            ds = new DataSet();
            da.Fill(ds);

            return ds;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }

}



