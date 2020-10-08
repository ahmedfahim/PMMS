using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;
using System.Data;

public partial class ASPX_Archive_InsertFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
        {
            ddlFilterUsers.SelectedValue = "0";
            DataTable FilterUsers = new SystemUsers().GetFilterUsers();
            ddlFilterUsers.DataSource = FilterUsers;
            ddlFilterUsers.DataValueField = FilterUsers.Columns[0].ColumnName;
            ddlFilterUsers.DataTextField = FilterUsers.Columns[1].ColumnName;
            ddlFilterUsers.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PanelNewStreets.Visible = false;
        if (!bool.Parse(Session["canEdit"].ToString()))
            throw new Exception(Feedback.NoPermissions());
        if (Session["UserID"].ToString() != "37")
            throw new Exception(Feedback.NoPermissions());
        if (ddlRegions.SelectedValue != "0" && ddlFilterUsers.SelectedValue != "0")
        {
            if (new SystemUsers().InsertReceivedFiles(ddlRegions.SelectedValue, ddlFilterUsers.SelectedValue))
            {
                lblFeedback.Text = Feedback.InsertSuccessfull();
                btnAll_Click(null, null);
            }
            else
                lblFeedback.Text = Feedback.UpdateExceptionUnique();
        }
        else
            lblFeedback.Text = "يجب اختيار المدخل ورقم المنطقة اولا ";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";
        PanelNewStreets.Visible = false;

    }


    protected void btnAll_Click(object sender, EventArgs e)
    {
        try
        {
            PanelNewStreets.Visible = true;
            //ViewState["dirState"] = new SystemUsers().GetReceivedFiles();
            //gvRegionSamples.DataSource = ViewState["dirState"];
            //ViewState["sortdr"] = "Asc";
            gvRegionSamples.DataBind();

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }
    protected void gvRegionSamples_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dtrslt = (DataTable)ViewState["dirState"];
        //if (dtrslt.Rows.Count > 0)
        //{
        //    if (Convert.ToString(ViewState["sortdr"]) == "Asc")
        //    {
        //        dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
        //        ViewState["sortdr"] = "Desc";
        //    }
        //    else
        //    {
        //        dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
        //        ViewState["sortdr"] = "Asc";
        //    }
        //    gvRegionSamples.DataSource = dtrslt;
        //    gvRegionSamples.DataBind();
        //}

    }

    protected void gvRegionSamples_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
            throw new Exception(Feedback.NoPermissions());
        if (Session["UserID"].ToString() != "37")
            throw new Exception(Feedback.NoPermissions());
        lblFeedback.Visible = true;
        DateTime date;
        if (DateTime.TryParse(gvRegionSamples.Rows[e.NewSelectedIndex].Cells[5].Text, out date) && date >= DateTime.Today)
            lblFeedback.Text = "تم تسليم الملف من قبل";
        else
        {
            Label lbl1 = gvRegionSamples.Rows[e.NewSelectedIndex].FindControl("Label1") as Label;
            if (new SystemUsers().UpdateReceivedFiles(lbl1.ToolTip))
            {
                lblFeedback.Text = string.Empty;
                gvRegionSamples.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();
        }
    }


    protected void gvRegionSamples_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
        else
        {
            if (Session["UserID"].ToString() != "37")
                throw new Exception(Feedback.NoPermissions());
            else
            {
                Label lbl1 = gvRegionSamples.Rows[e.RowIndex].FindControl("Label9") as Label;
                DropDownList Drp1 = gvRegionSamples.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
                if (Drp1.SelectedValue == "0")
                {
                    lblFeedback.Text = "يجب اختيار اسم المستخدم";
                    e.Cancel = true;
                }
                ObjectDataSource1.UpdateParameters[0].DefaultValue = lbl1.ToolTip;

                ObjectDataSource1.UpdateParameters[1].DefaultValue = Drp1.SelectedValue;
            }
        }
    }


  
}