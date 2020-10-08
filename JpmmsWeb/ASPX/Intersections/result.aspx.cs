using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses;
using System.Drawing;
using System.Collections;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Intersections_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Guid id = new Guid(Request.QueryString["id"]);

            // Check the thread result collection
            if (ThreadResults.Contains(id))
            {
                // The worker thread has finished

                // Get the result from the thread result collection
                //int authorizationId = (int)ThreadResults.Get(id);
                DataTable dt = (DataTable)ThreadResults.Get(id);

                // Remove the result from the collection
                ThreadResults.Remove(id);

                lblMessage.Text = "انتهى حساب حالة الرصف بنجاح";
                lblMessage.ForeColor = Color.Green;

                gvIntersectUDI.DataSource = dt;
                gvIntersectUDI.DataBind();

                //UdiShared.StartShapeFileAutoCreationProgram();
            }
            else
            {
                lblMessage.Text = "يجري الآن حساب حالة الرصف، الرجاء الانتظار";
                lblMessage.ForeColor = Color.Black;

                Response.AddHeader("Refresh", "2");
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvIntersectUDI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;

        var c = e.Row.FindControl("lblRateUDI") as Label;
        if (c != null)
        {
            if (c.Text == "Excellent")
                ((Label)e.Row.FindControl("lblRateUDI")).ForeColor = Color.Green;
            else if (c.Text == "Good")
                ((Label)e.Row.FindControl("lblRateUDI")).ForeColor = Color.Cyan;
            else if (c.Text == "Fair")
                ((Label)e.Row.FindControl("lblRateUDI")).ForeColor = Color.Yellow;
            else if (c.Text == "Poor")
                ((Label)e.Row.FindControl("lblRateUDI")).ForeColor = Color.Red;
        }
    }

}
