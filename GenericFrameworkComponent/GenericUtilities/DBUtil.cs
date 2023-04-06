using GenericFrameworkComponent.UIFrameworkUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.Utilities
{
    public class DBUtil
    {
        static string? connetionString;
        static SqlConnection? cnn;
        static string? sqlQuery;
        static SqlCommand? command;
        static SqlDataReader? dataReader;
        static string? queryResult;

        public static bool dbConfigFlagStatus()
        {
            bool flag = false;
            if (ExcelUtil.cs.dbConfigFlag.Equals(CommonConstants.flagYes))
            {
                flag = true;
            }
            return flag;
        }

        public static bool dbAutFlagStatus()
        {
            bool flag = false;
            if (ExcelUtil.cs.dbAuthFlag.Equals(CommonConstants.flagYes))
            {
                flag = true;
            }
            return flag;
        }

        public static SqlConnection initDBConnection(string dataSourceName, string dbName, string dbUsername, string dbPassword)
        {
            if (dbConfigFlagStatus())
            {
                if (dbAutFlagStatus())
                {
                    connetionString = "Data Source=" + dataSourceName + ";Initial Catalog=" + dbName + ";Integrated Security=True;";
                }
                else
                {
                    connetionString = "Data Source=" + dataSourceName + ";Initial Catalog=" + dbName + ";User ID=" + ExcelUtil.cs.dbUsername + ";Password=" + ExcelUtil.cs.dbPassword + "";
                }

                cnn = new SqlConnection(connetionString);
                LogUtil.infoLog("Initialising the DB connection with Data Source is = " + dataSourceName + " and Database name is = " + dbName);
            }

            return cnn;
        }

        public static void openDBConnection()
        {
            try
            {
                if (dbConfigFlagStatus())
                {
                    cnn.Open();
                    LogUtil.infoLog("DB Connection is open");
                }
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to open DB connection due to error - ");
            }
        }

        public static string designWhereClause(string tableName, string columnName, string value, string selectiveColumnName, bool flag)
        {
            if (dbConfigFlagStatus())
            {
                if (flag)
                {
                    sqlQuery = "SELECT * FROM[" + ExcelUtil.cs.dbName + "].[dbo].[" + tableName + "] WHERE [" + columnName + "] = '" + value + "'";
                }
                else
                {
                    if (selectiveColumnName.Length > 0)
                    {
                        sqlQuery = "SELECT [" + selectiveColumnName + "] FROM[" + ExcelUtil.cs.dbName + "].[dbo].[" + tableName + "] WHERE [" + columnName + "] = '" + value + "'";
                    }
                }

                LogUtil.infoLog("Designed where query is: " + sqlQuery);
            }

            return sqlQuery;
        }

        public static string executeQueryAndGetData(string sqlQuery)
        {
            try
            {
                if (dbConfigFlagStatus())
                {
                    LogUtil.infoLog("Executing query: " + sqlQuery);

                    command = new SqlCommand(sqlQuery, cnn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        queryResult = dataReader.GetValue(0).ToString().Trim();
                    }

                    dataReader.Close();
                    command.Dispose();

                    LogUtil.infoLog("Query result is " + queryResult);
                }
            }
            catch (Exception ex)
            {
                WebDriverUtils.catchBlockWithFailAndStop(ex, "Failed to execute query " + sqlQuery + " due to error ");
            }

            return queryResult;
        }

        public static void closeDBConnection()
        {
            if (dbConfigFlagStatus())
            {
                if (!cnn.State.Equals(CommonConstants.dbStatusClosed))
                {
                    cnn.Close();
                    LogUtil.infoLog("DataBase Connection is successfully closed");
                }
                else
                {
                    LogUtil.infoLog("DataBase Connection is already closed");
                }
            }
        }
    }
}
