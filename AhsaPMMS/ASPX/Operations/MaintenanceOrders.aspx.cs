using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASPX_Operations_MaintenanceOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (!IsPostBack)
            btnCancelContract_Click(sender, e);
    }

    protected void odsMaintainOrders_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            try
            {
                lblFeedback.Text = Feedback.DeleteSuccessfull();
                gvMaintainOrdersDetails.DataBind();
                gvMaintainOrdersDetails.SelectedIndex = -1;
                gvMaintainOrders.SelectedIndex = -1;
                //gvMaintainOrders_SelectedIndexChanged(sender, e);
                pnlDetails.Visible = false;
                pnlLocations.Visible = false;
            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.Message;
            }
        }
    }

    protected void odsMaintainOrders_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.InsertSuccessfull();
    }

    protected void odsMaintainOrders_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void odsMaintainOrdersDetails_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.DeleteSuccessfull();
    }

    protected void odsMaintainOrdersDetails_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblFeedback.Text = Feedback.UpdateSuccessfull();
    }

    protected void odsMaintainOrdersDetails_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblFeedback.Text = Feedback.InsertSuccessfull();
            gvMaintainOrdersDetails.SelectedIndex = -1;
            pnlLocations.Visible = false;
            //gvTrafficEnhanceDetails_SelectedIndexChanged(sender, new EventArgs());
        }
    }

    protected void radSection_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlMainStreetSection.Visible = true;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = false;
        ddlRegionSecondaryStreets.Visible = false;
        ddlRegionNames.Visible = false;
        ddlMunic.Visible = false;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radIntersect_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = true;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = true;
        ddlRegions.Visible = false;
        ddlRegionSecondaryStreets.Visible = false;
        ddlRegionNames.Visible = false;
        ddlMunic.Visible = false;

        ddlMainStreets.SelectedValue = "0";
        ddlMainStreets_SelectedIndexChanged(sender, e);
    }

    protected void radRegion_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = true;
        ddlRegionSecondaryStreets.Visible = true;
        ddlRegionNames.Visible = false;
        ddlMunic.Visible = false;

        ddlRegions.SelectedValue = "0";
        ddlRegions_SelectedIndexChanged(sender, e);
    }

    protected void ddlMainStreets_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            //string select = (.Contains("ar")) ? "اختيار" : "Select";

            if (radSection.Checked)
            {
                ddlMainStreetSection.Items.Clear();
                ddlMainStreetSection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetSection.DataBind();
            }
            else if (radIntersect.Checked)
            {
                ddlMainStreetIntersection.Items.Clear();
                ddlMainStreetIntersection.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
                ddlMainStreetIntersection.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //string select = (.Contains("ar")) ? "اختيار" : "Select";

            ddlRegionSecondaryStreets.Items.Clear();
            ddlRegionSecondaryStreets.Items.Add(new Telerik.Web.UI.RadComboBoxItem("اختيار", "0"));
            ddlRegionSecondaryStreets.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnAddLocation_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";
            lblAddFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool saved = false;
            int maintOrderDetailID = int.Parse(gvMaintainOrdersDetails.SelectedValue.ToString());
            int sectionID = string.IsNullOrEmpty(ddlMainStreetSection.SelectedValue) ? 0 : int.Parse(ddlMainStreetSection.SelectedValue);
            int mainStID = string.IsNullOrEmpty(ddlMainStreets.SelectedValue) ? 0 : int.Parse(ddlMainStreets.SelectedValue);
            int intersectID = string.IsNullOrEmpty(ddlMainStreetIntersection.SelectedValue) ? 0 : int.Parse(ddlMainStreetIntersection.SelectedValue);
            int regionID = string.IsNullOrEmpty(ddlRegions.SelectedValue) ? 0 : int.Parse(ddlRegions.SelectedValue);
            int secStID = string.IsNullOrEmpty(ddlRegionSecondaryStreets.SelectedValue) ? 0 : int.Parse(ddlRegionSecondaryStreets.SelectedValue);


            if (radSection.Checked)
                saved = new MaintenanceOrders().AddMaintenanceOrdersDetailLocations(maintOrderDetailID, radSection.Checked, radIntersect.Checked, radRegion.Checked,
                    mainStID, sectionID, radDistricts.Checked, radMunics.Checked, "");

            else if (radIntersect.Checked)
                saved = new MaintenanceOrders().AddMaintenanceOrdersDetailLocations(maintOrderDetailID, radSection.Checked, radIntersect.Checked, radRegion.Checked,
                    mainStID, intersectID, radDistricts.Checked, radMunics.Checked, "");

            else if (radRegion.Checked)
                saved = new MaintenanceOrders().AddMaintenanceOrdersDetailLocations(maintOrderDetailID, radSection.Checked, radIntersect.Checked, radRegion.Checked,
                    regionID, secStID, radDistricts.Checked, radMunics.Checked, "");

            else if (radDistricts.Checked)
                saved = new MaintenanceOrders().AddMaintenanceOrdersDetailLocations(maintOrderDetailID, radSection.Checked, radIntersect.Checked, radRegion.Checked,
                   regionID, secStID, radDistricts.Checked, radMunics.Checked, ddlRegionNames.SelectedValue);

            else if (radMunics.Checked)
                saved = new MaintenanceOrders().AddMaintenanceOrdersDetailLocations(maintOrderDetailID, radSection.Checked, radIntersect.Checked, radRegion.Checked,
                   regionID, secStID, radDistricts.Checked, radMunics.Checked, ddlMunic.SelectedValue);


            if (saved)
            {
                lblAddFeedback.Text = Feedback.InsertSuccessfull();
                gvLocations.DataBind();
            }
            else
                lblAddFeedback.Text = Feedback.InsertException();

        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelLocation_Click(object sender, EventArgs e)
    {
        lblAddFeedback.Text = "";
        radIntersect.Checked = false;
        radRegion.Checked = false;
        radSection.Checked = true;
        radSection_CheckedChanged(sender, e);
    }

    protected void odsMaintainOrdersLocations_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblAddFeedback.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
        {
            lblAddFeedback.Text = Feedback.DeleteSuccessfull();
            gvLocations.DataBind();
        }
    }

    protected void gvMaintainOrdersDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblAddFeedback.Text = "";
            pnlLocations.Visible = !string.IsNullOrEmpty(gvMaintainOrdersDetails.SelectedValue.ToString());

            btnCancelLocation_Click(sender, e);
            //radSection.Checked = true;
            //radIntersect.Checked = false;
            //radRegion.Checked = false;
            //radSection_CheckedChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblAddFeedback.Text = ex.Message;
        }
    }

    protected void gvMaintainOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlDetails.Visible = !string.IsNullOrEmpty(gvMaintainOrders.SelectedValue.ToString());
        pnlLocations.Visible = false;
        gvMaintainOrdersDetails.SelectedIndex = -1;
    }

    protected void btnAddContractor_Click(object sender, EventArgs e)
    {
        AddContractorMini1.Display();
    }

    protected void OnOnContractorAdded()  //object sender, EventArgs e)
    {
        try
        {
            //((DropDownList)FormView1.FindControl("ddlContractors")).DataBind();
            //DropDownList ddl = ((DropDownList)FormView1.FindControl("ddlContractors"));
            ddlContractors.Items.Clear();
            ddlContractors.Items.Add(new ListItem("اختيار", "0"));
            ddlContractors.DataBind();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    private bool DataAreValid()
    {
        if (string.IsNullOrEmpty(CONTRACT_NOTextBox.Text))
        {
            CONTRACT_NOTextBox.Focus();
            throw new Exception("الرجاء إدخال رقم العقد");
        }
        else if (string.IsNullOrEmpty(CONTRACT_NAMETextBox.Text))
        {
            CONTRACT_NAMETextBox.Focus();
            throw new Exception("الرجاء إدخال اسم العقد");
        }
        else if (ddlContractors.SelectedValue == "0")
        {
            ddlContractors.Focus();
            throw new Exception("الرجاء اختيار المقاول");
        }
        else if (raddtpBegin.SelectedDate == null)
        {
            raddtpBegin.Focus();
            throw new Exception("الرجاء إدخال تاريخ العقد");
        }
        else if (raddtpWorkBegin.SelectedDate == null)
        {
            raddtpWorkBegin.Focus();
            throw new Exception("الرجاء إدخال تاريخ بدء التنفيذ");
        }
        else if (raddtpEnd.SelectedDate == null)
        {
            raddtpEnd.Focus();
            throw new Exception("الرجاء إدخال تاريخ الانتهاء");
        }
        else
            return false;
    }

    protected void btnAddContract_Click(object sender, EventArgs e)
    {
        try
        {
            lblFeedback.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (DataAreValid())
                return;

            bool saved = new MaintenanceOrders().Insert(CONTRACT_NOTextBox.Text, CONTRACT_NAMETextBox.Text, int.Parse(ddlContractors.SelectedValue),
               raddtpBegin.SelectedDate, raddtpWorkBegin.SelectedDate, raddtpEnd.SelectedDate, int.Parse(ddlWorkStatus.SelectedValue));
               
               //radWorking.Checked, radStopped.Checked, radCancelled.Checked);
            //bool saved = new MaintenanceOrders().Insert(CONTRACT_NOTextBox.Text, CONTRACT_NAMETextBox.Text, int.Parse(ddlContractors.SelectedValue),
            //    ((DateTime)raddtpBegin.SelectedDate).ToString("dd/MM/yyyy"), ((DateTime)raddtpWorkBegin.SelectedDate).ToString("dd/MM/yyyy"),
            //    ((DateTime)raddtpEnd.SelectedDate).ToString("dd/MM/yyyy"));

            if (saved)
            {
                btnCancelContract_Click(sender, e);
                lblFeedback.Text = Feedback.InsertSuccessfull();
                gvMaintainOrders.DataBind();
            }
            else
                lblFeedback.Text = Feedback.InsertException();
        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void btnCancelContract_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = "";

        CONTRACT_NOTextBox.Text = "";
        CONTRACT_NAMETextBox.Text = "";
        ddlContractors.SelectedValue = "0";

        raddtpBegin.SelectedDate = null;
        raddtpWorkBegin.SelectedDate = null;
        raddtpEnd.SelectedDate = null;

        ddlWorkStatus.SelectedValue = "1";
    }

    protected void radDistricts_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = false;
        ddlRegionSecondaryStreets.Visible = false;
        ddlRegionNames.Visible = true;
        ddlMunic.Visible = false;
    }

    protected void radMunics_CheckedChanged(object sender, EventArgs e)
    {
        ddlMainStreets.Visible = false;
        ddlMainStreetSection.Visible = false;
        ddlMainStreetIntersection.Visible = false;
        ddlRegions.Visible = false;
        ddlRegionSecondaryStreets.Visible = false;
        ddlRegionNames.Visible = false;
        ddlMunic.Visible = true;
    }

    protected void gvMaintainOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvMaintainOrders_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void FormView2_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvMaintainOrdersDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvMaintainOrdersDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvLocations_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblFeedback.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvMaintainOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridViewRow row = (GridViewRow)e.Row;
        //if (row.RowType == DataControlRowType.DataRow)
        //{
        //    DataRowView rowV = (DataRowView)row.DataItem;

        //    RadioButton radWorkingEd = (RadioButton)row.FindControl("radWorkingEd");
        //    radWorkingEd.Checked = bool.Parse(rowV["UP_WORKING"].ToString());

        //    RadioButton radStoppedEd = (RadioButton)row.FindControl("radStoppedEd");
        //    radStoppedEd.Checked = bool.Parse(rowV["STOPPED"].ToString());

        //    RadioButton radCancelledEd = (RadioButton)row.FindControl("radCancelledEd");
        //    radCancelledEd.Checked = bool.Parse(rowV["CANCELLED"].ToString());
        //}
    }

  

}