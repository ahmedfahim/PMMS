using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;

public partial class ASPX_Intersections_Tunnels : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (string.IsNullOrEmpty(Request.QueryString["InterID"]))
                Response.Redirect("~/aspx/home/Default.aspx", false);
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

        if (!isChecked)
            chkMidIslandGood.Checked = false;
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
            //string lang = ;

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (!AreValidData())
                return;

            bool saved = new Tunnel().Insert(txtBridgeName.Text, 0, int.Parse(Request.QueryString["InterID"]), txtDetails.Text, ChkMidIsland.Checked, ChkSideWalk.Checked,
                chkMidIslandGood.Checked, chkSideCurbGood.Checked, ChkLight.Checked, txtLightLocation.Text, rntxtLightCount.Text, ChkElect_MH.Checked, ChkSTC_MH.Checked,
                rnTxtElect_MHCount.Text, rntxtSTC_MHCount.Text, chkTrafficSigns.Checked, chkPaintGood.Checked, chkTrafficSigns.Checked, chkGuideSigns.Checked,
                ChkDrinage_CBs.Checked, chkDrainCbGood.Checked, int.Parse(ddlContractors.SelectedValue), txtBridgeNo.Text, Session["UserName"].ToString(),
                int.Parse(ddlBridgeType.SelectedValue), int.Parse(ddlCammerTypes.SelectedValue), rntxtCammerHeight.Value, int.Parse(ddlSupporterTypes.SelectedValue),
                (int?)rntxtSupportersCount.Value, int.Parse(ddlBarrierTypes.SelectedValue), (int?)rntxtLanesCount.Value, rntxtLaneWidth.Value, rntxtTileWidth.Value,
                rntxtEntryWidth.Value, rntxtX.Value, rntxtY.Value, rntxtZ.Value, (int?)rntxtBYear.Value, chkCurved.Checked, chkPerpend.Checked, rntxtCurbHeight.Value,
                rntxtCurbWidth.Value, rntxtMidIslandWidth.Value, (int?)rntxtOpeningsCount.Value, int.Parse(ddlSurfaceTypes.SelectedValue)); //, rntxtBridgeHeight.Value);

            if (saved)
            {
                lblFeedback.Text = Feedback.InsertSuccessfull();
                UpdateCancelButton_Click(sender, e);
                //gvTunnels.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void UpdateCancelButton_Click(object sender, EventArgs e)
    {
        string url = string.Format("Tunnels.aspx?InterID={0}", Request.QueryString["InterID"]);
        Response.Redirect(url, false);
    }

    protected void ChkDrinage_CBs_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = ChkDrinage_CBs.Checked;
        chkDrainCbGood.Enabled = isChecked;

        if (!isChecked)
            chkDrainCbGood.Checked = false;
    }

    protected void odsTunnels_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.DeleteSuccessfull();
    }

    protected void gvTunnels_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

}
