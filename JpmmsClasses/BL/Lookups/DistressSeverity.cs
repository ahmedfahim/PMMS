using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL.Lookups
{
    public class DistressSeverity
    {

        public DataTable GetDistressSeverities(int distCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("dist_sever", typeof(string)));

            if (distCode <= 0)
                dt.Rows.Add("N");
            else if (distCode == 4) // || distCode == 10
            {
                dt.Rows.Add("N");
                dt.Rows.Add("L");
            }
            else
            {
                dt.Rows.Add("N");
                dt.Rows.Add("L");
                dt.Rows.Add("M");
                dt.Rows.Add("H");
            }

            return dt;
        }


    }
}
