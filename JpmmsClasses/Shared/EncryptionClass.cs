using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


/// <summary>
/// Summary description for EncryptionClass
/// </summary>
public class EncryptionClass
{
    public EncryptionClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string EncryptText(string plainText)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(plainText, "SHA1");
    }


}
