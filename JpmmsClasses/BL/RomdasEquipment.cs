using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JpmmsClasses.BL;
using Oracle.DataAccess.Client;
namespace JpmmsClasses.BL
{
    public class RomdasEquipment
    {
        private OracleConnection oracleConnection;

        
       
        public enum FilesCollections
        {
            NewFile,
            ExistsFileIdentical,
            ExistsFileDifferent
        }

        public enum TablesCollections
        {
            DT_EVENT_SECTION_NO,
            DT_EVENT_LANE_NO,
            DT_EVENT_LANE_WIDTH,
            DT_EVENT_DATE,
            DT_PROFILER_IRI,
            
            DT_EVENT_DEPRESSION_AREA,
            DT_EVENT_PATCHING_AREA,
            DT_EVENT_POLISHING_AREA,
            DT_EVENT_RAVELLING_AREA,
            DT_EVENT_RUTTING_AREA,
            DT_EVENT_SHOVING_AREA,

            DT_LCMS_CRACK_PROCESSED,
            DT_LCMS_POTHOLES_PROCESSED,
            DT_LCMS_BLEEDING_PROCESSED,

        }

        public RomdasEquipment()
        {
            oracleConnection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JPMMS_ConnectionString"].ToString());
        }
        public DataTable ValidateMainTables()
        {
            OracleDatabaseClass db = new OracleDatabaseClass();
            string sql = "select * from jpmms.DT_MAINTABES order by TableName";
//            string sql = @"select t.*,'dt_Event_LANE_WIDTH' TableName  from ( 
//select * from jpmms.DT_MAINTABES
//)t join jpmms.dt_Event_LANE_WIDTH  LW on 
//LW.SURVEY_ID=t.SURVEY_ID and LW.CHAINAGE_START=t.CHAINAGE_START 
//and LW.CHAINAGE_END=t.CHAINAGE_END and LW.FRAME_START=t.FRAME_START and LW.FRAME_END=t.FRAME_END
//UNION
//select t.*,'DT_EVENT_DATE' TableName  from (
//select * from jpmms.DT_MAINTABES
//)t join jpmms.DT_EVENT_DATE  LW on 
//LW.SURVEY_ID=t.SURVEY_ID and LW.CHAINAGE_START=t.CHAINAGE_START 
//and LW.CHAINAGE_END=t.CHAINAGE_END and LW.FRAME_START=t.FRAME_START and LW.FRAME_END=t.FRAME_END
//UNION
//select t.*,'DT_EVENT_LANE_NO' TableName  from ( 
//select * from jpmms.DT_MAINTABES
//)t join jpmms.DT_EVENT_LANE_NO  LW on 
//LW.SURVEY_ID=t.SURVEY_ID and LW.CHAINAGE_START=t.CHAINAGE_START 
//and LW.CHAINAGE_END=t.CHAINAGE_END and LW.FRAME_START=t.FRAME_START and LW.FRAME_END=t.FRAME_END
//UNION 
//select t.*,'DT_EVENT_SECTION_NO' TableName  from ( 
//select * from jpmms.DT_MAINTABES
//)t join jpmms.DT_EVENT_SECTION_NO  LW on 
//LW.SURVEY_ID=t.SURVEY_ID and LW.CHAINAGE_START=t.CHAINAGE_START 
//and LW.CHAINAGE_END=t.CHAINAGE_END and LW.FRAME_START=t.FRAME_START and LW.FRAME_END=t.FRAME_END order by TableName";

            return db.ExecuteQuery(sql);
        }
        public void RemovePreviousTables()
        {
            OracleDatabaseClass db = new OracleDatabaseClass();

            string sql = string.Format("delete from DT_EVENT_SECTION_NO");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_LANE_NO");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_LANE_WIDTH");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_DATE");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_PROFILER_IRI");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_LCMS_CRACK_PROCESSED");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_LCMS_BLEEDING_LEFT");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_LCMS_BLEEDING_RIGHT");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_LCMS_POTHOLES_PROCESSED");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_DEPRESSION_AREA");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_PATCHING_AREA");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_POLISHING_AREA");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_RAVELLING_AREA");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_RUTTING_AREA");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);

            sql = string.Format("delete from DT_EVENT_SHOVING_AREA");
            Shared.LogStatment(sql);
            db.ExecuteNonQuery(sql);


        }

        public bool InsertDT_PROFILER_IRI(List<DT_PROFILER_IRI> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {

                string query = @"insert into JPMMS.dt_Profiler_IRI (Survey_ID,CHAINAGE,LRP_OFFSET_START,LRP_OFFSET_END,LRP_NUMBER_START,LRP_NUMBER_END,SPEED,LWP_IRI,LWP_QUALITY,CWP_IRI,CWP_QUALITY,RWP_IRI,RWP_QUALITY,LANE_IRI,HRI,CH_START,CH_END,nID,CreateDate,Done_By) values 
								(:Survey_ID,:CHAINAGE,:LRP_OFFSET_START,:LRP_OFFSET_END,:LRP_NUMBER_START,:LRP_NUMBER_END,:SPEED,:LWP_IRI,:LWP_QUALITY,:CWP_IRI,:CWP_QUALITY,:RWP_IRI,:RWP_QUALITY,:LANE_IRI,:HRI,:CH_START,:CH_END,:nID,:CreateDate,:Done_By)";
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SPEED", OracleDbType.NVarchar2, bulkData.Select(c => c.SPEED).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LWP_IRI", OracleDbType.NVarchar2, bulkData.Select(c => c.LWP_IRI).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LWP_QUALITY", OracleDbType.NVarchar2, bulkData.Select(c => c.LWP_QUALITY).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CWP_IRI", OracleDbType.NVarchar2, bulkData.Select(c => c.CWP_IRI).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CWP_QUALITY", OracleDbType.NVarchar2, bulkData.Select(c => c.CWP_QUALITY).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":RWP_IRI", OracleDbType.NVarchar2, bulkData.Select(c => c.RWP_IRI).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":RWP_QUALITY", OracleDbType.NVarchar2, bulkData.Select(c => c.RWP_QUALITY).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LANE_IRI", OracleDbType.NVarchar2, bulkData.Select(c => c.LANE_IRI).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":HRI", OracleDbType.NVarchar2, bulkData.Select(c => c.HRI).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CH_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CH_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CH_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CH_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":nID", OracleDbType.NVarchar2, bulkData.Select(c => c.nID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_LCMS_BLEEDING_RIGHT(List<DT_LCMS_BLEEDING_RIGHT> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {

                string query = @"insert into JPMMS.DT_LCMS_BLEEDING_RIGHT (SURVEY_ID,CHAINAGE,LRP_NUMBER,LRP_CHAINAGE,BI_RIGHT,SEVERITY_RIGHT,IMAGE_FILE_INDEX,CH_START,CH_END,NID,CreateDate,Done_By) values 
								(:SURVEY_ID,:CHAINAGE,:LRP_NUMBER,:LRP_CHAINAGE,:BI_RIGHT,:SEVERITY_RIGHT,:IMAGE_FILE_INDEX,:CH_START,:CH_END,:NID,:CreateDate,:Done_By)";
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":SURVEY_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.SURVEY_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":BI_RIGHT", OracleDbType.NVarchar2, bulkData.Select(c => c.BI_RIGHT).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SEVERITY_RIGHT", OracleDbType.NVarchar2, bulkData.Select(c => c.SEVERITY_RIGHT).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":IMAGE_FILE_INDEX", OracleDbType.NVarchar2, bulkData.Select(c => c.IMAGE_FILE_INDEX).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CH_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CH_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CH_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CH_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":NID", OracleDbType.NVarchar2, bulkData.Select(c => c.NID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_LCMS_BLEEDING_LEFT(List<DT_LCMS_BLEEDING_LEFT> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {

                string query = @"insert into JPMMS.DT_LCMS_BLEEDING_LEFT (SURVEY_ID,CHAINAGE,LRP_NUMBER,LRP_CHAINAGE,BI_LEFT,SEVERITY_LEFT,IMAGE_FILE_INDEX,CH_START,CH_END,NID,CreateDate,Done_By) values 
								(:SURVEY_ID,:CHAINAGE,:LRP_NUMBER,:LRP_CHAINAGE,:BI_LEFT,:SEVERITY_LEFT,:IMAGE_FILE_INDEX,:CH_START,:CH_END,:NID,:CreateDate,:Done_By)";
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":SURVEY_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.SURVEY_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":BI_LEFT", OracleDbType.NVarchar2, bulkData.Select(c => c.BI_LEFT).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SEVERITY_LEFT", OracleDbType.NVarchar2, bulkData.Select(c => c.SEVERITY_LEFT).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":IMAGE_FILE_INDEX", OracleDbType.NVarchar2, bulkData.Select(c => c.IMAGE_FILE_INDEX).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CH_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CH_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CH_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CH_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":NID", OracleDbType.NVarchar2, bulkData.Select(c => c.NID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_LCMS_POTHOLES_PROCESSED(List<DT_LCMS_POTHOLES_PROCESSED> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {

                string query = @"insert into JPMMS.DT_LCMS_POTHOLES_PROCESSED (SURVEY_ID,CHAINAGE,LRP_NUMBER,LRP_CHAINAGE,AREA,MAX_DEPTH,AVE_DEPTH,SEVERITY,IMAGE_FILE_INDEX,CreateDate,Done_By) values 
								(:SURVEY_ID,:CHAINAGE,:LRP_NUMBER,:LRP_CHAINAGE,:AREA,:MAX_DEPTH,:AVE_DEPTH,:SEVERITY,:IMAGE_FILE_INDEX,:CreateDate,:Done_By)";
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":SURVEY_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.SURVEY_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":MAX_DEPTH", OracleDbType.NVarchar2, bulkData.Select(c => c.MAX_DEPTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":AVE_DEPTH", OracleDbType.NVarchar2, bulkData.Select(c => c.AVE_DEPTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SEVERITY", OracleDbType.NVarchar2, bulkData.Select(c => c.SEVERITY).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":IMAGE_FILE_INDEX", OracleDbType.NVarchar2, bulkData.Select(c => c.IMAGE_FILE_INDEX).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_LCMS_CRACK_PROCESSED(List<DT_LCMS_CRACK_PROCESSED> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {

                string query = @"insert into JPMMS.DT_LCMS_CRACK_PROCESSED (SURVEY_ID,CHAINAGE,LRP_NUMBER,LRP_CHAINAGE,CRACK_ID,LENGTH,WIDTH,DEPTH,AREA,CLASSIFICATION,SEVERITY,IMAGE_FILE_INDEX,CreateDate,Done_By) values 
								(:SURVEY_ID,:CHAINAGE,:LRP_NUMBER,:LRP_CHAINAGE,:CRACK_ID,:LENGTH,:WIDTH,:DEPTH,:AREA,:CLASSIFICATION,:SEVERITY,:IMAGE_FILE_INDEX,:CreateDate,:Done_By)";
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":SURVEY_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.SURVEY_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_CHAINAGE", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_CHAINAGE).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CRACK_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.CRACK_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":WIDTH", OracleDbType.NVarchar2, bulkData.Select(c => c.WIDTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":DEPTH", OracleDbType.NVarchar2, bulkData.Select(c => c.DEPTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CLASSIFICATION", OracleDbType.NVarchar2, bulkData.Select(c => c.CLASSIFICATION).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SEVERITY", OracleDbType.NVarchar2, bulkData.Select(c => c.SEVERITY).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":IMAGE_FILE_INDEX", OracleDbType.NVarchar2, bulkData.Select(c => c.IMAGE_FILE_INDEX).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_DATE(List<DT_EVENT_DATE> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_DATE (SURVEY_ID,DATE1,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END,CreateDate,Done_By) values 
								(:SURVEY_ID,:DATE1,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END,:CreateDate,:Done_By)";
                
                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":DATE1", OracleDbType.NVarchar2, bulkData.Select(c => c.DATE1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_LANE_WIDTH(List<DT_EVENT_LANE_WIDTH> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_LANE_WIDTH (SURVEY_ID,LANE_WIDTH,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END,CreateDate,Done_By) values 
								(:SURVEY_ID,:LANE_WIDTH,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END,:CreateDate,:Done_By)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LANE_WIDTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LANE_WIDTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_LANE_NO(List<DT_EVENT_LANE_NO> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_LANE_NO (SURVEY_ID,LANE_NO,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END,CreateDate,Done_By) values 
								(:SURVEY_ID,:LANE_NO,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END,:CreateDate,:Done_By)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LANE_NO", OracleDbType.NVarchar2, bulkData.Select(c => c.LANE_NO).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_SECTION_NO(List<DT_EVENT_SECTION_NO> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_SECTION_NO (SURVEY_ID,SECTION_NO,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END,CreateDate,Done_By) values 
								(:SURVEY_ID,:SECTION_NO,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END,:CreateDate,:Done_By)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SECTION_NO", OracleDbType.NVarchar2, bulkData.Select(c => c.SECTION_NO).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CreateDate", OracleDbType.NVarchar2, bulkData.Select(c => c.CreateDate).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Done_By", OracleDbType.NVarchar2, bulkData.Select(c => c.Done_By).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_DEPRESSION_AREA(List<DT_EVENT_DEPRESSION_AREA> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_DEPRESSION_AREA (SURVEY_ID,DEPRESSION_AREA,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END) values 
								(:SURVEY_ID,:DEPRESSION_AREA,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":DEPRESSION_AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.DEPRESSION_AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_PATCHING_AREA(List<DT_EVENT_PATCHING_AREA> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_PATCHING_AREA (SURVEY_ID,PATCHING_AREA,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END) values 
								(:SURVEY_ID,:PATCHING_AREA,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PATCHING_AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.PATCHING_AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_POLISHING_AREA(List<DT_EVENT_POLISHING_AREA> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_POLISHING_AREA (SURVEY_ID,POLISHING_AREA,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END) values 
								(:SURVEY_ID,:POLISHING_AREA,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":POLISHING_AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.POLISHING_AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_RAVELLING_AREA(List<DT_EVENT_RAVELLING_AREA> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_RAVELLING_AREA (SURVEY_ID,RAVELLING_AREA,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END) values 
								(:SURVEY_ID,:RAVELLING_AREA,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":RAVELLING_AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.RAVELLING_AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_RUTTING_AREA(List<DT_EVENT_RUTTING_AREA> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_RUTTING_AREA (SURVEY_ID,RUTTING_AREA,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END) values 
								(:SURVEY_ID,:RUTTING_AREA,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":RUTTING_AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.RUTTING_AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }

        public bool InsertDT_EVENT_SHOVING_AREA(List<DT_EVENT_SHOVING_AREA> bulkData)
        {
             if (bulkData == null || bulkData.Count ==0  ) return false; bool returnValue = false;
            try
            {
                string query = @"insert into JPMMS.DT_EVENT_SHOVING_AREA (SURVEY_ID,SHOVING_AREA,CHAINAGE_START,CHAINAGE_END,LENGTH,LRP_NUMBER_START,LRP_OFFSET_START,LRP_NUMBER_END,LRP_OFFSET_END,FRAME_START,FRAME_END,COMMENT1,COMMENT_1,COMMENT_2,COMMENT_3,COMMENT_4,PHOTO_SET,X,Y,Z,X_END,Y_END,Z_END) values 
								(:SURVEY_ID,:SHOVING_AREA,:CHAINAGE_START,:CHAINAGE_END,:LENGTH,:LRP_NUMBER_START,:LRP_OFFSET_START,:LRP_NUMBER_END,:LRP_OFFSET_END,:FRAME_START,:FRAME_END,:COMMENT1,:COMMENT_1,:COMMENT_2,:COMMENT_3,:COMMENT_4,:PHOTO_SET,:X,:Y,:Z,:X_END,:Y_END,:Z_END)";

                oracleConnection.Open();
                using (var command = oracleConnection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.BindByName = true;
                    command.ArrayBindCount = bulkData.Count;
                    command.Parameters.Add(":Survey_ID", OracleDbType.NVarchar2, bulkData.Select(c => c.Survey_ID).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":SHOVING_AREA", OracleDbType.NVarchar2, bulkData.Select(c => c.SHOVING_AREA).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_START", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":CHAINAGE_END", OracleDbType.NVarchar2, bulkData.Select(c => c.CHAINAGE_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LENGTH", OracleDbType.NVarchar2, bulkData.Select(c => c.LENGTH).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_START", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_NUMBER_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_NUMBER_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":LRP_OFFSET_END", OracleDbType.NVarchar2, bulkData.Select(c => c.LRP_OFFSET_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_START", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_START).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":FRAME_END", OracleDbType.NVarchar2, bulkData.Select(c => c.FRAME_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_1", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_1).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_2", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_2).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_3", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_3).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":COMMENT_4", OracleDbType.NVarchar2, bulkData.Select(c => c.COMMENT_4).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":PHOTO_SET", OracleDbType.NVarchar2, bulkData.Select(c => c.PHOTO_SET).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X", OracleDbType.NVarchar2, bulkData.Select(c => c.X).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y", OracleDbType.NVarchar2, bulkData.Select(c => c.Y).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z", OracleDbType.NVarchar2, bulkData.Select(c => c.Z).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":X_END", OracleDbType.NVarchar2, bulkData.Select(c => c.X_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Y_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Y_END).ToArray(), ParameterDirection.Input);
                    command.Parameters.Add(":Z_END", OracleDbType.NVarchar2, bulkData.Select(c => c.Z_END).ToArray(), ParameterDirection.Input);
                    int result = command.ExecuteNonQuery();
                    if (result == bulkData.Count)
                        returnValue = true;
                }

            }
            catch (OracleException ex)
            {
                //Log error thrown
            }
            finally
            {
                oracleConnection.Close();
            }
            return returnValue;
        }
    }

}
