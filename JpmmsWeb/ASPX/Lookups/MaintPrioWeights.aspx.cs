using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;
using System.Data;

public partial class ASPX_Lookups_MaintPrioWeights : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // load settings
            try
            {
                lblFeedback.Text = "";
                if (Session["Permissions"] == null || Session["Permissions"].ToString()[6] != '1')
                    Response.Redirect("~/ASPX/Default.aspx", false);

                DataTable dt = new MaintPriorityWeights().GetSettings();
                if (dt.Rows.Count > 0) 
                {
                    DataRow dr = dt.Rows[0];
                    // fill texts
                    MAIN_ST_GOOD_WEIGHTTextBox.Text = dr["MAIN_ST_GOOD_WEIGHT"].ToString();
                    MAIN_ST_POOR_WEIGHTTextBox.Text = dr["MAIN_ST_POOR_WEIGHT"].ToString();
                    SECOND_ST_GOOD_WEIGHTTextBox.Text = dr["SECOND_ST_GOOD_WEIGHT"].ToString();
                    SECOND_ST_POOR_WEIGHTTextBox.Text = dr["SECOND_ST_POOR_WEIGHT"].ToString();

                    HOUSES_SECTIONSTextBox.Text = dr["HOUSES_SECTIONS"].ToString();
                    COMMERIAL_SECTIONSTextBox.Text = dr["COMMERIAL_SECTIONS"].ToString();
                    INDISTERIAL_SECTIONSTextBox.Text = dr["INDISTERIAL_SECTIONS"].ToString();
                    REST_HOUSE_SECTIONSTextBox.Text = dr["REST_HOUSE_SECTIONS"].ToString();
                    GARDENS_SECTIONSTextBox.Text = dr["GARDENS_SECTIONS"].ToString();
                    PUBLICS_SECTIONSTextBox.Text = dr["PUBLICS_SECTIONS"].ToString();

                    HOUSES_REGIONSTextBox.Text = dr["HOUSES_REGIONS"].ToString();
                    COMMERIAL_REGIONSTextBox.Text = dr["COMMERIAL_REGIONS"].ToString();
                    INDISTERIAL_REGIONSTextBox.Text = dr["INDISTERIAL_REGIONS"].ToString();
                    REST_HOUSE_REGIONSTextBox.Text = dr["REST_HOUSE_REGIONS"].ToString();
                    GARDENS_REGIONSTextBox.Text = dr["GARDENS_REGIONS"].ToString();
                    PUBLICS_REGIONSTextBox.Text = dr["PUBLICS_REGIONS"].ToString();
                    SCHOOL_REGIONSTextBox.Text = dr["SCHOOL_REGIONS"].ToString();
                    MASJID_REGIONSTextBox.Text = dr["MASJID_REGIONS"].ToString();
                    HOSPITAL_REGIONSTextBox.Text = dr["HOSPITAL_REGIONS"].ToString();
                    SPORT_CLUB_REGIONSTextBox.Text = dr["SPORT_CLUB_REGIONS"].ToString();
                    NEW_BUILDINGS_REGIONSTextBox.Text = dr["NEW_BUILDINGS_REGIONS"].ToString();
                    OTHER_UTIL_REGIONSTextBox.Text = dr["OTHER_UTIL_REGIONS"].ToString();

                    TRAFFIC_LOW_WEIGHTTextBox.Text = dr["TRAFFIC_LOW_WEIGHT"].ToString();
                    TRAFFIC_MEDIUM_WEIGHTTextBox.Text = dr["TRAFFIC_MEDIUM_WEIGHT"].ToString();
                    TRAFFIC_HIGH_WEIGHTTextBox.Text = dr["TRAFFIC_HIGH_WEIGHT"].ToString();
                    TRAFFIC_VERY_HIGH_WEIGHTTextBox.Text = dr["TRAFFIC_VERY_HIGH_WEIGHT"].ToString();
                }
                else
                    throw new Exception(Feedback.NoData());

            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // save settings
        try
        {
            lblFeedback.Text = "";
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            bool saved = new MaintPriorityWeights().Update(MAIN_ST_GOOD_WEIGHTTextBox.Value, MAIN_ST_POOR_WEIGHTTextBox.Value, SECOND_ST_GOOD_WEIGHTTextBox.Value,
                SECOND_ST_POOR_WEIGHTTextBox.Value, HOUSES_SECTIONSTextBox.Value, COMMERIAL_SECTIONSTextBox.Value, INDISTERIAL_SECTIONSTextBox.Value,
                REST_HOUSE_SECTIONSTextBox.Value, GARDENS_SECTIONSTextBox.Value, PUBLICS_SECTIONSTextBox.Value, HOUSES_REGIONSTextBox.Value, COMMERIAL_REGIONSTextBox.Value,
                INDISTERIAL_REGIONSTextBox.Value, REST_HOUSE_REGIONSTextBox.Value, GARDENS_REGIONSTextBox.Value, PUBLICS_REGIONSTextBox.Value, SCHOOL_REGIONSTextBox.Value,
                MASJID_REGIONSTextBox.Value, HOSPITAL_REGIONSTextBox.Value, SPORT_CLUB_REGIONSTextBox.Value, NEW_BUILDINGS_REGIONSTextBox.Value, OTHER_UTIL_REGIONSTextBox.Value,
                TRAFFIC_LOW_WEIGHTTextBox.Value, TRAFFIC_MEDIUM_WEIGHTTextBox.Value, TRAFFIC_HIGH_WEIGHTTextBox.Value, TRAFFIC_VERY_HIGH_WEIGHTTextBox.Value);

            lblFeedback.Text = saved ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintPrioWeights.aspx", false);
    }

}