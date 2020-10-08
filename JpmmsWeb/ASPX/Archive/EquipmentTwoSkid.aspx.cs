using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_EquipmentTwoSkid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
        }
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback0.Text = string.Empty;
        lblFeedback.Text = string.Empty;
        lblFeedback1.Text = string.Empty;
        System.Data.DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsSKID();
        RadioButtonList1.Items.Clear();
        RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString()));
        RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
        RadioButtonList1.DataBind();
        if (dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString() == "1")
            RadioButtonList1.Enabled = false;
        else
            RadioButtonList1.Enabled = true;
        gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoSKID(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionIRI.DataBind();

        gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionSections.DataBind();

        DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengthSKID(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);

        gvRegionSamplesIRI.DataSource = dtIRI;
        gvRegionSamplesIRI.DataBind();
        gvRegionSamplesSECTION.DataSource = dtSection;
        gvRegionSamplesSECTION.DataBind();

        try
        {
            dtSection.PrimaryKey = new DataColumn[] { 
                             dtSection.Columns["SECTION_NO"], 
                             dtSection.Columns["LANE"] };


            for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
            {
                if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (!dtSection.Rows.Contains(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }))
                    {
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                        gvRegionSamplesIRI.Rows[i].Cells[3].Text = "غير موجود IRI";
                    }
                }
            }
            dtIRI.PrimaryKey = new DataColumn[] { 
                             dtIRI.Columns["SECTION_NO"], 
                             dtIRI.Columns["LANE"]};


            for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
            {
                if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (!dtIRI.Rows.Contains(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }))
                    {
                        gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.LimeGreen;
                        gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "غير موجود SKID";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblFeedback0.Text = string.Empty;
            if (ex.Message == "Column 'SECTION_NO' has null values in it.")
            {
                
                lblFeedback0.Text = "البيانات من النظام يوجد بها مقطع ليس له رقم";
                    
                for (int i = 0; i < dtSection.Rows.Count; i++)
                {
                    if (dtSection.Rows[i][1].ToString() == string.Empty)
                        lblFeedback.Text += "LANE_ID : " + dtSection.Rows[i][0].ToString();
                }
                for (int i = 0; i < dtIRI.Rows.Count; i++)
                {
                    if (dtIRI.Rows[i][0].ToString() == string.Empty)
                    {
                        lblFeedback.Text += " LANE  : " + dtIRI.Rows[i][1].ToString();
                        lblFeedback0.Text = "البيانات من المعدة يوجد بها مقطع ليس له رقم";
                    }
                        
                }

            }
            else if (ex.Message == "These columns don't currently have unique values.")
            {
                DataTable dtIRIErorr = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengtErorr((int.Parse(ddlRegions.SelectedValue)));
                if (dtIRIErorr.Rows.Count > 0)
                    for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                    {
                        if (gvRegionSamplesSECTION.Rows[i].Cells[0].Text == dtIRIErorr.Rows[0][0].ToString() &&
                            gvRegionSamplesSECTION.Rows[i].Cells[1].Text == dtIRIErorr.Rows[0][1].ToString())
                            gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;
                    }
                DataTable dtdublicate = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanesSKID(ddlRegions.SelectedItem.Text);
                if (dtdublicate.Rows.Count > 0)
                    for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtdublicate.Rows.Count; j++)
                        {
                            if (gvRegionSamplesIRI.Rows[i].Cells[0].Text == dtdublicate.Rows[j][2].ToString() &&
                                 gvRegionSamplesIRI.Rows[i].Cells[1].Text == dtdublicate.Rows[j][3].ToString())
                            {
                                if (gvRegionSamplesIRI.Rows[i].Cells[3].Text == string.Empty)
                                {
                                    gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;
                                    gvRegionSamplesIRI.Rows[i].Cells[3].Text = "  مكرر  ";
                                }
                                else
                                {
                                    gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Salmon;
                                    gvRegionSamplesIRI.Rows[i].Cells[3].Text += "  ومكرر  ";
                                }
                                
                                
                            }
                        }
                    }
                lblFeedback.Text = "البيانات من المعدة يوجد بها تكرار";

            }
            else
                lblFeedback.Text = ex.Message;
            lblFeedback.Focus();
        }



        //ViewState["gvRegionSamplesSECTION"] = gvRegionSamplesSECTION.DataSource;
        //ViewState["gvRegionSamplesIRI"] = gvRegionSamplesIRI.DataSource;
        //ViewState["sortdrIRI"] = "Asc";
        //ViewState["sortdr"] = "Asc";


    }
    protected void gvRegionSamplesSECTION_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من IRI";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamplesSECTION.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamplesSECTION.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void gvRegionSamplesIRI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من SKID";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamplesIRI.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamplesIRI.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void gvRegionSamplesSECTION_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamplesSECTION"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            gvRegionSamplesSECTION.DataSource = dtrslt;
            gvRegionSamplesSECTION.DataBind();
        }
    }
    protected void gvRegionSamplesIRI_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamplesIRI"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdrIRI"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdrIRI"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdrIRI"] = "Asc";
            }

            gvRegionSamplesIRI.DataSource = dtrslt;
            gvRegionSamplesIRI.DataBind();

        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoSKID(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionIRI.DataBind();

        gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        gvRegionSections.DataBind();

        DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengthSKID(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
        DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);

        gvRegionSamplesIRI.DataSource = dtIRI;
        gvRegionSamplesIRI.DataBind();
        gvRegionSamplesSECTION.DataSource = dtSection;
        gvRegionSamplesSECTION.DataBind();

        try
        {
            dtSection.PrimaryKey = new DataColumn[] { 
                             dtSection.Columns["SECTION_NO"], 
                             dtSection.Columns["LANE"] };


            for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
            {
                if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (!dtSection.Rows.Contains(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }))
                    {
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                        gvRegionSamplesIRI.Rows[i].Cells[3].Text = "غير موجود IRI";
                    }
                }
            }
            dtIRI.PrimaryKey = new DataColumn[] { 
                             dtIRI.Columns["SECTION_NO"], 
                             dtIRI.Columns["LANE"]};


            for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
            {
                if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (!dtIRI.Rows.Contains(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }))
                    {
                        gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.LimeGreen;
                        gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "غير موجود SKID";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblFeedback0.Text = string.Empty;
            if (ex.Message == "Column 'SECTION_NO' has null values in it.")
            {

                lblFeedback0.Text = "البيانات من النظام يوجد بها مقطع ليس له رقم";

                for (int i = 0; i < dtSection.Rows.Count; i++)
                {
                    if (dtSection.Rows[i][1].ToString() == string.Empty)
                        lblFeedback.Text += "LANE_ID : " + dtSection.Rows[i][0].ToString();
                }
                for (int i = 0; i < dtIRI.Rows.Count; i++)
                {
                    if (dtIRI.Rows[i][0].ToString() == string.Empty)
                    {
                        lblFeedback.Text += " LANE  : " + dtIRI.Rows[i][1].ToString();
                        lblFeedback0.Text = "البيانات من المعدة يوجد بها مقطع ليس له رقم";
                    }

                }

            }
            else if (ex.Message == "These columns don't currently have unique values.")
            {
                DataTable dtIRIErorr = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengtErorr((int.Parse(ddlRegions.SelectedValue)));
                if (dtIRIErorr.Rows.Count > 0)
                    for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                    {
                        if (gvRegionSamplesSECTION.Rows[i].Cells[0].Text == dtIRIErorr.Rows[0][0].ToString() &&
                            gvRegionSamplesSECTION.Rows[i].Cells[1].Text == dtIRIErorr.Rows[0][1].ToString())
                            gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;
                    }
                DataTable dtdublicate = new JpmmsClasses.BL.MainStreet().GetStreetsDublicateLanesSKID(ddlRegions.SelectedItem.Text);
                if (dtdublicate.Rows.Count > 0)
                    for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtdublicate.Rows.Count; j++)
                        {
                            if (gvRegionSamplesIRI.Rows[i].Cells[0].Text == dtdublicate.Rows[j][2].ToString() &&
                                 gvRegionSamplesIRI.Rows[i].Cells[1].Text == dtdublicate.Rows[j][3].ToString())
                            {
                                if (gvRegionSamplesIRI.Rows[i].Cells[3].Text == string.Empty)
                                {
                                    gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;
                                    gvRegionSamplesIRI.Rows[i].Cells[3].Text = "  مكرر  ";
                                }
                                else
                                {
                                    gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Salmon;
                                    gvRegionSamplesIRI.Rows[i].Cells[3].Text += "  ومكرر  ";
                                }


                            }
                        }
                    }
                lblFeedback.Text = "البيانات من المعدة يوجد بها تكرار";

            }
            else
                lblFeedback.Text = ex.Message;
            lblFeedback.Focus();
        }
    }
}