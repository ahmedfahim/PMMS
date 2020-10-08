using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;

namespace JpmmsClasses.BL
{
    public class MainStreet
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();

        public DataTable FinshedStreetsMFV(bool CLEARANCE)
        {
            //select S.MAIN_NO,S.STREET_ID,S.ARNAME, case when survey_no is null then 0 else 1 end Finshed,
            //0 EDITING , 0 UPDATING , 0 DRAWING ,0 IS_REVIEW_DRAWING,0 IS_REVIEW_EDITING,0 IS_DATAENTRYFINSH,0 IS_DRAWINGFINSH
            //from  jpmms.STREETIRI S left join jpmms.DISTRESSIRI D on D.STREET_ID =S.STREET_ID
            //sql = string.Format(@"select MAIN_NO,round(sum(LEN)/1000,3) length from JPMMS.IRIAVARAGESECTION group by MAIN_NO order by MAIN_NO");
            //DataTable DataTableTwo = db.ExecuteQuery(sql);
            //if (DataTableTwo.Rows.Count == DataTableOne.Rows.Count)
            //{
            //    for (int i = 0; i < DataTableOne.Rows.Count; i++)
            //        if (DataTableOne.Rows[i][1].ToString() == DataTableTwo.Rows[i][0].ToString())
            //            DataTableOne.Rows[i][4] = DataTableTwo.Rows[i][1];

            //    return DataTableOne;
            //}
            //else
            //    return new DataTable();
            string sql;

            if (CLEARANCE)
                sql = string.Format(@"Select * from jpmms.VW_STREETSQC_DATA  where CLEARANCE_DDF is not null and CLEARANCE_IRI is not null");
            else
                sql = string.Format(@"Select * from jpmms.VW_STREETSQC_DATA where CLEARANCE_DDF is  null and CLEARANCE_IRI is  null");

            DataTable DataTableOne = db.ExecuteQuery(sql);//concat('KM ',)
            return DataTableOne;
        }
        public DataTable FinshedRowDataMFV()
        {
            string sql = string.Format(@"select row_number() OVER (ORDER BY Q.MAIN_NO) ID,
                                        Q.MAIN_NO,Q.Arname,V.length,Q.SURVEY_NO from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE V
                                        right join JPMMS.EQUIPMENTMAINQC Q on Q.MAIN_NO = V.MAIN_NO and Q.SURVEY_NO = V.SURVEY_NO
                                        where  Q.ROWDATA=1 and IS_CLOSED=0");
            DataTable DataTableOne = db.ExecuteQuery(sql);
            if (DataTableOne.Rows.Count > 0)
                return DataTableOne;
            else
                return new DataTable();
        }
        public DataTable GetRecivedIRI()
        {
            string sql = @"select row_number() OVER (ORDER BY I.MAIN_NO) ID 
                            ,I.MAIN_NO,DECODE(IS_DATAENTRYFINSH, 1, 'True', 'False') AS DATAENTRYFINSH
                            ,S.ARNAME from jpmms.RecivedIRI I join jpmms.streets S on I.main_no=S.main_no
                            ORDER BY IS_DATAENTRYFINSH";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedMFV()
        {

            //            string sql = @" select Q.MAIN_NO,Q.Arname,V.length, 
            //                            DECODE(Q.IS_TRANSFARE, 1, 'True', 'False') AS IS_TRANSFARE ,
            //                            DECODE(Q.TRANSFARE_ERROR, 1, 'True', 'False') AS TRANSFARE_ERROR,
            //                            DECODE(SE.IS_Equipment, 1, 'True', 'False') AS IS_Equipment, Q.SURVEY_NO
            //                            from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE V
            //                            left join jpmms.VW_IRI_MAIN_LATEST_SURVEYS EQ on  EQ.MAIN_NO=V.MAIN_NO
            //                            join jpmms.EQUIPMENTMAINQC Q on Q.MAIN_NO = V.MAIN_NO and Q.SURVEY_NO=3
            //                            left join jpmms.STREETSQC SE  on Q.MAIN_NO = SE.MAIN_NO
            //                            where  EQ.MAIN_NO is null and  Q.ROWDATA=1 and IS_CLOSED=0 and Q.SURVEY_NO=3  and SE.IS_Equipment is null and (Q.DONE_BY=1 or Q.DONE_BY is null)  order by TRANSFARE_ERROR desc ,IS_TRANSFARE  desc";
            string sql = @"select * from JPMMS.VW_StreetsThree order by TRANSFARE_ERROR desc ,IS_TRANSFARE  desc";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStatisticsWorkOrders(JpmmsClasses.BL.UDI.UdiShared.UdiFilter UdiValue )
        { 
            string sql;
            switch (UdiValue)
            {
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsPoor:
                    {
                        sql = @"select * from STATWORKORDERMAINP ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsPoorFair:
                    {
                        sql = @"select * from STATWORKORDERMAINPF ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsGoodExcellent:
                    {
                        sql = @"select * from STATWORKORDERMAINGE ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsPoor:
                    {
                        sql = @"select * from StatWorkOrderP ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsPoorFair:
                    {
                        sql = @"select * from StatWorkOrderPF ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsGoodExcellent:
                    {
                        sql = @"select * from StatWorkOrderGE";
                        break;
                    }
               case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsAll:
                    {
                        sql = @"select * from StatWorkOrder";
                        break;
                    }
               case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsALL:
                    {
                        sql = @"select * from STATWORKORDERMAIN";
                        break;
                    }
                default:
                    return null;
            }
            return db.ExecuteQuery(sql);

        }
        public DataTable GetStatisticsWorkOrdersDetails(JpmmsClasses.BL.UDI.UdiShared.UdiFilter UdiValue)
        {
            string sql;
            switch (UdiValue)
            {
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsPoor:
                    {
                        sql = @"select * from STATWORKORDERDETAILSMAINP ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsPoorFair:
                    {
                        sql = @"select * from STATWORKORDERDETAILSMAINPF ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsGoodExcellent:
                    {
                        sql = @"select * from STATWORKORDERDETAILSMAINGE ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsPoor:
                    {
                        sql = @"select * from STATWORKORDERDETAILSP ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsPoorFair:
                    {
                        sql = @"select * from jpmms.STATWORKORDERDETAILSPF ";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsGoodExcellent:
                    {
                        sql = @"select * from STATWORKORDERDETAILSGE";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.MainStreetsAll:
                    {
                        sql = @"select * from StatWorkOrderDetails";
                        break;
                    }
                case JpmmsClasses.BL.UDI.UdiShared.UdiFilter.AxesStreetsALL:
                    {
                        sql = @"select * from STATWORKORDERDETAILSMAIN";
                        break;
                    }
                default:
                    return null;
            }
            return db.ExecuteQuery(sql);

        }
        public DataTable GetRecivedMFVNext(string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(SURVEY_NO))

                sql = @" select Q.MAIN_NO,Q.Arname,V.length, 
                            DECODE(Q.IS_TRANSFARE, 1, 'True', 'False') AS IS_TRANSFARE ,
                            DECODE(Q.TRANSFARE_ERROR, 1, 'True', 'False') AS TRANSFARE_ERROR,
                            DECODE(SE.IS_Equipment, 1, 'True', 'False') AS IS_Equipment, Q.SURVEY_NO,
                            case when TypeOfEquipment=39 then 'MFV' when TypeOfEquipment=40 then 'RDAS' else ' ' end AS TypeOfEquipment
                            from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE V
                            join jpmms.VW_EQUIPQC_LATEST_SURVEYS EQ on  EQ.MAIN_NO=V.MAIN_NO and EQ.SURVEY_NO=V.SURVEY_NO
                            join jpmms.EQUIPMENTMAINQC Q on Q.MAIN_NO = V.MAIN_NO and Q.SURVEY_NO=EQ.SURVEY_NO
                            left join jpmms.STREETSQC SE  on Q.MAIN_NO = SE.MAIN_NO where  Q.ROWDATA=1 and IS_CLOSED=0  and SE.IS_Equipment is null
                and Q.SURVEY_NO> (select min(SURVEY_NO) from jpmms.EQUIPMENTMAINQC where MAIN_NO=EQ.MAIN_NO) and (Q.DONE_BY=1 or Q.DONE_BY is null)  order by Q.SURVEY_NO,Q.MAIN_NO,TRANSFARE_ERROR desc ,IS_TRANSFARE  desc";
            else
                sql = string.Format(@" select Q.MAIN_NO,Q.Arname,V.length, 
                            DECODE(Q.IS_TRANSFARE, 1, 'True', 'False') AS IS_TRANSFARE ,
                            DECODE(Q.TRANSFARE_ERROR, 1, 'True', 'False') AS TRANSFARE_ERROR,
                            DECODE(SE.IS_Equipment, 1, 'True', 'False') AS IS_Equipment, Q.SURVEY_NO,
                            case when TypeOfEquipment=39 then 'MFV' when TypeOfEquipment=40 then 'RDAS' else ' ' end AS TypeOfEquipment
                            from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE V
                            join jpmms.VW_EQUIPQC_LATEST_SURVEYS EQ on  EQ.MAIN_NO=V.MAIN_NO and EQ.SURVEY_NO=V.SURVEY_NO
                            join jpmms.EQUIPMENTMAINQC Q on Q.MAIN_NO = V.MAIN_NO and Q.SURVEY_NO=EQ.SURVEY_NO
                            left join jpmms.STREETSQC SE  on Q.MAIN_NO = SE.MAIN_NO where  Q.ROWDATA=1 and IS_CLOSED=0  and SE.IS_Equipment is null
                and Q.SURVEY_NO> (select min(SURVEY_NO) from jpmms.EQUIPMENTMAINQC where MAIN_NO=EQ.MAIN_NO) and (Q.DONE_BY=1 or Q.DONE_BY is null) and Q.SURVEY_NO={0} order by Q.SURVEY_NO,Q.MAIN_NO,TRANSFARE_ERROR desc ,IS_TRANSFARE  desc", SURVEY_NO);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetFinshedSTREETSMFV()
        {
            string sql = @"select row_number() OVER (ORDER BY V.MAIN_NO) ID,V.MAIN_NO,Arname,DECODE(ROWDATA, 0, 'True', 'False') AS 
                          ROWDATA ,DECODE(IS_TRANSFARE, 0, 'True', 'False') AS IS_TRANSFARE ,STREET_IRI_LEN,V.SURVEY_NO,
                          CASE WHEN TypeOfEquipment = 39 THEN 'MFV' WHEN TypeOfEquipment = 40 THEN 'RDAS' ELSE ' ' END AS TypeOfEquipment 
                          from JPMMS.EQUIPMENTMAINQC V join jpmms.VW_EQUIPQC_LATEST_SURVEYS 
                          EQ on  EQ.MAIN_NO=V.MAIN_NO and V.SURVEY_NO=EQ.SURVEY_NO where IS_CLOSED=0 and IS_TRANSFARE=1 order by ROWDATA";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetFinshedSTREETSMFVCount()
        {
            string sql = @"select V.* from  JPMMS.EQUIPMENTMAINQC V join jpmms.VW_EQUIPQC_LATEST_SURVEYS 
                    EQ on  EQ.MAIN_NO=V.MAIN_NO and V.SURVEY_NO=EQ.SURVEY_NO where ROWDATA=1 and  IS_TRANSFARE =1";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetFinshedSTREETSQC()
        {
            string sql = @"select ST.MAIN_NO,ST.STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY from JPMMS.STREETSQC ST
                            join JPMMS.EQUIPMENTMAINQC EQ on ST.MAIN_NO = EQ.MAIN_NO
                            where ST.IS_DATAENTRYFINSH=1 group by ST.MAIN_NO,ST.STREET_ID  order by ST.MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedUpdateingIRI()
        {
            string sql = @"select  row_number() OVER (ORDER BY MAIN_NO) ID ,
                            MAIN_NO,STREET_ID,ARNAME,
                            DECODE(EDITING, 1, 'True', 'False') AS EDITING, 
                            DECODE(DRAWING, 1, 'True', 'False') AS DRAWING,
                            DECODE(IS_REVIEW_EDITING, 1, 'True', 'False') AS IS_REVIEW_EDITING
                            from JPMMS.STREETSQC where UPDATING=1";
            return db.ExecuteQuery(sql);
        }
        public bool UpdateRecivedFinshedIRI(string MAIN_NO, bool Finshed, bool UPDATING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql;
                //if (Finshed && UPDATING == false)
                if (UPDATING)
                    sql = string.Format("update STREETSQC set  UPDATING='{1}' ,IS_REVIEW_EDITING=0 ,Finshed=0 , IS_REVIEW_ANALYZ=0 where MAIN_NO='{0}'", MAIN_NO, UPDATING == true ? 1 : 0);
                else
                    sql = string.Format("update STREETSQC set  Finshed='{1}'  where MAIN_NO='{0}'", MAIN_NO, Finshed == true ? 1 : 0);

                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool InsertCleanDDF(string Section_no, string LANE, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(Section_no) || string.IsNullOrEmpty(LANE) || string.IsNullOrEmpty(SURVEY_NO))
                return false;
            else if (Section_no.Length < 10 || Section_no.Length > 11)
                return false;
            else
            {
                string sql;
                if (Section_no.Length == 10)
                    sql = string.Format(@"insert into jpmms.ddf select '{0}' SECTION,'{1}' LANE,DATE1,STREETNO,'CLEAN' DISTRESSTYPE,0  MPID,'N'  SEVERITY , 
NULL  MAXSEVERITYLEVEL  , 
NULL  WIDTHM            , 
0  LENGTHM           , 
0  AREAM             , 
NULL  LOCATION_STATIONM , 
NULL  FROMM             , 
NULL  TOM               , 
NULL  LATITUDE          , 
NULL  LONGITUDE         , 
NULL  ALTITUDE          , 
NULL  ISVALID           , 
(select max(RECORD_ID)+1 from jpmms.ddf)   RECORD_ID    , 
{2}  SURVEY_NO ,DONE_BY      from jpmms.ddf  where STREETNO=SUBSTR('{0}', -4) and DONE_BY is not null and rownum=1 --and  SECTION='{0}'", Section_no, LANE, SURVEY_NO);
                else
                    sql = string.Format(@"insert into jpmms.ddf select '{0}' SECTION,'{1}' LANE,DATE1,STREETNO,'CLEAN' DISTRESSTYPE,0  MPID,'N'  SEVERITY , 
NULL  MAXSEVERITYLEVEL  , 
NULL  WIDTHM            , 
0  LENGTHM           , 
0  AREAM             , 
NULL  LOCATION_STATIONM , 
NULL  FROMM             , 
NULL  TOM               , 
NULL  LATITUDE          , 
NULL  LONGITUDE         , 
NULL  ALTITUDE          , 
NULL  ISVALID           , 
(select max(RECORD_ID)+1 from jpmms.ddf)   RECORD_ID    , 
{2}  SURVEY_NO ,DONE_BY     from jpmms.ddf  where STREETNO=SUBSTR(SUBSTR('{0}', -5),0,4) and DONE_BY is not null and rownum=1 --and  SECTION='{0}'", Section_no, LANE, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool DeleteCleanDDF(string Section_no, string LANE, string SURVEY_NO)
        {
            if (string.IsNullOrEmpty(Section_no) || string.IsNullOrEmpty(LANE) || string.IsNullOrEmpty(SURVEY_NO))
                return false;
            else if (Section_no.Length < 10 || Section_no.Length > 11)
                return false;
            else
            {
                string sql;
                if (Section_no.Length == 10)
                    sql = string.Format(@"delete from JPMMS.DDF where STREETNO=SUBSTR('{0}', -4) and SECTION='{0}' and DISTRESSTYPE='CLEAN' and  MPID=0 and SEVERITY='N' and LANE='{1}' and SURVEY_NO={2}", Section_no, LANE, SURVEY_NO);
                else
                    sql = string.Format(@"delete from JPMMS.DDF where STREETNO=SUBSTR(SUBSTR('{0}', -5),0,4) and SECTION='{0}' and DISTRESSTYPE='CLEAN' and  MPID=0 and SEVERITY='N' and LANE='{1}' and SURVEY_NO={2}", Section_no, LANE, SURVEY_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRecivedFinshedIRIANALYZE(string MAIN_NO, bool ANALYZE, bool UPDATING, bool EDITING, bool DRAWING, bool IS_NOTCOMPLETE)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {

                string sql;
                if (IS_NOTCOMPLETE)
                    sql = string.Format("update STREETSQC set  IS_NOTCOMPLETE='{1}' ,IS_REVIEW_DRAWING=0, IS_REVIEW_EDITING=0 ,DRAWING=0, EDITING=0 ,Finshed=0,UPDATING=0, IS_Equipment=0, IS_TRANSFARE_ERROR=0 where MAIN_NO='{0}'",
                         MAIN_NO, IS_NOTCOMPLETE == true ? 1 : 0);
                else if (DRAWING)
                    sql = string.Format("update STREETSQC set  DRAWING='{1}' , IS_REVIEW_EDITING=0 , EDITING=0 ,Finshed=0, IS_Equipment=0, IS_REVIEW_DRAWING=1, UPDATING=0,IS_TRANSFARE_ERROR=0 where MAIN_NO='{0}'",
                         MAIN_NO, DRAWING == true ? 1 : 0);
                else if (UPDATING)
                    sql = string.Format("update STREETSQC set  UPDATING='{1}' ,IS_REVIEW_EDITING=0 ,Finshed=0 where MAIN_NO='{0}'", MAIN_NO, UPDATING == true ? 1 : 0);
                else if (EDITING)
                    sql = string.Format("update STREETSQC set  EDITING='{1}' ,IS_REVIEW_EDITING=0 ,Finshed=0,UPDATING=0,IS_TRANSFARE_ERROR=0 where MAIN_NO='{0}'",
                        MAIN_NO, EDITING == true ? 1 : 0);
                else sql = string.Format("update STREETSQC set  IS_REVIEW_ANALYZ='{1}'  where MAIN_NO='{0}'", MAIN_NO, ANALYZE == true ? 1 : 0);

                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public DataTable GetRecivedFinshedIRIANALYZE()
        {
            string sql = @"select   Q.MAIN_NO,Q.STREET_ID,Q.ARNAME,
                            DECODE(IS_REVIEW_ANALYZ, 1, 'True', 'False') AS ANALYZE ,
                            DECODE(case when (D.DONE_BY=39 or D.DONE_BY=40) and D.SURVEY_NO=EQ.SURVEY_NO then 1 else 0 end , 1, 'True', 'False') AS   DISTRESS ,
                            DECODE(Q.UPDATING, 1, 'True', 'False') AS UPDATING ,
                            DECODE(Q.EDITING, 1, 'True', 'False') AS EDITING ,
                            DECODE(Q.DRAWING, 1, 'True', 'False') AS DRAWING,
                            DECODE(Q.IS_NOTCOMPLETE, 1, 'True', 'False') AS IS_NOTCOMPLETE,
                            EQ.SURVEY_NO,
                            case when TypeOfEquipment=39 then 'MFV' when TypeOfEquipment=40 then 'RDAS' else ' ' end AS TypeOfEquipment
                            from JPMMS.STREETSQC Q join JPMMS.EQUIPMENTMAINQC EQ on Q.MAIN_NO=EQ.MAIN_NO 
                            and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO) 
                            LEFT join JPMMS.DISTRESS D on D.STREET_ID=Q.STREET_ID AND (D.DONE_BY=39 or D.DONE_BY=40) and D.SURVEY_NO=EQ.SURVEY_NO
                            WHERE Q.IS_REVIEW_EDITING=1 and Q.FINSHED=0 and Q.IS_REVIEW_ANALYZ=0 order by Q.MAIN_NO ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedFinshedIRI(bool CLEARANCE)
        {
            string sql;
            if (CLEARANCE)
                sql = @"select * from (select t.*,row_number() over (ORDER BY t.FINSHED ASC,t.STREET_IRI_LEN desc) line_number FROM jpmms.FINSHEDIRI t  where CLEARANCE_DDF is null )"; //WHERE line_number between 1 AND 300;
            else
                sql = @"select * from (select t.*,row_number() over (ORDER BY t.FINSHED ASC,t.STREET_IRI_LEN desc) line_number FROM jpmms.FINSHEDIRI t  where CLEARANCE_DDF is not null )";//WHERE line_number between 1 AND 300;
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedEditIRI()
        {
            string sql = @"select  row_number() OVER (ORDER BY Q.MAIN_NO) ID ,
                            Q.MAIN_NO,Q.STREET_ID,Q.ARNAME,
                            DECODE(Q.UPDATING, 1, 'True', 'False') AS UPDATING ,
                            DECODE(Q.IS_TRANSFARE_ERROR, 1, 'True', 'False') AS IS_TRANSFARE_ERROR ,
                            SURVEY_NO       
                            from JPMMS.STREETSQC  Q join 
                            JPMMS.EQUIPMENTMAINQC  EQ on EQ.MAIN_NO = Q.MAIN_NO
                            where Q.EDITING=1 and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO ) ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetErorrSectionLane()
        {
            string sql = @"  select s.main_no,LANE_TYPE,s.section_NO,s.section_ID from jpmms.lane s 
          left join jpmms.sections r  on
          r.section_ID=s.section_ID and r.section_no=s.section_no
          where 
          (r.section_no is null or r.section_ID is null)
          order by main_no";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsIdIRI()
        {
            string sql = string.Format(@"select MAIN_NO,ARNAME,SURVEY_NO from JPMMS.EQUIPMENTMAINQC where (main_no,SURVEY_NO) in(
select                      distinct main_no,SURVEY_NO from JPMMS.IRI where SURVEY_NO>2 and SECTION_ID is null  group by SECTION_NO,SURVEY_NO,main_no )");
            return db.ExecuteQuery(sql);
        }
        public bool UpdateSectionsInfo(bool? Is_Draw)
        {
            try
            {
                string sql;
                if (Is_Draw.HasValue)
                {
                    sql = @"begin
  savepoint my_savepoint_sec;
begin
delete JPMMS.SECTIONSUPDATE;
insert into JPMMS.SECTIONSUPDATE
select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from JPMMS.VW_SECTIONS_UPDATE where (SECTION_ID,SECTION_NO)
in (select  SECTION_ID,SECTION_NO from (select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from jpmms.sections where 
MAIN_NO is null or REGION_NO is null or ARNAME is null or MUNICIPALITY is null or STREET_ID is null 
union  select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from jpmms.sections where 
SECTION_NO in (select section_no from JPMMS.SECTIONSUPDATE group by section_no having count(section_no)>1)));
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,New.REGION_NO as NEW_REGION_NO , old.REGION_NO as OLD_REGION_NO
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_REGION_NO=t.NEW_REGION_NO;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.MAIN_NO as NEW_MAIN_NO,old.MAIN_NO as OLD_MAIN_NO
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_MAIN_NO=t.NEW_MAIN_NO;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.STREET_ID as NEW_STREET_ID,old.STREET_ID as OLD_STREET_ID
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_STREET_ID=t.NEW_STREET_ID;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.ARNAME as NEW_ARNAME,old.ARNAME as OLD_ARNAME
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_ARNAME=t.NEW_ARNAME;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.MUNICIPALITY as NEW_MUNICIPALITY,old.MUNICIPALITY as OLD_MUNICIPALITY
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_MUNICIPALITY=t.NEW_MUNICIPALITY;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO my_savepoint_sec;
    RAISE;
END;
 commit;
end;
";
                }
                else
                {
                    sql = @"begin
  savepoint my_savepoint_sec;
begin
delete JPMMS.SECTIONSUPDATE;
insert into JPMMS.SECTIONSUPDATE
select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from JPMMS.VW_SECTIONS_UPDATE;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,New.REGION_NO as NEW_REGION_NO , old.REGION_NO as OLD_REGION_NO
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_REGION_NO=t.NEW_REGION_NO;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.MAIN_NO as NEW_MAIN_NO,old.MAIN_NO as OLD_MAIN_NO
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_MAIN_NO=t.NEW_MAIN_NO;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.STREET_ID as NEW_STREET_ID,old.STREET_ID as OLD_STREET_ID
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_STREET_ID=t.NEW_STREET_ID;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.ARNAME as NEW_ARNAME,old.ARNAME as OLD_ARNAME
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_ARNAME=t.NEW_ARNAME;
UPDATE 
(
SELECT  NEW.SECTION_ID,NEW.SECTION_NO,NEW.MUNICIPALITY as NEW_MUNICIPALITY,old.MUNICIPALITY as OLD_MUNICIPALITY
FROM JPMMS.SECTIONS old 
join JPMMS.SECTIONSUPDATE New on 
New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD_MUNICIPALITY=t.NEW_MUNICIPALITY;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO my_savepoint_sec;
    RAISE;
END;
 commit;
end;
";
                }
                if (db.ExecuteNonQuery(sql) > 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
        public DataTable CheckUpdateSectionsInfo()
        {
            string sql = @"select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from  JPMMS.VW_SECTIONS_UPDATE where SECTION_NO in 
                            (select SECTION_NO from (select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from JPMMS.VW_SECTIONS_UPDATE) group by 
                                SECTION_NO having count(1)>1 ) order by SECTION_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedEditIRILanes()
        {
            string sql = @"select  row_number() OVER (ORDER BY MAIN_NO) ID ,
                            MAIN_NO,STREET_ID,ARNAME,
                            DECODE(IS_LANEDRAW, 0, 'True', 'False') AS UPDATING                             
                            from JPMMS.STREETSQC where IS_LANEDRAW=1 ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedEditIRISampleLanes()
        {
            string sql = @"select  row_number() OVER (ORDER BY MAIN_NO) ID ,
                            MAIN_NO,STREET_ID,ARNAME,
                            DECODE(IS_SAMPLEDRAW, 0, 'True', 'False') AS UPDATING                             
                            from JPMMS.STREETSQC where IS_SAMPLEDRAW=1 ";
            return db.ExecuteQuery(sql);
        }
        public bool UpdateRecivedUpdateingIRI(string MAIN_NO, bool DRAWING, bool EDITING, bool IS_REVIEW_EDITING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql;
                if (IS_REVIEW_EDITING)
                    sql = string.Format("update STREETSQC set DRAWING=0 , EDITING=0 ,UPDATING=0,IS_REVIEW_EDITING=1,IS_TRANSFARE_ERROR=0 where MAIN_NO='{0}'", MAIN_NO);
                else if (DRAWING || EDITING)
                    sql = string.Format("update STREETSQC set DRAWING='{0}' , EDITING='{1}' ,UPDATING=0,IS_TRANSFARE_ERROR=0 where MAIN_NO='{2}'",
                        DRAWING == true ? 1 : 0, EDITING == true ? 1 : 0, MAIN_NO);
                else
                    sql = string.Format("update STREETSQC set DRAWING='{0}' , EDITING='{1}' ,IS_TRANSFARE_ERROR=0  where MAIN_NO='{2}'",
                                         DRAWING == true ? 1 : 0, EDITING == true ? 1 : 0, MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRecivedEditIRILanes(string MAIN_NO, bool UPDATING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql = string.Format("update STREETSQC set  IS_SAMPLEDRAW=1 , IS_LANEDRAW=0 where MAIN_NO='{0}'",
                          MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRecivedEditIRISampleLanes(string MAIN_NO, bool UPDATING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql = string.Format("update STREETSQC set  IS_SAMPLEDRAW=0 , IS_SAMPLEFISHED=1 where MAIN_NO='{0}'",
                          MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRecivedEditIRI(string MAIN_NO, bool UPDATING, bool IS_TRANSFARE_ERROR)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql = string.Format("update STREETSQC set  EDITING=0 , IS_REVIEW_DRAWING=0 ,IS_TRANSFARE_ERROR={1} where MAIN_NO='{0}'",
                          MAIN_NO, IS_TRANSFARE_ERROR == true ? 1 : 0);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRecivedCompleteDrawingIRI(string MAIN_NO, bool IS_REVIEW_EDITING, bool EDITING, bool DRAWING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql;
                if (DRAWING || EDITING || IS_REVIEW_EDITING)
                    sql = string.Format("update STREETSQC set IS_REVIEW_EDITING='{0}' , EDITING='{1}' , DRAWING='{2}',IS_DRAWINGFINSH=0 where MAIN_NO='{3}'",
                         IS_REVIEW_EDITING == true ? 1 : 0, EDITING == true ? 1 : 0, DRAWING == true ? 1 : 0, MAIN_NO);
                else
                    sql = string.Format("update STREETSQC set IS_REVIEW_EDITING='{0}' , EDITING='{1}' , DRAWING='{2}' where MAIN_NO='{3}'",
                     IS_REVIEW_EDITING == true ? 1 : 0, EDITING == true ? 1 : 0, DRAWING == true ? 1 : 0, MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public DataTable GetRecivedCompleteDrawingIRI()
        {
            string sql = @"select  row_number() OVER (ORDER BY Q.MAIN_NO) ID ,
                            Q.MAIN_NO,Q.STREET_ID,Q.ARNAME,
                            DECODE(Q.IS_REVIEW_EDITING, 1, 'True', 'False') AS IS_REVIEW_EDITING, 
                            DECODE(Q.EDITING, 1, 'True', 'False') AS EDITING ,
                            DECODE(Q.DRAWING, 1, 'True', 'False') AS DRAWING,
                            SURVEY_NO, case when TypeOfEquipment=39 then 'MFV' when TypeOfEquipment=40 then 'RDAS' else ' ' end AS TypeOfEquipment from JPMMS.STREETSQC Q join 
                            JPMMS.EQUIPMENTMAINQC  EQ on EQ.MAIN_NO = Q.MAIN_NO 
                            where EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO ) and  Q.IS_DATAENTRYFINSH=1 and Q.IS_DRAWINGFINSH=1";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedEditingIRI()
        {
            string sql = @"select  row_number() OVER (ORDER BY SQ.MAIN_NO) ID ,
                            SQ.MAIN_NO,SQ.STREET_ID,SQ.ARNAME,
                            DECODE(SQ.IS_REVIEW_EDITING, 1, 'True', 'False') AS IS_REVIEW_EDITING, 
                            DECODE(SQ.EDITING, 1, 'True', 'False') AS EDITING ,
                            DECODE(SQ.DRAWING, 1, 'True', 'False') AS DRAWING,
                            DECODE(SQ.UPDATING, 1, 'True', 'False') AS UPDATING,
                            DECODE(IS_TRANSFARE_ERROR, 1, 'True', 'False') AS IS_TRANSFARE_ERROR,
                            DECODE(IS_Equipment, 1, 'True', 'False') AS IS_Equipment,
                            DECODE(case when SQ.IS_REVIEW_EDITING=0 and SQ.EDITING=0 and SQ.DRAWING =0 and SQ.UPDATING=0 and IS_TRANSFARE_ERROR=0 and IS_Equipment=0 then 1 else 0 end, 1, 'True', 'False') AS NEW,
                            SURVEY_NO,DECODE((select case when  count(1)>=1 then 1 else 0 end from JPMMS.SECTIONS where main_no=EQ.main_no ),0,'True', 'False') AS IS_StreetNew,
                            case when TypeOfEquipment=39 then 'MFV' when TypeOfEquipment=40 then 'RDAS' else ' ' end AS TypeOfEquipment
                            from JPMMS.STREETSQC SQ join JPMMS.EQUIPMENTMAINQC EQ on EQ.STREET_ID = SQ.STREET_ID and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where SQ.STREET_ID=STREET_ID )
                            where IS_NOTCOMPLETE=0 and SQ.IS_DATAENTRYFINSH=1 and (SQ.UPDATING=1 or SQ.IS_REVIEW_DRAWING=0)";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedDrawingIRI()
        {
            string sql = @"select  row_number() OVER (ORDER BY SQ.MAIN_NO) ID ,
                            SQ.MAIN_NO,SQ.STREET_ID,SQ.ARNAME,
                            DECODE(SQ.IS_DRAWINGFINSH, 1, 'True', 'False') AS IS_DRAWINGFINSH, 
                            DECODE(SQ.UPDATING, 1, 'True', 'False') AS UPDATING   ,
                            DECODE(SQ.IS_LANEDRAW, 1, 'True', 'False') AS IS_LANEDRAW, 
                            DECODE(SQ.IS_SAMPLEDRAW, 1, 'True', 'False') AS IS_SAMPLEDRAW,
                            DECODE(SQ.IS_SAMPLEFISHED, 1, 'True', 'False') AS IS_SAMPLEFISHED,
                            DECODE(case when SQ.IS_DRAWINGFINSH=0 and SQ.UPDATING=0 and SQ.IS_LANEDRAW =0 and SQ.IS_SAMPLEDRAW=0 and SQ.IS_SAMPLEFISHED=0 then 1 else 0 end, 1, 'True', 'False') AS NEW,
                            SURVEY_NO,DECODE((select case when  count(1)>=1 then 1 else 0 end from JPMMS.SECTIONS where main_no=EQ.main_no ),0,'True', 'False') AS IS_StreetNew
                            from JPMMS.STREETSQC SQ join JPMMS.EQUIPMENTMAINQC EQ on EQ.STREET_ID = SQ.STREET_ID and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where SQ.STREET_ID=STREET_ID ) where SQ.DRAWING=1 ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRecivedDrawingIntersectionsIRI()
        {
            string sql = @"select distinct EQ.MAIN_NO,EQ.STREET_ID,EQ.ARNAME,
                        DECODE((select case when  count(1)>=1 then 1 else 0 end from JPMMS.INTERSECTIONS where main_no=EQ.main_no ),0,'True', 'False') AS IS_StreetNew
                        from JPMMS.EQUIPMENTMAINQC EQ ";
            return db.ExecuteQuery(sql);
        }
        public bool UpdateRecivedDrawingIRI(string MAIN_NO, bool IS_DRAWINGFINSH, bool UPDATING, bool IS_SAMPLEDRAW, bool IS_LANEDRAW, bool IS_SAMPLEFISHED)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql;
                if (UPDATING || IS_DRAWINGFINSH)
                    sql = string.Format("update STREETSQC set FINSHED=0, IS_DRAWINGFINSH='{0}' , UPDATING='{1}' ,DRAWING=0 where MAIN_NO='{2}'",
                                       IS_DRAWINGFINSH == true ? 1 : 0, UPDATING == true ? 1 : 0, MAIN_NO);
                else
                    sql = string.Format("update STREETSQC set FINSHED=0, IS_DRAWINGFINSH='{0}' , UPDATING='{1}' , IS_SAMPLEDRAW='{2}' ,IS_LANEDRAW='{3}' ,IS_SAMPLEFISHED=0 where MAIN_NO='{4}'",
                        IS_DRAWINGFINSH == true ? 1 : 0, UPDATING == true ? 1 : 0, IS_SAMPLEDRAW == true ? 1 : 0, IS_LANEDRAW == true ? 1 : 0, MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool UpdateRecivedEditingIRI(string MAIN_NO, bool IS_REVIEW_EDITING, bool EDITING, bool DRAWING, bool IS_Equipment, bool UPDATING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql;
                if (IS_Equipment)
                    sql = string.Format(@"update STREETSQC set FINSHED=0 ,EDITING=0,UPDATING=0,DRAWING=0,IS_REVIEW_DRAWING=0,IS_REVIEW_EDITING=0,
                                          IS_DATAENTRYFINSH=0,IS_DRAWINGFINSH=0,IS_LANEDRAW=0,IS_SAMPLEDRAW=0,IS_SAMPLEFISHED=0,IS_Equipment=1 where MAIN_NO='{0}'", MAIN_NO);
                else if (DRAWING || EDITING || IS_REVIEW_EDITING)
                    sql = string.Format("update STREETSQC set FINSHED=0 ,IS_REVIEW_EDITING='{0}' , EDITING='{1}' , DRAWING='{2}',IS_TRANSFARE_ERROR=0,IS_Equipment=0, IS_REVIEW_DRAWING=1, UPDATING=0 where MAIN_NO='{3}'",
                         IS_REVIEW_EDITING == true ? 1 : 0, EDITING == true ? 1 : 0, DRAWING == true ? 1 : 0, MAIN_NO);
                else if (UPDATING)
                    sql = string.Format(@"update STREETSQC set FINSHED=0 ,EDITING=0,UPDATING=1,DRAWING=0,IS_REVIEW_DRAWING=0,IS_REVIEW_EDITING=0,
                                          IS_DRAWINGFINSH=0,IS_LANEDRAW=0,IS_SAMPLEDRAW=0,IS_SAMPLEFISHED=0 where MAIN_NO='{0}'", MAIN_NO);
                else
                    sql = string.Format("update STREETSQC set FINSHED=0 , IS_REVIEW_EDITING='{0}' , EDITING='{1}' , DRAWING='{2}' ,IS_TRANSFARE_ERROR=0,IS_Equipment=0, UPDATING=0 where MAIN_NO='{3}'",
                     IS_REVIEW_EDITING == true ? 1 : 0, EDITING == true ? 1 : 0, DRAWING == true ? 1 : 0, MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public bool DeleteRecivedIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format("delete JPMMS.STREETSQC where MAIN_NO='{0}' and IS_GPR=0 and IS_SKID=0 and IS_ASSETS=0 and IS_IRI=0 and IS_DDF=0 and IS_EQUIPMENT=0 ", MAIN_NO);
            db.ExecuteNonQuery(sql);

            sql = string.Format(@"update jpmms.EQUIPMENTMAINQC set ROWDATA=1 where  ROWDATA=0 and IS_CLOSED=0 and MAIN_NO='{0}' and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            int value = db.ExecuteNonQuery(sql);

            if (value > 0)
                return true;
            else
                return false;
        }
        public bool CheckStreetsIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select distinct MAIN_NO from IRI where survey_no>=3 and MAIN_NO='{0}' and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            object value = db.ExecuteScalar(sql);
            if (value != null && !string.IsNullOrEmpty(value.ToString()) && value.ToString() != "0")
                return true;
            else
                return false;
        }
        public DataTable GetDrawingStreetsIRI()
        {
            string sql = string.Format(@"select MAIN_NO,ARNAME,nvl(STREET_SHAPE_LEN,0) SHAPE_LEN,nvl(STREET_IRI_LEN,0) IRI_LEN,
                                    nvl(SECTIONS_SYS,0)SECTIONS_SYS,nvl(LANES_SYS,0)LANES_SYS,nvl(IRI_SECTIONS,0)IRI_SECTIONS,nvl(IRI_LANES,0)IRI_LANES,
                                    abs(case when IRI_SECTIONS=SECTIONS_SYS then 0 else nvl(IRI_SECTIONS,0)-nvl(SECTIONS_SYS,0)end )   SECTIONS_NEW,
                                    abs (case when IRI_LANES=LANES_SYS then 0 else nvl(IRI_LANES,0)-nvl(LANES_SYS,0)end ) LANES_NEW,
                                    nvl((select count(L.MAIN_NO) from JPMMS.IRI_LENGHTH_TEST ISC join JPMMS.LANE L on L.SECTION_ID = ISC.SECTION_ID AND
                                    L.LANE_TYPE=ISC.LANE AND L.MAIN_NO = ISC.MAIN_NO left join JPMMS.LANE_SAMPLES LS on LS.LANE_ID = L.LANE_ID where
                                    L.MAIN_NO=X.MAIN_NO and LS.SAMPLE_NO is null group by L.MAIN_NO),0) SAMPLES_NEW
                                    from jpmms.EQUIPMENTMAINQC X where main_no in (select main_no from JPMMS.STREETSQC where DRAWING=1) 
                                    and SURVEY_NO=(select max(SURVEY_NO) from jpmms.EQUIPMENTMAINQC where main_no=x.main_no)
                                    order by STREET_IRI_LEN desc,STREET_SHAPE_LEN desc,MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public bool InsertRecivedIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"insert into  JPMMS.STREETSQC 
                                        select S.MAIN_NO,S.STREET_ID,S.ARNAME, case when survey_no is null then 0 else 1 end Finshed,
                                        0 EDITING , 0 UPDATING , 0 DRAWING ,0 IS_REVIEW_DRAWING,0 IS_REVIEW_EDITING,1 IS_DATAENTRYFINSH,
                                        0 IS_DRAWINGFINSH,0 IS_LANEDRAW, 0 IS_SAMPLEDRAW,0 IS_SAMPLEFISHED,0 IS_TRANSFARE_ERROR,
                                        0 STREET_IRI_LEN ,0 STREET_SHAPE_LEN ,0 IS_GPR,0 IS_SKID,0 IS_NOTCOMPLETE ,0 IS_IRI ,0 IS_DDF ,
                                        0 COMPLETIMG ,0 IS_ASSETS ,0 IS_EQUIPMENT ,0 IS_REVIEW_ANALYZ ,0 SECTIONS_SYS , 0 LANES_SYS ,
                                        0 IRI_SECTIONS , 0 IRI_LANES , 0 GPR_SECTIONS , 0 GPR_LANES , 0 SKID_SECTIONS , 0 SKID_LANES , 0 FWD_SECTIONS ,0 FWD_LANES 
                                        from  jpmms.STREETIRI S left join jpmms.DISTRESSIRI D on D.STREET_ID =S.STREET_ID where MAIN_NO='{0}'", MAIN_NO);
            db.ExecuteNonQuery(sql);

            sql = string.Format(@"update jpmms.EQUIPMENTMAINQC set ROWDATA=0 where  ROWDATA=1 and IS_CLOSED=0 and MAIN_NO='{0}' and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            int value = db.ExecuteNonQuery(sql);

            if (value > 0)
                return true;
            else
                return false;
        }
        public bool UpdateFailIRIMFV(string MAIN_NO, bool TRANSFARE_ERROR, string SURVEY_NO)
        {
            string sql = string.Format(@"update jpmms.EQUIPMENTMAINQC set TRANSFARE_ERROR={0} ,IS_TRANSFARE=0 where  ROWDATA=1 and IS_CLOSED=0 and MAIN_NO='{1}' and SURVEY_NO={2}", TRANSFARE_ERROR == true ? 1 : 0, MAIN_NO, SURVEY_NO);
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public DataTable FinshedRrturnToMFV()
        {
            string sql = string.Format(@"Select  row_number() OVER (ORDER BY MAIN_NO) ID ,MAIN_NO,STREET_ID,ARNAME,
                                         DECODE(IS_TRANSFARE_ERROR, 1, 'True', 'False') AS IS_TRANSFARE_ERROR,
                                         DECODE(IS_EQUIPMENT, 1, 'True', 'False') AS IS_EQUIPMENT ,
                                         DECODE(EDITING, 1, 'True', 'False') AS EDITING from jpmms.STREETSQC where IS_EQUIPMENT=1 ");
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable StatisticsToMFV(string SURVEY_NO)
        {
//            string sql = string.Format(@"select * from 
//                                        (select count(MAIN_NO)STREETS from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={1}),
//                                        (select count(MAIN_NO)STREETSQC from jpmms.STREETSEQUIPMENTQC where SURVEY_NO={0}),
//                                        (select count(MAIN_NO)ERORRS from jpmms.EQUIPMENTMAINQC where SURVEY_NO={1} and main_no not in (select MAIN_NO from jpmms.STREETSEQUIPMENTQC where SURVEY_NO={1}) 
//                                        and main_no not in  (select MAIN_NO from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0})),
//                                        (select count(MAIN_NO)ALLSTREETS from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0}),
//                                        (select count(MAIN_NO)CompleteIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_IRI=1),
//                                        (select count(MAIN_NO)MinusIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_IRI=0),
//                                        (select count(MAIN_NO)OpenMinusIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_IRI=0 and is_closed=0),
//                                        (select count(MAIN_NO)ClosedMinusIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_IRI=0 and is_closed=1)", SURVEY_NO, int.Parse(SURVEY_NO) <= 3 ? 3 : int.Parse(SURVEY_NO) - 1);
            string sql = string.Format(@"select * from 
                                                    (select count(MAIN_NO)STREETS from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={1} and is_IRI=1),
                                                    (select count(MAIN_NO)STREETSQC from jpmms.STREETSEQUIPMENTQC where SURVEY_NO={0}),
                                                    (select count(MAIN_NO)ERORRS from jpmms.EQUIPMENTMAINQC where IS_TRANSFARE=0 and ROWDATA=1 and is_closed=0 and SURVEY_NO={0}),
                                                    (select count(MAIN_NO)ALLSTREETS from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0}),
                                                    (select count(MAIN_NO)CompleteIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_IRI=1),
                                                    (select count(MAIN_NO)MinusIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_IRI=0  ),
                                                    (select count(MAIN_NO)OpenMinusIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and  is_closed=0),
                                                    (select count(MAIN_NO)ClosedMinusIRI from JPMMS.EQUIPMENTMAINQC where SURVEY_NO={0} and is_closed=1)", SURVEY_NO, int.Parse(SURVEY_NO) <= 3 ? 3 : int.Parse(SURVEY_NO) - 1);
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable FinshedRrturnToMFVDelete()
        {
            string sql = string.Format(@"Select distinct  Q.MAIN_NO,STREET_ID,ARNAME,
                                         DECODE(IS_TRANSFARE_ERROR, 1, 'True', 'False') AS IS_TRANSFARE_ERROR,
                                         DECODE(IS_EQUIPMENT, 1, 'True', 'False') AS IS_EQUIPMENT ,
                                         DECODE(EDITING, 1, 'True', 'False') AS EDITING ,SURVEY_NO from jpmms.STREETSQC Q
                                         join jpmms.iri I on I.main_no=Q.main_no 
                                         where SURVEY_NO=(select max(SURVEY_NO) from EQUIPMENTMAINQC where main_no=I.main_no) and IS_EQUIPMENT=1 ");
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable FinshedRrturnToMFVMaintenance()
        {
            //            string sql = string.Format(@"select MAIN_NO,ARNAME,REPORTSMAINQC.STREET_IRI_LEN,STREET_ID from REPORTSMAINQC where STREET_ID in 
            //                                         (select STREET_ID from REPORTSMAINQC where IS_DDF=1 minus select STREET_ID from MAINTENANCE_DECISIONS where SURVEY_NO=3 
            //                                         and SECTION_ID is not null group by  STREET_ID)");
            string sql = string.Format(@"select  MAIN_NO,ARNAME,STREET_IRI_LEN,STREET_ID from jpmms.EQUIPMENTMAINQC  where (STREET_ID,SURVEY_NO) in (select STREET_ID,SURVEY_NO from jpmms.EQUIPMENTMAINQC  where IS_DDF=1 minus select STREET_ID,max(SURVEY_NO)SURVEY_NO from jpmms.MAINTENANCE_DECISIONS where SURVEY_NO>2 and SECTION_ID is not null group by  STREET_ID,SURVEY_NO)");
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable CustomMunicpilityMaintenance()
        {
            string sql = string.Format(@"select distinct STREET_ID from jpmms.sections where MUNICIPALITY in ('بلدية طيبة','بلدية الصفا','بلدية الشرفية','بلدية المليساء','بلدية جدة التاريخية')
                                            and SECTION_ID in (select distinct SECTION_ID from jpmms.GV_SAMPLES where SAMPLE_LENGTH<>0 and SAMPLE_WIDTH<>0)");
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public bool UpdateReadyFWD(string SECTION_NO, string LANE, string Record_IDs, bool FINSHED)
        {
            try
            {
                if (string.IsNullOrEmpty(SECTION_NO) || string.IsNullOrEmpty(LANE) || string.IsNullOrEmpty(Record_IDs))
                    return false;

                string sql = string.Format(@"update jpmms.fwd set SECTION_NO='{1}', Lane='{2}' ,FINSHED={3} where RECORD_ID in ({0})"
                    , Record_IDs, SECTION_NO, LANE, FINSHED == true ? 1 : 0);
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateFinshedReadyFWD(string main_no)
        {
            try
            {
                if (string.IsNullOrEmpty(main_no))
                    return false;
                string sql = string.Format(@"update jpmms.fwd set FWD=1 where main_no ='{0}'", main_no);
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteReadyFWD(string Record_IDs)
        {
            try
            {
                if (string.IsNullOrEmpty(Record_IDs))
                    return false;
                string sql = string.Format(@"update jpmms.fwd set SECTION_NO=null, Lane=null ,FINSHED=0 where RECORD_ID in ({0})", Record_IDs);
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool ValidateReadyFWD(string main_no)
        {
            try
            {
                if (string.IsNullOrEmpty(main_no))
                    return false;
                string sql = string.Format(@"SELECT (select count(FINSHED) from JPMMS.FWD where FWD is null and main_no ='{0}') - 
                (select count(FINSHED) from JPMMS.FWD where FWD is null and main_no ='{0}' and  FINSHED=1) T FROM dual", main_no);
                return db.ExecuteScalar(sql).ToString() == "0" ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable ReadyFWD(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = @"select MAIN_NO,STREET_ID from STREETS where street_Type=1 and 
                        MAIN_NO in (select distinct MAIN_NO from fwd where survey_no>=3 and FWD is null) order by MAIN_NO";
            else
                sql = string.Format(@"select MAIN_NO,SECTION_NO,STATION_ID,DROP_ID,STATION,LANE,ASPHALT_TEMPERATURE,SURFACE_TEMPERATURE
                        ,AIR_TEMPERATURE,SURVEY_DATE,SURVEY_TIME,RECORD_ID,DECODE(FINSHED, 1, 'True', 'False') AS FINSHED,D1 
                        from jpmms.fwd where MAIN_NO='{0}' and SURVEY_NO=3  and fwd is null order by to_number(STATION_ID),to_number(DROP_ID)", MAIN_NO);
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable FinshedReadyFWD()
        {
            string sql = string.Format(@"select S.MAIN_NO,arname,TotalDrops,DECODE(R.FWD, 1, 'False', 'True') AS FWD from STREETS S join ReadyFWD R on R.MAIN_NO=S.MAIN_NO where street_Type=1 and R.FWD is not null order by FWD,S.MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable FinshedInterSections(int STREET_ID)
        {
            string sql = string.Format(@"select INTERSECTION_ID,INTER_NO,round(sum(INTERSEC_SAMP_AREA)/3700,3) INTER_LENGTH,
                      (select count(INTERSECTION_ID) from JPMMS.DISTRESS where INTERSECTION_ID is not null and INTERSECTION_ID=Eq.INTERSECTION_ID) INTER_DISTRESS,
                      (select max(SURVEY_NO) from JPMMS.DISTRESS where INTERSECTION_ID is not null and INTERSECTION_ID=Eq.INTERSECTION_ID) SURVEY_NO        
                      from JPMMS.GV_INTERSECTION_SAMPLES EQ where STREET_ID={0} group by INTERSECTION_ID,INTER_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable ApproveInterSections(string StreetID)
        {
            int value;
            if (int.TryParse(StreetID, out value))
            {
                string sql = string.Format(@" select S.STREET_ID,S.MAIN_NO,S.INTERSECTION_ID,S.INTER_NO,INTEREC_STREET1,INTEREC_STREET2,INTER_LENGTH,INTER_DISTRESS,SURVEY_NO,
                            (select DECODE(count(INTER_NO), 0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) Recived from jpmms.INTERSECT_STATISTICS S join 
                            JPMMS.INTERSECTIONS F on S.INTERSECTION_ID=F.INTERSECTION_ID where S.STREET_ID={0} order by Recived,INTER_DISTRESS,SURVEY_NO", StreetID);
                return db.ExecuteQuery(sql);
            }
            else
                return null;
        }
        public DataTable DetialsInterSections()
        {
            string sql = string.Format(@"select S.STREET_ID,S.MAIN_NO||' '||ARNAME Title,S.INTERSECTION_ID,S.INTER_NO,INTEREC_STREET1,INTEREC_STREET2,INTER_LENGTH,INTER_DISTRESS,SURVEY_NO,
(select DECODE(count(INTER_NO), 0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) Recived,
(select DECODE( case when IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 then 1 else 0 end,0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) NotFinshed,
(select DECODE( case when IS_REVIEWREPORT=0 and IS_REVIEWGIS=1 then 1 else 0 end,0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) GIS,
(select DECODE( case when IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=1 then 1 else 0 end,0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) Finshed,
(select DECODE( IS_REVIEWDATAENTRY,0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) Reviwed,
(select DECODE( case when IS_REVIEWREPORT=1 and IS_REVIEWDATAENTRY=1 then 1 else 0 end,0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) Reports,
(select DECODE( case when IS_DATAENTRYFINSH=1 and IS_READY=1 then 1 else 0 end,0, 'False', 'True')  from JPMMS.INTERSECTQC where INTERSECTION_ID=F.INTERSECTION_ID) CLEARANCE
from jpmms.INTERSECT_STATISTICS S join JPMMS.INTERSECTIONS F on S.INTERSECTION_ID=F.INTERSECTION_ID order by  S.STREET_ID--,Recived,NotFinshed,GIS,FINSHED,Reviwed,REPORTS");
            return db.ExecuteQuery(sql);
        }
        public DataTable ApproveInterSections(bool Complete)
        {
            string sql;
            //            if (Complete)
            //                sql = string.Format(@"select STREET_ID,MAIN_NO,SURVEY_NO,TOTALINTERSECTIONS,DISTRESSINTERSECTIONS,TOTALINTERSECTIONS-DISTRESSINTERSECTIONS DIFF_INTERSECTIONS_DISTRESS,TOTALLENGTH
            //                      from(select STREET_ID,MAIN_NO,SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=INS.STREET_ID) TOTALINTERSECTIONS ,
            //                      count(INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from jpmms.INTERSECT_STATISTICS INS
            //                      where SURVEY_NO is not null   group by STREET_ID,MAIN_NO,SURVEY_NO) where TOTALINTERSECTIONS-DISTRESSINTERSECTIONS=0");
            //            else
            //                sql = string.Format(@"select STREET_ID,MAIN_NO,SURVEY_NO,TOTALINTERSECTIONS,DISTRESSINTERSECTIONS,TOTALINTERSECTIONS-DISTRESSINTERSECTIONS DIFF_INTERSECTIONS_DISTRESS,TOTALLENGTH
            //                      from(select STREET_ID,MAIN_NO,SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=INS.STREET_ID) TOTALINTERSECTIONS ,
            //                      count(INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from jpmms.INTERSECT_STATISTICS INS
            //                      where SURVEY_NO is not null   group by STREET_ID,MAIN_NO,SURVEY_NO) where TOTALINTERSECTIONS-DISTRESSINTERSECTIONS>0");

            if (Complete)
                sql = string.Format(@"select ES.STREET_ID,(select ARNAME from JPMMS.EQUIPMENTMAINQC where ES.MAIN_NO=MAIN_NO and ES.SURVEY_NO=SURVEY_NO) ARNAME ,ES.MAIN_NO,ES.SURVEY_NO,TOTALINTERSECTIONS,DISTRESSINTERSECTIONS,TOTALINTERSECTIONS-DISTRESSINTERSECTIONS DIFF_INTERSECTIONS_DISTRESS,TOTALLENGTH
                      from(select EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=EQ.STREET_ID) TOTALINTERSECTIONS ,
                      count(EQ.INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from JPMMS.INTERSECT_STATISTICS EQ
                      LEFT JOIN JPMMS.INTERSECTQC IQ ON IQ.INTER_NO = EQ.INTER_NO where  EQ.SURVEY_NO is not null and  
                      EQ.STREET_ID in (select STREET_ID from JPMMS.INTERSECTQC where IS_READY=0 )   group by EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO)ES
                      join jpmms.EQUIPMENTMAINQC RQ ON RQ.SURVEY_NO=ES.SURVEY_NO and RQ.STREET_ID=ES.STREET_ID where IS_INTERSECTIONS is null and TOTALINTERSECTIONS-DISTRESSINTERSECTIONS=0");
            else
                sql = string.Format(@"select ES.STREET_ID,(select ARNAME from JPMMS.EQUIPMENTMAINQC where ES.MAIN_NO=MAIN_NO and ES.SURVEY_NO=SURVEY_NO) ARNAME ,ES.MAIN_NO,ES.SURVEY_NO,TOTALINTERSECTIONS,DISTRESSINTERSECTIONS,TOTALINTERSECTIONS-DISTRESSINTERSECTIONS DIFF_INTERSECTIONS_DISTRESS,TOTALLENGTH
                      from(select EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=EQ.STREET_ID) TOTALINTERSECTIONS ,
                      count(EQ.INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from JPMMS.INTERSECT_STATISTICS EQ
                      LEFT JOIN JPMMS.INTERSECTQC IQ ON IQ.INTER_NO = EQ.INTER_NO where  EQ.SURVEY_NO is not null and  
                      EQ.STREET_ID in (select STREET_ID from JPMMS.INTERSECTQC where IS_READY=0 )   group by EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO)ES
                      join jpmms.EQUIPMENTMAINQC RQ ON RQ.SURVEY_NO=ES.SURVEY_NO and RQ.STREET_ID=ES.STREET_ID where IS_INTERSECTIONS is null and TOTALINTERSECTIONS-DISTRESSINTERSECTIONS>0");

            return db.ExecuteQuery(sql);
        }
        public DataTable FinshedAllStreets()
        {
            string sql = string.Format(@"select STREET_ID,MAIN_NO,ARNAME,SURVEY_NO from JPMMS.EQUIPMENTMAINQC where IS_GPR =1 and IS_SKID =1 and IS_FWD=1 and IS_IRI =1 and IS_DDF =1 and IS_ASSETS=1 order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public string SumReadyFWD(bool? fwd)
        {
            try
            {
                string sql;
                if (fwd.HasValue)
                {
                    if (fwd.Value)
                        sql = string.Format(@"select round(count(*)/3,2) from jpmms.fwd where survey_no=3 and FWD =1");
                    else
                        sql = string.Format(@"select round(count(*)/3,2) from jpmms.fwd where survey_no=3 and FWD =0");
                }
                else
                    sql = string.Format(@"select round(count(*)/3,2) from jpmms.fwd where survey_no=3 and FWD is null");

                return db.ExecuteScalar(sql).ToString();
            }
            catch
            {
                return null;
            }
        }
        public DataTable ReadySKID(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = @"select MAIN_NO,STREET_ID from STREETS where street_Type=1 and 
                        MAIN_NO in (select distinct MAIN_NO from SKID  where survey_no=4) order by MAIN_NO";
            else
                sql = string.Format(@"select * from JPMMS.SKID  where MAIN_NO='{0}' and SURVEY_NO=4  order by SECTION_NO", MAIN_NO);
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable FinshedMFVMaintenanceWithDate(string date,string SURVEY_NO)
        {
            //            string sql = string.Format(@"select distinct STREET_ID from JPMMS.DISTRESS where DONE_BY=39 and SURVEY_NO=3 and STREET_ID in 
            //                    (select distinct STREET_ID from JPMMS.VW_LATEST_UDI_SECTIONS_GIS where UDI_DATE<'{0}')", date);
            string sql = string.Format(@"select distinct STREET_ID from JPMMS.DISTRESS where (DONE_BY=39 or DONE_BY=40) and SURVEY_NO='{0}' and STREET_ID in 
                    (select distinct STREET_ID  from JPMMS.MAINTENANCE_DECISIONS where  UDI_DATE<'{0}' and SECTION_ID is not null and SURVEY_NO='{0}' ) ", date , SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable FinshedRrturnToMFVUDI()
        {
            //            string sql = string.Format(@"select MAIN_NO,ARNAME,STREET_ID from REPORTSMAINQC where STREET_ID in ((select STREET_ID from UDI_SECTION where SURVEY_NO=3 group by  STREET_ID
            //                                        minus select STREET_ID from REPORTSMAINQC where IS_DDF=1 ) union (select  STREET_ID from REPORTSMAINQC where IS_DDF=1 
            //                                        minus  select STREET_ID from UDI_SECTION where SURVEY_NO=3 group by  STREET_ID ))");
            string sql = string.Format(@"select MAIN_NO,ARNAME,STREET_ID,SURVEY_NO from JPMMS.EQUIPMENTMAINQC where (STREET_ID,SURVEY_NO) in (select  STREET_ID,SURVEY_NO from jpmms.EQUIPMENTMAINQC where IS_DDF=1 minus  select STREET_ID,max(SURVEY_NO)SURVEY_NO  from jpmms.UDI_SECTION where SURVEY_NO>2 group by  STREET_ID,SURVEY_NO )");
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public DataTable CustomMunicpilityUdi()
        {
//            string sql = string.Format(@"select distinct STREET_ID from jpmms.sections where MUNICIPALITY in ('بلدية طيبة') 
//                                            and SECTION_ID in (select distinct SECTION_ID from jpmms.GV_SAMPLES where SAMPLE_LENGTH<>0 and SAMPLE_WIDTH<>0)");
            string sql = @"select distinct STREET_ID from jpmms.sections where MAIN_NO   not in ( select MAIN_NO from JPMMS.EQUIPMENTMAINQC where IS_MAINSTREETS=1 and survey_no=3 )
                                            and  SECTION_ID in (select distinct SECTION_ID from jpmms.GV_SAMPLES where SAMPLE_LENGTH<>0 and SAMPLE_WIDTH<>0)
                                            ";
            DataTable DataTableOne = db.ExecuteQuery(sql);
            return DataTableOne;
        }
        public bool UpdateRrturnToMFV(string MAIN_NO, bool EDITING)
        {
            string sql = string.Format(@"update jpmms.STREETSQC set IS_EQUIPMENT=0 ,IS_TRANSFARE_ERROR=0,IS_DATAENTRYFINSH=1,EDITING=1 where MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public bool UpdateRecivedIRIMFV(string MAIN_NO, bool IS_TRANSFARE, bool IS_Equipment, string SURVEY_NO)
        {
            string sql;
            if (IS_Equipment)
                sql = string.Format(@"insert into JPMMS.STREETSQC 
                                        select MAIN_NO,STREET_ID,ARNAME,0 Finshed,
                                        0 EDITING , 0 UPDATING , 0 DRAWING ,0 IS_REVIEW_DRAWING,0 IS_REVIEW_EDITING,0 IS_DATAENTRYFINSH,
                                        0 IS_DRAWINGFINSH,0 IS_LANEDRAW, 0 IS_SAMPLEDRAW,0 IS_SAMPLEFISHED,0 IS_TRANSFARE_ERROR,
                                        0 STREET_IRI_LEN ,0 STREET_SHAPE_LEN ,0 IS_GPR,0 IS_SKID,0 IS_NOTCOMPLETE ,0 IS_IRI ,0 IS_DDF ,
                                        0 FWD_COUNT ,0 IS_ASSETS ,1 IS_EQUIPMENT ,0 IS_REVIEW_ANALYZ ,0 SECTIONS_SYS , 0 LANES_SYS ,
                                        0 IRI_SECTIONS , 0 IRI_LANES , 0 GPR_SECTIONS , 0 GPR_LANES , 0 SKID_SECTIONS , 0 SKID_LANES , 0 FWD_SECTIONS ,0 FWD_LANES 
                                        from  jpmms.EQUIPMENTMAINQC where  IS_CLOSED=0 and  ROWDATA=1 and main_no='{0}' and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            else sql = string.Format(@"update jpmms.EQUIPMENTMAINQC set IS_TRANSFARE={0} ,TRANSFARE_ERROR=0  where  ROWDATA=1 and IS_CLOSED=0 and MAIN_NO='{1}' and SURVEY_NO={2}", IS_TRANSFARE == true ? 1 : 0, MAIN_NO, SURVEY_NO);

            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public DataTable LenghthStreetsMFV()
        {
            string sql = string.Format(@"select count(distinct main_NO) TOTAL,concat('KM ',round(sum(LEN)/1000,3)) length from JPMMS.IRIAVARAGESECTION");
            return db.ExecuteQuery(sql);
        }
        public DataTable LenghthRowDataMFV()
        {
            string sql = string.Format(@"select  concat(count(main_NO),' ') TOTAL from jpmms.EQUIPMENTMAINQC where  ROWDATA=1 and IS_CLOSED=0
                                         union select concat('KM ',sum(length)) length from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE where  ROWDATA=1");
            return db.ExecuteQuery(sql);
        }
        public DataTable LenghthRowDataTRANSFAREMFV()
        {
            string sql = string.Format(@"select  concat(count(main_NO),' ') TOTAL from jpmms.EQUIPMENTMAINQC where   IS_CLOSED=0 and IS_TRANSFARE=1
                                         union select concat('KM ',sum(length)) length from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE where IS_TRANSFARE=1 ");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAssets(string MAIN_NO)
        {
            string sql = string.Format("select * from VW_ASSETS_TOTAL where MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataSet GetAssetsTotal(string MAIN_NO, string SURVEY_NO)
        {
            DataSet ds = new DataSet();
            string sqlOne = string.Format(@"select   MAIN_NO,TCOUNT,ASSET_TYPE,ASSET_CONDITION,LANE,ST_ARNAME,
                                            (select ROUND (MAX (sdE.sT_length (SHAPE)/1000)*2, 3) from STREETS where  MAIN_NO='{0}' )lane_length,SURVEY_NO  from VW_ASSETS_TOTAL where  MAIN_NO='{0}' and SURVEY_NO='{1}'", MAIN_NO, SURVEY_NO);
            DataTable dt1 = db.ExecuteQuery(sqlOne);
            dt1.TableName = "VW_ASSETS_TOTAL";
            ds.Tables.Add(dt1.Copy());
            string sqlTwo = string.Format(@"select MAIN_NO,TCOUNT
                                            ,CASE WHEN ASSET_TYPE is null THEN 'الكل' else ASSET_TYPE END ASSET_TYPE 
                                            ,CASE WHEN ASSET_CONDITION is null THEN 'الكل' else ASSET_CONDITION END ASSET_CONDITION 
                                            from  VW_ASSETS_SUMTOTAL where MAIN_NO='{0}' and SURVEY_NO='{1}' ", MAIN_NO,SURVEY_NO);
            DataTable dt2 = db.ExecuteQuery(sqlTwo);
            dt2.TableName = "VW_ASSETS_SUMTOTAL";
            ds.Tables.Add(dt2.Copy());
            return ds;
        }
        public DataTable GetSections(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = string.Format("select SECTION_NO,SECTION_ID from JPMMS.SECTIONS", MAIN_NO);
            else
                sql = string.Format("select SECTION_NO,SECTION_ID from JPMMS.SECTIONS where MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetLanes(string MAIN_NO)
        {
            string sql = string.Format("select distinct LANE_TYPE from JPMMS.LANE where MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetInterSections(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = string.Format("select INTER_NO,INTERSECTION_ID from JPMMS.INTERSECTIONS", MAIN_NO);
            else
                sql = string.Format("select INTER_NO,INTERSECTION_ID from JPMMS.INTERSECTIONS where MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public bool RemoveDistressStreets(int Street_id)
        {
            try
            {
                //string sql = string.Format("delete jpmms.IRI where SURVEY_NO=3 and  MAIN_NO = (select MAIN_NO from jpmms.Streets where STREET_ID={0})", Street_id);
                //db.ExecuteNonQuery(sql);

                string sqlone = string.Format("delete JPMMS.DISTRESS d where (DONE_BY=39 or DONE_BY=40) and SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where  STREET_ID=d.STREET_ID ) and  STREET_ID={0}", Street_id);
                int value = db.ExecuteNonQuery(sqlone);
                if (value > 0)
                {
                    string sqlTwo = string.Format("update JPMMS.STREETSQC set finshed=0 where Street_id={0}", Street_id);
                    if (db.ExecuteNonQuery(sqlTwo) > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool RemovePreviousSections(int section_id)
        {
            try
            {
                string sql = string.Format("delete JPMMS.UDI_LANES_PATCHING where section_id={0} and SURVEY_NO<3", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.DISTRESS where section_id={0} and DONE_BY <>39 ", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.SECTION_DETAILS where section_id={0}", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.UDI_SECTION where section_id={0} and SURVEY_NO<3", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.UDI_SECTION_PATCHING where section_id={0} and SURVEY_NO<3", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.UDI_SECTION_SAMPLE_PATCHING where section_id={0} and SURVEY_NO<3", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.MAINTENANCE_DECISIONS where section_id={0} and SURVEY_NO<3", section_id);
                db.ExecuteNonQuery(sql);

                sql = string.Format("delete JPMMS.SECTIONS where section_id={0}", section_id);
                int value = db.ExecuteNonQuery(sql);

                if (value > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool RemovePreviousInterSections(int interSection_id)
        {
            try
            {
                string sql = string.Format("delete JPMMS.DISTRESS where INTERSECTION_ID={0} and SURVEY_NO<3", interSection_id);
                db.ExecuteNonQuery(sql);
                sql = string.Format("delete JPMMS.MAINTENANCE_DECISIONS where INTERSECTION_ID={0} and SURVEY_NO<3", interSection_id);
                db.ExecuteNonQuery(sql);
                sql = string.Format("delete JPMMS.INTERSECTIONS where INTERSECTION_ID={0}", interSection_id);
                int value = db.ExecuteNonQuery(sql);

                if (value > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveIRILength()
        {
            try
            {
                db.ExecuteNonQuery("delete LENGTHIRI");
                db.ExecuteNonQuery("delete LENGHTHSEC");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveRepetedIntersctions()
        {
            try
            {
                db.ExecuteNonQuery(@"
delete  MAGDY.NEW_INTERSECTIONS where (INTER_no,OBJECTID_1)
in (
 select S.INTER_no,S.OBJECTID_1 from
      MAGDY.NEW_INTERSECTIONS S join 
     (
select count(INTER_no)Count,INTER_no from MAGDY.NEW_INTERSECTIONS group by INTER_no having count(INTER_no)>1

)DF on S.INTER_NO = DF.INTER_NO
minus
select distinct S.INTER_no,FIRST_VALUE(OBJECTID_1) 
     OVER (PARTITION BY S.INTER_no ORDER BY S.INTER_no) OBJECTID_1  from 
      MAGDY.NEW_INTERSECTIONS S join 
     (
select count(INTER_no)Count,INTER_no from MAGDY.NEW_INTERSECTIONS group by INTER_no having count(INTER_no)>1

)DF on S.INTER_NO = DF.INTER_NO)
     ");
              
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove_UpdateIRILength()
        {
            try
            {
                db.ExecuteNonQuery("delete IRISECTIONSLENGHT");
                db.ExecuteNonQuery("delete STREETIRILEN");
                int value = db.ExecuteNonQuery("insert into IRISECTIONSLENGHT select  MAIN_NO,SECTION_NO,SECTION_ID,LANE,LEN,AVARAGE,SURVEY_NO  from IRIAVARAGESECTION S where  EXISTS(select main_no from EQUIPMENTMAINQC where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO) ");
                if (value > 0)
                {
                    if (db.ExecuteNonQuery("insert into STREETIRILEN select * from STREET_IRI_LEN ") > 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove_UpdateSHAPELength()
        {
            try
            {
                db.ExecuteNonQuery("delete STREETSHAPELEN");
                int value = db.ExecuteNonQuery(@"insert into jpmms.STREETSHAPELEN
                                select V.MAIN_NO,V.LENGTH,V.SURVEY_NO from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE V
                                join JPMMS.EQUIPMENTMAINQC  S on  S.MAIN_NO=V.MAIN_NO and S.SURVEY_NO=V.SURVEY_NO
                                where  CLEARANCE_IRI is  null ");
                if (value > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool ValidateUpdateInsertIRI()
        {
            db.ExecuteNonQuery("delete IRI_LENGHTH_TEST");
            int value = db.ExecuteNonQuery(@"insert into IRI_LENGHTH_TEST select MAIN_NO,SECTION_NO,SECTION_ID,LANE,LEN,AVARAGE,Width ,SURVEY_NO  from jpmms.IRIAVARAGESECTION");
            if (value > 0)
                return true;
            else
                return false;
        }
        public bool Remove_InsertUpdateIRISections()
        {
            try
            {
                if (Remove_UpdateDDFLength())
                {
                    db.ExecuteNonQuery("delete IRI_LENGHTH_TEST");
                    int value = db.ExecuteNonQuery(@"insert into IRI_LENGHTH_TEST select MAIN_NO,SECTION_NO,SECTION_ID,LANE,LEN,AVARAGE,Width,SURVEY_NO  from IRIAVARAGESECTION ");
                    if (value > 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert_UpdateIRISections()
        {
            try
            {
                string sql = string.Format(@"begin
savepoint my_savepoint;
begin
delete jpmms.SECTIONS_LANES;
insert into  jpmms.SECTIONS_LANES 
select V.MAIN_NO,SECTIONSDRAW SECTIONS_SYS,LANESIRIDRAW LANES_SYS,SECTIONSIRI,LANESIRI,SECTIONS_GPR,LANES_GPR,SECTIONS_SKID,LANES_SKID,V.SURVEY_NO 
from jpmms.VW_SECTIONS_LANES V
left join jpmms.COUNTSECTIONSIRI S on V.MAIN_NO =S.MAIN_NO and V.SURVEY_NO=S.SURVEY_NO
left join jpmms.COUNTLANESIRI I  on I.MAIN_NO =S.MAIN_NO and I.SURVEY_NO=S.SURVEY_NO
left join jpmms.COUNTSECTIONSDRAW D on D.MAIN_NO =S.MAIN_NO and D.SURVEY_NO=S.SURVEY_NO
left join jpmms.COUNTLANEDRW E on E.MAIN_NO =S.MAIN_NO and E.SURVEY_NO=S.SURVEY_NO ;
UPDATE 
(
SELECT  New.SECTIONS_SYS as NEW, old.SECTIONS_SYS as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.LANES_SYS as NEW, old.LANES_SYS as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
  and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SECTIONSIRI as NEW, old.IRI_SECTIONS as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
  and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.LANESIRI as NEW, old.IRI_LANES as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
  and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SECTIONS_GPR as NEW, old.GPR_SECTIONS as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
 --and old.CLEARANCE_GPR is  null
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.LANES_GPR as NEW, old.GPR_LANES as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
 --and old.CLEARANCE_GPR is  null
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SECTIONS_SKID as NEW, old.SKID_SECTIONS as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
 --and old.CLEARANCE_SKID is  null
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.LANES_SKID as NEW, old.SKID_LANES as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.SECTIONS_LANES New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
-- and old.CLEARANCE_SKID is  null
)t
SET  t.OLD=t.NEW;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO my_savepoint;
    RAISE;
END;
 commit;
end;");
                if (db.ExecuteNonQuery(sql) > 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
        public bool Finshed_UpdateIRIValid()
        {
            try
            {
                string sql = string.Format(@"begin
savepoint savepoint_Equipment;
begin
delete jpmms.UpdateIRIValid;
insert into jpmms.UpdateIRIValid
select SE.main_no,SECTION_NO,SE.SECTION_ID OLDSECTION_ID,(select max(SECTION_ID) from jpmms.sections)+rownum NEWSECTION_ID,UV.SURVEY_NO from jpmms.sections SE join (SELECT main_no, SECTION_ID, MAX (survey_no) survey_no
       FROM JPMMS.VE_LATEST_IRI_LENGHTH_SEC
       WHERE SECTION_ID IN (  SELECT SECTION_ID
                                FROM JPMMS.VE_LATEST_IRI_LENGHTH_SEC
                            GROUP BY SECTION_ID
                             HAVING COUNT (*) > 1)
   GROUP BY main_no, SECTION_ID) UV
on SE.SECTION_ID = UV.SECTION_ID;
UPDATE 
(
SELECT  New.NEWSECTION_ID as NEW, old.SECTION_ID as OLD
FROM JPMMS.SECTIONS old 
join JPMMS.UpdateIRIValid New on 
New.OLDSECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.NEWSECTION_ID as NEW, old.SECTION_ID as OLD
FROM JPMMS.Lane old 
join JPMMS.UpdateIRIValid New on 
New.OLDSECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.NEWSECTION_ID as NEW, old.SECTION_ID as OLD
FROM JPMMS.iri old 
join JPMMS.UpdateIRIValid New on 
New.OLDSECTION_ID=old.SECTION_ID
where old.SURVEY_NO>2 and old.SURVEY_NO = New.SURVEY_NO
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.NEWSECTION_ID as NEW, old.SECTION_ID as OLD
FROM JPMMS.distress old 
join JPMMS.UpdateIRIValid New on 
New.OLDSECTION_ID=old.SECTION_ID
where (old.DONE_BY=39 or old.DONE_BY=40) and old.SURVEY_NO>2 and old.SURVEY_NO = New.SURVEY_NO
)t
SET  t.OLD=t.NEW;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO savepoint_Equipment;
    RAISE;
END;
 commit;
end;");
                if (db.ExecuteNonQuery(sql) > 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
        public bool Finshed_UpdateEquipment()
        {
            try
            {
                string sql = string.Format(@"begin
  savepoint savepoint_Equipment;
begin
--delete JPMMS.IRISECTIONSLENGHT;
--insert into jpmms.IRISECTIONSLENGHT select * from jpmms.IRIAVARAGESECTION S where  EXISTS(select main_no from JPMMS.EQUIPMENTMAINQC where MAIN_NO=S.MAIN_NO); 
delete jpmms.EquipmentIRI;
insert into jpmms.EquipmentIRI
select  main_no,SURVEY_NO,SURVEY_TYPE from JPMMS.IRI where SURVEY_NO>2 group by  main_no,SURVEY_NO,SURVEY_TYPE;
UPDATE 
(
SELECT  New.SURVEY_TYPE as NEW, old.TypeOfEquipment as OLD
FROM JPMMS.EQUIPMENTMAINQC old 
join JPMMS.EquipmentIRI New on 
New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
delete jpmms.STREETFWDCOUNT;
insert into jpmms.STREETFWDCOUNT
SELECT MAIN_NO, count(*)/3 TOTAL ,SURVEY_NO FROM JPMMS.FWD_DATA where SURVEY_no>2
group BY MAIN_NO,SURVEY_no order by MAIN_NO;
UPDATE 
(
SELECT  New.TOTAL as NEW, old.FWD_COUNT as OLD
FROM JPMMS.EQUIPMENTMAINQC old 
join JPMMS.STREETFWDCOUNT New on 
New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
delete jpmms.STREETIRIGPR;
insert into jpmms.STREETIRIGPR
select V.MAIN_NO,V.LENGTH,V.SURVEY_NO from jpmms.VW_REPORTSMAINQC_GPRLENIRI V
join JPMMS.EQUIPMENTMAINQC  S on  S.MAIN_NO=V.MAIN_NO AND S.SURVEY_NO=V.SURVEY_NO;
UPDATE 
(
SELECT  New.LENGTH as NEW, old.GPR_IRI_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETIRIGPR New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
delete jpmms.STREETIRISKID;
insert into jpmms.STREETIRISKID 
select V.MAIN_NO,V.LENGTH,V.SURVEY_NO from jpmms.VW_REPORTSMAINQC_SKIDLENIRI V
join JPMMS.EQUIPMENTMAINQC  S on  S.MAIN_NO=V.MAIN_NO and S.SURVEY_NO=V.SURVEY_NO;
UPDATE 
(
SELECT  New.LENGTH as NEW, old.SKID_IRI_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETIRISKID New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
delete jpmms.STREETSHAPELENSKID;
insert into jpmms.STREETSHAPELENSKID
select distinct  V.MAIN_NO,V.LENGTH,V.SURVEY_NO from jpmms.VW_REPORTSMAINQC_SKIDLENSHAPE V
join JPMMS.EQUIPMENTMAINQC  S on  S.MAIN_NO=V.MAIN_NO and S.SURVEY_NO = V.SURVEY_NO;
UPDATE 
(
SELECT  New.LENGTH as NEW, old.SKID_SHAPE_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETSHAPELENSKID New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
delete jpmms.STREETSHAPELENGPR;
insert into jpmms.STREETSHAPELENGPR
select V.MAIN_NO,V.LENGTH ,V.SURVEY_NO from jpmms.VW_REPORTSMAINQC_GPRLENSHAPE V
join JPMMS.EQUIPMENTMAINQC  S on  S.MAIN_NO=V.MAIN_NO and S.SURVEY_NO = V.SURVEY_NO;
UPDATE 
(
SELECT  New.LENGTH as NEW, old.GPR_SHAPE_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETSHAPELENGPR New on 
 New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.ARNAME as NEW_ARNAME , old.ST_ARNAME as OLD_ARNAME
FROM JPMMS.ASSETS_FINAL old 
join JPMMS.EQUIPMENTMAINQC New on 
New.MAIN_NO=old.MAIN_NO
 and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD_ARNAME=t.NEW_ARNAME;
UPDATE 
(
SELECT  New.SURVEY_NO  as NEW_SURVEY_NO , old.SURVEY_NO as OLD_SURVEY_NO
FROM JPMMS.ASSETS_FINAL old 
join JPMMS.EQUIPMENTMAINQC New on 
New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD_SURVEY_NO=t.NEW_SURVEY_NO;
update JPMMS.ASSETS_FINAL set ASSET_CONDITION=lower(ASSET_CONDITION) where main_no is not null and  main_no<>'<Null>';
update JPMMS.ASSETS_FINAL set LANE=lower(LANE) where main_no is not null and  main_no<>'<Null>';
delete jpmms.STREETASSETSLEN;
insert into jpmms.STREETASSETSLEN select MAIN_NO, ROUND(sum(ROUND (sdE.sT_length (SHAPE)/1000 *2, 3)),2) STREET_ASSETS_LEN from jpmms.STREETS  where street_type=1 group by MAIN_NO;
UPDATE 
(
SELECT  old.MAIN_NO, New.STREET_ASSETS_LEN as NEW, old.STREET_ASSETS_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETASSETSLEN New on 
 New.MAIN_NO=old.MAIN_NO --and old.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where main_no = old.main_no)
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.arname as NEW, old.arname as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETS New on 
 New.STREET_ID=old.STREET_ID --and old.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where main_no = old.main_no)
)t
SET  t.OLD=t.NEW;
update jpmms.EQUIPMENTMAINQC set  IS_IRI=0;
update jpmms.EQUIPMENTMAINQC EQ set  IS_IRI=1 where MAIN_NO in (select distinct MAIN_NO from JPMMS.IRI where SURVEY_no=EQ.SURVEY_NO);
update jpmms.EQUIPMENTMAINQC set  IS_DDF=0;
update jpmms.EQUIPMENTMAINQC EQ set  IS_DDF=1 where STREET_ID in (select distinct STREET_ID from JPMMS.DISTRESS where (DONE_BY=39 or DONE_BY=40) and SURVEY_NO=EQ.SURVEY_NO );
update JPMMS.STREETSQC  set  IS_DDF=0;
update JPMMS.STREETSQC  SQ set IS_DDF=1 where STREET_ID in (select distinct STREET_ID from JPMMS.DISTRESS where (DONE_BY=39 or DONE_BY=40) and SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where SQ.MAIN_NO=MAIN_NO) );
update jpmms.EQUIPMENTMAINQC set  IS_FWD=0;
update jpmms.EQUIPMENTMAINQC EQ set  IS_FWD=1 where MAIN_NO in (select distinct MAIN_NO from JPMMS.FWD_DATA where SURVEY_no=EQ.SURVEY_NO);
update jpmms.EQUIPMENTMAINQC set  IS_SKID=0;
update jpmms.EQUIPMENTMAINQC EQ set  IS_SKID=1 where MAIN_NO in (select distinct MAIN_NO from JPMMS.SKID_DATA where SURVEY_no=EQ.SURVEY_NO);
update jpmms.EQUIPMENTMAINQC set  IS_GPR=0;
update jpmms.EQUIPMENTMAINQC EQ set  IS_GPR=1 where MAIN_NO in (select distinct MAIN_NO from JPMMS.GPR where SECTION_NO is not null and SURVEY_no=EQ.SURVEY_NO);
update jpmms.EQUIPMENTMAINQC set  IS_ASSETS=0;
update jpmms.EQUIPMENTMAINQC EQ set  IS_ASSETS=1 where MAIN_NO in (select distinct MAIN_NO from jpmms.ASSETS_final where  MAIN_NO=EQ.MAIN_NO and SURVEY_NO=EQ.SURVEY_NO  and MAIN_NO is not null and  main_no<>'<Null>' and x  is not null and y is not null and SURVEY_MONTH is not null );
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO savepoint_Equipment;
    RAISE;
END;
 commit;
end;");
                if (db.ExecuteNonQuery(sql) > 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
        public bool Remove_UpdateDDFLength()
        {
            try
            {
                db.ExecuteNonQuery("delete LENGTHIRI");
                db.ExecuteNonQuery("delete IRISECTIONSLENGHT");
                int value = db.ExecuteNonQuery("insert into IRISECTIONSLENGHT select  MAIN_NO,SECTION_NO,SECTION_ID,LANE,LEN,AVARAGE,SURVEY_NO  from IRIAVARAGESECTION S where EXISTS (select main_no from EQUIPMENTMAINQC Q where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO)");
                if (value > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable CheckErorrInsertLength()
        {
            string sql = @"select MAIN_NO,STREET_ID,ARNAME from  JPMMS.STREETSQC QC where MAIN_NO in (select main_no from jpmms.STREETSNEWSUERVEY)
                    and MAIN_NO in (SELECT MAIN_NO from jpmms.GV_SAMPLES  where MAIN_NO=QC.MAIN_NO and (SAMPLE_LENGTH=0 or SAMPLE_WIDTH=0)
                    and (SECTION_NO,LANE_TYPE) in (select distinct SECTION_NO,LANE from jpmms.iri where SURVEY_NO>2 and MAIN_NO=QC.MAIN_NO ))";
            return db.ExecuteQuery(sql);
        }
        public DataTable CheckErorrInsertDDF()
        {
            string sql = @"select * from jpmms.CHKDDFDISTRESS
            where SAMPLE_ID is null or DIST_CODE is null or DIST_SEVERITY is null or SURVEY_DATE is null or JPMMS.IsDate(SURVEY_DATE,'dd-mm-yyyy')=0";
            return db.ExecuteQuery(sql);
        }
        public bool GetRecivedInsertDDF()
        {
            string sql = @"select * from jpmms.CHKDDFDISTRESS";
            try
            {
                return db.ExecuteQuery(sql).Rows.Count > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool FinalInsertDDF()
        {
            try
            {
                string sql = string.Format(@"begin
  savepoint savepoint_MFV;
begin
update JPMMS.IRI I set SECTION_ID=(select SECTION_ID from jpmms.sections where I.SECTION_NO=SECTION_NO ) where SECTION_ID is null and (SURVEY_NO, MAIN_NO)
in(select SURVEY_NO, MAIN_NO  FROM jpmms.FINSHEDIRI where MAIN_NO in (select main_no from jpmms.STREETSQC where IS_REVIEW_ANALYZ=1 and IS_REVIEW_EDITING =1 and Finshed=0));
delete IRI_LENGHTH_TEST;
insert into IRI_LENGHTH_TEST select MAIN_NO,SECTION_NO,SECTION_ID,LANE,LEN,AVARAGE,Width,SURVEY_NO  from IRIAVARAGESECTION;
insert into jpmms.distress (SURVEY_DATE,DIST_AREA,DIST_CODE,DIST_SEVERITY,SECTION_NO,DIST_ID,SURVEY_NO,STREET_ID,SECTION_ID,SAMPLE_ID,
DIST_DENSITY,DEDUCT_VALUE,DEN_DASH,DEDUCT_DEN_DASH,DEDUCT_VALUE_UPD,DEDUCT_DEN_DASH_UPD,DEN_DASH_UPD,STATUS,STATUS_UPD,DONE_BY)
SELECT  SURVEY_DATE,
    DIST_AREA,
    DIST_CODE,
    DIST_SEVERITY,
    SECTION_NO,
    JPMMS.SEQ_DISTRESS.nextval DIST_ID,
    SURVEY_NO,
    STREET_ID,
    SECTION_ID,
    (select SAMPLE_ID from JPMMS.VW_MINLANE_SAMPLES where LANE_ID=X.LANE_ID and rownum=1) SAMPLE_ID,
     round(DIST_DENSITY,2),
    DEDUCT_VALUE,
    round(DEDUCT_DEN_DASH,2),
    round((DEDUCT_VALUE * DEDUCT_DEN_DASH) / 100.0,2) DEN_DASH,
    DEDUCT_VALUE DEDUCT_VALUE_UPD,
    round(DEDUCT_DEN_DASH,2) DEDUCT_DEN_DASH_UPD,
    round((DEDUCT_VALUE * DEDUCT_DEN_DASH) / 100.0,2) DEN_DASH_UPD,
     'N' STATUS,
     'N' STATUS_UPD ,
     DONE_BY
     from jpmms.MFVFOUR X;
    update  JPMMS.STREETSQC old set old.FINSHED=1
where exists (select STREET_ID from JPMMS.DISTRESS New where SURVEY_NO>2 and DONE_BY=39 and New.STREET_ID=old.STREET_ID 
and New.SURVEY_NO= (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where STREET_ID=old.STREET_ID)group by STREET_ID);
     UPDATE (SELECT EQ.IS_DDF as OLD FROM JPMMS.EQUIPMENTMAINQC EQ JOIN JPMMS.STREETSQC SQ ON EQ.STREET_ID = SQ.STREET_ID and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where EQ.STREET_ID =STREET_ID )
     where (EQ.STREET_ID,EQ.SURVEY_NO) in (select STREET_ID,max(SURVEY_NO) from JPMMS.DISTRESS where SURVEY_NO>2 and DONE_BY=39 group by STREET_ID)
) t SET t.OLD = 1;     
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO savepoint_MFV;
    RAISE;
END;
 commit;
end;");
                if (db.ExecuteNonQuery(sql) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool InsertLengthDDF(string main_no)
        {
            try
            {
                string sqlOne = string.Format(@"insert into LENGTHIRI
                select LS.SAMPLE_LENGTH as LENGTHOLD , ISC.LEN as LENGTHNEW ,LS.SAMPLE_WIDTH WIDTHOLD,ISC.WIDTH WIDTHNEW,LS.SAMPLE_ID
                from jpmms.IRI_LENGHTH_TEST ISC join jpmms.LANE L on L.SECTION_ID = ISC.SECTION_ID AND
                L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO join jpmms.LANE_SAMPLES LS on
                LS.LANE_ID = L.LANE_ID join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO
                join JPMMS.VE_LATEST_IRI_LENGHTH_TEST ST on ST.MAIN_NO = ISC.MAIN_NO and ST.SECTION_NO = ISC.SECTION_NO and ST.SURVEY_NO = ISC.SURVEY_NO AND ISC.LANE = ST.LANE
                where L.MAIN_NO='{0}' and LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID)", main_no);

                string sqlTwo = string.Format(@"insert into jpmms.LENGHTHSEC
                select L.MAIN_NO,L.SECTION_NO,SEC_LENGTH,SEC_WIDTH,L.SECTION_ID
                FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO
                join JPMMS.VE_LATEST_IRI_LENGHTH_SEC SEC on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO
                where L.MAIN_NO='{0}' ", main_no);

                if (db.ExecuteNonQuery(sqlOne) > 0)
                {
                    if (db.ExecuteNonQuery(sqlTwo) > 0)
                        return true;
                    else
                        return false;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertLengthDDF(string StreetID, string SURVEY_NO)
        {
            try
            {
                string sqlOne = string.Format(@"insert into LENGTHIRI
                select LS.SAMPLE_LENGTH as LENGTHOLD , ISC.LEN as LENGTHNEW ,LS.SAMPLE_WIDTH WIDTHOLD,ISC.WIDTH WIDTHNEW,LS.SAMPLE_ID
                from jpmms.IRI_LENGHTH_TEST ISC join jpmms.LANE L on L.SECTION_ID = ISC.SECTION_ID AND
                L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO join jpmms.LANE_SAMPLES LS on
                LS.LANE_ID = L.LANE_ID join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO
                join JPMMS.VE_IRI_LENGHTH_TEST ST on ST.MAIN_NO = ISC.MAIN_NO and ST.SECTION_NO = ISC.SECTION_NO and ST.SURVEY_NO = ISC.SURVEY_NO AND ISC.LANE = ST.LANE
                where Q.STREET_ID='{0}'and ISC.SURVEY_NO='{1}' and LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID)", StreetID, SURVEY_NO);

                string sqlTwo = string.Format(@"insert into jpmms.LENGHTHSEC
                select L.MAIN_NO,L.SECTION_NO,SEC_LENGTH,SEC_WIDTH,L.SECTION_ID
                FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO
                join JPMMS.VE_LENGHTH_SEC SEC on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO
                where Q.STREET_ID='{0}' and SEC.SURVEY_NO='{1}'", StreetID, SURVEY_NO);

                if (db.ExecuteNonQuery(sqlOne) > 0)
                {
                    if (db.ExecuteNonQuery(sqlTwo) > 0)
                        return true;
                    else
                        return false;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertLengthDDF()
        {
            try
            {
                string sqlOne = string.Format(@"insert into LENGTHIRI
                select LS.SAMPLE_LENGTH as LENGTHOLD , ISC.LEN as LENGTHNEW ,LS.SAMPLE_WIDTH WIDTHOLD,ISC.WIDTH WIDTHNEW,LS.SAMPLE_ID
                from jpmms.IRI_LENGHTH_TEST ISC join jpmms.LANE L on L.SECTION_ID = ISC.SECTION_ID AND
                L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO join jpmms.LANE_SAMPLES LS on
                LS.LANE_ID = L.LANE_ID join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO
                join JPMMS.VE_LATEST_IRI_LENGHTH_TEST ST on ST.MAIN_NO = ISC.MAIN_NO and ST.SECTION_NO = ISC.SECTION_NO and ST.SURVEY_NO = ISC.SURVEY_NO AND ISC.LANE = ST.LANE
                where L.MAIN_NO in (select MAIN_NO from  JPMMS.STREETSQC QC where MAIN_NO in (select main_no from jpmms.STREETSNEWSUERVEY)
                    and MAIN_NO in (SELECT MAIN_NO from jpmms.GV_SAMPLES  where MAIN_NO=QC.MAIN_NO and (SAMPLE_LENGTH=0 or SAMPLE_WIDTH=0))) and LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID)");

                string sqlTwo = string.Format(@"insert into jpmms.LENGHTHSEC
                select L.MAIN_NO,L.SECTION_NO,SEC_LENGTH,SEC_WIDTH,L.SECTION_ID
                FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO
                join JPMMS.VE_LATEST_IRI_LENGHTH_SEC SEC on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO
                where L.MAIN_NO in (select MAIN_NO from  JPMMS.STREETSQC QC where MAIN_NO in (select main_no from jpmms.STREETSNEWSUERVEY)
                    and MAIN_NO in (SELECT MAIN_NO from jpmms.GV_SAMPLES  where MAIN_NO=QC.MAIN_NO and (SAMPLE_LENGTH=0 or SAMPLE_WIDTH=0))) ");

                if (db.ExecuteNonQuery(sqlOne) > 0)
                {
                    if (db.ExecuteNonQuery(sqlTwo) > 0)
                        return true;
                    else
                        return false;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertLengthIRI_FISNSHED()
        {
            try
            {
                string sql = string.Format(@"UPDATE 
(
SELECT  New.MAIN_NO,New.LEN_KM as NEW, old.STREET_IRI_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETIRILEN New on 
 New.MAIN_NO=old.MAIN_NO and 
 New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW");
                if (db.ExecuteNonQuery(sql) > 0)
                {
                    sql = string.Format(@"
UPDATE  JPMMS.STREETSQC old
set old.STREET_IRI_LEN=(select LEN_KM from JPMMS.STREETIRILEN new where New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO= (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO=old.MAIN_NO)  )
where exists (
select MAIN_NO from JPMMS.STREETIRILEN new where New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO= (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO=old.MAIN_NO))");
                    if (db.ExecuteNonQuery(sql) > 0)
                        return true;
                    else
                        return false;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertLengthSHAPE_FISNSHED()
        {
            try
            {
                string sql = string.Format(@"UPDATE 
(
SELECT  New.LENGTH as NEW, old.STREET_SHAPE_LEN as OLD
 FROM JPMMS.EQUIPMENTMAINQC old 
 join JPMMS.STREETSHAPELEN New on 
 New.MAIN_NO=old.MAIN_NO and 
 New.SURVEY_NO=old.SURVEY_NO
)t
SET  t.OLD=t.NEW");
                if (db.ExecuteNonQuery(sql) > 0)
                {
                    sql = string.Format(@"
UPDATE  JPMMS.STREETSQC old
set old.STREET_SHAPE_LEN=(select LENGTH from JPMMS.STREETSHAPELEN new where New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO= (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO=old.MAIN_NO)  )
where exists (
select MAIN_NO from JPMMS.STREETSHAPELEN new where New.MAIN_NO=old.MAIN_NO
and New.SURVEY_NO= (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO=old.MAIN_NO))");
                    if (db.ExecuteNonQuery(sql) > 0)
                        return true;
                    else
                        return false;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertLengthDDF_FISNSHED()
        {
            try
            {
                string sql = string.Format(@"   insert into LENGTHIRI
                                                select LS.SAMPLE_LENGTH as LENGTHOLD , ISC.LEN as LENGTHNEW ,LS.SAMPLE_ID
                                                 from jpmms.IRISECTIONSLENGHT ISC join
                                                jpmms.LANE L
                                                on 
                                                L.SECTION_ID = ISC.SECTION_ID AND
                                                L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO
                                                join jpmms.LANE_SAMPLES LS on
                                                LS.LANE_ID = L.LANE_ID
                                                join JPMMS.STREETSQC Q on 
                                                L.MAIN_NO = Q.MAIN_NO
                                                where IS_REVIEW_EDITING=1  and IS_REVIEW_ANALYZ=1 and FINSHED=0 and 
                                                LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID)");
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable CheckUpdateLengthSAMPLES()
        {
            string sql = string.Format(@"select L.MAIN_NO,L.SECTION_NO,L.SECTION_ID
                                            FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO join JPMMS.VE_LATEST_IRI_LENGHTH_SEC SEC 
                                            on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO
                                            where IS_REVIEW_EDITING=1  and IS_REVIEW_ANALYZ=1 and FINSHED=0 and L.SECTION_ID in (
                                            select L.SECTION_ID FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO join JPMMS.VE_LATEST_IRI_LENGHTH_SEC SEC 
                                            on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO
                                            where IS_REVIEW_EDITING=1  and IS_REVIEW_ANALYZ=1 and FINSHED=0
                                            group by L.SECTION_ID having count(L.SECTION_ID)>1)");
            return db.ExecuteQuery(sql);
        }
        public bool UpdateLengthMAXServey()
        {
            try
            {
                string sql = string.Format(@"begin
  savepoint savepointUpdate;
begin
delete jpmms.LENGHTHSEC;
insert into jpmms.LENGHTHSEC
select distinct L.MAIN_NO,L.SECTION_NO,SEC_LENGTH,SEC_WIDTH,L.SECTION_ID
FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.EQUIPMENTMAINQC Q on L.MAIN_NO = Q.MAIN_NO 
and L.SURVEY_NO = (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where main_no=Q.main_no and IS_IRI=1) join JPMMS.VE_LATEST_IRI_LENGHTH_SEC SEC 
on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO and L.MAIN_NO not in (select main_no from JPMMS.STREETSQC);
UPDATE 
(
SELECT  New.SEC_LENGTH as NEW , old.SEC_LENGTH as OLD
 FROM JPMMS.LENGHTHSEC new 
 join JPMMS.SECTIONS old on 
 New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SEC_WIDTH as NEW , old.SEC_WIDTH as OLD
 FROM JPMMS.LENGHTHSEC new 
 join JPMMS.SECTIONS old on 
 New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
delete jpmms.LENGTHIRI;
insert into jpmms.LENGTHIRI
select distinct LS.SAMPLE_LENGTH as LENGTHOLD , ISC.LEN as LENGTHNEW ,LS.SAMPLE_WIDTH WIDTHOLD,ISC.WIDTH WIDTHNEW,LS.SAMPLE_ID
from jpmms.IRI_LENGHTH_TEST ISC join jpmms.LANE L on L.SECTION_ID = ISC.SECTION_ID AND
L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO join jpmms.LANE_SAMPLES LS on
LS.LANE_ID = L.LANE_ID join JPMMS.EQUIPMENTMAINQC Q on L.MAIN_NO = Q.MAIN_NO 
and ISC.SURVEY_NO = (select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where main_no=Q.main_no and IS_IRI=1) join JPMMS.VE_LATEST_IRI_LENGHTH_TEST ST on 
ST.MAIN_NO = ISC.MAIN_NO and ST.SECTION_NO = ISC.SECTION_NO and ST.SURVEY_NO = ISC.SURVEY_NO AND ISC.LANE = ST.LANE
where L.MAIN_NO not in (select main_no from JPMMS.STREETSQC) and
LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID);
UPDATE 
(
SELECT  New.SAMPLE_LENGTH as NEW, old.LENGTHNEW as OLD
 FROM JPMMS.LENGTHIRI old 
 join JPMMS.LANE_SAMPLES New on 
 New.SAMPLE_ID=old.SAMPLE_ID
)t
SET  t.NEW=t.OLD;
UPDATE 
(
SELECT   New.SAMPLE_WIDTH as NEW, old.WIDTHNEW as OLD
 FROM JPMMS.LENGTHIRI old 
 join JPMMS.LANE_SAMPLES New on 
 New.SAMPLE_ID=old.SAMPLE_ID
)t
SET  t.NEW=t.OLD;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO savepointUpdate;
    RAISE;
END;

 commit;
end;");
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateLengthSAMPLES()
        {
            try
            {
                string sql = string.Format(@"begin
  savepoint savepointUpdate;
begin
delete jpmms.LENGHTHSEC;
insert into jpmms.LENGHTHSEC
select L.MAIN_NO,L.SECTION_NO,SEC_LENGTH,SEC_WIDTH,L.SECTION_ID
FROM JPMMS.IRI_LENGHTH_SEC L join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO join JPMMS.VE_LATEST_IRI_LENGHTH_SEC SEC 
on SEC.MAIN_NO = L.MAIN_NO AND SEC.SECTION_ID = L.SECTION_ID and SEC.SURVEY_NO = L.SURVEY_NO
where IS_REVIEW_EDITING=1  and IS_REVIEW_ANALYZ=1 and FINSHED=0; 
UPDATE 
(
SELECT  New.SEC_LENGTH as NEW , old.SEC_LENGTH as OLD
 FROM JPMMS.LENGHTHSEC new 
 join JPMMS.SECTIONS old on 
 New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SEC_WIDTH as NEW , old.SEC_WIDTH as OLD
 FROM JPMMS.LENGHTHSEC new 
 join JPMMS.SECTIONS old on 
 New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
delete jpmms.LENGTHIRI;
insert into jpmms.LENGTHIRI
select LS.SAMPLE_LENGTH as LENGTHOLD , ISC.LEN as LENGTHNEW ,LS.SAMPLE_WIDTH WIDTHOLD,ISC.WIDTH WIDTHNEW,LS.SAMPLE_ID
from jpmms.IRI_LENGHTH_TEST ISC join jpmms.LANE L on L.SECTION_ID = ISC.SECTION_ID AND
L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO join jpmms.LANE_SAMPLES LS on
LS.LANE_ID = L.LANE_ID join JPMMS.STREETSQC Q on L.MAIN_NO = Q.MAIN_NO join JPMMS.VE_LATEST_IRI_LENGHTH_TEST ST on 
ST.MAIN_NO = ISC.MAIN_NO and ST.SECTION_NO = ISC.SECTION_NO and ST.SURVEY_NO = ISC.SURVEY_NO AND ISC.LANE = ST.LANE
where IS_REVIEW_EDITING=1  and IS_REVIEW_ANALYZ=1 and FINSHED=0 and
LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID);
UPDATE 
(
SELECT  New.SAMPLE_LENGTH as NEW, old.LENGTHNEW as OLD
 FROM JPMMS.LENGTHIRI old 
 join JPMMS.LANE_SAMPLES New on 
 New.SAMPLE_ID=old.SAMPLE_ID
)t
SET  t.NEW=t.OLD;
UPDATE 
(
SELECT   New.SAMPLE_WIDTH as NEW, old.WIDTHNEW as OLD
 FROM JPMMS.LENGTHIRI old 
 join JPMMS.LANE_SAMPLES New on 
 New.SAMPLE_ID=old.SAMPLE_ID
)t
SET  t.NEW=t.OLD;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO savepointUpdate;
    RAISE;
END;

 commit;
end;");
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateLengthSAMPLESOld()
        {
            try
            {
                //                string sql = string.Format(@"UPDATE 
                //(
                //SELECT  New.SAMPLE_LENGTH as NEW, old.LENGTHNEW as OLD
                // FROM JPMMS.LENGTHIRI old 
                // join JPMMS.LANE_SAMPLES New on 
                // New.SAMPLE_ID=old.SAMPLE_ID
                //)t
                //SET  t.NEW=t.OLD");
                //                db.ExecuteNonQuery(sql);

                //                sql = string.Format(@"UPDATE 
                //(
                //SELECT   New.SAMPLE_WIDTH as NEW, old.WIDTHNEW as OLD
                // FROM JPMMS.LENGTHIRI old 
                // join JPMMS.LANE_SAMPLES New on 
                // New.SAMPLE_ID=old.SAMPLE_ID
                //)t
                //SET  t.NEW=t.OLD");
                string sql = string.Format(@"begin
  savepoint savepointSEC;
begin
UPDATE 
(
SELECT  New.SEC_LENGTH as NEW , old.SEC_LENGTH as OLD
 FROM JPMMS.LENGHTHSEC new 
 join JPMMS.SECTIONS old on 
 New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SEC_WIDTH as NEW , old.SEC_WIDTH as OLD
 FROM JPMMS.LENGHTHSEC new 
 join JPMMS.SECTIONS old on 
 New.SECTION_ID=old.SECTION_ID
)t
SET  t.OLD=t.NEW;
UPDATE 
(
SELECT  New.SAMPLE_LENGTH as NEW, old.LENGTHNEW as OLD
 FROM JPMMS.LENGTHIRI old 
 join JPMMS.LANE_SAMPLES New on 
 New.SAMPLE_ID=old.SAMPLE_ID
)t
SET  t.NEW=t.OLD;
UPDATE 
(
SELECT   New.SAMPLE_WIDTH as NEW, old.WIDTHNEW as OLD
 FROM JPMMS.LENGTHIRI old 
 join JPMMS.LANE_SAMPLES New on 
 New.SAMPLE_ID=old.SAMPLE_ID
)t
SET  t.NEW=t.OLD;
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO savepointSEC;
    RAISE;
END;
 commit;
end;");
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetAllStreetsErorrs()
        {
            string sql = "select count(MAIN_NO)COUNT,MAIN_NO from STREETS  group by MAIN_NO having count(MAIN_NO)>1   ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMissingStreetsGPR()
        {
            string sql = "select STREET_ID,MAIN_NO,ARNAME,SURVEY_NO from JPMMS.EQUIPMENTMAINQC where SURVEY_NO=3 and IS_GPR=0 and IS_IRI=1 order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public bool UpdateStreetsMUNICDIST()
        {
            string sql = @"update JPMMS.STREETS S set  DATASOURCE =(select MUNIC_NAME from jpmms.regions where REGION_NO=S.REGION_NO)
                        , LASTUSER=(select DIST_NAME from jpmms.regions where REGION_NO=S.REGION_NO)
                        ,SUBDIST_ID=(select SUBDISTRIC from jpmms.regions where REGION_NO=S.REGION_NO) where STREET_TYPE=0 and REGION_NO is not null
                         and (DATASOURCE is null or LASTUSER is null or SUBDIST_ID is null) ";
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public DataTable GetMissingStreetsSKID()
        {
            string sql = "select STREET_ID,MAIN_NO,ARNAME,SURVEY_NO from JPMMS.EQUIPMENTMAINQC where SURVEY_NO=3 and IS_SKID=0 and IS_IRI=1 order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMissingStreetsASSETS()
        {
            string sql = "select STREET_ID,MAIN_NO,ARNAME,SURVEY_NO from JPMMS.EQUIPMENTMAINQC where SURVEY_NO=3 and IS_ASSETS=0 and IS_IRI=1 order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreets()
        {
            string sql = "select MAIN_NO,STREET_ID from STREETS where street_Type=1 and length(MAIN_NO)>1 order by MAIN_NO ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllSuervey(bool IRI)
        {
            string sql;
            if (IRI)
                sql = @"select QC.STREET_ID,QC.MAIN_NO,ST.ARNAME,1 ROWDATA, IS_MAINSTREETS, IS_CLOSED, 0 DONE_BY 
                        ,0 IS_GPR ,0 IS_SKID,0 IS_FWD ,0 IS_IRI ,0  IS_DDF ,0 IS_ASSETS,  SURVEY_NO+1 SURVEY_NO
                        from JPMMS.STREETS ST join JPMMS.EQUIPMENTMAINQC  QC 
                        ON  QC.MAIN_NO=ST.MAIN_NO and SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO=ST.MAIN_NO  )  where Street_TYPE=1 and IS_IRI=1 order by SURVEY_NO,QC.MAIN_NO";
            else
                sql = @"select QC.STREET_ID,QC.MAIN_NO,ST.ARNAME,1 ROWDATA, IS_MAINSTREETS, IS_CLOSED, 0 DONE_BY 
                        ,0 IS_GPR ,0 IS_SKID,0 IS_FWD ,0 IS_IRI ,0  IS_DDF ,0 IS_ASSETS,  SURVEY_NO+1 SURVEY_NO
                        from JPMMS.STREETS ST join JPMMS.EQUIPMENTMAINQC  QC 
                        ON  QC.MAIN_NO=ST.MAIN_NO and SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO=ST.MAIN_NO  )  where Street_TYPE=1 and IS_IRI=0 order by SURVEY_NO,QC.MAIN_NO";

            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllSuervey()
        {

            string sql = @"select QC.STREET_ID,QC.MAIN_NO,ST.ARNAME,IS_MAINSTREETS, IS_CLOSED, DONE_BY , IS_IRI , case when IS_IRI=1 then SURVEY_NO+1 else SURVEY_NO end SURVEY_NO
                        from JPMMS.STREETS ST join JPMMS.EQUIPMENTMAINQC  QC 
                        ON  QC.MAIN_NO=ST.MAIN_NO   where Street_TYPE=1  order by SURVEY_NO,QC.MAIN_NO";


            return db.ExecuteQuery(sql);
        }
        public DataTable GetNewStreetsGis(bool GIS)
        {
            string sql;
            if (GIS)
                sql = @"select concat(concat(MAIN_NO,'   '),arname) arname,STREET_ID from STREETS where  street_Type=1 and length(MAIN_NO)>1 and STREET_ID in (select STREET_ID from EQUIPMENTMAINQC where DONE_BY=0) ";
            else
                sql = @"select concat(concat(MAIN_NO,'   '),arname) arname,STREET_ID from STREETS where  street_Type=1 and length(MAIN_NO)>1 and STREET_ID not in (select STREET_ID from EQUIPMENTMAINQC where DONE_BY>=0 or DONE_BY is null ) ";

            return db.ExecuteQuery(sql);
        }
        public bool InsertNewStreetsGis(int STREET_ID, bool GIS)
        {
            string sql;
            if (GIS)
                sql = string.Format(@"update EQUIPMENTMAINQC set DONE_BY=1 where STREET_ID={0}", STREET_ID);
            else
                sql = string.Format(@"insert into EQUIPMENTMAINQC (STREET_ID,MAIN_NO,ARNAME,ROWDATA,IS_MAINSTREETS,IS_CLOSED,DONE_BY,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,SURVEY_NO)
                        select STREET_ID,MAIN_NO,ARNAME,1 ROWDATA,0 IS_MAINSTREETS,0 IS_CLOSED, 0 DONE_BY ,0 IS_GPR ,0 IS_SKID,0 IS_FWD ,0 IS_IRI , 0 IS_DDF ,0 IS_ASSETS, 
                        (select  nvl(MAX (SURVEY_NO),2)  FROM EQUIPMENTMAINQC where main_no=x.main_no )+1 SURVEY_NO
                        from STREETS x where street_Type=1 and length(MAIN_NO)>1 and STREET_ID={0}", STREET_ID);
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public bool DeleteNewStreets()
        {
            string sql
           = string.Format(@"delete JPMMS.EQUIPMENTMAINQC where (MAIN_NO,STREET_ID) in (select distinct  MAIN_NO,STREET_ID from JPMMS.EQUIPMENTMAINQC  minus select MAIN_NO,STREET_ID from JPMMS.STREETS where STREET_TYPE=1)
                             and IS_ASSETS=0 and IS_GPR=0 and IS_SKID=0 and IS_FWD=0 and IS_IRI=0 and IS_DDF=0 and IS_INTERSECTIONS is null and 
                             CLEARANCE_DDF is null and CLEARANCE_IRI is null and CLEARANCE_FWD is null and CLEARANCE_ASSETS is null and CLEARANCE_GPR is null 
                             and CLEARANCE_SKID is null and CLEARANCE_INTERSECTIONS is null");
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public bool InsertNewStreetsDID(string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"begin
  savepoint my_savepoint_sec;
begin
delete jpmms.STREETSNEWSUERVEY;
insert into jpmms.STREETSNEWSUERVEY
select F.STREET_ID,F.MAIN_NO,F.ARNAME,1 ROWDATA,0 IS_MAINSTREETS,0 IS_CLOSED,0 IS_GPR ,0 IS_SKID,0 IS_FWD ,0 IS_IRI , 0 IS_DDF ,0 IS_ASSETS,
F.SURVEY_NO+1 SURVEY_NO from JPMMS.FINSHEDIRI F join JPMMS.DistressCount D on D.MAIN_NO=F.MAIN_NO and D.STREET_ID=F.STREET_ID where CLEARANCE_DDF is not null
and SECTIONSDIS=SECTIONSIRI and LANESDIS=LANESIRI;
insert into JPMMS.EQUIPMENTMAINQC (STREET_ID,MAIN_NO,ARNAME,ROWDATA,IS_MAINSTREETS,IS_CLOSED,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,SURVEY_NO,IS_TRANSFARE)
select STREET_ID,MAIN_NO,ARNAME,ROWDATA,IS_MAINSTREETS,IS_CLOSED,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,SURVEY_NO,0 IS_TRANSFARE from jpmms.STREETSNEWSUERVEY;
delete JPMMS.STREETSQC where (STREET_ID,main_no) in (select STREET_ID,MAIN_NO from jpmms.STREETSNEWSUERVEY);
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO my_savepoint_sec;
    RAISE;
END;
 commit;
end;");
            else
                sql = string.Format(@"begin
  savepoint my_savepoint_sec;
begin
delete jpmms.STREETSNEWSUERVEY;
insert into jpmms.STREETSNEWSUERVEY
select F.STREET_ID,F.MAIN_NO,F.ARNAME,1 ROWDATA,0 IS_MAINSTREETS,0 IS_CLOSED,0 IS_GPR ,0 IS_SKID,0 IS_FWD ,0 IS_IRI , 0 IS_DDF ,0 IS_ASSETS,
F.SURVEY_NO+1 SURVEY_NO from JPMMS.FINSHEDIRI F join JPMMS.DistressCount D on D.MAIN_NO=F.MAIN_NO and D.STREET_ID=F.STREET_ID where CLEARANCE_DDF is not null
and SECTIONSDIS=SECTIONSIRI and LANESDIS=LANESIRI and SURVEY_NO={0};
insert into JPMMS.EQUIPMENTMAINQC (STREET_ID,MAIN_NO,ARNAME,ROWDATA,IS_MAINSTREETS,IS_CLOSED,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,SURVEY_NO,IS_TRANSFARE)
select STREET_ID,MAIN_NO,ARNAME,ROWDATA,IS_MAINSTREETS,IS_CLOSED,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,SURVEY_NO,0 IS_TRANSFARE from jpmms.STREETSNEWSUERVEY;
delete JPMMS.STREETSQC where (STREET_ID,main_no) in (select STREET_ID,MAIN_NO from jpmms.STREETSNEWSUERVEY );
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK TO my_savepoint_sec;
    RAISE;
END;
 commit;
end;", SURVEY_NO);
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public DataTable GetStreetsDistress()
        {
            string sql = @"select concat(concat(MAIN_NO,'   '),arname) arname,STREET_ID from JPMMS.STREETS where STREET_ID in (select distinct STREET_ID from JPMMS.DISTRESS where (DONE_BY=39 or DONE_BY=40) and SURVEY_NO>2 )
                            and street_Type=1 and length(MAIN_NO)>1 order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsAssets()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME from jpmms.EQUIPMENTMAINQC
                            where IS_ASSETS=1 and MAIN_NO in (select distinct MAIN_NO from JPMMS.ASSETS_FINAL where survey_no>=3) 
                            group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsIRI()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME from EQUIPMENTMAINQC
                            where IS_IRI=1 and MAIN_NO in (select distinct MAIN_NO from IRI where survey_no>=3) 
                            group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsIRILength()
        {
            string sql = @"select MAIN_NO,STREET_ID  from jpmms.STREETSQC where IS_REVIEW_ANALYZ=1  ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDDF()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME from EQUIPMENTMAINQC
                            where IS_IRI=1 and MAIN_NO in (select distinct STREETNO from DDF where survey_no>=3) 
                            group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsNotIRI()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME from EQUIPMENTMAINQC where 
                           MAIN_NO not in (select distinct MAIN_NO from IRI where survey_no>=3) 
                           group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsGPR()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME from jpmms.EQUIPMENTMAINQC 
                            where IS_GPR=1 and (MAIN_NO,SURVEY_NO) in (select distinct MAIN_NO,SURVEY_NO from jpmms.gpr where survey_no>'2')
                            group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSKID()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME  from jpmms.EQUIPMENTMAINQC 
                            where  IS_SKID=1 and (MAIN_NO,SURVEY_NO) in (select distinct MAIN_NO,SURVEY_NO from jpmms.skid_data where survey_no>2)
                            group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsFWD()
        {
            string sql = @"select MAIN_NO,STREET_ID,max(SURVEY_NO)SURVEY_NO,count(SURVEY_NO)CountSURVEY,ARNAME  from jpmms.EQUIPMENTMAINQC 
                            where IS_FWD=1 and (MAIN_NO,SURVEY_NO) in (select distinct MAIN_NO,SURVEY_NO from jpmms.fwd_data where survey_no>2)
                            group by MAIN_NO,STREET_ID,ARNAME  order by MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfo(int STREET_ID)
        {
            string sql = string.Format(@"   select t.* from (select count( SECTION_NO) OVER(PARTITION BY STREET_ID  ) COUNTSECTION,ARNAME,
                                        (select count(*) from LANE L where exists (select SECTION_ID from SECTIONS  where STREET_ID={0} and SECTION_ID=L.SECTION_ID and main_no=L.main_no ))COUNTLANE
                                         from SECTIONS  where STREET_ID={0} )t where rownum=1
                                        ", STREET_ID);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfo(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select ARNAME,
                                        (select sum(count(distinct SECTION_NO)) from IRI where MAIN_NO='{0}' and SURVEY_NO={1} group by  SECTION_NO) COUNTSECTION,
                                        (select sum(count(distinct lane)) from IRI where MAIN_NO='{0}' and SURVEY_NO={1} group by  SECTION_NO, lane)COUNTLANE 
                                        from STREETS where MAIN_NO in (select MAIN_NO from IRI where MAIN_NO='{0}' and SURVEY_NO={1}) 
                                        ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsValidate(string MAIN_NO)
        {
            string sql = string.Format(@"select concat(ARNAME) ARNAME, from STREETS where MAIN_NO='{0}' ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfoDDF(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select ARNAME,
                                        (select sum(count(distinct SECTION)) from JPMMS.DDF where STREETNO='{0}' and SURVEY_NO>=3  and SURVEY_NO={1} group by  SECTION) COUNTSECTION,
                                        (select sum(count(distinct lane)) from jpmms.DDF where STREETNO='{0}' and SURVEY_NO>=3  and SURVEY_NO={1} group by  SECTION, lane)COUNTLANE 
                                        from jpmms.STREETS where MAIN_NO = '{0}'", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSampleNotFoundIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select L.MAIN_NO,L.SECTION_NO,L.SECTION_ID,L.LANE_ID,LANE
                                            from JPMMS.IRIAVARAGESECTION ISC 
                                            join JPMMS.LANE L on 
                                            L.SECTION_NO = ISC.SECTION_NO AND
                                            L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO
                                            left join JPMMS.LANE_SAMPLES LS on
                                            LS.LANE_ID = L.LANE_ID
                                            where L.MAIN_NO ='{0}' and ISC.SURVEY_NO={1}
                                            and LS.SAMPLE_NO is null 
                                        ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSampleNotFoundIRI()
        {
            //            string sql = string.Format(@"select L.MAIN_NO,L.SECTION_NO,L.SECTION_ID,L.LANE_ID,LANE
            //                                            from JPMMS.IRIAVARAGESECTION ISC 
            //                                            join JPMMS.LANE L on 
            //                                            L.SECTION_ID = ISC.SECTION_ID AND
            //                                            L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO
            //                                            left join JPMMS.LANE_SAMPLES LS on
            //                                            LS.LANE_ID = L.LANE_ID
            //                                            where ISC.SURVEY_NO=3
            //                                            and LS.SAMPLE_NO is null ");
            string sql = @"select  L.MAIN_NO,L.SECTION_NO,L.SECTION_ID,L.LANE_ID,LANE
                                            from JPMMS.IRIAVARAGESECTION ISC 
                                            join jpmms.EQUIPMENTMAINQC EQ on EQ.main_no=ISC.main_no and Eq.SURVEY_NO=ISC.SURVEY_NO
                                            join JPMMS.LANE L on 
                                            L.SECTION_NO = ISC.SECTION_NO AND
                                            L.LANE_TYPE=ISC.LANE  AND L.MAIN_NO = ISC.MAIN_NO
                                            left join JPMMS.LANE_SAMPLES LS on
                                            LS.LANE_ID = L.LANE_ID
                                            where  LS.SAMPLE_NO is null ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDeltedSamples()
        {
            string sql = string.Format(@"select distinct SAMPLE_ID,STREET_ID,(select distinct main_no from JPMMS.EQUIPMENTMAINQC where STREET_ID=D.STREET_ID )main_no,(select distinct arname from JPMMS.EQUIPMENTMAINQC where STREET_ID=D.STREET_ID )arname from JPMMS.DISTRESS D where (DONE_BY=39 or DONE_BY=40) and sample_id not in ( select sample_id from JPMMS.LANE_SAMPLES) order by sample_id");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsUpdateErorrIRI()
        {
            string sql = string.Format(@"select distinct Q.section_id,Q.section_no,Q.Lane,Q.main_no,Q.SURVEY_NO  from iri Q left join sections G on Q.section_id =G.section_id 
                                        and Q.section_no =G.section_no where Q.SURVEY_NO>2 and Q.SURVEY_NO=(select max(SURVEY_NO) from EQUIPMENTMAINQC where main_no=Q.main_no) and G.section_id is null and  Q.section_id is not null order by Q.main_no");
            return db.ExecuteQuery(sql);
        }
        public bool UpdateStreetsUpdateErorrIRI(string section_id, string section_no, string Lane, string main_no, string SURVEY_NO)
        {
            string sql = string.Format(@"update iri set section_id={0} where SURVEY_NO={4} and MAIN_NO='{1}' and section_no='{2}' and Lane='{3}' "
                , section_id, main_no, section_no, Lane, SURVEY_NO);
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public DataTable GetStreetsERorrIRI()
        {
            //            string sql = string.Format(@"select distinct IR.main_no,IR.SECTION_NO,SURVEY_NO from iri IR 
            //                                            full outer join sections SE on SE.SECTION_ID = IR.SECTION_ID and SURVEY_NO>2 
            //                                            where SURVEY_NO>2 and SE.SECTION_ID is null and IR.SECTION_ID is null order by IR.main_no");
            string sql = string.Format(@"select distinct IR.main_no,IR.SECTION_NO,SURVEY_NO from iri IR 
                                              where SURVEY_NO>2 and IR.SECTION_ID is null order by IR.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanes()
        {
            string sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_ID,LANE_TYPE 
                                            from LANE
                                            group by MAIN_NO,SECTION_ID,LANE_TYPE 
                                            having count(*)>1 and SECTION_ID<>0 
                                            order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanes(string MAIN_NO)
        {
            string sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_ID,LANE_TYPE 
                                            from LANE
                                            group by MAIN_NO,SECTION_ID,LANE_TYPE 
                                            having count(*)>1 and SECTION_ID<>0 and MAIN_NO='{0}' 
                                            order by MAIN_NO
                                            ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanesIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_ID,LANE LANE_TYPE
                                            from IRIAVARAGESECTION
                                            group by MAIN_NO,SECTION_ID,LANE,SURVEY_NO 
                                            having count(*)>1 and SECTION_ID<>0 and MAIN_NO='{0}' and SURVEY_NO={1}
                                            order by MAIN_NO
                                            ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanesIRI(string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select count(*)TOTAL,SECTION_NO,LANE LANE_TYPE,SURVEY_NO 
                                            from IRIAVARAGESECTION
                                            group by SECTION_NO,LANE,SURVEY_NO 
                                            having count(*)>1 order by SURVEY_NO");
            else
                sql = string.Format(@"select count(*)TOTAL,SECTION_NO,LANE LANE_TYPE,SURVEY_NO 
                                            from IRIAVARAGESECTION
                                            group by SECTION_NO,LANE,SURVEY_NO 
                                            having count(*)>1 and SURVEY_NO={0} order by SURVEY_NO", SURVEY_NO);

            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanesSKID(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE,SURVEY_NO
                                            from JPMMS.SKID_DATA where SURVEY_NO > 2 
                                            group by MAIN_NO,SECTION_NO,LANE,REMARKS,SURVEY_NO 
                                            having REMARKS=0 and count(*)>1 and SECTION_NO is not null 
                                            order by MAIN_NO ");
            else
                sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE,SURVEY_NO
                                            from JPMMS.SKID_DATA where SURVEY_NO > 2 
                                            group by MAIN_NO,SECTION_NO,LANE,REMARKS,SURVEY_NO 
                                            having REMARKS=0 and count(*)>1 and SECTION_NO is not null and MAIN_NO='{0}'
                                            order by MAIN_NO ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanesSKIDNew(string MAIN_NO)
        {
            string sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE 
                                            from JPMMS.SKID where SURVEY_NO = 4 
                                            group by MAIN_NO,SECTION_NO,LANE 
                                            having count(*)>1 and SECTION_NO is not null and MAIN_NO='{0}' 
                                            order by MAIN_NO
                                            ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsDublicateLanesGPR(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE,SURVEY_NO
                                            from JPMMS.GPR where SURVEY_NO > '2' 
                                            group by MAIN_NO,SECTION_NO,LANE,SURVEY_NO 
                                            having count(*)>1 and SECTION_NO is not null 
                                            order by MAIN_NO");
            else
                sql = string.Format(@"select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE,SURVEY_NO
                                            from JPMMS.GPR where SURVEY_NO > '2' 
                                            group by MAIN_NO,SECTION_NO,LANE,SURVEY_NO 
                                            having count(*)>1 and SECTION_NO is not null and MAIN_NO='{0}'
                                            order by MAIN_NO", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSampleDublicateIRI()
        {
            string sql = string.Format(@"select s.MAIN_NO,s.SECTION_NO,s.LANE_TYPE,s.LANE_ID,D.SAMPLE_NO,ls.SAMPLE_ID,D.count  from  jpmms.LANE_SAMPLES ls join jpmms.SampleTwo s
                                        on 
                                        ls.LANE_ID=s.LANE_ID --and s.SURVEY_NO=(select max(SURVEY_NO) from EQUIPMENTMAINQC where main_no=s.main_no) 
                                        and LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=jpmms.LANE_SAMPLES.LANE_ID)
                                        join JPMMS.SampleNODublicate D on
                                        D.LANE_ID=s.LANE_ID
                                        order by MAIN_NO,LANE_ID,D.SAMPLE_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetTotalMIN()
        {
            string sql = string.Format(@"select count(case when  TotalMainStreets+CLOSEDSTREETS=TOTALSTREETS then 0 else 1 end )TOTALMIN from jpmms.ReceivedMINStreets where TotalMainStreets+CLOSEDSTREETS<>TOTALSTREETS");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSampleDublicateIRI(string MAIN_NO, string SURVEY_NO)
        {
            //            string sql = string.Format(@"select s.MAIN_NO,s.SECTION_NO,s.LANE_TYPE,s.LANE_ID,ls.SAMPLE_NO,ls.SAMPLE_ID,null count from  LANE_SAMPLES ls join SampleTwo s
            //                                        on 
            //                                        ls.LANE_ID=s.LANE_ID
            //                                        and LS.SAMPLE_NO=(select min(SAMPLE_NO) from LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID)
            //                                        where s.MAIN_NO='{0}' 
            //                                        and s.LANE_ID in (
            //                                        select s.LANE_ID from  JPMMS.LANE_SAMPLES ls join jpmms.SampleTwo s
            //                                        on 
            //                                        ls.LANE_ID=s.LANE_ID
            //                                        and LS.SAMPLE_NO=(select min(SAMPLE_NO) from LANE_SAMPLES where LS.LANE_ID=LANE_SAMPLES.LANE_ID)
            //                                        where s.MAIN_NO='{0}' 
            //                                        group by s.LANE_ID
            //                                        having count(s.LANE_ID)>1) order by MAIN_NO,LANE_ID
            //                                        ", MAIN_NO);
            string sql = string.Format(@"select s.MAIN_NO,s.SECTION_NO,s.LANE_TYPE,s.LANE_ID,D.SAMPLE_NO,ls.SAMPLE_ID,D.count  from  jpmms.LANE_SAMPLES ls join jpmms.SampleTwo s
                                        on 
                                        ls.LANE_ID=s.LANE_ID and s.SURVEY_NO={1} 
                                        and LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=jpmms.LANE_SAMPLES.LANE_ID)
                                        join JPMMS.SampleNODublicate D on
                                        D.LANE_ID=s.LANE_ID
                                        where s.MAIN_NO='{0}' 
                                        order by MAIN_NO,LANE_ID,D.SAMPLE_NO", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSampleExceed(string MAIN_NO)
        {
            string sql = string.Format(@"select MAIN_NO,LANE_ID,SAMPLE_ID from JPMMS.LANE_SAMPLES LS where  LS.SAMPLE_NO=(select min(SAMPLE_NO) 
                                            from JPMMS.LANE_SAMPLES where LS.LANE_ID=JPMMS.LANE_SAMPLES.LANE_ID) and MAIN_NO='{0}'
                                            and LANE_ID not in (select LANE_ID from JPMMS.LANE  where MAIN_NO='{0}')", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionsNoUdi()
        {
            string sql = string.Format(@"select * from  jpmms.QcUdi where TOTALSTREETS-TOTALUDISTREETS<>CLOSEDSTREETS");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetIntersetionNoUdi()
        {
            string sql = string.Format(@"select * from  jpmms.QCUDIINTERSECT where TOTALINTERSECT-TOTALUDIINTERSECT<>CLOSEDINTERSECT");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetRegionsNoMin()
        {
            string sql = string.Format(@"select * from  jpmms.QcMIN where TOTALSTREETS-TOTALMAINSTREETS<>CLOSEDSTREETS");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetIntersetionNoMin()
        {
            string sql = string.Format(@"select * from  jpmms.QcMININTERSECT where TOTALUDIINTERSECT<>TOTALINTERSECT");
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateStreetsRegions()
        {
           string sql = string.Format(@"select distinct Q.region_id,Q.region_no   from 
                                    jpmms.STREETS Q left join jpmms.REGIONS G
                                    on 
                                    Q.region_id =G.region_id
                                    and Q.region_no =G.region_no
                                    where G.REGION_ID is null and  Q.REGION_ID is not null");
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateSurveyable(bool? Surveyable = null)
        {
            string sql = null;
            if (Surveyable.HasValue)
                sql = string.Format(@"select REGION_NO,REGION_ID,case when SURVEYABLE=0 then 'غير قابلة للمسح' else 'قابلة للمسح' end SURVEYABLE from jpmms.ValidateSURVEYABLE  where SURVEYABLE='{0}'", Surveyable == true ? 1 : 0);
            else
                sql = string.Format(@"select distinct case when SURVEYABLE=0 then  'غير قابلة للمسح' else 'قابلة للمسح' end SURVEYABLE_TITLE,SURVEYABLE  from jpmms.ValidateSURVEYABLE", Surveyable);
            return db.ExecuteQuery(sql);
        }
        public DataTable CountUDI()
        {
            string sql = string.Format(@"SELECT * FROM
                    (select count(distinct REGION_NO)CountRegionsExcellent from JPMMS.VW_LATEST_UDI_SECONDARY_GIS where  SURVEY_NO>2 and UDI_RATE in ('Excellent','Good')),
                    (select count(distinct REGION_NO)CountRegionsPoor from JPMMS.VW_LATEST_UDI_SECONDARY_GIS where  SURVEY_NO>2 and UDI_RATE in ('Fair','Poor')),
                    (select count(case when  TOTALUDISTREETS+CLOSEDSTREETS=TOTALSTREETS then 0 else 1 end )TOTALUDI from jpmms.ReceivedUDIStreets where TOTALUDISTREETS+CLOSEDSTREETS<>TOTALSTREETS)
--                    ,(select count(case when  TotalMainStreets+CLOSEDSTREETS=TOTALSTREETS then 0 else 1 end )TOTALMIN from jpmms.ReceivedMINStreets where TotalMainStreets+CLOSEDSTREETS<>TOTALSTREETS)");
            return db.ExecuteQuery(sql);
        }
        public DataTable CountOthersEquipment(bool IRIDDF)
        {
            string sql;
            if (IRIDDF)
                sql = string.Format(@"select count(MAIN_NO)CountIRIDDFCLEARANCE  from JPMMS.EQUIPMENTMAINQC where  is_closed=0 and  (IS_IRI=1 and CLEARANCE_IRI is null) or (IS_DDF=1  and CLEARANCE_DDF is null)");
            else
                sql = string.Format(@"SELECT * FROM
                    (select count(MAIN_NO)CountFWDCLEARANCE from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_FWD=1 and CLEARANCE_FWD is null ),
                    (select count(MAIN_NO)CountGPRCLEARANCE  from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_GPR=1 and CLEARANCE_GPR is null ),
                    (select count(MAIN_NO)CountSKIDCLEARANCE  from jpmms.EQUIPMENTMAINQC where  IS_SKID=1 and CLEARANCE_SKID is null ),
                    (select count(MAIN_NO)CountASSETSCLEARANCE  from jpmms.EQUIPMENTMAINQC where  IS_ASSETS=1 and CLEARANCE_ASSETS is null),
                    (SELECT count(distinct QC.SECTION_NO) CountDistreesGPR FROM JPMMS.SECTIONS  LE  RIGHT JOIN JPMMS.GPR QC   ON LE.SECTION_NO = QC.SECTION_NO where survey_no>'2' and LE.SECTION_NO is null and QC.SECTION_NO is not null),
                    (SELECT count(distinct QC.SECTION_NO) CountDistreesFWD FROM JPMMS.SECTIONS  LE  RIGHT JOIN JPMMS.FWD_DATA QC ON LE.SECTION_NO = QC.SECTION_NO where survey_no>2 and LE.SECTION_NO is null),
                    (SELECT count(distinct QC.SECTION_NO) CountDistreesSKID FROM JPMMS.SECTIONS LE  RIGHT JOIN JPMMS.SKID_DATA QC ON LE.SECTION_NO = QC.SECTION_NO where survey_no>2 and LE.SECTION_NO is null),
                    (select count(*)CountValidateGPRLane from (select  main_no,SURVEY_NO from jpmms.EQUIPMENTMAINQC S where exists (select main_no from jpmms.ValidateGPR where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO))),
                    (select count(*)CountValidateFWDLane from (select  main_no,SURVEY_NO from jpmms.EQUIPMENTMAINQC S where exists (select main_no from jpmms.ValidateFWD where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO))),
                    (select count(*)CountValidateSKIDLane from (select  main_no,SURVEY_NO from JPMMS.EQUIPMENTMAINQC S where exists (select main_no from jpmms.ValidateSkid where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO))),
                    (select count(*)CountValidateGPRSections from (select distinct f.main_no, S.SURVEY_NO  from jpmms.GPR f join jpmms.EQUIPMENTMAINQC  S on S.MAIN_NO=f.MAIN_NO  where f.SURVEY_NO=S.SURVEY_NO and f.SECTION_NO is not null and not exists (select SECTION_NO from jpmms.GPR_LANE where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO))),
                    (select count(*)CountValidateFWDSections from (select distinct f.main_no,S.SURVEY_NO from jpmms.fwd_data f join jpmms.EQUIPMENTMAINQC  S on S.MAIN_NO=f.MAIN_NO where   f.SURVEY_NO=S.SURVEY_NO and not exists (select SECTION_NO from jpmms.FWD_SECTION_DETIALS where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO))),
                    (select count(*)CountValidateSKIDSections from (select distinct f.main_no,S.SURVEY_NO  from jpmms.skid_data f join jpmms.EQUIPMENTMAINQC  S on S.MAIN_NO=f.MAIN_NO where f.SURVEY_NO=S.SURVEY_NO and not exists (select SECTION_NO from jpmms.SKID_JEDDAH where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO))),
                    (select count(distinct t.MAIN_NO)CountValidateGPR from (select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where section_no is not null minus select distinct section_no,MAIN_NO from jpmms.gpr where section_no is not null  and SURVEY_NO>'2')t where t.MAIN_NO in (select MAIN_NO from jpmms.EQUIPMENTMAINQC where is_gpr=1)),
                    (select count(distinct t.MAIN_NO)CountValidateFWD from (select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where section_no is not null minus select distinct section_no,MAIN_NO from jpmms.fwd_data where section_no is not null  and SURVEY_NO>2)t where t.MAIN_NO in (select MAIN_NO from jpmms.EQUIPMENTMAINQC where is_fwd=1)),
                    (select count(distinct t.MAIN_NO)CountValidateSKID from (select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where section_no is not null minus select distinct section_no,MAIN_NO from jpmms.skid_data where section_no is not null  and SURVEY_NO>2)t where t.MAIN_NO in (select MAIN_NO from jpmms.EQUIPMENTMAINQC where is_skid=1)),
                    (select count(distinct t.MAIN_NO)CountDublicateGPR from (select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE,SURVEY_NO from JPMMS.GPR where SURVEY_NO > '2' group by MAIN_NO,SECTION_NO,LANE,SURVEY_NO having count(*)>1 and SECTION_NO is not null)t),
                    (select count(distinct t.MAIN_NO)CountDublicateSKID from (select count(*)TOTAL,MAIN_NO,SECTION_NO,LANE LANE_TYPE,SURVEY_NO from JPMMS.SKID_DATA where SURVEY_NO > 2 group by MAIN_NO,SECTION_NO,LANE,REMARKS,SURVEY_NO having REMARKS=0 and count(*)>1 and SECTION_NO is not null)t),
                    (select count(S.MAIN_NO)FinshedReadyFWD from STREETS S join ReadyFWD R on R.MAIN_NO=S.MAIN_NO where street_Type=1 and R.FWD is not null and R.FWD=1),
                    (select count(MAIN_NO)LanesDeletedSKID from (select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.SKID_DATA where SURVEY_NO>2  and REMARKS=0 minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSSKID )),
                    (select count(MAIN_NO)LanesDeletedGPR from (select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.GPR where SURVEY_NO>'2' and section_no is not null minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSGPR )),
                    (select count(MAIN_NO)CountSectionMainNOSKID from (select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.SKID_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO union all select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.SKID_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO)),
                    (select count(MAIN_NO)CountSectionMainNOGPR from (select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.GPR where SURVEY_NO>'2' and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO union all select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.GPR where SURVEY_NO>'2' and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO)),
                    (select count(MAIN_NO)CountSectionMainNOFWD from (select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.FWD_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO union all select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.FWD_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO)),
                    (select Count(MAIN_NO)CountMFVGPR from JPMMS.EQUIPMENTMAINQC where SURVEY_NO=3 and IS_GPR=0 and IS_IRI=1 order by MAIN_NO),
                    (select Count(MAIN_NO)CountMFVSKID from JPMMS.EQUIPMENTMAINQC where SURVEY_NO=3 and IS_SKID=0 and IS_IRI=1 order by MAIN_NO),
                    (select Count(MAIN_NO)CountMFVASSETS from JPMMS.EQUIPMENTMAINQC where SURVEY_NO=3 and IS_ASSETS=0 and IS_IRI=1 order by MAIN_NO),
                    (select Count(MAIN_NO)CountCompareASSETS from JPMMS.CHECKASSETS where CLEARANCE_ASSETS<>SURVEY_MONTH order by MAIN_NO)");
            return db.ExecuteQuery(sql);
        }
        public DataTable CountRegionsUdiMin()
        {
            string sql = string.Format(@"SELECT * FROM
                    (select count(REGION_NO)TOTALRegionsOpend from jpmms.ValidateSURVEYABLE where SURVEYABLE=1 ),
                    (select count(REGION_NO)TOTALRegionsClosed from jpmms.ValidateSURVEYABLE where SURVEYABLE=0 ),
                    (select count(SECOND_ST_NO)CountStreetWidth from jpmms.STREETS join jpmms.REGIONS on STREETS.REGION_ID = REGIONS.REGION_ID where SECOND_ST_WIDTH>100 and STREET_TYPE=0 and STREETS.region_id in (select distinct region_id from jpmms.DISTRESS where SURVEY_NO>2)),
                    (select count(SECOND_ST_NO)CountStreetLength from jpmms.STREETS join jpmms.REGIONS on STREETS.REGION_ID = REGIONS.REGION_ID where SECOND_ST_LENGTH>1000 and STREET_TYPE=0 and STREETS.region_id in (select distinct region_id from jpmms.DISTRESS where SURVEY_NO>2)),
                    (select count(REGION_NO)CountRegionsClosedNote from JPMMS.REGIONS  where NOTES is null and SURVEYABLE=0),
                    (select count(REGION_NO)CountRegionsOpenedNote from JPMMS.REGIONS  where NOTES is not null and SURVEYABLE=1),
                    (select count(SECOND_ST_NO)CountSECOND_ST from jpmms.STREETS where length(SECOND_ST_NO)>2 and REGION_ID in (select REGION_ID from jpmms.REPORTSQC )),
                    (select count(REGION_NO)CountRegionsNotFinshed from jpmms.RECEIVEDFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO join  jpmms.REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 ),
                    (select count(REGION_NO)CountRegionFinshed  from jpmms.RECEIVEDFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO  join  jpmms.REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=1),
                    (select count(REGION_NO)CountRegionsReports from jpmms.RECEIVEDFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDFILES.RECEIVEDUSERNO  join  jpmms.REPORTSQC rq on rq.REGION_ID= RECEIVEDFILES.ID where IS_REVIEWDATAENTRY=1),
                    (select count(REGION_NO)CountAREA from jpmms.REPORTSQC d join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where  SURVEYOR_AREA <>(select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2)  from jpmms.STREETS s where s.region_id=d.region_id)),
                    (select count(*)CountReports from jpmms.VW_ReportQC where IS_REVIEWREPORT='False'),                 
                    (select count(REGION_NO)CountRegionsNoUdi from  jpmms.QcUdi where TOTALSTREETS-TOTALUDISTREETS<>CLOSEDSTREETS),
                    (SELECT count(street_id)CountNewStreets FROM JPMMS.STREETS WHERE street_id NOT IN (SELECT street_id FROM jpmms.SECONDARY_STREET_DETAILS) and REGION_ID is not null and ARNAME is   null and STREET_TYPE=0),
                    (SELECT count(*)CountNewStreetsQC from (select d.region_no from jpmms.SURVEYORS_REGIONs_distinct d join jpmms.REPORTSQC Q on d.region_id=Q.region_id and d.SURVEY_NO = Q.SURVEY_NO where d.SURVEY_NO>2  group by d.region_no, MUNIC_NAME, subdistrict, d.survey_no, d.region_id having  (select round(sum(SECOND_ST_LENGTH*SECOND_ST_width), 2) from jpmms.STREETS s where s.region_id=d.region_id) <> SUM (REGION_AREA))),
                    (select count(t.region_id)GetDublicateStreets from (select distinct Q.region_id,Q.region_no from jpmms.STREETS Q left join jpmms.REGIONS G on Q.region_id =G.region_id and Q.region_no =G.region_no where G.REGION_ID is null and  Q.REGION_ID is not null)t)
                --,(select count(REGION_NO)CountRegionsNoMin from  jpmms.QcMIN where TOTALSTREETS-TOTALMAINSTREETS<>CLOSEDSTREETS)");
            return db.ExecuteQuery(sql);
        }
        public DataTable CounIntersectionsUdiMin()
        {
            //            string sql = string.Format(@"SELECT * FROM
            //                      (select count(*)TOTALIntersectionsEditReady from(select STREET_ID,SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=INS.STREET_ID) TOTALINTERSECTIONS ,
            //                      count(INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from jpmms.INTERSECT_STATISTICS INS where SURVEY_NO is not null   group by STREET_ID,SURVEY_NO) where  TOTALINTERSECTIONS-DISTRESSINTERSECTIONS>0 ),
            //                      (select count(*)TOTALIntersectionsReady from(select STREET_ID,SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=INS.STREET_ID) TOTALINTERSECTIONS ,
            //                      count(INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from jpmms.INTERSECT_STATISTICS INS where SURVEY_NO is not null   group by STREET_ID,SURVEY_NO) where  TOTALINTERSECTIONS-DISTRESSINTERSECTIONS=0 ),
            //                    (select count(INTER_NO)CountInterSectionsNotFinshed from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO join  jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 ),
            //                    (select count(INTER_NO)CountInterSectionsFinshed  from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO  join  jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=1),
            //                    (select count(INTER_NO)CountInterSectionsReports from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO  join  jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWDATAENTRY=1)");

            string sql = string.Format(@"SELECT * FROM
                    (select count(ES.STREET_ID)TOTALIntersectionsEditReady
                      from(select EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=EQ.STREET_ID) TOTALINTERSECTIONS ,
                      count(EQ.INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from JPMMS.INTERSECT_STATISTICS EQ
                      LEFT JOIN JPMMS.INTERSECTQC IQ ON IQ.INTER_NO = EQ.INTER_NO where  EQ.SURVEY_NO is not null and  
                      EQ.STREET_ID in (select STREET_ID from JPMMS.INTERSECTQC where IS_READY=0 )   group by EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO)ES
                      join jpmms.EQUIPMENTMAINQC RQ ON RQ.SURVEY_NO=ES.SURVEY_NO and RQ.STREET_ID=ES.STREET_ID where IS_INTERSECTIONS is null and TOTALINTERSECTIONS-DISTRESSINTERSECTIONS>0),
                    (select count(ES.STREET_ID)TOTALIntersectionsReady
                      from(select EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO,(select count(INTER_NO) from JPMMS.INTERSECTIONS where  STREET_ID=EQ.STREET_ID) TOTALINTERSECTIONS ,
                      count(EQ.INTER_NO)DISTRESSINTERSECTIONS,sum(INTER_LENGTH) TOTALLENGTH from JPMMS.INTERSECT_STATISTICS EQ
                      LEFT JOIN JPMMS.INTERSECTQC IQ ON IQ.INTER_NO = EQ.INTER_NO where  EQ.SURVEY_NO is not null and  
                      EQ.STREET_ID in (select STREET_ID from JPMMS.INTERSECTQC where IS_READY=0 )   group by EQ.STREET_ID,EQ.MAIN_NO,EQ.SURVEY_NO)ES
                      join jpmms.EQUIPMENTMAINQC RQ ON RQ.SURVEY_NO=ES.SURVEY_NO and RQ.STREET_ID=ES.STREET_ID where IS_INTERSECTIONS is null and TOTALINTERSECTIONS-DISTRESSINTERSECTIONS=0),
                    (select count(INTER_NO)CountInterSectionsNotFinshed from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO join  jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=0 ),
                    (select count(INTER_NO)CountInterSectionsFinshed  from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO  join  jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_DATAENTRYFINSH=1),
                    (select count(INTER_NO)CountInterSectionsReports from jpmms.RECEIVEDINTERSECTFILES join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO  join  jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWDATAENTRY=1),
                    (select count(*)CountInterSectionsClearance from jpmms.EQUIPMENTMAINQC where IS_INTERSECTIONS =1 and CLEARANCE_INTERSECTIONS is null),
                    (select count(*)CountInterSectionsMissing from jpmms.INTERSECTIONS where STREET_ID in (select distinct STREET_ID from jpmms.INTERSECTQC) and INTER_NO  not in (select INTER_NO from jpmms.INTERSECTQC)),
                    (select count(INTER_NO)CountAREA from jpmms.INTERSECTQC d join jpmms.REPORTMONTH on REPORTMONTH_ID=REPORTSMONTH where  SURVEYOR_AREA <>(select round(sum(INTERSEC_SAMP_AREA), 2)  from jpmms.INTERSECTION_SAMPLES s where s.INTERSECTION_ID=d.INTERSECTION_ID)),
                    (select count(INTER_NO)CountGis from jpmms.RECEIVEDINTERSECTFILES  join jpmms.SYSTEM_USERS  sy on sy.USER_ID =RECEIVEDINTERSECTFILES.RECEIVEDUSERNO join jpmms.INTERSECTQC rq on rq.INTERSECTION_ID= RECEIVEDINTERSECTFILES.ID where IS_REVIEWREPORT=0 and IS_REVIEWGIS=1),
                    (select count(INTER_NO)CountExceedArea from(select d.INTER_NO from jpmms.GV_INTERSECTION_DISTRESS d join jpmms.INTERSECTIONS_AREA s on s.INTER_NO=d.INTER_NO where INTERSECTION_AREA>(INTERSECTION_COUNT*1500)  and d.SURVEY_NO>2 group by d.INTER_NO,INTERSECTION_COUNT, MAIN_NAME, INTEREC_STREET1,INTEREC_STREET2, d.survey_no ,INTERSECTION_AREA)),
                    (select count(*)CountQcUDI from jpmms.QCUDIINTERSECT where TOTALINTERSECT-TOTALUDIINTERSECT<>CLOSEDINTERSECT)");
            return db.ExecuteQuery(sql);
        }
        public DataTable CounMissClearance()
        {
            string sql = string.Format(@"SELECT * FROM
                    (select count(MAIN_NO)CountIRIDDFCLEARANCE from JPMMS.EQUIPMENTMAINQC where  is_closed=0 and  IS_IRI=1 and IS_DDF=1 and CLEARANCE_IRI is null  and CLEARANCE_DDF is null),
                    (select count(*)CountInterSectionsClearance from jpmms.EQUIPMENTMAINQC where IS_INTERSECTIONS =1 and CLEARANCE_INTERSECTIONS is null),
                    (select count(MAIN_NO)CountFWDCLEARANCE from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_FWD=1 and CLEARANCE_FWD is null ),
                    (select count(MAIN_NO)CountGPRCLEARANCE  from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_GPR=1 and CLEARANCE_GPR is null ),
                    (select count(MAIN_NO)CountSKIDCLEARANCE  from jpmms.EQUIPMENTMAINQC where  IS_SKID=1 and CLEARANCE_SKID is null ),
                    (select count(MAIN_NO)CountASSETSCLEARANCE  from jpmms.EQUIPMENTMAINQC where  IS_ASSETS=1 and CLEARANCE_ASSETS is null)");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetInterSectionsClearance()
        {
            string sql = string.Format(@"select STREET_ID,MAIN_NO,ARNAME,(select  distinct DECODE( IS_READY, 0, 'False', 'True') from jpmms.INTERSECTQC where STREET_ID=EQ.STREET_ID ) IS_READY  from jpmms.EQUIPMENTMAINQC EQ where IS_INTERSECTIONS =1 and CLEARANCE_INTERSECTIONS is null order by STREET_ID ");
            return db.ExecuteQuery(sql);
        }
        public bool UpdateInterSectionsClearance(string STREET_ID, bool IS_READY)
        {
            string sql = string.Format(@"update INTERSECTQC set IS_READY={1} where STREET_ID={0}", STREET_ID, (IS_READY == true) ? 1 : 0);
            return db.ExecuteNonQuery(sql) > 0 ? true : false;
        }
        public DataTable GetInterSectionsMissing()
        {
            string sql = string.Format(@"select STREET_ID,MAIN_NO,ARNAME,INTER_NO,INTERSECTION_ID,INTEREC_STREET1,INTEREC_STREET2 from jpmms.INTERSECTIONS where STREET_ID in(select distinct STREET_ID from jpmms.INTERSECTQC) and INTER_NO  not in (select INTER_NO from jpmms.INTERSECTQC) order by STREET_ID ");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetInterSectionsComplete()
        {
            string sql = string.Format(@"select STREET_ID,MAIN_NO,ARNAME,INTER_NO,INTERSECTION_ID,INTEREC_STREET1,INTEREC_STREET2 from jpmms.INTERSECTIONS S
                                where STREET_ID not in (select distinct STREET_ID from jpmms.INTERSECTIONS where STREET_ID in(select distinct STREET_ID from jpmms.INTERSECTQC)
                                and INTER_NO  not in (select INTER_NO from jpmms.INTERSECTQC))  order by STREET_ID");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetInterSectionsComplete(string main_no)
        {
            string sql = string.Format(@"select * from (
                                       select STREET_ID,MAIN_NO,ARNAME,INTER_NO,INTERSECTION_ID,INTEREC_STREET1,INTEREC_STREET2 from jpmms.INTERSECTIONS S
                                       where STREET_ID not in (select distinct STREET_ID from jpmms.INTERSECTIONS where STREET_ID in(select distinct STREET_ID from jpmms.INTERSECTQC)
                                       and INTER_NO  not in (select INTER_NO from jpmms.INTERSECTQC))) where MAIN_NO='{0}'", main_no);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetInterSectionsMissing(string main_no)
        {
            string sql = string.Format(@"select * from (
                                        select STREET_ID,MAIN_NO,ARNAME,INTER_NO,INTERSECTION_ID,INTEREC_STREET1,INTEREC_STREET2 
                                        from jpmms.INTERSECTIONS where STREET_ID in(select distinct STREET_ID from jpmms.INTERSECTQC) and INTER_NO  not in (select INTER_NO from jpmms.INTERSECTQC) 
                                        )where MAIN_NO='{0}'", main_no);
            return db.ExecuteQuery(sql);
        }
        public object CountRegionsNoMin()
        {
            string sql = string.Format(@"select count(REGION_NO)CountRegionsNoMin from  jpmms.QcMIN where TOTALSTREETS-TOTALMAINSTREETS<>CLOSEDSTREETS");
            return db.ExecuteScalar(sql);
        }
        public DataTable RegionsNotes(bool Surveyable)
        {
            string sql = null;
            if (Surveyable)
                sql = string.Format(@"select REGION_NO,NOTES,case when SURVEYABLE=0 then  'غير قابلة للمسح' else 'قابلة للمسح' end SURVEYABLE_TITLE from JPMMS.REGIONS  where NOTES is null and SURVEYABLE=0");
            else
                sql = string.Format(@"select REGION_NO,NOTES,case when SURVEYABLE=0 then  'غير قابلة للمسح' else 'قابلة للمسح' end SURVEYABLE_TITLE from JPMMS.REGIONS  where NOTES is not null and SURVEYABLE=1");
            return db.ExecuteQuery(sql);
        }

        public DataTable GetCountRegions(bool UDI)
        {
            string sql = null;
            if (UDI)
                sql = string.Format(@"select REGION_NO||'_'||'الشوارع_'||count(*)||'_مسح_'||SURVEY_NO REGION_NO,REGION_ID from JPMMS.VW_LATEST_UDI_SECONDARY_GIS where  SURVEY_NO>2 and UDI_RATE in ('Excellent','Good')group by REGION_NO,SURVEY_NO,REGION_ID order by REGION_NO,SURVEY_NO");
            else
                sql = string.Format(@"select REGION_NO||'_'||'الشوارع_'||count(*)||'_مسح_'||SURVEY_NO REGION_NO,REGION_ID from JPMMS.VW_LATEST_UDI_SECONDARY_GIS where  SURVEY_NO>2 and UDI_RATE in ('Fair','Poor')group by REGION_NO,SURVEY_NO,REGION_ID order by REGION_NO,SURVEY_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetCountRegions(bool UDI, string Region_Id)
        {
            string sql = null;
            if (UDI)
                sql = string.Format(@"select REGION_NO,SUBDISTRICT,SURVEY_NO,STREET_ID,SECOND_ST_NO,SECOND_ARNAME,UDI_RATE from JPMMS.VW_LATEST_UDI_SECONDARY_GIS where REGION_ID={0} and SURVEY_NO>2 and UDI_RATE in ('Excellent','Good') order by SECOND_ST_NO,SURVEY_NO", Region_Id);
            else
                sql = string.Format(@"select REGION_NO,SUBDISTRICT,SURVEY_NO,STREET_ID,SECOND_ST_NO,SECOND_ARNAME,UDI_RATE from JPMMS.VW_LATEST_UDI_SECONDARY_GIS where REGION_ID={0} and SURVEY_NO>2 and UDI_RATE in ('Fair','Poor') order by SECOND_ST_NO,SURVEY_NO", Region_Id);
            return db.ExecuteQuery(sql);
        }
        public DataTable CountMFV()
        {
            string sql = string.Format(@"SELECT * FROM
                    (select count(STREET_ID) GetNewStreetsGisOK from jpmms.STREETS where  street_Type=1 and length(MAIN_NO)>1 and STREET_ID in (select STREET_ID from jpmms.EQUIPMENTMAINQC where DONE_BY=0)),
                    (select count(STREET_ID) GetNewStreetsGis from jpmms.STREETS where  street_Type=1 and length(MAIN_NO)>1 and STREET_ID not in (select STREET_ID from jpmms.EQUIPMENTMAINQC where DONE_BY>=0 or DONE_BY is null )) ,
                    (select count(*) GetFinshedSTREETSMFVCount from  JPMMS.EQUIPMENTMAINQC V join jpmms.VW_EQUIPQC_LATEST_SURVEYS EQ on  EQ.MAIN_NO=V.MAIN_NO and V.SURVEY_NO=EQ.SURVEY_NO where ROWDATA=1 and  IS_TRANSFARE =1),
                    (select count(*) GetRecivedEditingIRI from JPMMS.STREETSQC SQ join JPMMS.EQUIPMENTMAINQC EQ on EQ.STREET_ID = SQ.STREET_ID and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where SQ.STREET_ID=STREET_ID ) where SQ.IS_DATAENTRYFINSH=1 and (SQ.UPDATING=1 or SQ.IS_REVIEW_DRAWING=0)),
                    (select count(*) GetRecivedEditIRI from JPMMS.STREETSQC  Q join JPMMS.EQUIPMENTMAINQC  EQ on EQ.MAIN_NO = Q.MAIN_NO  where Q.EDITING=1 and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO )),
                    (select count(*) GetIsNotComplete from JPMMS.STREETSQC  Q join JPMMS.EQUIPMENTMAINQC  EQ on EQ.MAIN_NO = Q.MAIN_NO  where Q.IS_NOTCOMPLETE=1 and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO )),
                    (select count(*) GetRecivedFinshedIRI from jpmms.FINSHEDIRI  where  FINSHED='False' ),
                    (select count(*) GetRecivedDrawingIRI from JPMMS.STREETSQC SQ join JPMMS.EQUIPMENTMAINQC EQ on EQ.STREET_ID = SQ.STREET_ID and EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC where SQ.STREET_ID=STREET_ID )where SQ.DRAWING=1),
                    (select count(*) GetRecivedCompleteDrawingIRI from JPMMS.STREETSQC Q join JPMMS.EQUIPMENTMAINQC  EQ on EQ.MAIN_NO = Q.MAIN_NO where EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO ) and  Q.IS_DATAENTRYFINSH=1 and Q.IS_DRAWINGFINSH=1),
                    (select count(distinct MAIN_NO)GetRecivedFinshedIRIANALYZE from JPMMS.STREETSQC Q LEFT join JPMMS.DISTRESS D on D.STREET_ID=Q.STREET_ID AND (DONE_BY=39 or DONE_BY=40) and SURVEY_NO>=3 WHERE IS_REVIEW_EDITING=1 and FINSHED=0 and IS_REVIEW_ANALYZ=0),
                    (Select count(*)FinshedRrturnToMFV from jpmms.STREETSQC where IS_EQUIPMENT=1 ),
                    (Select count(distinct Q.MAIN_NO) FinshedRrturnToMFVDelete from jpmms.STREETSQC Q join jpmms.iri I on I.main_no=Q.main_no where SURVEY_NO=(select max(SURVEY_NO) from jpmms.EQUIPMENTMAINQC where main_no=I.main_no) and IS_EQUIPMENT=1 ),
                    (select count(Q.MAIN_NO) GetRecivedMFV from jpmms.VW_IRI_MAIN_LATEST_SURVEYS EQ right join jpmms.EQUIPMENTMAINQC Q on Q.MAIN_NO = EQ.MAIN_NO left join jpmms.STREETSQC SE  on Q.MAIN_NO = SE.MAIN_NO where  EQ.MAIN_NO is null  and SE.IS_Equipment is null and  Q.ROWDATA=1 and IS_CLOSED=0 and Q.SURVEY_NO=3 and (Q.DONE_BY=1 or Q.DONE_BY is null)),
                    (select count(*) GetStreetsERorrIRI from (select distinct main_no,SECTION_NO,SURVEY_NO from jpmms.iri where SURVEY_NO>2 and SECTION_ID is null)),                    
                    (select count(Q.MAIN_NO) GetRecivedMFVNext from jpmms.VW_REPORTSMAINQC_LENGTHSHAPE V  join jpmms.VW_EQUIPQC_LATEST_SURVEYS EQ on  EQ.MAIN_NO=V.MAIN_NO and EQ.SURVEY_NO=V.SURVEY_NO join jpmms.EQUIPMENTMAINQC Q on Q.MAIN_NO = V.MAIN_NO and Q.SURVEY_NO=EQ.SURVEY_NO left join jpmms.STREETSQC SE  on Q.MAIN_NO = SE.MAIN_NO where  Q.ROWDATA=1 and IS_CLOSED=0  and SE.IS_Equipment is null and Q.SURVEY_NO> (select min(SURVEY_NO) from jpmms.EQUIPMENTMAINQC where MAIN_NO=EQ.MAIN_NO) and (Q.DONE_BY=1 or Q.DONE_BY is null)),
                    (select count(Main_no) GetStreetsDublicateLanes from (select MAIN_NO,SECTION_ID,LANE_TYPE from jpmms.LANE group by MAIN_NO,SECTION_ID,LANE_TYPE having count(*)>1 and SECTION_ID<>0)),
                    (select count(s.main_no) GetErorrSectionLane from jpmms.lane s left join jpmms.sections r on r.section_ID=s.section_ID and r.section_no=s.section_no where (r.section_no is null or r.section_ID is null)),
                    (select count(*)GetStreetsUpdateErorrIRI from (select distinct Q.section_id,Q.section_no,Q.Lane from jpmms.iri Q left join jpmms.sections G on Q.section_id =G.section_id and Q.section_no =G.section_no where Q.SURVEY_NO>2 and Q.SURVEY_NO=(select max(SURVEY_NO) from jpmms.EQUIPMENTMAINQC where main_no=Q.main_no) and G.section_id is null and  Q.section_id is not null)),
                    (select count(*) GetStreetsSampleDublicateIRI from jpmms.LANE_SAMPLES ls join JPMMS.SampleNODublicate D on D.LANE_ID=ls.LANE_ID and LS.SAMPLE_NO=(select min(SAMPLE_NO) from jpmms.LANE_SAMPLES where LS.LANE_ID=LANE_ID)),
                    (select count(MAIN_NO)GetStreetsSampleExceed from JPMMS.LANE_SAMPLES LS where main_no in (select main_no from JPMMS.EQUIPMENTMAINQC) and LANE_ID not in (select LANE_ID from JPMMS.LANE)),
                    (select count(SECTIONS_MATCH) GetDistressCount from (select case when SECTIONS=SECTIONSIRI then 1 else 0 end  SECTIONS_MATCH,case when LANES=LANESIRI then 1 else 0 end  LANES_MATCH from jpmms.COUNTLANESIRI I join jpmms.COUNTSECTIONSIRI SC on I.MAIN_NO =SC.MAIN_NO and I.Survey_NO =SC.Survey_NO join jpmms.STREETS ST on ST.MAIN_NO=SC.MAIN_NO left join jpmms.COUNT_DISTRESS_LANES  L on ST.STREET_ID=L.STREET_ID and L.Survey_NO =SC.Survey_NO left join jpmms.COUNT_DISTRESS_SECTIONS S on S.STREET_ID =ST.STREET_ID and S.Survey_NO =SC.Survey_NO where SC.Survey_NO=(select max(Survey_NO) from JPMMS.EQUIPMENTMAINQC where MAIN_NO =SC.MAIN_NO) and exists (select STREET_ID from jpmms.STREETSQC where IS_REVIEW_EDITING = 1  AND IS_REVIEW_ANALYZ = 1 AND FINSHED=1  AND STREET_ID=ST.STREET_ID) )where SECTIONS_MATCH =0 or LANES_MATCH=0),
                    (select count(MAIN_NO)GetUDICount from JPMMS.EQUIPMENTMAINQC where (STREET_ID,SURVEY_NO) in (select  STREET_ID,SURVEY_NO from jpmms.EQUIPMENTMAINQC where IS_DDF=1 minus  select STREET_ID,max(SURVEY_NO)SURVEY_NO  from jpmms.UDI_SECTION where SURVEY_NO>2 group by  STREET_ID,SURVEY_NO )),
                    (select count(MAIN_NO)GetMINCount from jpmms.EQUIPMENTMAINQC  where (STREET_ID,SURVEY_NO) in (select STREET_ID,SURVEY_NO from jpmms.EQUIPMENTMAINQC  where IS_DDF=1 minus select STREET_ID,max(SURVEY_NO)SURVEY_NO from jpmms.MAINTENANCE_DECISIONS where SURVEY_NO>2 and SECTION_ID is not null group by  STREET_ID,SURVEY_NO)),
                    (select count(MAIN_NO)GetDrawUpdateSections from (select distinct MAIN_NO from jpmms.sections where MAIN_NO is null or REGION_NO is null or ARNAME is null or MUNICIPALITY is null or STREET_ID is null union  select distinct MAIN_NO from jpmms.sections where SECTION_NO in (select section_no from JPMMS.SECTIONSUPDATE group by section_no having count(section_no)>1))),
                    (select count(distinct SAMPLE_ID)GetDeletedSamples from JPMMS.DISTRESS D where (DONE_BY=39 or DONE_BY=40)  and sample_id not in ( select sample_id from JPMMS.LANE_SAMPLES)),
                    (select count(distinct STREETNO)Distressmanuale from JPMMS.DDF where (MPID ='15' and SEVERITY in ('1','2')) or (MPID ='10' and SEVERITY = '1')),
                    (select count(t.STREET_ID)GetStreetDeleted from (select distinct  MAIN_NO,STREET_ID from JPMMS.EQUIPMENTMAINQC  minus select MAIN_NO,STREET_ID from JPMMS.STREETS where STREET_TYPE=1)t),
                    (select count(*)CountErorrData from JPMMS.VE_LATEST_IRI_LENGHTH_SEC where SECTION_ID in (select SECTION_ID from  JPMMS.VE_LATEST_IRI_LENGHTH_SEC group by SECTION_ID  having count(*)>1))");

            return db.ExecuteQuery(sql);
        }
        public DataTable GetIsNotComplete()
        {
            string sql = @"select  row_number() OVER (ORDER BY Q.MAIN_NO) ID ,
                            Q.MAIN_NO,Q.STREET_ID,Q.ARNAME,
                            DECODE(Q.UPDATING, 1, 'True', 'False') AS UPDATING, 
                            DECODE(Q.EDITING, 1, 'True', 'False') AS EDITING ,
                            DECODE(Q.DRAWING, 1, 'True', 'False') AS DRAWING,
                            SURVEY_NO, case when TypeOfEquipment=39 then 'MFV' when TypeOfEquipment=40 then 'RDAS' else ' ' end AS TypeOfEquipment,
                            DECODE(Q.COMPLETING, 1, 'True', 'False') AS COMPLETING
                            from JPMMS.STREETSQC Q join JPMMS.EQUIPMENTMAINQC  EQ on EQ.MAIN_NO = Q.MAIN_NO 
                            where EQ.SURVEY_NO=(select max(SURVEY_NO) from JPMMS.EQUIPMENTMAINQC  where main_no=Q.MAIN_NO ) and  Q.IS_NOTCOMPLETE=1";
            return db.ExecuteQuery(sql);
        }
        public bool UpdateIsNotComplete(string MAIN_NO, bool UPDATING, bool EDITING, bool DRAWING)
        {
            if (string.IsNullOrEmpty(MAIN_NO))
                return false;
            else
            {
                string sql;
                if (DRAWING || EDITING || UPDATING)
                    sql = string.Format("update STREETSQC set UPDATING=0 , EDITING='{1}' , DRAWING='{2}',IS_DRAWINGFINSH=0,IS_NOTCOMPLETE=0 ,COMPLETING=0 where MAIN_NO='{3}'",
                         UPDATING == true ? 1 : 0, EDITING == true ? 1 : 0, DRAWING == true ? 1 : 0, MAIN_NO);
                else
                    sql = string.Format("update STREETSQC set UPDATING='{0}' , EDITING='{1}' , DRAWING='{2}', IS_NOTCOMPLETE=0 ,COMPLETING=0 where MAIN_NO='{3}'",
                     UPDATING == true ? 1 : 0, EDITING == true ? 1 : 0, DRAWING == true ? 1 : 0, MAIN_NO);
                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
        }
        public DataTable CountValidateGPRIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct t.MAIN_NO from (select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where section_no is not null 
                    minus select distinct section_no,MAIN_NO from jpmms.gpr where section_no is not null  and SURVEY_NO>'2')t where t.MAIN_NO in (select MAIN_NO from jpmms.EQUIPMENTMAINQC where is_gpr=1) order by t.main_no ");
            else
                sql = string.Format(@"select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where main_no='{0}' and section_no is not null 
                    minus select distinct section_no,MAIN_NO from jpmms.gpr where main_no='{0}'  and SURVEY_NO>'2' and SURVEY_NO='{1}' and section_no is not null ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable CountValidateFWD(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct t.MAIN_NO from (select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where section_no is not null 
                    minus select distinct section_no,MAIN_NO from jpmms.fwd_data where section_no is not null  and SURVEY_NO>2)t where t.MAIN_NO in (select MAIN_NO from jpmms.EQUIPMENTMAINQC where is_fwd=1) order by t.main_no ");
            else
                sql = string.Format(@"select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where main_no='{0}' and section_no is not null 
                    minus select distinct section_no,MAIN_NO from jpmms.fwd_data where main_no='{0}'  and SURVEY_NO>2 and SURVEY_NO='{1}' and section_no is not null ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable CountValidateSKIDIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct t.MAIN_NO from (select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where section_no is not null 
                    minus select distinct section_no,MAIN_NO from jpmms.skid_data where section_no is not null  and SURVEY_NO>2)t where t.MAIN_NO in (select MAIN_NO from jpmms.EQUIPMENTMAINQC where is_skid=1) order by t.main_no ");
            else
                sql = string.Format(@"select to_char(section_no)section_no,to_char(MAIN_NO)MAIN_NO from jpmms.sections where main_no='{0}' and section_no is not null 
                    minus select distinct section_no,MAIN_NO from jpmms.skid_data where main_no='{0}'  and SURVEY_NO>2 and SURVEY_NO='{1}' and section_no is not null ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable LanesDeletedSKID(string MAIN_NO, bool OnlyMAIN_NO)
        {
            string sql;
            if (OnlyMAIN_NO)
                sql = string.Format(@"select distinct MAIN_NO from (select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.SKID_DATA where SURVEY_NO>2  and REMARKS=0 minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSSKID) order by main_no");
            else
            {
                if (string.IsNullOrEmpty(MAIN_NO))
                    sql = string.Format(@"select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.SKID_DATA where SURVEY_NO>2  and REMARKS=0
                                        minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSSKID order by MAIN_NO,SURVEY_NO");
                else
                    sql = string.Format(@"select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.SKID_DATA where SURVEY_NO>2  and REMARKS=0 and  main_no='{0}'
                                        minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSSKID where  main_no='{0}' order by SURVEY_NO", MAIN_NO);
            }
            return db.ExecuteQuery(sql);
        }
        public DataTable LanesDeletedGPR(string MAIN_NO, bool OnlyMAIN_NO)
        {
            string sql;
            if (OnlyMAIN_NO)
                sql = string.Format(@"select distinct MAIN_NO from (select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.GPR where SURVEY_NO>'2' and section_no is not null minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSGPR) order by main_no");
            else
            {
                if (string.IsNullOrEmpty(MAIN_NO))
                    sql = string.Format(@"select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.GPR where SURVEY_NO>'2' and section_no is not null
                                        minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSGPR order by MAIN_NO,SURVEY_NO");
                else
                    sql = string.Format(@"select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from JPMMS.GPR where SURVEY_NO>'2' and section_no is not null and  main_no='{0}'
                                        minus select MAIN_NO,SECTION_NO,LANE,SURVEY_NO from jpmms.TOTALDETAILSGPR where  main_no='{0}' order by SURVEY_NO", MAIN_NO);
            }
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetDeleted()
        {
            string sql = string.Format(@"select distinct  MAIN_NO,STREET_ID,Arname from JPMMS.EQUIPMENTMAINQC  minus select MAIN_NO,STREET_ID,Arname from JPMMS.STREETS where STREET_TYPE=1");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDistressManuale()
        {
            string sql = string.Format(@"select distinct SECTION,STREETNO,SURVEY_NO from JPMMS.DDF where (MPID ='15' and SEVERITY in ('1','2')) or (MPID ='10' and SEVERITY = '1')order by STREETNO ");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrDistressGPR()
        {
            string sql = string.Format(@"SELECT distinct LE.SECTION_ID,LE.SECTION_NO RIGHTSECTIONNO,QC.SECTION_NO WRONGSECTIONNO,QC.MAIN_NO
       FROM JPMMS.SECTIONS  LE
         RIGHT   JOIN JPMMS.GPR QC
                ON     LE.SECTION_NO = QC.SECTION_NO 
                where survey_no>'2' and LE.SECTION_NO is null and QC.SECTION_NO is not null");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrDistressFWD()
        {
            string sql = string.Format(@"SELECT distinct LE.SECTION_ID,LE.SECTION_NO RIGHTSECTIONNO,QC.SECTION_NO WRONGSECTIONNO,QC.MAIN_NO
       FROM JPMMS.SECTIONS  LE
         RIGHT   JOIN JPMMS.FWD_DATA QC
                ON     LE.SECTION_NO = QC.SECTION_NO 
                where survey_no>2 and LE.SECTION_NO is null");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrDistressSKID()
        {
            string sql = string.Format(@"SELECT distinct LE.SECTION_ID,LE.SECTION_NO RIGHTSECTIONNO,QC.SECTION_NO WRONGSECTIONNO,QC.MAIN_NO
       FROM JPMMS.SECTIONS  LE
         RIGHT   JOIN JPMMS.SKID_DATA QC
                ON     LE.SECTION_NO = QC.SECTION_NO 
                where survey_no>2 and LE.SECTION_NO is null");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrMainNOIRI()
        {
            string sql = string.Format(@"select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.IRI where
                (SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO)or(SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO) order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrIRIDISTRESS()
        {
            string sql = string.Format(@"select SECTION_NO,SURVEY_NO,MAIN_NO,(select DECODE(IS_DDF, 0, 'False', 'True') from JPMMS.EQUIPMENTMAINQC where MAIN_NO=ID.MAIN_NO and SURVEY_NO=ID.SURVEY_NO)IS_DDF from jpmms.IRIDISTRESS ID");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrMainNODDF()
        {
            string sql = string.Format(@"select STREETNO MAIN_NO,SECTION SECTION_NO,SURVEY_NO from  JPMMS.DDF where
                (SURVEY_NO>2 and JPMMS.isNum(SECTION)=1 and SUBSTR(SECTION, -4)<>STREETNO)or(SURVEY_NO>2 and JPMMS.isNum(SECTION)=0 and SUBSTR(SUBSTR(SECTION, 0, LENGTH(SECTION) - 1), -4)<>STREETNO) order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrMainNOFWD()
        {
            string sql = string.Format(@"select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.FWD_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO 
                        union all select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.FWD_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrMainNOSKID()
        {
            string sql = string.Format(@"select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.SKID_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO
                        union all select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.SKID_DATA where SURVEY_NO>2 and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrMainNOGPR()
        {
            string sql = string.Format(@"select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.GPR where SURVEY_NO>'2' and JPMMS.isNum(SECTION_NO)=1 and SUBSTR(SECTION_NO, -4)<>MAIN_NO
                        union all select MAIN_NO,SECTION_NO,SURVEY_NO from  JPMMS.GPR where SURVEY_NO>'2' and JPMMS.isNum(SECTION_NO)=0 and SUBSTR(SUBSTR(SECTION_NO, 0, LENGTH(SECTION_NO) - 1), -4)<>MAIN_NO order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrDistressDDF()
        {
            //            string sql = string.Format(@"select  distinct SECTION_NO,SECTION_ID from JPMMS.DISTRESS where SECTION_NO is not null and done_by=39 and SECTION_NO not in (
            //SELECT SECTION_NO
            //       FROM JPMMS.SECTIONS
            //     INTERSECT 
            //     SELECT distinct LE.SECTION_NO
            //       FROM JPMMS.SECTIONS  LE
            //            JOIN JPMMS.DISTRESS QC
            //                ON     LE.SECTION_NO = QC.SECTION_NO
            //                   AND LE.SECTION_ID = QC.SECTION_ID
            //WHERE done_by=39)");
            string sql = string.Format(@"SELECT distinct QC.SECTION_ID,LE.SECTION_NO RIGHTSECTIONNO,QC.SECTION_NO WRONGSECTIONNO,LE.MAIN_NO
       FROM JPMMS.SECTIONS  LE
            JOIN JPMMS.DISTRESS QC
                ON     LE.SECTION_NO <> QC.SECTION_NO
                   AND LE.SECTION_ID = QC.SECTION_ID
                   where (DONE_BY=39 or DONE_BY=40) ");
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateUpdateIRI()
        {
            string sql = string.Format(@" select * from JPMMS.VE_LATEST_IRI_LENGHTH_SEC where SECTION_ID in (
   select SECTION_ID from  JPMMS.VE_LATEST_IRI_LENGHTH_SEC
   group by SECTION_ID
   having count(*)>1) order by main_no,SECTION_ID");
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateUpdateDistress()
        {
            string sql = string.Format(@"select d.SURVEY_NO,d.SECTION_NO,d.SECTION_ID,
            case when LENGTH(SUBSTR(d.section_no,7,5))=5 then SUBSTR(SUBSTR(d.section_no,7,5),1,4) else SUBSTR(d.section_no,-4) end  MAIN_NO
            from jpmms.distTest  d join jpmms.distTest v on d.SECTION_ID=v.SECTION_ID
            where d.SECTION_no<>v.SECTION_no order by d.SECTION_ID");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsErorrIRI()
        {
            string sql = string.Format(@"SELECT distinct QC.SECTION_ID,LE.SECTION_NO RIGHTSECTIONNO,QC.SECTION_NO WRONGSECTIONNO
       FROM JPMMS.SECTIONS  LE
            JOIN JPMMS.IRI QC
                ON     LE.SECTION_NO <> QC.SECTION_NO
                   AND LE.SECTION_ID = QC.SECTION_ID
                   where survey_no=3");
            return db.ExecuteQuery(sql);
        }
        public DataTable CountSectionsErorrDistressIRI()
        {
            string sql = string.Format(@"select count(t.SECTION_ID) from (
SELECT distinct QC.SECTION_ID SECTION_ID
       FROM JPMMS.SECTIONS  LE
            JOIN JPMMS.DISTRESS QC
                ON     LE.SECTION_NO <> QC.SECTION_NO
                   AND LE.SECTION_ID = QC.SECTION_ID
                   where (DONE_BY=39 or DONE_BY=40) 
                   union all
                   SELECT distinct QC.SECTION_ID SECTION_ID
       FROM JPMMS.SECTIONS  LE
            JOIN JPMMS.IRI QC
                ON     LE.SECTION_NO <> QC.SECTION_NO
                   AND LE.SECTION_ID = QC.SECTION_ID
                   where survey_no>2)t");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoSKID()
        {
            string sql = string.Format(@"select  r.main_no,r.survey_no,r.CLEARANCE_SKID CLEARANCE,min(c.SURVEY_NO) Right_SURVEY  from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_SKID ,c.IS_SKID,c.SURVEY_NO,r.CLEARANCE_SKID
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_SKID=1 and c.IS_SKID=0 
                                            order by r.CLEARANCE_SKID,r.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoGPR()
        {
            string sql = string.Format(@"select  r.main_no,r.survey_no,r.CLEARANCE_GPR CLEARANCE,min(c.SURVEY_NO) Right_SURVEY  from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_GPR ,c.IS_GPR,c.SURVEY_NO,r.CLEARANCE_GPR
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_GPR=1 and c.IS_GPR=0 
                                            order by r.CLEARANCE_GPR,r.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoFWD()
        {
            string sql = string.Format(@"select  r.main_no,r.survey_no,r.CLEARANCE_FWD CLEARANCE,min(c.SURVEY_NO) Right_SURVEY  from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_FWD ,c.IS_FWD,c.SURVEY_NO,r.CLEARANCE_FWD
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_FWD=1 and c.IS_FWD=0 
                                            order by r.CLEARANCE_FWD,r.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoASSETS()
        {
            string sql = string.Format(@"select  r.main_no,r.survey_no,r.CLEARANCE_ASSETS CLEARANCE,min(c.SURVEY_NO) Right_SURVEY  from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_ASSETS ,c.IS_ASSETS,c.SURVEY_NO,r.CLEARANCE_ASSETS
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_ASSETS=1 and c.IS_ASSETS=0 
                                            order by r.CLEARANCE_ASSETS,r.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoIRI()
        {
            string sql = string.Format(@"select  r.main_no,r.survey_no,r.CLEARANCE_IRI CLEARANCE,min(c.SURVEY_NO) Right_SURVEY  from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_IRI ,c.IS_IRI,c.SURVEY_NO,r.CLEARANCE_IRI
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_IRI=1 and c.IS_IRI=0 
                                            order by r.CLEARANCE_IRI,r.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoDDF()
        {
            string sql = string.Format(@"select  r.main_no,r.survey_no,r.CLEARANCE_DDF CLEARANCE,min(c.SURVEY_NO) Right_SURVEY   from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_DDF ,c.IS_DDF,c.SURVEY_NO,r.CLEARANCE_DDF
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_DDF=1 and c.IS_DDF=0 
                                            order by r.CLEARANCE_DDF,r.main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable ErorrSuerveyNoIRIDDF()
        {
            string sql = string.Format(@"select  r.main_no main_no,r.survey_no survey_no,r.CLEARANCE_IRI CLEARANCE,min(c.SURVEY_NO) Right_SURVEY   from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_IRI ,c.IS_IRI,c.SURVEY_NO,r.CLEARANCE_IRI
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_IRI=1 and c.IS_IRI=0 
                                        UNION
                                        select  r.main_no,r.survey_no,r.CLEARANCE_DDF CLEARANCE,min(c.SURVEY_NO) Right_SURVEY   from JPMMS.EQUIPMENTMAINQC r join 
                                            JPMMS.EQUIPMENTMAINQC  c on r.MAIN_NO = c.MAIN_NO 
                                            group by r.main_no,r.survey_no,r.IS_DDF ,c.IS_DDF,c.SURVEY_NO,r.CLEARANCE_DDF
                                            having  max(r.SURVEY_NO) > min(c.SURVEY_NO) and r.IS_DDF=1 and c.IS_DDF=0");
            return db.ExecuteQuery(sql);
        }
        public DataTable FWD_NotComplete()
        {
            string sql = string.Format(@"select MAIN_NO,ARNAME,FWD_COUNT LENGTH,CLEARANCE_FWD CLEARANCE,SURVEY_NO
                                            from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_FWD=1 and CLEARANCE_FWD is null order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GPR_NotComplete()
        {
            string sql = string.Format(@"select MAIN_NO,ARNAME,NVL(GPR_IRI_LEN,GPR_SHAPE_LEN)LENGTH,CLEARANCE_GPR CLEARANCE,SURVEY_NO
                                            from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_GPR=1 and CLEARANCE_GPR is null order by NVL(GPR_IRI_LEN,GPR_SHAPE_LEN) desc");
            return db.ExecuteQuery(sql);
        }
        public DataTable SKID_NotComplete()
        {
            string sql = string.Format(@"select MAIN_NO,ARNAME,NVL(SKID_IRI_LEN,SKID_SHAPE_LEN)LENGTH,CLEARANCE_SKID CLEARANCE,SURVEY_NO
                                            from jpmms.EQUIPMENTMAINQC where IS_SKID=1 and CLEARANCE_SKID is null order by NVL(SKID_IRI_LEN,SKID_SHAPE_LEN) desc");
            return db.ExecuteQuery(sql);
        }
        public DataTable RoadsUdi(string IS_MAINSTREETS, string survey_no)
        {
            string sql;

            if (string.IsNullOrEmpty(IS_MAINSTREETS) && string.IsNullOrEmpty(survey_no))
                sql = string.Format(@"select * from jpmms.vw_Roads_udi  where  UDI_STREET  is not null ");
            else if (string.IsNullOrEmpty(IS_MAINSTREETS) && !string.IsNullOrEmpty(survey_no))
                sql = string.Format(@"select * from jpmms.vw_Roads_udi  where  UDI_STREET  is not null  and survey_no={0}", survey_no);
            else if (!string.IsNullOrEmpty(IS_MAINSTREETS) && string.IsNullOrEmpty(survey_no))
                sql = string.Format(@"select * from jpmms.vw_Roads_udi  where  UDI_STREET  is not null  and IS_MAINSTREETS={0}", IS_MAINSTREETS);
            else
                sql = string.Format(@"select * from jpmms.vw_Roads_udi  where  UDI_STREET  is not null  and IS_MAINSTREETS={0} and survey_no={1}", IS_MAINSTREETS, survey_no);

            return db.ExecuteQuery(sql);
        }
        public DataTable IRIDDF_NotComplete(bool? IRIDDF)
        {
            string sql;
            if (IRIDDF.HasValue)
            {
                if (IRIDDF.Value)
                    sql = string.Format(@"select MAIN_NO,ARNAME,STREET_IRI_LEN LENGTH ,CLEARANCE_IRI CLEARANCE,SURVEY_NO
                                            from JPMMS.EQUIPMENTMAINQC where is_closed=0 and  IS_IRI=1 and CLEARANCE_IRI is null");
                else
                    sql = string.Format(@"select MAIN_NO,ARNAME,STREET_IRI_LEN LENGTH,CLEARANCE_DDF CLEARANCE,SURVEY_NO
                                            from jpmms.EQUIPMENTMAINQC where is_closed=0 and  IS_DDF=1  and CLEARANCE_DDF is null order by MAIN_NO");

            }
            else
                sql = string.Format(@"select MAIN_NO,ARNAME,STREET_IRI_LEN LENGTH ,SURVEY_NO, CLEARANCE_IRI ,CLEARANCE_DDF ,
                                        DECODE(IS_DDF, 0, 'False', 'True') AS IS_DDF,DECODE(IS_IRI, 0, 'False', 'True') AS IS_IRI
                                        from JPMMS.EQUIPMENTMAINQC where  is_closed=0 and  (IS_IRI=1 and CLEARANCE_IRI is null) or (IS_DDF=1  and CLEARANCE_DDF is null) order by IS_IRI,IS_DDF desc,MAIN_NO ");
            return db.ExecuteQuery(sql);
        }

        public DataTable ASSETES_NotComplete()
        {
            string sql = string.Format(@"select QC.MAIN_NO,ARNAME,STREET_ASSETS_LEN LENGTH,CLEARANCE_ASSETS CLEARANCE,QC.SURVEY_NO,FX.SURVEY_MONTH
                                            from jpmms.EQUIPMENTMAINQC QC join (select distinct MAIN_NO,SURVEY_NO,SURVEY_MONTH from JPMMS.ASSETS_FINAL ) FX 
                                            on FX.MAIN_NO=QC.MAIN_NO and FX.SURVEY_NO=QC.SURVEY_NO where IS_ASSETS=1 and CLEARANCE_ASSETS is null order by QC.MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable SectionsFromT0()
        {
            string sql = string.Format(@"SELECT MAIN_NO,section_id FROM JPMMS.SECTIONS where FROM_STREET is null or TO_STREET is null or length(FROM_STREET)<3 or length(TO_STREET)<3 group by MAIN_NO,section_id order by MAIN_NO,section_id");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetLaneSamplesArea(bool Count)
        {
            //(select count(distinct LS.main_no)GetLaneSamplesArea from JPMMS.LANE_SAMPLES LS join JPMMS.STREETSQC  ST on LS.main_no=ST.main_no where  IS_REVIEW_EDITING = 1 AND IS_REVIEW_ANALYZ = 1 AND FINSHED = 0 and (SAMPLE_LENGTH is null or SAMPLE_WIDTH is null)and LS.SAMPLE_NO=(select min(SAMPLE_NO) from JPMMS.LANE_SAMPLES where LS.LANE_ID=JPMMS.LANE_SAMPLES.LANE_ID))
            //string sql = string.Format(@"select distinct LS.main_no,st.arname from JPMMS.LANE_SAMPLES LS join JPMMS.STREETSQC  ST on LS.main_no=ST.main_no where  IS_REVIEW_EDITING = 1 AND IS_REVIEW_ANALYZ = 1 AND FINSHED = 0 and (SAMPLE_LENGTH is null or SAMPLE_WIDTH is null) and LS.SAMPLE_NO=(select min(SAMPLE_NO) from JPMMS.LANE_SAMPLES where LS.LANE_ID=JPMMS.LANE_SAMPLES.LANE_ID)");
            string sql;
            if (Count)
                sql = string.Format(@"SELECT count(distinct main_no)GetLaneSamplesArea from jpmms.MFVFOUR X join jpmms.GV_SAMPLES GV on GV.SECTION_ID = X.SECTION_ID and GV.LANE_ID = X.LANE_ID where  SAMPLE_LENGTH=0 or SAMPLE_WIDTH=0");
            else
                sql = string.Format(@"SELECT distinct main_no,GV.arname from jpmms.MFVFOUR X join jpmms.GV_SAMPLES GV on GV.SECTION_ID = X.SECTION_ID and GV.LANE_ID = X.LANE_ID where  SAMPLE_LENGTH=0 or SAMPLE_WIDTH=0");
            return db.ExecuteQuery(sql);
        }
        public bool CheckGetLaneSamplesArea()
        {
            int result;
            object value = db.ExecuteScalar("select count(*) from  jpmms.MFVONE where JPMMS.ISNUM(DIST_AREA)=0");
            if (value != null)
            {
                int.TryParse(value.ToString(), out result);
                if (result > 0)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        public DataTable GetDrawUpdateSections()
        {
            string sql = string.Format(@"select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from jpmms.sections where 
                                        MAIN_NO is null or REGION_NO is null or ARNAME is null or MUNICIPALITY is null or STREET_ID is null 
                                        union  select distinct SECTION_ID,SECTION_NO,REGION_NO,MAIN_NO,STREET_ID,ARNAME,MUNICIPALITY from jpmms.sections where 
                                        SECTION_NO in (select section_no from JPMMS.SECTIONSUPDATE group by section_no having count(section_no)>1) order by MAIN_NO,SECTION_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSampleExceed()
        {
            //and LS.SAMPLE_NO=(select min(SAMPLE_NO) from JPMMS.LANE_SAMPLES where LS.LANE_ID=JPMMS.LANE_SAMPLES.LANE_ID) 
            string sql = string.Format(@"select MAIN_NO,LANE_ID,SAMPLE_ID from JPMMS.LANE_SAMPLES LS where main_no in (select main_no from JPMMS.EQUIPMENTMAINQC) 
                                            and LANE_ID not in (select LANE_ID from JPMMS.LANE) order by main_no");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfoGPR(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select ARNAME,
                                        (select sum(count(distinct SECTION_NO)) from GPR where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by  SECTION_NO) COUNTSECTION,
                                        (select sum(count(distinct lane)) from GPR where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} and SECTION_NO is not null group by  SECTION_NO, lane)COUNTLANE 
                                        from STREETS where MAIN_NO in (select MAIN_NO from GPR where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1})", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfoSKID(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select ARNAME,
                                        (select sum(count(distinct SECTION_NO)) from SKID_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by  SECTION_NO) COUNTSECTION,
                                        (select sum(count(distinct lane)) from SKID_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by  SECTION_NO, lane)COUNTLANE 
                                        from STREETS where MAIN_NO in (select MAIN_NO from SKID_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1})", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfoSKIDNew(string MAIN_NO)
        {
            string sql = string.Format(@"select ARNAME,
                                        (select sum(count(distinct SECTION_NO)) from SKID where MAIN_NO='{0}' and SURVEY_NO=4 group by  SECTION_NO) COUNTSECTION,
                                        (select sum(count(distinct lane)) from SKID where MAIN_NO='{0}' and SURVEY_NO=4 group by  SECTION_NO, lane)COUNTLANE 
                                        from STREETS where MAIN_NO in (select MAIN_NO from SKID where MAIN_NO='{0}' and SURVEY_NO=4) 
                                        ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsInfoFWD(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select ARNAME,
                                        (select sum(count(distinct SECTION_NO)) from FWD_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by  SECTION_NO) COUNTSECTION,
                                        (select sum(count(distinct lane)) from FWD_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by  SECTION_NO, lane)COUNTLANE 
                                        from STREETS where MAIN_NO in (select MAIN_NO from FWD_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1})", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSections(int STREET_ID)
        {
            string sql = string.Format(@"select row_number() OVER (ORDER BY SECTION_NO)SN,SECTION_NO,SECTION_ID,FROM_STREET,TO_STREET,
                                            (select count(LANE_ID) from LANE where SECTION_NO=S.SECTION_NO and main_no=S.main_no group by SECTION_NO  ) TCountLane,
                                            (SELECT  LISTAGG(LANE_TYPE, ',') WITHIN GROUP (ORDER BY LANE_TYPE) FROM   LANE where SECTION_NO=S.SECTION_NO and main_no=S.main_no)LTYPE
                                            from SECTIONS S where STREET_ID={0} ", STREET_ID);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSections(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select distinct  SECTION_NO,SECTION_ID,
                                            (select count(distinct LANE) from IRI where SECTION_NO=S.SECTION_NO and SURVEY_NO={1} group by SECTION_NO  ) TCountIRI,
                                            (select count(LANE_ID) from LANE where SECTION_NO=S.SECTION_NO and main_no=S.main_no group by SECTION_NO  ) TCountLane,
                                            (SELECT  LISTAGG(t.LANE, ',') WITHIN GROUP (ORDER BY LANE) from
                                            (SELECT   LANE,SECTION_NO FROM IRI  where MAIN_NO='{0}' and SURVEY_NO={1} group by SECTION_NO,LANE)t where t.SECTION_NO=S.SECTION_NO)LTYPE
                                            from IRI S where MAIN_NO='{0}' and SURVEY_NO={1} ORDER BY SECTION_NO", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsGPR(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select distinct  SECTION_NO,
                                            (select count(distinct LANE) from GPR where SECTION_NO=S.SECTION_NO and SURVEY_NO>'2' and SURVEY_NO='{1}' and SECTION_NO is not null group by SECTION_NO  ) TCountIRI,
                                            (select count(LANE_ID) from LANE where SECTION_NO=S.SECTION_NO group by SECTION_NO  ) TCountLane,
                                            (SELECT  LISTAGG(t.LANE, ',') WITHIN GROUP (ORDER BY LANE) from
                                            (SELECT   LANE,SECTION_NO FROM GPR  where MAIN_NO='{0}' and SURVEY_NO>'2' and SURVEY_NO='{1}' group by SECTION_NO,LANE)t where t.SECTION_NO=S.SECTION_NO)LTYPE
                                            from GPR S where MAIN_NO='{0}' and SURVEY_NO>'2' and SURVEY_NO='{1}'  and SECTION_NO is not null ORDER BY SECTION_NO", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsSKID(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select distinct  SECTION_NO,
                                            (select count(distinct LANE) from SKID_DATA where SECTION_NO=S.SECTION_NO and SURVEY_NO>2 and SURVEY_NO={1} group by SECTION_NO  ) TCountIRI,
                                            (select count(LANE_ID) from LANE where SECTION_NO=S.SECTION_NO group by SECTION_NO  ) TCountLane,
                                            (SELECT  LISTAGG(t.LANE, ',') WITHIN GROUP (ORDER BY LANE) from
                                            (SELECT   LANE,SECTION_NO FROM SKID_DATA  where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by SECTION_NO,LANE)t where t.SECTION_NO=S.SECTION_NO)LTYPE
                                            from SKID_DATA S where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} ORDER BY SECTION_NO", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsFWD(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select distinct  SECTION_NO,
                                            (select count(distinct LANE) from FWD_DATA where SECTION_NO=S.SECTION_NO and SURVEY_NO>2 and SURVEY_NO={1} group by SECTION_NO  ) TCountIRI,
                                            (select count(LANE_ID) from LANE where SECTION_NO=S.SECTION_NO group by SECTION_NO  ) TCountLane,
                                            (SELECT  LISTAGG(t.LANE, ',') WITHIN GROUP (ORDER BY LANE) from
                                            (SELECT   LANE,SECTION_NO FROM FWD_DATA  where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} group by SECTION_NO,LANE)t where t.SECTION_NO=S.SECTION_NO)LTYPE
                                            from FWD_DATA S where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} ORDER BY SECTION_NO", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsDetailsIRI(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = @"select main_no,concat(main_no ,(concat(' ',arname))) arname from STREETS where MAIN_NO in (select distinct MAIN_NO from IRI_LENGHTH_TEST) order by main_no";
            else
                sql = string.Format(@"select row_number() OVER (ORDER BY X.SECTION_NO)SN,X.main_no,X.SECTION_NO,X.SEC_LENGTH ,X.SEC_LANES_COUNT,X.SEC_WIDTH,X.SEC_LANES_LENGTH,X.SEC_LANES_TYPE,FROM_STREET,TO_STREET,SEC_DIRECTION          
                                           from  IRI_LENGHTH_SEC X LEFT join SECTIONS S on S.SECTION_NO = X.SECTION_NO where X.MAIN_NO='{0}'
                                           order by X.main_no,SEC_DIRECTION,SEC_ORDER ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsDetailsIRI()
        {
            string sql = string.Format(@"select row_number() OVER (ORDER BY X.SECTION_NO)SN,X.main_no,X.SECTION_NO,X.SEC_LENGTH ,X.SEC_LANES_COUNT,X.SEC_WIDTH,X.SEC_LANES_LENGTH,X.SEC_LANES_TYPE,FROM_STREET,TO_STREET,SEC_DIRECTION          
                                           from  IRI_LENGHTH_SEC X LEFT join SECTIONS S on S.SECTION_NO = X.SECTION_NO order by X.main_no,SEC_DIRECTION,SEC_ORDER ");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsDetailsSYS(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = @"select main_no,concat(main_no ,(concat(' ',arname))) arname from STREETS where MAIN_NO in (select distinct MAIN_NO from IRI_LENGHTH_TEST) order by main_no";
            else
                sql = string.Format(@"select ROW_NUMBER () OVER (ORDER BY MAIN_NO,SECTION_NO) SN, MAIN_NO,SECTION_NO,SEC_LENGTH,SEC_LANES_COUNT,SEC_WIDTH,SEC_LANES_LENGTH,
            SEC_LANES_TYPE,FROM_STREET,TO_STREET,SEC_DIRECTION from STREETS_SECTIONS_LANE_GIS  where MAIN_NO='{0}'  order by main_no,SEC_DIRECTION,SEC_ORDER", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsDetailsSYS()
        {
            string sql = string.Format(@"select ROW_NUMBER () OVER (ORDER BY MAIN_NO,SECTION_NO) SN, MAIN_NO,SECTION_NO,SEC_LENGTH,SEC_LANES_COUNT,SEC_WIDTH,SEC_LANES_LENGTH,
            SEC_LANES_TYPE,FROM_STREET,TO_STREET,SEC_DIRECTION from STREETS_SECTIONS_LANE_GIS  order by main_no,SEC_DIRECTION,SEC_ORDER");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsDetailsNewIRI(string MAIN_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO))
                sql = @"select main_no,concat(main_no ,(concat(' ',arname))) arname from STREETS where MAIN_NO in (select distinct MAIN_NO from IRI_LENGHTH_TEST) order by main_no";
            else
                sql = string.Format(@"select row_number() OVER (ORDER BY X.SECTION_NO)SN,X.main_no,X.SECTION_NO,X.SEC_LENGTH ,X.SEC_LANES_COUNT,X.SEC_WIDTH,X.SEC_LANES_LENGTH,X.SEC_LANES_TYPE        
                                           from  jpmms.IRI_LENGHTH_SEC X left join jpmms.SECTIONS S on S.SECTION_NO = X.SECTION_NO
                                           where S.SECTION_NO is null and  X.MAIN_NO='{0}'
                                           order by X.main_no,SEC_DIRECTION,SEC_ORDER", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSectionsDetailsNewIRI()
        {
            string sql = string.Format(@"select row_number() OVER (ORDER BY X.SECTION_NO)SN,X.main_no,X.SECTION_NO,X.SEC_LENGTH ,X.SEC_LANES_COUNT,X.SEC_WIDTH,X.SEC_LANES_LENGTH,X.SEC_LANES_TYPE        
                                           from  jpmms.IRI_LENGHTH_SEC X left join jpmms.SECTIONS S on S.SECTION_NO = X.SECTION_NO
                                           where S.SECTION_NO is null  order by X.main_no,SEC_DIRECTION,SEC_ORDER");
            return db.ExecuteQuery(sql);
        }
        public DataTable GetFwdnotinReport(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct f.main_no, concat(f.main_no ,(concat(' ',S.arname))) arname ,S.SURVEY_NO from jpmms.fwd_data f join jpmms.EQUIPMENTMAINQC  S on     S.MAIN_NO=f.MAIN_NO
            where   f.SURVEY_NO=S.SURVEY_NO and not exists (select SECTION_NO from jpmms.FWD_SECTION_DETIALS where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO  ) order by  MAIN_NO");
            else
                sql = string.Format(@"select distinct f.MAIN_NO ,f.SECTION_NO ,DECODE(IS_DDF, 0, 'False', 'True') AS IS_DDF ,S.SURVEY_NO from fwd_data f join EQUIPMENTMAINQC  S on     S.MAIN_NO=f.MAIN_NO
            where   f.SURVEY_NO=S.SURVEY_NO and not exists (select SECTION_NO from FWD_SECTION_DETIALS where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO  ) and S.MAIN_NO='{0}' and S.SURVEY_NO={1} ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetSKIDnotinReport(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"  select distinct f.main_no, concat(f.main_no ,(concat(' ',S.arname))) arname,S.SURVEY_NO  from skid_data f join EQUIPMENTMAINQC  S on     S.MAIN_NO=f.MAIN_NO
            where   f.SURVEY_NO=S.SURVEY_NO and not exists (select SECTION_NO from SKID_JEDDAH where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO  ) order by  MAIN_NO");
            else
                sql = string.Format(@"select distinct f.MAIN_NO ,f.SECTION_NO ,DECODE(IS_DDF, 0, 'False', 'True') AS IS_DDF from skid_data f join JPMMS.EQUIPMENTMAINQC S on S.MAIN_NO=f.MAIN_NO
               where   f.SURVEY_NO=S.SURVEY_NO and not exists (select SECTION_NO from SKID_JEDDAH where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO  ) and f.MAIN_NO='{0}' and S.SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetGPRnotinReport(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"  select distinct f.main_no, concat(f.main_no ,(concat(' ',S.arname))) arname,S.SURVEY_NO  from GPR f join EQUIPMENTMAINQC  S on     S.MAIN_NO=f.MAIN_NO
            where   f.SURVEY_NO=S.SURVEY_NO and f.SECTION_NO is not null and not exists (select SECTION_NO from GPR_LANE where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO  ) order by  MAIN_NO");
            else
                sql = string.Format(@"select distinct f.MAIN_NO ,f.SECTION_NO ,DECODE(IS_DDF, 0, 'False', 'True') AS IS_DDF from GPR f join JPMMS.EQUIPMENTMAINQC S on S.MAIN_NO=f.MAIN_NO
               where   f.SURVEY_NO=S.SURVEY_NO and f.SECTION_NO is not null and  not exists (select SECTION_NO from GPR_LANE where SURVEY_NO=S.SURVEY_NO and MAIN_NO=f.MAIN_NO and SECTION_NO=f.SECTION_NO  ) and f.MAIN_NO='{0}' and S.SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLength(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE,round(LEN,0) LEN,SURVEY_NO from IRIAVARAGESECTION where MAIN_NO='{0}' and SURVEY_NO={1} ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateIRI(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                //                sql = string.Format(@"select distinct main_no, concat(main_no ,(concat(' ',arname))) arname  from STREETS S
                //                                      where exists  (select main_no from ValidateIRI where MAIN_NO=S.MAIN_NO and SURVEY_NO={0} )order by  MAIN_NO", SURVEY_NO);
                sql = string.Format(@"select distinct s.main_no, concat(s.main_no ,(concat(' ',arname))) arname,s.SURVEY_NO  from EQUIPMENTMAINQC S
                    join ValidateIRI V on V.MAIN_NO=S.MAIN_NO and s.SURVEY_NO=V.SURVEY_NO order by  s.MAIN_NO");
            else sql = string.Format(@"select * from ValidateIRI where MAIN_NO='{0}' and SURVEY_NO={1} ", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateFWD(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct main_no, concat(main_no ,(concat(' ',arname))) arname,s.SURVEY_NO   from EQUIPMENTMAINQC S
                                      where exists  (select main_no from ValidateFWD where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO)order by  MAIN_NO");
            else sql = string.Format(@"select * from ValidateFWD where MAIN_NO='{0}'and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateSKID(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct main_no, concat(main_no ,(concat(' ',arname))) arname,SURVEY_NO from JPMMS.EQUIPMENTMAINQC S
                                      where exists  (select main_no from jpmms.ValidateSkid where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO )order by  MAIN_NO");
            else sql = string.Format(@"select * from ValidateSkid where MAIN_NO='{0}' and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable ValidateGPR(string MAIN_NO, string SURVEY_NO)
        {
            string sql;
            if (string.IsNullOrEmpty(MAIN_NO) && string.IsNullOrEmpty(SURVEY_NO))
                sql = string.Format(@"select distinct main_no,  concat(main_no ,(concat(' ',arname))) arname,SURVEY_NO from EQUIPMENTMAINQC S
                                      where exists  (select main_no from ValidateGPR where MAIN_NO=S.MAIN_NO and SURVEY_NO=S.SURVEY_NO )order by  MAIN_NO");
            else sql = string.Format(@"select * from ValidateGPR where MAIN_NO='{0}' and SURVEY_NO={1}", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLengthSKID(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE from SKID_DATA where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO={1} and remarks=0 order by SECTION_NO,LANE", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLengthSKIDNew(string MAIN_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE from SKID where MAIN_NO='{0}' and SURVEY_NO=4 and remarks=0 ", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLengthGPR(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE from GPR where MAIN_NO='{0}' and SURVEY_NO>2 and SURVEY_NO='{1}' and SECTION_NO is not null order by SECTION_NO,LANE", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLengthDDF(string MAIN_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE,NULL LEN from DDFAVARAGE where MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLengthDDFCLEAN(string MAIN_NO, string SURVEY_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE,case when MPID=0 then '0' else null end LEN ,SURVEY_NO from DDFAVARAGECLEAN where MAIN_NO='{0}' and SURVEY_NO='{1}'", MAIN_NO, SURVEY_NO);
            return db.ExecuteQuery(sql);
        }
        public bool SelectInterSectionsReady(string STREET_ID, string SURVEY_NO, string DistressCount)
        {
            try
            {
                string sql = string.Format(@"select count(STREET_ID) from JPMMS.INTERSECTQC where IS_REVIEWREPORT=1 and STREET_ID={0} and SURVEY_NO='{1}'",
                    STREET_ID, SURVEY_NO);
                return db.ExecuteScalar(sql).ToString() == DistressCount ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateInterSectionsReady(string STREET_ID, string SURVEY_NO, string INTERSECTIONS_SYS, string INTERSECTIONS_DISTRESS, string INTERSECTIONS_DISTRESS_LEN)
        {
            try
            {
                string sql = string.Format(@"update jpmms.EQUIPMENTMAINQC set IS_INTERSECTIONS=1 ,INTERSECTIONS_SYS={2},INTERSECTIONS_DISTRESS={3},INTERSECTIONS_DISTRESS_LEN={4} where STREET_ID={0} and SURVEY_NO='{1}'",
                    STREET_ID, SURVEY_NO, INTERSECTIONS_SYS, INTERSECTIONS_DISTRESS, INTERSECTIONS_DISTRESS_LEN);
                return db.ExecuteNonQuery(sql) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetLength(string MAIN_NO)
        {
            string sql = string.Format(@"select * from jpmms.VW_LANESAMPLEone L
                                                join jpmms.IRIAVARAGESECTION ISC on
                                                L.SECTION_NO = ISC.SECTION_NO AND
                                                L.LANE_TYPE=ISC.LANE
                                                where L.MAIN_NO='{0}'", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataSet CompareGPR(string CLEARANCE)
        {

            DataSet ds = new DataSet();
            string sqlOne, sqlTwo;
            if (string.IsNullOrEmpty(CLEARANCE))
            {
                sqlOne = "select distinct CLEARANCE_GPR from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_GPR=1 and CLEARANCE_GPR is not null order by CLEARANCE_GPR ";
                sqlTwo = string.Format(@"select * from jpmms.HAFRIAT_GPR where 1=2");
            }
            else if (CLEARANCE == "ALL")
            {
                sqlOne = string.Format(@"select EQ.MAIN_NO,ARNAME,
                                            SECTIONS_SYS,CTSECTION GPR_SECTIONS,LANES_SYS,CTLANE GPR_LANES,
                                            STREET_SHAPE_LEN,STREET_IRI_LEN,GPR_SHAPE_LEN,GPR_IRI_LEN
                                            ,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,CLEARANCE_GPR,EQ.SURVEY_NO,LENGTH GPR_LENGTH
                                            from jpmms.EQUIPMENTMAINQC EQ join jpmms.TOTALSUMGPR TS on TS.SURVEY_NO=EQ.SURVEY_NO and TS.MAIN_NO=EQ.MAIN_NO
                                            where  is_closed=0 and IS_GPR=1 and CLEARANCE_GPR is not null order by EQ.MAIN_NO");
                sqlTwo = string.Format(@"select * from jpmms.HAFRIAT_GPR");

            }
            else
            {
                sqlOne = string.Format(@"select EQ.MAIN_NO,ARNAME,
                                            SECTIONS_SYS,CTSECTION GPR_SECTIONS,LANES_SYS,CTLANE GPR_LANES,
                                            STREET_SHAPE_LEN,STREET_IRI_LEN,GPR_SHAPE_LEN,GPR_IRI_LEN
                                            ,IS_SKID,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,CLEARANCE_GPR,EQ.SURVEY_NO,LENGTH GPR_LENGTH
                                            from jpmms.EQUIPMENTMAINQC EQ join jpmms.TOTALSUMGPR TS on TS.SURVEY_NO=EQ.SURVEY_NO and TS.MAIN_NO=EQ.MAIN_NO
                                            where  is_closed=0 and IS_GPR=1 and CLEARANCE_GPR={0} order by EQ.MAIN_NO", CLEARANCE);
                sqlTwo = string.Format(@"select * from jpmms.HAFRIAT_GPR  where CLEARANCE={0}", CLEARANCE);
            }
            DataTable dt1 = db.ExecuteQuery(sqlOne);
            dt1.TableName = "VW_GPR_KM";
            ds.Tables.Add(dt1.Copy());
            DataTable dt2 = db.ExecuteQuery(sqlTwo);
            dt2.TableName = "VW_GPR_HAFRIAT";
            ds.Tables.Add(dt2.Copy());
            return ds;
        }
        public DataTable SKIDNotIRI()
        {
            string sql = string.Format(@"select to_char(MAIN_NO)MAIN_NO,SURVEY_NO from jpmms.TOTALSUMSKID  
                                        minus 
                                        select to_char(EQ.MAIN_NO),EQ.SURVEY_NO from jpmms.EQUIPMENTMAINQC EQ
                                        join jpmms.TOTALSUMSKID TS on TS.SURVEY_NO=EQ.SURVEY_NO and TS.MAIN_NO=EQ.MAIN_NO
                                        where IS_SKID=1 order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable GPRNotIRI()
        {
            string sql = string.Format(@"select to_char(MAIN_NO)MAIN_NO,SURVEY_NO from jpmms.TOTALSUMGPR 
                                        minus 
                                        select to_char(EQ.MAIN_NO) MAIN_NO,to_char(EQ.SURVEY_NO)SURVEY_NO from jpmms.EQUIPMENTMAINQC EQ
                                        join jpmms.TOTALSUMGPR TS on TS.SURVEY_NO=EQ.SURVEY_NO and TS.MAIN_NO=EQ.MAIN_NO
                                        where IS_GPR=1 order by MAIN_NO");
            return db.ExecuteQuery(sql);
        }
        public DataTable CompareSKID(string CLEARANCE)
        {
            string sql;
            if (string.IsNullOrEmpty(CLEARANCE))
                sql = "select distinct CLEARANCE_SKID from jpmms.EQUIPMENTMAINQC where IS_SKID=1 and CLEARANCE_SKID is not null order by CLEARANCE_SKID ";
            else if (CLEARANCE == "ALL")
                sql = string.Format(@"select EQ.MAIN_NO,ARNAME,
                                            SECTIONS_SYS,CTSECTION SKID_SECTIONS,LANES_SYS,CTLANE SKID_LANES,
                                            STREET_SHAPE_LEN,STREET_IRI_LEN,SKID_SHAPE_LEN,SKID_IRI_LEN
                                            ,IS_GPR,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,CLEARANCE_SKID, DECODE(is_closed, 1, 'True', 'False') AS is_closed,EQ.SURVEY_NO,LENGTH SKID_LENGTH
                                            from jpmms.EQUIPMENTMAINQC EQ
                                            join jpmms.TOTALSUMSKID TS on TS.SURVEY_NO=EQ.SURVEY_NO and TS.MAIN_NO=EQ.MAIN_NO
                                            where IS_SKID=1 and CLEARANCE_SKID is not null
                                            order by EQ.MAIN_NO");
            else
                sql = string.Format(@"select EQ.MAIN_NO,ARNAME,
                                            SECTIONS_SYS,CTSECTION SKID_SECTIONS,LANES_SYS,CTLANE SKID_LANES,
                                            STREET_SHAPE_LEN,STREET_IRI_LEN,SKID_SHAPE_LEN,SKID_IRI_LEN
                                            ,IS_GPR,IS_FWD,IS_IRI,IS_DDF,IS_ASSETS,CLEARANCE_SKID, DECODE(is_closed, 1, 'True', 'False') AS is_closed,EQ.SURVEY_NO,LENGTH SKID_LENGTH
                                            from jpmms.EQUIPMENTMAINQC EQ
                                            join jpmms.TOTALSUMSKID TS on TS.SURVEY_NO=EQ.SURVEY_NO and TS.MAIN_NO=EQ.MAIN_NO
                                            where IS_SKID=1 and CLEARANCE_SKID={0}
                                            order by EQ.MAIN_NO", CLEARANCE);
            return db.ExecuteQuery(sql);
        }
        public DataSet CompareFWD(string CLEARANCE)
        {
            DataSet ds = new DataSet();
            string sqlOne, sqlTwo;
            if (string.IsNullOrEmpty(CLEARANCE))
            {
                sqlOne = "select distinct CLEARANCE_FWD from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_FWD=1 and CLEARANCE_FWD is not null order by CLEARANCE_FWD ";
                sqlTwo = string.Format(@"select * from jpmms.HAFRIAT_FWD where 1=2");
            }
            else if (CLEARANCE == "ALL")
            {
                sqlOne = string.Format(@"select MAIN_NO,ARNAME,FWD_COUNT,STREET_ASSETS_LEN,CLEARANCE_FWD,SURVEY_NO
                                            from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_FWD=1 and CLEARANCE_FWD is not null
                                            order by MAIN_NO");
                sqlTwo = string.Format(@"select * from jpmms.HAFRIAT_FWD");

            }
            else
            {
                sqlOne = string.Format(@"select MAIN_NO,ARNAME,FWD_COUNT,STREET_ASSETS_LEN,CLEARANCE_FWD,SURVEY_NO
                                            from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_FWD=1 and CLEARANCE_FWD={0}
                                            order by MAIN_NO", CLEARANCE);
                sqlTwo = string.Format(@"select * from jpmms.HAFRIAT_FWD  where CLEARANCE={0}", CLEARANCE);
            }
            DataTable dt1 = db.ExecuteQuery(sqlOne);
            dt1.TableName = "VW_FWD_POINT";
            ds.Tables.Add(dt1.Copy());
            DataTable dt2 = db.ExecuteQuery(sqlTwo);
            dt2.TableName = "VW_FWD_HAFRIAT";
            ds.Tables.Add(dt2.Copy());
            return ds;
        }
        public DataTable CompareIRI(string CLEARANCE)
        {
            string sql;
            if (string.IsNullOrEmpty(CLEARANCE))
                sql = "select distinct CLEARANCE_IRI from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_IRI=1 and CLEARANCE_IRI is not null order by CLEARANCE_IRI ";
            else if (CLEARANCE == "ALL")
                sql = string.Format(@"select QC.MAIN_NO,QC.ARNAME,QC.SECTIONS_SYS,QC.IRI_SECTIONS,QC.LANES_SYS,QC.IRI_LANES,
                                        QC.STREET_SHAPE_LEN,QC.STREET_IRI_LEN,QC.IS_GPR,QC.IS_SKID,QC.IS_FWD,QC.IS_DDF,QC.IS_ASSETS,QC.CLEARANCE_IRI,SURVEY_NO
                                        from JPMMS.EQUIPMENTMAINQC  QC  where  QC.is_closed=0 and  QC.IS_IRI=1 and QC.CLEARANCE_IRI is not null order by MAIN_NO");
            else
                sql = string.Format(@"select QC.MAIN_NO,QC.ARNAME,QC.SECTIONS_SYS,QC.IRI_SECTIONS,QC.LANES_SYS,QC.IRI_LANES,
                                        QC.STREET_SHAPE_LEN,QC.STREET_IRI_LEN,QC.IS_GPR,QC.IS_SKID,QC.IS_FWD,QC.IS_DDF,QC.IS_ASSETS,QC.CLEARANCE_IRI,SURVEY_NO
                                        from JPMMS.EQUIPMENTMAINQC  QC  where  QC.is_closed=0 and  QC.IS_IRI=1 and QC.CLEARANCE_IRI={0} order by MAIN_NO", CLEARANCE);
            return db.ExecuteQuery(sql);
        }
        public DataTable FinalCompareASSETS(string CLEARANCE)
        {
            string sql;
            if (string.IsNullOrEmpty(CLEARANCE))
                sql = @"select  MAIN_NO,ARNAME,SURVEY_NO,SURVEY_MONTH,CLEARANCE_ASSETS,null IS_ASSETS  from JPMMS.CHECKASSETS where CLEARANCE_ASSETS<>SURVEY_MONTH order by MAIN_NO";
            else
                sql = string.Format(@"select MAIN_NO,ARNAME,SURVEY_NO,SURVEY_MONTH,CLEARANCE_ASSETS,null IS_ASSETS  from JPMMS.CHECKASSETS where CLEARANCE_ASSETS={0} order by MAIN_NO", CLEARANCE);
            return db.ExecuteQuery(sql);
        }
        public DataTable FinalCompareASSETS()
        {
            string sql = @"select distinct main_no,
                    (select distinct ARNAME from JPMMS.EQUIPMENTMAINQC where main_no = F.main_no) ARNAME,
                    SURVEY_no,
                    SURVEY_MONTH ,
                    DECODE(NVL((select IS_ASSETS  from JPMMS.EQUIPMENTMAINQC where main_no = F.main_no and SURVEY_NO=F.SURVEY_NO),0), 0, 'False', 'True') IS_ASSETS,
                    (select CLEARANCE_ASSETS from JPMMS.EQUIPMENTMAINQC where main_no = F.main_no and SURVEY_NO=F.SURVEY_NO) CLEARANCE_ASSETS 
                    from JPMMS.ASSETS_FINAL F where (main_no ,SURVEY_NO) in (select distinct MAIN_NO,SURVEY_NO from JPMMS.ASSETS_FINAL 
                    minus select MAIN_NO,SURVEY_NO from JPMMS.CHECKASSETS where  CLEARANCE_ASSETS is not null) order by SURVEY_MONTH,MAIN_NO";
            return db.ExecuteQuery(sql);
        }
        public DataTable CompareDDF(string CLEARANCE)
        {
            string sql;
            if (string.IsNullOrEmpty(CLEARANCE))
                sql = "select distinct CLEARANCE_DDF from jpmms.EQUIPMENTMAINQC where  is_closed=0 and IS_DDF=1 and CLEARANCE_DDF is not null order by CLEARANCE_DDF ";
            else if (CLEARANCE == "ALL")
                sql = string.Format(@"select QC.MAIN_NO,QC.ARNAME,QC.SECTIONS_SYS,QC.IRI_SECTIONS,QC.LANES_SYS,QC.IRI_LANES,
                                        QC.STREET_SHAPE_LEN,QC.STREET_IRI_LEN,QC.IS_GPR,QC.IS_SKID,QC.IS_FWD,QC.IS_DDF,QC.IS_ASSETS,QC.CLEARANCE_DDF,SURVEY_NO
                                        from jpmms.EQUIPMENTMAINQC  QC where  QC.is_closed=0 and  QC.IS_DDF=1  and QC.CLEARANCE_DDF is not null order by MAIN_NO");
            else
                sql = string.Format(@"select QC.MAIN_NO,QC.ARNAME,QC.SECTIONS_SYS,QC.IRI_SECTIONS,QC.LANES_SYS,QC.IRI_LANES,
                                        QC.STREET_SHAPE_LEN,QC.STREET_IRI_LEN,QC.IS_GPR,QC.IS_SKID,QC.IS_FWD,QC.IS_DDF,QC.IS_ASSETS,QC.CLEARANCE_DDF,SURVEY_NO
                                        from jpmms.EQUIPMENTMAINQC  QC where  QC.is_closed=0 and  QC.IS_DDF=1  and QC.CLEARANCE_DDF={0} order by MAIN_NO", CLEARANCE);
            return db.ExecuteQuery(sql);
        }
        public DataTable CompareInterSetions(string CLEARANCE)
        {
            string sql;
            if (string.IsNullOrEmpty(CLEARANCE))
                sql = "select distinct CLEARANCE_INTERSECTIONS from jpmms.EQUIPMENTMAINQC where  IS_INTERSECTIONS=1 and CLEARANCE_INTERSECTIONS is not null order by CLEARANCE_INTERSECTIONS ";
            else if (CLEARANCE == "ALL")
                sql = string.Format(@"select QC.MAIN_NO,QC.ARNAME,QC.INTERSECTIONS_SYS,QC.INTERSECTIONS_DISTRESS,
                                        QC.INTERSECTIONS_SHAPE_LEN,QC.INTERSECTIONS_DISTRESS_LEN,SURVEY_NO,QC.CLEARANCE_INTERSECTIONS
                                        from jpmms.EQUIPMENTMAINQC  QC where   QC.IS_INTERSECTIONS=1  and QC.CLEARANCE_INTERSECTIONS is not null order by MAIN_NO");
            else
                sql = string.Format(@"select QC.MAIN_NO,QC.ARNAME,QC.INTERSECTIONS_SYS,QC.INTERSECTIONS_DISTRESS,
                                        QC.INTERSECTIONS_SHAPE_LEN,QC.INTERSECTIONS_DISTRESS_LEN,SURVEY_NO,QC.CLEARANCE_INTERSECTIONS
                                        from jpmms.EQUIPMENTMAINQC  QC where QC.IS_INTERSECTIONS=1   and QC.CLEARANCE_INTERSECTIONS={0} order by MAIN_NO", CLEARANCE);
            return db.ExecuteQuery(sql);
        }
        public DataTable CompareASSETS(string CLEARANCE)
        {
            string sql;
            if (string.IsNullOrEmpty(CLEARANCE))
                sql = "select distinct CLEARANCE_ASSETS from jpmms.EQUIPMENTMAINQC where  IS_ASSETS=1 and CLEARANCE_ASSETS is not null order by CLEARANCE_ASSETS ";
            else if (CLEARANCE == "ALL")
                sql = string.Format(@"select MAIN_NO,ARNAME,STREET_ASSETS_LEN,SECTIONS_SYS,LANES_SYS,
                                        STREET_SHAPE_LEN,STREET_IRI_LEN,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,CLEARANCE_ASSETS,SURVEY_NO,DECODE(is_closed, 1, 'True', 'False') AS is_closed
                                        from jpmms.EQUIPMENTMAINQC where  IS_ASSETS=1 and CLEARANCE_ASSETS is not null
                                        order by MAIN_NO");
            else
                sql = string.Format(@"select MAIN_NO,ARNAME,STREET_ASSETS_LEN,SECTIONS_SYS,LANES_SYS,
                                        STREET_SHAPE_LEN,STREET_IRI_LEN,IS_GPR,IS_SKID,IS_FWD,IS_IRI,IS_DDF,CLEARANCE_ASSETS,SURVEY_NO,DECODE(is_closed, 1, 'True', 'False') AS is_closed
                                        from jpmms.EQUIPMENTMAINQC where   IS_ASSETS=1 and CLEARANCE_ASSETS={0}
                                        order by MAIN_NO", CLEARANCE);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetDistressCount()
        {
            string sql = string.Format(@"select * from DistressCount where SECTIONSDIS<>SECTIONSIRI or LANESDIS<>LANESIRI");
            return db.ExecuteQuery(sql);
        }
        public DataTable TOTALSUMGPR()
        {
            // string sql = string.Format(@"select sum(IRILENGTH) IRILENGTH from  TOTAL_SUM_GPR");
            string sql = string.Format(@"select sum(LENGTH),count(main_no) from  TOTALSUMGPR");
            return db.ExecuteQuery(sql);
        }
        public DataTable TOTALSUMSKID()
        {
            //string sql = string.Format(@"select sum(IRILENGTH) IRILENGTH from  TOTAL_SUM_SKID");
            //string sql = string.Format(@"select sum(t.LENGTH) from (select  ROUND (SUM (LENGTH) / 1000, 2) LENGTH  from JPMMS.INER_SKID_SHAPE_IRI union select  ROUND (SUM (LENGTH) / 1000, 2) LENGTH  from JPMMS.DIFF_SKID_SHAPE_IRI )t");
            string sql = string.Format(@"select sum(LENGTH),count(main_no) from jpmms.TOTALSUMSKID");
            return db.ExecuteQuery(sql);
        }
        public bool UpdateSectionsDrawing(string MAIN_NO, string SECTION_NO, string SURVEY_NO)
        {
            try
            {
                string sqlone = string.Format(@"select SECTION_ID from SECTIONS where  main_no='{0}' and SECTION_NO='{1}'", MAIN_NO, SECTION_NO);
                if (db.ExecuteScalar(sqlone).ToString().Length == 0)
                    return false;
                else
                {
                    string sql = string.Format(@"update  IRI set SECTION_ID =(select SECTION_ID from SECTIONS where  main_no='{0}' and SECTION_NO='{1}') 
                            where  main_no='{0}' and SECTION_ID is null and SECTION_NO='{1}' and SURVEY_NO={2} ", MAIN_NO, SECTION_NO, SURVEY_NO);
                    return db.ExecuteNonQuery(sql) > 0 ? true : false;
                }
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetStreetsSectionsLength(int MAIN_NO)
        {
            string sql = string.Format(@"select LANE_ID,SECTION_NO,LANE_TYPE LANE,round(sdE.sT_length (SHAPE),0) LEN from jpmms.LANE L
                            where exists (select SECTION_ID from jpmms.SECTIONS  where STREET_ID={0} and SECTION_ID=L.SECTION_ID and main_no=L.main_no )
                             order by SECTION_NO,LANE", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsShapeIRILength(string MAIN_NO)
        {
            string sql = string.Format(@"select LANE_ID,SECTION_NO,LANE_TYPE LANE,round(sdE.sT_length (SHAPE),0) LENSHAPE,
                                         (select round(LEN,0) LEN from jpmms.IRIAVARAGESECTION where MAIN_NO =x.MAIN_NO and SECTION_NO=x.SECTION_NO and LANE=x.LANE_TYPE)LANEIRI
                                         from jpmms.LANE x where SECTION_ID in (select SECTION_ID from jpmms.SECTIONS  where MAIN_NO='{0}') order by SECTION_NO,LANE", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsSectionsLengtErorr(int MAIN_NO)
        {
            string sql = string.Format(@"select SECTION_NO,LANE_TYPE LANE  from LANE 
                                            where SECTION_ID in (select SECTION_ID from SECTIONS  where STREET_ID={0}) 
                                            group by  SECTION_NO,LANE_TYPE 
                                            having count(SECTION_NO)>1
                                            order by SECTION_NO,LANE_TYPE", MAIN_NO);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetStreetsLanes(int STREET_ID)
        {
            string sql = string.Format(@"select count(LANE_ID) OVER(PARTITION BY SECTION_NO  ) Tcount ,SECTION_NO,LANE_TYPE,LANE_ID from LANE 
                            where SECTION_ID in (select SECTION_ID from SECTIONS  where STREET_ID={0} ) order by SECTION_NO,LANE_TYPE ", STREET_ID);
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllFullInfo()
        {
            // OFFICIAL_MUNIC_NUM||' - '||
            string sql = "select MAIN_NO, (ARNAME) as MAIN_ST_TITLE, ARNAME, ARNAME as MAIN_NAME, ENNAME, ENNAME as MAIN_EN_NAME, MAIN_ST_ID, street_id, " +
                " nvl(CONTRACTOR_ID, 0) as CONTRACTOR_ID, DECODE(NVL (IS_R4, 'N'), 'N', 'False', 'True') AS IS_R4_, OFFICIAL_MUNIC_NUM, " +
                " DECODE(NVL(FULLY_MUNIC_OWNED, '0'), '0', 'False', 'True') AS FULLY_MUNIC_OWNED_, DECODE(NVL(PARTIALLY_MUNIC_OWNED, '0'), '0', 'False', 'True') AS PARTIALLY_MUNIC_OWNED_,  " +
                " DECODE(NVL(NOT_MUNIC_OWNED, '0'), '0', 'False', 'True') AS NOT_MUNIC_OWNED_, DECODE(NVL(ALL_INTERSAMP_OWNED_MUNIC, '0'), '0', 'False', 'True') AS ALL_INTERSAMP_OWNED_MUNIC_, " +
                " OWNERSHIP_DETAILS, nvl(MAINST_CATEGORY_ID, 0) as MAINST_CATEGORY_ID   from STREETS where street_type=1 order by main_no ";

            return db.ExecuteQuery(sql);
        }

        public DataTable GetByID(int MAIN_ST_ID)
        {
            if (MAIN_ST_ID == 0)
                return new DataTable();

            // OFFICIAL_MUNIC_NUM||' - '||
            string sql = string.Format("select MAIN_NO, ARNAME, (ARNAME) as MAIN_ST_TITLE, ARNAME as MAIN_NAME, ENNAME, ENNAME as MAIN_EN_NAME, street_id, " +
                " MAIN_ST_ID, nvl(CONTRACTOR_ID, 0) as CONTRACTOR_ID, DECODE(NVL (IS_R4, 'N'), 'N', 'False', 'True') AS IS_R4_, OFFICIAL_MUNIC_NUM, " +
                " DECODE(NVL(FULLY_MUNIC_OWNED, '0'), '0', 'False', 'True') AS FULLY_MUNIC_OWNED_, DECODE(NVL(PARTIALLY_MUNIC_OWNED, '0'), '0', 'False', 'True') AS PARTIALLY_MUNIC_OWNED_,  " +
                " DECODE(NVL(NOT_MUNIC_OWNED, '0'), '0', 'False', 'True') AS NOT_MUNIC_OWNED_, DECODE(NVL(ALL_INTERSAMP_OWNED_MUNIC, '0'), '0', 'False', 'True') AS ALL_INTERSAMP_OWNED_MUNIC_, " +
                " OWNERSHIP_DETAILS, nvl(MAINST_CATEGORY_ID, 0) as MAINST_CATEGORY_ID  from STREETS where street_id={0} ", MAIN_ST_ID); // MAIN_ST_ID

            DataTable dt = db.ExecuteQuery(sql);
            dt.Columns.Add(new DataColumn("IS_R4", typeof(bool)));
            dt.Columns.Add(new DataColumn("FULLY_MUNIC_OWNED", typeof(bool)));
            dt.Columns.Add(new DataColumn("PARTIALLY_MUNIC_OWNED", typeof(bool)));
            dt.Columns.Add(new DataColumn("NOT_MUNIC_OWNED", typeof(bool)));
            dt.Columns.Add(new DataColumn("ALL_INTERSAMP_OWNED_MUNIC", typeof(bool)));
            foreach (DataRow dr in dt.Rows)
            {
                dr["IS_R4"] = bool.Parse(dr["IS_R4_"].ToString());
                dr["FULLY_MUNIC_OWNED"] = bool.Parse(dr["FULLY_MUNIC_OWNED_"].ToString());
                dr["PARTIALLY_MUNIC_OWNED"] = bool.Parse(dr["PARTIALLY_MUNIC_OWNED_"].ToString());
                dr["NOT_MUNIC_OWNED"] = bool.Parse(dr["NOT_MUNIC_OWNED_"].ToString());
                dr["ALL_INTERSAMP_OWNED_MUNIC"] = bool.Parse(dr["ALL_INTERSAMP_OWNED_MUNIC_"].ToString());
            }

            return dt;
        }

        public bool Update(string MAIN_NAME, string MAIN_EN_NAME, int CONTRACTOR_ID, bool IS_R4, bool FULLY_MUNIC_OWNED, bool PARTIALLY_MUNIC_OWNED, bool NOT_MUNIC_OWNED,
            string OWNERSHIP_DETAILS, int MAINST_CATEGORY_ID, string MAIN_NO, bool ALL_INTERSAMP_OWNED_MUNIC, int MAIN_ST_ID, string OFFICIAL_MUNIC_NUM)
        {
            MAIN_NAME = MAIN_NAME.Replace("'", "''");
            MAIN_EN_NAME = string.IsNullOrEmpty(MAIN_EN_NAME) ? "NULL" : string.Format("'{0}'", MAIN_EN_NAME.Replace("'", "''"));
            OWNERSHIP_DETAILS = string.IsNullOrEmpty(OWNERSHIP_DETAILS) ? "NULL" : string.Format("'{0}'", OWNERSHIP_DETAILS.Replace("'", "''"));
            OFFICIAL_MUNIC_NUM = string.IsNullOrEmpty(OFFICIAL_MUNIC_NUM) ? "NULL" : string.Format("'{0}'", OFFICIAL_MUNIC_NUM.Replace("'", "''"));

            string contarctorIDPart = (CONTRACTOR_ID == 0) ? "NULL" : CONTRACTOR_ID.ToString();
            string categoryIDPart = (MAINST_CATEGORY_ID == 0) ? "NULL" : MAINST_CATEGORY_ID.ToString();


            // MAIN_NAME , MAIN_EN_NAME
            string sql = string.Format("update STREETS set ARNAME='{0}', ENNAME={1}, CONTRACTOR_ID={2}, IS_R4='{3}', FULLY_MUNIC_OWNED={4}, PARTIALLY_MUNIC_OWNED={5}, " +
                " NOT_MUNIC_OWNED={6}, MAINST_CATEGORY_ID={7}, ALL_INTERSAMP_OWNED_MUNIC={9}, OWNERSHIP_DETAILS={10}, OFFICIAL_MUNIC_NUM={11}  where street_id={8}  ",
                MAIN_NAME, MAIN_EN_NAME, contarctorIDPart, Shared.Bool2YN(IS_R4), Shared.Bool2Int(FULLY_MUNIC_OWNED), Shared.Bool2Int(PARTIALLY_MUNIC_OWNED),
                Shared.Bool2Int(NOT_MUNIC_OWNED), categoryIDPart, MAIN_ST_ID, Shared.Bool2Int(ALL_INTERSAMP_OWNED_MUNIC), OWNERSHIP_DETAILS, OFFICIAL_MUNIC_NUM);

            int rows = db.ExecuteNonQuery(sql);
            if (rows > 0)
            {
                sql = string.Format("update SECTIONS set ARNAME='{0}' where STREET_ID={1} ", MAIN_NAME, MAIN_ST_ID);
                db.ExecuteNonQuery(sql);

                sql = string.Format("update INTERSECTIONS set ARNAME='{0}' where STREET_ID={1} ", MAIN_NAME, MAIN_ST_ID);
                db.ExecuteNonQuery(sql);
            }

            return (rows > 0);
        }

        public static string GetOwnerShipStatus(int MAIN_ST_ID)
        {
            if (MAIN_ST_ID == 0)
                return "";

            string sql = string.Format("select OFFICIAL_MUNIC_NUM, DECODE(NVL(FULLY_MUNIC_OWNED, '0'), '0', 'False', 'True') AS FULLY_MUNIC_OWNED, DECODE(NVL(PARTIALLY_MUNIC_OWNED, '0'), '0', 'False', 'True') AS PARTIALLY_MUNIC_OWNED, " +
                " DECODE(NVL(NOT_MUNIC_OWNED, '0'), '0', 'False', 'True') AS NOT_MUNIC_OWNED, OWNERSHIP_DETAILS from STREETS where street_id={0}  ", MAIN_ST_ID);
            DataTable dt = new OracleDatabaseClass().ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (bool.Parse(dr["FULLY_MUNIC_OWNED"].ToString()))
                    return "الطريق يتبع للأمانة " + (string.IsNullOrEmpty(dr["OWNERSHIP_DETAILS"].ToString()) ? "" : " - " + dr["OWNERSHIP_DETAILS"].ToString());
                else if (bool.Parse(dr["PARTIALLY_MUNIC_OWNED"].ToString()))
                    return "مقاطع محددة فقط من هذا الطريق تتبع للأمانة " + (string.IsNullOrEmpty(dr["OWNERSHIP_DETAILS"].ToString()) ? "" : " - " + dr["OWNERSHIP_DETAILS"].ToString());
                else if (bool.Parse(dr["NOT_MUNIC_OWNED"].ToString()))
                    return "هذا الطريق لا يتبع للأمانة " + (string.IsNullOrEmpty(dr["OWNERSHIP_DETAILS"].ToString()) ? "" : " - " + dr["OWNERSHIP_DETAILS"].ToString());
                else
                    return "";
            }
            else
                return "";
        }


        public DataTable GetAllMainStreets()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||         MAIN_ST_ID as id3
            string sql = "select street_id, main_no, concat(concat(main_no,' '),ARNAME) as main_title, ARNAME, ARNAME as main_name from STREETS where ARNAME is not null and street_type=1  order by ARNAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMainStreets(string main_no)
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||         MAIN_ST_ID as id3
            string sql = string.Format("select street_id, main_no, concat(concat(main_no,' '),ARNAME) as main_title, ARNAME, ARNAME as main_name from STREETS where ARNAME is not null and street_type=1  and main_no='{0}' order by ARNAME ", main_no);
            return db.ExecuteQuery(sql);
        }
        public DataTable LoadMFVMainStreetsHavingSKID()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||         MAIN_ST_ID as id3
            string sql = " SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title FROM STREETS S WHERE  exists (SELECT  MAIN_NO FROM skid_DATA where SURVEY_NO>1 and S.main_no=main_no) and street_type=1 ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetAllMainStreetsNonR4()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "select street_id, main_no, (ARNAME) as main_title, ARNAME, ARNAME as main_name from STREETS where IS_R4='N' and ARNAME is not null and street_type=1 order by ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetByID(int id)
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||  id3={0} or main_streets
            string sql = string.Format("select street_id, main_no, (ARNAME) as main_name from streets where street_id={0} order by ARNAME ", id);
            return db.ExecuteQuery(sql);
        }


        public DataTable Search(string numName, bool byNum)
        {
            if (string.IsNullOrEmpty(numName))
                return new DataTable();

            //string sql = "";  MAIN_NAME       MAIN_ST_ID
            numName = numName.Trim().Replace("'", "''");
            string columnName = (byNum ? "MAIN_NO" : "ARNAME");
            string sql = string.Format("select street_id, MAIN_NO, ARNAME as main_name, ARNAME, (ARNAME) as main_st_title from STREETS where {1} like '%{0}%' and STREET_TYPE=1 ", numName, columnName);
            return db.ExecuteQuery(sql);
        }



        public DataTable GetMainStreetsHavingSurveyDistresses(bool intersect)
        {
            return (intersect) ? GetMainStreetsHavingIntersectionsSurveyDistresses() : GetMainStreetsHavingSurveyDistresses();
        }

        public DataTable GetMainStreetsHavingSurveyDistresses()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "SELECT  street_id, Main_no, concat(arname,concat(MAIN_NO,'   ')) as main_title, ARNAME, ARNAME as main_name FROM STREETS where street_id in (select street_id from gv_sample_distress where SURVEY_NO=3 and dist_code is not null) and IS_R4='N' and street_type=1  ORDER BY  ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetsHavingIntersectionsSurveyDistresses()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||           MAIN_ST_ID, MAIN_ST_ID as id3 MAIN_STREET_ID (ARNAME)
            string sql = "SELECT  STREET_ID, Main_no, concat(arname,concat(MAIN_NO,'   ')) as main_title, ARNAME, ARNAME as main_name FROM STREETS where street_id in (select street_id from GV_INTERSECTION_DISTRESS where SURVEY_NO=3 and dist_code is not null and inter_no is not null) and IS_R4='N' and street_type=1  ORDER BY  ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetsHavingUdiCalculated()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "SELECT  STREET_ID, main_no, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS where main_no in (select main_no from gv_sample_udi) and IS_R4='N' and street_type=1   ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMainMFVStreetsHavingUdiCalculated()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title FROM STREETS  s where street_type=1  and IS_R4='N' and  exists (select main_no from gv_sample_udi where s.main_no= main_no)      ORDER BY main_title ";
            return db.ExecuteQuery(sql);
        }
        public DataTable GetMainStreetsHavingCalculatedUDI()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "SELECT  STREET_ID, main_no, (ARNAME) as main_title, ARNAME, ARNAME as main_name, MAX(SECTION_NO) SECTION_NO FROM GV_SAMPLE_UDI WHERE UDI_DATE IS NOT NULL and street_type=1  GROUP BY id3, main_no, ARNAME ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetHavingIntersectionWithCalculatedUdi()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||   main_streets   MAIN_ST_ID       main_street_id 
            string sql = "SELECT  STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name from STREETS where IS_R4='N' and STREET_ID in " +
                " (select STREET_ID FROM INTERSECTIONS  WHERE inter_no IN (SELECT inter_no FROM GV_INTERS_SMPL_UDI  WHERE UDI_DATE IS NOT NULL)) " +
                " and street_type=1 order by ARNAME ";

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetsHavingMaintenanceDecisions(bool isServiceLanes, bool forIntersections, bool isRegion)
        {
            string sql = "";  // MAIN_ST_ID, MAIN_ST_ID as ID3

            if (isServiceLanes)
                sql = "SELECT  STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE STREET_ID IN (SELECT STREET_ID FROM MAINTENANCE_DECISIONS WHERE UDI_DATE IS NOT NULL and SECTION_ID is not null) and IS_R4='N' and street_type=1   ORDER BY ARNAME ";
            else if (forIntersections)
                sql = "SELECT STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE STREET_ID IN (SELECT STREET_ID FROM MAINTENANCE_DECISIONS WHERE UDI_DATE IS NOT NULL and INTERSECTION_ID is not null) and IS_R4='N' and street_type=1  ORDER BY ARNAME ";
            else
                return new DataTable();

            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetsHavingMaintenanceDecisions()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "SELECT  STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE STREET_ID IN (SELECT STREET_ID FROM MAINTENANCE_DECISIONS WHERE UDI_DATE IS NOT NULL and section_id is not null) and IS_R4='N' and street_type=1   ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetMainStreetsHavingIntersectionsMaintenanceDecisions()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' || 
            string sql = "SELECT  STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE STREET_ID IN (SELECT STREET_ID FROM MAINTENANCE_DECISIONS WHERE UDI_DATE IS NOT NULL and inter_no is not null) and IS_R4='N' and street_type=1  ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }



        public DataTable LoadMainStreetHavingTrafficCounting()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||           MAIN_ST_ID, MAIN_ST_ID as ID3
            string sql = "SELECT main_no, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN  (SELECT MAIN_NO FROM TRAFFIC_COUNTING WHERE Start_time IS NOT NULL) and street_type=1   ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }

        public DataTable LoadMainStreetHavingFWD()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||           MAIN_ST_ID, MAIN_ST_ID as ID3  Main_STREETS
            string sql = "SELECT main_no, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN  (SELECT MAIN_NO FROM FWD_DATA) and street_type=1  ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable LoadMFVMainStreetHavingFWD()
        {
            // OFFICIAL_MUNIC_NUM || ' - ' ||           MAIN_ST_ID, MAIN_ST_ID as ID3  Main_STREETS
            string sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title FROM STREETS S WHERE street_type=1 and exists (SELECT distinct MAIN_NO FROM FWD_DATA where SURVEY_NO>1 and S.main_no=main_no)  ORDER BY ARNAME ";
            return db.ExecuteQuery(sql);
        }
        public DataTable LoadMainStreetsHavingCalculatedIri(bool forMainStreetLanes)
        {
            string sql = "";            // OFFICIAL_MUNIC_NUM || ' - ' ||  MAIN_ST_ID, MAIN_ST_ID as ID3

            if (forMainStreetLanes)
                sql = "SELECT   MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name  FROM STREETS WHERE MAIN_NO IN  (SELECT MAIN_NO FROM IRI WHERE  SURVEY_DATE  IS NOT NULL) and street_type=1  ORDER BY ARNAME ";
            else
                sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (SELECT MAIN_NO FROM IRI_INTERSECTION) and street_type=1  ORDER BY ARNAME ";

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable LoadMainMFVStreetsHavingCalculatedIri(bool forMainStreetLanes)
        {
            string sql = "";            // OFFICIAL_MUNIC_NUM || ' - ' ||  MAIN_ST_ID, MAIN_ST_ID as ID3

            if (forMainStreetLanes)
                sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title from STREETS s WHERE street_type=1 and  exists  (SELECT  distinct MAIN_NO FROM IRI WHERE SURVEY_NO>1 and  s.MAIN_NO=MAIN_NO) ORDER BY ARNAME  ";
            else
                sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title from STREETS s WHERE street_type=1 and exists (SELECT MAIN_NO FROM IRI_INTERSECTION s.MAIN_NO=MAIN_NO) and   ORDER BY ARNAME ";

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable LoadMainMFVStreetsHavingASETSS()
        {
            string sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title from STREETS s WHERE street_type=1 and  exists  (SELECT  MAIN_NO FROM ASSETS_final where  s.MAIN_NO=MAIN_NO and x  is not null and y is not null and SURVEY_MONTH is not null ) ORDER BY ARNAME  ";
            return db.ExecuteQuery(sql);
        }
        public DataTable LoadMainStreetsHavingCalculatedRutting(bool intersect)
        {
            string sql = ""; // MAIN_ST_ID, MAIN_ST_ID as ID3

            if (intersect)
                sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (SELECT distinct MAIN_NO FROM RUTTING_INTERSECTIONS) and street_type=1 ORDER BY ARNAME ";
            else
                sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (SELECT distinct MAIN_NO FROM RUTTING_SECTIONS) and street_type=1 ORDER BY ARNAME ";

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable LoadMainStreetsHavingGPR(bool isIntersection)
        {
            string sql = "";    // MAIN_ST_ID, MAIN_ST_ID as ID3 // ID3, 

            if (isIntersection)
                sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (select distinct main_no from GPR_INTERSECTIONS) and street_type=1  order by ARNAME ";
            else
                sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (select distinct main_no from GPR_LANE) and street_type=1   order by ARNAME ";

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }
        public DataTable LoadMFVMainStreetsHavingGPR(bool isIntersection)
        {
            string sql = "";    // MAIN_ST_ID, MAIN_ST_ID as ID3 // ID3, 

            if (isIntersection)
                sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title from STREETS s WHERE street_type=1 and  exists(select distinct main_no from GPR_INTERSECTIONS where s.main_no=main_no) order by ARNAME ";
            else
                sql = "SELECT  STREET_ID,main_no, concat(concat(main_no,' '),ARNAME) as main_title from STREETS s WHERE street_type=1 and  exists(select distinct main_no from GPR_LANE where s.main_no=main_no) order by ARNAME ";

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }

        public DataTable GetR4MainStreets()
        {
            string sql = "SELECT  STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE IS_R4='Y' and street_type=1 ORDER BY ARNAME "; //MAIN_NO 
            return db.ExecuteQuery(sql);
        }



        public DataTable GetMainStreetSamples(bool intersect, string sectionID, string interID)
        {
            if ((intersect && string.IsNullOrEmpty(interID)) || (!intersect && string.IsNullOrEmpty(sectionID)))
                return new DataTable(); // dt

            string sql = "";
            if (intersect)
                sql = string.Format("select INTER_SAMP_NO as sample_title, INTER_SAMP_ID as sample_id from GV_INTERSECTION_SAMPLES where INTERSECTION_ID={0}   order by INTER_SAMP_NO ", int.Parse(interID));
            else
                sql = string.Format("select (LANE_TYPE||' - '||SAMPLE_NO) as sample_title, SAMPLE_ID as sample_id from GV_SAMPLES where SECTION_ID={0} order by LANE_TYPE, SAMPLE_NO ", int.Parse(sectionID));

            return (string.IsNullOrEmpty(sql) ? new DataTable() : db.ExecuteQuery(sql));
        }


    }
}
