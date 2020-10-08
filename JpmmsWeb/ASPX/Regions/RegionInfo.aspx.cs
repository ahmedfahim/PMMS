using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Regions_RegionInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            ddlRegions.SelectedValue = "0";
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new ListItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();

            ddlRegionSecondaryStreets.SelectedValue = "0";
            ddlRegionSecondaryStreets_SelectedIndexChanged(sender, e);

            lnkSurveyor.Visible = (ddlRegions.SelectedValue != "0");
            pnlSurveyor.Visible = (ddlRegions.SelectedValue != "0");
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegionSecondaryStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        lblFeedbackInsert.Text = "";

        try
        {
            if (ddlRegions.SelectedValue != "0" && new Region().CheckRegionSurveyorNotSaved(int.Parse(ddlRegions.SelectedValue)))
            {
                lblFeedback.Text = "الرجاء تسجيل بيانات المسح أولا ومن ثم حفظ البيانات الوصفية";

                gvSurveyorJob.DataBind();
                pnlSurveyor.Visible = true;
                pnlSecondarySt.Visible = false;
            }
            else
            {
                int id = int.Parse(ddlRegionSecondaryStreets.SelectedValue);
                if (id != 0)
                {
                    pnlSurveyor.Visible = false;
                    pnlSecondarySt.Visible = false;

                    DataTable dt = new SecondaryStreets().GetSecondaryStreetInfo(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        lnkGallery.NavigateUrl = string.Format("SecondStImages.aspx?SecondStID={0}", id);
                        txtSecondStArName.Text = dr["SECOND_AR_NAME"].ToString();
                        txtSecondStNo.Text = dr["SECOND_ST_NO"].ToString();

                        rntxtLength.Text = dr["SECOND_ST_LENGTH"].ToString();
                        rntxtWidth.Text = dr["SECOND_ST_WIDTH"].ToString();
                        rntxtSectionWidth_TextChanged(sender, e);

                        rntxtUnpavedLength.Text = dr["DIRT_LENGTH"].ToString();

                        ChkLight.Checked = bool.Parse(dr["LIGHTING_TRUE"].ToString());
                        ChkLight_CheckedChanged(sender, e);
                        txtLightLocation.Text = dr["LIGHTING_LOC"].ToString();
                        rntxtLightGood.Text = dr["LIGHT_GOOD_COUNT"].ToString();
                        rntxtLightFair.Text = dr["LIGHT_FAIR_COUNT"].ToString();
                        rntxtLightPoor.Text = dr["LIGHT_POOR_COUNT"].ToString();
                        //rntxtLightCount.Text = dr["LIGHT_COUNT"].ToString();

                        ChkHousing.Checked = bool.Parse(dr["houses"].ToString());
                        ChkCommercial.Checked = bool.Parse(dr["Commerial"].ToString());
                        ChkPublics.Checked = bool.Parse(dr["publics"].ToString());
                        ChkGarden.Checked = bool.Parse(dr["gardens"].ToString());
                        ChkRest_House.Checked = bool.Parse(dr["rest_house"].ToString());
                        ChkIndisterial.Checked = bool.Parse(dr["indisterial"].ToString());
                        chkNewlyBuilt.Checked = bool.Parse(dr["NEW_BUILDINGS"].ToString());
                        chkSchools.Checked = bool.Parse(dr["SCHOOL"].ToString());
                        chkMasjid.Checked = bool.Parse(dr["MASJID"].ToString());
                        chkSport.Checked = bool.Parse(dr["SPORT_CLUB"].ToString());
                        chkHospital.Checked = bool.Parse(dr["HOSPITAL"].ToString());
                        chkOtherUtils.Checked = bool.Parse(dr["OTHER_UTIL"].ToString());
                        chkOtherUtils_CheckedChanged(sender, e);

                        ChkDrinage_CBs.Checked = bool.Parse(dr["drinage_cb_True"].ToString());
                        ChkDrinage_CBs_CheckedChanged(sender, e);

                        ChkDrinage_MH.Checked = bool.Parse(dr["drinage_mh_True"].ToString());
                        ChkDrinage_MH_CheckedChanged(sender, e);

                        ChkSewage_MH.Checked = bool.Parse(dr["Sewage_mh_True"].ToString());
                        ChkSewage_MH_CheckedChanged(sender, e);

                        ChkElect_MH.Checked = bool.Parse(dr["elect_mh_True"].ToString());
                        ChkElect_MH_CheckedChanged(sender, e);

                        ChkSTC_MH.Checked = bool.Parse(dr["stc_mh_True"].ToString());
                        ChkSTC_MH_CheckedChanged(sender, e);

                        ChkWater_MH.Checked = bool.Parse(dr["water_valve_True"].ToString());
                        ChkWater_MH_CheckedChanged(sender, e);

                        //rntxtDrinage_CBCount.Text = dr["drinage_cb_Count"].ToString();
                        //rntxtDrinage_MHCount.Text = dr["drinage_mh_Count"].ToString();
                        //rntxtSewage_MHCount.Text = dr["Sewage_mh_Count"].ToString();
                        //rnTxtElect_MHCount.Text = dr["Elect_mh_Count"].ToString();
                        //rntxtSTC_MHCount.Text = dr["stc_mh_Count"].ToString();
                        //rnTxtWater_MHCount.Text = dr["water_valve_Count"].ToString();

                        rntxtDrinage_CBGood.Text = dr["drinage_cb_Count"].ToString();
                        rntxtDrinage_CBFair.Text = dr["DRAIN_CB_FAIR"].ToString();
                        rntxtDrinage_CBPoor.Text = dr["DRAIN_CB_POOR"].ToString();

                        rntxtDrinage_MH_Good.Text = dr["drinage_mh_Count"].ToString();
                        rntxtDrinage_MH_Fair.Text = dr["DRAIN_CB_FAIR"].ToString();
                        rntxtDrinage_MH_Poor.Text = dr["DRAIN_MH_POOR"].ToString();

                        rntxtSewage_MH_Good.Text = dr["Sewage_mh_Count"].ToString();
                        rntxtSewage_MH_Fair.Text = dr["SEWAGE_MH_FAIR"].ToString();
                        rntxtSewage_MH_Poor.Text = dr["SEWAGE_MH_POOR"].ToString();

                        rnTxtElect_MH_Good.Text = dr["Elect_mh_Count"].ToString();
                        rnTxtElect_MH_Fair.Text = dr["ELEC_MH_FAIR"].ToString();
                        rnTxtElect_MH_Poor.Text = dr["ELEC_MH_POOR"].ToString();

                        rntxtSTC_MH_Good.Text = dr["stc_mh_Count"].ToString();
                        rntxtSTC_MH_Fair.Text = dr["STC_MH_FAIR"].ToString();
                        rntxtSTC_MH_Poor.Text = dr["STC_MH_POOR"].ToString();

                        rnTxtWater_MH_Good.Text = dr["water_valve_Count"].ToString();
                        rnTxtWater_MH_Fair.Text = dr["WATER_MH_FAIR"].ToString();
                        rnTxtWater_MH_Poor.Text = dr["WATER_MH_POOR"].ToString();

                        ChkMidIsland.Checked = bool.Parse(dr["mid_island_True"].ToString());
                        ChkMidIsland_CheckedChanged(sender, e);
                        chkMidGood.Checked = bool.Parse(dr["MID_ISLAND_GOOD"].ToString());
                        chkMidFair.Checked = bool.Parse(dr["MID_ISLAND_FAIR"].ToString());
                        chkMidPoor.Checked = bool.Parse(dr["MID_ISLAND_POOR"].ToString());

                        ChkSideWalk.Checked = bool.Parse(dr["side_Curb_True"].ToString());
                        ChkSideWalk_CheckedChanged(sender, e);
                        chkSideGood.Checked = bool.Parse(dr["SIDE_CURB_GOOD"].ToString());
                        chkSideFair.Checked = bool.Parse(dr["SIDE_CURB_FAIR"].ToString());
                        chkSidePoor.Checked = bool.Parse(dr["SIDE_CURB_POOR"].ToString());


                        chkSpeedBumps.Checked = bool.Parse(dr["SPEED_BUMPS_TRUE"].ToString());
                        chkSpeedBumps_CheckedChanged(sender, e);
                        chkLegal.Checked = bool.Parse(dr["SPEED_BUMPS_LEGAL"].ToString());
                        chkIllegal.Checked = bool.Parse(dr["SPEED_BUMPS_ILLEGAL"].ToString());
                        rntxtSpeedBumpsCount.Text = dr["SPEED_BUMPS_COUNT"].ToString();

                        ddlSpeedBumpType.Items.Clear();
                        ddlSpeedBumpType.Items.Add(new ListItem("اختيار", "0"));
                        ddlSpeedBumpType.DataBind();
                        ddlSpeedBumpType.SelectedValue = dr["SPEED_BUMP_TYPE_ID"].ToString();


                        chkConcreteBlocks.Checked = bool.Parse(dr["CONCRETE_BLOCKS"].ToString());
                        chkConcreteBlocks_CheckedChanged(sender, e);
                        rntxtConcreteBlocks.Text = dr["CONCRETE_BLOCKS_COUNT"].ToString();

                        chkDrillingElec.Checked = bool.Parse(dr["DRILLINGS_ELEC"].ToString());
                        chkDrillingElec_CheckedChanged(sender, e);
                        rntxtDrillingElec.Text = dr["DRILLINGS_ELEC_LENGTH"].ToString();

                        chkDrillingSewage.Checked = bool.Parse(dr["DRILLINGS_SEWAGE"].ToString());
                        chkDrillingSewage_CheckedChanged(sender, e);
                        rntxtDrillingSewage.Text = dr["DRILLINGS_SEWAG_LENGTH"].ToString();

                        chkDrillingSTC.Checked = bool.Parse(dr["DRILLINGS_STC"].ToString());
                        chkDrillingSTC_CheckedChanged(sender, e);
                        rntxtDrillingSTC.Text = dr["DRILLINGS_STC_LENGTH"].ToString();

                        chkDrillingWater.Checked = bool.Parse(dr["DRILLINGS_WATER"].ToString());
                        chkDrillingWater_CheckedChanged(sender, e);
                        rntxtDrillingWater.Text = dr["DRILLINGS_WATER_LENGTH"].ToString();

                        txtNotes.Text = dr["NOTES"].ToString();
                        if (string.IsNullOrEmpty(dr["SURVEY_DATE"].ToString()))
                            rdtpSurveyDate.SelectedDate = null;
                        else
                            rdtpSurveyDate.SelectedDate = DateTime.Parse(dr["SURVEY_DATE"].ToString());

                        pnlSecondarySt.Visible = true;
                        pnlSurveyor.Visible = false;
                        BoldUnBoldLinks(1);
                    }
                    else
                    {
                        lblFeedback.Text = Feedback.NoData();
                        pnlSecondarySt.Visible = false;
                        pnlSurveyor.Visible = false;
                    }
                }
                else
                {
                    pnlSecondarySt.Visible = false;
                    pnlSurveyor.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void rntxtSectionWidth_TextChanged(object sender, EventArgs e)
    {
        if (rntxtLength.Value != null && rntxtWidth.Value != null)
            rntxtArea.Value = rntxtLength.Value * rntxtWidth.Value;
        else if (rntxtLength.Value == null)
        {
            rntxtLength.Text = "0";
            rntxtArea.Text = "0";
        }
        else if (rntxtWidth.Value == null)
        {
            rntxtWidth.Text = "0";
            rntxtArea.Text = "0";
        }
        else
        {
            //rntxtLength.Text = "0";
            //rntxtWidth.Text = "0";
            rntxtArea.Text = "0";
        }
    }

    protected void chkOtherUtils_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkOtherUtils.Checked;
        txtOtherDetails.Enabled = isChecked;

        if (!isChecked)
            txtOtherDetails.Text = "";
    }

    protected void ChkDrinage_CBs_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_CBs.Checked;
        rntxtDrinage_CBGood.Enabled = isChecked;
        rntxtDrinage_CBFair.Enabled = isChecked;
        rntxtDrinage_CBPoor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtDrinage_CBGood.Text = "";
            rntxtDrinage_CBFair.Text = "";
            rntxtDrinage_CBPoor.Text = "";
        }
        else
        {
            rntxtDrinage_CBGood.Text = "0";
            rntxtDrinage_CBFair.Text = "0";
            rntxtDrinage_CBPoor.Text = "0";
        }
    }

    protected void ChkDrinage_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_MH.Checked;
        rntxtDrinage_MH_Good.Enabled = isChecked;
        rntxtDrinage_MH_Fair.Enabled = isChecked;
        rntxtDrinage_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtDrinage_MH_Good.Text = "";
            rntxtDrinage_MH_Fair.Text = "";
            rntxtDrinage_MH_Poor.Text = "";
        }
        else
        {
            rntxtDrinage_MH_Good.Text = "0";
            rntxtDrinage_MH_Fair.Text = "0";
            rntxtDrinage_MH_Poor.Text = "0";
        }
    }

    protected void ChkSewage_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSewage_MH.Checked;
        rntxtSewage_MH_Good.Enabled = isChecked;
        rntxtSewage_MH_Fair.Enabled = isChecked;
        rntxtSewage_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSewage_MH_Good.Text = "";
            rntxtSewage_MH_Fair.Text = "";
            rntxtSewage_MH_Poor.Text = "";
        }
        else
        {
            rntxtSewage_MH_Good.Text = "0";
            rntxtSewage_MH_Fair.Text = "0";
            rntxtSewage_MH_Poor.Text = "0";
        }
    }

    protected void ChkWater_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkWater_MH.Checked;
        rnTxtWater_MH_Good.Enabled = isChecked;
        rnTxtWater_MH_Fair.Enabled = isChecked;
        rnTxtWater_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rnTxtWater_MH_Good.Text = "";
            rnTxtWater_MH_Fair.Text = "";
            rnTxtWater_MH_Poor.Text = "";
        }
        else
        {
            rnTxtWater_MH_Good.Text = "0";
            rnTxtWater_MH_Fair.Text = "0";
            rnTxtWater_MH_Poor.Text = "0";
        }
    }

    protected void ChkElect_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkElect_MH.Checked;
        rnTxtElect_MH_Good.Enabled = isChecked;
        rnTxtElect_MH_Fair.Enabled = isChecked;
        rnTxtElect_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rnTxtElect_MH_Good.Text = "";
            rnTxtElect_MH_Fair.Text = "";
            rnTxtElect_MH_Poor.Text = "";
        }
        else
        {
            rnTxtElect_MH_Good.Text = "0";
            rnTxtElect_MH_Fair.Text = "0";
            rnTxtElect_MH_Poor.Text = "0";
        }
    }

    protected void ChkSTC_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSTC_MH.Checked;
        rntxtSTC_MH_Good.Enabled = isChecked;
        rntxtSTC_MH_Fair.Enabled = isChecked;
        rntxtSTC_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSTC_MH_Good.Text = "";
            rntxtSTC_MH_Fair.Text = "";
            rntxtSTC_MH_Poor.Text = "";
        }
        else
        {
            rntxtSTC_MH_Good.Text = "0";
            rntxtSTC_MH_Fair.Text = "0";
            rntxtSTC_MH_Poor.Text = "0";
        }
    }

    protected void ChkLight_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkLight.Checked;
        txtLightLocation.Enabled = isChecked;
        rntxtLightGood.Enabled = isChecked;
        rntxtLightFair.Enabled = isChecked;
        rntxtLightPoor.Enabled = isChecked;
        //rntxtLightCount.Enabled = isChecked;

        if (!isChecked)
        {
            txtLightLocation.Text = "";
            rntxtLightGood.Text = "0";
            rntxtLightFair.Text = "0";
            rntxtLightPoor.Text = "0";
            //rntxtLightCount.Text = "";
        }
        else
        {
            //rntxtLightCount.Text = "0";
            rntxtLightGood.Text = "0";
            rntxtLightFair.Text = "0";
            rntxtLightPoor.Text = "0";
        }
    }

    private bool DataAreValid()
    {
        if (ChkDrinage_CBs.Checked && (string.IsNullOrEmpty(rntxtDrinage_CBGood.Text) && string.IsNullOrEmpty(rntxtDrinage_CBFair.Text) && string.IsNullOrEmpty(rntxtDrinage_CBPoor.Text)))
        {
            rntxtDrinage_CBGood.Focus();
            throw new Exception("الرجاء إدخال عدد مصائد السيول ");
        }
        else if (ChkDrinage_MH.Checked && (string.IsNullOrEmpty(rntxtDrinage_MH_Good.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_Fair.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_Poor.Text)))
        {
            rntxtDrinage_MH_Poor.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل السيول ");
        }
        else if (ChkSewage_MH.Checked && (string.IsNullOrEmpty(rntxtSewage_MH_Good.Text) && string.IsNullOrEmpty(rntxtSewage_MH_Fair.Text) && string.IsNullOrEmpty(rntxtSewage_MH_Poor.Text)))
        {
            rntxtSewage_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الصرف الصحي ");
        }
        else if (ChkElect_MH.Checked && (string.IsNullOrEmpty(rnTxtElect_MH_Good.Text) && string.IsNullOrEmpty(rnTxtElect_MH_Fair.Text) && string.IsNullOrEmpty(rnTxtElect_MH_Poor.Text)))
        {
            rnTxtElect_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الكهرياء ");
        }
        else if (ChkSTC_MH.Checked && (string.IsNullOrEmpty(rntxtSTC_MH_Good.Text) && string.IsNullOrEmpty(rntxtSTC_MH_Fair.Text) && string.IsNullOrEmpty(rntxtSTC_MH_Poor.Text)))
        {
            rntxtSTC_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الهاتف ");
        }
        else if (ChkWater_MH.Checked && (string.IsNullOrEmpty(rnTxtWater_MH_Good.Text) && string.IsNullOrEmpty(rnTxtWater_MH_Fair.Text) && string.IsNullOrEmpty(rnTxtWater_MH_Poor.Text)))
        {
            rnTxtWater_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل المياه ");
        }
        else if (chkConcreteBlocks.Checked && string.IsNullOrEmpty(rntxtConcreteBlocks.Text))
        {
            rntxtConcreteBlocks.Focus();
            throw new Exception("الرجاء إدخال عدد الحواجز الخرسانية ");
        }
        else if (chkDrillingElec.Checked && string.IsNullOrEmpty(rntxtDrillingElec.Text))
        {
            rntxtDrillingElec.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الكهرباء ");
        }
        else if (chkDrillingSewage.Checked && string.IsNullOrEmpty(rntxtDrillingSewage.Text))
        {
            rntxtDrillingSewage.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الصرف الصحي ");
        }
        else if (chkDrillingSTC.Checked && string.IsNullOrEmpty(rntxtDrillingSTC.Text))
        {
            rntxtDrillingSTC.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الاتصالات ");
        }
        else if (chkDrillingWater.Checked && string.IsNullOrEmpty(rntxtDrillingWater.Text))
        {
            rntxtDrillingWater.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات المياه ");
        }
        else if (ChkLight.Checked && string.IsNullOrEmpty(txtLightLocation.Text))
        {
            txtLightLocation.Focus();
            throw new Exception("الرجاء إدخال موقع الإنارة");
        }
        else if (ChkLight.Checked && ((string.IsNullOrEmpty(rntxtLightGood.Text) || string.IsNullOrEmpty(rntxtLightFair.Text) || string.IsNullOrEmpty(rntxtLightPoor.Text))
                                    || (rntxtLightGood.Text == "0" && rntxtLightFair.Text == "0" && rntxtLightPoor.Text == "0"))
            )
        {
            rntxtLightGood.Focus();
            throw new Exception("الرجاء إدخال عدد أعمدة الإنارة ");
        }
        else if (chkOtherUtils.Checked && string.IsNullOrEmpty(txtOtherDetails.Text))
        {
            txtOtherDetails.Focus();
            throw new Exception("الرجاء ذكر الاستخدامات الأخرى");
        }
        else
            return true;
    }


    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblFeedbackInsert.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (!DataAreValid())
                return;

            if (new Region().CheckRegionSurveyorNotSaved(int.Parse(ddlRegions.SelectedValue)))
            {
                lblFeedback.Text = "الرجاء تسجيل بيانات المسح أولا ومن ثم حفظ البيانات الوصفية";

                gvSurveyorJob.DataBind();
                pnlSurveyor.Visible = true;
                pnlSecondarySt.Visible = false;
            }

            bool saved = new SecondaryStreets().Update(txtSecondStArName.Text, rntxtLength.Text, rntxtWidth.Text, rntxtUnpavedLength.Text, ChkLight.Checked, txtLightLocation.Text,
                ChkHousing.Checked, ChkCommercial.Checked, ChkPublics.Checked, ChkGarden.Checked, ChkIndisterial.Checked, ChkRest_House.Checked, chkNewlyBuilt.Checked,
                chkSchools.Checked, chkHospital.Checked, chkMasjid.Checked, chkSport.Checked, chkOtherUtils.Checked, txtOtherDetails.Text, ChkDrinage_MH.Checked,
                rntxtDrinage_MH_Good.Text, ChkDrinage_CBs.Checked, rntxtDrinage_CBGood.Text, ChkSewage_MH.Checked, rntxtSewage_MH_Good.Text, ChkElect_MH.Checked,
                rnTxtElect_MH_Good.Text, ChkSTC_MH.Checked, rntxtSTC_MH_Good.Text, ChkWater_MH.Checked, rnTxtWater_MH_Good.Text, chkSpeedBumps.Checked, chkLegal.Checked,
                chkIllegal.Checked, rntxtSpeedBumpsCount.Text, int.Parse(ddlRegionSecondaryStreets.SelectedValue), Session["UserName"].ToString(), chkConcreteBlocks.Checked,
                rntxtConcreteBlocks.Text, chkDrillingSTC.Checked, chkDrillingElec.Checked, chkDrillingWater.Checked, chkDrillingSewage.Checked, rntxtDrillingSTC.Text,
                rntxtDrillingElec.Text, rntxtDrillingWater.Text, rntxtDrillingSewage.Text, rntxtDrinage_CBFair.Text, rntxtDrinage_CBPoor.Text, rntxtDrinage_MH_Fair.Text,
                rntxtDrinage_MH_Poor.Text, rnTxtElect_MH_Fair.Text, rnTxtElect_MH_Poor.Text, rntxtSTC_MH_Fair.Text, rntxtSTC_MH_Poor.Text, rntxtSewage_MH_Fair.Text,
                rntxtSewage_MH_Poor.Text, rnTxtWater_MH_Fair.Text, rnTxtWater_MH_Poor.Text, chkMidGood.Checked, chkMidFair.Checked, chkMidPoor.Checked, chkSideGood.Checked,
                chkSideFair.Checked, chkSidePoor.Checked, int.Parse(ddlSpeedBumpType.SelectedValue), rntxtLightGood.Text, rntxtLightFair.Text, rntxtLightPoor.Text, txtNotes.Text,
                ChkMidIsland.Checked, ChkSideWalk.Checked, rdtpSurveyDate.SelectedDate);


            //rntxtLightCount.Text,
            lblFeedback.Text = saved ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
            lblFeedbackInsert.Text = lblFeedback.Text;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
            lblFeedbackInsert.Text = lblFeedback.Text;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        ddlRegionSecondaryStreets_SelectedIndexChanged(sender, e);
    }

    protected void chkSpeedBumps_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkSpeedBumps.Checked;
        chkLegal.Enabled = isChecked;
        chkIllegal.Enabled = isChecked;
        rntxtSpeedBumpsCount.Enabled = isChecked;
        ddlSpeedBumpType.Enabled = isChecked;

        if (!isChecked)
        {
            chkLegal.Checked = false;
            chkIllegal.Checked = false;

            rntxtSpeedBumpsCount.Text = "";
            ddlSpeedBumpType.SelectedValue = "0";
        }
    }

    protected void lbtnSearch_Click(object sender, EventArgs e)
    {
        SearchRegion1.Visible = true;
    }

    protected void OnSetSearchChanged()
    {
        try
        {
            int selectedID = SearchRegion1.SelectedRegionID;
            if (selectedID != 0)
            {
                ddlRegions.SelectedValue = selectedID.ToString();
                ddlRegions_SelectedIndexChanged(new Object(), new EventArgs());
                SearchRegion1.Visible = false;
            }
            else
            {
                SearchRegion1.Visible = false;
                ddlRegions.SelectedValue = "0";
                ddlRegions_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void chkDrillingSTC_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingSTC.Checked;
        rntxtDrillingSTC.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingSTC.Text = "";
    }

    protected void chkDrillingWater_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingWater.Checked;
        rntxtDrillingWater.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingWater.Text = "";
    }

    protected void chkDrillingElec_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingElec.Checked;
        rntxtDrillingElec.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingElec.Text = "";
    }

    protected void chkDrillingSewage_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingSewage.Checked;
        rntxtDrillingSewage.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingSewage.Text = "";
    }

    protected void chkConcreteBlocks_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkConcreteBlocks.Checked;
        rntxtConcreteBlocks.Enabled = isChecked;

        if (!isChecked)
            rntxtConcreteBlocks.Text = "";
    }

    protected void ChkMidIsland_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkMidIsland.Checked;
        chkMidGood.Enabled = isChecked;
        chkMidFair.Enabled = isChecked;
        chkMidPoor.Enabled = isChecked;

        if (!isChecked)
        {
            chkMidGood.Checked = false;
            chkMidFair.Checked = false;
            chkMidPoor.Checked = false;
        }
    }

    protected void ChkSideWalk_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSideWalk.Checked;
        chkSideGood.Enabled = isChecked;
        chkSideFair.Enabled = isChecked;
        chkSidePoor.Enabled = isChecked;

        if (!isChecked)
        {
            chkSideGood.Checked = false;
            chkSideFair.Checked = false;
            chkSidePoor.Checked = false;
        }
    }


    private void BoldUnBoldLinks(int i)
    {
        lnkDetails.Font.Bold = (i == 1);
        lnkAg.Font.Bold = (i == 2);
        lnkIslands.Font.Bold = (i == 3);
        lnkUses.Font.Bold = (i == 4);
        lnkMainholes.Font.Bold = (i == 5);
        lnkDrills.Font.Bold = (i == 6);
        lnkSurveyor.Font.Bold = (i == 7);
    }

    protected void lnkDetails_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 0;
        BoldUnBoldLinks(1);
    }

    protected void lnkAg_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 1;
        BoldUnBoldLinks(2);
    }

    protected void lnkIslands_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 2;
        BoldUnBoldLinks(3);
    }

    protected void lnkUses_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 3;
        BoldUnBoldLinks(4);
    }

    protected void lnkMainholes_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 4;
        BoldUnBoldLinks(5);
    }

    protected void lnkDrills_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 5;
        BoldUnBoldLinks(6);
    }

    protected void lnkSurveyor_Click(object sender, EventArgs e)
    {
        BoldUnBoldLinks(7);

        if (int.Parse(ddlRegions.SelectedValue) != 0)
        {
            if (!pnlSurveyor.Visible)
            {
                pnlSurveyor.Visible = true;
                pnlSecondarySt.Visible = false;
                lnkSurveyor.Text = "البيانات الوصفية";
            }
            else
            {
                ddlRegionSecondaryStreets_SelectedIndexChanged(sender, e);
                lnkSurveyor.Text = "تسليم المساح";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (raddtpIssueDate.SelectedDate == null)
                throw new Exception("الرجاء إدخال تاريخ الاستلام");
            else if (raddtpDeliveryDate.SelectedDate != null && (raddtpIssueDate.SelectedDate > raddtpDeliveryDate.SelectedDate))
                throw new Exception("تاريخ التسليم لايمكن أن يكون سابقا لتاريخ الاستلام");
            else if (rntxtSurveyNo.Value == null)
                throw new Exception(Feedback.NoSurveyNum());


            bool saved = new SurveyorSubmitJob().Insert(int.Parse(ddlSurveyor.SelectedValue), raddtpIssueDate.SelectedDate, raddtpDeliveryDate.SelectedDate,
                int.Parse(rntxtSurveyNo.Text), txtNotes.Text, ddlRegions.SelectedValue, JobType.RegionSecondaryStreets);

            if (saved)
            {
                btnCancel_Click(sender, e);
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvSurveyorJob.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlSurveyor.SelectedValue = "0";
        raddtpIssueDate.SelectedDate = null;
        raddtpDeliveryDate.SelectedDate = null;

        txtNotes.Text = "";
        lblFeedback.Text = "";
        rntxtSurveyNo.Text = "1";
    }

    protected void odsSurveySubmitJobs_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.DeleteSuccessfull();
    }

    protected void odsSurveySubmitJobs_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

}