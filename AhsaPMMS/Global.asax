<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        //// Code that runs when an unhandled error occurs
        //Exception ex = Server.GetLastError().GetBaseException();
        //StringBuilder sb = new StringBuilder();
        //sb.AppendLine("<b>Message: " + ex.Message + "</b>");
        //sb.AppendLine("<b>Exception: " + ex.GetType().ToString() + "</b>");
        //if (ex.TargetSite != null)
        //    sb.AppendLine("<b>TargetSite: " + ex.TargetSite.ToString() + "</b>");

        //sb.AppendLine("<b>Source: " + ex.Source + "</b>");
        //sb.AppendLine("<b>StackTrace: " + ex.StackTrace.Replace(Environment.NewLine, "") + "</b>");
        //sb.AppendLine("<b>DataCount: " + ex.Data.Count.ToString() + "</b>");
        //if (ex.Data.Count > 0)
        //{
        //    HtmlTable tb = new HtmlTable();
        //    tb.Border = 1;
        //    HtmlTableRow htr = new HtmlTableRow();
        //    HtmlTableCell htc1 = new HtmlTableCell();
        //    HtmlTableCell htc2 = new HtmlTableCell();
        //    HtmlTableCell htc3 = new HtmlTableCell();
        //    HtmlTableCell htc4 = new HtmlTableCell();
        //    htc1.InnerHtml = "<b>Key</b>";
        //    htc2.InnerHtml = "<b>Value</b>";
        //    htc3.InnerHtml = "Key Type: ";
        //    htc4.InnerHtml = "Value Type: ";

        //    htr.Cells.Add(htc1);
        //    htr.Cells.Add(htc2);
        //    htr.Cells.Add(htc3);
        //    htr.Cells.Add(htc4);
        //    tb.Rows.Add(htr);

        //    foreach (DictionaryEntry de in ex.Data)
        //    {
        //        htr = new HtmlTableRow();
        //        htc1 = new HtmlTableCell();
        //        htc2 = new HtmlTableCell();
        //        htc3 = new HtmlTableCell();
        //        htc4 = new HtmlTableCell();

        //        htc1.InnerHtml = "<b>" + de.Key + "</b>";
        //        htc2.InnerHtml = "<b>" + de.Value + "</b>";
        //        htc3.InnerHtml = "<b>" + de.Key.GetType().Name + "</b>";
        //        htc4.InnerHtml = "<b>" + de.Value.GetType().Name + "</b>";
        //        htc3.Align = "center";
        //        htc4.Align = "center";

        //        htr.Cells.Add(htc1);
        //        htr.Cells.Add(htc2);
        //        htr.Cells.Add(htc3);
        //        htr.Cells.Add(htc4);
        //        tb.Rows.Add(htr);
        //    }

        //    StringBuilder tblsb = new StringBuilder();
        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    tb.RenderControl(htw);
        //    sb.AppendLine(tblsb.ToString());            
        //}

        //sb.AppendLine("");
        //sb.AppendLine("<b>Exception</b>: " + ex.ToString().Replace(Environment.NewLine, "") + "");

        //Session["Exception"] = sb.ToString();
        //Server.ClearError();
        //Response.Redirect("~/aspx/DefaultError.aspx", false);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        //Session["lang"] = "en-GB";
        Session["lang"] = "ar-AE";
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
