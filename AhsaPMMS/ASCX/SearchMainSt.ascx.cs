using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL;
using System.Data;

public partial class ASCX_SearchMainSt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            txtNumSearch.Focus();
    }


    private int _SelectedMainStreetID;

    public int SelectedMainStreetID
    {
        get { return _SelectedMainStreetID; }
        set { _SelectedMainStreetID = value; }
    }

    public delegate void SetChangedEvent();
    public event SetChangedEvent SetSearchChanged;


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            DataTable dt = new MainStreet().Search(txtNumSearch.Text, radByNumber.Checked);
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
        SelectedMainStreetID = 0;

        SetSearchChanged();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedMainStreetID = (gvSearch.SelectedValue != null) ? int.Parse(gvSearch.SelectedValue.ToString()) : 0;

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
