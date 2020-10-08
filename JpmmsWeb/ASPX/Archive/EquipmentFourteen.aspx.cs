using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JpmmsClasses.BL;

public partial class ASPX_Archive_EquipmentFourteen : System.Web.UI.Page
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
            lblFeedback1.Text = string.Empty;
            
            DataTable dt = new JpmmsClasses.BL.MainStreet().GetFinshedSTREETSQC();
            RadioButtonList1.Items.Clear();
            RadioButtonList1.Items.AddRange(new SharedClass().CreateRadioBtnSurveys(dt.Rows[ddlRegions.SelectedIndex - 1][3].ToString()));
            RadioButtonList1.SelectedValue = dt.Rows[ddlRegions.SelectedIndex - 1][2].ToString();
            RadioButtonList1.DataBind();

            gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
            gvRegionIRI.DataBind();

            gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoDDF(ddlRegions.SelectedItem.Text,RadioButtonList1.SelectedValue);
            gvRegionSections.DataBind();
            gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo((int.Parse(ddlRegions.SelectedValue)));
            gvRegionSections.DataBind();

            DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(int.Parse(ddlRegions.SelectedValue));

            gvRegionSamplesIRI.DataSource = dtIRI;
            gvRegionSamplesIRI.DataBind();
            gvRegionSamplesSECTION.DataSource = dtSection;
            gvRegionSamplesSECTION.DataBind();

            try
            {
                dtSection.PrimaryKey = new DataColumn[] { 
                             dtSection.Columns["SECTION_NO"], 
                             dtSection.Columns["LANE"] };

                dtIRI.PrimaryKey = new DataColumn[] { 
                             dtIRI.Columns["SECTION_NO"], 
                             dtIRI.Columns["LANE"] };


                for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                {
                    if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (dtSection.Rows.Contains(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }))
                        {
                            int SectionLenth = int.Parse(
                                dtSection.Rows.Find(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }).ItemArray[3].ToString());

                            if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 4000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "4000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 3000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "3000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 2000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "2000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 1000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "1000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 600))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "600 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 450))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "450 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 300))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "300 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 200))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "200 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 75))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "75 تجاوز الطول";
                                //gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.BlueViolet;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 50))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "50 تجاوز الطول";
                                //gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Aqua;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 25))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "25 تجاوز الطول";
                                //gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.AntiqueWhite;

                            }


                            //if ((int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text) > 25))
                            //{
                            //    gvRegionSamplesIRI.Rows[i].Cells[3].Text = " تجاوز الطول";
                            //    gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.BlueViolet;
                            //    gvRegionSamplesSECTION.Rows[i].Cells[3].Text = " تجاوز الطول";
                            //    gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.BlueViolet;
                            //}
                        }
                    }
                }
                for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                {
                    if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (dtIRI.Rows.Contains(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }))
                        {
                            int SectionLenth = int.Parse(
                                dtIRI.Rows.Find(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }).ItemArray[2].ToString());
                            if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 4000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "4000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 3000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "3000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 2000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "2000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 1000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "1000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 600))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "600 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 450))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "450 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 300))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "300 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 200))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "200 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 75))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "75 تجاوز الطول";
                                //gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.BlueViolet;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 50))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "50 تجاوز الطول";
                                //gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Aqua;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 25))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "25 تجاوز الطول";
                                //gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.AntiqueWhite;

                            }

                        }
                    }
                }

            }
            catch
            {

            } 
        }





    }
    protected void gvRegionSamplesSECTION_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "البيانات من النظام";
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
            HeaderCell.Text = "البيانات من معدة استوائيه رصف الطريق";
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
        if (ddlRegions.SelectedValue != "0")
        {
            lblFeedback0.Text = string.Empty;
            lblFeedback.Text = string.Empty;
            lblFeedback1.Text = string.Empty;

            gvRegionIRI.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            gvRegionIRI.DataBind();

            gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfoDDF(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            gvRegionSections.DataBind();
            gvRegionSections.DataSource = new JpmmsClasses.BL.MainStreet().GetStreetsInfo((int.Parse(ddlRegions.SelectedValue)));
            gvRegionSections.DataBind();

            DataTable dtIRI = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(ddlRegions.SelectedItem.Text, RadioButtonList1.SelectedValue);
            DataTable dtSection = new JpmmsClasses.BL.MainStreet().GetStreetsSectionsLength(int.Parse(ddlRegions.SelectedValue));

            gvRegionSamplesIRI.DataSource = dtIRI;
            gvRegionSamplesIRI.DataBind();
            gvRegionSamplesSECTION.DataSource = dtSection;
            gvRegionSamplesSECTION.DataBind();

            try
            {
                dtSection.PrimaryKey = new DataColumn[] { 
                             dtSection.Columns["SECTION_NO"], 
                             dtSection.Columns["LANE"] };

                dtIRI.PrimaryKey = new DataColumn[] { 
                             dtIRI.Columns["SECTION_NO"], 
                             dtIRI.Columns["LANE"] };


                for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                {
                    if (gvRegionSamplesIRI.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (dtSection.Rows.Contains(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }))
                        {
                            int SectionLenth = int.Parse(
                                dtSection.Rows.Find(new object[] { gvRegionSamplesIRI.Rows[i].Cells[0].Text, gvRegionSamplesIRI.Rows[i].Cells[1].Text }).ItemArray[3].ToString());

                            if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 4000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "4000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 3000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "3000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 2000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "2000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 1000))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "1000 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 600))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "600 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 450))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "450 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 300))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "300 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 200))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "200 تجاوز الطول";
                                gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 75))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "75 تجاوز الطول";
                                //gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.BlueViolet;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 50))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "50 تجاوز الطول";
                                //gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.Aqua;

                            }
                            else if ((System.Math.Abs(int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - SectionLenth) > 25))
                            {
                                gvRegionSamplesIRI.Rows[i].Cells[3].Text = "25 تجاوز الطول";
                                //gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.AntiqueWhite;

                            }


                            //if ((int.Parse(gvRegionSamplesIRI.Rows[i].Cells[2].Text) - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text) > 25))
                            //{
                            //    gvRegionSamplesIRI.Rows[i].Cells[3].Text = " تجاوز الطول";
                            //    gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.BlueViolet;
                            //    gvRegionSamplesSECTION.Rows[i].Cells[3].Text = " تجاوز الطول";
                            //    gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.BlueViolet;
                            //}
                        }
                    }
                }
                for (int i = 0; i < gvRegionSamplesSECTION.Rows.Count; i++)
                {
                    if (gvRegionSamplesSECTION.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        if (dtIRI.Rows.Contains(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }))
                        {
                            int SectionLenth = int.Parse(
                                dtIRI.Rows.Find(new object[] { gvRegionSamplesSECTION.Rows[i].Cells[0].Text, gvRegionSamplesSECTION.Rows[i].Cells[1].Text }).ItemArray[2].ToString());
                            if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 4000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "4000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 3000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "3000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 2000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "2000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 1000))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "1000 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 600))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "600 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 450))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "450 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 300))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "300 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 200))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "200 تجاوز الطول";
                                gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Red;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 75))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "75 تجاوز الطول";
                                //gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.BlueViolet;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 50))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "50 تجاوز الطول";
                                //gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.Aqua;

                            }
                            else if ((System.Math.Abs(SectionLenth - int.Parse(gvRegionSamplesSECTION.Rows[i].Cells[2].Text)) > 25))
                            {
                                gvRegionSamplesSECTION.Rows[i].Cells[3].Text = "25 تجاوز الطول";
                                //gvRegionSamplesSECTION.Rows[i].BackColor = System.Drawing.Color.AntiqueWhite;

                            }

                        }
                    }
                }

            }
            catch
            {

            }
        }

    }
}