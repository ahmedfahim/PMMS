﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Sections_EditTunnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!IsPostBack)
            {
                if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                    Response.Redirect("~/ASPX/Default.aspx", false);

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    DataTable dt = new Tunnel().GetTunnelInfo(id);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        txtBridgeName.Text = dr["TUNNEL_NAME"].ToString();
                        txtBridgeNo.Text = dr["TUNNEL_NO"].ToString();

                        ChkLight.Checked = bool.Parse(dr["LIGHTING_TRUE"].ToString());
                        ChkLight_CheckedChanged(sender, e);
                        txtLightLocation.Text = dr["LIGHTING_LOC"].ToString();
                        rntxtLightCount.Text = dr["LIGHTING_COUNT"].ToString();

                        ChkMidIsland.Checked = bool.Parse(dr["MID_ISLAND_TRUE"].ToString());
                        ChkMidIsland_CheckedChanged(sender, e);
                        chkMidIslandGood.Checked = bool.Parse(dr["MID_ISLAND_GOOD"].ToString());

                        ChkSideWalk.Checked = bool.Parse(dr["SIDE_CURB_TRUE"].ToString());
                        ChkSideWalk_CheckedChanged(sender, e);
                        chkSideCurbGood.Checked = bool.Parse(dr["SIDE_CURB_GOOD"].ToString());

                        chkPaints.Checked = bool.Parse(dr["PAINT_TRUE"].ToString());
                        chkPaints_CheckedChanged(sender, e);
                        chkPaintGood.Checked = bool.Parse(dr["PAINT_GOOD"].ToString());

                        ChkElect_MH.Checked = bool.Parse(dr["ELEC_MH_TRUE"].ToString());
                        ChkElect_MH_CheckedChanged(sender, e);
                        rnTxtElect_MHCount.Text = dr["ELEC_MH_COUNT"].ToString();

                        ChkSTC_MH.Checked = bool.Parse(dr["STC_MH_TRUE"].ToString());
                        ChkSTC_MH_CheckedChanged(sender, e);
                        rntxtSTC_MHCount.Text = dr["STC_MH_COUNT"].ToString();

                        ChkDrinage_CBs.Checked = bool.Parse(dr["DRAIN_CB_TRUE"].ToString());
                        ChkDrinage_CBs_CheckedChanged(sender, e);
                        chkDrainCbGood.Checked = bool.Parse(dr["DRAIN_CB_GOOD"].ToString());

                        chkTrafficSigns.Checked = bool.Parse(dr["TRAFFIC_SIGNS_TRUE"].ToString());
                        chkGuideSigns.Checked = bool.Parse(dr["GUIDE_SIGNS_TRUE"].ToString());

                        txtDetails.Text = dr["DETAILS"].ToString();
                        ddlContractors.SelectedValue = dr["CONTRACTOR_ID"].ToString();

                        ddlBridgeType.SelectedValue = dr["TUNNEL_TYPE_ID"].ToString();
                        ddlCammerTypes.SelectedValue = dr["CAMMERS_TYPE_ID"].ToString();
                        ddlSupporterTypes.SelectedValue = dr["SUPPORTER_TYPE_ID"].ToString();
                        ddlBarrierTypes.SelectedValue = dr["SIDE_BARRIER_TYPE_ID"].ToString();
                        ddlSurfaceTypes.SelectedValue = dr["SURFACE_TYPE_ID"].ToString();

                        rntxtOpeningsCount.Text = dr["OPENINGS_COUNT"].ToString();
                        rntxtCammerHeight.Text = dr["CAMMERS_HEIGHT"].ToString();
                        rntxtSupportersCount.Text = dr["SUPPORTERS_COUNT"].ToString();
                        rntxtLanesCount.Text = dr["LANES_COUNT"].ToString();
                        rntxtLaneWidth.Text = dr["LANE_WIDTH"].ToString();
                        rntxtTileWidth.Text = dr["TILE_WIDTH"].ToString();
                        rntxtEntryWidth.Text = dr["ENTRANCE_WIDTH"].ToString();
                        rntxtX.Text = dr["COORD_X"].ToString();
                        rntxtY.Text = dr["COORD_Y"].ToString();
                        rntxtZ.Text = dr["COORD_Z"].ToString();
                        rntxtBYear.Text = dr["BUILT_YEAR"].ToString();
                        //rntxtBridgeHeight.Text = dr["BRIDGE_HEIGHT"].ToString();
                        rntxtCurbHeight.Text = dr["CURB_HEIGHT"].ToString();
                        rntxtCurbWidth.Text = dr["CURB_WIDTH"].ToString();
                        rntxtMidIslandWidth.Text = dr["MID_ISLAND_WIDTH"].ToString();

                        chkCurved.Checked = bool.Parse(dr["CURVED"].ToString());
                        chkPerpend.Checked = bool.Parse(dr["ROAD_PERPEND"].ToString());


                        lnkFiles.NavigateUrl = string.Format("~/aspx/operations/TunnelBridgesFiles.aspx?tunnelID={0}&bridgeID={1}", id, 0);
                    }
                    else
                        lblFeedback.Text = Feedback.NoData();
                }
                else
                    Response.Redirect("SectionInfo.aspx", false);
            }

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ChkLight_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkLight.Checked;
        txtLightLocation.Enabled = isChecked;
        rntxtLightCount.Enabled = isChecked;

        if (!isChecked)
        {
            txtLightLocation.Text = "";
            rntxtLightCount.Text = "";
        }
    }

    protected void ChkMidIsland_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkMidIsland.Checked;
        chkMidIslandGood.Enabled = isChecked;
        rntxtMidIslandWidth.Enabled = isChecked;

        if (!isChecked)
        {
            chkMidIslandGood.Checked = false;
            rntxtMidIslandWidth.Value = 0;
        }
    }

    protected void ChkSideWalk_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkMidIsland.Checked;
        ChkSideWalk.Enabled = isChecked;

        if (!isChecked)
            chkMidIslandGood.Checked = false;
    }

    protected void chkPaints_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkTrafficSigns.Checked;
        chkPaintGood.Enabled = isChecked;

        if (!isChecked)
            chkPaintGood.Checked = false;
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


    private bool AreValidData()
    {
        if (string.IsNullOrEmpty(txtBridgeName.Text))
        {
            txtBridgeName.Focus();
            throw new Exception("الرجاء إدخال اسم الجسر");
        }
        else if (ChkLight.Checked && string.IsNullOrEmpty(rntxtLightCount.Text))
        {
            rntxtLightCount.Focus();
            throw new Exception("الرجاء إدخال عدد أعمدة الإنارة");
        }
        else if (ChkLight.Checked && string.IsNullOrEmpty(txtLightLocation.Text))
        {
            txtLightLocation.Focus();
            throw new Exception("الرجاء إدخال موقع أعمدة الإنارة");
        }
        else if (ChkElect_MH.Checked && string.IsNullOrEmpty(rnTxtElect_MHCount.Text))
        {
            rntxtLightCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الكهرباء");
        }
        else if (ChkSTC_MH.Checked && string.IsNullOrEmpty(rntxtSTC_MHCount.Text))
        {
            rntxtSTC_MHCount.Focus();
            throw new Exception("الرجاء إدخال عدد مناهل الهاتف");
        }
        else if (ChkMidIsland.Checked && string.IsNullOrEmpty(rntxtMidIslandWidth.Text))
        {
            rntxtMidIslandWidth.Focus();
            throw new Exception("الرجاء إدخال عرض الجزيرة الوسطية");
        }
        //else if (ddlContractors.SelectedValue == "0")
        //{
        //    ddlContractors.Focus();
        //    throw new Exception("الرجاء اختيار مقاول التنفيذ");
        //}
        else
            return true;
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (!AreValidData())
                return;

            bool saved = new Tunnel().Update(txtBridgeName.Text, txtDetails.Text, ChkMidIsland.Checked, ChkSideWalk.Checked, chkMidIslandGood.Checked, chkSideCurbGood.Checked,
                ChkLight.Checked, txtLightLocation.Text, rntxtLightCount.Text, ChkElect_MH.Checked, ChkSTC_MH.Checked, rnTxtElect_MHCount.Text, rntxtSTC_MHCount.Text,
                chkTrafficSigns.Checked, chkPaintGood.Checked, chkTrafficSigns.Checked, chkGuideSigns.Checked, ChkDrinage_CBs.Checked, chkDrainCbGood.Checked,
                int.Parse(Request.QueryString["id"]), int.Parse(ddlContractors.SelectedValue), txtBridgeNo.Text, Session["UserName"].ToString(), int.Parse(ddlBridgeType.SelectedValue), int.Parse(ddlCammerTypes.SelectedValue),
                rntxtCammerHeight.Value, int.Parse(ddlSupporterTypes.SelectedValue), (int?)rntxtSupportersCount.Value, int.Parse(ddlBarrierTypes.SelectedValue),
                (int?)rntxtLanesCount.Value, rntxtLaneWidth.Value, rntxtTileWidth.Value, rntxtEntryWidth.Value, rntxtX.Value, rntxtY.Value, rntxtZ.Value, (int?)rntxtBYear.Value,
                chkCurved.Checked, chkPerpend.Checked, rntxtCurbHeight.Value, rntxtCurbWidth.Value, rntxtMidIslandWidth.Value, (int?)rntxtOpeningsCount.Value, 
                int.Parse(ddlSurfaceTypes.SelectedValue));
                //, rntxtBridgeHeight.Value);

            lblFeedback.Text = (saved) ? Feedback.UpdateSuccessfull() : Feedback.UpdateException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        string url = string.Format("EditTunnel.aspx?id={0}", Request.QueryString["id"]);
        Response.Redirect(url, false);
    }

    protected void ChkDrinage_CBs_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_CBs.Checked;
        chkDrainCbGood.Enabled = isChecked;

        if (!isChecked)
            chkDrainCbGood.Checked = false;
    }

}
