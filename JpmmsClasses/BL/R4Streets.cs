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
    public class R4Streets
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public bool Insert(string r4No, string r4Name, DateTime? r4Date, DateTime? openingDate, DateTime? surveyDate, DateTime? sectionsDefiningDate, int contractorID,
            bool houses, bool warehouses, bool commerial, bool gardens, bool indisterial, bool rest_house, bool publics, bool drinage_cb_true, string drinage_cb_count,
            bool drinage_mh_true, string drinage_mh_count, bool sewage_mh_true, string sewage_mh_count, bool Elect_mh_true, string Elect_mh_count, bool stc_mh_true,
            string stc_mh_count, bool water_valve_true, string water_valve_count, bool notPavedByMunic, string NotPavedDetails, bool OwnedByMunic, string OwnedDetails,
            char populationDensity, string topographyDetails, bool needMidIsland, bool needTrees, bool needLighting, bool needInfraWorks, bool needTrafficSigns,
            bool needServiceLanes, bool needSpeedBumps, string neededLanesCount, bool innerWaterHas, string soilType, string moreDetails, int lightingContractorID,
            DateTime? lightingFinishDate, string lightingContractName, string lightingContractNo, int treesContractorID, DateTime? treesFinishDate, string treesContractName,
            string treesContractNo, int pavingContractorID, DateTime? pavingFinishDate, string pavingContractName, string pavingContractNo, string r4_length, int mainStID)
        {
            int rows = 0;
            int newID = 0;

            string r4_lengthPart = string.IsNullOrEmpty(r4_length) ? "NULL" : decimal.Parse(r4_length).ToString("N2");
            string r4DatePart = (r4Date == null) ? "NULL" : string.Format("'{0}'", ((DateTime)r4Date).ToString("dd/MM/yyyy"));
            string openingDatePart = (openingDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)openingDate).ToString("dd/MM/yyyy"));
            string surveyDatePart = (surveyDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)surveyDate).ToString("dd/MM/yyyy"));
            string sectionsDefiningDatePart = (sectionsDefiningDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)sectionsDefiningDate).ToString("dd/MM/yyyy"));
            string neededLanesPart = string.IsNullOrEmpty(neededLanesCount) ? "NULL" : int.Parse(neededLanesCount).ToString();

            string drinageCbCount = (drinage_cb_true || !string.IsNullOrEmpty(drinage_cb_count)) ? drinage_cb_count : "NULL";
            string drinageMhCount = (drinage_mh_true || !string.IsNullOrEmpty(drinage_mh_count)) ? drinage_mh_count : "NULL";
            string sewageMhCount = (sewage_mh_true || !string.IsNullOrEmpty(sewage_mh_count)) ? sewage_mh_count : "NULL";
            string ElectMhCount = (Elect_mh_true || !string.IsNullOrEmpty(Elect_mh_count)) ? Elect_mh_count : "NULL";
            string stcMhCount = (stc_mh_true || !string.IsNullOrEmpty(stc_mh_count)) ? stc_mh_count : "NULL";
            string waterValveCount = (water_valve_true || !string.IsNullOrEmpty(water_valve_count)) ? water_valve_count : "NULL";

            r4No = string.IsNullOrEmpty(r4No) ? "NULL" : string.Format("'{0}'", r4No.Replace("'", "''"));
            r4Name = string.IsNullOrEmpty(r4Name) ? "NULL" : string.Format("'{0}'", r4Name.Replace("'", "''"));
            NotPavedDetails = string.IsNullOrEmpty(NotPavedDetails) ? "NULL" : string.Format("'{0}'", NotPavedDetails.Replace("'", "''"));
            OwnedDetails = string.IsNullOrEmpty(OwnedDetails) ? "NULL" : string.Format("'{0}'", OwnedDetails.Replace("'", "''"));
            topographyDetails = string.IsNullOrEmpty(topographyDetails) ? "NULL" : string.Format("'{0}'", topographyDetails.Replace("'", "''"));
            moreDetails = string.IsNullOrEmpty(moreDetails) ? "NULL" : string.Format("'{0}'", moreDetails.Replace("'", "''"));
            soilType = string.IsNullOrEmpty(soilType) ? "NULL" : string.Format("'{0}'", soilType.Replace("'", "''"));

            //                                                              0       1       2           3           4           5                       6
            string sql = string.Format("insert into R4_STREETS(R4_ST_ID, R4_NO, R4_NAME, R4_DATE, OPENING_DATE, SURVEY_DATE, SECTIONS_DEFINING_DATE, CONTRACTOR_ID, " +
                //      7           8               9               10              11          12              13              14              15              16
                "DRAIN_CB_TRUE, DRAIN_CB_COUNT, DRAIN_MH_TRUE, DRAIN_MH_COUNT, ELEC_MH_TRUE, ELEC_MH_COUNT, WATER_MH_TRUE, WATER_MH_COUNT, SEWAGE_MH_TRUE, SEWAGE_MH_COUNT, " +
                //      17          18              19                  20                  21              22          23        24       25           26          27      
                "STC_MH_TRUE, STC_MH_COUNT, NOT_PAVED_BY_MUNIC, NOT_PAVED_BY_DETAILS, OWNED_BY_MUNIC, OWNED_DETAILS, HOUSING, WAREHOUSES, COMMERCIAL, GARDENS, INDUSTRIAL, " +
                //      28      29          30          31                  32              33          34              35                  36                  37
                "REST_HOUSES, PUBLICS, POPULATION, TOPOGRAPHY_DETAILS, NEED_MID_ISLAND, NEED_TREES, NEED_LIGHTING, NEED_INFRA_WORKS, NEED_TRAFFIC_SIGNS, NEEDED_LANES_COUNT, " +
                //          38          39                  40          41                  42          43          44
                "NEED_SERVICE_LANES, NEED_SPEED_BUMPS, INNER_WATER, SOIL_TYPE_DETAILS, R4_LENGTH, MORE_DETAILS, STREET_ID) " + // MAIN_ST_ID
                " values(SEQ_R4_STREETS.nextval, {0}, {1}, {2}, {3}, {4}, {5}, {6}, " +
                " '{7}', {8}, '{9}', {10}, '{11}', {12}, '{13}', {14}, '{15}', {16}, " +
                " '{17}', {18}, '{19}', {20}, '{21}', {22}, '{23}', '{24}', '{25}', '{26}', '{27}', " +
                " '{28}', '{29}', '{30}', {31}, '{32}', '{33}', " +
                " '{34}', '{35}', '{36}', {37}, '{38}', '{39}', '{40}', {41}, {42}, {43}, {44}) ",
                r4No, r4Name, r4DatePart, openingDatePart, surveyDatePart, sectionsDefiningDatePart, contractorID,
                 Shared.Bool2YN(drinage_cb_true), drinageCbCount, Shared.Bool2YN(drinage_mh_true), drinageMhCount, Shared.Bool2YN(Elect_mh_true), ElectMhCount,
                 Shared.Bool2YN(water_valve_true), waterValveCount, Shared.Bool2YN(sewage_mh_true), sewageMhCount,
                 Shared.Bool2YN(stc_mh_true), stcMhCount, Shared.Bool2YN(notPavedByMunic), NotPavedDetails, Shared.Bool2YN(OwnedByMunic), OwnedDetails, Shared.Bool2YN(houses),
                 Shared.Bool2YN(warehouses), Shared.Bool2YN(commerial), Shared.Bool2YN(gardens), Shared.Bool2YN(indisterial),
                 Shared.Bool2YN(rest_house), Shared.Bool2YN(publics), populationDensity, topographyDetails, Shared.Bool2YN(needMidIsland), Shared.Bool2YN(needTrees),
                 Shared.Bool2YN(needLighting), Shared.Bool2YN(needInfraWorks), Shared.Bool2YN(needTrafficSigns), neededLanesPart,
                 Shared.Bool2YN(needServiceLanes), Shared.Bool2YN(needSpeedBumps), Shared.Bool2YN(innerWaterHas), soilType, r4_lengthPart, moreDetails, mainStID);

            newID = db.ExecuteInsertWithIDReturn(sql, "R4_STREETS");
            if (newID != 0)
            {
                string lightingFinishDatePart = (lightingFinishDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)lightingFinishDate).ToString("dd/MM/yyyy"));
                lightingContractNo = string.IsNullOrEmpty(lightingContractNo) ? "NULL" : string.Format("'{0}'", lightingContractNo.Replace("'", "''"));
                lightingContractName = string.IsNullOrEmpty(lightingContractName) ? "NULL" : string.Format("'{0}'", lightingContractName.Replace("'", "''"));

                //                                               0        0         1               2           3           4
                sql = string.Format("insert into R4_LIGHTING(RECORD_ID, R4_ID, CONTRACTOR_ID, FINISH_DATE, CONTRACT_NAME, CONTRACT_NO) " +
                    " values({0}, {0}, {1}, {2}, {3}, {4})", newID, lightingContractorID, lightingFinishDatePart, lightingContractName, lightingContractNo);
                rows += db.ExecuteNonQuery(sql);


                string treesFinishDatePart = (treesFinishDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)treesFinishDate).ToString("dd/MM/yyyy"));
                treesContractNo = string.IsNullOrEmpty(treesContractNo) ? "NULL" : string.Format("'{0}'", treesContractNo.Replace("'", "''"));
                treesContractName = string.IsNullOrEmpty(treesContractName) ? "NULL" : string.Format("'{0}'", treesContractName.Replace("'", "''"));

                sql = string.Format("insert into R4_PAVING(RECORD_ID, R4_ID, CONTRACTOR_ID, FINISH_DATE, CONTRACT_NAME, CONTRACT_NO) " +
                    " values({0}, {0}, {1}, {2}, {3}, {4})", newID, treesContractorID, treesFinishDatePart, treesContractName, treesContractNo);
                rows += db.ExecuteNonQuery(sql);


                string pavingFinishDatePart = (pavingFinishDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)pavingFinishDate).ToString("dd/MM/yyyy"));
                pavingContractNo = string.IsNullOrEmpty(pavingContractNo) ? "NULL" : string.Format("'{0}'", pavingContractNo.Replace("'", "''"));
                pavingContractName = string.IsNullOrEmpty(pavingContractName) ? "NULL" : string.Format("'{0}'", pavingContractName.Replace("'", "''"));

                sql = string.Format("insert into R4_TREES(RECORD_ID, R4_ID, CONTRACTOR_ID, FINISH_DATE, CONTRACT_NAME, CONTRACT_NO) " +
                    " values({0}, {0}, {1}, {2}, {3}, {4})", newID, pavingContractorID, pavingFinishDatePart, pavingContractName, pavingContractNo);
                rows += db.ExecuteNonQuery(sql);

                return (rows > 0);
            }
            else
                return false;
        }


        public bool Update(string r4No, string r4Name, DateTime? r4Date, DateTime? openingDate, DateTime? surveyDate, DateTime? sectionsDefiningDate, int contractorID,
            bool houses, bool warehouses, bool commerial, bool gardens, bool indisterial, bool rest_house, bool publics, bool drinage_cb_true, string drinage_cb_count,
            bool drinage_mh_true, string drinage_mh_count, bool sewage_mh_true, string sewage_mh_count, bool Elect_mh_true, string Elect_mh_count, bool stc_mh_true,
            string stc_mh_count, bool water_valve_true, string water_mh_count, bool notPavedByMunic, string NotPavedDetails, bool OwnedByMunic, string OwnedDetails,
            char popDens, string topographyDetails, bool needMidIsland, bool needTrees, bool needLighting, bool needInfraWorks, bool needTrafficSigns, bool needServiceLanes,
            bool needSpeedBumps, string neededLanesCount, bool innerWaterHas, string soilType, string moreDetails, int lightingContractorID, DateTime? lightingFinishDate,
            string lightingContractName, string lightingContractNo, int treesContractorID, DateTime? treesFinishDate, string treesContractName, string treesContractNo,
            int pavingContractorID, DateTime? pavingFinishDate, string pavingContractName, string pavingContractNo, string r4_length, int r4ID, int mainStID)
        {
            int rows = 0;

            string r4_lengthPart = string.IsNullOrEmpty(r4_length) ? "NULL" : decimal.Parse(r4_length).ToString("N2");
            string r4DatePart = (r4Date == null) ? "NULL" : string.Format("'{0}'", ((DateTime)r4Date).ToString("dd/MM/yyyy"));
            string openingDatePart = (openingDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)openingDate).ToString("dd/MM/yyyy"));
            string surveyDatePart = (surveyDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)surveyDate).ToString("dd/MM/yyyy"));
            string sectionsDefiningDatePart = (sectionsDefiningDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)sectionsDefiningDate).ToString("dd/MM/yyyy"));
            string neededLanesPart = string.IsNullOrEmpty(neededLanesCount) ? "NULL" : int.Parse(neededLanesCount).ToString();

            string drinageCbCount = (drinage_cb_true || !string.IsNullOrEmpty(drinage_cb_count)) ? drinage_cb_count : "NULL";
            string drinageMhCount = (drinage_mh_true || !string.IsNullOrEmpty(drinage_mh_count)) ? drinage_mh_count : "NULL";
            string sewageMhCount = (sewage_mh_true || !string.IsNullOrEmpty(sewage_mh_count)) ? sewage_mh_count : "NULL";
            string ElectMhCount = (Elect_mh_true || !string.IsNullOrEmpty(Elect_mh_count)) ? Elect_mh_count : "NULL";
            string stcMhCount = (stc_mh_true || !string.IsNullOrEmpty(stc_mh_count)) ? stc_mh_count : "NULL";
            string waterValveCount = (water_valve_true || !string.IsNullOrEmpty(water_mh_count)) ? water_mh_count : "NULL";

            r4No = string.IsNullOrEmpty(r4No) ? "NULL" : string.Format("'{0}'", r4No.Replace("'", "''"));
            r4Name = string.IsNullOrEmpty(r4Name) ? "NULL" : string.Format("'{0}'", r4Name.Replace("'", "''"));
            NotPavedDetails = string.IsNullOrEmpty(NotPavedDetails) ? "NULL" : string.Format("'{0}'", NotPavedDetails.Replace("'", "''"));
            OwnedDetails = string.IsNullOrEmpty(OwnedDetails) ? "NULL" : string.Format("'{0}'", OwnedDetails.Replace("'", "''"));
            topographyDetails = string.IsNullOrEmpty(topographyDetails) ? "NULL" : string.Format("'{0}'", topographyDetails.Replace("'", "''"));
            moreDetails = string.IsNullOrEmpty(moreDetails) ? "NULL" : string.Format("'{0}'", moreDetails.Replace("'", "''"));
            soilType = string.IsNullOrEmpty(soilType) ? "NULL" : string.Format("'{0}'", soilType.Replace("'", "''"));

            string sql = string.Format("update R4_STREETS set R4_NO={0}, R4_NAME={1}, R4_DATE={2}, OPENING_DATE={3}, SURVEY_DATE={4}, SECTIONS_DEFINING_DATE={5}, CONTRACTOR_ID={6}, " +
                "DRAIN_CB_TRUE='{7}', DRAIN_CB_COUNT={8}, DRAIN_MH_TRUE='{9}', DRAIN_MH_COUNT={10}, ELEC_MH_TRUE='{11}', ELEC_MH_COUNT={12}, WATER_MH_TRUE='{13}', " +
                "WATER_MH_COUNT={14}, SEWAGE_MH_TRUE='{15}', SEWAGE_MH_COUNT={16}, STC_MH_TRUE='{17}', STC_MH_COUNT={18}, NOT_PAVED_BY_MUNIC='{19}', NOT_PAVED_BY_DETAILS={20},  " +
                "OWNED_BY_MUNIC='{21}', OWNED_DETAILS={22}, HOUSING='{23}', WAREHOUSES={24}, COMMERCIAL={25}, GARDENS={26}, INDUSTRIAL={27}, " +
                "REST_HOUSES='{28}', PUBLICS='{29}', POPULATION='{30}', TOPOGRAPHY_DETAILS={31}, NEED_MID_ISLAND='{32}', NEED_TREES='{33}', NEED_LIGHTING='{34}', " +
                "NEED_INFRA_WORKS='{35}', NEED_TRAFFIC_SIGNS='{36}', NEEDED_LANES_COUNT={37}, NEED_SERVICE_LANES='{38}', NEED_SPEED_BUMPS='{39}', INNER_WATER='{40}' " +
                ", SOIL_TYPE_DETAILS='{41}', R4_LENGTH={42}, MORE_DETAILS='{43}', STREET_ID={45} where R4_ST_ID={44}  ", // MAIN_ST_ID
                r4No, r4Name, r4DatePart, openingDate, surveyDate, sectionsDefiningDate, contractorID, Shared.Bool2YN(drinage_cb_true), drinageCbCount,
                Shared.Bool2YN(drinage_mh_true), drinageMhCount, Shared.Bool2YN(Elect_mh_true), ElectMhCount, Shared.Bool2YN(water_valve_true), waterValveCount,
                Shared.Bool2YN(sewage_mh_true), sewageMhCount, Shared.Bool2YN(stc_mh_true), stcMhCount, Shared.Bool2YN(notPavedByMunic), NotPavedDetails,
                Shared.Bool2YN(OwnedByMunic), OwnedDetails, Shared.Bool2YN(houses), Shared.Bool2YN(warehouses), Shared.Bool2YN(commerial), Shared.Bool2YN(gardens),
                Shared.Bool2YN(indisterial), Shared.Bool2YN(rest_house), Shared.Bool2YN(publics), popDens, topographyDetails, Shared.Bool2YN(needMidIsland),
                Shared.Bool2YN(needLighting), Shared.Bool2YN(needInfraWorks), Shared.Bool2YN(needTrafficSigns), neededLanesCount, Shared.Bool2YN(needServiceLanes),
                Shared.Bool2YN(needSpeedBumps), Shared.Bool2YN(innerWaterHas), r4_length, moreDetails, r4ID, mainStID);

            rows = db.ExecuteNonQuery(sql);


            string lightingFinishDatePart = (lightingFinishDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)lightingFinishDate).ToString("dd/MM/yyyy"));
            lightingContractNo = string.IsNullOrEmpty(lightingContractNo) ? "NULL" : string.Format("'{0}'", lightingContractNo.Replace("'", "''"));
            lightingContractName = string.IsNullOrEmpty(lightingContractName) ? "NULL" : string.Format("'{0}'", lightingContractName.Replace("'", "''"));

            sql = string.Format("update R4_LIGHTING set CONTRACTOR_ID={0}, FINISH_DATE={1}, CONTRACT_NAME={2}, CONTRACT_NO={3} where RECORD_ID={4} ",
                lightingContractorID, lightingFinishDatePart, lightingContractName, lightingContractNo, r4ID);
            rows += db.ExecuteNonQuery(sql);


            string treesFinishDatePart = (treesFinishDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)treesFinishDate).ToString("dd/MM/yyyy"));
            treesContractNo = string.IsNullOrEmpty(treesContractNo) ? "NULL" : string.Format("'{0}'", treesContractNo.Replace("'", "''"));
            treesContractName = string.IsNullOrEmpty(treesContractName) ? "NULL" : string.Format("'{0}'", treesContractName.Replace("'", "''"));

            sql = string.Format("update R4_PAVING set CONTRACTOR_ID={0}, FINISH_DATE={1}, CONTRACT_NAME={2}, CONTRACT_NO={3} where RECORD_ID={4} ",
                treesContractorID, treesFinishDatePart, treesContractName, treesContractNo, r4ID);
            rows += db.ExecuteNonQuery(sql);


            string pavingFinishDatePart = (pavingFinishDate == null) ? "NULL" : string.Format("'{0}'", ((DateTime)pavingFinishDate).ToString("dd/MM/yyyy"));
            pavingContractNo = string.IsNullOrEmpty(pavingContractNo) ? "NULL" : string.Format("'{0}'", pavingContractNo.Replace("'", "''"));
            pavingContractName = string.IsNullOrEmpty(pavingContractName) ? "NULL" : string.Format("'{0}'", pavingContractName.Replace("'", "''"));

            sql = string.Format("update R4_TREES set CONTRACTOR_ID={0}, FINISH_DATE={1}, CONTRACT_NAME={2}, CONTRACT_NO={3} where RECORD_ID={4} ",
                 pavingFinishDatePart, pavingContractorID, pavingContractName, pavingContractNo, r4ID);
            rows += db.ExecuteNonQuery(sql);

            return (rows > 0);
        }



        public bool Delete(int R4_ST_ID)
        {
            int rows = 0;
            string sql = string.Format("delete from R4_STREETS where R4_ST_ID={0} ", R4_ST_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from R4_LIGHTING where R4_ID={0} ", R4_ST_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from R4_PAVING where R4_ID={0} ", R4_ST_ID);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("delete from R4_TREES where R4_ID={0} ", R4_ST_ID);
            rows += db.ExecuteNonQuery(sql);

            return (rows > 0);
        }

        public DataTable GetR4StreetsList()
        {
            string sql = "SELECT R4_ST_ID, R4_DATE, R4_NO, R4_NAME FROM R4_STREETS ORDER BY R4_NAME ";
            return db.ExecuteQuery(sql);
        }


        public DataTable GetR4StreetByID(int R4_ST_ID)
        {
            if (R4_ST_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from VW_R4_STREETS_FULL_INFO where R4_ST_ID={0} ", R4_ST_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetR4LightingInfo(int R4_ST_ID)
        {
            if (R4_ST_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from R4_LIGHTING where R4_ID={0} ", R4_ST_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetR4TreesInfo(int R4_ST_ID)
        {
            if (R4_ST_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from R4_TREES where R4_ID={0} ", R4_ST_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetR4PavingInfo(int R4_ST_ID)
        {
            if (R4_ST_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from R4_PAVING where R4_ID={0} ", R4_ST_ID);
            return db.ExecuteQuery(sql);
        }

        public DataTable GetR4StreetTestList(int R4ID)
        {
            if (R4ID == 0)
                return new DataTable();

            string sql = String.Format("SELECT R4ID, R4_STREETS_TESTS.TESTID, ISPASS, FILENAME,TestName FROM R4_STREETS_TESTS INNER JOIN TestTypes " +
                " ON TestTypes.TestID=R4_STREETS_TESTS.TestID  where R4ID={0} ", R4ID);

            return db.ExecuteQuery(sql);
        }

        public DataTable GetR4StreetTest(int R4ID, int TestID)
        {
            if (R4ID == 0 || TestID == 0)
                return new DataTable();

            string sql = String.Format("SELECT R4ID, TESTID, ISPASS, FILENAME FROM R4_STREETS_TESTS where R4ID={0} AND TESTID={1}  ", R4ID, TestID);
            return db.ExecuteQuery(sql);
        }

        public bool InsertNewTest(int R4ID, int TestID, string FileName, int IsPass)
        {
            FileName = (string.IsNullOrEmpty(FileName)) ? "NULL" : string.Format("'{0}'", FileName);

            int rows = 0;
            string sql = string.Format("INSERT INTO R4_STREETS_TESTS (R4ID, TESTID, ISPASS, FILENAME) VALUES ({0}, {1}, {2}, {3})", R4ID, TestID, IsPass, FileName);
            rows += db.ExecuteNonQuery(sql);

            return (rows > 0);
        }

        public bool UpdateTest(int R4ID, int TestID, string FileName, int IsPass)
        {
            int rows = 0;
            string sql = string.Format(@"UPDATE R4_STREETS_TESTS SET TESTID={0}, ISPASS={1}, FILENAME={2} WHERE  R4ID={3} AND TESTID ={4}", TestID, IsPass, FileName, R4ID, TestID);
            rows += db.ExecuteNonQuery(sql);
            // :TESTID
            return (rows > 0);
        }

        public bool DeleteTest(int R4ID, int TestID)
        {
            int rows = 0;
            string sql = string.Format("delete from R4_STREETS_TESTS  WHERE  R4ID={0} AND TESTID={1} ", R4ID, TestID);
            rows += db.ExecuteNonQuery(sql);

            return (rows > 0);
        }

        public DataTable GetR4StreetTestTypes()
        {
            string sql = "SELECT TESTID, TestName FROM TestTypes";
            return db.ExecuteQuery(sql);
        }

    }
}
