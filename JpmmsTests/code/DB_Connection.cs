using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections;
using System.Xml;
using System.Security.AccessControl;
using System.Data.OracleClient;

namespace Maintenance_Decision.DB
{

    public class DBConnection
    {

        static public OracleConnection m_Conn = new OracleConnection();
        static public string m_ConnStr = "";
        static public string m_CommStr = "";
        static public string m_DBPath = @"Inventory.accdb";
       static public string m_StoragePath = "";

        public DBConnection()
        {

        }
        /// <summary>
        ///  To start open connection with specified DataBase
        /// </summary>
        /// <returns></returns>
        /// 


        static public void InitAttributeValues()
        {

            m_DBPath = GetAttributeValue("DBPath") + "\\Archive_DB.mdb";

            m_StoragePath = GetAttributeValue("StoragePath");
        }

        static public string GetAttributeValue(string strKey)
        {
            string newValue = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Path.GetDirectoryName(Application.ExecutablePath) + "\\app.config");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/userSettings/Archive.Properties.Settings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode.ChildNodes)
            {
                if (childNode.Attributes["name"].Value == strKey)
                    newValue = childNode.InnerText;
            }
            return newValue;

        }
        static public bool SetAttributeValue(string strKey, string newValue)
        {
            XmlDocument xmlDoc = new XmlDocument();

          // SetAccessControl(Path.GetDirectoryName(Application.ExecutablePath));
           SetAccessControl();

            xmlDoc.Load(Path.GetDirectoryName(Application.ExecutablePath) + "\\app.config");
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/userSettings/Archive.Properties.Settings");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in appSettingsNode.ChildNodes)
            {
                if (childNode.Attributes["name"].Value == strKey)
                {
                    childNode.InnerXml = "<value>" + newValue + "</value>";
                    break;
                }
            }

            try
            {
                xmlDoc.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\app.config");
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                return true;
            }
            catch
            {

               
            }
            return false;

        }

        static private void SetAccessControl()
        {
            try
            {
                 string folder = Directory.GetCurrentDirectory();
                 //string folder=@"C:\Program Files\GEH\Archive_Package";

                 DirectorySecurity ds = Directory.GetAccessControl(folder);

                 ds.AddAccessRule(new FileSystemAccessRule("Everyone",   //Everyone is important
                     //because rights for all users!
                  FileSystemRights.Read | FileSystemRights.Write, AccessControlType.Allow));


                //System.IO.Directory.SetAccessControl(Path,);
                //System.Security.AccessControl.DirectorySecurity DSC=new System.Security.AccessControl.DirectorySecurity();

                //System.Security.AccessControl.DirectorySecurity dsec = System.IO.Directory.GetAccessControl(folder);
                //System.Security.Principal.NTAccount group = new System.Security.Principal.NTAccount("Everyone");
                //System.Security.AccessControl.FileSystemAccessRule myrule = new System.Security.AccessControl.FileSystemAccessRule(group, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.AccessControlType.Allow);
                //dsec.SetAccessRule(myrule);
                //System.IO.Directory.SetAccessControl(folder, dsec);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }




        static public bool OpenConnection()
        {

            //m_DBPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Archive_DB.mdb";
         //   MessageBox.Show(m_DBPath); 
            
           // m_DBPath=@"D:\Documents and Settings\ayoussef\Desktop\TwainGui\Project.mdb";



            
            if (m_Conn.State != ConnectionState.Open)
            {

                try
                {
                    //m_ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    //            "Data Source=" + m_DBPath + ";" +
                    //            "Persist Security Info=false";

                    //m_ConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + m_DBPath + ";Persist Security Info=False";
                    m_ConnStr = "DATA SOURCE=jpmms;PASSWORD=jpmms;USER ID=jpmms; ";

                    //m_ConnStr="Provider=Microsoft.Jet.OLEDB.4.0;"+
                    //           "Data Source=" + m_DBPath +";"+
                    //           "User Id=Admin;Password=";
                    m_Conn = new OracleConnection();
                    m_Conn.ConnectionString = m_ConnStr;
                    m_Conn.Open();
                    
                    return true;
                }
                catch (Exception oleEx)
                {
                    Console.WriteLine(oleEx.StackTrace);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///    To close connection channel with DataBase
        /// </summary>
        /// <returns></returns>
        static public bool CloseConnection()
        {
            try
            {
                m_Conn.Close();
                return true;
            }
            catch (Exception oleEx)
            {
#if DEBUG
                Console.WriteLine(oleEx.StackTrace);
#else
                MessageBox.Show("Can`t Open DataBase");
#endif
                return false;
            }
        }



        static public OracleDataReader ExcuteReaderCommand()
        {
            OracleDataReader oleReader = null;
            try
            {

                if (m_Conn.State == ConnectionState.Closed)
                    OpenConnection();
                OracleCommand oleCommand = new OracleCommand(m_CommStr, m_Conn);
                oleReader = oleCommand.ExecuteReader();
            }
            catch (Exception oleEx)
            {
#if DEBUG
                Console.WriteLine(oleEx.StackTrace);
#else
                MessageBox.Show("Can`t Excute Command");
#endif
            }
            return oleReader;
        }

        static public object ExecuteScalarCommand()
        {
            object res = new object();
            try
            {

                if (m_Conn.State == ConnectionState.Closed)
                    OpenConnection();
                OracleCommand oleCommand = new OracleCommand(m_CommStr, m_Conn);
                res = oleCommand.ExecuteScalar();
            }
            catch (Exception oleEx)
            {
#if DEBUG
                Console.WriteLine(oleEx.StackTrace);
#else
                MessageBox.Show("Can`t Excute Command");
#endif
            }
            return res;
        }

        static public DataSet ExcuteReaderCommand(string tableName)
        {

            DataSet ds = null;
            try
            {

                if (m_Conn.State == ConnectionState.Closed)
                    OpenConnection();
                OracleDataAdapter da = new OracleDataAdapter(m_CommStr, m_Conn);
                ds = new DataSet();
                da.Fill(ds, tableName);


            }
            catch (Exception oleEx)
            {
#if DEBUG
                Console.WriteLine(oleEx.StackTrace);
#else
                MessageBox.Show("Can`t Excute Command");
#endif
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }

        static public bool ExcuteReaderCommand(string tableName, ref DataSet ds)
        {

            try
            {

                if (m_Conn.State == ConnectionState.Closed)
                    OpenConnection();
                OracleDataAdapter da = new OracleDataAdapter(m_CommStr, m_Conn);
                da.Fill(ds, tableName);
                return true;

            }
            catch (Exception oleEx)
            {
#if DEBUG
                Console.WriteLine(oleEx.StackTrace);
#else
                MessageBox.Show("Can`t Excute Command");
#endif

            }
            return false;
        }

        /// <summary>
        /// To excute command that will not return data unless number of rows affected 
        /// with that command
        /// </summary>
        /// <returns></returns>
        static public int ExcuteNonQueryCommand()
        {
            int rNo = 0;//init rows affected value 
            try
            {


                if (m_Conn.State == ConnectionState.Closed)
                    OpenConnection();
                OracleCommand oleCommand = new OracleCommand(m_CommStr, m_Conn);
                try
                {
                    rNo = oleCommand.ExecuteNonQuery();
                }
                catch(TimeoutException tEx)
                {
                    Console.WriteLine(tEx);
  
                }
            }
         
            catch (Exception oleEx)
            {
                MessageBox.Show(oleEx.Message + "\n " + m_CommStr); 
#if DEBUG
                Console.WriteLine(oleEx.StackTrace);
#else
                MessageBox.Show("Can`t Excute Command");
#endif
            }
            return rNo;
        }        
    }


//    class DBConnectionTemp
//    {

//        static public OleDbConnection m_Conn = new OleDbConnection();
//        static public string m_ConnStr = "";
//        static public string m_CommStr = "";
//        static public string m_DBPath = "Project.mdb";
//        public DBConnectionTemp()
//        {

//        }
//        /// <summary>
//        ///  To start open connection with specified DataBase
//        /// </summary>
//        /// <returns></returns>
//        static public bool OpenConnection()
//        {
//            if (m_Conn.State != ConnectionState.Open)
//            {

//                try
//                {
//                    m_ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
//                                "Data Source=" + m_DBPath + ";" +
//                                "Persist Security Info=false";
//                    //m_ConnStr="Provider=Microsoft.Jet.OLEDB.4.0;"+
//                    //           "Data Source=" + m_DBPath +";"+
//                    //           "User Id=Admin;Password=";
//                    m_Conn = new OleDbConnection();
//                    m_Conn.ConnectionString = m_ConnStr;
//                    m_Conn.Open();

//                    return true;
//                }
//                catch (OleDbException oleEx)
//                {
//                    Console.WriteLine(oleEx.StackTrace);
//                    return false;
//                }
//            }
//            return true;
//        }
//        /// <summary>
//        ///    To close connection channel with DataBase
//        /// </summary>
//        /// <returns></returns>
//        static public bool CloseConnection()
//        {
//            try
//            {
//                m_Conn.Close();
//                return true;
//            }
//            catch (OleDbException oleEx)
//            {
//#if DEBUG
//                Console.WriteLine(oleEx.StackTrace);
//#else
//                MessageBox.Show("Can`t Open DataBase");
//#endif
//                return false;
//            }
//        }
//        /// <summary>
//        /// To run command that will return values
//        /// </summary>
//        /// <returns></returns>
//        static public OleDbDataReader ExcuteReaderCommand()
//        {
//            OleDbDataReader oleReader = null;
//            try
//            {

//                if (m_Conn.State == ConnectionState.Closed)
//                    OpenConnection();
//                OleDbCommand oleCommand = new OleDbCommand(m_CommStr, m_Conn);
//                oleReader = oleCommand.ExecuteReader();
//            }
//            catch (OleDbException oleEx)
//            {
//#if DEBUG
//                Console.WriteLine(oleEx.StackTrace);
//#else
//                MessageBox.Show("Can`t Excute Command");
//#endif
//            }
//            return oleReader;
//        }
//        static public object ExecuteScalarCommand()
//        {
//            object res = new object();
//            try
//            {

//                if (m_Conn.State == ConnectionState.Closed)
//                    OpenConnection();
//                OleDbCommand oleCommand = new OleDbCommand(m_CommStr, m_Conn);
//                res = oleCommand.ExecuteScalar();
//            }
//            catch (OleDbException oleEx)
//            {
//#if DEBUG
//                Console.WriteLine(oleEx.StackTrace);
//#else
//                MessageBox.Show("Can`t Excute Command");
//#endif
//            }
//            return res;
//        }
//        static public DataSet ExcuteReaderCommand(string tableName)
//        {

//            DataSet ds = null;
//            try
//            {

//                if (m_Conn.State == ConnectionState.Closed)
//                    OpenConnection();
//                OleDbDataAdapter da = new OleDbDataAdapter(m_CommStr, m_Conn);
//                ds = new DataSet();
//                da.Fill(ds, tableName);


//            }
//            catch (OleDbException oleEx)
//            {
//#if DEBUG
//                Console.WriteLine(oleEx.StackTrace);
//#else
//                MessageBox.Show("Can`t Excute Command");
//#endif
//            }
//            return ds;
//        }
//        static public bool ExcuteReaderCommand(string tableName, ref DataSet ds)
//        {

//            try
//            {

//                if (m_Conn.State == ConnectionState.Closed)
//                    OpenConnection();
//                OleDbDataAdapter da = new OleDbDataAdapter(m_CommStr, m_Conn);
//                da.Fill(ds, tableName);
//                return true;

//            }
//            catch (OleDbException oleEx)
//            {
//#if DEBUG
//                Console.WriteLine(oleEx.StackTrace);
//#else
//                MessageBox.Show("Can`t Excute Command");
//#endif

//            }
//            return false;
//        }

//        /// <summary>
//        /// To excute command that will not return data unless number of rows affected 
//        /// with that command
//        /// </summary>
//        /// <returns></returns>
//        static public int ExcuteNonQueryCommand()
//        {
//            int rNo = 0;//init rows affected value 
//            try
//            {


//                if (m_Conn.State == ConnectionState.Closed)
//                    OpenConnection();
//                OleDbCommand oleCommand = new OleDbCommand(m_CommStr, m_Conn);
//                try
//                {
//                    rNo = oleCommand.ExecuteNonQuery();
//                }
//                catch (TimeoutException tEx)
//                {
//                    Console.WriteLine(tEx);

//                }
//            }

//            catch (OleDbException oleEx)
//            {
//#if DEBUG
//                Console.WriteLine(oleEx.StackTrace);
//#else
//                MessageBox.Show("Can`t Excute Command");
//#endif
//            }
//            return rNo;
//        }







//    }
    // <summary>
    // To run command that will return values
    // </summary>
    // <returns></returns>
    // 

}

