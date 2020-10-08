using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Sections_SectionInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }


    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreetSection.Items.Clear();
            ddlMainStreetSection.Items.Add(new ListItem("اختيار", "0"));
            ddlMainStreetSection.DataBind();
            ddlMainStreetSection.SelectedValue = "0";

            ddlMainStreetSection_SelectedIndexChanged(sender, e);
            lblOwnershipDetails.Text = MainStreet.GetOwnerShipStatus(int.Parse(ddlMainStreets.SelectedValue));
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }


    private void HasTunnelsBridges()
    {
        bool hasTunnel = chkBridges.Checked | ChkTunnel.Checked;
        //bool hasBridge = ((CheckBox)frvIntersectionsEd.FindControl("ChkBridge")).Checked;

        txtBrdg_TUNEL_TYPE.Enabled = hasTunnel; //|| hasBridge;
        if (!hasTunnel)  //&& !hasBridge)
            txtBrdg_TUNEL_TYPE.Text = "";

        if (chkBridges.Checked)
        {
            hlnkBridges.Visible = true;
            hlnkBridges.NavigateUrl = string.Format("Bridges.aspx?sectionID={0}", int.Parse(ddlMainStreetSection.SelectedValue));
        }
        else
            hlnkBridges.Visible = false;

        if (ChkTunnel.Checked)
        {
            hlnkTunnels.Visible = true;
            hlnkTunnels.NavigateUrl = string.Format("Tunnels.aspx?sectionID={0}", int.Parse(ddlMainStreetSection.SelectedValue));
        }
        else
            hlnkTunnels.Visible = false;
    }




    protected void chkSoilParts_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkSoilParts.Checked;
        rntxtUnpavedLength.Enabled = isChecked;
        rntxtUnpavedWidth.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtUnpavedLength.Text = "";
            rntxtUnpavedWidth.Text = "";
        }
    }

    protected void ChkMidIsland_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkMidIsland.Checked;
        rntxtMidIsWidth.Enabled = isChecked;
        chkMidGood.Enabled = isChecked;
        chkMidFair.Enabled = isChecked;
        chkMidPoor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtMidIsWidth.Text = "";
            chkMidGood.Checked = false;
            chkMidFair.Checked = false;
            chkMidPoor.Checked = false;
        }
    }

    protected void ChkSideIsland_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSideIsland.Checked;
        rntxtSideIsWidth.Enabled = isChecked;
        chkSideLGood.Enabled = isChecked;
        chkSideLFair.Enabled = isChecked;
        chkSideLPoor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSideIsWidth.Text = "";
            chkSideLGood.Checked = false;
            chkSideLFair.Checked = false;
            chkSideLPoor.Checked = false;
        }
    }

    protected void ChkSideWalk_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSideWalk.Checked;
        rntxtSideWalkWidth.Enabled = isChecked;
        chkSideGood.Enabled = isChecked;
        chkSideFair.Enabled = isChecked;
        chkSidePoor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSideWalkWidth.Text = "";
            chkSideGood.Checked = false;
            chkSideFair.Checked = false;
            chkSidePoor.Checked = false;
        }
    }

    protected void ChkLight_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkLight.Checked;
        txtLightLocation.Enabled = isChecked;
        //chkLightGood.Enabled = isChecked;
        //rntxtLightCount.Enabled = isChecked;
        chkPropertyConflict.Enabled = isChecked;
        rntxtLightControlsCount.Enabled = isChecked;
        rntxtLightGood.Enabled = isChecked;
        rntxtLightFair.Enabled = isChecked;
        rntxtLightPoor.Enabled = isChecked;
        //chkLightFair.Enabled = isChecked;
        //chkLightPoor.Enabled = isChecked;

        if (!isChecked)
        {
            txtLightLocation.Text = "";
            //chkLightGood.Checked = false;
            chkPropertyConflict.Checked = false;

            //chkLightFair.Checked = false;
            //chkLightPoor.Checked = false;

            //rntxtLightCount.Text = "";
            rntxtLightControlsCount.Text = "0";
            rntxtLightGood.Text = "0";
            rntxtLightFair.Text = "0";
            rntxtLightPoor.Text = "0";
        }
    }

    protected void ChkTunnel_CheckedChanged(object sender, EventArgs e)
    {
        HasTunnelsBridges();
    }

    protected void ChkBridge_CheckedChanged(object sender, EventArgs e)
    {
        HasTunnelsBridges();
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

    protected void frvIntersectionsEd_DataBound(object sender, EventArgs e)
    {
        if (ddlMainStreetSection.SelectedValue != "0")
        {
            chkSoilParts_CheckedChanged(sender, e);
            ChkMidIsland_CheckedChanged(sender, e);
            ChkSideIsland_CheckedChanged(sender, e);
            ChkSideWalk_CheckedChanged(sender, e);
            ChkLight_CheckedChanged(sender, e);

            ChkTunnel_CheckedChanged(sender, e);
            ChkBridge_CheckedChanged(sender, e);

            ChkDrinage_CBs_CheckedChanged(sender, e);
            ChkDrinage_MH_CheckedChanged(sender, e);
            ChkSewage_MH_CheckedChanged(sender, e);
            ChkWater_MH_CheckedChanged(sender, e);
            ChkElect_MH_CheckedChanged(sender, e);
            ChkSTC_MH_CheckedChanged(sender, e);
        }
    }

    protected void frvIntersectionsEd_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    private MainStreetSection section;


    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblFeedbackSave.Text = "";
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (!DataAreValid())
                return;

            section = new MainStreetSection();
            if (chkMultilevel.Checked)
            {
                // check that section must have bridges or tunnels, if not, user must enter information for a tunnel or bridge, otherwise, save info
                if (section.InvalidMultilevelSection(int.Parse(ddlMainStreetSection.SelectedValue)))
                    throw new Exception("بما أن هذا المقطع متعدد المستويات فيرجى تحديد وجود جسور أو أنفاق في هذا المقطع ومن ثم إدخال بياناتها");
            }
            else if (section.CheckSectionSurveyorNotSaved(int.Parse(ddlMainStreetSection.SelectedValue)))
            {
                lnkSurveyor_Click(sender, e);
                throw new Exception("الرجاء تسجيل بيانات المسح أولا ومن ثم حفظ البيانات الوصفية");
            }


            // int.Parse(ddlMainStreetSection.SelectedValue), chkLightGood.Checked, chkLightFair.Checked, chkLightPoor.Checked,  rntxtLightCount.Text, Session["UserName"].ToString(),
            bool saved = section.UpdateSectionInfo(ddlDirection.SelectedValue, decimal.Parse(rntxtSectionWidth.Text), decimal.Parse(rntxtSectionLength.Text), ChkHousing.Checked,
                ChkPublics.Checked, ChkCommercial.Checked, ChkGarden.Checked, ChkIndisterial.Checked, ChkRest_House.Checked, chkSoilParts.Checked, rntxtUnpavedLength.Text,
                rntxtUnpavedWidth.Text, ChkMidIsland.Checked, rntxtMidIsWidth.Text, ChkSideIsland.Checked, rntxtSideIsWidth.Text, ChkSideWalk.Checked, rntxtSideWalkWidth.Text,
                ChkLight.Checked, txtLightLocation.Text, chkBridges.Checked, txtBrdg_TUNEL_TYPE.Text, ChkAg_MID.Checked, ChkAg_SID.Checked, ChkAg_SEC.Checked, ChkDrinage_MH.Checked,
                rntxtDrinage_MH_Good.Text, ChkDrinage_CBs.Checked, rntxtDrinage_CBGood.Text, ChkSewage_MH.Checked, rntxtSewage_MH_Good.Text, ChkElect_MH.Checked, rnTxtElect_MH_Good.Text,
                ChkSTC_MH.Checked, rntxtSTC_MH_Good.Text, ChkWater_MH.Checked, rnTxtWater_MH_Good.Text, ChkIntersection_Open.Checked, ChkIntersection_TL.Checked,
                int.Parse(rntxtSectionOrder.Text), int.Parse(ddlMainStreetSection.SelectedValue), chkDrillingSTC.Checked, chkDrillingElec.Checked, chkDrillingWater.Checked,
                chkDrillingSewage.Checked, rntxtDrillingSTC.Text, rntxtDrillingElec.Text, rntxtDrillingWater.Text, rntxtDrillingSewage.Text, chkR4.Checked, chkR3.Checked,
                rdtpR4Date.SelectedDate, rdtpR3Date.SelectedDate, rntxtDrinage_CBFair.Text, rntxtDrinage_CBPoor.Text, rntxtDrinage_MH_Fair.Text, rntxtDrinage_MH_Poor.Text,
                rnTxtElect_MH_Fair.Text, rnTxtElect_MH_Poor.Text, rntxtSTC_MH_Fair.Text, rntxtSTC_MH_Poor.Text, rntxtSewage_MH_Fair.Text, rntxtSewage_MH_Poor.Text, rnTxtWater_MH_Fair.Text,
                rnTxtWater_MH_Poor.Text, chkMidGood.Checked, chkMidFair.Checked, chkMidPoor.Checked, chkSideGood.Checked, chkSideFair.Checked, chkSidePoor.Checked,
                chkPropertyConflict.Checked, rntxtMegacomCount.Text, rntxtMobyCount.Text, rntxtUnipoleCount.Text, rntxtLightControlsCount.Text, chkMultilevel.Checked,
                chkSideLGood.Checked, chkSideLFair.Checked, chkSideLPoor.Checked, chkPavemarkers.Checked, chkMarkerPaints.Checked, chkMarkerCeramics.Checked, chkPavedbyMunic.Checked,
                txtNotpavedByDetails.Text, chkOwnedByMunic.Checked, txtOwnedByMunicDetails.Text, chkWalkerBridges.Checked, int.Parse(ddlwalkerBridgeType.SelectedValue),
                rntxtWalkerBridgesCount.Text, chkBorderOthers.Checked, txtSectionBorderType.Text, rdtpSurveyDate.SelectedDate, rntxtLightGood.Text, rntxtLightFair.Text,
                rntxtLightPoor.Text, rntxtGuideSignsCount.Text, int.Parse(Session["UserID"].ToString()), Session["UserName"].ToString());

            lblFeedback.Text = saved ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
            lblFeedbackSave.Text = lblFeedback.Text;
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
            lblFeedbackSave.Text = lblFeedback.Text;
        }
    }



    private bool DataAreValid()
    {
        if (ChkMidIsland.Checked && string.IsNullOrEmpty(rntxtMidIsWidth.Text))
        {
            rntxtMidIsWidth.Focus();
            throw new Exception("الرجاء إدخال عرض الجزيرة الوسطية في الشارع/الطريق الرئيسي");
        }
        else if (ChkSideIsland.Checked && string.IsNullOrEmpty(rntxtSideIsWidth.Text))
        {
            rntxtSideIsWidth.Focus();
            throw new Exception("الرجاء إدخال عرض الجزيرة الفاصلة في الشارع/الطريق الرئيسي");
        }
        else if (ChkSideWalk.Checked && string.IsNullOrEmpty(rntxtSideWalkWidth.Text))
        {
            rntxtSideWalkWidth.Focus();
            throw new Exception("الرجاء إدخال عرض الرصيف الجانبي في الشارع/الطريق الرئيسي");
        }

        else if ((chkBridges.Checked || ChkTunnel.Checked) && string.IsNullOrEmpty(txtBrdg_TUNEL_TYPE.Text))
        {
            txtBrdg_TUNEL_TYPE.Focus();
            throw new Exception("الرجاء إدخال تفاصيل الجسر/النفق");
        }

        else if (ChkLight.Checked && string.IsNullOrEmpty(txtLightLocation.Text))
        {
            txtBrdg_TUNEL_TYPE.Focus();
            throw new Exception("الرجاء إدخال موقع الإنارة في الشارع/الطريق الرئيسي");
        }

        else if (chkSoilParts.Checked && string.IsNullOrEmpty(rntxtUnpavedLength.Text))
        {
            rntxtUnpavedLength.Focus();
            throw new Exception("الرجاء إدخال طول الجزء الترابي في الشارع/الطريق الرئيسي");
        }
        else if (chkSoilParts.Checked && string.IsNullOrEmpty(rntxtUnpavedWidth.Text))
        {
            rntxtUnpavedWidth.Focus();
            throw new Exception("الرجاء إدخال عرض الجزء الترابي في الشارع/الطريق الرئيسي");
        }

        else if (ChkDrinage_CBs.Checked && (string.IsNullOrEmpty(rntxtDrinage_CBGood.Text) && string.IsNullOrEmpty(rntxtDrinage_CBFair.Text) && string.IsNullOrEmpty(rntxtDrinage_CBPoor.Text)))
        {
            rntxtDrinage_CBGood.Focus();
            throw new Exception("الرجاء إدخال عدد مصائد السيول في الشارع/الطريق الرئيسي");
        }
        else if (ChkDrinage_MH.Checked && (string.IsNullOrEmpty(rntxtDrinage_MH_Good.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_Fair.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_Poor.Text)))
        {
            rntxtDrinage_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل السيول في الشارع/الطريق الرئيسي");
        }
        else if (ChkSewage_MH.Checked && (string.IsNullOrEmpty(rntxtSewage_MH_Good.Text) && string.IsNullOrEmpty(rntxtSewage_MH_Fair.Text) && string.IsNullOrEmpty(rntxtSewage_MH_Poor.Text)))
        {
            rntxtSewage_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الصرف الصحي في الشارع/الطريق الرئيسي");
        }
        else if (ChkElect_MH.Checked && (string.IsNullOrEmpty(rnTxtElect_MH_Good.Text) && string.IsNullOrEmpty(rnTxtElect_MH_Fair.Text) && string.IsNullOrEmpty(rnTxtElect_MH_Poor.Text)))
        {
            rnTxtElect_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الكهرياء في الشارع/الطريق الرئيسي");
        }
        else if (ChkSTC_MH.Checked && (string.IsNullOrEmpty(rntxtSTC_MH_Good.Text) && string.IsNullOrEmpty(rntxtSTC_MH_Fair.Text) && string.IsNullOrEmpty(rntxtSTC_MH_Poor.Text)))
        {
            rntxtSTC_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الهاتف في الشارع/الطريق الرئيسي");
        }
        else if (ChkWater_MH.Checked && (string.IsNullOrEmpty(rnTxtWater_MH_Good.Text) && string.IsNullOrEmpty(rnTxtWater_MH_Fair.Text) && string.IsNullOrEmpty(rnTxtWater_MH_Poor.Text)))
        {
            rnTxtWater_MH_Good.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل المياه في الشارع/الطريق الرئيسي");
        }
        if (chkR4.Checked && rdtpR4Date.SelectedDate == null)
        {
            rdtpR4Date.Focus();
            throw new Exception("الرجاء إدخال تاريخ الاستحداث");
        }
        else if (chkDrillingElec.Checked && string.IsNullOrEmpty(rntxtDrillingElec.Text))
        {
            rntxtDrillingElec.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الكهرباء");
        }
        else if (chkDrillingSewage.Checked && string.IsNullOrEmpty(rntxtDrillingSewage.Text))
        {
            rntxtDrillingSewage.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الصرف الصحي");
        }
        else if (chkDrillingSTC.Checked && string.IsNullOrEmpty(rntxtDrillingSTC.Text))
        {
            rntxtDrillingSTC.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الهاتف");
        }
        else if (chkDrillingWater.Checked && string.IsNullOrEmpty(rntxtDrillingWater.Text))
        {
            rntxtDrillingWater.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات المياه");
        }
        else if (chkWalkerBridges.Checked && (string.IsNullOrEmpty(rntxtWalkerBridgesCount.Text) || ddlwalkerBridgeType.SelectedValue == "0"))
        {
            ddlwalkerBridgeType.Focus();
            throw new Exception("الرجاء إدخال عدد ونوع جسور المشاة بالشارع/الطريق الرئيسي");
        }
        else if (string.IsNullOrEmpty(rntxtSectionOrder.Text))
        {
            rntxtSectionOrder.Focus();
            throw new Exception("الرجاء إدخال ترتيب المقطع");
        }
        else
            return true;
    }


    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        ddlMainStreetSection_SelectedIndexChanged(sender, e);
    }

    protected void rntxtSectionWidth_TextChanged(object sender, EventArgs e)
    {
        if (rntxtSectionLength.Value != null && rntxtSectionWidth.Value != null)
            rntxtSectionArea.Value = rntxtSectionLength.Value * rntxtSectionWidth.Value;
    }

    protected void ddlMainStreetSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblFeedbackSave.Text = lblFeedback.Text;

            int id = int.Parse(ddlMainStreetSection.SelectedValue);
            if (id != 0)
            {
                DataTable dt = new MainStreetSection().GetSectionInfo(id);
                if (dt.Rows.Count > 0)
                {
                    mlvSectionInfo.Visible = false;
                    pnlSamplesLanes.Visible = false;
                    pnlSectionInfo.Visible = false;
                    DataRow dr = dt.Rows[0];

                    mlvSectionInfo.Visible = true;
                    pnlSectionInfo.Visible = true;
                    pnlSamplesLanes.Visible = true;

                    //lblID.Text = id.ToString();

                    #region 0
                    mlvSectionInfo.ActiveViewIndex = 0;
                    lnkGallery.NavigateUrl = string.Format("SectionImages.aspx?sectionID={0}", id);
                    lblSubMunicip.Text = dr["MUNICIPALITY"].ToString();
                    lblDistrict.Text = dr["DISTRICT"].ToString();
                    lblSectionNo.Text = dr["SECTION_NO"].ToString();
                    lblMainStName.Text = dr["main_st_title"].ToString();
                    lblSectionFrom.Text = dr["FROM_STREET"].ToString();
                    lblSectionTo.Text = dr["TO_STREET"].ToString();

                    ddlDirection.SelectedValue = dr["SEC_DIRECTION"].ToString();
                    rntxtSectionOrder.Text = dr["SEC_ORDER"].ToString();

                    rntxtSectionWidth.Value = double.Parse(dr["SEC_WIDTH"].ToString());
                    rntxtSectionLength.Value = double.Parse(dr["SEC_LENGTH"].ToString());
                    rntxtSectionWidth_TextChanged(sender, e);

                    chkR3.Checked = bool.Parse(dr["IS_R3"].ToString());
                    chkR4.Checked = bool.Parse(dr["IS_R4"].ToString());

                    if (!string.IsNullOrEmpty(dr["R3_DATE"].ToString()))
                    {
                        rdtpR3Date.Enabled = true;
                        rdtpR3Date.SelectedDate = DateTime.Parse(dr["R3_DATE"].ToString());
                    }
                    else
                    {
                        rdtpR3Date.Enabled = false;
                        rdtpR3Date.SelectedDate = null;
                    }

                    if (!string.IsNullOrEmpty(dr["R4_DATE"].ToString()))
                    {
                        rdtpR4Date.Enabled = true;
                        rdtpR4Date.SelectedDate = DateTime.Parse(dr["R4_DATE"].ToString());
                    }
                    else
                    {
                        rdtpR4Date.Enabled = false;
                        rdtpR4Date.SelectedDate = null;
                    }

                    if (string.IsNullOrEmpty(dr["SURVEY_DATE"].ToString()))
                        rdtpSurveyDate.SelectedDate = null;
                    else
                        rdtpSurveyDate.SelectedDate = DateTime.Parse(dr["SURVEY_DATE"].ToString());


                    chkPavedbyMunic.Checked = bool.Parse(dr["PAVED_BY_MUNIC"].ToString());
                    chkOwnedByMunic.Checked = bool.Parse(dr["OWNED_BY_MUNIC"].ToString());

                    txtNotpavedByDetails.Text = dr["NOT_PAVED_BY_DETAILS"].ToString();
                    txtOwnedByMunicDetails.Text = dr["OWNED_DETAILS"].ToString();

                    #endregion

                    #region 1
                    mlvSectionInfo.ActiveViewIndex = 1;
                    chkSoilParts.Checked = bool.Parse(dr["unpaved_True"].ToString());
                    chkSoilParts_CheckedChanged(sender, e);
                    rntxtUnpavedLength.Text = dr["unpaved_length"].ToString();
                    rntxtUnpavedWidth.Text = dr["unpaved_Width"].ToString();

                    ChkAg_MID.Checked = bool.Parse(dr["ag_mid_island_True"].ToString());
                    ChkAg_SID.Checked = bool.Parse(dr["ag_sid_island_True"].ToString());
                    ChkAg_SEC.Checked = bool.Parse(dr["ag_sec_island_true"].ToString());

                    chkPavemarkers.Checked = bool.Parse(dr["PAV_MARKERS_TRUE"].ToString());
                    chkPavemarkers_CheckedChanged(sender, e);
                    chkMarkerCeramics.Checked = bool.Parse(dr["MARKER_CERAMIC"].ToString());
                    chkMarkerPaints.Checked = bool.Parse(dr["MARKER_PAINT"].ToString());
                    #endregion

                    #region 2
                    mlvSectionInfo.ActiveViewIndex = 2;
                    ChkMidIsland.Checked = bool.Parse(dr["mid_island_True"].ToString());
                    ChkMidIsland_CheckedChanged(sender, e);
                    rntxtMidIsWidth.Text = dr["mid_island_width"].ToString();

                    chkMidGood.Checked = bool.Parse(dr["MID_ISLAND_GOOD"].ToString());
                    chkMidFair.Checked = bool.Parse(dr["MID_ISLAND_FAIR"].ToString());
                    chkMidPoor.Checked = bool.Parse(dr["MID_ISLAND_POOR"].ToString());

                    ChkSideIsland.Checked = bool.Parse(dr["sideisland_True"].ToString());
                    ChkSideIsland_CheckedChanged(sender, e);
                    rntxtSideIsWidth.Text = dr["sideisland_width"].ToString();

                    ChkSideWalk.Checked = bool.Parse(dr["side_Curb_True"].ToString());
                    ChkSideWalk_CheckedChanged(sender, e);
                    rntxtSideWalkWidth.Text = dr["side_Curb_width"].ToString();

                    chkSideGood.Checked = bool.Parse(dr["SIDE_CURB_GOOD"].ToString());
                    chkSideFair.Checked = bool.Parse(dr["SIDE_CURB_FAIR"].ToString());
                    chkSidePoor.Checked = bool.Parse(dr["SIDE_CURB_POOR"].ToString());
                    #endregion

                    #region 3
                    mlvSectionInfo.ActiveViewIndex = 3;
                    ChkHousing.Checked = bool.Parse(dr["houses"].ToString());
                    ChkCommercial.Checked = bool.Parse(dr["Commerial"].ToString());
                    ChkPublics.Checked = bool.Parse(dr["publics"].ToString());
                    ChkGarden.Checked = bool.Parse(dr["gardens"].ToString());
                    ChkIndisterial.Checked = bool.Parse(dr["indisterial"].ToString());
                    ChkRest_House.Checked = bool.Parse(dr["rest_house"].ToString());
                    #endregion

                    #region 4
                    mlvSectionInfo.ActiveViewIndex = 4;
                    ChkLight.Checked = bool.Parse(dr["LIGHTING_True"].ToString());
                    ChkLight_CheckedChanged(sender, e);
                    txtLightLocation.Text = dr["LIGHTING_LOC"].ToString();
                    chkPropertyConflict.Checked = bool.Parse(dr["LIGHTING_PROPERTY_CONFLICT"].ToString());
                    //chkLightGood.Checked = bool.Parse(dr["LIGHTING_GOOD"].ToString());

                    rntxtMegacomCount.Text = dr["MEGACOM_COUNT"].ToString();
                    rntxtMobyCount.Text = dr["MOBY_COUNT"].ToString();
                    rntxtUnipoleCount.Text = dr["UNIPOLE_COUNT"].ToString();
                    rntxtLightControlsCount.Text = dr["LIGHTING_CONTROLS_COUNT"].ToString();

                    rntxtLightGood.Text = dr["LIGHT_GOOD_COUNT"].ToString();
                    rntxtLightFair.Text = dr["LIGHT_FAIR_COUNT"].ToString();
                    rntxtLightPoor.Text = dr["LIGHT_POOR_COUNT"].ToString();

                    rntxtGuideSignsCount.Text = dr["GUIDE_SIGNS_COUNT"].ToString();
                    //rntxtLightCount.Text = dr["LIGHTING_COUNT"].ToString();
                    //chkLightFair.Checked = bool.Parse(dr["LIGHT_FAIR"].ToString());
                    //chkLightPoor.Checked = bool.Parse(dr["LIGHT_POOR"].ToString());
                    #endregion

                    #region 5
                    mlvSectionInfo.ActiveViewIndex = 5;
                    chkBridges.Checked = bool.Parse(dr["brdg_tunel_True"].ToString());
                    ChkTunnel.Checked = chkBridges.Checked;
                    //ChkTunnel_CheckedChanged(sender, e);
                    HasTunnelsBridges();
                    txtBrdg_TUNEL_TYPE.Text = dr["brdg_tunel_type"].ToString();

                    ChkIntersection_Open.Checked = bool.Parse(dr["INTERSECTION_OPEN_ISLAND"].ToString());
                    ChkIntersection_TL.Checked = bool.Parse(dr["INTERSECTION_TRAFFIC_LIGHT"].ToString());
                    chkMultilevel.Checked = bool.Parse(dr["MULTILEVEL"].ToString());

                    chkWalkerBridges.Checked = bool.Parse(dr["PEDESTRIAN"].ToString());
                    chkWalkerBridges_CheckedChanged(sender, e);

                    ddlwalkerBridgeType.Items.Clear();
                    ddlwalkerBridgeType.Items.Add(new ListItem("اختيار", "0"));
                    ddlwalkerBridgeType.DataBind();

                    ddlwalkerBridgeType.SelectedValue = dr["PEDESTRIAN_BRIDGE_TYPE"].ToString();
                    rntxtWalkerBridgesCount.Text = dr["PEDESTRIAN_COUNT"].ToString();
                    #endregion

                    #region 6
                    mlvSectionInfo.ActiveViewIndex = 6;
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

                    rntxtDrinage_CBGood.Text = ChkDrinage_CBs.Checked ? (string.IsNullOrEmpty(dr["drinage_cb_Count"].ToString()) ? "0" : dr["drinage_cb_Count"].ToString()) : "";
                    rntxtDrinage_CBFair.Text = ChkDrinage_CBs.Checked ? (string.IsNullOrEmpty(dr["DRAIN_CB_FAIR"].ToString()) ? "0" : dr["DRAIN_CB_FAIR"].ToString()) : ""; //dr[""].ToString();
                    rntxtDrinage_CBPoor.Text = ChkDrinage_CBs.Checked ? (string.IsNullOrEmpty(dr["DRAIN_CB_POOR"].ToString()) ? "0" : dr["DRAIN_CB_POOR"].ToString()) : ""; //dr["DRAIN_CB_POOR"].ToString();

                    rntxtDrinage_MH_Good.Text = ChkDrinage_MH.Checked ? (string.IsNullOrEmpty(dr["drinage_mh_Count"].ToString()) ? "0" : dr["drinage_mh_Count"].ToString()) : "";//dr[""].ToString();
                    rntxtDrinage_MH_Fair.Text = ChkDrinage_MH.Checked ? (string.IsNullOrEmpty(dr["DRAIN_MH_FAIR"].ToString()) ? "0" : dr["DRAIN_MH_FAIR"].ToString()) : "";//dr["DRAIN_MH_FAIR"].ToString();
                    rntxtDrinage_MH_Poor.Text = ChkDrinage_MH.Checked ? (string.IsNullOrEmpty(dr["DRAIN_MH_POOR"].ToString()) ? "0" : dr["DRAIN_MH_POOR"].ToString()) : "";//dr[""].ToString();

                    rntxtSewage_MH_Good.Text = ChkSewage_MH.Checked ? (string.IsNullOrEmpty(dr["Sewage_mh_Count"].ToString()) ? "0" : dr["Sewage_mh_Count"].ToString()) : "";//dr[""].ToString();
                    rntxtSewage_MH_Fair.Text = ChkSewage_MH.Checked ? (string.IsNullOrEmpty(dr["SEWAGE_MH_FAIR"].ToString()) ? "0" : dr["SEWAGE_MH_FAIR"].ToString()) : "";//dr[""].ToString();
                    rntxtSewage_MH_Poor.Text = ChkSewage_MH.Checked ? (string.IsNullOrEmpty(dr["SEWAGE_MH_POOR"].ToString()) ? "0" : dr["SEWAGE_MH_POOR"].ToString()) : "";//dr[""].ToString();

                    rnTxtElect_MH_Good.Text = ChkElect_MH.Checked ? (string.IsNullOrEmpty(dr["Elect_mh_Count"].ToString()) ? "0" : dr["Elect_mh_Count"].ToString()) : "";//dr[""].ToString();
                    rnTxtElect_MH_Fair.Text = ChkElect_MH.Checked ? (string.IsNullOrEmpty(dr["ELEC_MH_FAIR"].ToString()) ? "0" : dr["ELEC_MH_FAIR"].ToString()) : "";//dr[""].ToString();
                    rnTxtElect_MH_Poor.Text = ChkElect_MH.Checked ? (string.IsNullOrEmpty(dr["ELEC_MH_POOR"].ToString()) ? "0" : dr["ELEC_MH_POOR"].ToString()) : "";//dr[""].ToString();

                    rntxtSTC_MH_Good.Text = ChkSTC_MH.Checked ? (string.IsNullOrEmpty(dr["stc_mh_Count"].ToString()) ? "0" : dr["stc_mh_Count"].ToString()) : "";//dr[""].ToString();
                    rntxtSTC_MH_Fair.Text = ChkSTC_MH.Checked ? (string.IsNullOrEmpty(dr["STC_MH_FAIR"].ToString()) ? "0" : dr["STC_MH_FAIR"].ToString()) : "";//dr[""].ToString();
                    rntxtSTC_MH_Poor.Text = ChkSTC_MH.Checked ? (string.IsNullOrEmpty(dr["STC_MH_POOR"].ToString()) ? "0" : dr["STC_MH_POOR"].ToString()) : "";//dr[""].ToString();

                    rnTxtWater_MH_Good.Text = ChkWater_MH.Checked ? (string.IsNullOrEmpty(dr["water_valve_Count"].ToString()) ? "0" : dr["water_valve_Count"].ToString()) : "";//dr[""].ToString();
                    rnTxtWater_MH_Fair.Text = ChkWater_MH.Checked ? (string.IsNullOrEmpty(dr["WATER_MH_FAIR"].ToString()) ? "0" : dr["WATER_MH_FAIR"].ToString()) : ""; //dr[""].ToString();
                    rnTxtWater_MH_Poor.Text = ChkWater_MH.Checked ? (string.IsNullOrEmpty(dr["WATER_MH_POOR"].ToString()) ? "0" : dr["WATER_MH_POOR"].ToString()) : "";//dr[""].ToString();
                    #endregion

                    #region 7
                    mlvSectionInfo.ActiveViewIndex = 7;
                    chkDrillingSTC.Checked = bool.Parse(dr["DRILLINGS_STC"].ToString());
                    chkDrillingSTC_CheckedChanged(sender, e);
                    rntxtDrillingSTC.Text = dr["DRILLINGS_STC_LENGTH"].ToString();

                    chkDrillingElec.Checked = bool.Parse(dr["DRILLINGS_ELEC"].ToString());
                    chkDrillingElec_CheckedChanged(sender, e);
                    rntxtDrillingElec.Text = dr["DRILLINGS_ELEC_LENGTH"].ToString();

                    chkDrillingWater.Checked = bool.Parse(dr["DRILLINGS_WATER"].ToString());
                    chkDrillingWater_CheckedChanged(sender, e);
                    rntxtDrillingWater.Text = dr["DRILLINGS_WATER_LENGTH"].ToString();

                    chkDrillingSewage.Checked = bool.Parse(dr["DRILLINGS_SEWAGE"].ToString());
                    chkDrillingSewage_CheckedChanged(sender, e);
                    rntxtDrillingSewage.Text = dr["DRILLINGS_SEWAG_LENGTH"].ToString();
                    #endregion


                    //hlnkTunnels.Visible = false;
                    //hlnkBridges.Visible = false;

                    //mlvSectionInfo.Visible = true;
                    //pnlSectionInfo.Visible = true;
                    //pnlSamplesLanes.Visible = true;

                    lnkDetails_Click(sender, e);

                    mlvSectionInfo.ActiveViewIndex = 0;

                    gvLanes.DataBind();
                    gvLanes.SelectedIndex = -1;
                    gvLaneSamples.DataBind();

                    gvSurveyorJob.DataBind();
                }
                else
                {
                    lblFeedback.Text = Feedback.NoData();
                    mlvSectionInfo.Visible = false;
                    pnlSectionInfo.Visible = false;
                    pnlSamplesLanes.Visible = false;
                    pnlSurveyor.Visible = false;
                }
            }
            else
            {
                mlvSectionInfo.Visible = false;
                pnlSectionInfo.Visible = false;
                pnlSamplesLanes.Visible = false;
                pnlSurveyor.Visible = false;
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
            //mlvSectionInfo.Visible = false;
        }
    }

    protected void odsSectionLanes_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.SampleUpdateSuccessful();
    }

    protected void gvLaneSamples_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblSampleFeedback.Text = "";

            if (gvLaneSamples.SelectedValue != null)
            {
                pnlSampleInfo.Visible = false;
                // load panel Info
                DataTable dt = new LaneSample().GetLaneSampleDetails(int.Parse(gvLaneSamples.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    rntxtSampleNo.Text = dr["SAMPLE_NO"].ToString();

                    rntxtSampleLength.Value = double.Parse(dr["SAMPLE_LENGTH"].ToString());
                    rntxtSampleWidth.Value = double.Parse(dr["SAMPLE_WIDTH"].ToString());
                    rntxtSampleLength_TextChanged(sender, e);

                    chkOpening.Checked = bool.Parse(dr["MAIN_SRVC_OPENING_TRUE"].ToString());
                    chkHasOpening_CheckedChanged(sender, e);
                    rntxtOpeningLength.Text = dr["MAIN_SRVC_OPENING_LENGTH"].ToString();
                    rntxtOpeningWidth.Text = dr["MAIN_SRVC_OPENING_WIDTH"].ToString();

                    chkParking.Checked = bool.Parse(dr["IS_PARKING"].ToString());
                    chkParking_CheckedChanged(sender, e);

                    //ddlParkingMethods.DataBind();
                    ddlParkingMethods.SelectedValue = dr["PARKING_METHOD"].ToString();

                    chkUTurn.Checked = bool.Parse(dr["U_TURN_TRUE"].ToString());
                    chkUTurn_CheckedChanged(sender, e);
                    rntxtUTurnLength.Text = dr["U_TURN_LENGTH"].ToString();
                    rntxtUTurnWidth.Text = dr["U_TURN_WIDTH"].ToString();

                    chkSidewalkPainted.Checked = bool.Parse(dr["SIDEWALK_PAINT_TRUE"].ToString());
                    chkSidewalkPainted_CheckedChanged(sender, e);
                    chkSidewalkPaintGood.Checked = bool.Parse(dr["SIDEWALK_PAINT_GOOD"].ToString());

                    chkPedestrain.Checked = bool.Parse(dr["PEDESTRIAN"].ToString());
                    chkPedestrain_CheckedChanged(sender, e);
                    chkPedestrianGood.Checked = bool.Parse(dr["PEDESTRIAN_GOOD"].ToString());

                    chkHandicappedSlopes.Checked = bool.Parse(dr["HANDICAPPED_SLOPE_TRUE"].ToString());
                    chkhandicappedSlopes_CheckedChanged(sender, e);
                    chkHandicappedSlopeGood.Checked = bool.Parse(dr["HANDICAPPED_SLOPE_GOOD"].ToString());

                    chkSpeedBumps.Checked = bool.Parse(dr["SPEED_BUMPS_TRUE"].ToString());
                    chkSpeedBumps_CheckedChanged(sender, e);
                    chkLegal.Checked = bool.Parse(dr["SPEED_BUMPS_LEGAL"].ToString());
                    chkIllegal.Checked = bool.Parse(dr["SPEED_BUMPS_ILLEGAL"].ToString());
                    rntxtSpeedBumpsCount.Text = dr["SPEED_BUMPS_COUNT"].ToString();
                    ddlSpeedBumpType.SelectedValue = dr["SPEED_BUMP_TYPE_ID"].ToString();


                    chkConcreteBlocks.Checked = bool.Parse(dr["CONCRETE_BLOCKS"].ToString());
                    rntxtConcreteBlocks.Text = dr["CONCRETE_BLOCKS_COUNT"].ToString();


                    pnlSampleInfo.Visible = true;

                    pnlServiceMainOpening.Visible = false;
                    pnlParking.Visible = false;
                    pnlUTurn.Visible = false;
                    pnlPaint.Visible = false;
                    pnlPedestPass.Visible = false;
                    pnlHandicapped.Visible = false;


                    string lane = gvLanes.SelectedRow.Cells[2].Text;

                    if (lane.Contains("R") || lane.Contains("S") || lane.Contains("P"))
                    {
                        pnlServiceMainOpening.Visible = true;
                        pnlParking.Visible = true;
                        pnlHandicapped.Visible = true;
                    }
                    else
                    {
                        pnlServiceMainOpening.Visible = false;
                        pnlParking.Visible = false;
                        pnlHandicapped.Visible = false;
                    }


                    //pnlHandicapped.Visible = (lane.Contains("P")) ? true : false;
                    pnlPaint.Visible = (lane.Contains("M")) ? false : true;
                    pnlPedestPass.Visible = (lane.Contains("PS")) ? true : false;



                    if (lane.Contains("L"))
                    {
                        pnlUTurn.Visible = true;
                        pnlHandicapped.Visible = true;
                    }
                    else
                    {
                        pnlUTurn.Visible = false;
                        pnlHandicapped.Visible = false;
                    }

                    if (lane.Contains("M"))
                        pnlConcBlocks.Visible = false;
                    else
                        pnlConcBlocks.Visible = true;

                }
                else
                {
                    pnlSampleInfo.Visible = false;
                    lblFeedback.Text = Feedback.NoData();
                }
            }
            else
                pnlSampleInfo.Visible = false;

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void rntxtSampleLength_TextChanged(object sender, EventArgs e)
    {
        if (rntxtSampleLength.Value != null && rntxtSampleWidth.Value != null)
            rntxtSampleArea.Value = rntxtSampleLength.Value * rntxtSampleWidth.Value;
        else
            rntxtSampleArea.Value = null;
    }

    protected void gvLanes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnlSampleInfo.Visible = false;

            gvLaneSamples.SelectedIndex = -1;
            gvLaneSamples.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void chkHasOpening_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkOpening.Checked;
        rntxtOpeningLength.Enabled = isChecked;
        rntxtOpeningWidth.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtOpeningLength.Text = "";
            rntxtOpeningWidth.Text = "";
        }
    }

    protected void chkParking_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkParking.Checked;
        ddlParkingMethods.Enabled = isChecked;
        if (!isChecked)
            ddlParkingMethods.SelectedValue = "0";
    }

    protected void chkUTurn_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkUTurn.Checked;
        rntxtUTurnLength.Enabled = isChecked;
        rntxtUTurnWidth.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtUTurnLength.Text = "";
            rntxtUTurnWidth.Text = "";
        }
    }

    protected void chkSidewalkPainted_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkSidewalkPainted.Checked;
        chkSidewalkPaintGood.Enabled = isChecked;
        if (!isChecked)
            chkSidewalkPaintGood.Checked = false;
    }

    protected void chkPedestrain_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkPedestrain.Checked;
        chkPedestrianGood.Enabled = isChecked;
        if (!isChecked)
            chkPedestrianGood.Checked = false;
    }

    protected void chkhandicappedSlopes_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkHandicappedSlopes.Checked;
        chkHandicappedSlopeGood.Enabled = isChecked;
        if (!isChecked)
            chkHandicappedSlopeGood.Checked = false;
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
            chkHandicappedSlopeGood.Checked = false;
            chkLegal.Checked = false;
            chkIllegal.Checked = false;

            rntxtSpeedBumpsCount.Text = "";
            ddlSpeedBumpType.SelectedValue = "0";
        }
    }

    protected void btnSaveSampleDetails_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());



            lblSampleFeedback.Text = "";
            if (!SampleDataAreValid())
                return;

            bool saved = new LaneSample().UpdateLaneSampleDetails(rntxtSampleNo.Text, rntxtSampleLength.Text, rntxtSampleWidth.Text, chkOpening.Checked, rntxtOpeningWidth.Text,
                rntxtOpeningLength.Text, chkParking.Checked, int.Parse(ddlParkingMethods.SelectedValue), chkUTurn.Checked, rntxtUTurnLength.Text, rntxtUTurnWidth.Text,
                chkSidewalkPainted.Checked, chkSidewalkPaintGood.Checked, chkHandicappedSlopes.Checked, chkHandicappedSlopeGood.Checked, chkSpeedBumps.Checked, chkLegal.Checked,
                chkIllegal.Checked, rntxtSpeedBumpsCount.Text, chkPedestrain.Checked, chkPedestrianGood.Checked, int.Parse(gvLaneSamples.SelectedValue.ToString()),
                chkConcreteBlocks.Checked, rntxtConcreteBlocks.Text, Session["UserName"].ToString(), int.Parse(ddlSpeedBumpType.SelectedValue));

            if (saved)
            {
                gvLaneSamples.DataBind();
                gvLaneSamples.SelectedIndex = -1;
                pnlSampleInfo.Visible = false;

                lblFeedback.Text = Feedback.InsertSuccessfull();
                lblSampleFeedback.Text = lblFeedback.Text;
            }
            else
            {
                lblFeedback.Text = Feedback.InsertException();
                lblSampleFeedback.Text = lblFeedback.Text;
            }
        }
        catch (Exception ex)
        {
            lblSampleFeedback.Text = ex.Message;
        }
    }


    private bool SampleDataAreValid()
    {
        if (chkParking.Checked && ddlParkingMethods.SelectedValue == "0")
        {
            ddlParkingMethods.Focus();
            throw new Exception("الرجاء اختيار نوع الوقوف");
        }
        else if (chkUTurn.Checked && string.IsNullOrEmpty(rntxtUTurnLength.Text))
        {
            rntxtUTurnLength.Focus();
            throw new Exception("الرجاء إدخال طول فتحة الدوران");
        }
        else if (chkUTurn.Checked && string.IsNullOrEmpty(rntxtUTurnWidth.Text))
        {
            rntxtUTurnWidth.Focus();
            throw new Exception("الرجاء إدخال عرض فتحة الدوران");
        }
        else if (chkSpeedBumps.Checked && string.IsNullOrEmpty(rntxtSpeedBumpsCount.Text))
        {
            rntxtSpeedBumpsCount.Focus();
            throw new Exception("الرجاء إدخال عدد المطبات الصناعية");
        }
        else if (chkConcreteBlocks.Checked && string.IsNullOrEmpty(rntxtConcreteBlocks.Text))
        {
            rntxtConcreteBlocks.Focus();
            throw new Exception("الرجاء إدخال عدد الحواجز الخرسانية");
        }
        else
            return true;
    }


    protected void btnSampleSaveCancel_Click(object sender, EventArgs e)
    {
        gvLaneSamples_SelectedIndexChanged(sender, e);
    }

    protected void chkConcreteBlocks_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkConcreteBlocks.Checked;
        rntxtConcreteBlocks.Enabled = isChecked;

        if (!isChecked)
            rntxtConcreteBlocks.Text = "";
    }

    protected void lbtnSearchMainSt_Click(object sender, EventArgs e)
    {
        SearchMainSt1.Visible = true;
    }

    protected void lbtnSearchSection_Click(object sender, EventArgs e)
    {
        if (ddlMainStreets.SelectedValue != "0")
        {
            Session["MainStreetID"] = ddlMainStreets.SelectedValue;
            SearchSection1.Visible = true;
        }
        else
            SearchSection1.Visible = false;
    }


    protected void onMainStSearchChanged()
    {
        try
        {
            int selectedID = SearchMainSt1.SelectedMainStreetID;
            if (selectedID != 0)
            {
                ddlMainStreets.SelectedValue = selectedID.ToString();
                ddlMainStreets_SelectedIndexChanged(new Object(), new EventArgs());
                SearchMainSt1.Visible = false;
            }
            else
            {
                SearchMainSt1.Visible = false;
                ddlMainStreets.SelectedValue = "0";
                ddlMainStreets_SelectedIndexChanged(new Object(), new EventArgs());
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void onSectionSearchChanged()
    {
        try
        {
            int selectedID = SearchSection1.SelectedSectionID;
            if (selectedID != 0)
            {
                lblID.Text = selectedID.ToString();

                ddlMainStreetSection.SelectedValue = "0";
                ddlMainStreetSection_SelectedIndexChanged(new Object(), new EventArgs());

                ddlMainStreetSection.SelectedValue = selectedID.ToString();
                ddlMainStreetSection_SelectedIndexChanged(this.SearchSection1, new EventArgs());
                SearchSection1.Visible = false;
            }
            else
            {
                SearchSection1.Visible = false;
                ddlMainStreetSection.SelectedValue = "0";
                ddlMainStreetSection_SelectedIndexChanged(new Object(), new EventArgs());
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

    protected void chkR4_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkR4.Checked;
        rdtpR4Date.Enabled = isChecked;

        if (!isChecked)
            rdtpR4Date.SelectedDate = null;
    }

    protected void chkR3_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkR3.Checked;
        rdtpR3Date.Enabled = isChecked;

        if (!isChecked)
            rdtpR3Date.SelectedDate = null;
    }

    protected void chkPavemarkers_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkPavemarkers.Checked;
        chkMarkerCeramics.Enabled = isChecked;
        chkMarkerPaints.Enabled = isChecked;

        if (!isChecked)
        {
            chkMarkerCeramics.Checked = false;
            chkMarkerPaints.Checked = false;
        }
    }

    protected void gvLanes_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedbackSave.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void chkWalkerBridges_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkWalkerBridges.Checked;
        ddlwalkerBridgeType.Enabled = isChecked;
        rntxtWalkerBridgesCount.Enabled = isChecked;

        if (!isChecked)
        {
            ddlwalkerBridgeType.SelectedValue = "0";
            rntxtWalkerBridgesCount.Text = "";
        }
    }


    private void HideShowSectionUpdateCancelButtons()
    {
        UpdateButton.Visible = (mlvSectionInfo.ActiveViewIndex != -1);
        UpdateCancelButton.Visible = (mlvSectionInfo.ActiveViewIndex != -1);
    }

    private void BoldUnBoldLinks(int i)
    {
        lnkDetails.Font.Bold = (i == 1);
        lnkAg.Font.Bold = (i == 2);
        lnkIslands.Font.Bold = (i == 3);
        lnkUses.Font.Bold = (i == 4);
        lnkLights.Font.Bold = (i == 5);
        lnkBridges.Font.Bold = (i == 6);
        lnkMainholes.Font.Bold = (i == 7);
        lnkDrills.Font.Bold = (i == 8);
        lnkLaneSamples.Font.Bold = (i == 9);
        lnkSurveyor.Font.Bold = (i == 10);
    }

    protected void lnkDetails_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 0;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(1);
    }

    protected void lnkAg_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 1;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(2);
    }

    protected void lnkIslands_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 2;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(3);
    }

    protected void lnkUses_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 3;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(4);
    }

    protected void lnkLights_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 4;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(5);
    }

    protected void lnkBridges_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 5;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(6);
    }

    protected void lnkMainholes_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 6;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(7);
    }

    protected void lnkDrills_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 7;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(8);
    }

    protected void lnkLaneSamples_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = -1;
        pnlSamplesLanes.Visible = true;
        pnlSurveyor.Visible = false;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(9);
    }

    protected void lnkSurveyor_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = -1;
        pnlSamplesLanes.Visible = false;
        pnlSurveyor.Visible = true;

        HideShowSectionUpdateCancelButtons();
        BoldUnBoldLinks(10);
    }

    protected void odsSurveySubmitJobs_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            lblFeedbackSave.Text = lblFeedback.Text;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.UpdateSuccessfull();
            lblFeedbackSave.Text = lblFeedback.Text;
        }
    }

    protected void odsSurveySubmitJobs_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            lblFeedbackSave.Text = lblFeedback.Text;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.DeleteSuccessfull();
            lblFeedbackSave.Text = lblFeedback.Text;
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


            //JobType type = ((radSection.Checked) ? JobType.Section : (radIntersection.Checked ? JobType.Intersection : (radRegionSecondary.Checked ? JobType.RegionSecondaryStreets : JobType.None)));
            //string elementID = ((radSection.Checked) ? ddlMainStreetSection.SelectedValue : (radIntersection.Checked ? ddlMainStreetIntersection.SelectedValue : (radRegionSecondary.Checked ? ddlRegions.SelectedValue : "")));

            // int.Parse(hID.Value) , ddlSurveyor.SelectedItem.Text, 
            bool saved = new SurveyorSubmitJob().Insert(int.Parse(ddlSurveyor.SelectedValue), raddtpIssueDate.SelectedDate, raddtpDeliveryDate.SelectedDate,
                int.Parse(rntxtSurveyNo.Text), txtNotes.Text, ddlMainStreetSection.SelectedValue, JobType.Section);

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

}