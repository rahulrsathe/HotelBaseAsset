using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
/// <summary>
/// Summary description for clsUserAuth
/// </summary>
public class UserAuth
{
    public UserAuth()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string[] validateLogin(string memberID, string password)
    {
        string[] userDetails;
        userDetails = null;
        MySqlConnection con = null;
        try
        {

            string[] strSQL = XMLWrapper.getSQLString("validateLogin");

            MySqlCommand command = new MySqlCommand(strSQL[0]);
            command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
            command.Parameters[strSQL[1]].Value = memberID;

            command.Parameters.Add(strSQL[2], MySqlDbType.VarChar);
            command.Parameters[strSQL[2]].Value = password;

            con = Connection.getConnection();
            command.Connection = con;
            MySqlDataReader reader = command.ExecuteReader();
            userDetails = new string[6];
            while (reader.Read())
            {
                userDetails[0] = reader["employee_id"].ToString();
                userDetails[3] = reader["FullName"].ToString();
                userDetails[2] = reader["role_id"].ToString();
                userDetails[1] = reader["login_name"].ToString();
                userDetails[4] = reader["HotelName"].ToString();
                userDetails[5] = reader["hotelid"].ToString();
            }

            if (
                userDetails[0] == null ||
                userDetails[1] == null ||
                userDetails[2] == null ||
                userDetails[3] == null ||
                userDetails[4] == null  
            )
            {
                userDetails = null;
                //throw new Exception(Resources.AppMessages.AUTH_FAILED.ToString());
            }
                reader.Close();
                return userDetails;
        }

        finally
        {
            Connection.closeConnection(con);
        }
    }
    public bool validateRoleAccess(string pageName, long roleID)
    {
            MySqlConnection con = null;
            try
            {
               int hasAccess=0;

                string[] strSQL = XMLWrapper.getSQLString("validateRoleAccess");

                MySqlCommand command = new MySqlCommand(strSQL[0]);
                command.Parameters.Add(strSQL[1], MySqlDbType.VarChar);
                command.Parameters[strSQL[1]].Value = pageName.ToUpper();

                command.Parameters.Add(strSQL[2], MySqlDbType.Int64  );
                command.Parameters[strSQL[2]].Value = roleID;

                con = Connection.getConnection();
                command.Connection = con;
                MySqlDataReader reader = command.ExecuteReader();

               
                while (reader.Read())
                {
                    hasAccess =  hasAccess+1;
                }

                if (hasAccess  > 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            finally
            {
                Connection.closeConnection(con);
            }

        }

    }
