using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

public partial class ASPX_Archive_ReadyFWD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnFinshed.Visible = false;
        lblFeedback.Text = string.Empty;
        string v1 = new JpmmsClasses.BL.MainStreet().SumReadyFWD(null);
        string v2 = new JpmmsClasses.BL.MainStreet().SumReadyFWD(false);
        string v3 = new JpmmsClasses.BL.MainStreet().SumReadyFWD(true);
        lblSumReadyFWDNULL.Text = "    عدد النقاط الناقصة " + v1;
        lblSumReadyFWDFalse.Text = "    عدد النقاط بالنظام " + v2;
        lblSumReadyFWDTrue.Text = "    عدد النقاط المنجزة " + v3;
        lblSum.Text = "  إجمالي  عدد النقاط  " + (float.Parse(v1) + float.Parse(v2) + float.Parse(v3)).ToString();
        int SumSections = 0, SumFinshed = 0;
        gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo((int.Parse(ddlRegions.SelectedValue)));
        gvRegionIRI.DataBind();
        if (gvRegionIRI.Rows.Count > 0)
        {
            gvFWD.DataSource = new JpmmsClasses.BL.MainStreet().ReadyFWD(ddlRegions.SelectedItem.Text);
            gvFWD.DataBind();
            bool is_integer = unchecked(gvFWD.Rows.Count / 3f - gvFWD.Rows.Count / 3 == 0);
            lblFeedback0.Text = gvFWD.Rows.Count / 3f + " نقطة ";
            if (is_integer)
            {
                CheckBox chkAllDelete = gvFWD.HeaderRow.FindControl("chkSelect") as CheckBox;
                chkAllDelete.Visible = false;
                for (int i = 0; i < gvFWD.Rows.Count; i++)
                {
                    DropDownList DrpDwnLane = gvFWD.Rows[i].FindControl("DrpDwnListLane") as DropDownList;
                    DropDownList DrpDwnSection = gvFWD.Rows[i].FindControl("DrpDwnListSection") as DropDownList;
                    CheckBox ChkBoxSave = gvFWD.Rows[i].FindControl("ChkBoxSave") as CheckBox;
                    CheckBox ChkBoxDelete = gvFWD.Rows[i].FindControl("ChkBoxDelete") as CheckBox;
                    CheckBox ChkFinshed = (CheckBox)gvFWD.Rows[i].Cells[14].Controls[0];

                    ChkBoxSave.Visible = !((CheckBox)gvFWD.Rows[i].Cells[14].Controls[0]).Checked;
                    ChkBoxDelete.Visible = ((CheckBox)gvFWD.Rows[i].Cells[14].Controls[0]).Checked;
                    gvFWD.Rows[i].Cells[15].Controls[0].Visible = false;

                    if (i % 3 == 0)
                    {

                        if (gvFWD.Rows[i].Cells[8].Text == "0" && ChkFinshed.Checked == false)
                        {
                            SumSections++;
                            DrpDwnSection.DataSource = new JpmmsClasses.BL.MainStreet().GetSections(ddlRegions.SelectedItem.Text);
                            DrpDwnSection.DataTextField = "SECTION_NO";
                            DrpDwnSection.DataValueField = "SECTION_ID";
                            DrpDwnSection.DataBind();
                            DrpDwnLane.DataSource = new JpmmsClasses.BL.MainStreet().GetLanes(ddlRegions.SelectedItem.Text);
                            DrpDwnLane.DataTextField = "LANE_TYPE";
                            DrpDwnLane.DataValueField = "LANE_TYPE";
                            DrpDwnLane.DataBind();
                        }
                        else if (ChkFinshed.Checked)
                        {
                            if (gvFWD.Rows[i].Cells[8].Text == "0")
                                gvFWD.Rows[i].Cells[15].Controls[0].Visible = true;

                            chkAllDelete.Visible = true;
                            ChkBoxDelete.Enabled = true;
                            DrpDwnLane.Visible = false;
                            DrpDwnSection.Visible = false;
                            gvFWD.Rows[i].Cells[11].Controls[0].Visible = false;
                            BtnFinshed.Visible = true;
                            SumFinshed++;
                        }
                        else
                        {
                            DrpDwnLane.Visible = false;
                            DrpDwnSection.Visible = false;
                            gvFWD.Rows[i].Cells[11].Controls[0].Visible = false;

                        }

                    }
                    else
                    {
                        // BtnSave.Text = gvFWD.DataKeys[i].Value.ToString();
                        if (ChkFinshed.Checked)
                        {
                            ChkBoxDelete.Enabled = true;
                            chkAllDelete.Visible = true;
                            BtnFinshed.Visible = true;
                            SumFinshed++;
                        }
                        DrpDwnLane.Visible = false;
                        DrpDwnSection.Visible = false;
                        gvFWD.Rows[i].Cells[11].Controls[0].Visible = false;

                    }
                }
                if (SumFinshed == gvFWD.Rows.Count)
                    ((CheckBox)gvFWD.HeaderRow.FindControl("chkInsert")).Visible = false;

            }
            else
            {
                gvFWD.DataSource = null;
                gvFWD.DataBind();
            }

            if (SumSections > 0)
                lblFeedback.Text = "  المقاطع من المعدة " + SumSections.ToString();

        }
        else
        {
            lblFeedback0.Text = Feedback.NoData();
            gvFWD.DataSource = null;
            gvFWD.DataBind();
        }

    }
    protected void gvFWD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (Session["UserID"].ToString() == "59")
        {
            lblFeedback.Text = "";
            DropDownList DrpDwnLane = gvFWD.Rows[e.NewSelectedIndex].FindControl("DrpDwnListLane") as DropDownList;
            DropDownList DrpDwnSection = gvFWD.Rows[e.NewSelectedIndex].FindControl("DrpDwnListSection") as DropDownList;
            if (((CheckBox)gvFWD.Rows[e.NewSelectedIndex].FindControl("ChkBoxSave")).Checked && DrpDwnSection.SelectedValue != "-1" && DrpDwnLane.SelectedValue != "-1")
            {
                StringBuilder BuildmyString = new StringBuilder();
                for (int i = 0; i < gvFWD.Rows.Count; i++)
                {
                    CheckBox ChkBoxSave = gvFWD.Rows[i].FindControl("ChkBoxSave") as CheckBox;
                    if (ChkBoxSave.Checked)
                    {
                        BuildmyString.Append(gvFWD.DataKeys[i].Value.ToString());
                        BuildmyString.Append(",");
                    }
                }
                BuildmyString.Remove(BuildmyString.Length - 1, 1);
                if (new JpmmsClasses.BL.MainStreet().UpdateReadyFWD(DrpDwnSection.SelectedItem.Text, DrpDwnLane.SelectedValue, BuildmyString.ToString(), true))
                {
                    e.Cancel = true;
                    ddlRegions_SelectedIndexChanged(null, null);
                }
                else
                {
                    e.Cancel = true;
                    lblFeedback.Text = false.ToString();
                }
            }
            else
            {
                e.Cancel = true;
                lblFeedback.Text = "يجب اختيار المقطع والحارة قبل الإضافة ";
            }
        }
        else
            lblFeedback.Text = Feedback.NoPermissions();

    }
    protected void gvFWD_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Session["UserID"].ToString() == "59")
        {
            lblFeedback.Text = "";
            if (((CheckBox)gvFWD.Rows[e.RowIndex].FindControl("ChkBoxDelete")).Checked && ((CheckBox)gvFWD.Rows[e.RowIndex].Cells[14].Controls[0]).Checked)
            {
                StringBuilder BuildmyString = new StringBuilder();
                for (int i = 0; i < gvFWD.Rows.Count; i++)
                {
                    CheckBox ChkBoxDelete = gvFWD.Rows[i].FindControl("ChkBoxDelete") as CheckBox;
                    if (ChkBoxDelete.Checked)
                    {
                        BuildmyString.Append(gvFWD.DataKeys[i].Value.ToString());
                        BuildmyString.Append(",");
                    }
                }
                BuildmyString.Remove(BuildmyString.Length - 1, 1);
                if (new JpmmsClasses.BL.MainStreet().DeleteReadyFWD(BuildmyString.ToString()))
                {
                    e.Cancel = true;
                    ddlRegions_SelectedIndexChanged(null, null);
                }
                else
                {
                    e.Cancel = true;
                    lblFeedback.Text = false.ToString();
                }
            }
            else
            {
                e.Cancel = true;
                lblFeedback.Text = "يجب الاختيار قبل الحذف ";
            }
        }
        else
            lblFeedback.Text = Feedback.NoPermissions();
    }
    protected void BtnFinshed_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "59")
        {
            if (new JpmmsClasses.BL.MainStreet().ValidateReadyFWD(ddlRegions.SelectedItem.Text))
            {
                if (new JpmmsClasses.BL.MainStreet().UpdateFinshedReadyFWD(ddlRegions.SelectedItem.Text))
                {
                    lblFeedback.Text = " تم انتهاء الشارع";
                    BtnFinshed.Visible = false;
                    gvFWD.DataSource = null;
                    gvFWD.DataBind();
                }
                else
                    lblFeedback.Text = Feedback.UpdateUNSuccessfull();
            }
            else
                lblFeedback.Text = "تاكد من انتهاء الشارع";
        }
        else
            lblFeedback.Text = Feedback.NoPermissions();
    }
}