using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ASPX_Sections_R4Tests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[0] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);

            if (string.IsNullOrEmpty(Request.QueryString["R4ID"]))
                Response.Redirect("R4StreetsInfo.aspx", false);
        }
    }

    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        GridView1.DataBind();
    }

    protected void Label1_PreRender(object sender, EventArgs e)
    {
        Label lbl = (Label)sender;
        if (lbl.Text == "1")
            lbl.Text = "ناجح";
        else
            lbl.Text = "راسب";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!bool.Parse(Session["canEdit"].ToString()))
                throw new Exception(Feedback.NoPermissions());

            FileUpload updDistressImage = (FileUpload)this.FormView1.FindControl("updDistressImage");
            Label lblOperation = (Label)this.FormView1.FindControl("lblOperation");
            HiddenField HFfileName = (HiddenField)this.FormView1.FindControl("HFfileName");
            if (updDistressImage.HasFile)
            {
                string datetimePart = DateTime.Now.ToString("ddMMyyyyHHmm");
                string imageFileName = string.Format("{0}_{1}", datetimePart, Path.GetFileName(updDistressImage.FileName));
                string fullImagePath = Server.MapPath("~/Uploads/") + imageFileName;
                updDistressImage.SaveAs(fullImagePath);
                lblOperation.Text = "تم تحميل الملف بنجاح";
                HFfileName.Value = imageFileName;
            }
            else
                throw new Exception("الرجاء اختيار ملف الصورة");

        }
        catch (Exception ex)
        {
            lblFeedback.Text = ex.Message;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

}