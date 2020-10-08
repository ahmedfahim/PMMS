using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using JpmmsClasses.BL;
using JpmmsClasses.BL.DistressEntry;

public partial class ASPX_Regions_ViewDistressImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (!string.IsNullOrEmpty(Request.QueryString["DistID"]))
            {
                string image = new DistressEntry().GetDistressImage(int.Parse(Request.QueryString["DistID"]));
                imgPhoto.ImageUrl = "~/Uploads/" + image;
            }
            else
                Response.Redirect("Regiondistresses.aspx", false);

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

                bool saved = new DistressEntry().EditDistressImage(imageFileName, int.Parse(Request.QueryString["DistID"]));
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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        string url = string.Format("Regiondistresses.aspx?DistID={0}", Request.QueryString["DistID"]);
        Response.Redirect(url, false);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            lblOperation.Text = "";
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool deleted = new ImagesGallery().DeleteDistressImage(int.Parse(Request.QueryString["DistID"]));
            if (deleted)
            {
                imgPhoto.ImageUrl = "~/Uploads/" + new DistressEntry().GetDistressImage(int.Parse(Request.QueryString["DistID"]));
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