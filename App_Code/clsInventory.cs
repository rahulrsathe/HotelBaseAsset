using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for clsInventory
/// </summary>
public class Inventory
{
	public Inventory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void saveInventory(int iInventoryHeaderID, Decimal dcQty, string sInventoryAction, Decimal dcCost, DateTime dtBoughtUsedDt, int iModBy)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        MySqlCommand command = new MySqlCommand();
            
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("insertNewWasteInventory");
            command.CommandText = strSQL[0];
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iInventoryHeaderID;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = dcQty;

            command.Parameters.Add(strSQL[3], MySqlDbType.Int32);
            command.Parameters[strSQL[3]].Value = sInventoryAction;

            command.Parameters.Add(strSQL[4], MySqlDbType.Decimal);
            command.Parameters[strSQL[4]].Value = dcCost;

            command.Parameters.Add(strSQL[5], MySqlDbType.Datetime);
            command.Parameters[strSQL[5]].Value = dtBoughtUsedDt;


            command.Parameters.Add(strSQL[6], MySqlDbType.Int32);
            command.Parameters[strSQL[6]].Value = iModBy;

            //OrderID for inventory action will be -1
            command.Parameters.Add(strSQL[7], MySqlDbType.Int32);
            command.Parameters[strSQL[7]].Value = -1;

            command.Parameters.Add(strSQL[8], MySqlDbType.Int32);
            command.Parameters[strSQL[8]].Value = -1;
            
            con = Connection.getConnection();
            command.Connection = con;
            command.ExecuteNonQuery();
        }
        finally
        {
            Connection.closeConnection(con);
           
        }
        
    }
    public DataSet getInventoryHeaderItemsbyCat(int iInventoryTypeID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getInventoryHeaderItemsbyCat");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iInventoryTypeID;
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
            da = null;
            ds = null;
        }
    }

    public string  getInvMeasureByInvID(int invHeaderID)
    {
        MySqlConnection con = null;
        string  sMeasure="";
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getInventoryMeasureByInvID");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = invHeaderID;
              
            con = Connection.getConnection();
            command.Connection = con;

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sMeasure  = reader["Measure"].ToString();
                 
            }

            return sMeasure ;

        }

        finally
        {
            Connection.closeConnection(con);
        }
    }


}