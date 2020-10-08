using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for clsDatabase
/// </summary>
public class DatabaseClass
{
    private static string dbName;
    private static string serverName;

    private DataSet ds;
    private SqlCommand cmd;
    private SqlDataAdapter da;


    private static string connectionString;
    public SqlConnection cn;

    public static string DBName
    {
        get { return DatabaseClass.dbName; }
        set { DatabaseClass.dbName = value; }
    }


    public static string ServerName
    {
        get { return DatabaseClass.serverName; }
        set { DatabaseClass.serverName = value; }
    }

    public static string DatabaseClassConnectionString
    {
        get { return connectionString; }
    }


    #region Constructors

    /// <summary>
    /// Creates a connection to the database using the connection string saved in app.config
    /// </summary>
    public DatabaseClass()
    {
        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ToString();
        cn = new SqlConnection(connectionString);
    }

    #endregion


    /// <summary>
    /// Opens a connection to the database
    /// </summary>
    public void OpenConnection()
    {
        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// Closes the open connection
    /// </summary>
    public void CloseConnection()
    {
        try
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    /// <summary>
    ///  To Execute SQL statement that returns result in rows
    /// </summary>
    /// <param name="sqlStmt">SQL Statement</param>
    /// <returns>result rows</returns>
    public DataTable ExecuteQuery(string sqlStmt)
    {
        cmd = new SqlCommand(sqlStmt, cn);
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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
    /// <param name="cmd">QL command containing SQL Statement</param>
    /// <returns>result rows</returns>
    public DataTable ExecuteQuery(SqlCommand cmd)
    {
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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
        int recordsAffected;

        try
        {
            cmd = new SqlCommand(sql, cn);

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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
    public int ExecuteNonQuery(SqlCommand cmd)
    {
        int recordsAffected;

        try
        {
            cmd.Connection = cn;

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
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
            cmd = new SqlCommand(sql, cn);

            if (cn.State != ConnectionState.Open)
                cn.Open();

            recordsAffected = cmd.ExecuteNonQuery();
            if (recordsAffected == 1)
            {
                sql = string.Format("select ident_current('{0}')", tableName);
                returnValue = Int32.Parse(ExecuteScalar(sql).ToString());
                return returnValue;
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        // return recordsAffected;
    }


    /// <summary>
    /// To execute SQL Statement that returns one value
    /// </summary>
    /// <param name="sql">SQL statement</param>
    /// <returns>Retrieved value</returns>
    public Object ExecuteScalar(string sql)
    {
        Object returnValue;
        cmd = new SqlCommand(sql, cn);

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            returnValue = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }

        /*
        if (returnValue == null)
            return 0;
        else
         * ?*/
        //return returnValue;
        return (returnValue == null ? 0 : returnValue);
    }

    /// <summary>
    /// To execute SQL Statement that returns one value
    /// </summary>
    /// <param name="cmd">SQL command containing SQL statement</param>
    /// <returns>Retrieved value</returns>
    public decimal? ExecuteScalar(SqlCommand cmd)
    {
        decimal returnValue = 0;

        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();

            returnValue = (decimal)cmd.ExecuteScalar();
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public decimal? ExecuteScalarNullable(string sql)
    {
        decimal? returnValue = 0;
        cmd = new SqlCommand(sql, cn);

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
