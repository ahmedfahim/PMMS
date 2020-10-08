using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace SepOct2009
{
  class Program
  {
    static void Main(string[] args)
    {
      // connection string - make sure to adjust for your environment
      string constr = "User Id=hr;" +
                      "Password=hr;" +
                      "Data Source=oramag;" +
                      "enlist=false;" +
                      "pooling=false";

      // create and open connection object
      OracleConnection con = new OracleConnection(constr);
      con.Open();

      // create and populate array for job_id column
      string[] job_id_vals = new string[3] { "IT_DBA",
                                             "IT_MAN",
                                             "IT_VP" };

      // create and populate array for job_title column
      string[] job_title_vals = new string[3] { "Database Administrator",
                                                "IT Manager",
                                                "IT Vice President" };

      // create and populate array for min_salary column
      int[] min_salary_vals = new int[3] { 8000, 12000, 18000 };

      // create and populate array for max_salary column
      int[] max_salary_vals = new int[3] { 16000, 24000, 35000 };

      // create parameter for job_id column
      OracleParameter p_job_id = new OracleParameter();
      p_job_id.OracleDbType = OracleDbType.Varchar2;
      p_job_id.Value = job_id_vals;

      // create parameter for job_title column
      OracleParameter p_job_title = new OracleParameter();
      p_job_title.OracleDbType = OracleDbType.Varchar2;
      p_job_title.Value = job_title_vals;

      // create parameter for min_salary column
      OracleParameter p_min_salary = new OracleParameter();
      p_min_salary.OracleDbType = OracleDbType.Int32;
      p_min_salary.Value = min_salary_vals;

      // create parameter for max_salary column
      OracleParameter p_max_salary = new OracleParameter();
      p_max_salary.OracleDbType = OracleDbType.Int32;
      p_max_salary.Value = max_salary_vals;

      // create command and set properties
      OracleCommand cmd = con.CreateCommand();
      
      // the sql text used to insert the rows in the arrays
      // this necessarily uses bind variables
      cmd.CommandText =  "insert into jobs (job_id, " +
                         "job_title, " +
                         "min_salary, " +
                         "max_salary) " +
                         "values (:1, :2, :3, :4)";

      // must set the number of elements in the arrays
      // all three arrays are the same size
      cmd.ArrayBindCount = job_id_vals.Length;

      // add parameters to collection
      cmd.Parameters.Add(p_job_id);
      cmd.Parameters.Add(p_job_title);
      cmd.Parameters.Add(p_min_salary);
      cmd.Parameters.Add(p_max_salary);

      // perform the array insert in a single call
      cmd.ExecuteNonQuery();

      // display the new jobs
      cmd.CommandText = "select job_id, job_title, " + 
                        "min_salary, max_salary " +
                        "from jobs " + 
                        "where job_id in " +
                        "('IT_DBA', 'IT_MAN', 'IT_VP') " + 
                        "order by job_id";

      OracleDataReader dr = cmd.ExecuteReader();

      Console.WriteLine("\nNew jobs have been added to the JOBS table:\n");

      // write the jobs to the console using currency format
      while (dr.Read())
      {
        Console.WriteLine("{0,6}: {1} ({2:C0} - {3:C0})",
          dr.GetString(0), dr.GetString(1),
          dr.GetInt32(2), dr.GetInt32(3));
      }

      Console.WriteLine();

      // delete the new jobs using an array
      cmd.CommandText = "delete from jobs " + 
                        "where job_id = :1";

      // clear parameters from existing collection
      cmd.Parameters.Clear();

      // add the job_id array parameter
      // other properties do not need to be adjusted
      // since they are still correct
      cmd.Parameters.Add(p_job_id);

      // execute the delete for each job_id
      cmd.ExecuteNonQuery();

      Console.WriteLine("New jobs have been removed from the JOBS table.");

      // clean up objects
      p_max_salary.Dispose();
      p_min_salary.Dispose();
      p_job_title.Dispose();
      p_job_id.Dispose();
      cmd.Dispose();
      con.Dispose();

      // keep console window from closing when executing from IDE
      Console.Write("\nPress ENTER to continue...");
      Console.ReadLine();
    }
  }
}
