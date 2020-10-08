using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL.Lookups
{
    public class SystemUsers
    {
       
        private OracleDatabaseClass db = new OracleDatabaseClass();

        //public void GetMonthlyDate(string Monthes,out DateTime From,out DateTime TO)
        //{
        //    if (Monthes == "1")
        //    {
        //        From = new DateTime(2018, 04, 16);
        //        TO = new DateTime(2018, 05, 14);
        //    }
        //    else if (Monthes == "2")
        //    {
        //        From = new DateTime(2018, 05, 15);
        //        TO = new DateTime(2018, 06, 13);
        //    }
        //    else if (Monthes == "3")
        //    {
        //        From = new DateTime(2018, 06, 14);
        //        TO = new DateTime(2018, 07, 15);
        //    }
        //    else if (Monthes == "4")
        //    {
        //        From = new DateTime(2018, 07, 16);
        //        TO = new DateTime(2018, 08, 11);
        //    }
        //    else if (Monthes == "5")
        //    {
        //        From = new DateTime(2018, 08, 12);
        //        TO = new DateTime(2018, 09, 09);
        //    }
        //    else if (Monthes == "6")
        //    {
        //        From = new DateTime(2018, 09, 10);
        //        TO = new DateTime(2018, 10, 01);
        //    }
        //    else if (Monthes == "7")
        //    {
        //        From = new DateTime(2018, 10, 02);
        //        TO = new DateTime(2018, 11, 04);
        //    }
        //    else if (Monthes == "8")
        //    {
        //        From = new DateTime(2018, 11, 05);
        //        TO = new DateTime(2018, 12, 03);
        //    }
        //    else if (Monthes == "0")
        //    {
        //        From = new DateTime(2018, 04, 16);
        //        TO = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //    }
        //    else
        //    {
        //        From = new DateTime();
        //        TO = new DateTime();
        //    }

        //}
        public bool UpdateReceivedFiles(string ID_REGION_NO ,string RECEIVEDUSERNO)
        {
            int value;
            if (int.TryParse(ID_REGION_NO, out value) && int.TryParse(RECEIVEDUSERNO, out value))
            {
                string sql = string.Format("update RECEIVEDFILES set RECEIVED_STARTDATE=(SELECT SYSDATE FROM dual) , RECEIVED_ENDDATE=NULL , RECEIVEDUSERNO='{1}' where ID='{0}'", ID_REGION_NO, RECEIVEDUSERNO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                return false;
        }
        public bool UpdateReceivedFiles(string ID_REGION_NO)
        {
            int value;
            if (int.TryParse(ID_REGION_NO, out value))
            {
                string sql = string.Format("update RECEIVEDFILES set RECEIVED_ENDDATE=(SELECT SYSDATE FROM dual)  where ID='{0}'", ID_REGION_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                return false;
        }
        public DataTable SelectReportsQC(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;
           
            string[] SplitMonthYear = MonthYear.Split('|');

            if (MonthYear != "0" && (SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;

            string sql;
            if (MonthYear == "0")
                sql = string.Format(@"select ROWNUM,SURVEYOR_TOTALSTREETS,SURVEYOR_AREA,(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                            REGION_SURVEYOR,REGION_DATAENTRY,STREETSDELETED,STREETSADDED,REGION_NO,
                            DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                            concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear from REPORTSQC d
                            join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where SURVEY_NO={0}", SURVEY_NO);
            else
                sql = string.Format(@"select ROWNUM,SURVEYOR_TOTALSTREETS,SURVEYOR_AREA,(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                            REGION_SURVEYOR,REGION_DATAENTRY,STREETSDELETED,STREETSADDED,REGION_NO,
                            DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                            concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear from REPORTSQC d
                            join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and SURVEY_NO={2}", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable SelectReportsQCInterSect(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (MonthYear != "0" && (SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;

            string sql;
            if (MonthYear == "0")
                sql = string.Format(@"select ROWNUM,SURVEYOR_AREA,(select round(sum(INTERSEC_SAMP_AREA), 2) from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) as INTERSECTION_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                            REGION_SURVEYOR,REGION_DATAENTRY,STREET_ID,INTER_NO,
                            DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                            concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear from jpmms.INTERSECTQC d
                            join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where SURVEY_NO={0}", SURVEY_NO);
            else
                sql = string.Format(@"select ROWNUM,SURVEYOR_AREA,(select round(sum(INTERSEC_SAMP_AREA), 2) from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) as INTERSECTION_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                            REGION_SURVEYOR,REGION_DATAENTRY,STREET_ID,INTER_NO,
                            DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                            concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear from jpmms.INTERSECTQC d
                            join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and SURVEY_NO={2}", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable SelectAREAReportsQC(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (MonthYear != "0" && (SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;

            string sql;
            if (MonthYear == "0" && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select ROWNUM,SURVEYOR_TOTALSTREETS,SURVEYOR_AREA,(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                                      REGION_SURVEYOR,REGION_DATAENTRY,STREETSDELETED,STREETSADDED,REGION_NO,
                                      DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                                      concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear,
                                      concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE from REPORTSQC d
                                      join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where   
                                      SURVEYOR_AREA <>(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id)");
            else
                if (MonthYear == "0")
                    sql = string.Format(@"select ROWNUM,SURVEYOR_TOTALSTREETS,SURVEYOR_AREA,(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                                      REGION_SURVEYOR,REGION_DATAENTRY,STREETSDELETED,STREETSADDED,REGION_NO,
                                      DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                                      concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear,
                                      concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE  from REPORTSQC d                                    
                                      join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where   
                                      SURVEYOR_AREA <>(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) and SURVEY_NO={0}", SURVEY_NO);
                else
                    sql = string.Format(@"select ROWNUM,SURVEYOR_TOTALSTREETS,SURVEYOR_AREA,(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) as region_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                                      REGION_SURVEYOR,REGION_DATAENTRY,STREETSDELETED,STREETSADDED,REGION_NO,
                                      DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                                      concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear,
                                      concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE from REPORTSQC d
                                      join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where    
                                      SURVEYOR_AREA <>(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from STREETS s where s.region_id=d.region_id) and REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and SURVEY_NO={2}", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);
            return db.ExecuteQuery(sql);
        }

        public DataTable SelectAREAReportsQCIntersect(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (MonthYear != "0" && (SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;

            string sql;
            if (MonthYear == "0" && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select ROWNUM,SURVEYOR_AREA,(select round(sum(INTERSEC_SAMP_AREA), 2) from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) as INTERSECTION_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                                      REGION_SURVEYOR,REGION_DATAENTRY,(select Main_no from JPMMS.EQUIPMENTMAINQC where Street_id=d.Street_id and SURVEY_NO=d.SURVEY_NO )Main_no,INTER_NO,
                                      DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                                      concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear,
                                      concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE from jpmms.INTERSECTQC d
                                      join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where 
                                      SURVEYOR_AREA <>(select round(sum(INTERSEC_SAMP_AREA), 2) from JPMMS.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID)");
            else
                if (MonthYear == "0")
                    sql = string.Format(@"select ROWNUM,SURVEYOR_AREA,(select round(sum(INTERSEC_SAMP_AREA), 2) from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) as INTERSECTION_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                                      REGION_SURVEYOR,REGION_DATAENTRY,(select Main_no from JPMMS.EQUIPMENTMAINQC where Street_id=d.Street_id and SURVEY_NO=d.SURVEY_NO )Main_no,INTER_NO,
                                      DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                                      concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear,
                                      concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE from jpmms.INTERSECTQC d
                                      join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where 
                                      SURVEYOR_AREA <>(select round(sum(INTERSEC_SAMP_AREA), 2) from JPMMS.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) and SURVEY_NO={0}", SURVEY_NO);
                else
                    sql = string.Format(@"select ROWNUM,SURVEYOR_AREA,(select round(sum(INTERSEC_SAMP_AREA), 2) from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) as INTERSECTION_area,SURVEY_NO,REPORTSMONTH,REPORTSYEAR,
                                      REGION_SURVEYOR,REGION_DATAENTRY,(select Main_no from JPMMS.EQUIPMENTMAINQC where Street_id=d.Street_id and SURVEY_NO=d.SURVEY_NO )Main_no,INTER_NO,
                                      DECODE (IS_REVIEWREPORT, 0, 'False', 'True') AS IS_REVIEWREPORT,
                                      concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear,
                                      concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE from jpmms.INTERSECTQC d
                                      join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where 
                                      SURVEYOR_AREA <>(select round(sum(INTERSEC_SAMP_AREA), 2) from JPMMS.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID) and REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and SURVEY_NO={2}", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public bool UpdateReportQc(string SURVEYOR_AREA, string MonthYear, string REGION_NO, string SURVEY_NO)
        {
            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return false;

            string sql = string.Format(@"update REPORTSQC set SURVEYOR_AREA='{0}',REPORTSMONTH='{1}',REPORTSYEAR='{2}'
                               where REGION_NO='{3}' and SURVEY_NO='{4}' ",  SURVEYOR_AREA, SplitMonthYear[0], SplitMonthYear[1], REGION_NO, SURVEY_NO);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);

        }
        public bool UpdateReportQcInterSect(string SURVEYOR_AREA, string MonthYear, string INTER_NO, string SURVEY_NO)
        {
            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return false;

            string sql = string.Format(@"update INTERSECTQC set SURVEYOR_AREA='{0}',REPORTSMONTH='{1}',REPORTSYEAR='{2}'
                               where INTER_NO='{3}' and SURVEY_NO='{4}' ", SURVEYOR_AREA, SplitMonthYear[0], SplitMonthYear[1], INTER_NO, SURVEY_NO);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }
        public bool InsertReportQc(string DONE_BY, int REGION_ID, string SURVEYOR_TOTALSTREETS, string SURVEYOR_AREA, string SURVEY_NO, int REPORTSMONTH,
           int REPORTSYEAR, string REGION_SURVEYOR, string REGION_DATAENTRY, string STREETSDELETED, string STREETSADDED)
        {

            try
            {
                string sql = string.Format(@" insert into ReportsQC (DONE_BY,REGION_ID,REGION_NO,SURVEYOR_TotalStreets,SURVEYOR_AREA,
                                          SURVEY_NO,ReportsMonth,ReportsYear,REGION_SURVEYOR,REGION_DataEntry,STREETSDELETED,STREETSADDED)
                                            values ('{0}','{1}',(select REGION_NO from REGIONS where REGION_ID='{1}'),'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                                DONE_BY, REGION_ID, SURVEYOR_TOTALSTREETS, SURVEYOR_AREA, SURVEY_NO, REPORTSMONTH, REPORTSYEAR,
                                REGION_SURVEYOR, REGION_DATAENTRY, STREETSDELETED, STREETSADDED);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public bool InsertIntersectQc(string DONE_BY, int INTERSECTION_ID, string STREET_ID, string SURVEYOR_AREA, string SURVEY_NO, int REPORTSMONTH,
          int REPORTSYEAR, string REGION_SURVEYOR, string REGION_DATAENTRY)
        {

            try
            {
                string sql = string.Format(@" insert into INTERSECTQC (DONE_BY,INTERSECTION_ID,INTER_NO,STREET_ID,SURVEYOR_AREA,
                                          SURVEY_NO,ReportsMonth,ReportsYear,REGION_SURVEYOR,REGION_DATAENTRY)
                                            values ('{0}','{1}',(select INTER_NO from INTERSECTIONS where INTERSECTION_ID='{1}'),'{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                DONE_BY, INTERSECTION_ID, STREET_ID, SURVEYOR_AREA, SURVEY_NO, REPORTSMONTH, REPORTSYEAR,
                                REGION_SURVEYOR, REGION_DATAENTRY);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable GetReportsQC(bool? IS_REVIEWREPORT = null)
        {
            string sql;
            if (IS_REVIEWREPORT.HasValue)
            {
                if (IS_REVIEWREPORT.Value == true)
                    sql = "select * from jpmms.VW_ReportQC where IS_REVIEWREPORT='True'";
                else
                    sql = "select * from jpmms.VW_ReportQC where IS_REVIEWREPORT='False'";

            }
            else
                sql = @"select * from VW_ReportQC";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataEntry(string SURVEY_NO)
        {
            string sql = string.Format(@" select count(distinct STREET_ID) TotalStreets,count(STREET_ID) TotaDISTRESS,case when grouping(USERNAME)=1 THEN 'ALL USERES' else USERNAME end as USERNAME,{0} SURVEY_NO
                            from DISTRESS join SYSTEM_USERS on USER_ID=DONE_BY where SURVEY_NO='{0}' and CAN_EDIT=1  group by ROLLUP(USERNAME) order by TotalStreets desc ", SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataEntry(string SURVEY_NO, DateTime? from, DateTime? to)
        {
            if (from == null || to == null)
                return GetDataEntry(SURVEY_NO);
            string sql = string.Format(@" select count(distinct STREET_ID) TotalStreets,count(STREET_ID) TotaDISTRESS,case when grouping(USERNAME)=1 THEN 'ALL USERES' else USERNAME end as USERNAME,{0} SURVEY_NO
                            from DISTRESS join SYSTEM_USERS on USER_ID=DONE_BY where SURVEY_NO='{0}' and CAN_EDIT=1 and SURVEY_DATE BETWEEN TO_DATE('{1}','DD/MM/YYYY') AND TO_DATE('{2}','DD/MM/YYYY')  group by ROLLUP(USERNAME) order by TotalStreets desc "
                , SURVEY_NO, from.Value.ToString("dd/MM/yyyy"), to.Value.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataEntryDetials(string SURVEY_NO)
        {
            string sql = string.Format(@" select count(distinct STREET_ID) TotalStreets,count(STREET_ID) TotaDISTRESS,case when grouping(USERNAME)=1 THEN 'ALL USERES' else USERNAME end as USERNAME,{0} SURVEY_NO
                            ,case when grouping(REGION_NO)=1 THEN 'ALL REGIONS' else REGION_NO end as REGION_NO from DISTRESS
                            join SYSTEM_USERS on USER_ID=DONE_BY where SURVEY_NO='{0}' and CAN_EDIT=1  group by ROLLUP(USERNAME,REGION_NO) order by TotalStreets desc ", SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDataEntryDetials(string SURVEY_NO, DateTime? from, DateTime? to)
        {
            if (from == null || to == null)
                return GetDataEntryDetials(SURVEY_NO);

            string sql = string.Format(@" select count(distinct STREET_ID) TotalStreets,count(STREET_ID) TotaDISTRESS,case when grouping(USERNAME)=1 THEN 'ALL USERES' else USERNAME end as USERNAME,{0} SURVEY_NO
                            ,case when grouping(REGION_NO)=1 THEN 'ALL REGIONS' else REGION_NO end as REGION_NO from DISTRESS
                            join SYSTEM_USERS on USER_ID=DONE_BY where SURVEY_NO='{0}' and CAN_EDIT=1 and SURVEY_DATE BETWEEN TO_DATE('{1}','DD/MM/YYYY') AND TO_DATE('{2}','DD/MM/YYYY') group by ROLLUP(USERNAME,REGION_NO) order by TotalStreets desc",
            SURVEY_NO, from.Value.ToString("dd/MM/yyyy"), to.Value.ToString("dd/MM/yyyy"));
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedFiles()
        {
            string sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE,
                            DECODE(sy.SUSPENDED, 1, 'False', 'True') AS SUSPENDED ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join REGIONS on REGIONS.REGION_ID =  RECEIVEDFILES.ID  order by FILENAME desc";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedFiles(int ID)
        {
            string sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE,
                            DECODE(sy.SUSPENDED, 1, 'False', 'True') AS SUSPENDED ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join REGIONS on REGIONS.REGION_ID =  RECEIVEDFILES.ID where sy.USER_ID=" + ID.ToString() + " order by FILENAME desc";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedQuality()
        {
            string sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE,
                            DECODE(sy.SUSPENDED, 1, 'False', 'True') AS SUSPENDED ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join REGIONS on REGIONS.REGION_ID =  RECEIVEDFILES.ID where sy.USER_ID in (45,34) order by FILENAME desc";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetWidthQuality()
        {
            string sql = @"select ROW_NUMBER() OVER (order by SECOND_ST_WIDTH desc) NUMROW,(STREETS.region_no|| ' - ' || SUBDISTRICT) as region_no,MUNIC_NAME,SECOND_ST_NO, SECOND_ARNAME,SECOND_ST_WIDTH 
                           from STREETS join REGIONS on STREETS.REGION_ID = REGIONS.REGION_ID
                           where SECOND_ST_WIDTH>100 and STREET_TYPE=0 and STREETS.region_id in (select distinct region_id from DISTRESS where SURVEY_NO>2)";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetLenthQuality()
        {
            string sql = @"select ROW_NUMBER() OVER (order by SECOND_ST_LENGTH desc) NUMROW,(STREETS.region_no|| ' - ' || SUBDISTRICT) as region_no,MUNIC_NAME,SECOND_ST_NO, SECOND_ARNAME,SECOND_ST_LENGTH 
                            from STREETS join REGIONS on STREETS.REGION_ID = REGIONS.REGION_ID
                            where SECOND_ST_LENGTH>1000 and STREET_TYPE=0 and STREETS.region_id in (select distinct region_id from DISTRESS where SURVEY_NO>2)";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetAreaQuality()
        {
            string sql = @"          
          select ROW_NUMBER() OVER (order by INTERSECTION_AREA desc) NUMROW,d.INTER_NO , MAIN_NAME , INTEREC_STREET1  ,INTEREC_STREET2 , d.survey_no,to_char(max(survey_date) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date,INTERSECTION_AREA 
                           from jpmms.GV_INTERSECTION_DISTRESS d join jpmms.INTERSECTIONS_AREA s on s.INTER_NO=d.INTER_NO
                           where INTERSECTION_AREA>(INTERSECTION_COUNT*1500)  and d.SURVEY_NO>2 group by d.INTER_NO,INTERSECTION_COUNT, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no ,INTERSECTION_AREA";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedDataEntry(string UserId)
        {
            string sql;
            if (string.IsNullOrEmpty(UserId))
                sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 
                            order by FILENAME desc";
            else
            {
                if (UserId == "37")
                    sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 
                            order by FILENAME desc";
//                    sql = string.Format(@"select REPORTSQC_ID ID, null FILENAME,REGION_NO,null RECEIVEDUSERNO,null USERNAME,TO_DATE(sysdate,'DD/MM/YYYY')RECEIVED_STARTDATE
//                                            ,DECODE(IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(sysdate,'DD/MM/YYYY')RECEIVED_ENDDATE 
//                                            ,DECODE(0, 1, 'True', 'False') AS IS_REVIEWGIS,SURVEY_NO from jpmms.REPORTSQC  where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0");
                else
                    sql = string.Format(@" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where sy.USER_ID='{0}' and IS_REVIEWREPORT=0
                            order by FILENAME desc", UserId);
            }
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedInterSectDataEntry(string UserId)
        {
            string sql;
            if (string.IsNullOrEmpty(UserId))
                sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,INTER_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO,
                            (select main_no from EQUIPMENTMAINQC where STREET_ID=rq.STREET_ID and SURVEY_NO=rq.SURVEY_NO)main_no,
                            (select count(INTER_NO) TotaDISTRESS from jpmms.DISTRESS xd where xd.SURVEY_NO=rq.SURVEY_NO and INTER_NO=rq.INTER_NO group by INTER_NO ) DISTRESS
                            from RECEIVEDINTERSECTFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join  INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 
                            order by FILENAME desc";
            else
            {
                if (UserId == "37")
                    sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,INTER_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO,
                            (select main_no from EQUIPMENTMAINQC where STREET_ID=rq.STREET_ID and SURVEY_NO=rq.SURVEY_NO)main_no,
                            (select count(INTER_NO) TotaDISTRESS from jpmms.DISTRESS xd where xd.SURVEY_NO=rq.SURVEY_NO and INTER_NO=rq.INTER_NO group by INTER_NO ) DISTRESS
                            from RECEIVEDINTERSECTFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join  INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 
                            order by FILENAME desc";
                else
                    sql = string.Format(@" select ID,TO_NUMBER(FILENAME)FILENAME,INTER_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO,
                            (select main_no from EQUIPMENTMAINQC where STREET_ID=rq.STREET_ID and SURVEY_NO=rq.SURVEY_NO)main_no,
                            (select count(INTER_NO) TotaDISTRESS from jpmms.DISTRESS xd where xd.SURVEY_NO=rq.SURVEY_NO and INTER_NO=rq.INTER_NO group by INTER_NO ) DISTRESS
                            from RECEIVEDINTERSECTFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join  INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where sy.USER_ID='{0}' and IS_REVIEWREPORT=0
                            order by FILENAME desc", UserId);
            }
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedGis()
        {
            string sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=0 and IS_REVIEWGIS=1
                            order by FILENAME desc";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedInterSectGis()
        {
            string sql = @" select ID,TO_NUMBER(FILENAME)FILENAME,INTER_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWGIS, 1, 'True', 'False') AS IS_REVIEWGIS ,rq.SURVEY_NO,
                            (select main_no from EQUIPMENTMAINQC where STREET_ID=rq.STREET_ID and SURVEY_NO=rq.SURVEY_NO)main_no,
                            (select count(INTER_NO) TotaDISTRESS from jpmms.DISTRESS xd where xd.SURVEY_NO=rq.SURVEY_NO and INTER_NO=rq.INTER_NO group by INTER_NO ) DISTRESS
                            from RECEIVEDINTERSECTFILES  join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_REVIEWGIS=1
                            order by FILENAME desc";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedUDIStreets(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return null;

            //(SURVEY_NO>2 or SURVEY_NO is null )
            string sql = string.Format(@"  SELECT 
            count( street_id) TotalUDIStreets,
             (select count( street_id )  from STREETS s where s.region_id=v.region_id)TotalStreets,
            (select SURVEYOR_TOTALSTREETS from REPORTSQC r where REPORTSMONTH='{0}' and r.region_id=v.region_id and REPORTSYEAR='{1}') SURVEYOR_TOTALSTREETS,
            (select count( street_id )  from STREETS s where s.region_id=v.region_id and SECOND_ST_LENGTH=0 and SECOND_ST_WIDTH=0 )ClosedStreets,
            REGION_ID,region_no,SURVEY_NO
            FROM UDI_SECONDARY v where SURVEY_NO={2} and REGION_ID in (
            select d.REGION_ID from GV_SEC_ST_DISTRESS d where SURVEY_NO={2} and REGION_ID in 
            (select REGION_ID from REPORTSQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}') group by  region_id) group by  region_id,region_no,SURVEY_NO", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedUDIIntersections(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if (SplitMonthYear == null || SplitMonthYear.Length != 2)
                return null;

            //(SURVEY_NO>2 or SURVEY_NO is null )
            string sql = string.Format(@"SELECT 
            count(street_id) TOTALUDIINTERSECT,
            (select count(INTER_SAMP_ID)  from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID = v.INTER_ID)TOTALINTERSECT,
            (SELECT COUNT(INTER_SAMP_ID)  FROM jpmms.INTERSECTION_SAMPLES s WHERE s.INTERSECTION_ID = v.INTER_ID AND INTERSEC_SAMP_AREA = 0)ClosedIntersect,
            INTER_ID INTERSECTION_ID,INTER_NO,SURVEY_NO
            FROM jpmms.UDI_INTERSECTION_SAMPLE v where SURVEY_NO={2} and INTER_ID in (
            select d.INTERSECTION_ID from jpmms.GV_INTERSECTION_DISTRESS d where SURVEY_NO={2} 
            and INTER_ID in (select INTERSECTION_ID from JPMMS.INTERSECTQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}'))
            group by  INTER_ID,INTER_NO,SURVEY_NO", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedUDIStreets()
        {
            string sql = string.Format(@"SELECT * from jpmms.ReceivedUDIStreets");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSECOND_ST_NO(string Month)
        {
            string sql;
            if (Month == "0")
                sql = @"select STREET_ID,REGION_NO,SECOND_ST_NO,SECOND_ARNAME,NOTES from STREETS where length(SECOND_ST_NO)>2 and REGION_ID in (
            select REGION_ID from REPORTSQC ) order by REGION_NO";
            else
                sql = string.Format(@"select STREET_ID,REGION_NO,SECOND_ST_NO,SECOND_ARNAME,NOTES from STREETS where length(SECOND_ST_NO)>2 and REGION_ID in (
            select REGION_ID from REPORTSQC where REPORTSMONTH='{0}' ) order by REGION_NO", Month);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedMaintinanceStreets(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if ((SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;
            string sql = string.Format(@"select  count(distinct street_id) TotalMainStreets,
            (select count( street_id )  from STREETS s where s.region_id=v.region_id)TotalStreets,
             (select SURVEYOR_TOTALSTREETS from REPORTSQC r where REPORTSMONTH='{0}' and REPORTSYEAR='{1}' and r.region_id=v.region_id) SURVEYOR_TOTALSTREETS,
             (select count( street_id )  from STREETS s where s.region_id=v.region_id and SECOND_ST_LENGTH=0 and SECOND_ST_WIDTH=0 )ClosedStreets,
             REGION_ID,region_no,SURVEY_NO 
             from VW_LATEST_MD_SEC_ST v where udi_date is not null and SURVEY_NO={2}
                                        and region_id in (select d.region_id  from GV_SEC_ST_DISTRESS d  where SURVEY_NO={2}  
                                        and region_id in (select region_id from REPORTSQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}')) group by  region_id,region_no,SURVEY_NO", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedMaintinanceIntersect(string MonthYear, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(MonthYear) || MonthYear == "-1")
                return null;

            string[] SplitMonthYear = MonthYear.Split('|');

            if ((SplitMonthYear == null || SplitMonthYear.Length != 2))
                return null;
            string sql = string.Format(@"select case when (select UDI_VALUE from jpmms.UDI_INTERSECTION where SURVEY_NO=v.SURVEY_NO and INTERSECTION_ID = v.INTERSECTION_ID )<70 then
             (select count(INTER_SAMP_ID)  from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID = v.INTERSECTION_ID) else count(distinct nvl(INTER_SAMP_NO,00)) end  TotalMainStreets,
             (select count(INTER_SAMP_ID)  from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID = v.INTERSECTION_ID)TOTALINTERSECT,
             (select count(INTER_SAMP_ID)  from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID = v.INTERSECTION_ID AND INTERSEC_SAMP_AREA = 0)CLOSEDINTERSECT,
             INTERSECTION_ID,INTER_NO,SURVEY_NO,INTERSECT_TITLE,MAIN_NAME
             from jpmms.VW_LATEST_MD_INTERSAMP v where udi_date is not null and SURVEY_NO='{2}'
             and INTERSECTION_ID in (select d.INTERSECTION_ID  from jpmms.GV_INTERSECTION_DISTRESS d  where SURVEY_NO='{2}' 
             and INTERSECTION_ID in (select INTERSECTION_ID from jpmms.INTERSECTQC where REPORTSMONTH='{0}' and REPORTSYEAR='{1}'))
             group by  INTERSECTION_ID,INTER_NO,INTERSECT_TITLE,MAIN_NAME,SURVEY_NO", SplitMonthYear[0], SplitMonthYear[1], SURVEY_NO);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedMaintinanceStreets()
        {
            string sql = string.Format(@"select * from jpmms.ReceivedMINStreets");

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedReviewed()
        {
            string sql = @" select ID, ROW_NUMBER() OVER (order by REGION_NO) NUMROW,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWDATAENTRY, 1, 'True', 'False') AS IS_REVIEWDATAENTRY ,rq.SURVEY_NO
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=1";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetInterSectReceivedReviewed()
        {
            string sql = @" select ID, ROW_NUMBER() OVER (order by INTER_NO) NUMROW,TO_NUMBER(FILENAME)FILENAME,INTER_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_DATAENTRYFINSH, 1, 'True', 'False') AS IS_DATAENTRYFINSH ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWDATAENTRY, 1, 'True', 'False') AS IS_REVIEWDATAENTRY ,rq.SURVEY_NO,
                            (select main_no from EQUIPMENTMAINQC where STREET_ID=rq.STREET_ID and SURVEY_NO=rq.SURVEY_NO)main_no
                            from RECEIVEDINTERSECTFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join  INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=1";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedReports()
        {
            string sql = @" select ID, ROW_NUMBER() OVER (order by REGION_NO) NUMROW,TO_NUMBER(FILENAME)FILENAME,REGION_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_REVIEWREPORT, 1, 'True', 'False') AS IS_REVIEWREPORT ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWDATAENTRY, 1, 'True', 'False') AS IS_REVIEWDATAENTRY ,rq.SURVEY_NO
                            from RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWDATAENTRY=1";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedInterSectReports()
        {
            string sql = @" select ID, ROW_NUMBER() OVER (order by INTER_NO) NUMROW,TO_NUMBER(FILENAME)FILENAME,INTER_NO,RECEIVEDUSERNO,sy.USERNAME ,TO_DATE(RECEIVED_STARTDATE,'DD/MM/YYYY')RECEIVED_STARTDATE
                            ,DECODE(rq.IS_REVIEWREPORT, 1, 'True', 'False') AS IS_REVIEWREPORT ,TO_DATE(RECEIVED_ENDDATE,'DD/MM/YYYY')RECEIVED_ENDDATE 
                            ,DECODE(rq.IS_REVIEWDATAENTRY, 1, 'True', 'False') AS IS_REVIEWDATAENTRY ,rq.SURVEY_NO,
                            (select main_no from EQUIPMENTMAINQC where STREET_ID=rq.STREET_ID and SURVEY_NO=rq.SURVEY_NO)main_no
                            from RECEIVEDINTERSECTFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join  INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWDATAENTRY=1";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetReceivedInterMainStreet()
        {
            string sql = @"select distinct STREET_ID ID,rq.SURVEY_NO
                            from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWDATAENTRY=1";

            return db.ExecuteQuery(sql);
        }
        public bool UpdateReceivedReports()
        {

            string sql = @"update REPORTSQC set IS_REVIEWDATAENTRY=0 where REPORTSQC_ID in (
                            select REPORTSQC_ID from RECEIVEDFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=1 and IS_REVIEWDATAENTRY=1)";
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }
        public bool UpdateReceivedInterSectReports()
        {

            string sql = @"update INTERSECTQC set IS_REVIEWDATAENTRY=0,IS_READY=1 where INTERSECTIONQC_ID in (
                            select INTERSECTIONQC_ID from RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO 
                            join  INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=1 and IS_REVIEWDATAENTRY=1)";
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        } 
        public DataTable SelectNewStreets()
        {
            string sql = @"SELECT street_id, ARNAME, ENNAME, REGION_NO, SECOND_ARNAME, SECOND_ENNAME, 
                            SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID  FROM JPMMS.STREETS WHERE street_id NOT IN (
                            SELECT street_id FROM jpmms.SECONDARY_STREET_DETAILS) and REGION_ID is not null and ARNAME is   null and STREET_TYPE=0 order by REGION_NO";
                                 
            return db.ExecuteQuery(sql);
        }
        public DataTable SelectNewStreetsQC()
        {
            string sql = @"select d.region_no, MUNIC_NAME, subdistrict, d.survey_no, to_char(max(RECEIVE_DATE) ,'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as survey_date, d.region_id,
                         SUM ( REGION_AREA)  SURVEYORS_AREA, (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) as STREETS_AREA
                         from jpmms.SURVEYORS_REGIONs_distinct d join jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where d.SURVEY_NO>2
                         group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id
                         having  (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) <> SUM (REGION_AREA) order by d.region_no";
            return db.ExecuteQuery(sql);
        }
        public bool UpdateUDINewStreets()
        {

            string sql = @"insert INTO SECONDARY_STREET_DETAILS(street_id, ARNAME, ENNAME, REGION_NO, SECOND_AR_NAME, SECOND_EN_NAME, 
                            SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID)
                            SELECT street_id, ARNAME, ENNAME, REGION_NO, SECOND_ARNAME, SECOND_ENNAME, 
                            SECOND_ST_LENGTH, SECOND_ST_WIDTH, SUBDIST_ID, SECOND_ST_NO, REGION_ID  FROM JPMMS.STREETS WHERE street_id NOT IN (
                            SELECT street_id FROM SECONDARY_STREET_DETAILS) and REGION_ID is not null and ARNAME is  not null and STREET_TYPE=0";
                                    int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }
        public bool UpdateRePortReviewed(string REGION_NO, bool IS_REVIEWREPORT, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(REGION_NO))
                return false;
            else
            {
                string sql = string.Format("update REPORTSQC set IS_REVIEWREPORT='{0}' where REGION_NO='{1}' and SURVEY_NO='{2}'",
                     IS_REVIEWREPORT == true ? 1 : 0, REGION_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRePortInterSectReviewed(string INTER_NO, bool IS_REVIEWREPORT, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(INTER_NO))
                return false;
            else
            {
                string sql = string.Format("update INTERSECTQC set IS_REVIEWREPORT='{0}' where INTER_NO='{1}' and SURVEY_NO='{2}'",
                     IS_REVIEWREPORT == true ? 1 : 0, INTER_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateReceivedGisFinish(string REGION_NO,bool IS_REVIEWGIS, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(REGION_NO))
                return false;
            else
            {
                string sql = string.Format("update REPORTSQC set IS_REVIEWGIS='{0}' where REGION_NO='{1}' and SURVEY_NO='{2}'",
                     IS_REVIEWGIS == true ? 1 : 0, REGION_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateReceivedInterSectGisFinish(string INTER_NO, bool IS_REVIEWGIS, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(INTER_NO))
                return false;
            else
            {
                string sql = string.Format("update INTERSECTQC set IS_REVIEWGIS='{0}' where INTER_NO='{1}' and SURVEY_NO='{2}'",
                     IS_REVIEWGIS == true ? 1 : 0, INTER_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateReceivedReviewed(string REGION_NO, bool IS_REVIEWDATAENTRY, bool IS_DATAENTRYFINSH, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(REGION_NO))
                return false;
            else
            {
                string sql = string.Format("update REPORTSQC set IS_REVIEWDATAENTRY='{0}' , IS_DATAENTRYFINSH='{1}' where REGION_NO='{2}' and SURVEY_NO='{3}'",
                     IS_REVIEWDATAENTRY == true ? 1 : 0, IS_DATAENTRYFINSH == true ? 1 : 0, REGION_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateReceivedInterSectReviewed(string INTER_NO, bool IS_REVIEWDATAENTRY, bool IS_DATAENTRYFINSH, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(INTER_NO))
                return false;
            else
            {
                string sql = string.Format("update INTERSECTQC set IS_REVIEWDATAENTRY='{0}' , IS_DATAENTRYFINSH='{1}' where INTER_NO='{2}' and SURVEY_NO='{3}'",
                     IS_REVIEWDATAENTRY == true ? 1 : 0, IS_DATAENTRYFINSH == true ? 1 : 0, INTER_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateDataEntryFinish(string REGION_NO, bool IS_DATAENTRYFINSH, bool IS_REVIEWGIS,string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(REGION_NO))
                return false;
            else
            {
//                string sql = string.Format(@"UPDATE 
//                                            (
//                                            SELECT IS_DATAENTRYFINSH as DATAFINSH
//                                            FROM RECEIVEDFILES join SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO 
//                                            join  REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID 
//                                            where rq.REGION_NO='{0}'
//                                            )t
//                                            SET t.DATAFINSH = {1}", REGION_NO, IS_DATAENTRYFINSH == true ? 1 : 0);
                string sql = string.Format("update REPORTSQC set IS_DATAENTRYFINSH='{0}' , IS_REVIEWGIS='{1}' where REGION_NO='{2}' and SURVEY_NO='{3}'",
                    IS_DATAENTRYFINSH == true ? 1 : 0, IS_REVIEWGIS == true ? 1 : 0, REGION_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateInterSectDataEntryFinish(string INTER_NO, bool IS_DATAENTRYFINSH, bool IS_REVIEWGIS, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(INTER_NO))
                return false;
            else
            {
                string sql = string.Format("update INTERSECTQC set IS_DATAENTRYFINSH='{0}' , IS_REVIEWGIS='{1}' where INTER_NO='{2}' and SURVEY_NO='{3}'",
                    IS_DATAENTRYFINSH == true ? 1 : 0, IS_REVIEWGIS == true ? 1 : 0, INTER_NO, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool InsertReceivedFiles(string ID_REGION_NO, string RECEIVEDUSERNO)
        {
            int value;
            if (string.IsNullOrEmpty(RECEIVEDUSERNO) || string.IsNullOrEmpty(ID_REGION_NO))
                return false;

            if (int.TryParse(ID_REGION_NO, out value))
            {
                string Exsists = string.Format(" select count(*) from RECEIVEDFILES where ID='{0}'", ID_REGION_NO);
                string rowsExsists = db.ExecuteScalar(Exsists).ToString();
                if (int.Parse(rowsExsists) > 0)
                    return false;
                else
                {
                    string sql = string.Format("insert INTO RECEIVEDFILES (ID,RECEIVEDUSERNO,FILENAME,RECEIVED_STARTDATE) values ('{0}','{1}',(select NVL(max(TO_NUMBER(FILENAME)),0) from RECEIVEDFILES)+1,(SELECT SYSDATE FROM dual))",
                            ID_REGION_NO, RECEIVEDUSERNO);

                    int rows = db.ExecuteNonQuery(sql);
                    return (rows > 0);
                }
            }
            else
                return false;
        }
        public bool InsertReceivedInterSectFiles(string ID_INTERSECTION_NO, string RECEIVEDUSERNO)
        {
            int value;
            if (string.IsNullOrEmpty(RECEIVEDUSERNO) || string.IsNullOrEmpty(ID_INTERSECTION_NO))
                return false;

            if (int.TryParse(ID_INTERSECTION_NO, out value))
            {
                string Exsists = string.Format(" select count(*) from RECEIVEDINTERSECTFILES where ID='{0}'", ID_INTERSECTION_NO);
                string rowsExsists = db.ExecuteScalar(Exsists).ToString();
                if (int.Parse(rowsExsists) > 0)
                    return false;
                else
                {
                    string sql = string.Format("insert INTO RECEIVEDINTERSECTFILES (ID,RECEIVEDUSERNO,FILENAME,RECEIVED_STARTDATE) values ('{0}','{1}',(select NVL(max(TO_NUMBER(FILENAME)),0) from RECEIVEDINTERSECTFILES)+1,(SELECT SYSDATE FROM dual))",
                            ID_INTERSECTION_NO, RECEIVEDUSERNO);

                    int rows = db.ExecuteNonQuery(sql);
                    return (rows > 0);
                }
            }
            else
                return false;
        }
        public bool Insert(string USERNAME, string PASSWORD, bool SUSPENDED, bool is_admin, bool can_edit)
        {
            string permissions = "";
            USERNAME = USERNAME.Replace("'", "''");
            permissions = permissions.PadRight(30, '0');

            string sql = string.Format("insert into SYSTEM_USERS(USER_ID, USERNAME, PASSWORD, PERMISSIONS, ENTRY_DATE, SUSPENDED, IS_ADMIN, can_edit) " +
                " values(SEQ_LAB_USERS.nextval, '{0}', '{1}', '{2}', (select sysdate from dual), {3}, {4}, {5}) ",
                USERNAME, EncryptionClass.EncryptText(PASSWORD), permissions, Shared.Bool2Int(SUSPENDED), Shared.Bool2Int(is_admin), Shared.Bool2Int(can_edit));

            //int rows = db.ExecuteInsertWithIDReturn(sql , "SYSTEM_USERS");
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(string USERNAME, bool SUSPENDED, bool is_admin, bool can_edit, int USER_ID)
        {
            USERNAME = USERNAME.Replace("'", "''");
            string suspensionDatePart = SUSPENDED ? ", SUSPENSION_DATE=(select sysdate from dual) " : "";

            string sql = string.Format("update SYSTEM_USERS set USERNAME='{0}', IS_ADMIN={4}, SUSPENDED={1}, can_edit={5} {3} where USER_ID={2} ", USERNAME, Shared.Bool2Int(SUSPENDED),
                USER_ID, suspensionDatePart, Shared.Bool2Int(is_admin), Shared.Bool2Int(can_edit));

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Delete(int USER_ID)
        {
            string sql = string.Format("DELETE FROM SYSTEM_USERS WHERE USER_ID={0} ", USER_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }
        public DataTable GetReportMonthsRegions()
        {
            string sql = @" select distinct REPORTSYEAR,REPORTMONTH_ID,concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE,
                            concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear from REPORTSQC 
                            join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH order by REPORTSYEAR ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetReportMonthsIntersect()
        {
            string sql = @" select distinct REPORTSYEAR,REPORTMONTH_ID,concat(concat(REPORTMONTH_TITLE,' السنة '),REPORTSYEAR) REPORTMONTH_TITLE,
                            concat(concat(REPORTMONTH_ID,'|'),REPORTSYEAR)MonthYear from INTERSECTQC 
                            join REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH order by REPORTSYEAR ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMonthsTitle()
        {
            string sql = @" select REPORTMONTH_ID,REPORTMONTH_TITLE from REPORTMONTH ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetFilterIntersectionsUsers()
        {
            string sql = "select USER_ID, USERNAME from SYSTEM_USERS where USER_ID in (33,42,51) and SUSPENDED=0 order by USERNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetFilterUsers()
        {
            string sql = "select USER_ID, USERNAME from SYSTEM_USERS where CAN_EDIT =1 and SUSPENDED=0 and USER_ID in (44,50,49,32,33,34,42,51) order by USERNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetFilterUsersQuality()
        {
            string sql = "select USER_ID, USERNAME from SYSTEM_USERS where CAN_EDIT =1 and SUSPENDED=0 and USER_ID in (45,34) order by USERNAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAll()
        {
            string sql = "select USER_ID, USERNAME, PASSWORD, PERMISSIONS, ENTRY_DATE, DECODE(SUSPENDED, 1, 'True', 'False') AS SUSPENDED, DECODE(IS_ADMIN, 1, 'True', 'False') AS IS_ADMIN, DECODE(CAN_EDIT, 1, 'True', 'False') AS CAN_EDIT  from SYSTEM_USERS order by USERNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllByID(int userID)
        {
            string sql = string.Format("select USER_ID, USERNAME, PASSWORD, PERMISSIONS, ENTRY_DATE, DECODE(SUSPENDED, 1, 'True', 'False') AS SUSPENDED, " +
                " DECODE(IS_ADMIN, 1, 'True', 'False') AS IS_ADMIN, DECODE(can_edit, 1, 'True', 'False') AS can_edit from SYSTEM_USERS where USER_ID={0} order by USERNAME ", userID);
            return db.ExecuteQuery(sql);
        }

        public UserLogonWorkOrdersDetails LoginWorkOrders(string userName, string password)
        {
            userName = userName.Replace("'", "''");
            password = password.Replace("'", "''");

            string sql = string.Format(@"select USER_ID, USERNAME,
            DECODE(IS_CONTRACTOR, 1, 'True', 'False') AS IS_CONTRACTOR,
            DECODE(IS_CONSULTANT, 1, 'True', 'False') AS IS_CONSULTANT, 
            DECODE(IS_PROJECTMANJER, 1, 'True', 'False') AS IS_PROJECTMANJER,
            DECODE(IS_DIRECTORMANGER, 1, 'True', 'False') AS IS_DIRECTORMANGER,
            DECODE(IS_SERVICESAVAILABLE, 1, 'True', 'False') AS IS_SERVICESAVAILABLE,
            DECODE(IS_GENERALDIRECTORMANGER, 1, 'True', 'False') AS IS_GENERALDIRECTORMANGER,
            DECODE(CAN_VIEW, 1, 'True', 'False') AS CAN_VIEW,
            DECODE(can_edit, 1, 'True', 'False') AS can_edit
            from SYSTEM_USERS_WORK where USERNAME='{0}' AND PASSWORD='{1}' ",
                userName, EncryptionClass.EncryptText(password));

            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];

                return new UserLogonWorkOrdersDetails(int.Parse(dr["USER_ID"].ToString()), dr["USERNAME"].ToString(), bool.Parse(dr["CAN_VIEW"].ToString()),bool.Parse(dr["can_edit"].ToString()),
                     bool.Parse(dr["IS_CONTRACTOR"].ToString()), bool.Parse(dr["IS_CONSULTANT"].ToString()), bool.Parse(dr["IS_PROJECTMANJER"].ToString()),
                     bool.Parse(dr["IS_DIRECTORMANGER"].ToString()), bool.Parse(dr["IS_SERVICESAVAILABLE"].ToString()), bool.Parse(dr["IS_GENERALDIRECTORMANGER"].ToString()));
            }
            else
                return new UserLogonWorkOrdersDetails();
        }


        public UserLogonDetails Login(string userName, string password)
        {
            userName = userName.Replace("'", "''");
            password = password.Replace("'", "''");

            string sql = string.Format("select USER_ID, USERNAME, PERMISSIONS, DECODE(IS_ADMIN, 1, 'True', 'False') AS IS_ADMIN, DECODE(can_edit, 1, 'True', 'False') AS can_edit from SYSTEM_USERS where USERNAME='{0}' AND PASSWORD='{1}' and SUSPENDED=0 ",
                userName, EncryptionClass.EncryptText(password));

            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];

                return new UserLogonDetails(int.Parse(dr["USER_ID"].ToString()), dr["Permissions"].ToString(), dr["USERNAME"].ToString(), bool.Parse(dr["IS_ADMIN"].ToString()),
                     bool.Parse(dr["can_edit"].ToString()));
            }
            else
                return new UserLogonDetails();
        }

        public UserLogonDetails GetReportsUser()
        {
            string sql = "select USER_ID, USERNAME, PERMISSIONS, DECODE(IS_ADMIN, 1, 'True', 'False') AS IS_ADMIN, DECODE(can_edit, 1, 'True', 'False') AS can_edit from SYSTEM_USERS where USERNAME like '%report%' and SUSPENDED=0 ";
            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];

                return new UserLogonDetails(int.Parse(dr["USER_ID"].ToString()), dr["Permissions"].ToString(), dr["USERNAME"].ToString(), bool.Parse(dr["IS_ADMIN"].ToString()),
                     bool.Parse(dr["can_edit"].ToString()));
            }
            else
                return new UserLogonDetails();
        }

        public UserLogonDetails GetDataBrowsingUser()
        {
            string sql = string.Format("select USER_ID, USERNAME, PERMISSIONS, DECODE(IS_ADMIN, 1, 'True', 'False') AS IS_ADMIN, DECODE(can_edit, 1, 'True', 'False') AS can_edit from SYSTEM_USERS " +
                " where USERNAME like '%data%' and PASSWORD='{0}'  and SUSPENDED=0 ", EncryptionClass.EncryptText("pmms12#"));

            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];

                return new UserLogonDetails(int.Parse(dr["USER_ID"].ToString()), dr["Permissions"].ToString(), dr["USERNAME"].ToString(), bool.Parse(dr["IS_ADMIN"].ToString()),
                     bool.Parse(dr["can_edit"].ToString()));
            }
            else
                return new UserLogonDetails();
        }



        public static string GetUserPermissions(int userID)
        {
            string sql = string.Format("select PERMISSIONS from SYSTEM_USERS where USER_ID={0} ", userID);
            return new OracleDatabaseClass().ExecuteScalar(sql).ToString();
        }

        public bool UpdateUserPermissions(string permissions, int userID)
        {
            string sql = string.Format("update SYSTEM_USERS set PERMISSIONS='{0}' where USER_ID={1} ", permissions, userID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public bool ChangeUserPassword(string oldPassword, string newPassword, string newPasswordConfirm, int userID)
        {
            string sql = "";

            // to get the old password and compare it to the old password written in txtoldPassword
            // and compare the passed agent old password with that saved in the database
            sql = string.Format("select nvl(PASSWORD, '') from SYSTEM_USERS where USER_ID={0} ", userID);
            string password = db.ExecuteScalar(sql).ToString();
            string encryptedOldPassword = EncryptionClass.EncryptText(oldPassword);

            //if (password == oldPassword.ToLower() || password == oldPassword.ToUpper())
            if (encryptedOldPassword == password)
            {
                // if the old password is the same with that saved in the database, 
                // and the new password is the same witn its confirmation change the customer password
                if (newPassword == newPasswordConfirm)
                {
                    sql = string.Format("UPDATE SYSTEM_USERS SET PASSWORD='{0}' WHERE USER_ID={1} ", EncryptionClass.EncryptText(newPassword), userID);
                    int records = db.ExecuteNonQuery(sql);
                    return (records == 1);

                    //if (records == 1)
                    //    return true;
                    //else
                    //    return false;
                    // if password change operation succeeded, show that to the customer
                    //lblFeedback.Text = "تم تغيير كلمة السر.";
                }
                else

                    // if the new password is not the same witn its confirmation
                    // show that to the customer
                    //lblFeedback.Text = 
                    throw new Exception("كلمة السر لاتطابق تأكيدها!");
            }
            else
            {
                // if the old password is not the same with that saved in the database, 
                // show that to the customer
                //lblFeedback.Text = 
                throw new Exception("كلمة السر غير صحيحة!");
            }
        }

        public bool ChangeUserPassword(string newPassword, string newPasswordConfirm, int userID)
        {
            string sql = "";
            newPassword = newPassword.Replace("'", "''");
            newPasswordConfirm = newPasswordConfirm.Replace("'", "''");

            // if the old password is the same with that saved in the database, 
            // and the new password is the same witn its confirmation change the customer password
            if (newPassword == newPasswordConfirm)
            {
                sql = string.Format("UPDATE SYSTEM_USERS SET PASSWORD='{0}' WHERE USER_ID={1} ", EncryptionClass.EncryptText(newPassword), userID);
                int records = db.ExecuteNonQuery(sql);
                return (records == 1);
            }
            else

                // if the new password is not the same witn its confirmation
                // show that to the customer
                throw new Exception("كلمة السر لاتطابق تأكيدها!");
        }

    }

    public class UserLogonWorkOrdersDetails
    {
        public int UserID;
        public string UserName;
        public bool CanView;
        public bool CanEdit;
        public bool IS_CONTRACTOR;
        public bool IS_CONSULTANT;
        public bool IS_PROJECTMANJER;
        public bool IS_DIRECTORMANGER;
        public bool IS_SERVICESAVAILABLE;
        public bool IS_GENERALDIRECTORMANGER;


        public UserLogonWorkOrdersDetails()
        {
            UserID = 0;
            UserName = "";
            CanView = false;
            CanEdit = false;
            IS_CONTRACTOR = false;
            IS_CONSULTANT = false;
            IS_PROJECTMANJER = false;
            IS_DIRECTORMANGER = false;
            IS_SERVICESAVAILABLE = false;
            IS_GENERALDIRECTORMANGER = false;
        }

        public UserLogonWorkOrdersDetails(int userID, string userName, bool canView, bool canEdit ,bool CONTRACTOR, bool CONSULTANT, bool PROJECTMANJER, bool DIRECTORMANGER, bool SERVICESAVAILABLE, bool GENERALDIRECTORMANGER)
        {
            UserID = userID;
            UserName = userName;
            CanView = canView;
            CanEdit = canEdit;
            IS_CONTRACTOR = CONTRACTOR;
            IS_CONSULTANT = CONSULTANT;
            IS_PROJECTMANJER = PROJECTMANJER;
            IS_DIRECTORMANGER = DIRECTORMANGER;
            IS_SERVICESAVAILABLE = SERVICESAVAILABLE;
            IS_GENERALDIRECTORMANGER = GENERALDIRECTORMANGER;
        }

    }
    public class UserLogonDetails
    {
        public int UserID;

        public string UserName;
        public string Permissions;
        public bool IsAdmin;
        public bool CanEdit;


        public UserLogonDetails()
        {
            UserID = 0;
            Permissions = "";
            UserName = "";
            IsAdmin = false;
            CanEdit = false;
        }

        public UserLogonDetails(int userID, string permissions, string userName, bool admin, bool canEdit)
        {
            UserID = userID;
            Permissions = permissions;
            UserName = userName;
            IsAdmin = admin;
            CanEdit = canEdit;
        }

    }

}
