using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections;
namespace UtilitiesLibrary
{
    namespace Data
    {
        public enum ExecuteType
        {
            SqlDataAdapterFill,
            ExecuteNonQuery,
            ExecuteReader,
            ExecuteScalar,
            ExecuteXmlReader

        }
        /// <summary>
        /// 
        /// </summary>
        public class DataBaseEngine
        {

            #region Private Members
            private string serverName;
            private string databaseName;
            private string userName;
            private string password;
            private string connectionString;
            private SqlTransaction transactionObject;
            private Exception erorrValue;
            #endregion

            #region Internal Properties
            /// <summary>
            /// Internal only For Security Reasons
            /// </summary>
            internal string Password
            {
                get { return password; }
                set { password = value; }
            }
            internal string ConnectionString
            {
                get { return connectionString; }
                set { connectionString = value; }
            }
            internal SqlTransaction TransactionObject
            {
                get { return transactionObject; }
                set { transactionObject = value; }
            }
            #endregion

            #region Public Properties
            public string DatabaseName
            {
                get { return databaseName; }

            }
            public string ServerName
            {
                get { return serverName; }

            }
            public string UserName
            {
                get { return userName; }

            }
            public int ConnectionTimeout
            {
                get
                {
                    SqlConnection ConnectionObject = null;
                    try
                    {
                        ConnectionObject = new SqlConnection(ConnectionString);
                        return ConnectionObject.ConnectionTimeout;
                    }
                    catch(Exception e)
                    {
                        this.erorrValue = e;
                        return Convert.ToInt32(false);
                    }
                    finally
                    {
                        ReleaseObjects(ref ConnectionObject);
                    }
                }
                set
                {
                    if (value >= 15 && value < int.MaxValue)
                    {
                        AppendConnectionTimeout(value);

                    }
                }
            }
            public Exception ErorrValue
            {
                get { return erorrValue; }

            }
            #endregion

