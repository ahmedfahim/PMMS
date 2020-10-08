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

namespace JpmmsClasses.BL.AhmedYousif
{
    public class DBConnection
    {
        //static public OracleConnection m_Conn = new OracleConnection();
        //static public string m_ConnStr = "";
        //static public string m_CommStr = "";
        //static public string m_DBPath = @"Inventory.accdb";
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

            //m_DBPath = GetAttributeValue("DBPath") + "\\Archive_DB.mdb";

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
            //try
            //{

            string folder = Directory.GetCurrentDirectory();
            //string folder=@"C:\Program Files\GEH\Archive_Package";

            DirectorySecurity ds = Directory.GetAccessControl(folder);
            //                                      Everyone is important        //because rights for all users!
            ds.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.Read | FileSystemRights.Write, AccessControlType.Allow));

            //System.IO.Directory.SetAccessControl(Path,);
            //System.Security.AccessControl.DirectorySecurity DSC=new System.Security.AccessControl.DirectorySecurity();

            //System.Security.AccessControl.DirectorySecurity dsec = System.IO.Directory.GetAccessControl(folder);
            //System.Security.Principal.NTAccount group = new System.Security.Principal.NTAccount("Everyone");
            //System.Security.AccessControl.FileSystemAccessRule myrule = new System.Security.AccessControl.FileSystemAccessRule(group, System.Security.AccessControl.FileSystemRights.FullControl, System.Security.AccessControl.AccessControlType.Allow);
            //dsec.SetAccessRule(myrule);
            //System.IO.Directory.SetAccessControl(folder, dsec);
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
        }

    }
}

