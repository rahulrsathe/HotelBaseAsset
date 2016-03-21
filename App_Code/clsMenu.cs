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