            #region Private Methods
            private void CreateConnectionString(bool IntegratedSecurity)
            {
                StringBuilder sb = new StringBuilder("Data Source=SERVER;Initial Catalog=DATABASE;Integrated Security=True;");
                sb.Replace("SERVER", ServerName);
                sb.Replace("DATABASE", DatabaseName);
                if (IntegratedSecurity == false)
                {
                    sb.Replace("Integrated Security=True;", "User ID=");
                    sb.Append(UserName);
                    sb.Append(";Password=");
                    sb.Append(this.password);
                    sb.Append(';');
                }
                this.connectionString = sb.ToString();
            }
            private void AppendConnectionTimeout(int TimeOut)
            {
                StringBuilder sb = new StringBuilder(this.connectionString);
                int StartIndex = this.connectionString.IndexOf("Connect Timeout=");
                if (StartIndex > 0)
                {
                    sb.Remove(
                          StartIndex, this.connectionString.IndexOf(';', StartIndex) - StartIndex);
                    
                }
                sb.Append("Connect Timeout=");
                sb.Append(TimeOut.ToString());
                sb.Append(';');

                this.connectionString = sb.ToString();

            }
            /// <summary>
            /// AssignValues from web.config 
            /// </summary>
            /// <param name="connectionString"></param>
            private void AssignValues(string connectionString)
            {
                SqlConnection ConnectionObject = null;
                int IndexUserName, IndexServerName;
                try
                {
                    ConnectionObject = new SqlConnection(ConnectionString);
                    this.databaseName = ConnectionObject.Database;
                    IndexServerName = connectionString.IndexOf("Data Source=");
                    IndexUserName=connectionString.IndexOf("User ID=");
                    if (IndexServerName != -1)
                    {
                        IndexServerName += 12; // "Data Source=".Length
                        this.serverName = connectionString.Substring(
                            IndexServerName, connectionString.IndexOf(';', IndexServerName) - IndexServerName);
                    }
                    if (IndexUserName != -1)
                    {
                        IndexUserName += 8; //"User ID=".Length
                        this.userName = connectionString.Substring(
                            IndexUserName, connectionString.IndexOf(';', IndexUserName) - IndexUserName);
                    }
                }
                catch(Exception e)
                {
                    this.erorrValue = e;
                }
                finally
                {
                    ReleaseObjects(ref ConnectionObject);
                }
            }
            private void ReleaseConnectionObject(ref SqlConnection Connection)
            {
                if (Connection != null)
                {
                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();
                    Connection.Dispose();
                    Connection = null;

                }
            }
            private void ReleaseTransactionObject(ref SqlTransaction Transaction)
            {
                if (Transaction != null)
                {
                    SqlConnection con = transactionObject.Connection;
                    if (Transaction.Connection != null)
                        ReleaseConnectionObject(ref con);
                    Transaction.Dispose();
                    Transaction = null;

                }
            }
            private void ReleaseCommandObject(ref SqlCommand Command)
            {
                if (Command != null)
                {
                    Command.Dispose();
                    Command = null;
                }

            }
            private void ReleaseDataAdapterObject(ref SqlDataAdapter DataAdapter)
            {
                if (DataAdapter != null)
                {
                    DataAdapter.Dispose();
                    DataAdapter = null;
                }

            }
            private void ReleaseDataReaderObject(ref SqlDataReader DataReader)
            {
                if (DataReader != null)
                {
                    if (DataReader.IsClosed == false)
                        DataReader.Close();
                    DataReader.Dispose();
                    DataReader = null;
                }

            }
            private void ReleaseDataSetObject(ref DataSet dataSet)
            {
                if (dataSet != null)
                {
                    dataSet.Dispose();
                    dataSet = null;
                }

            }
            private void InitializeObjects(string StordName, out SqlConnection ConnectionObject, out SqlCommand CommandObject, out SqlDataAdapter DataAdapterObject, out DataSet DataSetObject)
            {
                ConnectionObject = new SqlConnection(this.ConnectionString);
                CommandObject = new SqlCommand(StordName, ConnectionObject);
                CommandObject.CommandType = CommandType.StoredProcedure;
                DataAdapterObject = new SqlDataAdapter(CommandObject);
                DataSetObject = new DataSet();
            }
            private void InitializeObjects(string StordName, StordeParameters ParamtersValues, out SqlConnection ConnectionObject, out SqlCommand CommandObject, out SqlDataAdapter DataAdapterObject, out DataSet DataSetObject)
            {
                InitializeObjects(StordName, out ConnectionObject, out CommandObject, out DataAdapterObject, out DataSetObject);
                foreach (DictionaryEntry item in ParamtersValues.AllParameters)
                {
                    CommandObject.Parameters.AddWithValue(
                        item.Key.ToString(), item.Value);
                }
            }
            private void InitializeObjects(string StordName, out SqlCommand CommandObject, out SqlDataAdapter DataAdapterObject, out DataSet DataSetObject)
            {
                CommandObject = transactionObject.Connection.CreateCommand();
                CommandObject.CommandText = StordName;
                CommandObject.CommandType = CommandType.StoredProcedure;
                CommandObject.Transaction = transactionObject;
                DataAdapterObject = new SqlDataAdapter(CommandObject);
                DataSetObject = new DataSet();
            }
            private void InitializeObjects(string StordName, StordeParameters Paramters, out SqlCommand CommandObject, out SqlDataAdapter DataAdapterObject, out DataSet DataSetObject)
            {
                InitializeObjects(StordName, out CommandObject, out DataAdapterObject, out DataSetObject);
                foreach (DictionaryEntry item in Paramters.AllParameters)
                {
                    CommandObject.Parameters.AddWithValue(
                        item.Key.ToString(), item.Value);
                }
            }
            private object WithTransactions(string StordName, StordeParameters Paramters, ExecuteType eXecuteType)
            {
                object ObjectReturn = null;
                if (transactionObject.Connection.State == ConnectionState.Open)
                {
                    SqlCommand CommandObject;
                    SqlDataAdapter DataAdapterObject;
                    DataSet DataSetObject;
                    InitializeObjects(StordName, Paramters, out CommandObject, out DataAdapterObject, out DataSetObject);
                    try
                    {
                        switch (eXecuteType)
                        {
                            case ExecuteType.ExecuteNonQuery:
                                ObjectReturn = CommandObject.ExecuteNonQuery();
                                break;
                            case ExecuteType.ExecuteReader:
                                ObjectReturn = CommandObject.ExecuteReader();
                                break;
                            case ExecuteType.ExecuteScalar:
                                ObjectReturn = CommandObject.ExecuteScalar();
                                break;
                            case ExecuteType.ExecuteXmlReader:
                                ObjectReturn = CommandObject.ExecuteXmlReader();
                                break;
                            case ExecuteType.SqlDataAdapterFill:
                                DataAdapterObject.Fill(DataSetObject);
                                ObjectReturn = DataSetObject;
                                break;
                            default:
                                ObjectReturn = null;
                                break;
                        }
                        return ObjectReturn;

                    }
                    catch (Exception e)
                    {
                        erorrValue = e;
                        ReleaseObjects(ref CommandObject);
                        ReleaseObjects(ref DataAdapterObject);
                        ReleaseObjects(ref DataSetObject);
                        if (RollbackTransaction())
                            return "Transaction has Rollback";
                        else
                            return null;
                    }
                }
                else
                {
                    this.erorrValue = new Exception("Connection has Closed");
                    return null;
                }
            }
            private object WithOutTransactions(string StordName, StordeParameters Paramters, ExecuteType eXecuteType)
            {
                object ObjectReturn = null;
                SqlConnection ConnectionObject;
                SqlCommand CommandObject;
                SqlDataAdapter DataAdapterObject;
                DataSet DataSetObject;
                if (TryConnectiongToServer() && Security.IsNullOrEmpty(StordName))
                {
                    InitializeObjects(StordName, Paramters, out ConnectionObject, out CommandObject, out DataAdapterObject, out DataSetObject);
                    try
                    {
                        ConnectionObject.Open();
                        switch (eXecuteType)
                        {
                            case ExecuteType.ExecuteNonQuery:
                                ObjectReturn = CommandObject.ExecuteNonQuery();
                                break;
                            case ExecuteType.ExecuteReader:
                                ObjectReturn = CommandObject.ExecuteReader();
                                break;
                            case ExecuteType.ExecuteScalar:
                                ObjectReturn = CommandObject.ExecuteScalar();
                                break;
                            case ExecuteType.ExecuteXmlReader:
                                ObjectReturn = CommandObject.ExecuteXmlReader();
                                break;
                            case ExecuteType.SqlDataAdapterFill:
                                DataAdapterObject.Fill(DataSetObject);
                                ObjectReturn = DataSetObject;
                                break;
                            default:
                                ObjectReturn = null;
                                break;
                        }
                        return ObjectReturn;
                    }
                    catch (Exception e)
                    {
                        this.erorrValue = e;
                        return null;
                    }
                    finally
                    {
                        if (ObjectReturn as SqlDataReader == null || !((SqlDataReader)ObjectReturn).HasRows)
                            ReleaseObjects(ref ConnectionObject);
                        ReleaseObjects(ref CommandObject);
                        ReleaseObjects(ref DataAdapterObject);
                        ReleaseObjects(ref DataSetObject);
                    }

                }
                else
                {
                    this.erorrValue = new NullReferenceException();
                    return null;
                }
            }
            private object WithTransactions(string StordName, ExecuteType eXecuteType)
            {
                object ObjectReturn = null;
                if (transactionObject.Connection.State == ConnectionState.Open)
                {
                    SqlCommand CommandObject;
                    SqlDataAdapter DataAdapterObject;
                    DataSet DataSetObject;
                    InitializeObjects(StordName, out CommandObject, out DataAdapterObject, out DataSetObject);
                    try
                    {
                        switch (eXecuteType)
                        {
                            case ExecuteType.ExecuteNonQuery:
                                ObjectReturn = CommandObject.ExecuteNonQuery();
                                break;
                            case ExecuteType.ExecuteReader:
                                ObjectReturn = CommandObject.ExecuteReader();
                                break;
                            case ExecuteType.ExecuteScalar:
                                ObjectReturn = CommandObject.ExecuteScalar();
                                break;
                            case ExecuteType.ExecuteXmlReader:
                                ObjectReturn = CommandObject.ExecuteXmlReader();
                                break;
                            case ExecuteType.SqlDataAdapterFill:
                                DataAdapterObject.Fill(DataSetObject);
                                ObjectReturn = DataSetObject;
                                break;
                            default:
                                ObjectReturn = null;
                                break;
                        }
                        return ObjectReturn;
                    }
                    catch (Exception e)
                    {
                        erorrValue = e;
                        ReleaseObjects(ref CommandObject);
                        ReleaseObjects(ref DataAdapterObject);
                        ReleaseObjects(ref DataSetObject);
                        if (RollbackTransaction())
                            return "Transaction has Rollback";
                        else
                            return null;
                    }
                }
                else
                {
                    this.erorrValue = new Exception("Connection has Closed");
                    return null;
                }
            }
            private object WithOutTransactions(string StordName, ExecuteType eXecuteType)
            {
                object ObjectReturn = null;
                SqlConnection ConnectionObject;
                SqlCommand CommandObject;
                SqlDataAdapter DataAdapterObject;
                DataSet DataSetObject;
                if (TryConnectiongToServer() && Security.IsNullOrEmpty(StordName))
                {
                    InitializeObjects(StordName, out ConnectionObject, out CommandObject, out DataAdapterObject, out DataSetObject);
                    try
                    {
                        ConnectionObject.Open();
                        switch (eXecuteType)
                        {
                            case ExecuteType.ExecuteNonQuery:
                                ObjectReturn = CommandObject.ExecuteNonQuery();
                                break;
                            case ExecuteType.ExecuteReader:
                                ObjectReturn = CommandObject.ExecuteReader();
                                break;
                            case ExecuteType.ExecuteScalar:
                                ObjectReturn = CommandObject.ExecuteScalar();
                                break;
                            case ExecuteType.ExecuteXmlReader:
                                ObjectReturn = CommandObject.ExecuteXmlReader();
                                break;
                            case ExecuteType.SqlDataAdapterFill:
                                DataAdapterObject.Fill(DataSetObject);
                                ObjectReturn = DataSetObject;
                                break;
                            default:
                                ObjectReturn = null;
                                break;
                        }
                        return ObjectReturn;
                    }
                    catch (Exception e)
                    {
                        this.erorrValue = e;
                        return null;
                    }
                    finally
                    {
                        if (ObjectReturn as SqlDataReader == null || !((SqlDataReader)ObjectReturn).HasRows)
                            ReleaseObjects(ref ConnectionObject);
                        ReleaseObjects(ref CommandObject);
                        ReleaseObjects(ref DataAdapterObject);
                        ReleaseObjects(ref DataSetObject);

                    }

                }
                else
                {
                    this.erorrValue = new NullReferenceException();
                    return null;
                }
            }
            #endregion

