using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_EquipmentEleven : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count == 1 && Request.QueryString[0].ToString() == "AREA")
            {
                if (new JpmmsClasses.BL.MainStreet().CheckGetLaneSamplesArea())
                {
                    GridView1.DataSource = new JpmmsClasses.BL.MainStreet().GetLaneSamplesArea(false);
                    GridView1.DataBind();
                }
            }
        }
    }
    protected void BtnFinshed_Click(object sender, EventArgs e)
    {
        lblFeedback.Text = string.Empty;
        if (Session["UserID"].ToString()== "48")
        {
            if (ddlRegions.SelectedValue != "-1" && ddlRegions.SelectedValue != string.Empty)
            {
                if (ddlRegions.SelectedValue == "0")
                {
                    int Total = ddlRegions.Items.Count - 2;
                    bool Value = false;

                    if (new JpmmsClasses.BL.MainStreet().Remove_InsertUpdateIRISections())
                    {
                        System.Data.DataTable dtErorrUpdate = new JpmmsClasses.BL.MainStreet().CheckUpdateLengthSAMPLES();
                        if (dtErorrUpdate != null && dtErorrUpdate.Rows.Count == 0)
                        {
                            lblFeedbackErorr.Text = string.Empty;
                            if (new JpmmsClasses.BL.MainStreet().UpdateLengthSAMPLES())
                                Value = true;
                            else
                                Value = false;
                        }
                        else
                        {
                            lblFeedbackErorr.Text = "بيانات مدخلة خطأ ";
                            gvRegionSamplesErorr.DataSource = dtErorrUpdate;
                            gvRegionSamplesErorr.DataBind();

                        }
                     
                    }
                    else
                        Value = false;

                    //}
                    //else

                    //    Value = false;
                    if (Value)
                    {
                        ddlRegions.SelectedValue = "-1";
                        lblFeedback.Text = "تم تحديث جميع الأطوال";
                    }
                    else
                    {
                        ddlRegions.SelectedValue = "-1";
                        lblFeedback.Text = Feedback.UpdateUNSuccessfull();
                    }
                }
                else
                {
                    if (new JpmmsClasses.BL.MainStreet().RemoveIRILength())
                    {
                        if (new JpmmsClasses.BL.MainStreet().InsertLengthDDF(ddlRegions.SelectedValue))
                        {
                            lblFeedback.Text = new JpmmsClasses.BL.MainStreet().UpdateLengthSAMPLESOld() == true ? "تم تحديث الأطوال" : Feedback.UpdateUNSuccessfull();
                            ddlRegions.SelectedValue = "-1";
                        }
                        else
                        {
                            ddlRegions.SelectedValue = "-1";
                            lblFeedback.Text = Feedback.UpdateUNSuccessfull();
                        }

                    }
                    else
                    {
                        ddlRegions.SelectedValue = "-1";
                        lblFeedback.Text = Feedback.UpdateUNSuccessfull();
                    }

                }
            }
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}