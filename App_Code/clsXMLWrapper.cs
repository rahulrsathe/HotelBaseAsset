using System;
using System.Data;
using System.Data.SqlClient;
using System.Resources;
using System.Xml;
using System.Collections;
using System.Configuration;

/// <summary>
/// Summary description for clsXMLWrapper
/// </summary>
/// 
public class XMLWrapper
{

    private static readonly string SQLFilePath;


    static XMLWrapper()
    {
        SQLFilePath = ConfigurationManager.AppSettings["SQLXMLFile"].ToString();
    }


    public static string[] getSQLString(string queryID)
    {
        string[] command;
        DataSet ds = new DataSet();

        try
        {
            ds.ReadXml(SQLFilePath);

            DataTable tbl = ds.Tables[queryID];
            string parameters = tbl.Rows[0]["params"].ToString();

            string[] parameNames = parameters.Split('|');
            command = new string[parameNames.Length + 1];
            command[0] = tbl.Rows[0]["command"].ToString();

            command[0] = filterSQLChars(command[0]);

            for (int i = 1; i <= command.Length - 1; i++)
            {
                command[i] = parameNames[i - 1];
            }

            return command;
        }
        catch (Exception ex)
        {
            throw new Exception(Resources.AppMessages.CANNOT_READ_SQL_XML.ToString() + ex.Message.ToString());
        }
        finally
        {
            ds = null;

        }
    }

    private static string filterSQLChars(string checkSQL)
    {
        checkSQL = checkSQL.Replace("&lt;", " < ");
        checkSQL = checkSQL.Replace("&gt;", " > ");
        return checkSQL;

    }
}
 