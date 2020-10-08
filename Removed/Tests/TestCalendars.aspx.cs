using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASPX_Tests_TestCalendars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnShowDates_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Hijri2Greg1.SelectedGregDate) || string.IsNullOrEmpty(Hijri2Greg1.SelectedHijriDate))
            return;

        TextBox1.Text = string.Format("{0} \r\n {1} ", Hijri2Greg1.SelectedGregDate, Hijri2Greg1.SelectedHijriDate);
    }

}