            #region Internal Methods
            internal bool TryConnectiongToServer()
            {
                if (Security.IsNullOrEmpty(this.connectionString))
                {
                    SqlConnection Con
                            = new SqlConnection(this.connectionString);
                    try
                    {
                        Con.Open();
                        return true;
                    }
                    catch(Exception e)
                    {
                        this.erorrValue = e;
                        return false;
                    }
                    finally
                    {
                        ReleaseObjects(ref Con);
                    }
                }
                else
                    return false;

            }
            internal void ReleaseObjects(ref SqlConnection Connection, ref SqlCommand Command, ref SqlDataAdapter DataAdapter, ref DataSet dataSet)
            {
                ReleaseConnectionObject(ref Connection);
                ReleaseCommandObject(ref Command);
                ReleaseDataAdapterObject(ref DataAdapter);
                ReleaseDataSetObject(ref dataSet);
                GC.Collect();
            }
            internal void ReleaseObjects(ref SqlConnection Connection, ref SqlCommand Command, ref SqlDataReader DataReader, ref DataSet dataSet)
            {
                ReleaseConnectionObject(ref Connection);
                ReleaseCommandObject(ref Command);
                ReleaseDataReaderObject(ref DataReader);
                ReleaseDataSetObject(ref dataSet);
                GC.Collect();
            }
            internal void ReleaseObjects(ref SqlConnection Connection)
            {
                ReleaseConnectionObject(ref Connection);
                GC.Collect();
            }
            internal void ReleaseObjects(ref SqlTransaction Transaction)
            {
                ReleaseTransactionObject(ref Transaction);
                GC.Collect();
            }
            internal void ReleaseObjects(ref SqlCommand Command)
            {
                ReleaseCommandObject(ref Command);
                GC.Collect();
            }
            internal void ReleaseObjects(ref SqlDataAdapter DataAdapter)
            {
                ReleaseDataAdapterObject(ref DataAdapter);
                GC.Collect();
            }
            internal void ReleaseObjects(ref SqlDataReader DataReader)
            {
                ReleaseDataReaderObject(ref DataReader);
                GC.Collect();
            }
            internal void ReleaseObjects(ref DataSet dataSet)
            {
                ReleaseDataSetObject(ref dataSet);
                GC.Collect();
            }
            #endregion

