using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Archive_FirstEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Permissions"] == null || Session["Permissions"].ToString()[1] != '1')
                Response.Redirect("~/ASPX/Default.aspx", false);
            else
            {
                int ErorrData = new JpmmsClasses.BL.MainStreet().ValidateUpdateIRI().Rows.Count;
                if (ErorrData > 0)
                {
                    spanErorrData.Visible = true;
                    spanErorrData.InnerText = ErorrData.ToString();
                }
                else
                {
                    spanErorrData.Visible = false;
                    spanErorrData.InnerText = string.Empty;
                }
            }
        }
    }
    protected void BtnIRI_Click(object sender, EventArgs e)
    {

        if (Session["UserID"].ToString() == "48")
        {
            bool Value=false;
            if (new JpmmsClasses.BL.MainStreet().Remove_UpdateIRILength())
            {
                if (new JpmmsClasses.BL.MainStreet().InsertLengthIRI_FISNSHED())
                    Value = true;
                else

                    Value = false;
            }
            else
                Value = false;

            if (Value)
                lblFeedback.Text = " تم " + BtnIRI.Text;
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void gvRegionSamples_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (Session["UserID"].ToString() == "48")
        {
            lblFeedback.Text = string.Empty;
            CheckBox CHK = gvRegionSamples.Rows[e.NewSelectedIndex].Cells[3].Controls[0] as CheckBox;
            if (CHK.Checked == false)
            {
                if (new JpmmsClasses.BL.MainStreet().CheckStreetsIRI(gvRegionSamples.Rows[e.NewSelectedIndex].Cells[1].Text, gvRegionSamples.Rows[e.NewSelectedIndex].Cells[6].Text))
                {
                    if (new JpmmsClasses.BL.MainStreet().InsertRecivedIRI(gvRegionSamples.Rows[e.NewSelectedIndex].Cells[1].Text, gvRegionSamples.Rows[e.NewSelectedIndex].Cells[6].Text))
                    {
                        CHK.Checked = true;
                        e.Cancel = true;
                        ((LinkButton)gvRegionSamples.Rows[e.NewSelectedIndex].Cells[4].Controls[0]).Text = "حذف";
                        lblFeedback.Text = Feedback.InsertSuccessfull();
                        gvRegionSamples.DataBind();
                    }
                    else
                        CHK.Checked = false;
                }
                else
                {
                    lblFeedback.Text = "يجب إدخال IRI أولا";
                    e.Cancel = true;
                }
            }
            else
            {
                if (!new JpmmsClasses.BL.MainStreet().CheckStreetsIRI(gvRegionSamples.Rows[e.NewSelectedIndex].Cells[1].Text, gvRegionSamples.Rows[e.NewSelectedIndex].Cells[6].Text))
                {
                    if (new JpmmsClasses.BL.MainStreet().DeleteRecivedIRI(gvRegionSamples.Rows[e.NewSelectedIndex].Cells[1].Text, gvRegionSamples.Rows[e.NewSelectedIndex].Cells[6].Text))
                    {
                        lblFeedback.Text = Feedback.DeleteSuccessfull();
                        e.Cancel = true;
                        gvRegionSamples.DataBind();
                    }
                    else
                        lblFeedback.Text = Feedback.DeleteException();
                }
                else
                {
                    lblFeedback.Text = "يجب حذف IRI أولا";
                    e.Cancel = true;
                }
            }
        }
        else
        {
            e.Cancel = true;
            lblFeedback.Text = Feedback.NoPermissions();
        }

    }
    protected void gvRegionSamples_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < gvRegionSamples.Rows.Count; i++)
        {
            if (((CheckBox)gvRegionSamples.Rows[i].Cells[3].Controls[0]).Checked == false)
                ((LinkButton)gvRegionSamples.Rows[i].Cells[4].Controls[0]).Text = "إدخال";
        }
    }


    protected void gvRegionSamples_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "        العدد         ";
            HeaderCell.Text += new JpmmsClasses.BL.MainStreet().LenghthRowDataTRANSFAREMFV().Rows[0][0];
            HeaderCell.Text += "       الطول        ";
            HeaderCell.Text += new JpmmsClasses.BL.MainStreet().LenghthRowDataTRANSFAREMFV().Rows[1][0];
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = gvRegionSamples.Columns.Count;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.BackColor = System.Drawing.Color.Black;
            HeaderGridRow.Cells.Add(HeaderCell);
            gvRegionSamples.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }
    protected void gvRegionSamples_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lblFeedback.Text = string.Empty;
        CheckBox CHK = gvRegionSamples.Rows[e.RowIndex].Cells[3].Controls[0] as CheckBox;
        if (CHK.Checked)
            lblFeedback.Text = "يجب حذف الملف من النظام اولا";
        else
        {
            if (new JpmmsClasses.BL.MainStreet().UpdateFailIRIMFV(gvRegionSamples.Rows[e.RowIndex].Cells[1].Text, true, gvRegionSamples.Rows[e.RowIndex].Cells[6].Text))
            {
                lblFeedback.Text = Feedback.UpdateSuccessfull();
                gvRegionSamples.DataBind();
            }
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }

        e.Cancel = true;
    }
    protected void BtnSHAPE_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "48")
        {
            bool Value = false;
            if (new JpmmsClasses.BL.MainStreet().Remove_UpdateSHAPELength())
            {
                if (new JpmmsClasses.BL.MainStreet().InsertLengthSHAPE_FISNSHED())
                {
                    if (new JpmmsClasses.BL.MainStreet().Remove_InsertUpdateIRISections())
                        Value = true;
                    else
                        Value = false;
                }
                else
                    Value = false;
            }
            else
                Value = false;

            if (Value)
                lblFeedback.Text = " تم " + BtnSHAPE.Text;
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnSectionsIRI_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "48")
        {
            if (new JpmmsClasses.BL.MainStreet().Insert_UpdateIRISections())
                lblFeedback.Text = " تم " + BtnSectionsIRI.Text;
            else
                lblFeedback.Text = Feedback.UpdateUNSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
    protected void BtnFinshed_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString() == "48")
        {
            if (new JpmmsClasses.BL.MainStreet().Finshed_UpdateEquipment())
                lblFeedback.Text = Feedback.UpdateSuccessfull();
            else
                lblFeedback.Text = Feedback.StatusUpdateSuccessfull();
        }
        else
        {
            lblFeedback.Text = Feedback.NoPermissions();
        }
    }
}