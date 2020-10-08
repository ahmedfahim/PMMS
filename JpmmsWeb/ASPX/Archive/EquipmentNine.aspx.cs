using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ASPX_Archive_EquipmentNine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      

        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
        else
            if (Session["UserID"].ToString() == "49" || Session["UserID"].ToString() == "48" 
                || Session["UserID"].ToString() == "46" || Session["UserID"].ToString() == "55"
                || Session["UserID"].ToString() == "54" || Session["UserID"].ToString() == "56")
            {
                if (!IsPostBack)
                {
                    gvERorrIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsERorrIRI();
                    gvERorrIRI.DataBind();

                    if (gvERorrIRI.Rows.Count > 0)
                        lblFeedback.Text = string.Empty;
                    else
                        lblFeedback.Text = Feedback.NoData();
                }

            }
            else
            {
                lblFeedback.Text = Feedback.NoPermissions();
                BtnFinshed.Visible = false;
            }

    }

   
    protected void BtnFinshed_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "55" )
        {
            if (gvERorrIRI.Rows.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < gvERorrIRI.Rows.Count; i++)
                {
                    if (new JpmmsClasses.BL.MainStreet().UpdateSectionsDrawing(gvERorrIRI.Rows[i].Cells[0].Text, gvERorrIRI.Rows[i].Cells[1].Text, gvERorrIRI.Rows[i].Cells[2].Text))
                        count++;
                    
                }
                lblFeedback.Text = " عدد " + count + " مقطع تم الربط مع المعدة ";
                if (count > 0)
                {
                    gvERorrIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsERorrIRI();
                    gvERorrIRI.DataBind();
                }
            }
            else
            {
                lblFeedback.Text = Feedback.NoData();
                lblFeedback.Visible = true;
            }
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
            lblFeedback.Visible = true;
        } 
    }
}