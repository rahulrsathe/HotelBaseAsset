using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


/// <summary>
/// Summary description for dbConnection
/// </summary>
public class Connection
{
	public Connection()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    internal static MySqlConnection  getConnection()
    {
        try
        {

            MySqlConnection objCon = new MySqlConnection(ConfigurationManager.AppSettings["conString"]);
            objCon.Open();

            return objCon;
        }
        catch (MySqlException  ex)
        {
            throw new Exception(Resources.AppMessages.CANNOT_CONNECT.ToString() + ex.Message.ToString());
        }

    }

    internal MySqlConnection getConnection(string connectionString)
    {
        try
        {
            MySqlConnection objCon = new MySqlConnection(connectionString);
            objCon.Open();
            return objCon;
        }
        catch (MySqlException ex)
        {
            throw new Exception(Resources.AppMessages.CANNOT_CONNECT.ToString() + " " + ex.Message.ToString());
        }

    }


    internal static void closeConnection(MySqlConnection con)
    {
        try
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }

        }
        catch (MySqlException ex)
        {
            throw new Exception(Resources.AppMessages.CANNOT_CONNECT.ToString() + " "+ ex.Message.ToString());
        }
    }
}