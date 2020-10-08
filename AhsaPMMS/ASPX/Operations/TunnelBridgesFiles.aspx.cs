using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using JpmmsClasses.BL;
using JpmmsClasses.BL.Utils;

public partial class ASPX_Operations_TunnelIntersectFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[8] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);

        if (Request.QueryString["tunnelID"] == null && Request.QueryString["bridgeID"] == null)
            Response.Redirect("~/", false);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            if (updDistressImage.HasFile)
            {
                ImageFormat imageFormat = new ImageFormat(new Guid());
                FileInfo file = new FileInfo(updDistressImage.FileName);

                string datetimePart = DateTime.Now.ToString("ddMMyyyyHHmm");
                string imageFileName = string.Format("{0}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName));
                //string newFileNameThumb = string.Format("{0}_thumb_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName));
                string fullImagePath = Server.MapPath("~/Uploads/") + imageFileName;
                updDistressImage.SaveAs(fullImagePath);


                bool saved = new TunnelBridges().AddImage(int.Parse(Request.QueryString["tunnelID"]), int.Parse(Request.QueryString["bridgeID"].ToString()), imageFileName, txtImageDetails.Text);
                if (saved)
                {
                    txtImageDetails.Text = "";
                    lblOperation.Text = Feedback.UpdateSuccessfull();
                    gvIntersectImages.DataBind();
                }
                else
                    lblOperation.Text = Feedback.UpdateException();
            }
            else
                throw new Exception("الرجاء اختيار ملف الصورة");

        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

    protected void sdsIntersectImages_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblOperation.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblOperation.Text = Feedback.DeleteSuccessfull();
    }

    protected void sdsIntersectImages_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            lblOperation.Text = e.Exception.InnerException.Message;
            e.ExceptionHandled = true;
        }
        else
            lblOperation.Text = Feedback.UpdateSuccessfull();
    }

    protected void gvIntersectImages_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblOperation.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

    protected void gvIntersectImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblOperation.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

}
