using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using Microsoft.Win32;
using System.IO;
[assembly: System.CLSCompliant(true)]
//<------ To valid Case Sensitivity if any VB.net Call it like
//C#:
//namespace ClassLibrary1
//{
//      public class CSharpClass
//      {
//            public String method()
//            {
//                  return "From method()";
//            }

//            public String METHOD()
//            {
//                  return "From METHOD()";
//            }
//      }

//}

//Basic:
//Dim obj As New ClassLibrary1.CSharpClass

//' -----  Error
//Console.WriteLine(obj.method())
//Console.WriteLine(obj.METHOD())
namespace UtilitiesLibrary
{
    public static partial class Security
    {
        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";

        #region Internal Methods
        /// <summary>
        /// Read byte array and convert to hexadecimal string 
        /// different ToBase64String(arrInput)
        /// </summary>
        /// <param name="arrInput"></param>
        /// <returns></returns>
        internal static string ByteArrayToString(byte[] arrInput)
        {
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        /// <summary>
        /// Gets array containing known file extensions from HKEY_CLASSES_ROOT.
        /// </summary>
        /// <returns>String array containing extensions.</returns>
        internal static List<string> GetAllRegisteredFileExtensions()
        {
            //get into the HKEY_CLASSES_ROOT
            RegistryKey root = Registry.ClassesRoot;

            //generic list to hold all the subkey names
            List<string> subKeys = new List<string>();

            //IEnumerator for enumerating through the subkeys
            IEnumerator enums = root.GetSubKeyNames().GetEnumerator();

            //make sure we still have values
            while (enums.MoveNext())
            {
                //all registered extensions start with a period (.) so
                //we need to check for that
                if (enums.Current.ToString().StartsWith("."))
                    //valid extension so add it
                    subKeys.Add(enums.Current.ToString());
            }
            return subKeys;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        internal static bool IsNullOrEmpty(params string[] values)
        {
            foreach (var item in values)
            {
                if (string.IsNullOrEmpty(item))
                    return false;
            }
            return true;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        public static byte[] EncryptPassword(string originalPassword)
        {
            //Declarations
            byte[] originalBytes;
            byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return encodedBytes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="HashedPassword"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string Password, byte[] HashedPassword)
        {

            bool bEqual = false;
            byte[] tmpHash = EncryptPassword(Password);
            byte[] tmpNewHash = HashedPassword;

            if (tmpNewHash.Length == tmpHash.Length)
            {
                int i = 0;
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
                {
                    i += 1;
                }
                if (i == tmpNewHash.Length)
                {
                    bEqual = true;
                }
            }

            if (bEqual)
                return true; //"The two hash values are the same"
            else
                return false;//"The two hash values are not the same"
        }
        /// <summary>
        /// this code in the PageLoad of the page which you want to make it secure
        /// http://msdn.microsoft.com/en-us/library/aa302412.aspx
        /// </summary>
        /// <param name="WebRequest">Request.ClientCertificate</param>
        /// <returns></returns>
        public static bool ClientCertificate(HttpRequest WebRequest)
        {
            if (WebRequest != null)
            {
                HttpClientCertificate cert = WebRequest.ClientCertificate;
                if (cert.IsPresent)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsDefaultValue(params object[] values)
        {
            double result;
            bool Empty = true;
            foreach (var item in values)
            {
                if (item != null)
                {
                    if (!string.IsNullOrEmpty(item.ToString()))
                    {
                        Empty = false;
                        break;
                    }
                    if (double.TryParse(item.ToString(), out result))
                    {
                        if (result == 0)
                        {
                            Empty = false;
                            break;
                        }
                    }
                }
                else
                {
                    Empty = true;
                    break;
                }

            }
            return Empty;
        }
        /// <summary>
        /// Validate Query String Has Valid Index
        /// </summary>
        /// <param name="RequestObject"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public static string QueryStringHasIndex(System.Web.HttpRequest RequestObject, int Index)
        {
            if (RequestObject != null && RequestObject.QueryString.Count != 0 && Index >= 0)
            {
                try
                {
                    return RequestObject.QueryString[Index];
                }
                catch
                {
                    return null;
                }
            }
            else
                return null;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApplicationPath"></param>
        public static bool EncryptWebConfig(string ApplicationPath)
        {
            if (Security.IsNullOrEmpty(ApplicationPath))
            {
                try
                {
                    Configuration config = WebConfigurationManager.OpenWebConfiguration(ApplicationPath);
                    ConfigurationSection section = config.GetSection("connectionStrings");
                    if (!section.SectionInformation.IsProtected)
                    {
                        // Encrypt the <connectionStrings> section using the
                        //DataProtectionConfigurationProvider or RsaProtectedConfigurationProvider
                        section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                        config.Save();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApplicationPath"></param>
        public static bool DecryptWebConfig(string ApplicationPath)
        {
            if (Security.IsNullOrEmpty(ApplicationPath))
            {
                try
                {
                    Configuration config = WebConfigurationManager.OpenWebConfiguration(ApplicationPath);
                    ConfigurationSection section = config.GetSection("connectionStrings");
                    if (section.SectionInformation.IsProtected)
                    {
                        section.SectionInformation.UnprotectSection();
                        config.Save();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
        /// <summary>
        /// method to validate an IP address
        /// using regular expressions. The pattern
        /// being used will validate an ip address
        /// with the range of 1.0.0.0 to 255.255.255.255
        /// </summary>
        /// <param name="addr">Address to validate</param>
        /// <returns></returns>
        public static bool IsValidIP(string addr)
        {
            bool valid = false;
            if (Security.IsNullOrEmpty(addr))
            {
                //create our match pattern
                string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])
                        (\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
                //create our Regular Expression object
                Regex check = new Regex(pattern);
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(addr, 0);

            }
            else
            {
                //no address provided so return false
                valid = false;
            }

            return valid;
        }
        /// <summary>
        /// This Method valid when internet because it connect to 
        /// http://74.125.43.95/ google services
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /*public static bool ArabicOnly(string value)
        {
            if (IsNullOrEmpty(value) && ExceptionHandling.HttpStatus("http://www.google.com") == System.Net.HttpStatusCode.OK)
            {
                Gapi.Language.Language refLan = Gapi.Language.Language.Arabic;
                Gapi.Language.Language resLan;
                double conf;
                bool isReal;
                resLan = Gapi.Language.Translator.Detect(value, out isReal, out conf);
                if (isReal == false)
                {
                    return false;
                }
                else
                {
                    if (refLan == resLan)
                        return true;

                    else
                        return false;
                }
            }
            else
                return false;
        }*/
        /// <summary>
        /// this method convert from latin words like ÇáßãÈíæÊÑ to 
        /// computer with arabic الكمبيوتر
        /// </summary>
        /// <param name="Latin"></param>
        /// <returns></returns>
        public static string convertToArabic(string Latin)
        {
            char[] Arabic = new char[Latin.Length];
            for (int i = 0; i < Latin.Length; i++)
            {
                if (Latin[i] == 32)
                    Arabic[i] = Latin[i];
                else if (Latin[i] >= 192 && Latin[i] <= 214)
                    Arabic[i] = (char)(Latin[i] + 1376);
                else if (Latin[i] >= 216 && Latin[i] <= 219)
                    Arabic[i] = (char)(Latin[i] + 1375);
                else if (Latin[i] >= 221 && Latin[i] <= 223)
                    Arabic[i] = (char)(Latin[i] + 1380);
                else if (Latin[i] == 225)
                    Arabic[i] = (char)(Latin[i] + 1379);
                else if (Latin[i] >= 227 && Latin[i] <= 230)
                    Arabic[i] = (char)(Latin[i] + 1378);
                else if (Latin[i] >= 236 && Latin[i] <= 237)
                    Arabic[i] = (char)(Latin[i] + 1373);
            }
            return new string(Arabic);
        }
        /// <summary>
        /// For example, 台北, the characters for "Taipei" (Táiběi), can also be written as &#21488;&#21271;. 
        /// For this to work, the "charset" of the Web page should be set to Unicode:
        /// <meta http-equiv="content-type" content="text/html; charset=utf-8" />
        /// http://pinyin.info/tools/converter/chars2uninumbers.html
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToUnicode(string value)
        {
            var tstr = value;
            var bstr = "";
            for (int i = 0; i < tstr.Length; i++)
            {
                if (tstr[i] > 127)
                {
                    bstr += "&#" + (int)tstr[i] + ";";
                }
                else
                {
                    bstr += tstr[i];
                }
            }
            return bstr;
        }
        /// <summary>
        /// Decrypt the content
        /// </summary>
        /// <param name="stringToDecrypt"></param>
        /// <returns></returns>
        public static string DESDecrypt(string stringToDecrypt)
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);

                int len = stringToDecrypt.Length; inputByteArray = Convert.FromBase64String(stringToDecrypt.Replace(" ","+"));


                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream();

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
            }

            catch (System.Exception ex)
            {
                throw ex;
            }





        }
        /// <summary>
        /// Encrypt the content
        /// </summary>
        /// <param name="stringToEncrypt"></param>
        /// <returns></returns>
        public static string DESEncrypt(string stringToEncrypt)
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);

                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        private static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }
        #endregion

    }
}
