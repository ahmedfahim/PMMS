using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Hijri2Greg : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string SelectedHijriDate
    {
        get
        {
            //return MaskedTextBox1.Text; 
            return new JpmmsClasses.Dates().FormatHijri(MaskedTextBox1.Text, "dd/MM/yyyy");
        }
        set
        {
            MaskedTextBox1.Text = value;
            MaskedTextBox1_TextChanged(new Object(), new EventArgs());
        }
    }

    public string SelectedGregDate
    {
        get { return lblRadSelectedDate.Text; }
        set { lblRadSelectedDate.Text = value; }
    }


    protected void MaskedTextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            lblRadSelectedDate.Text = new JpmmsClasses.Dates().HijriToGreg(MaskedTextBox1.Text, "dd/MM/yyyy");
        }
        catch (Exception)
        {
            lblError.Text = "التاريخ الهجري المدخل غير صحيح"; //ex.Message;
        }
    }

}