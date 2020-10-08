using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.IO;

public partial class ASPX_Operations_FeedbackFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string image = new MaintenanceFeedback().GetFeedbackImage(int.Parse(Request.QueryString["id"]));
                imgPhoto.ImageUrl = "~/Uploads/" + image;
            }
            else
                Response.Redirect("Feedbacks.aspx", false);

        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string imageFileName = "";
            lblOperation.Text = "";
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (updDistressImage.HasFile)
            {
                string datetimePart = DateTime.Now.ToString("ddMMyyyyHHmm");
                imageFileName = string.Format("{0}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName));
                string strPath = MapPath("~/Uploads/") + imageFileName;
                updDistressImage.SaveAs(strPath);

                bool saved = new MaintenanceFeedback().EditFeedbackJobOrderImage(imageFileName, int.Parse(Request.QueryString["id"]));
                if (saved)
                {
                    lblOperation.Text = Feedback.UpdateSuccessfull();
                    imgPhoto.ImageUrl = "~/Uploads/" + imageFileName;
                }
                else
                    lblOperation.Text = Feedback.UpdateException();
            }

        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            lblOperation.Text = "";
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool deleted = new MaintenanceFeedback().DeleteFeedbackJobOrderImage(int.Parse(Request.QueryString["id"]));
            if (deleted)
            {
                imgPhoto.ImageUrl = "~/Uploads/" + new MaintenanceFeedback().GetFeedbackImage(int.Parse(Request.QueryString["id"]));
                lblOperation.Text = Feedback.DeleteSuccessfull();
            }
            else
                lblOperation.Text = Feedback.DeleteException();

        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

}