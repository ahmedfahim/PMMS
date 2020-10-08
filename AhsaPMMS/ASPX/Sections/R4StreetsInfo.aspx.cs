using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Sections_R4StreetsInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
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

            bool saved = new R4Streets().Insert(txtNo.Text, txtName.Text, radR4Date.SelectedDate, radR4OpeningDate.SelectedDate, radR4SurveyDate.SelectedDate, radR4SectionsDate.SelectedDate,
                int.Parse(ddlContractors.SelectedValue), ChkHousing.Checked, chkWarehouses.Checked, ChkCommercial.Checked, ChkGarden.Checked, ChkIndisterial.Checked,
                ChkRest_House.Checked, ChkPublics.Checked, ChkDrinage_CBs.Checked, rntxtDrinage_CBCount.Text, ChkDrinage_MH.Checked, rntxtDrinage_MHCount.Text, ChkSewage_MH.Checked,
                rntxtSewage_MHCount.Text, ChkElect_MH.Checked, rnTxtElect_MHCount.Text, ChkSTC_MH.Checked, rntxtSTC_MHCount.Text, ChkWater_MH.Checked, rnTxtWater_MHCount.Text,
                chkNotPavedbyMunic.Checked, txtNotpavedByDetails.Text, chkOwnedByMunic.Checked, txtOwnedByMunicDetails.Text, ddlPopulation.SelectedValue[0], txtTopographic.Text,
                ChkMidIsland.Checked, chkNeedTrees.Checked, chkLight.Checked, chkInfra.Checked, chkNeedSigns.Checked, chkNeedServiceLanes.Checked, chkNeedSpeedBumps.Checked,
                rntxtNeededlanesCount.Text, chkInnerWater.Checked, txtSoilType.Text, txtMoreDetails.Text, int.Parse(ddlLightingContractor.SelectedValue),
                radLightingFinishDate.SelectedDate, txtLightingContractName.Text, txtLightingContractNo.Text, int.Parse(ddlTreesContractor.SelectedValue), rdtpTreesFinishDate.SelectedDate, 
                txtTreesContractName.Text, txtTreesContractNo.Text, int.Parse(ddlPavingContractor.SelectedValue), rdtpPavingFinishDate.SelectedDate, txtpavingContractName.Text, 
                txtpavingContractNo.Text, rntxtSectionLength.Text, int.Parse(ddlMainStreets.SelectedValue));

            if (saved)
            {
                lblFeedbackSave.Text = Feedback.InsertSuccessfull();
                gvR4Streets.DataBind();
            }
            else
                lblFeedbackSave.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedbackSave.Text = ex.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("R4StreetsInfo.aspx", false);
    }

    protected void odsR4StreetsInfo_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedbackSave.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedbackSave.Text = Feedback.DeleteSuccessfull();
    }


    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlMainStreets.SelectedValue != "0")
            {
                string[] value = ddlMainStreets.SelectedItem.Text.Split('-');
                if (value.Length > 0)
                {
                    txtNo.Text = value[0].Trim();
                    txtName.Text = value[1].Trim();
                }
                else
                {
                    txtNo.Text = "";
                    txtName.Text = "";
                }
            }
            else
            {
                txtNo.Text = "";
                txtName.Text = "";
            }

        }
        catch (Exception ex)
        {
            lblFeedbackSave.Text = ex.Message;
        }
    }

}
