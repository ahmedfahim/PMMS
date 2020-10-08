using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL
{
    public class BridgeTunnelEvaluation
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        #region Evalution

        public bool InsertElementEvaluation(int BRIDGE_ID, int TUNNEL_ID, int ELEMENT_ID, int EVAL_ID, string DETAILS)
        {
            if (BRIDGE_ID == 0 && TUNNEL_ID == 0)
                return false;

            string bridgeIDPart = (BRIDGE_ID == 0) ? "NULL" : BRIDGE_ID.ToString();
            string tunnelIDPart = (TUNNEL_ID == 0) ? "NULL" : TUNNEL_ID.ToString();
            string typeColumn = (BRIDGE_ID == 0) ? "TUNNEL_ID" : "BRIDGE_ID";
            string valueColumn = (BRIDGE_ID == 0) ? TUNNEL_ID.ToString() : BRIDGE_ID.ToString();

            DETAILS = string.IsNullOrEmpty(DETAILS) ? "NULL" : string.Format("'{0}'", DETAILS.Replace("'", "''"));

            string sql = string.Format("select * from BRIDGE_EVALUATION where {0}={1} and ELEMENT_ID={2} and EVAL_ID={3} ", typeColumn, valueColumn, ELEMENT_ID, EVAL_ID);
            DataTable dt = db.ExecuteQuery(sql);

            if (dt.Rows.Count == 0)
            {
                //                                                                 0        1           2           3       4
                sql = string.Format("insert into BRIDGE_EVALUATION(RECORD_ID, BRIDGE_ID, TUNNEL_ID, ELEMENT_ID, EVAL_ID, DETAILS) values(SEQ_EVALUATION.nextval, {0}, {1}, {2}, {3}, {4})",
                   bridgeIDPart, tunnelIDPart, ELEMENT_ID, EVAL_ID, DETAILS);

                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                throw new Exception(Feedback.InsertExceptionUnique());
        }

        public bool UpdateElementEvaluation(int RECORD_ID, int EVAL_ID, string DETAILS)
        {
            if (RECORD_ID == 0)
                return false;

            DETAILS = string.IsNullOrEmpty(DETAILS) ? "NULL" : string.Format("'{0}'", DETAILS.Replace("'", "''"));

            string sql = string.Format("update BRIDGE_EVALUATION set EVAL_ID={0}, DETAILS={2} where RECORD_ID={1} ", EVAL_ID, RECORD_ID, DETAILS);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool DeleteElementEvaluation(int RECORD_ID)
        {
            if (RECORD_ID == 0)
                return false;

            string sql = string.Format("delete from BRIDGE_EVALUATION where RECORD_ID={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable Search(int bridgeID, int tunnelID)
        {
            string sql = "";
            if (bridgeID == 0)
                sql = string.Format("SELECT RECORD_ID, BRIDGE_ID, TUNNEL_ID, ELEMENT_ID, EVAL_ID, CRITERIA_NAME, B_ELEMENT_NAME, CRITERIA_TITLE, DETAILS FROM VW_BRIDGE_TUNNEL_EVALUATIONS where  TUNNEL_ID={0} ", tunnelID);
            else
                sql = string.Format("SELECT RECORD_ID, BRIDGE_ID, TUNNEL_ID, ELEMENT_ID, EVAL_ID, CRITERIA_NAME, B_ELEMENT_NAME, CRITERIA_TITLE, DETAILS FROM VW_BRIDGE_TUNNEL_EVALUATIONS where  BRIDGE_ID={0} ", bridgeID);

            if (!string.IsNullOrEmpty(sql))
                return db.ExecuteQuery(sql);
            else
                return new DataTable();
        }

        #endregion


        #region Distresses

        public bool InsertEvalDistress(int BRIDGE_ID, int TUNNEL_ID, int BT_DISTRESS_TYPE_ID, int EVAL_RECORD_ID)
        {
            string bridgeIDPart = (BRIDGE_ID == 0) ? "NULL" : BRIDGE_ID.ToString();
            string tunnelIDPart = (TUNNEL_ID == 0) ? "NULL" : TUNNEL_ID.ToString();

            string typeColumn = (BRIDGE_ID == 0) ? "TUNNEL_ID" : "BRIDGE_ID";
            string valueColumn = (BRIDGE_ID == 0) ? TUNNEL_ID.ToString() : BRIDGE_ID.ToString();

            string sql = string.Format("select * from BRIDGE_DISTRESS where {0}={1} and BT_DISTRESS_TYPE_ID={2} and EVAL_RECORD_ID={3} ", typeColumn, valueColumn, BT_DISTRESS_TYPE_ID, EVAL_RECORD_ID);
            DataTable dt = db.ExecuteQuery(sql);

            if (dt.Rows.Count == 0)
            {
                sql = string.Format("INSERT INTO BRIDGE_DISTRESS (RECORD_ID, BRIDGE_ID, TUNNEL_ID, BT_DISTRESS_TYPE_ID, EVAL_RECORD_ID) VALUES (SEQ_EVALUATION.nextval, {0}, {1}, {2}, {3}) ",
                   bridgeIDPart, tunnelIDPart, BT_DISTRESS_TYPE_ID, EVAL_RECORD_ID);

                int rows = db.ExecuteNonQuery(sql);
                return (rows > 0);
            }
            else
                throw new Exception(Feedback.InsertExceptionUnique());
        }

        public bool DeleteEvalDistress(int RECORD_ID)
        {
            string sql = string.Format("DELETE FROM BRIDGE_DISTRESS WHERE RECORD_ID ={0} ", RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable  GetEvalDistress(int EVAL_RECORD_ID)
        {
            if (EVAL_RECORD_ID == 0)
                return new DataTable();

            string sql = string.Format("select * from vw_bridge_tunnel_eval_dist where EVAL_RECORD_ID={0} ", EVAL_RECORD_ID);
            return db.ExecuteQuery(sql);
        }

        #endregion

        public DataTable GetInfo(int bridgeID, int tunnelID)
        {
            if (bridgeID == 0 && tunnelID == 0)
                return new DataTable();

            string sql = "";
            if (bridgeID == 0)
                sql = string.Format("select 'نفق' as header, TUNNEL_NAME as name, bridge_location, nvl(SECTION_NO, INTER_NO) as loc_no, nvl(FROM_STREET, INTEREC_STREET1) as title1, nvl(TO_STREET, INTEREC_STREET2) as title2, MAIN_STREET_NAME from VW_TUNNEL_FULL_INFO where TUNNEL_ID={0} ", tunnelID);
            else
                sql = string.Format("select 'جسر' as header, BRIDGE_NAME as name, bridge_location, nvl(SECTION_NO, INTER_NO) as loc_no, nvl(FROM_STREET, INTEREC_STREET1) as title1, nvl(TO_STREET, INTEREC_STREET2) as title2, MAIN_STREET_NAME from VW_BRIDGE_FULL_INFO where BRIDGE_ID={0} ", bridgeID);

            return db.ExecuteQuery(sql);
        }


    }
}
