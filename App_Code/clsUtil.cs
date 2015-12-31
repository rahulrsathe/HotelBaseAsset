using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for clsUtil
/// </summary>
public static class clsUtil
{
	 static clsUtil()
	{
		//
		// TODO: Add constructor logic here
		//
	}

     public static MySqlCommand createInString(MySqlCommand command, string[] sParams)
     {
         string[] paramNames = sParams.Select(
             (s, i) => "@tag" + i.ToString()
         ).ToArray();
         
         string inClause = string.Join(",", paramNames);

         command.CommandText = (string.Format(command.CommandText, inClause));

         using (command) {
             for(int i = 0; i < paramNames.Length; i++) {
                command.Parameters.AddWithValue(paramNames[i], sParams[i]);
             }
         } 
         return command;
     }

     public static DataSet getCodesByCategory(int iCatID)
     {
         MySqlConnection con = null;
         MySqlDataAdapter da;
         DataSet ds;
         try
         {
             string[] strSQL = XMLWrapper.getSQLString("getCodesByCategory");
             MySqlCommand command = new MySqlCommand(strSQL[0]);
             command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
             command.Parameters[strSQL[1]].Value = iCatID;
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
             da=null;
             ds = null;
         }
     }
     
}