using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_EquipmentEight : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
            Response.Redirect("~/ASPX/Default.aspx", false);
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegions.SelectedValue != "0")
        {
            lblFeedback0.Text = string.Empty;
            lblFeedback.Text = string.Empty;

            DataTable dt = new JpmmsClasses.BL.MainStreet().GetStreetsDDF();
            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.Add(new SharedClass().CreateRadioBtnMaxSurveys(dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString()));
            RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
            RadioButtonList1.DataBind();

            gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            gvRegionIRI.DataBind();

            gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoDDF(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
            gvRegionSections.DataBind();

            DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengthDDFCLEAN(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);

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
                            gvRegionSamplesIRI.Rows[i].Cells[3].Text = "غير موجود بــ DDF";
                        }
                        else
                            gvRegionSamplesIRI.Rows[i].Cells[4].Visible = false;
                    }
                }
                dtIRI.PrimaryKey = new DataColumn[] { 
                             dtIRI.Columns["SECTION_NO"], 
                             dtIRI.Columns["LANE"] };


                for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                {
                    if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (!dtIRI.Rows.Contains(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }))
                        {
                            gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.LimeGreen;
                            gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "غير موجود بــ IRI";
                        }
                        if (gvRegionSamplesSECTION.Rows[i].Cells[2].Text != "0")
                            gvRegionSamplesSECTION.Rows[i].Cells[4].Visible = false;
                        else
                        {
                            gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.LimeGreen;
                            gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "تم اضافة نظيف";
                            gvRegionSamplesSECTION.Rows[i].Cells[2].Text = string.Empty;
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


                }
                else if (ex.Message == "These columns don't currently have unique values.")
                {
                    DataTable dtIRIErorr = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengtErorr((int.Parse(ddlRegions.SelectedValue)));
                    if (dtIRIErorr.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                        {
                            if (gvRegionSamplesSECTION.Rows[i].Cells[0].Text == dtIRIErorr.Rows[0][0].ToString() &&
                                gvRegionSamplesSECTION.Rows[i].Cells[1].Text == dtIRIErorr.Rows[0][1].ToString())
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;
                        }
                        lblFeedback.Text = "البيانات من النظام يوجد بها تكرار";
                    }
                    else
                        lblFeedback.Text = "البيانات من المعدة يوجد بها تكرار";

                }
                else
                    lblFeedback.Text = ex.Message;
                lblFeedback.Focus();
            }
            
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
            HeaderCell.Text = "البيانات من العيوب";
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
            HeaderCell.Text = "البيانات من معدة  IRI";
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
    protected void gvRegionSamplesIRI_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (Session["UserID"].ToString() == "55" || Session["UserID"].ToString() == "49" || Session["UserID"].ToString() == "48")
        {
            if (new JpmmsClasses.BL.MainStreet().InsertCleanDDF(gvRegionSamplesIRI.Rows[e.NewSelectedIndex].Cells[0].Text, gvRegionSamplesIRI.Rows[e.NewSelectedIndex].Cells[1].Text,RadioButtonList1.SelectedValue))
            {
                lblFeedback.Text = Feedback.UpdateSuccessfull();
                gvRegionSamplesSECTION.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengthDDFCLEAN(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
                gvRegionSamplesSECTION.DataBind();
                for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                {
                    if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (gvRegionSamplesSECTION.Rows[i].Cells[2].Text != "0")
                            gvRegionSamplesSECTION.Rows[i].Cells[4].Visible = false;
                        else
                        {
                            gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.LimeGreen;
                            gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "تم اضافة نظيف";
                            gvRegionSamplesSECTION.Rows[i].Cells[2].Text = string.Empty;
                        }
                    }
                }
                gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoDDF(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
                
                gvRegionSections.DataBind();

                gvRegionSamplesIRI.Rows[e.NewSelectedIndex].Cells[4].Visible = false;
                gvRegionSamplesIRI.Rows[e.NewSelectedIndex].BackColor = gvRegionSamplesIRI.Rows[0].BackColor;
                gvRegionSamplesIRI.Rows[e.NewSelectedIndex].Cells[3].Text = string.Empty;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
            }
        }
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }

    protected void gvRegionSamplesSECTION_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (Session["UserID"].ToString() == "55" || Session["UserID"].ToString() == "49" || Session["UserID"].ToString() == "48")
        {
            if (new JpmmsClasses.BL.MainStreet().DeleteCleanDDF(gvRegionSamplesSECTION.Rows[e.NewSelectedIndex].Cells[0].Text, gvRegionSamplesSECTION.Rows[e.NewSelectedIndex].Cells[1].Text,RadioButtonList1.SelectedValue))
            {
                lblFeedback.Text = Feedback.UpdateSuccessfull();
                DataTable dtSection= new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLengthDDFCLEAN(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
                dtSection.PrimaryKey = new DataColumn[] { 
                             dtSection.Columns["SECTION_NO"], 
                             dtSection.Columns["LANE"] };
                gvRegionSamplesSECTION.DataSource = dtSection;
                gvRegionSamplesSECTION.DataBind();
                for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                {
                    if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (gvRegionSamplesSECTION.Rows[i].Cells[2].Text != "0")
                            gvRegionSamplesSECTION.Rows[i].Cells[4].Visible = false;
                        else
                        {
                            gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.LimeGreen;
                            gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "تم اضافة نظيف";
                            gvRegionSamplesSECTION.Rows[i].Cells[2].Text = string.Empty;
                        }
                    }
                }
                for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                {
                    if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (!dtSection.Rows.Contains(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }))
                        {
                            gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.YellowGreen;
                            gvRegionSamplesIRI.Rows[i].Cells[3].Text = "غير موجود بــ DDF";
                            gvRegionSamplesIRI.Rows[i].Cells[4].Visible = true;
                        }
                        else
                            gvRegionSamplesIRI.Rows[i].Cells[4].Visible = false;
                    }
                }
                gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoDDF(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
                gvRegionSections.DataBind();
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
            }

        }
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}