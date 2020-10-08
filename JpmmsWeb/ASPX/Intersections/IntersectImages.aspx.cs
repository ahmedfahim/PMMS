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

public partial class ASPX_Intersections_IntersectImages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (string.IsNullOrEmpty(Request.QueryString["InterID"]))
                Response.Redirect("IntersectionInfo.aspx", false);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string lang = ;

            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());


            if (updDistressImage.HasFile)
            {
                int interID = int.Parse(Request.QueryString["InterID"]);

                ImageFormat imageFormat = new ImageFormat(new Guid());
                FileInfo file = new FileInfo(updDistressImage.FileName);
                if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".jpeg")
                    imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                else if (file.Extension.ToLower() == ".gif")
                    imageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                else if (file.Extension.ToLower() == ".png")
                    imageFormat = System.Drawing.Imaging.ImageFormat.Png;

                string intersectTitle = "";
                DataTable dt = new Intersection().GetIntersection(interID);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    intersectTitle = string.Format("{0} - {1} ", dr["INTER_NO"].ToString(), dr["MAIN_NAME"].ToString());

                    string datetimePart = DateTime.Now.ToString("ddMMyyyyHHmm");
                    string imageFileName = string.Format("{0}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName));
                    string newFileNameThumb = string.Format("{0}_{2}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName), dr["INTER_NO"].ToString());
                    string fullImagePath = Server.MapPath("~/Uploads/") + imageFileName;
                    updDistressImage.SaveAs(fullImagePath);



                    using (FileStream fi = File.OpenRead(Server.MapPath("~/Uploads/") + imageFileName))
                    {
                        using (FileStream resizedImage = File.Create(Server.MapPath("~/Uploads/") + newFileNameThumb))
                        {
                            string strDatetime = File.GetCreationTime(Server.MapPath("~/Uploads/") + newFileNameThumb).ToString("dd/MM/yyyy HH:mm");
                            ImagesClass.ResizeImagePutWatermark(fi, resizedImage, imageFormat, 1600, 1200, true, intersectTitle + ' ' + strDatetime);

                            resizedImage.Dispose();
                        }

                        //ResizeImage(fi, resizedImage, imageFormat, 1600, 1200);
                        fi.Close();
                    }

                    File.Delete(Server.MapPath("~/Uploads/") + imageFileName);
                    bool saved = new ImagesGallery().AddImage(interID, newFileNameThumb, txtImageDetails.Text, RoadType.Intersect);
                    if (saved)
                    {
                        txtImageDetails.Text = "";
                        lblOperation.Text = Feedback.UpdateSuccessfull();
                        //gvIntersectImages.DataBind();
                        lvwImages.DataBind();
                    }
                    else
                        lblOperation.Text = Feedback.UpdateException();
                }
                else
                    throw new Exception("الرجاء اختيار ملف الصورة");
            }
            else
                throw new Exception("الرجاء اختيار التقاطع");

        }
        catch (Exception ex)
        {
            lblOperation.Text = ex.Message;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        string url = string.Format("IntersectionDistresses.aspx?DistID={0}", Request.QueryString["DistID"]);
        Response.Redirect(url, false);
    }

    protected void sdsIntersectImages_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //string lang = ;
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
            //string lang = ;

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
