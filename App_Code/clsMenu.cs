using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for clsMenu
/// </summary>
public class HotelMenu
{
	public HotelMenu()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void insertNewMenuItem(int iMenuType, string sMenuName, decimal dMenuCost, int iModBy, int iHotelid ,
        Int32 [] iMenutxassn)
    {
        MySqlConnection con = null;
        MySqlCommand command = new MySqlCommand();

        try
        {
            string[] strSQL = XMLWrapper.getSQLString("InsertNewMenu");
            command.CommandText = strSQL[0];
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iMenuType;

            command.Parameters.Add(strSQL[2], MySqlDbType.String);
            command.Parameters[strSQL[2]].Value = sMenuName;

            command.Parameters.Add(strSQL[3], MySqlDbType.Decimal);
            command.Parameters[strSQL[3]].Value = dMenuCost;

            command.Parameters.Add(strSQL[4], MySqlDbType.Int32);
            command.Parameters[strSQL[4]].Value = iModBy;

            command.Parameters.Add(strSQL[5], MySqlDbType.Int32);
            command.Parameters[strSQL[5]].Value = iHotelid;


            command.Parameters.Add(strSQL[6], MySqlDbType.Int32);
            command.Parameters[strSQL[6]].Value = iMenutxassn;

            con = Connection.getConnection();
            command.Connection = con;
            command.ExecuteNonQuery();
        }
        finally
        {
            Connection.closeConnection(con);

        }

    }

    public DataSet getRecipeForMenu(int iMenuItemID)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getRecipeForMenu");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
            command.Parameters[strSQL[1]].Value = iMenuItemID;
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


    public DataSet getMenuItemsForRecipe()
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getMenuItemsForRecipe");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
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


    public DataSet getMenuItemsByType(string sMenuType)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getMenuItemsByType");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
            command.Parameters[strSQL[1]].Value = sMenuType;
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


    public DataSet getMenuForMgmt()
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        DataSet ds;
        try
        {
            string[] strSQL = XMLWrapper.getSQLString("getMenuMgmt");
            MySqlCommand command = new MySqlCommand(strSQL[0]);
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