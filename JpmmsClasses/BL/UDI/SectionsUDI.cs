using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using JpmmsClasses.BL;
//using Oracle.DataAccess.Client;
using JpmmsClasses.BL.DistressEntry;
using System.Diagnostics;
using System.Web;

namespace JpmmsClasses.BL.UDI
{
    public class SectionsUDI
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private Dates hijri = new Dates();
        private DistressShared shared = new DistressShared();
        private DistressSurvey distSurvey = new DistressSurvey();
        private UdiRecord udi = new UdiRecord();
        private Region region = new Region();




        #region CalculatingUDI

        public bool CalculateMainStreetSectionsUDI(int mainStID, string user, bool wholeNetwork)
        {
            bool result = true;
            DataTable dt;
            if (wholeNetwork)
                dt = distSurvey.GetRegionsAndMainStreetSectionIntersections(0, "", "", "", false, false, false, false, mainStID, true, false);
            else
                dt = distSurvey.GetLastSurveyForRoadsNetwork(0, "", "", "", false, false, false, false, mainStID, true, false);

            foreach (DataRow dr in dt.Rows)
                result &= CalculateMainStreetSectionsUDI(mainStID, int.Parse(dr["SURVEY_NO"].ToString()), user);

            return result;
        }

        public bool CalculateMainStreetSectionsUDI(int mainStID, int surveyNo, string user)
        {
            if (new JpmmsClasses.BL.MainStreet().RemoveIRILength())
            {
                if (new JpmmsClasses.BL.MainStreet().InsertLengthDDF(mainStID.ToString(), surveyNo.ToString()))
                {
                    new JpmmsClasses.BL.MainStreet().UpdateLengthSAMPLESOld();
                }
            }

            //if (mainStID == 0 || surveyNo == 0)
            //    return false;

            RemovePreviousCalculations(mainStID, surveyNo);

            // retrieve main street samples
            int rows = 0;
            string sqlDistressesInfo = "";
            double sampleArea = 0;
            decimal DEDUCT_DEN_RAT = 0;

            DataTable dtSampleDistressesInfo; //, dtExists;
            DataRow dr;

            string sql = string.Format("SELECT SECTION_ID, SECTION_NO, LANE_ID, LANE_TYPE, SAMPLE_ID, SAMPLE_NO, MUNICIPALITY, SAMPLE_LENGTH, SAMPLE_WIDTH, " +
                " (SAMPLE_LENGTH*SAMPLE_WIDTH) as SAMPLE_AREA FROM GV_SAMPLES  WHERE STREET_ID={0} and SAMPLE_LENGTH<>0 and SAMPLE_WIDTH<>0  " +
                " order by SECTION_NO, LANE_TYPE, SAMPLE_NO  ", mainStID); // main_st_id
            //string sql = string.Format("SELECT * FROM GV_SAMPLESNEW  WHERE STREET_ID={0} ", mainStID); // main_st_id

            DataTable dtSamples = db.ExecuteQuery(sql);
            Shared.LogStatment(sql);
            if (dtSamples.Rows.Count == 0) //> 0)
                return false;

            foreach (DataRow drSample in dtSamples.Rows)
            {
                udi = new UdiRecord();

                // STATUS, STATUS_UPD, ENTRY_DATE_UPD   ORDER BY SAMPLE_ID
                sqlDistressesInfo = string.Format("SELECT section_no, arname, lane_type, sample_no, SAMPLE_ID, SURVEY_NO, " +
                    " to_char(max(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, SUM(DEDUCT_DEN_DASH) DEDUCT_DEN_RAT, " +
                    " SUM(DIST_DENSITY) DEN, MAX(DEDUCT_VALUE) DE_VALUE, MAX(DEN_DASH) DEN_D, MAX(DIST_CODE) DIS_CODE  " +
                    " FROM GV_SAMPLE_DISTRESS WHERE SAMPLE_ID={0} AND SURVEY_NO={1}   GROUP BY section_no, arname, lane_type, sample_no, SAMPLE_ID, SURVEY_NO  ",
                     drSample["SAMPLE_ID"].ToString(), surveyNo);

                Shared.LogStatment(sqlDistressesInfo);
                dtSampleDistressesInfo = db.ExecuteQuery(sqlDistressesInfo);
                if (dtSampleDistressesInfo.Rows.Count == 0)
                    continue;
                else
                {
                    #region All Distresses
                    dr = dtSampleDistressesInfo.Rows[0];
                    sampleArea = double.Parse(drSample["SAMPLE_AREA"].ToString());
                    DEDUCT_DEN_RAT = decimal.Parse(dr["DEDUCT_DEN_RAT"].ToString());
                    if (DEDUCT_DEN_RAT >= 0 && DEDUCT_DEN_RAT <= 5)
                        udi = UdiShared.GetUDI(DEDUCT_DEN_RAT);
                    else if (DEDUCT_DEN_RAT > 5)
                        udi = UdiShared.GetUDI(decimal.Parse(dr["DE_VALUE"].ToString()));

                    if (udi.udiValue == -1)
                        continue;


                    //sql = string.Format("SELECT SECTION_NO, LANE_TYPE, SAMPLE_NO, SURVEY_NO FROM UDI_SECTION_SAMPLE WHERE SAMPLE_ID={0} AND SURVEY_NO={1} ", drSample["SAMPLE_ID"].ToString(), surveyNo);
                    //Shared.LogStatment(sql);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_SECTION_SAMPLE set SAMPLE_LENGTH={0}, SAMPLE_WIDTH={1}, SAMPLE_AREA={2}, SURVEY_DATE=TO_DATE('{3}','DD/MM/YYYY'), " +
                    //        " UDI_DATE=(select sysdate from dual), UDI_VALUE={4}, UDI_RATE='{5}', MUNIC_NAME='{6}', LANE_ID={7}, STREET_ID={8}, SECTION_ID={9}, " +
                    //        " SECTION_NO='{10}', LANE_TYPE='{11}', SAMPLE_NO='{12}' where SAMPLE_ID={13} and SURVEY_No={14} ",  // MAIN_ST_ID
                    //       drSample["SAMPLE_LENGTH"].ToString(), drSample["SAMPLE_WIDTH"].ToString(), sampleArea.ToString("0.00"), dr["MAX_SURVEY_DATE"].ToString(),
                    //       udi.udiValue.ToString("N0"), udi.udiRate, drSample["MUNICIPALITY"].ToString(), drSample["LANE_ID"].ToString(), mainStID, drSample["SECTION_ID"].ToString(),
                    //      drSample["SECTION_NO"].ToString(), drSample["LANE_TYPE"].ToString(), drSample["SAMPLE_NO"].ToString(), drSample["SAMPLE_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_SECTION_SAMPLE WHERE SAMPLE_ID={0} AND SURVEY_NO={1} ", drSample["SAMPLE_ID"].ToString(), surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }


                    sql = string.Format("INSERT INTO UDI_SECTION_SAMPLE(SECTION_NO, LANE_TYPE, SAMPLE_NO, SAMPLE_LENGTH, SAMPLE_WIDTH, SAMPLE_AREA, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_No, MUNIC_NAME, RECORD_ID, SAMPLE_ID, LANE_ID, STREET_ID, SECTION_ID) " +
                        " VALUES('{0}', '{1}', '{2}', {3}, " +
                        " {4}, {5}, TO_DATE('{6}','DD/MM/YYYY'), (select sysdate from dual), {7}, '{8}', " +
                        " {9}, '{10}', SEQ_UDI_SEC_SAMPLE.nextval, {11}, {12}, {13}, {14}) ",
                        drSample["SECTION_NO"].ToString(), drSample["LANE_TYPE"].ToString(), drSample["SAMPLE_NO"].ToString(), drSample["SAMPLE_LENGTH"].ToString(),
                        drSample["SAMPLE_WIDTH"].ToString(), sampleArea.ToString("0.00"), dr["MAX_SURVEY_DATE"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate,
                        surveyNo, drSample["MUNICIPALITY"].ToString(), drSample["SAMPLE_ID"].ToString(), drSample["LANE_ID"].ToString(), mainStID, drSample["SECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                    #endregion

                    #region Patching Distresses

                    sqlDistressesInfo = string.Format("SELECT section_no, arname, lane_type, sample_no, SAMPLE_ID, SURVEY_NO, " +
                        " to_char(max(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                        " SUM(DEDUCT_DEN_DASH) DEDUCT_DEN_RAT, SUM(DIST_DENSITY) DEN, MAX(DEDUCT_VALUE) DE_VALUE, MAX(DEN_DASH) DEN_D, MAX(DIST_CODE) DIS_CODE  " +
                        " FROM GV_SAMPLE_DISTRESS WHERE SAMPLE_ID={0} AND SURVEY_NO={1}  and DIST_CODE in (12, 13, 14, 15)   " +
                        " GROUP BY section_no, arname, lane_type, sample_no, SAMPLE_ID, SURVEY_NO  ",
                         drSample["SAMPLE_ID"].ToString(), surveyNo);

                    Shared.LogStatment(sqlDistressesInfo);
                    dtSampleDistressesInfo = db.ExecuteQuery(sqlDistressesInfo);
                    if (dtSampleDistressesInfo.Rows.Count == 0)
                    {
                        //continue;
                        sampleArea = double.Parse(drSample["SAMPLE_AREA"].ToString());
                        udi = UdiShared.GetUDI(0);
                    }
                    else
                    {
                        dr = dtSampleDistressesInfo.Rows[0];
                        sampleArea = double.Parse(drSample["SAMPLE_AREA"].ToString());
                        DEDUCT_DEN_RAT = decimal.Parse(dr["DEDUCT_DEN_RAT"].ToString());
                        if (DEDUCT_DEN_RAT >= 0 && DEDUCT_DEN_RAT <= 5)
                            udi = UdiShared.GetUDI(DEDUCT_DEN_RAT);
                        else if (DEDUCT_DEN_RAT > 5)
                            udi = UdiShared.GetUDI(decimal.Parse(dr["DE_VALUE"].ToString()));
                    }

                    if (udi.udiValue == -1)
                        continue;


                    //sql = string.Format("SELECT SECTION_NO, LANE_TYPE, SAMPLE_NO, SURVEY_NO FROM UDI_SECTION_SAMPLE_PATCHING WHERE SAMPLE_ID={0} AND SURVEY_NO={1} ",
                    //   drSample["SAMPLE_ID"].ToString(), surveyNo);

                    //Shared.LogStatment(sql);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_SECTION_SAMPLE_PATCHING set SAMPLE_LENGTH={0}, SAMPLE_WIDTH={1}, SAMPLE_AREA={2}, SURVEY_DATE=TO_DATE('{3}','DD/MM/YYYY'), " +
                    //        " UDI_DATE=(select sysdate from dual), UDI_VALUE={4}, UDI_RATE='{5}', MUNIC_NAME='{6}', LANE_ID={7}, STREET_ID={8}, SECTION_ID={9}, " +
                    //        " SECTION_NO='{10}', LANE_TYPE='{11}', SAMPLE_NO='{12}' where SAMPLE_ID={13} and SURVEY_No={14} ",
                    //        drSample["SAMPLE_LENGTH"].ToString(), drSample["SAMPLE_WIDTH"].ToString(), sampleArea.ToString("0.00"), dr["MAX_SURVEY_DATE"].ToString(),
                    //        udi.udiValue.ToString("N0"), udi.udiRate, drSample["MUNICIPALITY"].ToString(), drSample["LANE_ID"].ToString(), mainStID, drSample["SECTION_ID"].ToString(),
                    //        drSample["SECTION_NO"].ToString(), drSample["LANE_TYPE"].ToString(), drSample["SAMPLE_NO"].ToString(), drSample["SAMPLE_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_SECTION_SAMPLE_PATCHING WHERE SAMPLE_ID={0} AND SURVEY_NO={1} ", drSample["SAMPLE_ID"].ToString(), surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }


                    sql = string.Format("INSERT INTO UDI_SECTION_SAMPLE_PATCHING(SECTION_NO, LANE_TYPE, SAMPLE_NO, SAMPLE_LENGTH, SAMPLE_WIDTH, SAMPLE_AREA, SURVEY_DATE, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_No, MUNIC_NAME, RECORD_ID, SAMPLE_ID, LANE_ID, STREET_ID, SECTION_ID) " +
                        " VALUES('{0}', '{1}', '{2}', {3}, " +
                        " {4}, {5}, TO_DATE('{6}','DD/MM/YYYY'), (select sysdate from dual), {7}, '{8}', " +
                        " {9}, '{10}', SEQ_UDI_SEC_SAMPLE.nextval, {11}, {12}, {13}, {14}) ",
                        drSample["SECTION_NO"].ToString(), drSample["LANE_TYPE"].ToString(), drSample["SAMPLE_NO"].ToString(), drSample["SAMPLE_LENGTH"].ToString(),
                        drSample["SAMPLE_WIDTH"].ToString(), sampleArea.ToString("0.00"), dr["MAX_SURVEY_DATE"].ToString(), udi.udiValue.ToString("N0"), udi.udiRate,
                        surveyNo, drSample["MUNICIPALITY"].ToString(), drSample["SAMPLE_ID"].ToString(), drSample["LANE_ID"].ToString(), mainStID, drSample["SECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                    //  }

                    #endregion
                }
            }


            //rows += CalculateSectionSamplesUDI(mainStID, surveyNo);
            rows += CalcualateLaneUDI(mainStID, surveyNo);
            rows += CalculateSectionUDI(mainStID, surveyNo);

            if (rows == 0)
                Shared.SaveLogfile("MAINTENANCE_DECISIONS", mainStID.ToString(), "Non-complete survey - Section/Lane UDI is not calculated yet!", user);
            else
                Shared.SaveLogfile("UDI", dtSamples.Rows.Count.ToString(), "UDI Calculation - Main Street Sections:" + mainStID.ToString(), user);
            //    throw new Exception(); "لم يتم حساب معامل حالة الرصف بسبب عدم اكتمال مسح هذا الطريق"


            return (rows > 0);
        }

        public int CalcualateLaneUDI(int mainStID, int surveyNo)
        {
            int rows = 0;
            DataRow sampleDr;
            DataTable dtSampleRecord; //, dtExists;
            string sectionNum, laneType;

            string sql = string.Format("SELECT SECTION_ID, SECTION_NO, LANE_TYPE, LANE_ID, SURVEY_NO, MUNIC_NAME, COUNT(SAMPLE_NO) AS NO_OF_SAMPLES, SUM(SAMPLE_LENGTH*SAMPLE_WIDTH) AS LANE_AREA  " +
                " FROM udi_section_sample WHERE STREET_ID={0} AND SURVEY_NO={1} and lane_id is not null " +
                " GROUP BY SECTION_ID, SECTION_NO, LANE_TYPE, LANE_ID, SURVEY_NO, MUNIC_NAME order by SECTION_NO, LANE_TYPE ", mainStID, surveyNo);

            Shared.LogStatment(sql);
            DataTable dtSamplesInfo = db.ExecuteQuery(sql);
            if (dtSamplesInfo.Rows.Count == 0)
                return 0;


            foreach (DataRow drLane in dtSamplesInfo.Rows)
            {
                udi = new UdiRecord();

                #region All Distresses
                sectionNum = drLane["SECTION_NO"].ToString();
                laneType = drLane["LANE_TYPE"].ToString();

                sql = string.Format("SELECT SECTION_NO, LANE_TYPE, SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as udidate, ROUND(AVG(udi_value), 2) udivalue, SUM(SAMPLE_LENGTH*SAMPLE_WIDTH) AS LANE_AREA, " +
                    " sum(sample_length) as lane_Length, round(Avg(sample_Width), 2) as lane_Width FROM udi_section_sample " +
                    " WHERE SECTION_NO='{0}' AND LANE_TYPE='{1}' AND SURVEY_NO={2} GROUP BY SECTION_NO, LANE_TYPE, SURVEY_NO ",
                    sectionNum, laneType, surveyNo);

                Shared.LogStatment(sql);
                dtSampleRecord = db.ExecuteQuery(sql);
                if (dtSampleRecord.Rows.Count > 0)
                {
                    sampleDr = dtSampleRecord.Rows[0];
                    udi = UdiShared.GetUDIRatio(decimal.Parse(sampleDr["udivalue"].ToString()));
                    if (udi.udiValue == -1)
                        continue;


                    //sql = string.Format("SELECT SECTION_NO, LANE_TYPE, SURVEY_NO FROM UDI_LANES  WHERE SECTION_NO='{0}' AND LANE_TYPE='{1}' AND SURVEY_NO={2} ", sectionNum, laneType, surveyNo);
                    //Shared.LogStatment(sql);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    // update
                    //    sql = string.Format("update UDI_laneS set SECTION_NO='{0}', SURVEY_DATE=TO_DATE('{1}', 'DD/MM/YYYY'), LANE_TYPE='{2}', NO_OF_SAMPLES={3}, " +
                    //        " LANE_AREA={4}, lane_length={5}, lane_width={6}, UDI_DATE=to_date('{7}', 'DD/MM/YYYY'), " +
                    //        " UDI_VALUE={8}, UDI_RATE='{9}', MUNIC_NAME='{10}', STREET_ID={11}, SECTION_ID={12} " +
                    //        " where LANE_ID={13} and SURVEY_NO={14} ",
                    //          sampleDr["SECTION_NO"].ToString(), sampleDr["MAX_SURVEY_DATE"].ToString(), drLane["LANE_TYPE"].ToString(), drLane["NO_OF_SAMPLES"].ToString(),
                    //          sampleDr["LANE_AREA"].ToString(), sampleDr["lane_Length"].ToString(), sampleDr["lane_Width"].ToString(), sampleDr["udidate"].ToString(),
                    //          udi.udiValue.ToString("N0"), udi.udiRate, drLane["MUNIC_NAME"].ToString(), mainStID, drLane["SECTION_ID"].ToString(),
                    //          drLane["LANE_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_LANES WHERE SECTION_NO='{0}' AND LANE_TYPE='{1}' AND SURVEY_NO={2} ", sectionNum, laneType, surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }

                    sql = string.Format("INSERT INTO UDI_laneS(RECORD_ID, SECTION_NO, SURVEY_DATE, LANE_TYPE, NO_OF_SAMPLES, LANE_AREA, lane_length, lane_width, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, MUNIC_NAME, LANE_ID, STREET_ID, SECTION_ID) " +
                        " VALUES(SEQ_UDI_LANE.nextval, '{0}', TO_DATE('{1}', 'DD/MM/YYYY'), '{2}', {3}, " +
                        " {4}, {5}, {6}, to_date('{7}', 'DD/MM/YYYY'), " +
                        " {8}, '{9}', {10}, '{11}', {12}, {13}, {14})",
                          sampleDr["SECTION_NO"].ToString(), sampleDr["MAX_SURVEY_DATE"].ToString(), drLane["LANE_TYPE"].ToString(), drLane["NO_OF_SAMPLES"].ToString(),
                          sampleDr["LANE_AREA"].ToString(), sampleDr["lane_Length"].ToString(), sampleDr["lane_Width"].ToString(), sampleDr["udidate"].ToString(),
                          udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, drLane["MUNIC_NAME"].ToString(), drLane["LANE_ID"].ToString(), mainStID, drLane["SECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                }
                #endregion

                #region Patching Distresses
                sectionNum = drLane["SECTION_NO"].ToString();
                laneType = drLane["LANE_TYPE"].ToString();

                sql = string.Format("SELECT SECTION_NO, LANE_TYPE, SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as udidate, ROUND(AVG(udi_value), 2) udivalue, SUM(SAMPLE_LENGTH*SAMPLE_WIDTH) AS LANE_AREA, " +
                    " sum(sample_length) as lane_Length, round(Avg(sample_Width), 2) as lane_Width FROM UDI_SECTION_SAMPLE_PATCHING " +
                    " WHERE SECTION_NO='{0}' AND LANE_TYPE='{1}' AND SURVEY_NO={2} GROUP BY SECTION_NO, LANE_TYPE, SURVEY_NO ",
                    sectionNum, laneType, surveyNo);

                Shared.LogStatment(sql);
                dtSampleRecord = db.ExecuteQuery(sql);
                if (dtSampleRecord.Rows.Count > 0)
                {
                    sampleDr = dtSampleRecord.Rows[0];
                    udi = UdiShared.GetUDIRatio(decimal.Parse(sampleDr["udivalue"].ToString()));
                    if (udi.udiValue == -1)
                        continue;

                    //sql = string.Format("SELECT SECTION_NO, LANE_TYPE, SURVEY_NO FROM UDI_LANES_PATCHING  WHERE SECTION_NO='{0}' AND LANE_TYPE='{1}' AND SURVEY_NO={2} ", sectionNum, laneType, surveyNo);
                    //Shared.LogStatment(sql);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_LANES_PATCHING set SECTION_NO='{0}', SURVEY_DATE=TO_DATE('{1}', 'DD/MM/YYYY'), LANE_TYPE='{2}', NO_OF_SAMPLES={3}, " +
                    //      " LANE_AREA={4}, lane_length={5}, lane_width={6}, UDI_DATE=to_date('{7}', 'DD/MM/YYYY'), " +
                    //      " UDI_VALUE={8}, UDI_RATE='{9}', MUNIC_NAME='{10}', STREET_ID={11}, SECTION_ID={12} " +
                    //      " where LANE_ID={13} and SURVEY_NO={14} ",
                    //        sampleDr["SECTION_NO"].ToString(), sampleDr["MAX_SURVEY_DATE"].ToString(), drLane["LANE_TYPE"].ToString(), drLane["NO_OF_SAMPLES"].ToString(),
                    //        sampleDr["LANE_AREA"].ToString(), sampleDr["lane_Length"].ToString(), sampleDr["lane_Width"].ToString(), sampleDr["udidate"].ToString(),
                    //        udi.udiValue.ToString("N0"), udi.udiRate, drLane["MUNIC_NAME"].ToString(), mainStID, drLane["SECTION_ID"].ToString(),
                    //        drLane["LANE_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_LANES_PATCHING WHERE SECTION_NO='{0}' AND LANE_TYPE='{1}' AND SURVEY_NO={2} ", sectionNum, laneType, surveyNo);
                    //        Shared.LogStatment(sql);
                    //        db.ExecuteNonQuery(sql);
                    //    }


                    sql = string.Format("INSERT INTO UDI_LANES_PATCHING(RECORD_ID, SECTION_NO, SURVEY_DATE, LANE_TYPE, NO_OF_SAMPLES, LANE_AREA, lane_length, lane_width, UDI_DATE, UDI_VALUE, UDI_RATE, SURVEY_NO, MUNIC_NAME, LANE_ID, STREET_ID, SECTION_ID) " +
                        " VALUES(SEQ_UDI_LANE.nextval, '{0}', TO_DATE('{1}', 'DD/MM/YYYY'), '{2}', {3}, " +
                        " {4}, {5}, {6}, to_date('{7}', 'DD/MM/YYYY'), " +
                        " {8}, '{9}', {10}, '{11}', {12}, {13}, {14})",
                          sampleDr["SECTION_NO"].ToString(), sampleDr["MAX_SURVEY_DATE"].ToString(), drLane["LANE_TYPE"].ToString(), drLane["NO_OF_SAMPLES"].ToString(),
                          sampleDr["LANE_AREA"].ToString(), sampleDr["lane_Length"].ToString(), sampleDr["lane_Width"].ToString(), sampleDr["udidate"].ToString(),
                          udi.udiValue.ToString("N0"), udi.udiRate, surveyNo, drLane["MUNIC_NAME"].ToString(), drLane["LANE_ID"].ToString(), mainStID, drLane["SECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                }
                #endregion
            }

            return rows;
        }

        public int CalculateSectionUDI(int mainStID, int surveyNo)
        {
            int rows = 0;
            DataRow drLane;
            DataTable dtSectionRecord; //, dtExists;

            string sql = string.Format("SELECT SECTION_ID, SECTION_NO, SURVEY_NO, sum(NO_OF_SAMPLES) as NO_OF_SAMPLES, MUNIC_NAME FROM udi_laneS " +
                " where STREET_ID={0} AND SURVEY_NO={1}    group by SECTION_ID, SECTION_NO, SURVEY_NO, MUNIC_NAME ", mainStID, surveyNo);

            Shared.LogStatment(sql); // MAIN_ST_ID
            DataTable dtSections = db.ExecuteQuery(sql);
            if (dtSections.Rows.Count == 0)
                return 0;

            foreach (DataRow drSection in dtSections.Rows)
            {
                udi = new UdiRecord();

                #region All Distresses
                sql = string.Format("SELECT SECTION_NO, SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as udidate, ROUND(AVG(udi_value), 2) udi_value, SUM(LANE_AREA) AS SECTION_AREA, " +
                    " COUNT(LANE_TYPE) AS NO_OF_LANE, max(lane_length) as section_length, sum(lane_width) as section_width FROM UDI_LANES " +
                    " WHERE SECTION_NO='{0}' AND SURVEY_NO={1} GROUP BY SECTION_NO, SURVEY_NO ",
                    drSection["SECTION_NO"].ToString(), surveyNo);

                Shared.LogStatment(sql);
                dtSectionRecord = db.ExecuteQuery(sql);
                if (dtSectionRecord.Rows.Count > 0)
                {
                    drLane = dtSectionRecord.Rows[0];
                    udi = UdiShared.GetUDIRatio(decimal.Parse(drLane["udi_value"].ToString()));
                    if (udi.udiValue == -1)
                        continue;

                    //sql = string.Format("SELECT SECTION_NO, SURVEY_NO FROM UDI_SECTION WHERE SECTION_NO='{0}' AND SURVEY_NO={1} ", drSection["SECTION_NO"].ToString(), surveyNo);
                    //Shared.LogStatment(sql);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_SECTION set SECTION_NO='{0}', SURVEY_DATE=TO_DATE('{1}','DD/MM/YYYY'), NO_OF_LANES={2}, NO_OF_SAMPLES={3}, " +
                    //        " SECTION_AREA={4}, section_length={5}, section_width={6}, UDI_VALUE={7}, " +
                    //        " UDI_DATE=to_date('{8}','DD/MM/YYYY'), UDI_RATE='{9}', MUNIC_NAME='{10}', STREET_ID={11}  where SECTION_ID={12} and SURVEY_NO={13} ",
                    //        drLane["SECTION_NO"].ToString(), drLane["MAX_SURVEY_DATE"].ToString(), drLane["NO_OF_LANE"].ToString(), drSection["NO_OF_SAMPLES"].ToString(),
                    //        drLane["SECTION_AREA"].ToString(), drLane["section_length"].ToString(), drLane["section_width"].ToString(), udi.udiValue.ToString("N0"),
                    //        drLane["udidate"].ToString(), udi.udiRate, drSection["MUNIC_NAME"].ToString(), mainStID, drSection["SECTION_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_SECTION WHERE SECTION_NO='{0}' AND SURVEY_NO={1} ", drSection["SECTION_NO"].ToString(), surveyNo);
                    //        db.ExecuteNonQuery(sql);
                    //        Shared.LogStatment(sql);
                    //    }

                    sql = string.Format("INSERT INTO UDI_SECTION(RECORD_ID, SECTION_NO, SURVEY_DATE, NO_OF_LANES, NO_OF_SAMPLES, SECTION_AREA, section_length, section_width, UDI_VALUE, UDI_DATE, UDI_RATE, SURVEY_NO, MUNIC_NAME, STREET_ID, SECTION_ID) " +
                        " VALUES(SEQ_UDI_SECTION.nextval, '{0}', TO_DATE('{1}','DD/MM/YYYY'), {2}, {3}, " +
                        " {4}, {5}, {6}, {7}, " +
                        " to_date('{8}','DD/MM/YYYY'), '{9}', {10}, '{11}', {12}, {13}) ",
                        drLane["SECTION_NO"].ToString(), drLane["MAX_SURVEY_DATE"].ToString(), drLane["NO_OF_LANE"].ToString(), drSection["NO_OF_SAMPLES"].ToString(),
                        drLane["SECTION_AREA"].ToString(), drLane["section_length"].ToString(), drLane["section_width"].ToString(), udi.udiValue.ToString("N0"),
                        drLane["udidate"].ToString(), udi.udiRate, surveyNo, drSection["MUNIC_NAME"].ToString(), mainStID, drSection["SECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                }
                #endregion

                #region Patching Distresses
                sql = string.Format("SELECT SECTION_NO, SURVEY_NO, to_char(MAX(SURVEY_DATE),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as MAX_SURVEY_DATE, " +
                    " to_char(MAX(udi_date),'DD/MM/YYYY','NLS_CALENDAR=''GREGORIAN''') as udidate, ROUND(AVG(udi_value), 2) udi_value, SUM(LANE_AREA) AS SECTION_AREA, " +
                    " COUNT(LANE_TYPE) AS NO_OF_LANE, max(lane_length) as section_length, sum(lane_width) as section_width " +
                    "  FROM UDI_LANES_PATCHING WHERE SECTION_NO='{0}' AND SURVEY_NO={1} GROUP BY SECTION_NO, SURVEY_NO ",
                    drSection["SECTION_NO"].ToString(), surveyNo);

                Shared.LogStatment(sql);
                dtSectionRecord = db.ExecuteQuery(sql);
                if (dtSectionRecord.Rows.Count > 0)
                {
                    drLane = dtSectionRecord.Rows[0];
                    udi = UdiShared.GetUDIRatio(decimal.Parse(drLane["udi_value"].ToString()));
                    if (udi.udiValue == -1)
                        continue;

                    //sql = string.Format("SELECT SECTION_NO, SURVEY_NO FROM UDI_SECTION_PATCHING WHERE SECTION_NO='{0}' AND SURVEY_NO={1} ", drSection["SECTION_NO"].ToString(), surveyNo);
                    //Shared.LogStatment(sql);
                    //dtExists = db.ExecuteQuery(sql);
                    //if (dtExists.Rows.Count == 1)
                    //{
                    //    sql = string.Format("update UDI_SECTION_PATCHING set SECTION_NO='{0}', SURVEY_DATE=TO_DATE('{1}','DD/MM/YYYY'), NO_OF_LANES={2}, NO_OF_SAMPLES={3}, " +
                    //        " SECTION_AREA={4}, section_length={5}, section_width={6}, UDI_VALUE={7}, " +
                    //        " UDI_DATE=to_date('{8}','DD/MM/YYYY'), UDI_RATE='{9}', MUNIC_NAME='{10}', STREET_ID={11} where SECTION_ID={12} and SURVEY_NO={13} ",
                    //        drLane["SECTION_NO"].ToString(), drLane["MAX_SURVEY_DATE"].ToString(), drLane["NO_OF_LANE"].ToString(), drSection["NO_OF_SAMPLES"].ToString(),
                    //        drLane["SECTION_AREA"].ToString(), drLane["section_length"].ToString(), drLane["section_width"].ToString(), udi.udiValue.ToString("N0"),
                    //        drLane["udidate"].ToString(), udi.udiRate, drSection["MUNIC_NAME"].ToString(), mainStID, drSection["SECTION_ID"].ToString(), surveyNo);

                    //    Shared.LogStatment(sql);
                    //    rows += db.ExecuteNonQuery(sql);
                    //}
                    //else
                    //{
                    //    if (dtExists.Rows.Count > 1)
                    //    {
                    //        sql = string.Format("DELETE FROM UDI_SECTION_PATCHING WHERE SECTION_NO='{0}' AND SURVEY_NO={1} ", drSection["SECTION_NO"].ToString(), surveyNo);
                    //        db.ExecuteNonQuery(sql);
                    //        Shared.LogStatment(sql);
                    //    }

                    sql = string.Format("INSERT INTO UDI_SECTION_PATCHING (RECORD_ID, SECTION_NO, SURVEY_DATE, NO_OF_LANES, NO_OF_SAMPLES, SECTION_AREA, section_length, section_width, UDI_VALUE, UDI_DATE, UDI_RATE, SURVEY_NO, MUNIC_NAME, STREET_ID, SECTION_ID) " +
                        " VALUES(SEQ_UDI_SECTION.nextval, '{0}', TO_DATE('{1}','DD/MM/YYYY'), {2}, {3}, " +
                        " {4}, {5}, {6}, {7}, " +
                        " to_date('{8}','DD/MM/YYYY'), '{9}', {10}, '{11}', {12}, {13}) ",
                        drLane["SECTION_NO"].ToString(), drLane["MAX_SURVEY_DATE"].ToString(), drLane["NO_OF_LANE"].ToString(), drSection["NO_OF_SAMPLES"].ToString(),
                        drLane["SECTION_AREA"].ToString(), drLane["section_length"].ToString(), drLane["section_width"].ToString(), udi.udiValue.ToString("N0"),
                        drLane["udidate"].ToString(), udi.udiRate, surveyNo, drSection["MUNIC_NAME"].ToString(), mainStID, drSection["SECTION_ID"].ToString());

                    Shared.LogStatment(sql);
                    rows += db.ExecuteNonQuery(sql);
                    //}
                }
                #endregion
            }

            return rows;
        }


        private void RemovePreviousCalculations(int mainStID, int surveyNo)
        {
            string sql = string.Format("delete from UDI_SECTION_SAMPLE where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_LANES where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_SECTION where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);


            sql = string.Format("delete from UDI_SECTION_SAMPLE_PATCHING where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_LANES_PATCHING where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from UDI_SECTION_PATCHING where STREET_ID={0} and SURVEY_NO={1} ", mainStID, surveyNo);
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);
        }


        private void TruncateUdiTables()
        {
            string sql = "truncate table UDI_SECTION_SAMPLE ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_LANES ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_SECTION ";
            db.ExecuteNonQuery(sql);


            sql = "truncate table UDI_SECTION_SAMPLE_PATCHING ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_LANES_PATCHING ";
            db.ExecuteNonQuery(sql);

            sql = "truncate table UDI_SECTION_PATCHING ";
            db.ExecuteNonQuery(sql);
        }

        #endregion



        #region Reporting


        //public DataTable GetSamplesUdiWithDistresses(int unitID, int surveyNo, bool sections, bool allDists)
        //{
        //    if (unitID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDists ? "VW_SAMPLES_UDI_DIST" : "VW_SAMPLES_UDI_p_DIST";
        //    string columnName = sections ? "SECTION_ID" : "STREET_ID"; //"MAIN_ST_ID";

        //    string sql = string.Format("SELECT * FROM {2} where {3}={0} and SURVEY_NO={1} order by section_no, lane_type, sample_no ", unitID, surveyNo, tableName, columnName);
        //    return ((string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql));
        //}

        //public DataTable GetSamplesUdiBySection(int sectionID, int surveyNo, bool allDists)
        //{
        //    if (sectionID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDists ? "SAM_SEC_UDI" : "SAM_SEC_UDI_patching";
        //    string sql = string.Format("SELECT * FROM {2} where SECTION_ID={0} and SURVEY_NO={1} order by lane_type, sample_no ", sectionID, surveyNo, tableName);
        //    return db.ExecuteQuery(sql);
        //}

        //public DataTable GetSamplesUdiByMainStreet(int mainStreetID, int surveyNo, bool allDists)
        //{
        //    if (mainStreetID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDists ? "MIDSAMSEC_UDI" : "MIDSAMSEC_UDI_patching"; // MAIN_ST_ID
        //    string sql = string.Format("SELECT * FROM {2} where STREET_ID={0} and SURVEY_NO={1} order by SEC_DIRECTION, sec_ORDER, section_no, lane_type ", mainStreetID, surveyNo, tableName);
        //    return db.ExecuteQuery(sql);
        //}

        //  public DataTable GetLanesUdiBySection(int sectionID, int surveyNo, bool allDists)
        //{
        //    if (sectionID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDists ? "MIDLANESEC_UDI" : "MIDLANESEC_UDI_patching";

        //    string sql = string.Format("SELECT * FROM {2}  where SECTION_ID={0} and SURVEY_NO={1}  order by lane_type ", sectionID, surveyNo, tableName);
        //    return db.ExecuteQuery(sql);
        //}

        //public DataTable GetLanesUdiByMainStreet(int mainStreetID, int surveyNo, bool allDists)
        //{
        //    if (mainStreetID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    string tableName = allDists ? "MIDLANESECUDI" : "MIDLANESECUDI_patching";
        //    string sql = string.Format("SELECT * FROM {2} where STREET_ID={0} and SURVEY_NO={1}  order by sec_ORDER, section_no, lane_type ", mainStreetID, surveyNo, tableName);
        //    return db.ExecuteQuery(sql);
        //}

        //public DataTable GetLanesUdiSurroundingRegion(int regionID, int surveyNo, bool allDists)
        //{
        //    if (regionID == 0 || surveyNo == 0)
        //        return new DataTable();

        //    DataTable dt = region.GetRegionInfo(regionID);
        //    if (dt.Rows.Count > 0)
        //    {
        //        string regionName = dt.Rows[0]["region_no"].ToString();
        //        string tableName = allDists ? "MIDLANESECUDI" : "MIDLANESECUDI_patching";

        //        string sql = string.Format("SELECT * FROM {2} where section_no like '{0}%' and SURVEY_NO={1}  order by sec_ORDER, section_no, lane_type ", regionName, surveyNo, tableName);
        //        return db.ExecuteQuery(sql);
        //    }
        //    else
        //        return new DataTable();
        //}

        public DataTable GetSectionsUdiByMainStreet(int mainStreetID, int surveyNo, bool allDists)
        {
            if (mainStreetID == 0)
                return new DataTable();

            string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and SURVEY_NO={0} ", surveyNo);
            string tableName = allDists ? "UDI_SECTIONS" : "UDI_SECTIONS_patching"; // MAIN_STREET_ID
            string sql = string.Format("SELECT * FROM {2} where STREET_ID={0} {1}  order by section_no ", mainStreetID, surveyNumPart, tableName);
            return db.ExecuteQuery(sql);
        }




        public DataTable GetSamplesUdiWithDistresses(int unitID, bool sections, bool allDists, string SURVEY_NO)
        {
            if (unitID == 0)
                return new DataTable();

            string tableName = allDists ? "VW_LATEST_UD_DIST_SEC_SAMPLES" : "VW_LATEST_UD_DIST_SEC_SAMPS_P";
            string patchDistPart = (!allDists) ? " and dist_code in (0, 12, 13, 14, 15) " : "";
            string columnName = sections ? "SECTION_ID" : "STREET_ID"; //"MAIN_ST_ID";
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where {1}={2}) ", tableName, columnName, unitID);  surveyPart,

            string sql = string.Format("SELECT * FROM {1} where {2}={0} {3} and SURVEY_NO='{4}' order by section_no, lane_type, sample_no ", unitID, tableName, columnName, patchDistPart,SURVEY_NO);
            return ((string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql));
        }

        public DataTable GetSamplesUdiBySection(int sectionID, bool allDists)
        {
            if (sectionID == 0)
                return new DataTable();

            string tableName = allDists ? "VW_LATEST_UDI_SEC_SAMPLES" : "VW_LATEST_UDI_SEC_SAMPLES_P";
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where SECTION_ID={1}) ", tableName, sectionID); surveyPart, 

            string sql = string.Format("SELECT * FROM {1} where SECTION_ID={0} order by lane_type, sample_no ", sectionID, tableName);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetSamplesUdiByMainStreet(int mainStreetID, bool allDists, string SURVEY_NO)
        {
            if (mainStreetID == 0)
                return new DataTable();

            string tableName = allDists ? "VW_LATEST_UDI_SEC_SAMPLES" : "VW_LATEST_UDI_SEC_SAMPLES_P";
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where STREET_ID={1}) ", tableName, mainStreetID);  surveyPart, 
            string sql = string.Format("SELECT * FROM {1} where STREET_ID={0} and SURVEY_NO='{2}' order by SEC_DIRECTION, sec_ORDER, section_no, lane_type ", mainStreetID, tableName,SURVEY_NO);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetLanesUdiBySection(int sectionID, bool allDists)
        {
            if (sectionID == 0)
                return new DataTable();

            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where STREET_ID={1}) ", tableName, sectionID); surveyPart,  and SURVEY_NO={1} 
            string tableName = allDists ? "VW_LATEST_UDI_LANES" : "VW_LATEST_UDI_LANES_P";
            string sql = string.Format("SELECT * FROM {1}  where SECTION_ID={0}  order by lane_type ", sectionID, tableName);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetLanesUdiByMainStreet(int mainStreetID, bool allDists)
        {
            if (mainStreetID == 0)
                return new DataTable();

            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where STREET_ID={1}) ", tableName, mainStreetID); surveyPart, 
            string tableName = allDists ? "VW_LATEST_UDI_LANES" : "VW_LATEST_UDI_LANES_P";
            string sql = string.Format("SELECT * FROM {1} where STREET_ID={0}  order by sec_ORDER, section_no, lane_type ", mainStreetID, tableName);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetLanesUdiSurroundingRegion(int regionID, bool allDists)
        {
            if (regionID == 0)
                return new DataTable();

            DataTable dt = region.GetRegionInfo(regionID);
            if (dt.Rows.Count > 0)
            {
                string regionName = dt.Rows[0]["region_no"].ToString();
                string tableName = allDists ? "VW_LATEST_UDI_LANES" : "VW_LATEST_UDI_LANES_P"; // and SURVEY_NO= surveyPart, 
                //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where section_no like '{1}%') ", tableName, regionName);

                string sql = string.Format("SELECT * FROM {1} where section_no like '{0}%'  order by arname, section_no, lane_type ", regionName, tableName);
                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }

        public DataTable GetSectionsUdiByMainStreet(int mainStreetID, bool allDists)
        {
            if (mainStreetID == 0)
                return new DataTable();

            //string surveyNumPart = (surveyNo == 0) ? "" : string.Format(" and SURVEY_NO={0} ", surveyNo);     surveyNumPart surveyPart, 
            string tableName = allDists ? "VW_LATEST_UDI_SECTIONS" : "VW_LATEST_UDI_SECTIONS_P"; // MAIN_STREET_ID
            //string surveyPart = string.Format("and SURVEY_NO=(select max(survey_no) from {0} where STREET_ID={1}) ", tableName, mainStreetID);

            string sql = string.Format("SELECT * FROM {1} where STREET_ID={0}  order by section_no ", mainStreetID, tableName);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetLaneSectionsUdiByMunic(bool byLane, bool bySection, string municNo, bool allDists)
        {
            if (municNo == "0" || string.IsNullOrEmpty(municNo))
                return new DataTable();

            if (byLane)
            {
                string tableName = allDists ? "VW_LATEST_UDI_LANES" : "VW_LATEST_UDI_LANES_P";
                string sql = string.Format("SELECT * FROM {1} where section_no like '{0}%'  order by sec_ORDER, section_no, lane_type ", municNo, tableName);
                return db.ExecuteQuery(sql);
            }
            else if (bySection)
            {
                string tableName = allDists ? "VW_LATEST_UDI_SECTIONS" : "VW_LATEST_UDI_SECTIONS_P";
                string sql = string.Format("SELECT * FROM {1} where section_no like '{0}%'  order by section_no ", municNo, tableName);
                return db.ExecuteQuery(sql);
            }
            else
                return new DataTable();
        }




        public DataTable GetAllMainStreetsPavementStatus()
        {
            string sql = "select * from VW_MAINST_PAVEMNT_STATUS order by main_no ";
            return db.ExecuteQuery(sql);
        }


        #endregion


    }
}
