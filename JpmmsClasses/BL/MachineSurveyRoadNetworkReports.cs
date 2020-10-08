using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL
{
    public class MachineSurveyRoadNetworkReports
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();
        private MainStreet mainStreet = new MainStreet();


        public DataTable GetSurveyedAreas(MachineSurveyType type)
        {
            string sql = "";
            switch (type)
            {
                case MachineSurveyType.FWD:
                    return mainStreet.LoadMainStreetHavingFWD();

                case MachineSurveyType.IRI_Sections:
                    return mainStreet.LoadMainStreetsHavingCalculatedIri(true);

                case MachineSurveyType.IRI_Intersects:
                    return mainStreet.LoadMainStreetsHavingCalculatedIri(false);

                case MachineSurveyType.GPR_Sections:
                    return mainStreet.LoadMainStreetsHavingGPR(false);

                case MachineSurveyType.GPR_Intersects:
                    return mainStreet.LoadMainStreetsHavingGPR(true);

                case MachineSurveyType.SKID_Sections:
                    sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (select distinct main_no from SKID_DATA where section_no is not null) and street_type=1 ORDER BY ARNAME ";
                    break;

                case MachineSurveyType.SKID_Intersects:
                    sql = "SELECT MAIN_NO, STREET_ID, (ARNAME) as main_title, ARNAME, ARNAME as main_name FROM STREETS WHERE MAIN_NO IN (select distinct main_no from SKID_DATA where INTERSECTION_no is not null) and street_type=1 ORDER BY ARNAME ";
                    break;

                case MachineSurveyType.Rutting_Sections:
                    return mainStreet.LoadMainStreetsHavingCalculatedRutting(false);

                case MachineSurveyType.Rutting_Intersects:
                    return mainStreet.LoadMainStreetsHavingCalculatedRutting(true);

                case MachineSurveyType.SectionTrafficCounting:
                    sql = "select * from VW_MAINST_MAX_TRAFFIC order by arname "; // main_no
                    break;

                case MachineSurveyType.None:
                default:
                    break;
            }

            return (!string.IsNullOrEmpty(sql) ? db.ExecuteQuery(sql) : new DataTable());
        }


    }
}
