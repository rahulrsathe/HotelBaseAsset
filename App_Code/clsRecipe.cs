using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;


/// <summary>
/// Summary description for clsRecipe
/// </summary>
public class Recipe
{
    public Recipe()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void deleteRecipeInvAssn(int iInvMnuAssnID, int iModBy)
    {
        MySqlConnection con = null;
        MySqlDataAdapter da;
        MySqlCommand command = new MySqlCommand();

        try
        {
            string[] strSQL = XMLWrapper.getSQLString("deleteInventoryData");
            command.CommandText = strSQL[0];
            command.Parameters.Add(strSQL[1], MySqlDbType.Int32);
            command.Parameters[strSQL[1]].Value = iInvMnuAssnID ;

            command.Parameters.Add(strSQL[2], MySqlDbType.Int32);
            command.Parameters[strSQL[2]].Value = iModBy;

            con = Connection.getConnection();
            command.Connection = con;
            command.ExecuteNonQuery();
        }
        finally
        {
            Connection.closeConnection(con);

        }

    }
    
}