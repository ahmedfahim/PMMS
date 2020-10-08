using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ASPX_Archive_StatisticsWorkOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void BtnShow_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(CheckBoxList1.SelectedValue) || string.IsNullOrEmpty(RadioBtnStreetType.SelectedValue) || string.IsNullOrEmpty(RadioBtnStreetStatus.SelectedValue))
        {
            lblFeedback.Text = "يجب اختيار النوع و الحاله والتقرير ";
        }
        else
        {
            int SelectedValue;
            if (RadioBtnStreetType.Items[0].Selected)
            {
                SelectedValue = int.Parse(RadioBtnStreetStatus.SelectedValue) + 1;
            }
            else
            {
                SelectedValue = int.Parse(RadioBtnStreetStatus.SelectedValue);

            }
            if (CheckBoxList1.Items[0].Selected && CheckBoxList1.Items[1].Selected)
            {
                gvStatWorkOrder.DataSource = new JpmmsClasses.BL.MainStreet().GetStatisticsWorkOrders((JpmmsClasses.BL.UDI.UdiShared.UdiFilter)SelectedValue);
                gvStatWorkOrder.DataBind();
                gvStatWorkOrderDetails.DataSource = new JpmmsClasses.BL.MainStreet().GetStatisticsWorkOrdersDetails((JpmmsClasses.BL.UDI.UdiShared.UdiFilter)SelectedValue);
                gvStatWorkOrderDetails.DataBind();
                GridViewDuplicates();
            }
            else if (CheckBoxList1.SelectedValue == "1")
            {
                gvStatWorkOrderDetails.DataBind();
                gvStatWorkOrder.DataSource = new JpmmsClasses.BL.MainStreet().GetStatisticsWorkOrders((JpmmsClasses.BL.UDI.UdiShared.UdiFilter)SelectedValue);
                gvStatWorkOrder.DataBind();
            }
            else if (CheckBoxList1.SelectedValue == "2")
            {
                gvStatWorkOrder.DataBind();
                gvStatWorkOrderDetails.DataSource = new JpmmsClasses.BL.MainStreet().GetStatisticsWorkOrdersDetails((JpmmsClasses.BL.UDI.UdiShared.UdiFilter)SelectedValue);
                gvStatWorkOrderDetails.DataBind();
                GridViewDuplicates();
            }
            lblFeedback.Text = string.Empty;
        }
    }

    protected void gvStatWorkOrder_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < gvStatWorkOrder.Rows.Count; i++)
        {
            if (gvStatWorkOrder.Rows[i].RowType == DataControlRowType.DataRow)
            {
                
                if (gvStatWorkOrder.Rows[i].Cells[2].Text == "&nbsp;")
                    gvStatWorkOrder.Rows[i].BackColor = System.Drawing.Color.BurlyWood;
                else if (gvStatWorkOrder.Rows[i].Cells[2].Text == "Poor")
                    gvStatWorkOrder.Rows[i].Cells[2].BackColor = System.Drawing.Color.Red;
                else if (gvStatWorkOrder.Rows[i].Cells[2].Text == "Fair")
                    gvStatWorkOrder.Rows[i].Cells[2].BackColor = System.Drawing.Color.Yellow;
                else if (gvStatWorkOrder.Rows[i].Cells[2].Text == "Good")
                {
                    gvStatWorkOrder.Rows[i].Cells[2].BackColor = System.Drawing.Color.Blue;
                    gvStatWorkOrder.Rows[i].Cells[2].ForeColor = System.Drawing.Color.White;
                }
                else if (gvStatWorkOrder.Rows[i].Cells[2].Text == "Excellent")
                {
                    gvStatWorkOrder.Rows[i].Cells[2].BackColor = System.Drawing.Color.Green;
                    gvStatWorkOrder.Rows[i].Cells[2].ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }
    protected void gvStatWorkOrderDetails_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < gvStatWorkOrderDetails.Rows.Count; i++)
        {
            if (gvStatWorkOrderDetails.Rows[i].RowType == DataControlRowType.DataRow)
            {
                
                if (gvStatWorkOrderDetails.Rows[i].Cells[3].Text == "Poor")
                    gvStatWorkOrderDetails.Rows[i].Cells[3].BackColor = System.Drawing.Color.Red;
                else if (gvStatWorkOrderDetails.Rows[i].Cells[3].Text == "Fair")
                    gvStatWorkOrderDetails.Rows[i].Cells[3].BackColor = System.Drawing.Color.Yellow;
                else if (gvStatWorkOrderDetails.Rows[i].Cells[3].Text == "Good")
                {
                    gvStatWorkOrderDetails.Rows[i].Cells[3].BackColor = System.Drawing.Color.Blue;
                    gvStatWorkOrderDetails.Rows[i].Cells[3].ForeColor = System.Drawing.Color.White;
                }
                else if (gvStatWorkOrderDetails.Rows[i].Cells[3].Text == "Excellent")
                {
                    gvStatWorkOrderDetails.Rows[i].Cells[3].BackColor = System.Drawing.Color.Green;
                    gvStatWorkOrderDetails.Rows[i].Cells[3].ForeColor = System.Drawing.Color.White;
                }
            }
        }
    }

    protected int findIDInGrid(ArrayList array, string s)
    {
        int digit = -1;
        foreach (object obj in array)
        {
            if (obj.ToString() == s)
            {
                digit = array.IndexOf(obj);
                break;
            }
        }

        return digit;
    }
    protected void GridViewDuplicates()
    {
        try
        {
            ArrayList array = new ArrayList();
            for (int i = 0; i < gvStatWorkOrderDetails.Rows.Count; i++)
            {
                if (findIDInGrid(array, gvStatWorkOrderDetails.Rows[i].Cells[2].Text) != -1)
                    gvStatWorkOrderDetails.Rows[findIDInGrid(array, gvStatWorkOrderDetails.Rows[i].Cells[2].Text)].BackColor = System.Drawing.Color.Aqua;
                array.Add(gvStatWorkOrderDetails.Rows[i].Cells[2].Text);
            }
        }
        catch
        {

        }
    }
}