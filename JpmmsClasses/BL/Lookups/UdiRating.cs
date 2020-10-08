using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL.Lookups
{
    public class UdiRating
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public DataTable GetAll()
        {
            string sql = "select RATING_ID, U_RATING, MIN, MAX from UDI_RATINGS order by min ";
            return db.ExecuteQuery(sql);
        }

        public bool Update(double MIN, double MAX, int RATING_ID)
        {
            if (RATING_ID == 0)
                return false;

            string sql = string.Format("update UDI_RATINGS set MIN={0}, MAX={1} where RATING_ID={2} ", MIN, MAX, RATING_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

    }
}
