using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


public partial class ASPX_Archive_EquipmentSectionsDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0] == "FWD")
                    RadioButtonList1.Enabled = false;

            }

        }
    }
    protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblFeedback.Text =  string.Empty;
        if (ddlRegions.SelectedValue != "-1")
        {
            DataTable dtIRI;
            if (RadioButtonList1.SelectedValue == "1")
            {
                gvRegionSamplesIRI.Visible = true;
                gvRegionSamplesNEW.Visible = false;
                if (ddlRegions.SelectedValue == "0")
                    dtIRI = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsIRI();
                else
                    dtIRI = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsIRI(ddlRegions.SelectedValue);
                gvRegionSamplesIRI.DataSource = dtIRI;
                gvRegionSamplesIRI.DataBind();
                float value = 0;
                for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                    value += float.Parse((gvRegionSamplesIRI.Rows[i].Cells[9]).Text);
                lblFeedback.Text += " طول الشارع " + value.ToString() + " م / حارة   ";
                ViewState["gvRegionSamplesIRI"] = dtIRI;
            }
            else if (RadioButtonList1.SelectedValue == "0")
            {
                gvRegionSamplesIRI.Visible = false;
                gvRegionSamplesNEW.Visible = true;
                if (ddlRegions.SelectedValue == "0")
                    dtIRI = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsNewIRI();
                else
                    dtIRI = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsNewIRI(ddlRegions.SelectedValue);
                gvRegionSamplesNEW.DataSource = dtIRI;
                gvRegionSamplesNEW.DataBind();

                float value = 0;
                for (int i = 0; i < gvRegionSamplesNEW.Rows.Count; i++)
                    value += float.Parse((gvRegionSamplesNEW.Rows[i].Cells[6]).Text);
                lblFeedback.Text += " طول الشارع " + value.ToString() + " م / حارة   ";
                ViewState["gvRegionSamplesNEW"] = dtIRI;
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {

                gvRegionSamplesIRI.Visible = true;
                gvRegionSamplesNEW.Visible = false;
                if (ddlRegions.SelectedValue == "0")
                    dtIRI = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsSYS();
                else
                    dtIRI = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsSYS(ddlRegions.SelectedValue);
                gvRegionSamplesIRI.DataSource = dtIRI;
                gvRegionSamplesIRI.DataBind();
                float value = 0;
                for (int i = 0; i < gvRegionSamplesIRI.Rows.Count; i++)
                {
                    if ((gvRegionSamplesIRI.Rows[i].Cells[9]).Text == "&nbsp;")
                    {
                        value += float.Parse("0");
                        gvRegionSamplesIRI.Rows[i].BackColor = System.Drawing.Color.BlanchedAlmond;
                    }
                    else
                        value += float.Parse((gvRegionSamplesIRI.Rows[i].Cells[9]).Text);
                }

                lblFeedback.Text += " طول الشارع " + value.ToString() + " م / حارة   ";
                ViewState["gvRegionSamplesIRI"] = dtIRI;
            }
            
           
        }
    }

    protected void gvRegionSamplesNEW_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["gvRegionSamplesNEW"];
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
            gvRegionSamplesNEW.DataSource = dtrslt;
            gvRegionSamplesNEW.DataBind();
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
        ddlRegions_SelectedIndexChanged(null, null);
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        string rptFullPath = Server.MapPath(@".\RptFiles\MachineSurveys\STREETS_SECTIONS_LANE_GIS.rpt");
        DataTable dt = new JpmmsClasses.BL.MainStreet().GetSectionsDetailsSYS(ddlRegions.SelectedValue);
        ReportDocument rpt = new ReportDocument();
        rpt.Load(rptFullPath);
        rpt.SetDataSource(dt);
        Stream memStream;
        Response.Buffer = false;
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();

        if (false)
        {
            ExcelFormatOptions excelOptions = new ExcelFormatOptions();
            excelOptions.ExcelUseConstantColumnWidth = false;
            rpt.ExportOptions.FormatOptions = excelOptions;

            memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
            Response.ContentType = "application/vnd.ms-excel";
        }
        else if (false)
        {
            memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
            Response.ContentType = "application/doc";
        }
        else
        {
            memStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            Response.ContentType = "application/pdf";
        }

        byte[] ArryStream = new byte[memStream.Length + 1];
        memStream.Read(ArryStream, 0, System.Convert.ToInt32(memStream.Length));
        Response.BinaryWrite(ArryStream);
        Response.End();

        memStream.Flush();
        memStream.Close();
        memStream.Dispose();
        rpt.Close();
        rpt.Dispose();
        GC.Collect();
      
    }
}