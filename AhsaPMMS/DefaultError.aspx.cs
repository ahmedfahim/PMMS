using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DefaultError : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Session["Exception"].ToString()))
                ltrFeedback.Text = Session["Exception"].ToString();
            //    Exception ex = Server.GetLastError();
            //    if (ex != null)
            //    {
            //        if (ex.GetBaseException() != null)
            //            lblFeedback.Text = ex.Message;
            //    }
        }
    }


}
