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

public partial class ASPX_Regions_SecondStImages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (string.IsNullOrEmpty(Request.QueryString["SecondStID"]))
                Response.Redirect("RegionInfo.aspx", false);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (updDistressImage.HasFile)
            {
                int secondStID = int.Parse(Request.QueryString["SecondStID"]);

                ImageFormat imageFormat = new ImageFormat(new Guid());
                FileInfo file = new FileInfo(updDistressImage.FileName);
                if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".jpeg")
                    imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                else if (file.Extension.ToLower() == ".gif")
                    imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                else if (file.Extension.ToLower() == ".png")
                    imageFormat = System.Drawing.Imaging.ImageFormat.Png;

                string secStTitle = "";
                DataTable dt = new SecondaryStreets().GetSecondaryStreetInfo(secondStID);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    secStTitle = string.Format("{0} - {1} - {2} ", dr["REGION_NO"].ToString(), dr["SUBDISTRICT"].ToString(), dr["SECOND_ST_NO"].ToString());

                    string datetimePart = DateTime.Now.ToString("ddMMyyyyHHmm");
                    string imageFileName = string.Format("{0}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName));
                    string newFileNameThumb = string.Format("{0}_{2}{3}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName), dr["REGION_NO"].ToString(), dr["SECOND_ST_NO"].ToString());
                    string fullImagePath = Server.MapPath("~/Uploads/") + imageFileName;
                    updDistressImage.SaveAs(fullImagePath);



                    using (FileStream fi = File.OpenRead(Server.MapPath("~/Uploads/") + imageFileName))
                    {
                        using (FileStream resizedImage = File.Create(Server.MapPath("~/Uploads/") + newFileNameThumb))
                        {
                            string strDatetime = File.GetCreationTime(Server.MapPath("~/Uploads/") + newFileNameThumb).ToString("dd/MM/yyyy HH:mm");
                            ImagesClass.ResizeImagePutWatermark(fi, resizedImage, imageFormat, 1600, 1200, true, secStTitle + ' ' + strDatetime);

                            resizedImage.Dispose();
                        }

                        //ImagesClass.ResizeImage(fi, resizedImage, imageFormat, 1600, 1200);
                        fi.Close();
                    }

                    File.Delete(Server.MapPath("~/Uploads/") + imageFileName);
                    bool saved = new ImagesGallery().AddImage(secondStID, newFileNameThumb, txtImageDetails.Text, RoadType.RegionSecondarySt);
                    if (saved)
                    {
                        txtImageDetails.Text = "";
                        lblOperation.Text = Feedback.UpdateSuccessfull();
                        //gvImages.DataBind();
                        lvwImages.DataBind();
                    }
                    else
                        lblOperation.Text = Feedback.UpdateException();
                }
                else
                    throw new Exception("الرجاء اختيار ملف الصورة");
            }
            else
                throw new Exception("الرجاء اختيار المنطقة الفرعية");

        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

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

    protected void lbtnDelete_click(object sender, CommandEventArgs e)
    {
        try
        {
            lblOperation.Text = "";

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            bool deleted = new ImagesGallery().DeleteImage(int.Parse(e.CommandArgument.ToString()));
            if (deleted)
            {
                lblOperation.Text = Feedback.DeleteSuccessfull();
                lvwImages.DataBind();
            }
            else
                lblOperation.Text = Feedback.DeleteException();
        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

    protected void lvwImages_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        if (!bool.Parse(Session["canEdit"].ToString()))
        {
            lblOperation.Text = Feedback.NoPermissions();
            e.Cancel = true;
        }
    }

}