            #region Public Methods
            /// <summary>
            /// 
            /// </summary>
            /// <param name="StordName"></param>
            /// <param name="eXecuteType"></param>
            /// <returns></returns>
            public object ExecuteSotord(string StordName, ExecuteType eXecuteType)
            {
                if (transactionObject == null)
                    return WithOutTransactions(StordName, eXecuteType);
                else
                    return WithTransactions(StordName, eXecuteType);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="StordName"></param>
            /// <param name="Paramters"></param>
            /// <param name="eXecuteType"></param>
            /// <returns></returns>
            public object ExecuteSotord(string StordName, StordeParameters Paramters, ExecuteType eXecuteType)
            {
                if (transactionObject == null)
                    return WithOutTransactions(StordName, Paramters, eXecuteType);
                else
                    return WithTransactions(StordName, Paramters, eXecuteType);

            }
            //Transaction.Current.Rollback();
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool BeginTransaction()
            {
                SqlConnection ConnectionObject;
                if (TryConnectiongToServer())
                {
                    try
                    {
                        ConnectionObject = new SqlConnection(this.ConnectionString);
                        ConnectionObject.Open();
                        TransactionObject = ConnectionObject.BeginTransaction();//IsoLevel
                        return true;
                    }
                    catch (Exception e)
                    {
                        erorrValue = e;
                        transactionObject = null;
                        return false;
                    }
                }
                else
                    return false;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="IsoLevel"></param>
            /// <returns></returns>
            public bool BeginTransaction(IsolationLevel IsoLevel)
            {
                SqlConnection ConnectionObject;
                if (TryConnectiongToServer())
                {
                    try
                    {
                        ConnectionObject = new SqlConnection(this.ConnectionString);
                        ConnectionObject.Open();
                        TransactionObject = ConnectionObject.BeginTransaction(IsoLevel);
                        return true;
                    }
                    catch (Exception e)
                    {
                        erorrValue = e;
                        transactionObject = null;
                        return false;
                    }
                }
                else
                    return false;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool CommitTransaction()
            {
                if (transactionObject != null)
                {
                    try
                    {
                        transactionObject.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        erorrValue = e;
                        return false;
                    }
                    finally
                    {
                        ReleaseObjects(ref transactionObject);
                    }
                }
                else
                    return false;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool RollbackTransaction()
            {
                if (transactionObject != null)
                {
                    try
                    {
                        transactionObject.Rollback();
                        return true;
                    }
                    catch (Exception e)
                    {
                        erorrValue = e;
                        return false;
                    }
                    finally
                    {
                        ReleaseObjects(ref transactionObject);
                    }
                }
                else
                    return false;
            }
            
            #endregion

            #region Constructors
            /// <summary>
            /// 
            /// </summary>
            /// <param name="WebConfigConnectionString"></param>
            public DataBaseEngine(string NameConnectionStringWebConfig)
            {
                if (Security.IsNullOrEmpty(NameConnectionStringWebConfig))
                {
                    ConnectionStringSettings WebConfigSettings =
                        ConfigurationManager.ConnectionStrings[NameConnectionStringWebConfig];
                    if (WebConfigSettings != null)
                    {
                        this.connectionString = WebConfigSettings.ConnectionString;
                        AssignValues(WebConfigSettings.ConnectionString);
                    }
                    else
                        this.erorrValue = new NullReferenceException();

                }
                else
                    this.erorrValue = new NullReferenceException();

            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="serverName"></param>
            /// <param name="databaseName"></param>
            /// <param name="userName"></param>
            /// <param name="password"></param>
            public DataBaseEngine(string serverName, string databaseName, string userName, string password)
            {
                if (Security.IsNullOrEmpty(serverName, databaseName, userName, password))
                {
                    this.serverName = serverName;
                    this.databaseName = databaseName;
                    this.userName = userName;
                    this.password = password;
                    CreateConnectionString(false);
                }
                else
                    this.erorrValue = new NullReferenceException();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="serverName"></param>
            /// <param name="databaseName"></param>
            public DataBaseEngine(string serverName, string databaseName)
            {
                if (Security.IsNullOrEmpty(serverName, databaseName))
                {
                    this.serverName = serverName;
                    this.databaseName = databaseName;
                    CreateConnectionString(true);
                }
                else this.erorrValue = new NullReferenceException();
            }
            #endregion

            
           



        } 
    }
}
