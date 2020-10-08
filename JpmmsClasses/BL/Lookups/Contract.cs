using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JpmmsClasses.BL.Lookups
{
    public class Contract
    {
        private OracleDatabaseClass db = new OracleDatabaseClass();



        public bool Insert(string CONTRACT_NO, string CONTRACT_NAME, DateTime? START_DATE, DateTime? END_DATE, DateTime? CONTRACT_DATE, int CONTRACTOR_ID)
        {
            CONTRACT_NAME = CONTRACT_NAME.Replace("'", "''");
            CONTRACT_NO = CONTRACT_NO.Replace("'", "''");
            string contractBeginPart = (START_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)START_DATE).ToString("dd/MM/yyyy"));
            string contractEndPart = (END_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)END_DATE).ToString("dd/MM/yyyy"));
            string contractDatePart = (CONTRACT_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_DATE).ToString("dd/MM/yyyy"));

            string sql = string.Format("insert into CONTRACT(CONTRACT_ID, CONTRACT_NO, CONTRACT_NAME, START_DATE, END_DATE, CONTRACT_DATE, CONTRACTOR_ID) values(SEQ_CONTRACTS.nextval, '{0}', '{1}', {2}, {3}, {4}, {5}) ",
                CONTRACT_NO, CONTRACT_NAME, contractBeginPart, contractEndPart, contractDatePart, CONTRACTOR_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Update(string CONTRACT_NO, string CONTRACT_NAME, DateTime? START_DATE, DateTime? END_DATE, DateTime? CONTRACT_DATE, int CONTRACTOR_ID, int CONTRACT_ID)
        {
            CONTRACT_NAME = CONTRACT_NAME.Replace("'", "''");
            CONTRACT_NO = CONTRACT_NO.Replace("'", "''");
            string contractBeginPart = (START_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)START_DATE).ToString("dd/MM/yyyy"));
            string contractEndPart = (END_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)END_DATE).ToString("dd/MM/yyyy"));
            string contractDatePart = (CONTRACT_DATE == null) ? "NULL" : string.Format("'{0}'", ((DateTime)CONTRACT_DATE).ToString("dd/MM/yyyy"));

            string sql = string.Format("update CONTRACT set CONTRACT_NO='{1}', CONTRACT_NAME='{2}', START_DATE={3}, END_DATE={4}, CONTRACT_DATE={5}, CONTRACTOR_ID={6} where CONTRACT_ID={0} ",
                CONTRACT_ID, CONTRACT_NO, CONTRACT_NAME, contractBeginPart, contractEndPart, contractDatePart, CONTRACTOR_ID);

            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public bool Delete(int CONTRACT_ID)
        {
            if (CONTRACT_ID == 0)
                return false;

            string sql = string.Format("delete from CONTRACT where CONTRACT_ID={0} ", CONTRACT_ID);
            int rows = db.ExecuteNonQuery(sql);
            return (rows > 0);
        }

        public DataTable GetAll()
        {
            string sql = "select CONTRACT_ID, CONTRACT_NO, CONTRACT_NAME, START_DATE, END_DATE, CONTRACT_DATE, CONTRACTOR_ID, CONTRACTOR_NAME, ('('||CONTRACT_NO || ')-(' ||CONTRACT_NAME || ')-('|| CONTRACTOR_NAME||')') as contract_title from VW_CONTRACTS_FULL_INFO order by CONTRACT_NO ";
            return db.ExecuteQuery(sql);
        }

        public DataTable GetByID(int CONTRACT_ID)
        {
            if (CONTRACT_ID == 0)
                return new DataTable();

            string sql = string.Format("select CONTRACT_ID, CONTRACT_NO, CONTRACT_NAME, START_DATE, END_DATE, CONTRACTOR_ID, CONTRACTOR_NAME, ('('||CONTRACT_NO || ')-(' ||CONTRACT_NAME || ')-('|| CONTRACTOR_NAME||')') as contract_title from VW_CONTRACTS_FULL_INFO where CONTRACT_ID={0}  ", CONTRACT_ID);
            return db.ExecuteQuery(sql);
        }

    }
}
