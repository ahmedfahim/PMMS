using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL.Lookups
{
    public class MaintDeciding
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public bool Insert(int DIST_CODE, char DIST_SEVER, int low_dens_maint_dec, int med_dens_maint_dec, int high_dens_maint_dec)
        {
            int rows = 0;
            string sql = string.Format("select * from MAINT_DECIDING where DIST_CODE={0} and DIST_SEVER='{1}'  ", DIST_CODE, DIST_SEVER);
            if (db.ExecuteQuery(sql).Rows.Count > 0)
                throw new Exception(Feedback.InsertExceptionUnique());

            //                                                             0           1           2           3           4
            sql = string.Format("insert into MAINT_DECIDING(RECORD_ID, DIST_CODE, DIST_SEVER, DENSITY_FROM, DENSITY_TO, MAINT_DEC_ID) " +
                " values(SEQ_MAINT_DECIDING.nextval, {0}, '{1}', {2}, {3}, {4})", DIST_CODE, DIST_SEVER, 0, 10, low_dens_maint_dec);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("insert into MAINT_DECIDING(RECORD_ID, DIST_CODE, DIST_SEVER, DENSITY_FROM, DENSITY_TO, MAINT_DEC_ID) " +
                " values(SEQ_MAINT_DECIDING.nextval, {0}, '{1}', {2}, {3}, {4})", DIST_CODE, DIST_SEVER, 11, 50, med_dens_maint_dec);
            rows += db.ExecuteNonQuery(sql);

            sql = string.Format("insert into MAINT_DECIDING(RECORD_ID, DIST_CODE, DIST_SEVER, DENSITY_FROM, DENSITY_TO, MAINT_DEC_ID) " +
                " values(SEQ_MAINT_DECIDING.nextval, {0}, '{1}', {2}, {3}, {4})", DIST_CODE, DIST_SEVER, 51, 100, high_dens_maint_dec);
            rows += db.ExecuteNonQuery(sql);

            return (rows > 0);
        }

        public bool UpdateDecision(int RECORD_ID, int MAINT_DEC_ID)
        {
            string sql = string.Format("update MAINT_DECIDING set MAINT_DEC_ID={0} where RECORD_ID={1}  ", MAINT_DEC_ID, RECORD_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }


        public MaintDecision GetMaintDecision(int DIST_CODE, char DIST_SEVER, double density, double distArea)
        {
            if (DIST_CODE == 0)
                return new MaintDecision(1, 0, 0);


            string sql = string.Format("select MAINT_DEC_ID, THICKNESS from MAINT_DECIDING, MAINT_DECISIONS where DIST_CODE={0} and DIST_SEVER='{1}' and (DENSITY_FROM-1)<={2} and DENSITY_TO>={2} and MAINT_DEC_ID=RECOMMENDED_DECISION_ID ",
                 DIST_CODE, DIST_SEVER, density.ToString("N2"));

            DataTable dt = db.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
                return new MaintDecision();

            int id = int.Parse(dt.Rows[0]["MAINT_DEC_ID"].ToString());
            //int thickness = int.Parse(dt.Rows[0]["THICKNESS"].ToString());
            distArea = (id == 1) ? 0 : distArea;

            return new MaintDecision(id, int.Parse(dt.Rows[0]["THICKNESS"].ToString()), distArea);
        }

        public DataTable GetAll()
        {
            string sql = "SELECT RECORD_ID,  (m.DIST_CODE ||'- ' || d.DISTRESS_AR_TYPE) as distress_title, m.DIST_CODE, d.DISTRESS_AR_TYPE, DIST_SEVER, DENSITY_FROM, DENSITY_TO, MAINT_DEC_ID, RECOMMENDED_DECISION FROM MAINT_DECIDING m, DISTRESS_CODE d, MAINT_DECISIONS md where m.dist_code=d.dist_code and m.MAINT_DEC_ID=md.RECOMMENDED_DECISION_ID ORDER BY DIST_CODE, DIST_SEVER, DENSITY_FROM ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetAllMaintDeciding()
        {
            string sql = "select * from VW_MAINT_DECIDING order by DIST_CODE, DENSITY_FROM ";
            return db.ExecuteQuery(sql);
        }


    }
}
