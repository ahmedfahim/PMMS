﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASCX_SearchIntersect : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            txtNumSearch.Focus();
    }


    private int _SelectedIntersectionID;
    private string _SelectedMain_NO;
    
    public int SelectedIntersectionID
    {
        get { return _SelectedIntersectionID; }
        set { _SelectedIntersectionID = value; }
    }

    public string SelectedMain_NO
    {
        get { return _SelectedMain_NO; }
        set { _SelectedMain_NO = value; }
    }


    public delegate void SetChangedEvent();
    public event SetChangedEvent SetSearchChanged;


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            DataTable dt;
            if (radByName.Checked)
            {
                if (string.IsNullOrEmpty(Session["MainStreetID"].ToString()))
                    throw new Exception("الرجاء اختيار الطريق الرئيسي أولا قبل البحث عن تقاطع");
                dt = new Intersection().Search(txtNumSearch.Text, radByNumber.Checked, int.Parse(Session["MainStreetID"].ToString()));
            }
            else
            {
                dt = new Intersection().SearchByNumber(txtNumSearch.Text);
            }
            Session["search"] = dt;
            gvSearch.DataSource = dt;
            gvSearch.DataBind();

            lblError.Text = (dt.Rows.Count == 0) ? Feedback.NoData() : "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        txtNumSearch.Text = "";

        gvSearch.SelectedIndex = -1;
        gvSearch.DataSource = null;
        gvSearch.DataBind();

        this.Visible = false;
        SelectedIntersectionID = 0;
        SelectedMain_NO = null; 

        SetSearchChanged();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedIntersectionID = (gvSearch.SelectedValue != null) ? int.Parse(gvSearch.SelectedValue.ToString()) : 0;
        SelectedMain_NO = (gvSearch.SelectedValue != null) ? gvSearch.Rows[gvSearch.SelectedIndex].Cells[4].Text : null;

        if (SetSearchChanged != null)
            SetSearchChanged();

        lblError.Text = "";
        txtNumSearch.Text = "";

        gvSearch.SelectedIndex = -1;
        gvSearch.DataSource = null;
        gvSearch.DataBind();
    }

    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearch.PageIndex = e.NewPageIndex;
        gvSearch.DataSource = (DataTable)Session["search"];
        gvSearch.DataBind();
    }

}
