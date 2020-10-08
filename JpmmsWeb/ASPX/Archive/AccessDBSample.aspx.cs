using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;

using Oracle.DataAccess.Client;
using JpmmsClasses.BL;
using System.IO;
using System.Reflection;

public partial class ASPX_Archive_AccessDBSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            GetUploadFiles();
    }
        //bulkDataIRI = (from DataRow dr in data.Rows
        //               select new DT_PROFILER_IRI()
        //               {
        //                   Survey_ID = dr[0].ToString(),
        //                   CHAINAGE = dr[1].ToString(),
        //                   LRP_OFFSET_START = dr[2].ToString(),
        //                   LRP_OFFSET_END = dr[3].ToString(),
        //                   LRP_NUMBER_START = dr[4].ToString(),
        //                   LRP_NUMBER_END = dr[5].ToString(),
        //                   SPEED = dr[6].ToString(),
        //                   LWP_IRI = dr[7].ToString(),
        //                   LWP_QUALITY = dr[8].ToString(),
        //                   CWP_IRI = dr[9].ToString(),
        //                   CWP_QUALITY = dr[10].ToString(),
        //                   RWP_IRI = dr[11].ToString(),
        //                   RWP_QUALITY = dr[12].ToString(),
        //                   LANE_IRI = dr[13].ToString(),
        //                   HRI = dr[14].ToString(),
        //                   CH_START = dr[15].ToString(),
        //                   CH_END = dr[16].ToString(),
        //                   nID = dr[17].ToString(),
        //                   CreateDate = DateTime.Now.ToString(),
        //                   Done_By = "40"
        //               }).ToList();

    public void LoopToUploadBulkData(DataTable[] Tablesdata, DataTable AccessDetials)
    {
        DataTable DataBaseTables = new DataTable();
        DataBaseTables.Columns.Add("TableName");
        DataBaseTables.Columns.Add("TableRows");

        var watch = System.Diagnostics.Stopwatch.StartNew();
        RomdasEquipment RomdasObject = new RomdasEquipment();
        RomdasObject.RemovePreviousTables();

        DataTable data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_PROFILER_IRI".ToLower());
        List<DT_PROFILER_IRI> bulkDataIRI = new List<DT_PROFILER_IRI>();

        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataIRI.Add(new DT_PROFILER_IRI()
                       {
                           Survey_ID = data.Rows[i][0].ToString(),
                           CHAINAGE = data.Rows[i][1].ToString(),
                           LRP_OFFSET_START = data.Rows[i][2].ToString(),
                           LRP_OFFSET_END = data.Rows[i][3].ToString(),
                           LRP_NUMBER_START = data.Rows[i][4].ToString(),
                           LRP_NUMBER_END = data.Rows[i][5].ToString(),
                           SPEED = data.Rows[i][6].ToString(),
                           LWP_IRI = data.Rows[i][7].ToString(),
                           LWP_QUALITY = data.Rows[i][8].ToString(),
                           CWP_IRI = data.Rows[i][9].ToString(),
                           CWP_QUALITY = data.Rows[i][10].ToString(),
                           RWP_IRI = data.Rows[i][11].ToString(),
                           RWP_QUALITY = data.Rows[i][12].ToString(),
                           LANE_IRI = data.Rows[i][13].ToString(),
                           HRI = data.Rows[i][14].ToString(),
                           CH_START = data.Rows[i][15].ToString(),
                           CH_END = data.Rows[i][16].ToString(),
                           nID = data.Rows[i][17].ToString(),
                           CreateDate = DateTime.Now.ToString(),
                           Done_By = "40"
                       });
        }

        RomdasObject.InsertDT_PROFILER_IRI(bulkDataIRI);
        DataBaseTables.Rows.Add(data.TableName, bulkDataIRI.Count);


        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_LCMS_BLEEDING_PROCESSED".ToLower());
        List<DT_LCMS_BLEEDING_LEFT> bulkDataLEFT = new List<DT_LCMS_BLEEDING_LEFT>();
        List<DT_LCMS_BLEEDING_RIGHT> bulkDataRIGHT = new List<DT_LCMS_BLEEDING_RIGHT>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            if (data.Rows[i][6].ToString() != "No Bleeding")
            {
                bulkDataLEFT.Add(new DT_LCMS_BLEEDING_LEFT()
                           {
                               SURVEY_ID = data.Rows[i][0].ToString(),
                               CHAINAGE = data.Rows[i][1].ToString(),
                               LRP_NUMBER = data.Rows[i][2].ToString(),
                               LRP_CHAINAGE = data.Rows[i][3].ToString(),
                               BI_LEFT = data.Rows[i][4].ToString(),
                               SEVERITY_LEFT = data.Rows[i][6].ToString(),
                               IMAGE_FILE_INDEX = data.Rows[i][8].ToString(),
                               CH_START = data.Rows[i][9].ToString(),
                               CH_END = data.Rows[i][10].ToString(),
                               NID = data.Rows[i][11].ToString(),
                               CreateDate = DateTime.Now.ToString(),
                               Done_By = "40"
                           });
            }
            if (data.Rows[i][7].ToString() != "No Bleeding")
            {

                bulkDataRIGHT.Add(new DT_LCMS_BLEEDING_RIGHT()
                {
                    SURVEY_ID = data.Rows[i][0].ToString(),
                    CHAINAGE = data.Rows[i][1].ToString(),
                    LRP_NUMBER = data.Rows[i][2].ToString(),
                    LRP_CHAINAGE = data.Rows[i][3].ToString(),
                    BI_RIGHT = data.Rows[i][5].ToString(),
                    SEVERITY_RIGHT = data.Rows[i][7].ToString(),
                    IMAGE_FILE_INDEX = data.Rows[i][8].ToString(),
                    CH_START = data.Rows[i][9].ToString(),
                    CH_END = data.Rows[i][10].ToString(),
                    NID = data.Rows[i][11].ToString(),
                    CreateDate = DateTime.Now.ToString(),
                    Done_By = "40"
                });
            }
        }

        RomdasObject.InsertDT_LCMS_BLEEDING_LEFT(bulkDataLEFT);
        DataBaseTables.Rows.Add("DT_LCMS_BLEEDING_LEFT", bulkDataLEFT.Count);

        RomdasObject.InsertDT_LCMS_BLEEDING_RIGHT(bulkDataRIGHT);
        DataBaseTables.Rows.Add("DT_LCMS_BLEEDING_RIGHT", bulkDataRIGHT.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_LCMS_CRACK_PROCESSED".ToLower());
        List<DT_LCMS_CRACK_PROCESSED> bulkDataPROCESSED = new List<DT_LCMS_CRACK_PROCESSED>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            if (data.Rows[i][10].ToString() != "Very Weak")
            {
                bulkDataPROCESSED.Add(new DT_LCMS_CRACK_PROCESSED()
                           {
                               SURVEY_ID = data.Rows[i][0].ToString(),
                               CHAINAGE = data.Rows[i][1].ToString(),
                               LRP_NUMBER = data.Rows[i][2].ToString(),
                               LRP_CHAINAGE = data.Rows[i][3].ToString(),
                               CRACK_ID = data.Rows[i][4].ToString(),
                               LENGTH = data.Rows[i][5].ToString(),
                               WIDTH = data.Rows[i][6].ToString(),
                               DEPTH = data.Rows[i][7].ToString(),
                               AREA = data.Rows[i][8].ToString(),
                               CLASSIFICATION = data.Rows[i][9].ToString(),
                               SEVERITY = data.Rows[i][10].ToString(),
                               IMAGE_FILE_INDEX = data.Rows[i][11].ToString(),
                               CreateDate = DateTime.Now.ToString(),
                               Done_By = "40"
                           });
            }

        }

        RomdasObject.InsertDT_LCMS_CRACK_PROCESSED(bulkDataPROCESSED);
        DataBaseTables.Rows.Add(data.TableName, bulkDataPROCESSED.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_LCMS_POTHOLES_PROCESSED".ToLower());
        List<DT_LCMS_POTHOLES_PROCESSED> bulkDataPOTHOLES = new List<DT_LCMS_POTHOLES_PROCESSED>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataPOTHOLES.Add(new DT_LCMS_POTHOLES_PROCESSED()
                       {
                           SURVEY_ID = data.Rows[i][0].ToString(),
                           CHAINAGE = data.Rows[i][1].ToString(),
                           LRP_NUMBER = data.Rows[i][2].ToString(),
                           LRP_CHAINAGE = data.Rows[i][3].ToString(),
                           AREA = data.Rows[i][4].ToString(),
                           MAX_DEPTH = data.Rows[i][5].ToString(),
                           AVE_DEPTH = data.Rows[i][6].ToString(),
                           SEVERITY = data.Rows[i][7].ToString(),
                           IMAGE_FILE_INDEX = data.Rows[i][8].ToString(),
                           CreateDate = DateTime.Now.ToString(),
                           Done_By = "40"
                       });
        }

        RomdasObject.InsertDT_LCMS_POTHOLES_PROCESSED(bulkDataPOTHOLES);
        DataBaseTables.Rows.Add(data.TableName, bulkDataPOTHOLES.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_SECTION_NO".ToLower());
        List<DT_EVENT_SECTION_NO> bulkDataSECTION = new List<DT_EVENT_SECTION_NO>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataSECTION.Add(new DT_EVENT_SECTION_NO()
                       {
                           Survey_ID = data.Rows[i][0].ToString(),
                           SECTION_NO = data.Rows[i][1].ToString(),
                           CHAINAGE_START = data.Rows[i][2].ToString(),
                           CHAINAGE_END = data.Rows[i][3].ToString(),
                           LENGTH = data.Rows[i][4].ToString(),
                           LRP_NUMBER_START = data.Rows[i][5].ToString(),
                           LRP_OFFSET_START = data.Rows[i][6].ToString(),
                           LRP_NUMBER_END = data.Rows[i][7].ToString(),
                           LRP_OFFSET_END = data.Rows[i][8].ToString(),
                           FRAME_START = data.Rows[i][9].ToString(),
                           FRAME_END = data.Rows[i][10].ToString(),
                           COMMENT1 = data.Rows[i][11].ToString(),
                           COMMENT_1 = data.Rows[i][12].ToString(),
                           COMMENT_2 = data.Rows[i][13].ToString(),
                           COMMENT_3 = data.Rows[i][14].ToString(),
                           COMMENT_4 = data.Rows[i][15].ToString(),
                           PHOTO_SET = data.Rows[i][16].ToString(),
                           X = data.Rows[i][17].ToString(),
                           Y = data.Rows[i][18].ToString(),
                           Z = data.Rows[i][19].ToString(),
                           X_END = data.Rows[i][20].ToString(),
                           Y_END = data.Rows[i][21].ToString(),
                           Z_END = data.Rows[i][22].ToString(),
                           CreateDate = DateTime.Now.ToString(),
                           Done_By = "40"
                       });
        }

        RomdasObject.InsertDT_EVENT_SECTION_NO(bulkDataSECTION);
        DataBaseTables.Rows.Add(data.TableName, bulkDataSECTION.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_LANE_NO".ToLower());
        List<DT_EVENT_LANE_NO> bulkDataLANE = new List<DT_EVENT_LANE_NO>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataLANE.Add(new DT_EVENT_LANE_NO()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                LANE_NO = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString(),
                CreateDate = DateTime.Now.ToString(),
                Done_By = "40"
            });
        }

        RomdasObject.InsertDT_EVENT_LANE_NO(bulkDataLANE);
        DataBaseTables.Rows.Add(data.TableName, bulkDataLANE.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_LANE_WIDTH".ToLower());
        List<DT_EVENT_LANE_WIDTH> bulkDataWIDTH = new List<DT_EVENT_LANE_WIDTH>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataWIDTH.Add(new DT_EVENT_LANE_WIDTH()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                LANE_WIDTH = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString(),
                CreateDate = DateTime.Now.ToString(),
                Done_By = "40"
            });
        }

        RomdasObject.InsertDT_EVENT_LANE_WIDTH(bulkDataWIDTH);
        DataBaseTables.Rows.Add(data.TableName, bulkDataWIDTH.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_DATE".ToLower());
        List<DT_EVENT_DATE> bulkDataDATE = new List<DT_EVENT_DATE>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataDATE.Add(new DT_EVENT_DATE()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                DATE1 = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString(),
                CreateDate = DateTime.Now.ToString(),
                Done_By = "40"
            });
        }

        RomdasObject.InsertDT_EVENT_DATE(bulkDataDATE);
        DataBaseTables.Rows.Add(data.TableName, bulkDataDATE.Count);


        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_DEPRESSION_AREA".ToLower());
        List<DT_EVENT_DEPRESSION_AREA> bulkDataDEPRESSION = new List<DT_EVENT_DEPRESSION_AREA>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataDEPRESSION.Add(new DT_EVENT_DEPRESSION_AREA()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                DEPRESSION_AREA = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString()
            });
        }

        RomdasObject.InsertDT_EVENT_DEPRESSION_AREA(bulkDataDEPRESSION);
        if (data != null)
            DataBaseTables.Rows.Add(data.TableName, bulkDataDEPRESSION.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_PATCHING_AREA".ToLower());
        List<DT_EVENT_PATCHING_AREA> bulkDataPATCHING = new List<DT_EVENT_PATCHING_AREA>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataPATCHING.Add(new DT_EVENT_PATCHING_AREA()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                PATCHING_AREA = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString()
            });
        }

        RomdasObject.InsertDT_EVENT_PATCHING_AREA(bulkDataPATCHING);
        if (data != null)
            DataBaseTables.Rows.Add(data.TableName, bulkDataPATCHING.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_POLISHING_AREA".ToLower());
        List<DT_EVENT_POLISHING_AREA> bulkDataPOLISHING = new List<DT_EVENT_POLISHING_AREA>();

        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataPOLISHING.Add(new DT_EVENT_POLISHING_AREA()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                POLISHING_AREA = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString()
            });
        }

        RomdasObject.InsertDT_EVENT_POLISHING_AREA(bulkDataPOLISHING);
        if (data != null)
            DataBaseTables.Rows.Add(data.TableName, bulkDataPOLISHING.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_RUTTING_AREA".ToLower());
        List<DT_EVENT_RUTTING_AREA> bulkDataRUTTING = new List<DT_EVENT_RUTTING_AREA>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataRUTTING.Add(new DT_EVENT_RUTTING_AREA()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                RUTTING_AREA = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString()
            });
        }

        RomdasObject.InsertDT_EVENT_RUTTING_AREA(bulkDataRUTTING);
        if (data != null)
            DataBaseTables.Rows.Add(data.TableName, bulkDataRUTTING.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_RAVELLING_AREA".ToLower());
        List<DT_EVENT_RAVELLING_AREA> bulkDataRAVELLING = new List<DT_EVENT_RAVELLING_AREA>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataRAVELLING.Add(new DT_EVENT_RAVELLING_AREA()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                RAVELLING_AREA = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString()
            });
        }

        RomdasObject.InsertDT_EVENT_RAVELLING_AREA(bulkDataRAVELLING);
        if (data != null)
            DataBaseTables.Rows.Add(data.TableName, bulkDataRAVELLING.Count);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_SHOVING_AREA".ToLower());
        List<DT_EVENT_SHOVING_AREA> bulkDataSHOVING = new List<DT_EVENT_SHOVING_AREA>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            bulkDataSHOVING.Add(new DT_EVENT_SHOVING_AREA()
            {
                Survey_ID = data.Rows[i][0].ToString(),
                SHOVING_AREA = data.Rows[i][1].ToString(),
                CHAINAGE_START = data.Rows[i][2].ToString(),
                CHAINAGE_END = data.Rows[i][3].ToString(),
                LENGTH = data.Rows[i][4].ToString(),
                LRP_NUMBER_START = data.Rows[i][5].ToString(),
                LRP_OFFSET_START = data.Rows[i][6].ToString(),
                LRP_NUMBER_END = data.Rows[i][7].ToString(),
                LRP_OFFSET_END = data.Rows[i][8].ToString(),
                FRAME_START = data.Rows[i][9].ToString(),
                FRAME_END = data.Rows[i][10].ToString(),
                COMMENT1 = data.Rows[i][11].ToString(),
                COMMENT_1 = data.Rows[i][12].ToString(),
                COMMENT_2 = data.Rows[i][13].ToString(),
                COMMENT_3 = data.Rows[i][14].ToString(),
                COMMENT_4 = data.Rows[i][15].ToString(),
                PHOTO_SET = data.Rows[i][16].ToString(),
                X = data.Rows[i][17].ToString(),
                Y = data.Rows[i][18].ToString(),
                Z = data.Rows[i][19].ToString(),
                X_END = data.Rows[i][20].ToString(),
                Y_END = data.Rows[i][21].ToString(),
                Z_END = data.Rows[i][22].ToString()
            });
        }
        RomdasObject.InsertDT_EVENT_SHOVING_AREA(bulkDataSHOVING);
        if (data != null)
            DataBaseTables.Rows.Add(data.TableName, bulkDataSHOVING.Count);

        LoadFromDataBase(DataBaseTables, AccessDetials);
        BtnValidate_Click(null, null);
        //BtnValidate.Enabled = false;
        watch.Stop();
        lblFeedbackStatus.Text = " Loop:  " + watch.ElapsedMilliseconds.ToString();

    }
    public void GenericToUploadBulkData(DataTable[] Tablesdata)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        RomdasEquipment RomdasObject = new RomdasEquipment();
        RomdasObject.RemovePreviousTables();

        DataTable data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_LCMS_BLEEDING_PROCESSED".ToLower());
        List<DT_LCMS_BLEEDING_LEFT> bulkDataLEFT = new List<DT_LCMS_BLEEDING_LEFT>();
        List<DT_LCMS_BLEEDING_RIGHT> bulkDataRIGHT = new List<DT_LCMS_BLEEDING_RIGHT>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            if (data.Rows[i][6].ToString() != "No Bleeding")
            {
                bulkDataLEFT.Add(new DT_LCMS_BLEEDING_LEFT()
                {
                    SURVEY_ID = data.Rows[i][0].ToString(),
                    CHAINAGE = data.Rows[i][1].ToString(),
                    LRP_NUMBER = data.Rows[i][2].ToString(),
                    LRP_CHAINAGE = data.Rows[i][3].ToString(),
                    BI_LEFT = data.Rows[i][4].ToString(),
                    SEVERITY_LEFT = data.Rows[i][6].ToString(),
                    IMAGE_FILE_INDEX = data.Rows[i][8].ToString(),
                    CH_START = data.Rows[i][9].ToString(),
                    CH_END = data.Rows[i][10].ToString(),
                    NID = data.Rows[i][11].ToString(),
                    CreateDate = DateTime.Now.ToString(),
                    Done_By = "40"
                });
            }
            if (data.Rows[i][7].ToString() != "No Bleeding")
            {

                bulkDataRIGHT.Add(new DT_LCMS_BLEEDING_RIGHT()
                {
                    SURVEY_ID = data.Rows[i][0].ToString(),
                    CHAINAGE = data.Rows[i][1].ToString(),
                    LRP_NUMBER = data.Rows[i][2].ToString(),
                    LRP_CHAINAGE = data.Rows[i][3].ToString(),
                    BI_RIGHT = data.Rows[i][5].ToString(),
                    SEVERITY_RIGHT = data.Rows[i][7].ToString(),
                    IMAGE_FILE_INDEX = data.Rows[i][8].ToString(),
                    CH_START = data.Rows[i][9].ToString(),
                    CH_END = data.Rows[i][10].ToString(),
                    NID = data.Rows[i][11].ToString(),
                    CreateDate = DateTime.Now.ToString(),
                    Done_By = "40"
                });
            }
        }
        RomdasObject.InsertDT_LCMS_BLEEDING_LEFT(bulkDataLEFT);
        RomdasObject.InsertDT_LCMS_BLEEDING_RIGHT(bulkDataRIGHT);

        data = Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_LCMS_CRACK_PROCESSED".ToLower());
        List<DT_LCMS_CRACK_PROCESSED> bulkDataPROCESSED = new List<DT_LCMS_CRACK_PROCESSED>();
        for (int i = 0; i < (data == null ? 0 : data.Rows.Count); i++)
        {
            if (data.Rows[i][10].ToString() != "Very Weak")
            {
                bulkDataPROCESSED.Add(new DT_LCMS_CRACK_PROCESSED()
                {
                    SURVEY_ID = data.Rows[i][0].ToString(),
                    CHAINAGE = data.Rows[i][1].ToString(),
                    LRP_NUMBER = data.Rows[i][2].ToString(),
                    LRP_CHAINAGE = data.Rows[i][3].ToString(),
                    CRACK_ID = data.Rows[i][4].ToString(),
                    LENGTH = data.Rows[i][5].ToString(),
                    WIDTH = data.Rows[i][6].ToString(),
                    DEPTH = data.Rows[i][7].ToString(),
                    AREA = data.Rows[i][8].ToString(),
                    CLASSIFICATION = data.Rows[i][9].ToString(),
                    SEVERITY = data.Rows[i][10].ToString(),
                    IMAGE_FILE_INDEX = data.Rows[i][11].ToString(),
                    CreateDate = DateTime.Now.ToString(),
                    Done_By = "40"
                });
            }

        }

        RomdasObject.InsertDT_LCMS_CRACK_PROCESSED(bulkDataPROCESSED);

        List<DT_PROFILER_IRI> bulkDataIRI = ConvertDataTable<DT_PROFILER_IRI>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_PROFILER_IRI".ToLower()));
        RomdasObject.InsertDT_PROFILER_IRI(bulkDataIRI);

        List<DT_LCMS_POTHOLES_PROCESSED> bulkDataPOTHOLES = ConvertDataTable<DT_LCMS_POTHOLES_PROCESSED>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_LCMS_POTHOLES_PROCESSED".ToLower()));
        RomdasObject.InsertDT_LCMS_POTHOLES_PROCESSED(bulkDataPOTHOLES);

        List<DT_EVENT_SECTION_NO> bulkDataSECTION = ConvertDataTable<DT_EVENT_SECTION_NO>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_SECTION_NO".ToLower()));
        RomdasObject.InsertDT_EVENT_SECTION_NO(bulkDataSECTION);

        List<DT_EVENT_LANE_NO> bulkDataLANE = ConvertDataTable<DT_EVENT_LANE_NO>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_LANE_NO".ToLower()));
        RomdasObject.InsertDT_EVENT_LANE_NO(bulkDataLANE);

        List<DT_EVENT_LANE_WIDTH> bulkDataWIDTH = ConvertDataTable<DT_EVENT_LANE_WIDTH>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_LANE_WIDTH".ToLower()));
        RomdasObject.InsertDT_EVENT_LANE_WIDTH(bulkDataWIDTH);

        List<DT_EVENT_DATE> bulkDataDATE = ConvertDataTable<DT_EVENT_DATE>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_DATE".ToLower()));
        RomdasObject.InsertDT_EVENT_DATE(bulkDataDATE);

        List<DT_EVENT_DEPRESSION_AREA> bulkDataDEPRESSION = ConvertDataTable<DT_EVENT_DEPRESSION_AREA>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_DEPRESSION_AREA".ToLower()));
        RomdasObject.InsertDT_EVENT_DEPRESSION_AREA(bulkDataDEPRESSION);

        List<DT_EVENT_PATCHING_AREA> bulkDataPATCHING = ConvertDataTable<DT_EVENT_PATCHING_AREA>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_PATCHING_AREA".ToLower()));
        RomdasObject.InsertDT_EVENT_PATCHING_AREA(bulkDataPATCHING);

        List<DT_EVENT_POLISHING_AREA> bulkDataPOLISHING = ConvertDataTable<DT_EVENT_POLISHING_AREA>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_POLISHING_AREA".ToLower()));
        RomdasObject.InsertDT_EVENT_POLISHING_AREA(bulkDataPOLISHING);

        List<DT_EVENT_RUTTING_AREA> bulkDataRUTTING = ConvertDataTable<DT_EVENT_RUTTING_AREA>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_RUTTING_AREA".ToLower()));
        RomdasObject.InsertDT_EVENT_RUTTING_AREA(bulkDataRUTTING);

        List<DT_EVENT_RAVELLING_AREA> bulkDataRAVELLING = ConvertDataTable<DT_EVENT_RAVELLING_AREA>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_RAVELLING_AREA".ToLower()));
        RomdasObject.InsertDT_EVENT_RAVELLING_AREA(bulkDataRAVELLING);

        List<DT_EVENT_SHOVING_AREA> bulkDataSHOVING = ConvertDataTable<DT_EVENT_SHOVING_AREA>(Tablesdata.FirstOrDefault(value => value.TableName.ToLower() == "DT_EVENT_SHOVING_AREA".ToLower()));
        RomdasObject.InsertDT_EVENT_SHOVING_AREA(bulkDataSHOVING);

        watch.Stop();
        lblFeedbackStatus.Text = " noLoop:  " + watch.ElapsedMilliseconds.ToString();
    }

    private  List<T> ConvertDataTable<T>(DataTable dt)
    {
        if (dt == null)
            return null;
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }
    private  T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    pro.SetValue(obj, dr[column.ColumnName].ToString(),null);
                else
                    continue;
            }
        }
        return obj;
    }  
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "55")
        {
            if (FileUpload1.HasFile)
            {
                SaveingFile();
                GetUploadFiles();
                LblTransfare.Text = string.Empty;
                BtnDelete.Enabled = false;
                BtnUpdate.Enabled = false;
                //BtnValidate.Enabled = false;
                GridView2.DataBind();
            }
            else
                lblUploadStatus.Text = "You did not specify a file to upload.";
        }
        else
            lblUploadStatus.Text = Feedback.NoPermissions();
    }
    private void SaveingFile()
    {
        string strFileName = Path.GetFileName(FileUpload1.PostedFile.FileName).Trim();
        string strExtension = Path.GetExtension(strFileName);
        string savePath = Server.MapPath("~/Uploads/");
        string OldpathToCheck = savePath + strFileName;
        string NewpathToCheck = OldpathToCheck;
        if (strExtension == ".mdb")
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);


            if (File.Exists(OldpathToCheck))
            {
                //string tempfileName = "";
                //int counter = 1;
                //while (File.Exists(NewpathToCheck))
                //{

                //    tempfileName = "Copy_" + counter.ToString() + "_" + strFileName;
                //    NewpathToCheck = savePath + tempfileName;
                //    counter++;
                //}
                //UploadStatusLabel.Text = "الملف موجود بنفس الإسم." +
                //    "<br />تم حفظ الملف بإسم  " + tempfileName;
            }
            else
            {
                lblUploadStatus.Text = "تم ارفاق الملف بنجاح.";
            }

            FileUpload1.PostedFile.SaveAs(NewpathToCheck);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            switch (CheckIdentical(OldpathToCheck, NewpathToCheck))
            {
                case RomdasEquipment.FilesCollections.NewFile:
                    {
                        LoadFromAccess(NewpathToCheck);
                        lblFeedbackPosition.Text = "وضع الملف : جديد";
                        break;
                    }
                case RomdasEquipment.FilesCollections.ExistsFileIdentical:
                    {
                        LoadFromAccess(NewpathToCheck);
                        DeleteIdentical(NewpathToCheck);
                        lblFeedbackPosition.Text = " وضع الملف : موجود بنفس البيانات";
                        break;
                    }
                case RomdasEquipment.FilesCollections.ExistsFileDifferent:
                    {
                        LoadFromAccess(NewpathToCheck);
                        lblFeedbackPosition.Text = "وضع الملف : موجود ومختلف في البيانات";
                        break;
                    }
                default:
                    break;
            }

        }
        else
            lblUploadStatus.Text = "Upload status: only .mbd file are allowed!";
    }
    private void DeleteIdentical(string NewpathToCheck)
    {
        if (File.Exists(NewpathToCheck))
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(NewpathToCheck);
            lblFeedbackStatus.Text = " حالة الملف : تم حذف الملف الجديد  " + Path.GetFileName(NewpathToCheck).Trim();
        }
    }

    private void DeleteErorr(string NewpathToCheck)
    {
        if (File.Exists(NewpathToCheck))
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(NewpathToCheck);
            lblFeedbackPosition.Text = "وضع الملف : جديد وغير مطابق ";
            lblFeedbackStatus.Text = " حالة الملف : تم حذف   " + Path.GetFileName(NewpathToCheck).Trim();
        }
    }
    private RomdasEquipment.FilesCollections CheckIdentical(string filenameOne, string filenameTwo)
    {
        if (filenameOne == filenameTwo)
            return RomdasEquipment.FilesCollections.NewFile;
        else if (AreFileEqualLength(filenameOne, filenameTwo))//CalculateSHA1(filenameOne) == CalculateSHA1(filenameTwo)
            return RomdasEquipment.FilesCollections.ExistsFileIdentical;
        else
            return RomdasEquipment.FilesCollections.ExistsFileDifferent;
    }
    private string CalculateSHA1(string filePathName)
    {
        using (FileStream streamfile = File.OpenRead(filePathName))
        using (var SHA1 = System.Security.Cryptography.SHA1.Create())
        {
            var hash = SHA1.ComputeHash(streamfile);
            var base64String = Convert.ToBase64String(hash);
            return base64String;
        }
    }
    public bool AreFileContentsEqual(FileInfo fi1, FileInfo fi2)
    {
        return fi1.Length == fi2.Length &&
         (fi1.Length == 0 || File.ReadAllBytes(fi1.FullName).SequenceEqual(
                             File.ReadAllBytes(fi2.FullName)));
    }
    public bool AreFileContentsEqual(String path1, String path2)
    {
        return AreFileContentsEqual(new FileInfo(path1), new FileInfo(path2));
    }
    public bool AreFileEqualLength(String path1, String path2)
    {
        return new FileInfo(path1).Length == new FileInfo(path2).Length;
    }
    private void LoadFromAccess(string FileName)
    {
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";";
        DataTable userTables = null;
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            connection.ConnectionString = ConnectionString;
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            connection.Open();
            userTables = connection.GetSchema("Tables", restrictions);
        }
        List<string> tableNames = new List<string>();
        bool? matchingvalues;
        for (int i = 0; i < userTables.Rows.Count; i++)
        {
            if (
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_PROFILER_IRI.ToString() ||

                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DEPRESSION_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_PATCHING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_POLISHING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_RAVELLING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_RUTTING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SHOVING_AREA.ToString() ||

                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_CRACK_PROCESSED.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_POTHOLES_PROCESSED.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_BLEEDING_PROCESSED.ToString()
                )
                tableNames.Add(userTables.Rows[i][2].ToString().ToLower());
        }

        if (tableNames.Count == 0)
        {
            lblFeedbackStatus.Text = "حالة الملف : الملف غير مطابق";
            GridView1.DataBind();
            return;
        }
        if (
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_PROFILER_IRI.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_LCMS_CRACK_PROCESSED.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_LCMS_POTHOLES_PROCESSED.ToString().ToLower()) &&
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_LCMS_BLEEDING_PROCESSED.ToString().ToLower()) &&
       (
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_DEPRESSION_AREA.ToString().ToLower()) ||
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_PATCHING_AREA.ToString().ToLower()) ||
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_POLISHING_AREA.ToString().ToLower()) ||
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_RAVELLING_AREA.ToString().ToLower()) ||
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_RUTTING_AREA.ToString().ToLower()) ||
       tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_SHOVING_AREA.ToString().ToLower())))
            matchingvalues = true;
        else
            matchingvalues = false;
        if (matchingvalues != null)
        {
            if (tableNames.Count == 0)
            {
                lblFeedbackStatus.Text = "حالة الملف : الملف غير مطابق";
                return;
            }
            else
            {
                if (matchingvalues.Value)
                    lblFeedbackStatus.Text = "حالة الملف : الملف مطابق";
                else
                    lblFeedbackStatus.Text = "حالة الملف : الملف غير مطابق";
            }
            DataTable[] Tablesdata = new DataTable[tableNames.Count];
            DataTable dtDetails = new DataTable();
            dtDetails.Columns.Add("Table Remarks");
            dtDetails.Columns.Add("Table Rows");
            dtDetails.Columns.Add("Table Name");
            dtDetails.Columns.Add("Serial No");
            System.Text.StringBuilder StringErorrs = new System.Text.StringBuilder();
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                for (int i = 0; i < tableNames.Count; i++)
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM " + tableNames[i].ToString(), connection);
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        OleDbDataAdapter oldp = new OleDbDataAdapter(command);
                        Tablesdata[i] = new DataTable();
                        oldp.Fill(Tablesdata[i]);
                        string result = null;

                        if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString())
                        {
                            Tablesdata[i].TableName = tableNames[i].ToString().ToUpper();
                            List<string> list = Tablesdata[i].AsEnumerable()
                               .Select(r => r.Field<string>(11))
                               .ToList();

                            if (list.Contains(string.Empty))
                            {
                                StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString());
                                StringErorrs.Append("<br />");
                            }

                            result = string.Join(",", list.GroupBy(s => s.Substring(6, 4))
                               .Select(g => g.First().Substring(6, 4))
                               .ToList().ToArray());
                        }
                        else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString())
                        {
                            Tablesdata[i].TableName = tableNames[i].ToString().ToUpper();
                            List<string> list = Tablesdata[i].AsEnumerable()
                               .Select(r => r.Field<string>(11))
                               .ToList();

                            if (list.Contains(string.Empty))
                            {
                                StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString());
                                StringErorrs.Append("<br />");
                            }

                            result = string.Join(",", list.GroupBy(s => s)
                               .Select(g => g.First())
                               .ToList().ToArray());
                        }
                        else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString())
                        {
                            Tablesdata[i].TableName = tableNames[i].ToString().ToUpper();
                            List<string> list = Tablesdata[i].AsEnumerable()
                               .Select(r => r.Field<string>(11))
                               .ToList();

                            if (list.Contains(string.Empty))
                            {
                                StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString());
                                StringErorrs.Append("<br />");
                            }
                        }
                        else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString())
                        {
                            Tablesdata[i].TableName = tableNames[i].ToString().ToUpper();
                            List<string> list = Tablesdata[i].AsEnumerable()
                               .Select(r => r.Field<string>(11))
                               .ToList();

                            if (list.Contains(string.Empty))
                            {
                                StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString());
                                StringErorrs.Append("<br />");
                            }
                        }

                        if (result != null)
                            dtDetails.Rows.Add(result, Tablesdata[i].Rows.Count, tableNames[i].ToString(), i + 1);
                        else
                            dtDetails.Rows.Add(null, Tablesdata[i].Rows.Count, tableNames[i].ToString(), i + 1);

                    }
                    catch
                    {
                        return;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
             
            }


            GridView1.DataSource = dtDetails;
            GridView1.DataBind();
            if (StringErorrs.Length > 0)
            {
                lblFeedbackStatus.Text = "<br /> حالة الملف : البيانات بجدول <br />" + StringErorrs.ToString() + " غير مطابقة";
                return;
            }
            //else return true;
        }
        else
        {
            lblFeedbackStatus.Text = "حالة الملف : الملف غير مطابق";
            GridView1.DataBind();
            return;
        }
    }
   
    private bool ValidateFile(string FileName)
    {
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";";
        DataTable userTables = null;
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            connection.ConnectionString = ConnectionString;
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            connection.Open();
            userTables = connection.GetSchema("Tables", restrictions);
        }
        List<string> tableNames = new List<string>();
        for (int i = 0; i < userTables.Rows.Count; i++)
        {
            if (
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_PROFILER_IRI.ToString() ||

                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DEPRESSION_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_PATCHING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_POLISHING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_RAVELLING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_RUTTING_AREA.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SHOVING_AREA.ToString() ||

                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_CRACK_PROCESSED.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_POTHOLES_PROCESSED.ToString() ||
                userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_BLEEDING_PROCESSED.ToString()
                )
                tableNames.Add(userTables.Rows[i][2].ToString().ToLower());
        }

        if (
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_PROFILER_IRI.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_LCMS_CRACK_PROCESSED.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_LCMS_POTHOLES_PROCESSED.ToString().ToLower()) &&
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_LCMS_BLEEDING_PROCESSED.ToString().ToLower()) &&
        (
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_DEPRESSION_AREA.ToString().ToLower()) ||
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_PATCHING_AREA.ToString().ToLower()) ||
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_POLISHING_AREA.ToString().ToLower()) ||
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_RAVELLING_AREA.ToString().ToLower()) ||
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_RUTTING_AREA.ToString().ToLower()) ||
        tableNames.Contains(RomdasEquipment.TablesCollections.DT_EVENT_SHOVING_AREA.ToString().ToLower())))
            return true;
        else
            return false;
    }
    private void GetUploadFiles()
    {
        RadioButtonList1.Items.Clear();
        var items = Directory.GetFiles(Server.MapPath("~/Uploads/"));
        if (items.Length == 0)
        {
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
        }
        for (int i = 0; i < items.Length; i++)
        {
            RadioButtonList1.Items.Add(new ListItem(Path.GetFileNameWithoutExtension(items[i]), Path.GetFullPath(items[i])));
        }
        RadioButtonList1.DataBind();

    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        lblFeedbackPosition.Text = string.Empty;
        lblFeedbackStatus.Text = string.Empty;
        lblUploadStatus.Text = string.Empty;
        if (Session["UserID"].ToString() == "55")
        {
            int count = 0, ItemIndex = 0;
            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                if (RadioButtonList1.Items[i].Selected == false)
                    count += 1;
                else
                    ItemIndex = i;

            }
            if (count == RadioButtonList1.Items.Count)
                LblTransfare.Text = "يجب اختيار ملف أولا ";
            else
            {
                if (ValidateFile(RadioButtonList1.Items[ItemIndex].Value))
                {
                    DataTable AccessDetials;
                    DataTable[] TableData = GetTablesData(RadioButtonList1.Items[ItemIndex].Value, out AccessDetials);
                    LoopToUploadBulkData(TableData, AccessDetials);
                    LblTransfare.Text = string.Empty;
                }
                else
                {
                    lblFeedbackStatus.Text = "حالة الملف : الملف غير مطابق";
                    GridView1.DataBind();
                    GridView2.DataBind();
                }
            }
        }
        else
            lblUploadStatus.Text = Feedback.NoPermissions();
        
    }
    private void LoadFromDataBase(DataTable Tablesdata, DataTable AccessDetials)
    {
   
        DataView ViewAccessDetials = AccessDetials.DefaultView;
        DataView ViewTablesdata = Tablesdata.DefaultView;

        ViewAccessDetials.Sort = "AccessName ";
        ViewTablesdata.Sort = "TableName";

        DataTable sortedAccessDetials = ViewAccessDetials.ToTable();
        DataTable sortedTablesdata = ViewTablesdata.ToTable();
       
        if (Tablesdata.Rows.Count == AccessDetials.Rows.Count )
        {
            DataTable dtDetails = new DataTable();
            dtDetails.Columns.Add("DataBase Remarks");
            dtDetails.Columns.Add("Access Remarks");
            dtDetails.Columns.Add("DataBase Rows");
            dtDetails.Columns.Add("DataBase Name"); 
            dtDetails.Columns.Add("Access Rows");
            dtDetails.Columns.Add("Access Name");
            dtDetails.Columns.Add("Serial");
            for (int i = 0; i < AccessDetials.Rows.Count; i++)
            {
                dtDetails.Rows.Add("DB Remark", sortedAccessDetials.Rows[i][0].ToString(), sortedTablesdata.Rows[i][1].ToString(), sortedTablesdata.Rows[i][0].ToString(), sortedAccessDetials.Rows[i][1].ToString(), AccessDetials.Rows[i][2].ToString(), i + 1);
            }
            GridView1.DataSource = dtDetails;
            GridView1.DataBind();
        }

    }
    private DataTable[] GetTablesData(string FileName, out DataTable TablesDetials)
    {
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";";
        DataTable userTables = null;
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            connection.ConnectionString = ConnectionString;
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            connection.Open();
            userTables = connection.GetSchema("Tables", restrictions);
        }
        List<string> tableNames = new List<string>();
        for (int i = 0; i < userTables.Rows.Count; i++)
        {
            if (
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_PROFILER_IRI.ToString() ||

               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DEPRESSION_AREA.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_PATCHING_AREA.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_POLISHING_AREA.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_RAVELLING_AREA.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_RUTTING_AREA.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SHOVING_AREA.ToString() ||

               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_CRACK_PROCESSED.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_POTHOLES_PROCESSED.ToString() ||
               userTables.Rows[i][2].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_BLEEDING_PROCESSED.ToString()
               )
                tableNames.Add(userTables.Rows[i][2].ToString());

        }
        DataTable[] Tablesdata = new DataTable[tableNames.Count];

        TablesDetials = new DataTable();
        TablesDetials.Columns.Add("AccessRemarks");
        TablesDetials.Columns.Add("AccessRows");
        TablesDetials.Columns.Add("AccessName");


        System.Text.StringBuilder StringErorrs = new System.Text.StringBuilder();
        using (OleDbConnection connection = new OleDbConnection(ConnectionString))
        {
            for (int i = 0; i < tableNames.Count; i++)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM " + tableNames[i].ToString(), connection);
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    OleDbDataAdapter oldp = new OleDbDataAdapter(command);
                    Tablesdata[i] = new DataTable(tableNames[i].ToString());
                    oldp.Fill(Tablesdata[i]);


                    string result = null;

                    if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString())
                    {
                        List<string> list = Tablesdata[i].AsEnumerable()
                           .Select(r => r.Field<string>(11))
                           .ToList();

                        if (list.Contains(string.Empty))
                        {
                            StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_SECTION_NO.ToString());
                            StringErorrs.Append("<br />");
                        }

                        result = string.Join(",", list.GroupBy(s => s.Substring(6, 4))
                           .Select(g => g.First().Substring(6, 4))
                           .ToList().ToArray());
                    }
                    else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString())
                    {
                        List<string> list = Tablesdata[i].AsEnumerable()
                           .Select(r => r.Field<string>(11))
                           .ToList();

                        if (list.Contains(string.Empty))
                        {
                            StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_DATE.ToString());
                            StringErorrs.Append("<br />");
                        }

                        result = string.Join(",", list.GroupBy(s => s)
                           .Select(g => g.First())
                           .ToList().ToArray());
                    }
                    else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString())
                    {
                        List<string> list = Tablesdata[i].AsEnumerable()
                           .Select(r => r.Field<string>(11))
                           .ToList();

                        if (list.Contains(string.Empty))
                        {
                            StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_LANE_NO.ToString());
                            StringErorrs.Append("<br />");
                        }
                    }
                    else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString())
                    {
                        List<string> list = Tablesdata[i].AsEnumerable()
                           .Select(r => r.Field<string>(11))
                           .ToList();

                        if (list.Contains(string.Empty))
                        {
                            StringErorrs.Append(RomdasEquipment.TablesCollections.DT_EVENT_LANE_WIDTH.ToString());
                            StringErorrs.Append("<br />");
                        }
                    }
                    else if (tableNames[i].ToString().ToUpper() == RomdasEquipment.TablesCollections.DT_LCMS_BLEEDING_PROCESSED.ToString())
                    {
                        TablesDetials.Rows.Add(null, Tablesdata[i].Rows.Count, tableNames[i].ToString());
                    }

                    if (result != null)
                        TablesDetials.Rows.Add(result, Tablesdata[i].Rows.Count, tableNames[i].ToString());
                    else
                        TablesDetials.Rows.Add(null, Tablesdata[i].Rows.Count, tableNames[i].ToString());

                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            
        }
        return Tablesdata;
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnUpdate.Enabled = true;
        BtnDelete.Enabled = true;
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {

        if (Session["UserID"].ToString() == "55")
        {
            //BtnValidate.Enabled = false;
            lblFeedbackPosition.Text = string.Empty;
            lblFeedbackStatus.Text = string.Empty;
            lblUploadStatus.Text = string.Empty;
            GridView1.DataBind();
            GridView2.DataBind();
            int count = 0, ItemIndex = 0;
            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                if (RadioButtonList1.Items[i].Selected == false)
                    count += 1;
                else
                    ItemIndex = i;

            }
            if (count == RadioButtonList1.Items.Count)
                LblTransfare.Text = "يجب اختيار ملف أولا ";
            else
            {

                if (DeleteAcessFile(RadioButtonList1.Items[ItemIndex].Value))
                {
                    LblTransfare.Text = Feedback.DeleteSuccessfull();
                    GetUploadFiles();
                }
                else
                    LblTransfare.Text = Feedback.DeleteException();
            }
        }
        else
            lblUploadStatus.Text = Feedback.NoPermissions();

    }
    private bool DeleteAcessFile(string FileName)
    {
        if (File.Exists(FileName))
        {
            File.Delete(FileName);
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void BtnValidate_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "55")
        {
            GridView2.DataSource = new RomdasEquipment().ValidateMainTables();
            GridView2.DataBind();
        }
        else
            lblUploadStatus.Text = Feedback.NoPermissions();
    }
}