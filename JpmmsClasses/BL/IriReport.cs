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
    public class IriReport
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();




        public DataTable GetMainStreetIriSurveys(string mainNo, bool isIntersection, bool allRoads, bool allIntersects)
        {
            if (!(allRoads || allIntersects) && (string.IsNullOrEmpty(mainNo) || mainNo == "0"))
                return new DataTable();

            string sql = "";
            if (isIntersection)
                sql = string.Format("SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM iri_INTERSECTION WHERE MAIN_NO ='{0}' GROUP BY SURVEY_NO order by SURVEY_DATE desc ", mainNo);
            else if (allRoads)
                //sql = "SELECT SURVEY_NO, max(SURVEY_DATE), (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM iri_LANE  GROUP BY SURVEY_NO ";
                sql = "select distinct survey_no, survey_no as survey_title from iri_lane order by SURVEY_no desc "; //survey_no ";
            else if (allIntersects)
                sql = "select distinct survey_no, survey_no as survey_title from iri_INTERSECTION order by SURVEY_no desc "; //survey_no ";
            else
                sql = string.Format("SELECT SURVEY_NO, max(SURVEY_DATE) as SURVEY_DATE, (SURVEY_NO || ' - ' || to_char(max(SURVEY_DATE), 'dd/mm/yyyy')) as survey_title FROM iri_LANE WHERE MAIN_NO ='{0}' GROUP BY SURVEY_NO order by SURVEY_DATE desc ", mainNo);

            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }

        public DataTable IriReportForMainStreet(string mainNo, int surveyNo, bool isIntersection, bool allRoads, bool allIntersects)
        {
            if (!(allRoads || allIntersects) && (string.IsNullOrEmpty(mainNo) || mainNo == "0" || surveyNo == 0))
                return new DataTable();
            else if (allRoads && surveyNo == 0)
                return new DataTable();

            string sql = "";
            if (isIntersection)
                sql = string.Format("SELECT * FROM IRI_INTERSECTION where MAIN_NO='{0}' AND SURVEY_NO={1}   ORDER BY  INTERSECTION_NO, LANE ", mainNo, surveyNo);
            //sql = string.Format("SELECT b.intersection_no, b.inter_no, b.MAIN_NO, b.mAIN_name, a.INTEREC_street1, a.INTEREC_street2, a.INTERSECTION_ORDER, MAX(b.survey_date) survey_date, b.DIRECTION, b.LANE, b.survey_no, AVG(b.l_iri)  l_iri FROM INTERSECTIONS a, IRI b,INTERSECTION_LENGTH c WHERE b.inter_no = a.inter_no AND b.intersection_no =c.intersection_no and b.MAIN_NO='{0}' AND b.SURVEY_NO={1} GROUP BY b.MAIN_NO, b.intersection_no, b.inter_no, b.mAIN_name, a.INTEREC_street1, a.INTEREC_street2, a.INTERSECTION_ORDER, b.SURVEY_date, B.DIRECTION, b.LANE, b.survey_no, c.LENGTH ORDER BY b.main_no,a.INTERSECTION_ORDER ", mainNo, surveyNo);
            // SEC_DIRECTION, INTERSECTION_ORDER
            else if (allRoads)
                //sql = string.Format("SELECT * FROM IRI_LANE where SURVEY_NO={0} ORDER BY main_no, SEC_ORDER, SECTION_NO, LANE ", surveyNo);
                sql = string.Format("SELECT * FROM IRI_LANE where SURVEY_NO={0}     ORDER BY main_no, SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", surveyNo);
            else if (allIntersects)
                // MAIN_NO='{0}' AND  mainNo,  INTERSECTION_ORDER
                sql = string.Format("SELECT * FROM IRI_INTERSECTION where SURVEY_NO={0}     ORDER BY  main_no, INTERSECTION_NO, LANE ", surveyNo);
            else
                sql = string.Format("SELECT * FROM IRI_LANE where MAIN_No='{0}' AND SURVEY_NO={1} ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", mainNo, surveyNo);


            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }




        public DataTable IriReportForMainStreet(string mainNo, bool isIntersection, bool allRoads, bool allIntersects, string SURVEYNO)
        {
            if (!(allRoads || allIntersects) && (string.IsNullOrEmpty(mainNo) || mainNo == "0"))
                return new DataTable();

            string sql = "";
            // IRI_INTERSECTION             IRI_LANE  
            if (isIntersection)
                sql = string.Format("SELECT * FROM VW_LATEST_IRI_INTERSECT where MAIN_NO='{0}'  and SURVEY_NO='{1}'  ORDER BY  INTERSECTION_NO, LANE ", mainNo, SURVEYNO);
            else if (allRoads)
                sql = string.Format("SELECT * FROM VW_LATEST_IRI  where SURVEY_NO='{0}'  ORDER BY arname, SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", SURVEYNO); // main_no  INTERSECTION_ORDER, 
            else if (allIntersects)
                sql = string.Format("SELECT * FROM VW_LATEST_IRI_INTERSECT where SURVEY_NO='{0}'    ORDER BY  main_no, INTERSECTION_NO, LANE ", SURVEYNO);
            else
                sql = string.Format("SELECT * FROM VW_LATEST_IRI where MAIN_No='{0}' and SURVEY_NO='{1}'   ORDER BY SEC_DIRECTION, SEC_ORDER, SECTION_NO, LANE ", mainNo, SURVEYNO);

            return (string.IsNullOrEmpty(sql)) ? new DataTable() : db.ExecuteQuery(sql);
        }

    }
}
