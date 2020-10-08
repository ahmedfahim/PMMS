using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using JpmmsClasses.BL;

public partial class ASPX_Intersections_IntersectionInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            BindIntersectInfoDropDowns();
        }
    }



    private void BindIntersectInfoDropDowns()
    {
        try
        {
            ddlIntersectControlTypes.Items.Clear();
            ddlIntersectControlTypes.Items.Add(new ListItem("اختيار", "0"));
            ddlIntersectControlTypes.DataBind();

            ddlIntersectTypes.Items.Clear();
            ddlIntersectTypes.Items.Add(new ListItem("اختيار", "0"));
            ddlIntersectTypes.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }


    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlMainStreetIntersection.Items.Clear();
            ddlMainStreetIntersection.Items.Add(new ListItem("اختيار", "0"));
            ddlMainStreetIntersection.DataBind();
            ddlMainStreetIntersection.SelectedValue = "0";

            ddlMainStreetIntersection_SelectedIndexChanged(sender, e);
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


    protected void chkSoilParts_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkSoilParts.Checked;
        rntxtUnpavedLength.Enabled = isChecked;
        rntxtUnpavedWidth.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtUnpavedLength.Text = "0";
            rntxtUnpavedWidth.Text = "0";
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

        //bool isChecked = ChkMidIsland.Checked;
        //rntxtMidIsWidth.Enabled = isChecked;
        //chkMidGood.Enabled = isChecked;
        //chkMidFair.Enabled = isChecked;
        //chkMidPoor.Enabled = isChecked;

        //if (!isChecked)
        //{
        //    rntxtMidIsWidth.Text = "";
        //    chkMidGood.Checked = false;
        //    chkMidFair.Checked = false;
        //    chkMidPoor.Checked = false;
        //}
    }

    protected void ChkLight_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkLight.Checked;
        txtLightLocation.Enabled = isChecked;
        rntxtLightGood.Enabled = isChecked;
        rntxtLightFair.Enabled = isChecked;
        rntxtLightPoor.Enabled = isChecked;
        //chkLightGood.Enabled = isChecked;
        //chkLightFair.Enabled = isChecked;
        //chkLightPoor.Enabled = isChecked;
        //rntxtLightsCount.Enabled = isChecked;

        if (!isChecked)
        {
            txtLightLocation.Text = "";
            rntxtLightGood.Text = "0";
            rntxtLightFair.Text = "0";
            rntxtLightPoor.Text = "0";
            //rntxtLightsCount.Text = "0";
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

    private void HasTunnelsBridges()
    {
        bool hasTunnel = ChkTunnel.Checked | chkBridges.Checked;
        //bool hasBridge = ((CheckBox)frvIntersectionsEd.FindControl("ChkBridge")).Checked;

        txtBrdg_TUNEL_TYPE.Enabled = hasTunnel; //|| hasBridge;
        if (!hasTunnel)  //&& !hasBridge)
            txtBrdg_TUNEL_TYPE.Text = "";

        if (chkBridges.Checked || chkBridgesIntersect.Checked)
        {
            hlnkBridges.Visible = true;
            hlnkBridges.NavigateUrl = string.Format("Bridges.aspx?InterID={0}", int.Parse(ddlMainStreetIntersection.SelectedValue));
        }
        else
            hlnkBridges.Visible = false;

        if (ChkTunnel.Checked || ChkTunnelIntersect.Checked)
        {
            hlnkTunnels.Visible = true;
            hlnkTunnels.NavigateUrl = string.Format("Tunnels.aspx?InterID={0}", int.Parse(ddlMainStreetIntersection.SelectedValue));
        }
        else
            hlnkTunnels.Visible = false;
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
        rntxtDrinage_MHGood.Enabled = isChecked;
        rntxtDrinage_MH_Fair.Enabled = isChecked;
        rntxtDrinage_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtDrinage_MHGood.Text = "";
            rntxtDrinage_MH_Fair.Text = "";
            rntxtDrinage_MH_Poor.Text = "";
        }
        else
        {
            rntxtDrinage_MHGood.Text = "0";
            rntxtDrinage_MH_Fair.Text = "0";
            rntxtDrinage_MH_Poor.Text = "0";
        }
    }

    protected void ChkSewage_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSewage_MH.Checked;
        rntxtSewage_MHGood.Enabled = isChecked;
        rntxtSewage_MH_Fair.Enabled = isChecked;
        rntxtSewage_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSewage_MHGood.Text = "";
            rntxtSewage_MH_Fair.Text = "";
            rntxtSewage_MH_Poor.Text = "";
        }
        else
        {
            rntxtSewage_MHGood.Text = "0";
            rntxtSewage_MH_Fair.Text = "0";
            rntxtSewage_MH_Poor.Text = "0";
        }
    }

    protected void ChkWater_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkWater_MH.Checked;
        rnTxtWater_MHGood.Enabled = isChecked;
        rnTxtWater_MH_Fair.Enabled = isChecked;
        rnTxtWater_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rnTxtWater_MHGood.Text = "";
            rnTxtWater_MH_Fair.Text = "";
            rnTxtWater_MH_Poor.Text = "";
        }
        else
        {
            rnTxtWater_MHGood.Text = "0";
            rnTxtWater_MH_Fair.Text = "0";
            rnTxtWater_MH_Poor.Text = "0";
        }
    }

    protected void ChkElect_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkElect_MH.Checked;
        rnTxtElect_MHGood.Enabled = isChecked;
        rnTxtElect_MH_Fair.Enabled = isChecked;
        rnTxtElect_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rnTxtElect_MHGood.Text = "";
            rnTxtElect_MH_Fair.Text = "";
            rnTxtElect_MH_Poor.Text = "";
        }
        else
        {
            rnTxtElect_MHGood.Text = "0";
            rnTxtElect_MH_Fair.Text = "0";
            rnTxtElect_MH_Poor.Text = "0";
        }
    }

    protected void ChkSTC_MH_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSTC_MH.Checked;
        rntxtSTC_MHGood.Enabled = isChecked;
        rntxtSTC_MH_Fair.Enabled = isChecked;
        rntxtSTC_MH_Poor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSTC_MHGood.Text = "";
            rntxtSTC_MH_Fair.Text = "";
            rntxtSTC_MH_Poor.Text = "";
        }
        else
        {
            rntxtSTC_MHGood.Text = "0";
            rntxtSTC_MH_Fair.Text = "0";
            rntxtSTC_MH_Poor.Text = "0";
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


    private Intersection intersect;

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

            intersect = new Intersection();
            if (chkMultilevel.Checked)
            {
                // check that section must have bridges or tunnels, if not, user must enter information for a tunnel or bridge, otherwise, save info
                if (intersect.InvalidMultilevelIntersect(int.Parse(ddlMainStreetIntersection.SelectedValue)))
                    throw new Exception("بما أن هذا التقاطع متعدد المستويات فيرجى تحديد وجود جسور أو أنفاق في هذا التقاطع ومن ثم إدخال بياناتها");
            }
            else if (intersect.CheckIntersectionSurveyorNotSaved(int.Parse(ddlMainStreetIntersection.SelectedValue)))
            {
                lnkSurveyor_Click(sender, e);
                throw new Exception("الرجاء تسجيل بيانات المسح أولا ومن ثم حفظ البيانات الوصفية");
            }


            bool saved = intersect.UpdateIntersectionInfo(
                ChkHousing.Checked, ChkPublics.Checked, ChkCommercial.Checked, ChkGarden.Checked, ChkIndisterial.Checked, ChkRest_House.Checked,
                chkSoilParts.Checked, rntxtUnpavedLength.Text, rntxtUnpavedWidth.Text,
                ChkMidIsland.Checked, rntxtMidIsWidth.Text,
                ChkSideIsland.Checked, rntxtSideIsWidth.Text,
                ChkSideWalk.Checked, rntxtSideWalkWidth.Text,
                ChkLight.Checked, txtLightLocation.Text,
                ChkTunnel.Checked, chkBridges.Checked, txtBrdg_TUNEL_TYPE.Text,
                ChkDrinage_MH.Checked, rntxtDrinage_MHGood.Text,
                ChkDrinage_CBs.Checked, rntxtDrinage_CBGood.Text,
                ChkSewage_MH.Checked, rntxtSewage_MHGood.Text,
                ChkElect_MH.Checked, rnTxtElect_MHGood.Text,
                ChkSTC_MH.Checked, rntxtSTC_MHGood.Text,
                ChkWater_MH.Checked, rnTxtWater_MHGood.Text,
                int.Parse(ddlMainStreetIntersection.SelectedValue), int.Parse(ddlIntersectTypes.SelectedValue), int.Parse(ddlIntersectControlTypes.SelectedValue),
                chkSoilPartsIntersect.Checked, rntxtUnpavedLengthIntersect.Text, rntxtUnpavedWidthIntersect.Text,
                ChkMidIslandIntersect.Checked, rntxtMidIsWidthIntersect.Text,
                ChkSideIslandIntersect.Checked, rntxtSideIsWidthIntersect.Text,
                ChkSideWalkIntersect.Checked, rntxtSideWalkWidthIntersect.Text,
                ChkLightIntersect.Checked, txtLightLocationIntersect.Text,
                ChkTunnelIntersect.Checked, chkBridgesIntersect.Checked, txtBrdg_TUNEL_TYPEIntersect.Text,
                ChkDrinage_MH_Intersect.Checked, rntxtDrinage_MHGoodIntersect.Text,
                ChkDrinage_CBsIntersect.Checked, rntxtDrinage_CBGoodIntersect.Text,
                ChkSewage_MH_Intersect.Checked, rntxtSewage_MHGoodIntersect.Text,
                ChkElect_MHIntersect.Checked, rnTxtElect_MHGoodIntersect.Text,
                ChkSTC_MH_Intersect.Checked, rntxtSTC_MHGoodIntersect.Text,
                ChkWater_MH_Intersect.Checked, rnTxtWater_MHGoodIntersect.Text,
                ChkAg_MID.Checked, ChkAg_SID.Checked, ChkAg_SEC.Checked,
                ChkAg_MIDIntersect.Checked, ChkAg_SIDIntersect.Checked, ChkAg_SECIntersect.Checked,
                chkDrillingSTC.Checked, chkDrillingElec.Checked, chkDrillingWater.Checked, chkDrillingSewage.Checked,
                rntxtDrillingSTC.Text, rntxtDrillingElec.Text, rntxtDrillingWater.Text, rntxtDrillingSewage.Text,
                chkDrillingSTC_Intersect.Checked, chkDrillingElecIntersect.Checked, chkDrillingWaterIntersect.Checked, chkDrillingSewageIntersect.Checked,
                rntxtDrillingSTC_Intersect.Text, rntxtDrillingElecIntersect.Text, rntxtDrillingWaterIntersect.Text, rntxtDrillingSewageIntersect.Text,
                chkConcreteBlocks.Checked, rntxtConcreteBlocks.Text,
                chkConcreteBlocks_intersect.Checked, rntxtConcreteBlocks_intersect.Text,
                rntxtDrinage_CBFair.Text, rntxtDrinage_CBPoor.Text,
                rntxtDrinage_MH_Fair.Text, rntxtDrinage_MH_Poor.Text,
                rnTxtElect_MH_Fair.Text, rnTxtElect_MH_Poor.Text,
                rntxtSTC_MH_Fair.Text, rntxtSTC_MH_Poor.Text,
                rntxtSewage_MH_Fair.Text, rntxtSewage_MH_Poor.Text,
                rnTxtWater_MH_Fair.Text, rnTxtWater_MH_Poor.Text,
                chkMidGood.Checked, chkMidFair.Checked, chkMidPoor.Checked,
                chkSideGood.Checked, chkSideFair.Checked, chkSidePoor.Checked,
                rntxtDrinage_CBFairIntersect.Text, rntxtDrinage_CBPoorIntersect.Text,
                rntxtDrinage_MH_FairIntersect.Text, rntxtDrinage_MH_PoorIntersect.Text,
                rnTxtElect_MH_FairIntersect.Text, rnTxtElect_MH_PoorIntersect.Text,
                rntxtSTC_MH_FairIntersect.Text, rntxtSTC_MH_PoorIntersect.Text,
                rntxtSewage_MH_FairIntersect.Text, rntxtSewage_MH_PoorIntersect.Text,
                rnTxtWater_MH_FairIntersect.Text, rnTxtWater_MH_PoorIntersect.Text,
                chkMidIntersectGood.Checked, chkMidIntersectFair.Checked, chkMidIntersectPoor.Checked,
                chkSideIntersectGood.Checked, chkSideIntersectFair.Checked, chkSideIntersectPoor.Checked,
                chkServiceLane.Checked, chkServiceLaneIntersect.Checked,
                chkOpeningService.Checked, chkOpeningServiceIntersect.Checked,
                chkSlopeInterSect.Checked, chkSlopeMain.Checked,
                chkUturnIntersect.Checked, chkUturnMain.Checked, chkMultilevel.Checked,
                rntxtLightGood.Text, rntxtLightFair.Text, rntxtLightPoor.Text,
                rntxtLightGoodIntersect.Text, rntxtLightFairIntersect.Text, rntxtLightGoodIntersect.Text,
                //chkLightGood.Checked, chkLightFair.Checked, chkLightPoor.Checked,
                //chkLightGoodIntersect.Checked, chkLightFairIntersect.Checked, chkLightPoorIntersect.Checked,
                //rntxtLightsCount.Text, rntxtLightsCountIntersect.Text,
                chkSideLGood.Checked, chkSideLFair.Checked, chkSideLPoor.Checked,
                chkSideLGoodIntersect.Checked, chkSideLFairIntersect.Checked, chkSideLPoorIntersect.Checked,
                ChkHousingIntersect.Checked, ChkPublicsIntersect.Checked, ChkCommercialIntersect.Checked, ChkGardenIntersect.Checked, ChkIndisterialIntersect.Checked, ChkRest_HouseIntersect.Checked,
                rntxtMegacomCount.Text, rntxtMobyCount.Text, rntxtUnipoleCount.Text,
                rntxtMegacomCountIntersect.Text, rntxtMobyCountIntersect.Text, rntxtUnipoleCountIntersect.Text,
                chkPavMarkers.Checked, chkPavePaints.Checked, chkPaveCeramics.Checked,
                chkPavMarkersIntersect.Checked, chkPavePaintsIntersect.Checked, chkPaveCeramicsIntersect.Checked, int.Parse(ddlSpeedBumpType.SelectedValue),
                int.Parse(ddlSpeedBumpTypeIntersect.SelectedValue),
                chkWalkerBridges.Checked, int.Parse(ddlwalkerBridgeType.SelectedValue), rntxtWalkerBridgesCount.Text,
                chkWalkerBridgesIntersect.Checked, int.Parse(ddlwalkerBridgeTypeIntersect.SelectedValue), rntxtWalkerBridgesCountIntersect.Text, rdtpSurveyDate.SelectedDate,
                rntxtGuideSignsCount.Text, rntxtGuideSignsIntersectCount.Text, int.Parse(Session["UserID"].ToString()), Session["UserName"].ToString());


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
        if (ChkMidIslandIntersect.Checked && string.IsNullOrEmpty(rntxtMidIsWidthIntersect.Text))
        {
            rntxtMidIsWidthIntersect.Focus();
            throw new Exception(" الرجاء إدخال عرض الجزيرة الوسطية في الشارع/الطريق المتقاطع");
        }
        else if (ChkSideIslandIntersect.Checked && string.IsNullOrEmpty(rntxtSideIsWidthIntersect.Text))
        {
            rntxtSideIsWidthIntersect.Focus();
            throw new Exception("الرجاء إدخال عرض الجزيرة الفاصلة في الشارع/الطريق المتقاطع");
        }
        else if (ChkSideWalkIntersect.Checked && string.IsNullOrEmpty(rntxtSideWalkWidthIntersect.Text))
        {
            rntxtSideWalkWidthIntersect.Focus();
            throw new Exception("الرجاء إدخال عرض الرصيف الجانبي في الشارع/الطريق المتقاطع");
        }
        else if ((chkBridges.Checked || ChkTunnel.Checked) && string.IsNullOrEmpty(txtBrdg_TUNEL_TYPE.Text))
        {
            txtBrdg_TUNEL_TYPE.Focus();
            throw new Exception("الرجاء إدخال تفاصيل الجسر/النفق في الشارع الرئيسي");
        }
        else if ((chkBridgesIntersect.Checked || ChkTunnelIntersect.Checked) && string.IsNullOrEmpty(txtBrdg_TUNEL_TYPEIntersect.Text))
        {
            txtBrdg_TUNEL_TYPE.Focus();
            throw new Exception("الرجاء إدخال تفاصيل الجسر/النفق في الشارع المتقاطع");
        }
        else if (ChkLight.Checked && string.IsNullOrEmpty(txtLightLocation.Text))
        {
            txtLightLocation.Focus();
            throw new Exception("الرجاء إدخال موقع الإنارة في الشارع/الطريق الرئيسي");
        }
        else if (ChkLightIntersect.Checked && string.IsNullOrEmpty(txtLightLocationIntersect.Text))
        {
            txtLightLocationIntersect.Focus();
            throw new Exception("الرجاء إدخال موقع الإنارة في الشارع/الطريق المتقاطع");
        }
        else if (ChkLight.Checked && ((string.IsNullOrEmpty(rntxtLightGood.Text) || string.IsNullOrEmpty(rntxtLightFair.Text) || string.IsNullOrEmpty(rntxtLightPoor.Text))
                             || (rntxtLightGood.Text == "0" && rntxtLightFair.Text == "0" && rntxtLightPoor.Text == "0"))
     )
        {
            rntxtLightGood.Focus();
            throw new Exception("الرجاء إدخال عدد أعمدة الإنارة في الشارع الرئيسي ");
        }
        else if (ChkLightIntersect.Checked && ((string.IsNullOrEmpty(rntxtLightGoodIntersect.Text) || string.IsNullOrEmpty(rntxtLightFairIntersect.Text) || string.IsNullOrEmpty(rntxtLightPoorIntersect.Text))
                             || (rntxtLightGoodIntersect.Text == "0" && rntxtLightFairIntersect.Text == "0" && rntxtLightPoorIntersect.Text == "0"))
     )
        {
            rntxtLightGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد أعمدة الإنارة في الشارع المتقاطع ");
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
        else if (chkSoilPartsIntersect.Checked && string.IsNullOrEmpty(rntxtUnpavedLengthIntersect.Text))
        {
            rntxtUnpavedLengthIntersect.Focus();
            throw new Exception("الرجاء إدخال طول الجزء الترابي في الشارع/الطريق المتقاطع");
        }
        else if (chkSoilPartsIntersect.Checked && string.IsNullOrEmpty(rntxtUnpavedWidthIntersect.Text))
        {
            rntxtUnpavedWidthIntersect.Focus();
            throw new Exception("الرجاء إدخال عرض الجزء الترابي في الشارع/الطريق المتقاطع");
        }
        else if (ChkDrinage_CBs.Checked && (string.IsNullOrEmpty(rntxtDrinage_CBGood.Text) && string.IsNullOrEmpty(rntxtDrinage_CBFair.Text) && string.IsNullOrEmpty(rntxtDrinage_CBPoor.Text)))
        {
            rntxtDrinage_CBGood.Focus();
            throw new Exception("الرجاء إدخال عدد مصائد السيول في الشارع/الطريق الرئيسي");
        }
        else if (ChkDrinage_MH.Checked && (string.IsNullOrEmpty(rntxtDrinage_MHGood.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_Fair.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_Poor.Text)))
        {
            rntxtDrinage_MHGood.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل السيول في الشارع/الطريق الرئيسي");
        }
        else if (ChkSewage_MH.Checked && (string.IsNullOrEmpty(rntxtSewage_MHGood.Text) && string.IsNullOrEmpty(rntxtSewage_MH_Fair.Text) && string.IsNullOrEmpty(rntxtSewage_MH_Poor.Text)))
        {
            rntxtSewage_MHGood.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الصرف الصحي في الشارع/الطريق الرئيسي");
        }
        else if (ChkElect_MH.Checked && (string.IsNullOrEmpty(rnTxtElect_MHGood.Text) && string.IsNullOrEmpty(rnTxtElect_MH_Fair.Text) && string.IsNullOrEmpty(rnTxtElect_MH_Poor.Text)))
        {
            rnTxtElect_MHGood.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الكهرياء في الشارع/الطريق الرئيسي");
        }
        else if (ChkSTC_MH.Checked && (string.IsNullOrEmpty(rntxtSTC_MHGood.Text) && string.IsNullOrEmpty(rntxtSTC_MH_Fair.Text) && string.IsNullOrEmpty(rntxtSTC_MH_Poor.Text)))
        {
            rntxtSTC_MHGood.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الهاتف في الشارع/الطريق الرئيسي");
        }
        else if (ChkWater_MH.Checked && (string.IsNullOrEmpty(rnTxtWater_MHGood.Text) && string.IsNullOrEmpty(rnTxtWater_MH_Fair.Text) && string.IsNullOrEmpty(rnTxtWater_MH_Poor.Text)))
        {
            rnTxtWater_MHGood.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل المياه في الشارع/الطريق الرئيسي");
        }
        else if (ChkDrinage_CBsIntersect.Checked && (string.IsNullOrEmpty(rntxtDrinage_CBGoodIntersect.Text) && string.IsNullOrEmpty(rntxtDrinage_CBFairIntersect.Text) && string.IsNullOrEmpty(rntxtDrinage_CBPoorIntersect.Text)))
        {
            rntxtDrinage_CBGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد مصائد السيول في الشارع/الطريق المتقاطع");
        }
        else if (ChkDrinage_MH_Intersect.Checked && (string.IsNullOrEmpty(rntxtDrinage_MHGoodIntersect.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_FairIntersect.Text) && string.IsNullOrEmpty(rntxtDrinage_MH_PoorIntersect.Text)))
        {
            rntxtDrinage_MHGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل السيول في الشارع/الطريق المتقاطع");
        }
        else if (ChkSewage_MH_Intersect.Checked && (string.IsNullOrEmpty(rntxtSewage_MHGoodIntersect.Text) && string.IsNullOrEmpty(rntxtSewage_MH_FairIntersect.Text) && string.IsNullOrEmpty(rntxtSewage_MH_PoorIntersect.Text)))
        {
            rntxtSewage_MHGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الصرف الصحي في الشارع/الطريق المتقاطع");
        }
        else if (ChkElect_MHIntersect.Checked && (string.IsNullOrEmpty(rnTxtElect_MHGoodIntersect.Text) && string.IsNullOrEmpty(rnTxtElect_MH_FairIntersect.Text) && string.IsNullOrEmpty(rnTxtElect_MH_PoorIntersect.Text)))
        {
            rnTxtElect_MHGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الكهرياء في الشارع/الطريق المتقاطع");
        }
        else if (ChkSTC_MH_Intersect.Checked && (string.IsNullOrEmpty(rntxtSTC_MHGoodIntersect.Text) && string.IsNullOrEmpty(rntxtSTC_MH_FairIntersect.Text) && string.IsNullOrEmpty(rntxtSTC_MH_PoorIntersect.Text)))
        {
            rntxtSTC_MHGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الهاتف في الشارع/الطريق المتقاطع");
        }
        else if (ChkWater_MH_Intersect.Checked && (string.IsNullOrEmpty(rnTxtWater_MHGoodIntersect.Text) && string.IsNullOrEmpty(rnTxtWater_MH_FairIntersect.Text) && string.IsNullOrEmpty(rnTxtWater_MH_PoorIntersect.Text)))
        {
            rnTxtWater_MHGoodIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل المياه في الشارع/الطريق المتقاطع");
        }
        else if (chkConcreteBlocks.Checked && string.IsNullOrEmpty(rntxtConcreteBlocks.Text))
        {
            rntxtConcreteBlocks.Focus();
            throw new Exception("الرجاء إدخال عدد الحواجز الخرسانية في الشارع/الطريق الرئيسي");
        }
        else if (chkConcreteBlocks_intersect.Checked && string.IsNullOrEmpty(rntxtConcreteBlocks_intersect.Text))
        {
            rntxtConcreteBlocks_intersect.Focus();
            throw new Exception("الرجاء إدخال عدد الحواجز الخرسانية في الشارع/الطريق المتقاطع");
        }
        else if (chkDrillingElec.Checked && string.IsNullOrEmpty(rntxtDrillingElec.Text))
        {
            rntxtDrillingElec.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الكهرباء في الشارع/الطريق الرئيسي");
        }
        else if (chkDrillingElecIntersect.Checked && string.IsNullOrEmpty(rntxtDrillingElecIntersect.Text))
        {
            rntxtDrillingElecIntersect.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الكهرباء في الشارع/الطريق المتقاطع");
        }
        else if (chkDrillingSewage.Checked && string.IsNullOrEmpty(rntxtDrillingSewage.Text))
        {
            rntxtDrillingSewage.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الصرف الصحي في الشارع/الطريق الرئيسي");
        }
        else if (chkDrillingSewageIntersect.Checked && string.IsNullOrEmpty(rntxtDrillingSewageIntersect.Text))
        {
            rntxtDrillingSewageIntersect.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الصرف الصحي في الشارع/الطريق المتقاطع");
        }
        else if (chkDrillingSTC.Checked && string.IsNullOrEmpty(rntxtDrillingSTC.Text))
        {
            rntxtDrillingSTC.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الاتصالات في الشارع/الطريق الرئيسي");
        }
        else if (chkDrillingSTC_Intersect.Checked && string.IsNullOrEmpty(rntxtDrillingSTC_Intersect.Text))
        {
            rntxtDrillingSTC_Intersect.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات الاتصالات في الشارع/الطريق المتقاطع");
        }
        else if (chkDrillingWater.Checked && string.IsNullOrEmpty(rntxtDrillingWater.Text))
        {
            rntxtDrillingWater.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات المياه في الشارع/الطريق الرئيسي");
        }
        else if (chkDrillingWaterIntersect.Checked && string.IsNullOrEmpty(rntxtDrillingWaterIntersect.Text))
        {
            rntxtDrillingWaterIntersect.Focus();
            throw new Exception("الرجاء إدخال طول حفريات خدمات المياه في الشارع/الطريق المتقاطع");
        }
        else if (chkWalkerBridges.Checked && (string.IsNullOrEmpty(rntxtWalkerBridgesCount.Text) || ddlwalkerBridgeType.SelectedValue == "0"))
        {
            ddlwalkerBridgeType.Focus();
            throw new Exception("الرجاء إدخال عدد ونوع جسور المشاة بالشارع/الطريق الرئيسي");
        }
        else if (chkWalkerBridgesIntersect.Checked && (string.IsNullOrEmpty(rntxtWalkerBridgesCountIntersect.Text) || ddlwalkerBridgeTypeIntersect.SelectedValue == "0"))
        {
            ddlwalkerBridgeTypeIntersect.Focus();
            throw new Exception("الرجاء إدخال عدد ونوع جسور المشاة بالشارع/الطريق المتقاطع");
        }
        else
            return true;
    }


    protected void ddlMainStreetIntersection_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblFeedbackSave.Text = "";

            pnlIntersect.Visible = false;
            pnlLinks.Visible = false;

            if (ddlMainStreetIntersection.SelectedValue != "0")
            {
                DataTable dt = new Intersection().GetIntersection(int.Parse(ddlMainStreetIntersection.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    pnlIntersect.Visible = true;
                    pnlLinks.Visible = true;
                    lnkGallery.NavigateUrl = string.Format("IntersectImages.aspx?InterID={0}", dr["INTERSECTION_ID"].ToString());

                    lblIntersectNo.Text = dr["INTER_NO"].ToString();
                    lblIntersectStreet1.Text = dr["INTEREC_STREET1"].ToString();
                    lblIntersectStreet2.Text = dr["INTEREC_STREET2"].ToString();
                    chkMultilevel.Checked = bool.Parse(dr["MULTILEVEL"].ToString());

                    #region MainStreet

                    chkSoilParts.Checked = bool.Parse(dr["unpaved_True"].ToString());
                    chkSoilParts_CheckedChanged(sender, e);
                    rntxtUnpavedLength.Text = dr["unpaved_length"].ToString();
                    rntxtUnpavedWidth.Text = dr["unpaved_Width"].ToString();

                    ChkMidIsland.Checked = bool.Parse(dr["mid_island_True"].ToString());
                    ChkMidIsland_CheckedChanged(sender, e);
                    rntxtMidIsWidth.Text = dr["mid_island_width"].ToString();

                    ChkSideIsland.Checked = bool.Parse(dr["sideisland_True"].ToString());
                    ChkSideIsland_CheckedChanged(sender, e);
                    rntxtSideIsWidth.Text = dr["sideisland_width"].ToString();

                    ChkSideWalk.Checked = bool.Parse(dr["side_Curb_True"].ToString());
                    ChkSideWalk_CheckedChanged(sender, e);
                    rntxtSideWalkWidth.Text = dr["side_Curb_width"].ToString();

                    ChkHousing.Checked = bool.Parse(dr["houses"].ToString());
                    ChkCommercial.Checked = bool.Parse(dr["Commerial"].ToString());
                    ChkPublics.Checked = bool.Parse(dr["publics"].ToString());
                    ChkGarden.Checked = bool.Parse(dr["gardens"].ToString());
                    ChkIndisterial.Checked = bool.Parse(dr["indisterial"].ToString());
                    ChkRest_House.Checked = bool.Parse(dr["rest_house"].ToString());

                    ChkAg_MID.Checked = bool.Parse(dr["ag_mid_island_True"].ToString());
                    ChkAg_SID.Checked = bool.Parse(dr["ag_sid_island_True"].ToString());
                    ChkAg_SEC.Checked = bool.Parse(dr["ag_sec_SIDE_True"].ToString());

                    chkPavMarkers.Checked = bool.Parse(dr["PAV_MARKERS_TRUE"].ToString());
                    chkPavMarkers_CheckedChanged(sender, e);
                    chkPavePaints.Checked = bool.Parse(dr["PAVE_MARK_PAINT"].ToString());
                    chkPaveCeramics.Checked = bool.Parse(dr["PAVE_MARK_CERAMICS"].ToString());


                    ChkLight.Checked = bool.Parse(dr["LIGHTING_True"].ToString());
                    ChkLight_CheckedChanged(sender, e);
                    txtLightLocation.Text = dr["LIGHTING_LOC"].ToString();

                    ChkTunnel.Checked = bool.Parse(dr["brdg_tunel_True"].ToString());
                    chkBridges.Checked = bool.Parse(dr["HAS_BRIDGES"].ToString());
                    //ChkTunnel_CheckedChanged(sender, e);
                    //ChkBridge_CheckedChanged(sender, e);
                    HasTunnelsBridges();
                    txtBrdg_TUNEL_TYPE.Text = dr["brdg_tunel_type"].ToString();


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

                    rntxtDrinage_CBGood.Text = dr["drinage_cb_Count"].ToString();
                    rntxtDrinage_MHGood.Text = dr["drinage_mh_Count"].ToString();
                    rntxtSewage_MHGood.Text = dr["Sewage_mh_Count"].ToString();
                    rnTxtElect_MHGood.Text = dr["Elect_mh_Count"].ToString();
                    rntxtSTC_MHGood.Text = dr["stc_mh_Count"].ToString();
                    rnTxtWater_MHGood.Text = dr["water_valve_Count"].ToString();

                    chkConcreteBlocks.Checked = bool.Parse(dr["CONCRETE_BLOCKS"].ToString());
                    chkConcreteBlocks_CheckedChanged(sender, e);

                    chkDrillingSTC.Checked = bool.Parse(dr["DRILLINGS_STC"].ToString());
                    chkDrillingSTC_CheckedChanged(sender, e);

                    chkDrillingElec.Checked = bool.Parse(dr["DRILLINGS_ELEC"].ToString());
                    chkDrillingElec_CheckedChanged(sender, e);

                    chkDrillingSewage.Checked = bool.Parse(dr["DRILLINGS_SEWAGE"].ToString());
                    chkDrillingSewage_CheckedChanged(sender, e);

                    chkDrillingWater.Checked = bool.Parse(dr["DRILLINGS_WATER"].ToString());
                    chkDrillingWater_CheckedChanged(sender, e);

                    rntxtConcreteBlocks.Text = dr["CONCRETE_BLOCKS_COUNT"].ToString();
                    rntxtDrillingElec.Text = dr["DRILLINGS_ELEC_LEN"].ToString();
                    rntxtDrillingSewage.Text = dr["DRILLINGS_SEWAG_LEN"].ToString();
                    rntxtDrillingSTC.Text = dr["DRILLINGS_STC_LEN"].ToString();
                    rntxtDrillingWater.Text = dr["DRILLINGS_WATER_LEN"].ToString();

                    rntxtDrinage_CBFair.Text = dr["DRAIN_CB_FAIR"].ToString();
                    rntxtDrinage_CBPoor.Text = dr["DRAIN_CB_POOR"].ToString();
                    rntxtDrinage_MH_Fair.Text = dr["DRAIN_MH_FAIR"].ToString();
                    rntxtDrinage_MH_Poor.Text = dr["DRAIN_MH_POOR"].ToString();
                    rnTxtElect_MH_Fair.Text = dr["ELEC_MH_FAIR"].ToString();
                    rnTxtElect_MH_Poor.Text = dr["ELEC_MH_POOR"].ToString();
                    rntxtSTC_MH_Fair.Text = dr["STC_MH_FAIR"].ToString();
                    rntxtSTC_MH_Poor.Text = dr["STC_MH_POOR"].ToString();
                    rntxtSewage_MH_Fair.Text = dr["SEWAGE_MH_FAIR"].ToString();
                    rntxtSewage_MH_Poor.Text = dr["SEWAGE_MH_POOR"].ToString();
                    rnTxtWater_MH_Fair.Text = dr["WATER_MH_FAIR"].ToString();
                    rnTxtWater_MH_Poor.Text = dr["WATER_MH_POOR"].ToString();

                    chkMidGood.Checked = bool.Parse(dr["MID_ISLAND_GOOD"].ToString());
                    chkMidFair.Checked = bool.Parse(dr["MID_ISLAND_FAIR"].ToString());
                    chkMidPoor.Checked = bool.Parse(dr["MID_ISLAND_POOR"].ToString());

                    chkSideGood.Checked = bool.Parse(dr["SIDE_CURB_GOOD"].ToString());
                    chkSideFair.Checked = bool.Parse(dr["SIDE_CURB_FAIR"].ToString());
                    chkSidePoor.Checked = bool.Parse(dr["SIDE_CURB_POOR"].ToString());

                    chkSideLGood.Checked = bool.Parse(dr["SID_ISLAND_GOOD"].ToString());
                    chkSideLFair.Checked = bool.Parse(dr["SID_ISLAND_FAIR"].ToString());
                    chkSideLPoor.Checked = bool.Parse(dr["SID_ISLAND_POOR"].ToString());


                    chkServiceLane.Checked = bool.Parse(dr["Service_Lane"].ToString());
                    chkOpeningService.Checked = bool.Parse(dr["Opening_Service"].ToString());
                    chkSlopeMain.Checked = bool.Parse(dr["Slope_Main"].ToString());
                    chkUturnMain.Checked = bool.Parse(dr["Uturn_Main"].ToString());

                    //chkLightGood.Checked = bool.Parse(dr["LIGHT_GOOD"].ToString());
                    //chkLightFair.Checked = bool.Parse(dr["LIGHT_FAIR"].ToString());
                    //chkLightPoor.Checked = bool.Parse(dr["LIGHT_POOR"].ToString());
                    //rntxtLightsCount.Text = dr["LIGHT_COUNT"].ToString();
                    rntxtLightGood.Text = dr["LIGHT_GOOD_COUNT"].ToString();
                    rntxtLightFair.Text = dr["LIGHT_FAIR_COUNT"].ToString();
                    rntxtLightPoor.Text = dr["LIGHT_POOR_COUNT"].ToString();

                    rntxtMegacomCount.Text = dr["MEGACOM_COUNT"].ToString();
                    rntxtMobyCount.Text = dr["MOBY_COUNT"].ToString();
                    rntxtUnipoleCount.Text = dr["UNIPOLE_COUNT"].ToString();


                    ddlSpeedBumpType.Items.Clear();
                    ddlSpeedBumpType.Items.Add(new ListItem("اختيار", "0"));
                    ddlSpeedBumpType.DataBind();
                    ddlSpeedBumpType.SelectedValue = dr["SPEED_BUMP_TYPE_ID"].ToString();

                    #endregion

                    #region IntersectingStreet

                    chkSoilPartsIntersect.Checked = bool.Parse(dr["UNPAVED_INTERSECT_TRUE"].ToString());
                    chkSoilPartsIntersect_CheckedChanged(sender, e);
                    rntxtUnpavedLengthIntersect.Text = dr["UNPAVED_INTERSECT_LENGTH"].ToString();
                    rntxtUnpavedWidthIntersect.Text = dr["UNPAVED_INTERSECT_WIDTH"].ToString();

                    ChkSideIslandIntersect.Checked = bool.Parse(dr["SIDEISLAND_INTERSECT_TRUE"].ToString());
                    ChkSideIslandIntersect_CheckedChanged(sender, e);
                    rntxtSideIsWidthIntersect.Text = dr["SIDEISLAND_WIDTH_INTERSECT"].ToString();

                    ChkMidIslandIntersect.Checked = bool.Parse(dr["MID_ISLAND_INTERSECT_TRUE"].ToString());
                    ChkMidIslandIntersect_CheckedChanged(sender, e);
                    rntxtMidIsWidthIntersect.Text = dr["MID_ISLAND_WIDTH_INTERSECT"].ToString();

                    ChkSideWalkIntersect.Checked = bool.Parse(dr["SIDE_CURB_INTERSECT_TRUE"].ToString());
                    ChkSideWalkIntersect_CheckedChanged(sender, e);
                    rntxtSideWalkWidthIntersect.Text = dr["SIDE_CURB_WIDTH_INTERSECT"].ToString();

                    ChkAg_MIDIntersect.Checked = bool.Parse(dr["AG_MID_ISLAND_INTERSECT_TRUE"].ToString());
                    ChkAg_SIDIntersect.Checked = bool.Parse(dr["AG_SID_ISLAND_INTERSECT_TRUE"].ToString());
                    ChkAg_SECIntersect.Checked = bool.Parse(dr["AG_SEC_ISLAND_INTERSECT_TRUE"].ToString());

                    chkPavMarkersIntersect.Checked = bool.Parse(dr["PAV_MARKERS_INTERSECT_TRUE"].ToString());
                    chkPavMarkersIntersect_CheckedChanged(sender, e);
                    chkPavePaintsIntersect.Checked = bool.Parse(dr["PAVE_MARK_PAINT_INTERSECT"].ToString());
                    chkPaveCeramicsIntersect.Checked = bool.Parse(dr["PAVE_MARK_CERAMICS_INTERSECT"].ToString());

                    ChkLightIntersect.Checked = bool.Parse(dr["LIGHTING_INTERSECT_TRUE"].ToString());
                    ChkLightIntersect_CheckedChanged(sender, e);
                    txtLightLocationIntersect.Text = dr["LIGHTING_LOC_INTERSECT"].ToString();

                    ChkTunnelIntersect.Checked = bool.Parse(dr["TUNNEL_INTERSECT_TRUE"].ToString());
                    chkBridgesIntersect.Checked = bool.Parse(dr["HAS_BRIDGES_INTERSECT"].ToString());
                    IntersectingHasTunnelsBridges();
                    txtBrdg_TUNEL_TYPEIntersect.Text = dr["BRDG_TUNEL_TYPE_INTERSECT"].ToString();


                    ChkDrinage_CBsIntersect.Checked = bool.Parse(dr["DRINAGE_CB_INTERSECT_TRUE"].ToString());
                    ChkDrinage_CBsIntersect_CheckedChanged(sender, e);

                    ChkDrinage_MH_Intersect.Checked = bool.Parse(dr["DRINAGE_MH_INTERSECT_TRUE"].ToString());
                    ChkDrinage_MH_Intersect_CheckedChanged(sender, e);

                    ChkSewage_MH_Intersect.Checked = bool.Parse(dr["SEWAGE_MH_INTERSECT_TRUE"].ToString());
                    ChkSewage_MH_Intersect_CheckedChanged(sender, e);

                    ChkElect_MHIntersect.Checked = bool.Parse(dr["ELECT_MH_INTERSECT_TRUE"].ToString());
                    ChkElect_MHIntersect_CheckedChanged(sender, e);

                    ChkSTC_MH_Intersect.Checked = bool.Parse(dr["STC_MH_INTERSECT_TRUE"].ToString());
                    ChkSTC_MH_Intersect_CheckedChanged(sender, e);

                    ChkWater_MH_Intersect.Checked = bool.Parse(dr["WATER_VALVE_INTERSECT_TRUE"].ToString());
                    ChkWater_MH_Intersect_CheckedChanged(sender, e);


                    rntxtDrinage_CBGoodIntersect.Text = dr["DRINAGE_CB_INTERSECT_COUNT"].ToString();
                    rntxtDrinage_MHGoodIntersect.Text = dr["DRINAGE_MH_INTERSECT_COUNT"].ToString();
                    rntxtSewage_MHGoodIntersect.Text = dr["SEWAGE_MH_INTERSECT_COUNT"].ToString();
                    rnTxtElect_MHGoodIntersect.Text = dr["ELECT_MH_INTERSECT_COUNT"].ToString();
                    rntxtSTC_MHGoodIntersect.Text = dr["STC_MH_INTERSECT_COUNT"].ToString();
                    rnTxtWater_MHGoodIntersect.Text = dr["WATER_VALVE_INTERSECT_COUNT"].ToString();


                    chkConcreteBlocks_intersect.Checked = bool.Parse(dr["CONCRETE_BLOCKS_INTERSECT"].ToString());
                    chkConcreteBlocks_intersect_CheckedChanged(sender, e);

                    chkDrillingSTC_Intersect.Checked = bool.Parse(dr["DRILLINGS_STC_INTERSECT"].ToString());
                    chkDrillingSTC_Intersect_CheckedChanged(sender, e);

                    chkDrillingElecIntersect.Checked = bool.Parse(dr["DRILLINGS_ELEC_INTERSECT"].ToString());
                    chkDrillingElecIntersect_CheckedChanged(sender, e);

                    chkDrillingSewageIntersect.Checked = bool.Parse(dr["DRILLINGS_SEWAGE_INTERSECT"].ToString());
                    chkDrillingSewageIntersect_CheckedChanged(sender, e);

                    chkDrillingWaterIntersect.Checked = bool.Parse(dr["DRILLINGS_WATER_INTERSECT"].ToString());
                    chkDrillingWaterIntersect_CheckedChanged(sender, e);


                    rntxtConcreteBlocks_intersect.Text = dr["CONCRETE_BLOCKS_COUNT_INTERSEC"].ToString();
                    rntxtDrillingElecIntersect.Text = dr["DRILLINGS_ELEC_LEN_INTERSECT"].ToString();
                    rntxtDrillingSewageIntersect.Text = dr["DRILLINGS_SEWAG_LEN_INTERSECT"].ToString();
                    rntxtDrillingSTC_Intersect.Text = dr["DRILLINGS_STC_LEN_INTERSECT"].ToString();
                    rntxtDrillingWaterIntersect.Text = dr["DRILLINGS_WATER_LEN_INTERSECT"].ToString();

                    rntxtDrinage_CBFairIntersect.Text = dr["DRAIN_CB_FAIR_INTERSECT"].ToString();
                    rntxtDrinage_CBPoorIntersect.Text = dr["DRAIN_CB_POOR_INTERSECT"].ToString();
                    rntxtDrinage_MH_FairIntersect.Text = dr["DRAIN_MH_FAIR_INTERSECT"].ToString();
                    rntxtDrinage_MH_PoorIntersect.Text = dr["DRAIN_MH_POOR_INTERSECT"].ToString();
                    rnTxtElect_MH_FairIntersect.Text = dr["ELEC_MH_FAIR_INTERSECT"].ToString();
                    rnTxtElect_MH_PoorIntersect.Text = dr["ELEC_MH_POOR_INTERSECT"].ToString();
                    rntxtSTC_MH_FairIntersect.Text = dr["STC_MH_FAIR_INTERSECT"].ToString();
                    rntxtSTC_MH_PoorIntersect.Text = dr["STC_MH_POOR_INTERSECT"].ToString();
                    rntxtSewage_MH_FairIntersect.Text = dr["SEWAGE_MH_FAIR_INTERSECT"].ToString();
                    rntxtSewage_MH_PoorIntersect.Text = dr["SEWAGE_MH_POOR_INTERSECT"].ToString();
                    rnTxtWater_MH_FairIntersect.Text = dr["WATER_MH_FAIR_INTERSECT"].ToString();
                    rnTxtWater_MH_PoorIntersect.Text = dr["WATER_MH_POOR_INTERSECT"].ToString();

                    chkMidIntersectGood.Checked = bool.Parse(dr["MID_ISLAND_GOOD_INTERSECT"].ToString());
                    chkMidIntersectFair.Checked = bool.Parse(dr["MID_ISLAND_FAIR_INTERSECT"].ToString());
                    chkMidIntersectPoor.Checked = bool.Parse(dr["MID_ISLAND_POOR_INTERSECT"].ToString());

                    chkSideIntersectGood.Checked = bool.Parse(dr["SIDE_CURB_GOOD_INTERSECT"].ToString());
                    chkSideIntersectFair.Checked = bool.Parse(dr["SIDE_CURB_FAIR_INTERSECT"].ToString());
                    chkSideIntersectPoor.Checked = bool.Parse(dr["SIDE_CURB_POOR_INTERSECT"].ToString());

                    chkSideLGoodIntersect.Checked = bool.Parse(dr["SID_ISLAND_GOOD_INTERSECT"].ToString());
                    chkSideLFairIntersect.Checked = bool.Parse(dr["SID_ISLAND_FAIR_INTERSECT"].ToString());
                    chkSideLPoorIntersect.Checked = bool.Parse(dr["SID_ISLAND_POOR_INTERSECT"].ToString());


                    chkOpeningServiceIntersect.Checked = bool.Parse(dr["Opening_Service_Intersect"].ToString());
                    chkServiceLaneIntersect.Checked = bool.Parse(dr["Service_Lane_Intersect"].ToString());
                    chkSlopeInterSect.Checked = bool.Parse(dr["Slope_Intersect"].ToString());
                    chkUturnIntersect.Checked = bool.Parse(dr["Uturn_Intersect"].ToString());

                    rntxtLightGoodIntersect.Text = dr["LIGHT_GOOD_INTER_COUNT"].ToString();
                    rntxtLightFairIntersect.Text = dr["LIGHT_FAIR_INTER_COUNT"].ToString();
                    rntxtLightPoorIntersect.Text = dr["LIGHT_POOR_INTER_COUNT"].ToString();

                    //chkLightGoodIntersect.Checked = bool.Parse(dr["LIGHT_INTERSECT_GOOD"].ToString());
                    //chkLightFairIntersect.Checked = bool.Parse(dr["LIGHT_INTERSECT_FAIR"].ToString());
                    //chkLightPoorIntersect.Checked = bool.Parse(dr["LIGHT_INTERSECT_POOR"].ToString());
                    //rntxtLightsCountIntersect.Text = dr["LIGHT_COUNT_INTERSECT"].ToString();

                    ChkHousingIntersect.Checked = bool.Parse(dr["HOUSES_INTERSECT"].ToString());
                    ChkCommercialIntersect.Checked = bool.Parse(dr["COMMERIAL_INTERSECT"].ToString());
                    ChkPublicsIntersect.Checked = bool.Parse(dr["PUBLICS_INTERSECT"].ToString());
                    ChkGardenIntersect.Checked = bool.Parse(dr["GARDENS_INTERSECT"].ToString());
                    ChkIndisterialIntersect.Checked = bool.Parse(dr["INDISTERIAL_INTERSECT"].ToString());
                    ChkRest_HouseIntersect.Checked = bool.Parse(dr["REST_HOUSE_INTERSECT"].ToString());

                    rntxtMegacomCountIntersect.Text = dr["MEGACOM_COUNT_INTERSECT"].ToString();
                    rntxtMobyCountIntersect.Text = dr["MOBY_COUNT_INTERSECT"].ToString();
                    rntxtUnipoleCountIntersect.Text = dr["UNIPOLE_COUNT_INTERSECT"].ToString();

                    ddlSpeedBumpTypeIntersect.Items.Clear();
                    ddlSpeedBumpTypeIntersect.Items.Add(new ListItem("اختيار", "0"));
                    ddlSpeedBumpTypeIntersect.DataBind();
                    ddlSpeedBumpTypeIntersect.SelectedValue = dr["SPEED_BUMP_TYPE_INTERSECT_ID"].ToString();

                    #endregion

                    chkWalkerBridges.Checked = bool.Parse(dr["PEDESTRIAN"].ToString());
                    chkWalkerBridges_CheckedChanged(sender, e);

                    ddlwalkerBridgeType.Items.Clear();
                    ddlwalkerBridgeType.Items.Add(new ListItem("اختيار", "0"));
                    ddlwalkerBridgeType.DataBind();

                    ddlwalkerBridgeType.SelectedValue = dr["PEDESTRIAN_BRIDGE_TYPE"].ToString();
                    rntxtWalkerBridgesCount.Text = dr["PEDESTRIAN_COUNT"].ToString();


                    ddlwalkerBridgeTypeIntersect.Items.Clear();
                    ddlwalkerBridgeTypeIntersect.Items.Add(new ListItem("اختيار", "0"));
                    ddlwalkerBridgeTypeIntersect.DataBind();

                    chkWalkerBridgesIntersect.Checked = bool.Parse(dr["PEDESTRIAN_INTERSECT"].ToString());
                    chkWalkerBridgesIntersect_CheckedChanged(sender, e);
                    ddlwalkerBridgeTypeIntersect.SelectedValue = dr["PEDESTRIAN_INTER_BRIDGE_TYPE"].ToString();
                    rntxtWalkerBridgesCountIntersect.Text = dr["PEDESTRIAN_INTERSECT_COUNT"].ToString();

                    rntxtGuideSignsCount.Text = dr["GUIDE_SIGNS_COUNT"].ToString();
                    rntxtGuideSignsIntersectCount.Text = dr["GUIDE_SIGNS_INTER_COUNT"].ToString();

                    ddlIntersectControlTypes.SelectedValue = dr["INTERSECT_CTRL_TYPE_ID"].ToString();
                    ddlIntersectTypes.SelectedValue = dr["INTERSECT_TYPE_ID"].ToString();
                    ddlIntersectTypes_SelectedIndexChanged(sender, e);

                    if (string.IsNullOrEmpty(dr["SURVEY_DATE"].ToString()))
                        rdtpSurveyDate.SelectedDate = null;
                    else
                        rdtpSurveyDate.SelectedDate = DateTime.Parse(dr["SURVEY_DATE"].ToString());

                    hlnkTunnels.Visible = false;
                    hlnkBridges.Visible = false;

                    lnkDetails_Click(sender, e);
                    gvSurveyorJob.DataBind();
                }
                else
                {
                    lblFeedback.Text = Feedback.NoData();
                    pnlIntersect.Visible = false;
                    pnlLinks.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
            //pnlIntersect.Visible = false;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        ddlMainStreetIntersection_SelectedIndexChanged(sender, e);
    }

    protected void ChkDrinage_CBsIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_CBsIntersect.Checked;
        rntxtDrinage_CBGoodIntersect.Enabled = isChecked;
        rntxtDrinage_CBFairIntersect.Enabled = isChecked;
        rntxtDrinage_CBPoorIntersect.Enabled = isChecked;


        if (!isChecked)
        {
            rntxtDrinage_CBGoodIntersect.Text = "";
            rntxtDrinage_CBFairIntersect.Text = "";
            rntxtDrinage_CBPoorIntersect.Text = "";
        }
        else
        {
            rntxtDrinage_CBGoodIntersect.Text = "0";
            rntxtDrinage_CBFairIntersect.Text = "0";
            rntxtDrinage_CBPoorIntersect.Text = "0";
        }
    }

    protected void ChkDrinage_MH_Intersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_MH_Intersect.Checked;
        rntxtDrinage_MHGoodIntersect.Enabled = isChecked;
        rntxtDrinage_MH_FairIntersect.Enabled = isChecked;
        rntxtDrinage_MH_PoorIntersect.Enabled = isChecked;
        if (!isChecked)
        {
            rntxtDrinage_MHGoodIntersect.Text = "";
            rntxtDrinage_MH_FairIntersect.Text = "";
            rntxtDrinage_MH_PoorIntersect.Text = "";
        }
        else
        {
            rntxtDrinage_MHGoodIntersect.Text = "0";
            rntxtDrinage_MH_FairIntersect.Text = "0";
            rntxtDrinage_MH_PoorIntersect.Text = "0";
        }
    }

    protected void ChkSewage_MH_Intersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSewage_MH_Intersect.Checked;
        rntxtSewage_MHGoodIntersect.Enabled = isChecked;
        rntxtSewage_MH_FairIntersect.Enabled = isChecked;
        rntxtSewage_MH_PoorIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSewage_MHGoodIntersect.Text = "";
            rntxtSewage_MH_FairIntersect.Text = "";
            rntxtSewage_MH_PoorIntersect.Text = "";
        }
        else
        {
            rntxtSewage_MHGoodIntersect.Text = "0";
            rntxtSewage_MH_FairIntersect.Text = "0";
            rntxtSewage_MH_PoorIntersect.Text = "0";
        }
    }

    protected void ChkElect_MHIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkElect_MHIntersect.Checked;
        rnTxtElect_MHGoodIntersect.Enabled = isChecked;
        rnTxtElect_MH_FairIntersect.Enabled = isChecked;
        rnTxtElect_MH_PoorIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            rnTxtElect_MHGoodIntersect.Text = "";
            rnTxtElect_MH_FairIntersect.Text = "";
            rnTxtElect_MH_PoorIntersect.Text = "";
        }
        else
        {
            rnTxtElect_MHGoodIntersect.Text = "0";
            rnTxtElect_MH_FairIntersect.Text = "0";
            rnTxtElect_MH_PoorIntersect.Text = "0";
        }
    }

    protected void ChkSTC_MH_Intersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSTC_MH_Intersect.Checked;
        rntxtSTC_MHGoodIntersect.Enabled = isChecked;
        rntxtSTC_MH_FairIntersect.Enabled = isChecked;
        rntxtSTC_MH_PoorIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSTC_MHGoodIntersect.Text = "";
            rntxtSTC_MH_FairIntersect.Text = "";
            rntxtSTC_MH_PoorIntersect.Text = "";
        }
        else
        {
            rntxtSTC_MHGoodIntersect.Text = "0";
            rntxtSTC_MH_FairIntersect.Text = "0";
            rntxtSTC_MH_PoorIntersect.Text = "0";
        }
    }

    protected void ChkWater_MH_Intersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkWater_MH_Intersect.Checked;
        rnTxtWater_MHGoodIntersect.Enabled = isChecked;
        rnTxtWater_MH_FairIntersect.Enabled = isChecked;
        rnTxtWater_MH_PoorIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            rnTxtWater_MHGoodIntersect.Text = "";
            rnTxtWater_MH_FairIntersect.Text = "";
            rnTxtWater_MH_PoorIntersect.Text = "";
        }
        else
        {
            rnTxtWater_MHGoodIntersect.Text = "0";
            rnTxtWater_MH_FairIntersect.Text = "0";
            rnTxtWater_MH_PoorIntersect.Text = "0";
        }
    }

    protected void ChkLightIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkLightIntersect.Checked;
        txtLightLocationIntersect.Enabled = isChecked;
        rntxtLightGoodIntersect.Enabled = isChecked;
        rntxtLightFairIntersect.Enabled = isChecked;
        rntxtLightPoorIntersect.Enabled = isChecked;
        //chkLightGoodIntersect.Enabled = isChecked;
        //chkLightFairIntersect.Enabled = isChecked;
        //chkLightPoorIntersect.Enabled = isChecked;
        //rntxtLightsCountIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            txtLightLocationIntersect.Text = "";
            rntxtLightGoodIntersect.Text = "0";
            rntxtLightFairIntersect.Text = "0";
            rntxtLightPoorIntersect.Text = "0";
            //chkLightGoodIntersect.Checked = false;
            //chkLightFairIntersect.Checked = false;
            //chkLightPoorIntersect.Checked = false;

            //rntxtLightsCountIntersect.Text = "0";
        }
    }

    protected void chkSoilPartsIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkSoilPartsIntersect.Checked;
        rntxtUnpavedLengthIntersect.Enabled = isChecked;
        rntxtUnpavedWidthIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtUnpavedWidthIntersect.Text = "0";
            rntxtUnpavedWidthIntersect.Text = "0";
        }
    }

    protected void chkBridgesIntersect_CheckedChanged(object sender, EventArgs e)
    {
        HasTunnelsBridges();
        IntersectingHasTunnelsBridges();
    }

    protected void ChkTunnelIntersect_CheckedChanged(object sender, EventArgs e)
    {
        HasTunnelsBridges();
        IntersectingHasTunnelsBridges();
    }

    private void IntersectingHasTunnelsBridges()
    {
        bool hasTunnel = ChkTunnelIntersect.Checked | chkBridgesIntersect.Checked;
        txtBrdg_TUNEL_TYPEIntersect.Enabled = hasTunnel;

        if (!hasTunnel)
            txtBrdg_TUNEL_TYPEIntersect.Text = "";
    }


    protected void ChkMidIslandIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkMidIslandIntersect.Checked;
        rntxtMidIsWidthIntersect.Enabled = isChecked;
        chkMidIntersectGood.Enabled = isChecked;
        chkMidIntersectFair.Enabled = isChecked;
        chkMidIntersectPoor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtMidIsWidthIntersect.Text = "";
            chkSideLGoodIntersect.Checked = false;
            chkSideLFairIntersect.Checked = false;
            chkSideLPoorIntersect.Checked = false;
        }
    }

    protected void ChkSideIslandIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSideIslandIntersect.Checked;
        rntxtSideIsWidthIntersect.Enabled = isChecked;
        chkSideLGoodIntersect.Enabled = isChecked;
        chkSideLFairIntersect.Enabled = isChecked;
        chkSideLPoorIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSideIsWidthIntersect.Text = "";
            chkSideLGoodIntersect.Checked = false;
            chkSideLFairIntersect.Checked = false;
            chkSideLPoorIntersect.Checked = false;
        }
    }

    protected void ChkSideWalkIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkSideWalkIntersect.Checked;
        rntxtSideWalkWidthIntersect.Enabled = isChecked;
        chkSideIntersectGood.Enabled = isChecked;
        chkSideIntersectFair.Enabled = isChecked;
        chkSideIntersectPoor.Enabled = isChecked;

        if (!isChecked)
        {
            rntxtSideWalkWidthIntersect.Text = "";
            chkSideIntersectGood.Checked = false;
            chkSideIntersectFair.Checked = false;
            chkSideIntersectPoor.Checked = false;
        }
    }

    protected void chkPavMarkers_CheckedChanged(object sender, EventArgs e)
    {
        bool cheked = chkPavMarkers.Checked;
        chkPaveCeramics.Enabled = cheked;
        chkPavePaints.Enabled = cheked;
        chkSlopeMain.Enabled = cheked;
        ddlSpeedBumpType.Enabled = cheked;

        if (!cheked)
        {
            chkPaveCeramics.Checked = false;
            chkPavePaints.Checked = false;
            chkSlopeMain.Checked = false;
            ddlSpeedBumpType.SelectedValue = "0";
        }
    }

    protected void chkPavMarkersIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool cheked = chkPavMarkersIntersect.Checked;
        chkPaveCeramicsIntersect.Enabled = cheked;
        chkPavePaintsIntersect.Enabled = cheked;
        chkSlopeInterSect.Enabled = cheked;
        ddlSpeedBumpTypeIntersect.Enabled = cheked;

        if (!cheked)
        {
            chkPaveCeramicsIntersect.Checked = false;
            chkPavePaintsIntersect.Checked = false;
            chkSlopeInterSect.Checked = false;
            ddlSpeedBumpTypeIntersect.SelectedValue = "0";
        }
    }

    protected void lbtnSearchMainSt_Click(object sender, EventArgs e)
    {
        SearchMainSt1.Visible = true;
    }

    protected void lbtnSearchIntersect_Click(object sender, EventArgs e)
    {
        if (ddlMainStreets.SelectedValue != "0")
        {
            //SearchIntersect1.MainStreetID = int.Parse(ddlMainStreets.SelectedValue);
            Session["MainStreetID"] = ddlMainStreets.SelectedValue;
            SearchIntersect1.Visible = true;
        }
        else
            SearchIntersect1.Visible = false;
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

    protected void onIntersectSearchChanged()
    {
        try
        {
            int selectedID = SearchIntersect1.SelectedIntersectionID;
            if (selectedID != 0)
            {
                ddlMainStreetIntersection.SelectedValue = selectedID.ToString();
                ddlMainStreetIntersection_SelectedIndexChanged(new Object(), new EventArgs());
                SearchIntersect1.Visible = false;
            }
            else
            {
                SearchIntersect1.Visible = false;
                ddlMainStreetIntersection.SelectedValue = "0";
                ddlMainStreetIntersection_SelectedIndexChanged(new Object(), new EventArgs());
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

    protected void chkDrillingSTC_Intersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingSTC_Intersect.Checked;
        rntxtDrillingSTC_Intersect.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingSTC_Intersect.Text = "";
    }

    protected void chkDrillingWaterIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingWaterIntersect.Checked;
        rntxtDrillingWaterIntersect.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingWaterIntersect.Text = "";
    }

    protected void chkDrillingElecIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingElecIntersect.Checked;
        rntxtDrillingElecIntersect.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingElecIntersect.Text = "";
    }

    protected void chkDrillingSewageIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkDrillingSewageIntersect.Checked;
        rntxtDrillingSewageIntersect.Enabled = isChecked;

        if (!isChecked)
            rntxtDrillingSewageIntersect.Text = "";
    }

    protected void chkConcreteBlocks_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkConcreteBlocks.Checked;
        rntxtConcreteBlocks.Enabled = isChecked;

        if (!isChecked)
            rntxtConcreteBlocks.Text = "";
    }

    protected void chkConcreteBlocks_intersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkConcreteBlocks_intersect.Checked;
        rntxtConcreteBlocks_intersect.Enabled = isChecked;

        if (!isChecked)
            rntxtConcreteBlocks_intersect.Text = "";
    }

    protected void ddlIntersectTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        imgIntersectType.ImageUrl = string.Format("LoadIntersectTypeImage.aspx?typeID={0}", ddlIntersectTypes.SelectedValue);
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

    protected void chkWalkerBridgesIntersect_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkWalkerBridgesIntersect.Checked;
        ddlwalkerBridgeTypeIntersect.Enabled = isChecked;
        rntxtWalkerBridgesCountIntersect.Enabled = isChecked;

        if (!isChecked)
        {
            ddlwalkerBridgeTypeIntersect.SelectedValue = "0";
            rntxtWalkerBridgesCountIntersect.Text = "";
        }
    }

    private void BoldUnBoldLinks(int i)
    {
        lnkDetails.Font.Bold = (i == 1);
        lnkUses.Font.Bold = (i == 2);
        lnkIslands.Font.Bold = (i == 3);
        lnkBridges.Font.Bold = (i == 4);
        lnkLights.Font.Bold = (i == 5);
        lnkAg.Font.Bold = (i == 6);
        lnkMainholes.Font.Bold = (i == 7);
        lnkDrills.Font.Bold = (i == 8);
        lnkSurveyor.Font.Bold = (i == 9);
    }

    protected void lnkDetails_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 0;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(1);
    }

    protected void lnkUses_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 1;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(2);
    }

    protected void lnkIslands_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 2;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(3);
    }

    protected void lnkBridges_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 3;
        mlvSectionInfo.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(4);
    }

    protected void lnkLights_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 4;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(5);
    }

    protected void lnkAg_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 5;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(6);
    }

    protected void lnkMainholes_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 6;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(7);
    }

    protected void lnkDrills_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = 7;
        pnlIntersect.Visible = true;
        pnlSurveyor.Visible = false;
        BoldUnBoldLinks(8);
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
                int.Parse(rntxtSurveyNo.Text), txtNotes.Text, ddlMainStreetIntersection.SelectedValue, JobType.Intersection);

            if (saved)
            {
                btnCancel_Click(sender, e);
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvSurveyorJob.DataBind();

                mlvSectionInfo.ActiveViewIndex = 0;
                pnlSurveyor.Visible = false;
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
            lblFeedbackSave.Text = lblFeedback.Text;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.DeleteSuccessfull();
            lblFeedbackSave.Text = lblFeedback.Text;
        }
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

    protected void lnkSurveyor_Click(object sender, EventArgs e)
    {
        mlvSectionInfo.ActiveViewIndex = -1;
        pnlIntersect.Visible = false;
        pnlSurveyor.Visible = true;
        BoldUnBoldLinks(9);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlMainStreets_SelectedIndexChanged(o, (EventArgs)e);
    }

}