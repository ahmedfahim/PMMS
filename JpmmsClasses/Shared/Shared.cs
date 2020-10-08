using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Data.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Shared
/// </summary>
public class Shared
{
    public Shared()
    {
        //
        // TODO: Add constructor logic here
        //
    }




    /// <summary>
    /// To format date string to be in the format DMY
    /// </summary>
    /// <param name="dt">Date the must be formatted</param>
    /// <returns>date in string formatted in DMY</returns>
    public static string FormatDateDMY(DateTime dt)
    {
        // To format date string to be in the format DMY
        string date = string.Format("{0}/{1}/{2}", dt.Day, dt.Month, dt.Year);
        return date;
    }

    /// <summary>
    /// To format date string to be in the format MDY
    /// </summary>
    /// <param name="dt">Date the must be formatted</param>
    /// <returns>date in string formatted in MDY</returns>
    public static string FormatDateMDY(DateTime dt)
    {
        // To format date string to be in the format DMY
        string date = string.Format("{1}/{0}/{2}", dt.Day, dt.Month, dt.Year);
        return date;
    }

    /// <summary>
    ///  To format date string to be in the format MDY after parsing it
    /// </summary>
    /// <param name="strDate">String of date the must be formatted</param>
    /// <returns>date in string formatted in MDY</returns>
    public static string FormatDateString(string strDate)
    {
        DateTime passedDate = DateTime.Parse(strDate);
        string date = string.Format("{1}/{0}/{2}", passedDate.Day, passedDate.Month, passedDate.Year);
        return date;
    }

    /// <summary>
    /// To format date string after parsing it to be in a determined format
    /// </summary>
    /// <param name="dateText">String of date the must be formatted</param>
    /// <param name="localeName">Locale short name (e.g: ar-eg, en-us, ar-sa, ...)</param>
    /// <param name="dateFormat">Date format, such as MM/dd/yyyy: MDY, dd/MM/yyyy</param>
    /// <returns>date in string formatted</returns>
    public static string FormatDateByLocale(string dateText, string localeName, string dateFormat)
    {
        DateTime parsedDateTime = Convert.ToDateTime(dateText, new CultureInfo(localeName));
        string parsedDateTimeString = parsedDateTime.ToString(dateFormat); //.ToString(dateFormat);
        return parsedDateTimeString;
    }

    /// <summary>
    /// To format date string after parsing according to Ar-Egypt locale it to be in MDY format
    /// </summary>
    /// <param name="dateText">String of date the must be formatted</param>
    /// <returns>date in string formatted</returns>
    public static string FormatDateArEgMDY(string dateText)
    {
        return FormatDateByLocale(dateText, "ar-eg", "MM/dd/yyyy");
    }

