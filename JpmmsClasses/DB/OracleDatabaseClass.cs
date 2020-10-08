using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.OracleClient;
//using Oracle.DataAccess.Client;


/// <summary>
/// Summary description for OracleDatabaseClass
/// </summary>
public class OracleDatabaseClass
{

    private static string dbName;
    private static string serverName;


    private DataSet ds;
    private OracleCommand cmd;
    private OracleDataAdapter da;


    public static string connectionString;
    public OracleConnection cn;

    public static string DBName
    {
        get { return OracleDatabaseClass.dbName; }
    }

    public static string ServerName
    {
        get { return OracleDatabaseClass.serverName; }
    }

    public string DatabaseClassConnectionString
    {
        get { return connectionString; }
    }


    #region Constructors

    /// <summary>
    /// Creates a connection to the database using the connection string saved in app.config
    /// </summary>
    public OracleDatabaseClass()
    {
        //this("AccountingStockConnectionString");
        connectionString = ConfigurationManager.ConnectionStrings["JPMMS_ConnectionString"].ToString(); 
        cn = new OracleConnection(connectionString);

        dbName = cn.DataSource;
        serverName = cn.DataSource;
    }


    /// <summary>
    /// Creates a connection to the database using the connection string saved in app.config
    /// </summary>
    public OracleDatabaseClass(string connectionStringName)
    {
        //connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
        cn = new OracleConnection(connectionStringName);

        dbName = cn.DataSource;
        serverName = cn.DataSource;
    }


    #endregion


    /// <summary>
    /// Opens a connection to the database
    /// </summary>
    public void OpenConnection()
    {
        if (cn.State != ConnectionState.Open)
            cn.Open();
    }


    /// <summary>
    /// Closes the open connection
    /// </summary>
    public void CloseConnection()
    {
        if (cn.State == ConnectionState.Open)
            cn.Close();
    }


    /// <summary>
    ///  To Execute SQL statement that returns result in rows
    /// </summary>
    /// <param name="sqlStmt">SQL Statement</param>
    /// <returns>result rows</returns>
    public DataTable ExecuteQuery(string sqlStmt)
    {
        cmd = new OracleCommand(sqlStmt, cn);
        da = new OracleDataAdapter(cmd);
        ds = new DataSet();

        cmd.CommandTimeout = 600;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return ds.Tables[0];
    }


    /// <summary>
    /// To Execute SQL command containing SQL Statement that returns result in rows
    /// </summary>
    /// <param name="cmd">SQL command containing SQL Statement</param>
    /// <returns>result rows</returns>
    public DataTable ExecuteQuery(OracleCommand cmd)
    {
        da = new OracleDataAdapter(cmd);
        ds = new DataSet();

        cmd.CommandTimeout = 600;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return ds.Tables[0];
    }


    /// <summary>
    /// To execute insert/update/delete SQL statement
    /// </summary>
    /// <param name="sql">insert/update/delete SQL statement</param>
    /// <returns>No. of rows affected by the statement</returns>
    public int ExecuteNonQuery(string sql)
    {
        int recordsAffected = 0;

        try
        {
            cmd = new OracleCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return recordsAffected;
    }


    /// <summary>
    /// To execute SQL command containing insert/update/delete SQL statement
    /// </summary>
    /// <param name="cmd">SQL command containing insert/update/delete SQL statement</param>
    /// <returns>No. of rows affected by the statement</returns>
    public int ExecuteNonQuery(OracleCommand cmd)
    {
        int recordsAffected = 0;
        cmd.CommandTimeout = 600;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return recordsAffected;
    }


    /// <summary>
    /// To execute SQL command containing insert SQL statement returning the new identity column value
    /// </summary>
    /// <param name="sql">Insert SQL Statement</param>
    /// <param name="tableName">Table affected by the insert statement</param>
    /// <returns>New identity value</returns>
    public int ExecuteInsertWithIDReturn(string sql, string tableName)
    {
        int returnValue, recordsAffected;

        try
        {
            cmd = new OracleCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
            if (recordsAffected == 1)
            {
                sql = string.Format("SELECT seq_{0}.CURRVAL from dual ", tableName);
                returnValue = Int32.Parse(ExecuteScalar(sql).ToString());
                return returnValue;
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public int ExecuteInsertWithIDReturn(OracleCommand cmd, string tableName)
    {
        int returnValue, recordsAffected;

        try
        {
            cmd.CommandTimeout = 600;
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            recordsAffected = cmd.ExecuteNonQuery();
            if (recordsAffected == 1)
            {
                string sql = string.Format("SELECT seq_{0}.CURRVAL from dual ", tableName);
                returnValue = Int32.Parse(ExecuteScalar(sql).ToString());
                return returnValue;
            }
            else
                return 0;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// To execute SQL Statement that returns one value
    /// </summary>
    /// <param name="sql">SQL statement</param>
    /// <returns>Retrieved value</returns>
    public Object ExecuteScalar(string sql)
    {
        Object returnValue;

        try
        {
            cmd = new OracleCommand(sql, cn);
            cmd.CommandTimeout = 600;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            returnValue = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return (returnValue == null ? 0 : returnValue);
        //if (returnValue == null)
        //    return 0;
        //else
        //    return returnValue;
    }


    /// <summary>
    /// To execute SQL Statement that returns one value
    /// </summary>
    /// <param name="cmd">SQL command containing SQL statement</param>
    /// <returns>Retrieved value</returns>
    public decimal ExecuteScalar(OracleCommand cmd)
    {
        decimal returnValue = 0;

        try
        {
            cmd.CommandTimeout = 600;
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            returnValue = (decimal)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return returnValue;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public decimal? ExecuteScalarNullable(string sql)
    {
        decimal? returnValue = 0;
        cmd = new OracleCommand(sql, cn);

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            returnValue = (decimal?)cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        return returnValue;
    }


}
