using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Sections_EditR4Street : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("R4StreetsInfo.aspx", false);

            if (!IsPostBack)
            {
                R4Streets r4 = new R4Streets();
                int id = int.Parse(Request.QueryString["id"]);
                DataTable dt = r4.GetR4LightingInfo(id);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    txtNo.Text = dr["R4_NO"].ToString();
                    txtName.Text = dr["R4_NAME"].ToString();
                    radR4Date.SelectedDate = DateTime.Parse(dr["R4_DATE"].ToString());
                    radR4OpeningDate.SelectedDate = DateTime.Parse(dr["OPENING_DATE"].ToString());
                    radR4SurveyDate.SelectedDate = DateTime.Parse(dr["SURVEY_DATE"].ToString());
                    radR4SectionsDate.SelectedDate = DateTime.Parse(dr["SECTIONS_DEFINING_DATE"].ToString());

                    ddlContractors.SelectedValue = dr["CONTRACTOR_ID"].ToString();
                    ChkHousing.Checked = bool.Parse(dr["HOUSING"].ToString());
                    chkWarehouses.Checked = bool.Parse(dr["WAREHOUSES"].ToString());
                    ChkCommercial.Checked = bool.Parse(dr["COMMERCIAL"].ToString());
                    ChkGarden.Checked = bool.Parse(dr["GARDENS"].ToString());
                    ChkIndisterial.Checked = bool.Parse(dr["INDUSTRIAL"].ToString());
                    ChkRest_House.Checked = bool.Parse(dr["REST_HOUSES"].ToString());
                    ChkPublics.Checked = bool.Parse(dr["PUBLICS"].ToString());

                    ChkDrinage_CBs.Checked = bool.Parse(dr["DRAIN_CB_TRUE"].ToString());
                    rntxtDrinage_CBCount.Text = dr["DRAIN_CB_COUNT"].ToString();
                    ChkDrinage_MH.Checked = bool.Parse(dr["DRAIN_MH_TRUE"].ToString());
                    rntxtDrinage_MHCount.Text = dr["DRAIN_MH_COUNT"].ToString();
                    ChkSewage_MH.Checked = bool.Parse(dr["SEWAGE_MH_TRUE"].ToString());
                    rntxtSewage_MHCount.Text = dr["SEWAGE_MH_COUNT"].ToString();
                    ChkElect_MH.Checked = bool.Parse(dr["ELEC_MH_TRUE"].ToString());
                    rnTxtElect_MHCount.Text = dr["ELEC_MH_COUNT"].ToString();
                    ChkSTC_MH.Checked = bool.Parse(dr["STC_MH_TRUE"].ToString());
                    rntxtSTC_MHCount.Text = dr["STC_MH_COUNT"].ToString();
                    ChkWater_MH.Checked = bool.Parse(dr["WATER_MH_TRUE"].ToString());
                    rnTxtWater_MHCount.Text = dr["WATER_MH_COUNT"].ToString();

                    chkNotPavedbyMunic.Checked = bool.Parse(dr["NOT_PAVED_BY_MUNIC"].ToString());
                    txtNotpavedByDetails.Text = dr["NOT_PAVED_BY_DETAILS"].ToString();
                    chkOwnedByMunic.Checked = bool.Parse(dr["OWNED_BY_MUNIC"].ToString());
                    txtOwnedByMunicDetails.Text = dr["OWNED_DETAILS"].ToString();

                    ddlPopulation.SelectedValue = dr["POPULATION"].ToString();
                    txtTopographic.Text = dr["TOPOGRAPHY_DETAILS"].ToString();

                    ChkMidIsland.Checked = bool.Parse(dr["NEED_MID_ISLAND"].ToString());
                    chkNeedTrees.Checked = bool.Parse(dr["NEED_TREES"].ToString());
                    chkLight.Checked = bool.Parse(dr["NEED_LIGHTING"].ToString());
                    chkInfra.Checked = bool.Parse(dr["NEED_INFRA_WORKS"].ToString());
                    chkNeedSigns.Checked = bool.Parse(dr["NEED_TRAFFIC_SIGNS"].ToString());
                    chkNeedServiceLanes.Checked = bool.Parse(dr["NEED_SERVICE_LANES"].ToString());
                    chkNeedSpeedBumps.Checked = bool.Parse(dr["NEED_SPEED_BUMPS"].ToString());
                    chkInnerWater.Checked = bool.Parse(dr["INNER_WATER"].ToString());

                    rntxtNeededlanesCount.Text = dr["NEEDED_LANES_COUNT"].ToString();
                    txtSoilType.Text = dr["SOIL_TYPE_DETAILS"].ToString();
                    txtMoreDetails.Text = dr["MORE_DETAILS"].ToString();
                    rntxtSectionLength.Text = dr["R4_LENGTH"].ToString();

                    DataTable dtLighting = r4.GetR4LightingInfo(id);
                    if (dtLighting.Rows.Count > 0)
                    {
                        dr = dtLighting.Rows[0];
                        ddlLightingContractor.SelectedValue = dr["CONTRACTOR_ID"].ToString();
                        radLightingFinishDate.SelectedDate = DateTime.Parse(dr["FINISH_DATE"].ToString());
                        txtLightingContractName.Text = dr["CONTRACT_NAME"].ToString();
                        txtLightingContractNo.Text = dr["CONTRACT_NO"].ToString();
                    }

                    DataTable dtTrees = r4.GetR4TreesInfo(id);
                    if (dtTrees.Rows.Count > 0)
                    {
                        dr = dtTrees.Rows[0];
                        ddlTreesContractor.SelectedValue = dr["CONTRACTOR_ID"].ToString();
                        rdtpTreesFinishDate.SelectedDate = DateTime.Parse(dr["FINISH_DATE"].ToString());
                        txtTreesContractName.Text = dr["CONTRACT_NAME"].ToString();
                        txtTreesContractNo.Text = dr["CONTRACT_NO"].ToString();
                    }

                    DataTable dtPaving = r4.GetR4PavingInfo(id);
                    if (dtPaving.Rows.Count > 0)
                    {
                        dr = dtPaving.Rows[0];
                        ddlPavingContractor.SelectedValue = dr["CONTRACTOR_ID"].ToString();
                        rdtpPavingFinishDate.SelectedDate = DateTime.Parse(dr["FINISH_DATE"].ToString());
                        txtpavingContractName.Text = dr["CONTRACT_NAME"].ToString();
                        txtpavingContractNo.Text = dr["CONTRACT_NO"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblFeedbackSave.Text = ex.Message;
        }
    }

    protected void ChkDrinage_CBs_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_CBs.Checked;
        rntxtDrinage_CBCount.Enabled = isChecked;

        if (!isChecked)
            rntxtDrinage_CBCount.Text = "";
    }

    protected void ChkDrinage_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_MH.Checked;
        rntxtDrinage_MHCount.Enabled = isChecked;

        if (!isChecked)
            rntxtDrinage_MHCount.Text = "";
    }

    protected void ChkSewage_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSewage_MH.Checked;
        rntxtSewage_MHCount.Enabled = isChecked;

        if (!isChecked)
            rntxtSewage_MHCount.Text = "";
    }

    protected void ChkWater_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkWater_MH.Checked;
        rnTxtWater_MHCount.Enabled = isChecked;

        if (!isChecked)
            rnTxtWater_MHCount.Text = "";
    }

    protected void ChkElect_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkElect_MH.Checked;
        rnTxtElect_MHCount.Enabled = isChecked;

        if (!isChecked)
            rnTxtElect_MHCount.Text = "";
    }

    protected void ChkSTC_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSTC_MH.Checked;
        rntxtSTC_MHCount.Enabled = isChecked;

        if (!isChecked)
            rntxtSTC_MHCount.Text = "";
    }

    private bool DataAreValid()
    {
        if (ddlMainStreets.SelectedValue == "0")
        {
            ddlMainStreets.Focus();
            throw new Exception("الرجاء اختيار الطريق الرئيسي الذي يتبع له الطريق المستحدث!");
        }
        else if (ChkDrinage_CBs.Checked && string.IsNullOrEmpty(rntxtDrinage_CBCount.Text))
        {
            rntxtDrinage_CBCount.Focus();
            throw new Exception("الرجاء إدخال عدد مصائد السيول في الطريق المستحدث");
        }
        else if (ChkDrinage_MH.Checked && string.IsNullOrEmpty(rntxtDrinage_MHCount.Text))
        {
            rntxtDrinage_MHCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل السيول في الطريق المستحدث");
        }
        else if (ChkSewage_MH.Checked && string.IsNullOrEmpty(rntxtSewage_MHCount.Text))
        {
            rntxtSewage_MHCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الصرف الصحي في االطريق المستحدث");
        }
        else if (ChkElect_MH.Checked && string.IsNullOrEmpty(rnTxtElect_MHCount.Text))
        {
            rnTxtElect_MHCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الكهرياء في الطريق المستحدث");
        }
        else if (ChkSTC_MH.Checked && string.IsNullOrEmpty(rntxtSTC_MHCount.Text))
        {
            rntxtSTC_MHCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الهاتف في الطريق المستحدث");
        }
        else if (ChkWater_MH.Checked && string.IsNullOrEmpty(rnTxtWater_MHCount.Text))
        {
            rnTxtWater_MHCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل المياه في الطريق المستحدث");
        }
        else if (chkNotPavedbyMunic.Checked && string.IsNullOrEmpty(txtNotpavedByDetails.Text))
        {
            txtNotpavedByDetails.Focus();
            throw new Exception("الرجاء إدخال تفاصيل عدم الرصف بواسطة الأمانة");
        }
        else if (chkOwnedByMunic.Checked && string.IsNullOrEmpty(txtOwnedByMunicDetails.Text))
        {
            txtNotpavedByDetails.Focus();
            throw new Exception("الرجاء إدخال تفاصيل انتقال الملكية للأمانة");
        }
        else
            return true;
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedbackSave.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (!DataAreValid())
                return;

            bool saved = new R4Streets().Update(txtNo.Text, txtName.Text, radR4Date.SelectedDate, radR4OpeningDate.SelectedDate, radR4SurveyDate.SelectedDate, radR4SectionsDate.SelectedDate,
                int.Parse(ddlContractors.SelectedValue), ChkHousing.Checked, chkWarehouses.Checked, ChkCommercial.Checked, ChkGarden.Checked, ChkIndisterial.Checked,
                ChkRest_House.Checked, ChkPublics.Checked, ChkDrinage_CBs.Checked, rntxtDrinage_CBCount.Text, ChkDrinage_MH.Checked, rntxtDrinage_MHCount.Text, ChkSewage_MH.Checked,
                rntxtSewage_MHCount.Text, ChkElect_MH.Checked, rnTxtElect_MHCount.Text, ChkSTC_MH.Checked, rntxtSTC_MHCount.Text, ChkWater_MH.Checked, rnTxtWater_MHCount.Text,
                chkNotPavedbyMunic.Checked, txtNotpavedByDetails.Text, chkOwnedByMunic.Checked, txtOwnedByMunicDetails.Text, ddlPopulation.SelectedValue[0], txtTopographic.Text,
                ChkMidIsland.Checked, chkNeedTrees.Checked, chkLight.Checked, chkInfra.Checked, chkNeedSigns.Checked, chkNeedServiceLanes.Checked, chkNeedSpeedBumps.Checked,
                rntxtNeededlanesCount.Text, chkInnerWater.Checked, txtSoilType.Text, txtMoreDetails.Text, int.Parse(ddlLightingContractor.SelectedValue), radLightingFinishDate.SelectedDate, 
                txtLightingContractName.Text, txtLightingContractNo.Text, int.Parse(ddlTreesContractor.SelectedValue), rdtpTreesFinishDate.SelectedDate, txtTreesContractName.Text, 
                txtTreesContractNo.Text, int.Parse(ddlPavingContractor.SelectedValue), rdtpPavingFinishDate.SelectedDate, txtpavingContractName.Text, txtpavingContractNo.Text, 
                rntxtSectionLength.Text, int.Parse(Request.QueryString["id"]), int.Parse(ddlMainStreets.SelectedValue));

            lblFeedbackSave.Text = (saved) ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
        }
        catch (Exception ex)
        {
            lblFeedbackSave.Text = ex.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        string url = string.Format("EditR4Street.aspx?id={0}", Request.QueryString["id"]);
        Response.Redirect(url, false);
    }

}