    /// <summary>
    /// To format date string after parsing according to Ar-Egypt locale it to be in DMY format
    /// </summary>
    /// <param name="dateText">String of date the must be formatted</param>
    /// <returns>date in string formatted</returns>
    public static string FormatDateArEgDMY(string dateText)
    {
        return FormatDateByLocale(dateText, "ar-eg", "dd/MM/yyyy");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateText"></param>
    /// <param name="localeName"></param>
    /// <param name="dateFormat"></param>
    /// <returns></returns>
    public static string FormatDateTimeByLocale(string dateText, string localeName, string dateFormat)
    {
        DateTime parsedDateTime = DateTime.Parse(dateText, new CultureInfo(localeName));
        string parsedDateTimeString = parsedDateTime.ToString(dateFormat);
        return parsedDateTimeString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTimeText"></param>
    /// <returns></returns>
    public static string FormatDateTimeArEgDMY_(string dateTimeText)
    {
        return string.Format("{0} {1}", FormatDateByLocale(dateTimeText, "ar-eg", "dd/MM/yyyy"), FormatTimeByLocale(dateTimeText, "ar-eg", "HH:mm"));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTimeText"></param>
    /// <returns></returns>
    public static string FormatDateTimeOracleEnGbDMY(string dateTimeText)
    {
        return string.Format("{0} {1}", FormatDateByLocale(dateTimeText, "en-GB", "dd/MM/yyyy"), FormatTimeByLocale(dateTimeText, "en-GB", "HH:mm"));
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateText"></param>
    /// <param name="localeName"></param>
    /// <param name="dateFormat"></param>
    /// <returns></returns>
    public static string FormatTimeByLocale(string dateText, string localeName, string dateFormat)
    {
        DateTime parsedDateTime = DateTime.Parse(dateText, new CultureInfo(localeName));
        //string parsedDateTimeString = parsedDateTime.ToShortTimeString(dateFormat);
        string parsedDateTimeString = parsedDateTime.ToString(dateFormat);
        return parsedDateTimeString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateText"></param>
    /// <returns></returns>
    public static string FormatTimeArEgMDY(string dateText)
    {
        return FormatTimeByLocale(dateText, "ar-eg", "hh:mm");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateText"></param>
    /// <returns></returns>
    public static string FormatDatTimeArEgMDY(string dateText)
    {
        return FormatDateTimeByLocale(dateText, "ar-eg", "MM/dd/yyyy hh:mm");
    }

    public static string FormatTimeString(string strTime)
    {
        DateTime date = new DateTime();
        int index = strTime.IndexOf(":");
        int hour = Convert.ToInt32(strTime.Substring(0, index));
        int minute = Convert.ToInt32(strTime.Substring(index + 1));

        string strDate = string.Format("{1}/{0}/{2} {3}:{4}:{5}", date.Day, date.Month, date.Year, hour, minute, 0);
        return strDate;
    }



    /// <summary>
    /// This function helps to make sure that there are no children rows for a parent row that we need to delete
    /// </summary>
    /// <param name="childTableName">Name of table that contains child rows</param>
    /// <param name="foreignKeyColName">Foreign key column name, which reference the parent row that we want to delete</param>
    /// <param name="foreignKeyColValue">The parent row value that we want to delete</param>
    /// <returns>number of children rows that refernce that parent row to be delete</returns>
    public int GetCountOfChildRecordsBeforeDeletingParent(string childTableName, string foreignKeyColName, string foreignKeyColValue)
    {
        string sql = string.Format("select count(*) from {0} where {1}={2}", childTableName, foreignKeyColName, foreignKeyColValue);
        int records = int.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        return records;
    }


    /// <summary>
    /// This function helps to make sure that there are no children rows for a parent row that we need to delete
    /// </summary>
    /// <param name="childTableName">Name of table that contains child rows</param>
    /// <param name="foreignKeyColName">Foreign key column name, which reference the parent row that we want to delete</param>
    /// <param name="foreignKeyColValue">The parent row value that we want to delete</param>
    /// <returns>number of children rows that refernce that parent row to be delete</returns>
    public int GetCountOfChildRecordsBeforeDeletingParent(string childTableName, string foreignKeyColName, int foreignKeyColValue)
    {
        string sql = string.Format("select count(*) from {0} where {1}={2}", childTableName, foreignKeyColName, foreignKeyColValue);
        int records = int.Parse(new OracleDatabaseClass().ExecuteScalar(sql).ToString());
        return records;
    }


    /// <summary>
    /// To convert boolean value to integer values
    /// </summary>
    /// <param name="value">Boolean value (True or False)</param>
    /// <returns>1 if true, 0 if false</returns>
    /// 
    public static int Bool2Int(bool value)
    {
        // if the passed value was true, return 1, otherwise return 0
        if (value)
            return 1;
        else
            return 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Bool2YN(bool value)
    {
        // if the passed value was true, return Y'', otherwise return 'N'
        if (value)
            return "Y";
        else
            return "N";
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Int2Bool(int value)
    {
        if (value == 0)
            return false;
        else
            return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Int2Bool(string value)
    {
        if (value == "0" || value.ToLower() == "false")
            return false;
        else
            return true;
    }





    /// <summary>
    /// To validate if the passed value is number or not
    /// </summary>
    /// <param name="s">Value to check if it is a number</param>
    /// <returns>Confirmation if it is or not</returns>
    public static bool IsNumeric(string s)
    {
        try
        {
            int.Parse(s);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static string GetCurrentDateString()
    {
        string dateTimePart = string.Format("{0}{1}{2}_{3}{4}", GetNumberCode(DateTime.Now.Day), GetNumberCode(DateTime.Now.Month),
               GetNumberCode(DateTime.Now.Year), GetNumberCode(DateTime.Now.Hour), GetNumberCode(DateTime.Now.Minute));

        return dateTimePart;
    }

    /// <summary>
    /// to get two characters string of the passed in number
    /// </summary>
    /// <param name="number">integer number</param>
    /// <returns>string of that number</returns>
    public static string GetNumberCode(int number)
    {
        if (number < 10)
            return string.Format("0{0}", number);
        else
            return number.ToString();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="tableName"></param>
    /// <param name="codeColumnName"></param>
    /// <returns></returns>
    public bool CheckCodeExist(int code, string tableName, string codeColumnName)
    {
        string sql = string.Format("select Count(*) from {0} where {2}='{1}' ", tableName, code.ToString(), codeColumnName);
        int count = (int)new OracleDatabaseClass().ExecuteScalar(sql);

        if (count == 0)
            return false;
        else
            return true;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="serial"></param>
    /// <returns></returns>
    public static string GetNumber3DigitsString(int serial)
    {
        if (serial >= 1 && serial <= 9)
            return "00" + serial.ToString();
        else if (serial > 9 && serial <= 99)
            return "0" + serial.ToString();
        else if (serial > 99)
            return serial.ToString();
        else
            return "001";
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool TimeIsValid(string time)
    {
        try
        {
            DateTime attTime = DateTime.Parse(time);
            return true;
        }
        catch (Exception)
        {
            return false;
            //throw new Exception("Please enter time in correct format!");
            //lblOperation.Text = "Please enter time in correct format!";
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int GetRandomNumber(int min, int max)
    {
        return new Random().Next(min, max);
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    public static void LogStatment(string sql)
    {
        if (ConfigurationManager.AppSettings["LogMdUdiSqlStatements"] == "1")
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["UDI_FilesDefaultPath"], true);
            sw.WriteLine(sql);
            sw.Close();
            sw.Dispose();
        }
    }

    public static void LogMdStatment(string sql)
    {
        if (ConfigurationManager.AppSettings["LogMdUdiSqlStatements"] == "1")
        {
            StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["MD_FilesDefaultPath"], true);
            sw.WriteLine(sql);
            sw.Close();
            sw.Dispose();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="memberType"></param>
    /// <param name="memberCode"></param>
    /// <param name="Desc"></param>
    /// <param name="user"></param>
    public static void SaveLogfile(string memberType, string memberCode, string Desc, string user)
    {
        string line = string.Format("MemberType:{0} \t MemberCode:{1} \t Description:{2} \t EventDate:{3} \t EventTime: {4} \t User:{5} ", memberType, memberCode, Desc,
            DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"), user);

        //string filePath = HttpContext.Current.Server.MapPath("~/test.txt");
        StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["FilesDefaultPath"], true);
        sw.WriteLine(line);
        sw.Close();
        sw.Dispose();
    }


    #region LINQ Support 

    public static DataTable IEnumerableToDataTable(IEnumerable ien)
    {
        DataTable dt = new DataTable();
        foreach (object obj in ien)
        {
            Type t = obj.GetType();
            PropertyInfo[] pis = t.GetProperties();
            if (dt.Columns.Count == 0)
            {
                foreach (PropertyInfo pi in pis)
                {
                    Type pt = pi.PropertyType;
                    if (pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(Nullable<>))
                        pt = Nullable.GetUnderlyingType(pt);
                    dt.Columns.Add(pi.Name, pt);
                }
            }
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in pis)
            {
                object value = pi.GetValue(obj, null);
                if (value == null)
                    dr[pi.Name] = DBNull.Value;
                else
                    dr[pi.Name] = value;
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }

    public static DataTable ToDataTable(DataContext ctx, object query)
    {
        if (query == null)
            throw new ArgumentNullException("query");

        IDbCommand cmd = ctx.GetCommand(query as IQueryable);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = (SqlCommand)cmd;
        DataTable dt = new DataTable("sd");

        try
        {
            cmd.Connection.Open();
            da.FillSchema(dt, SchemaType.Source);
            da.Fill(dt);
        }
        finally
        {
            cmd.Connection.Close();
        }

        return dt;
    }

    #endregion

}

public enum RoadType
{
    Section = 1,
    Intersect = 2,
    RegionSecondarySt = 3,
    MainStreet = 5,
    None = 0
};

public enum MachineSurveyType
{
    FWD = 1,
    IRI_Sections = 2,
    IRI_Intersects = 3,
    GPR_Sections = 4,
    GPR_Intersects = 5,
    SKID_Sections = 6,
    SKID_Intersects = 7,
    SectionTrafficCounting = 8,
    Rutting_Sections = 9,
    Rutting_Intersects = 10,
    None = 0
};

public enum RegionReportLevel
{
    None = 0,
    Region = 1,
    Subdistrict = 2,
    District = 3,
    Municipality = 4
}

public enum DistressQntyReportType
{
    None = 0,
    Region = 1,
    Subdistrict = 2,
    District = 3,
    Municipality = 4,
    MainStreet = 5,
    SectionSurroundingRegion = 6,
    SectionsInMunicipality = 7,
    MainStreetSections = 8,
    MainStreetIntersects = 9
};
