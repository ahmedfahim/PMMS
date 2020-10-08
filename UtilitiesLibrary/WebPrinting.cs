using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Web;

namespace UtilitiesLibrary
{
    namespace Web
    {
        /// <summary>
        /// Why would you want to print a web form directly to a printer once the user 
        /// submits it? Consider that not everyone in an organization has access to the 
        /// same level of technology. Usually web form data is sent via email, 
        /// saved as a text or xml file, or added to a database. For many applications
        /// the email option works well. But, in some organizations this email is then
        /// printed so that someone else can take the necessary action. 
        /// This works well where management desires to approve all events. 
        /// If the web form is printed to a network printer instead of or in addition 
        /// to the email being sent; then the person responsible for taking action has 
        /// access to the information. The rest of this discussion will focus on printing
        /// a web form.
        /// Note: This article uses server-side code to print a web form to a printer 
        /// that is installed on the server. Client-side code would be required 
        /// to print a web page to a printer that is installed on the client. 
        /// Using client-side javascript you can bring up the print dialog box with
        /// this statement: window.print();
        /// Web Form Printing Class 
        /// The web form printing class has two routines. 
        /// The first, PageCreate, takes two inputs the name of the printer 
        /// and the title to printed at the top of the page. This routine creates a 
        /// page (string) with line breaks that contain each field and it's value. 
        /// It also creates a string that is sent to a results page. The second routine,
        /// PagePrint, prints the page one line at a time.
        /// </summary>
        public class WebPrinting
        {
            protected StringReader stringToPrint;
            protected Font printFont;
            public void PageCreate(string printerName, string pageTitle)
            {
                StringBuilder sb = new StringBuilder();
                string qs = "";
                try
                {
                    // start creating page with title and date/time
                    sb.Append(pageTitle + "\n\n");
                    sb.Append("DateTime: " + DateTime.Now.ToString() + "\n\n");
                    string fieldValue;
                    // iterate submitted form fields, also gets field name
                    foreach (string fieldName in HttpContext.Current.Request.Form)
                    {
                        // exclude viewstate and submit button
                        if (fieldName == "__VIEWSTATE" || fieldName == "Submit") { }
                        else
                        {
                            // get the field value
                            fieldValue = HttpContext.Current.Request.Form[fieldName];
                            // builds the querystring for results.aspx
                            qs = qs + "&" + fieldName + "=" + fieldValue;
                            // adds the field name and value to the page
                            // breaks the field value into 50 character segments so it will fit on the paper
                            // this example only accounts for fields of l50 characters or less 
                            // issue: breaks in the middle of words instead of at spaces
                            if (fieldValue.Length > 100)
                            {
                                sb.Append(fieldName + ": " + fieldValue.Substring(0, 50) + "\n");
                                sb.Append("            " + fieldValue.Substring(50, 50) + "\n");
                                sb.Append("            " + fieldValue.Substring(100, fieldValue.Length - 100) + "\n");
                            }
                            else if (fieldValue.Length > 50)
                            {
                                sb.Append(fieldName + ": " + fieldValue.Substring(0, 50) + "\n");
                                sb.Append("            " + fieldValue.Substring(50, fieldValue.Length - 50) + "\n");
                            }
                            else
                            {
                                sb.Append(fieldName + ": " + fieldValue + "\n");
                            }

                        }
                    }
                    // place stringbuilder in string reader
                    stringToPrint = new StringReader(sb.ToString());
                    // set font and size here
                    printFont = new Font("Arial", 12);
                    PrintDocument doc = new PrintDocument();
                    // set the printer name
                    doc.PrinterSettings.PrinterName = printerName;
                    // add print page event handler
                    doc.PrintPage += new PrintPageEventHandler(this.PagePrint);
                    // print the page
                    doc.Print();
                    // adds status to querystring
                    qs = "Results.aspx?" + qs.Substring(1, qs.Length - 1) + "&Status=Success";
                }
                catch
                {
                    qs = "Results.aspx?Status=Failed";
                }
                finally
                {
                    stringToPrint.Close();
                }
                // redirects to result.aspx
                HttpContext.Current.Response.Redirect(qs);
            }
            private void PagePrint(object sender, PrintPageEventArgs e)
            {
                float linesPerPage = 0;
                float linePosition = 0;
                int lineCount = 0;
                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;
                String line = null;
                // gets the number of lines per page
                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                // iterate lines in string
                while (lineCount < linesPerPage && ((line = stringToPrint.ReadLine()) != null))
                {
                    // set line postion from top margin
                    linePosition = topMargin + (lineCount * printFont.GetHeight(e.Graphics));
                    // print line
                    e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, linePosition,
                        new StringFormat());
                    lineCount++;
                }
                // are there more lines?
                if (line != null)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
        }
        /// <summary>
        /// Making a Test Form
        /// The test page conatins a test form with two fields. 
        /// Only two lines of code in the Submit_Click routine are needed to print the 
        /// web form. You must change the printer name to one that is installed on 
        /// your server. For local printers and printers that use IP printing just use 
        /// the name in your printers folder (example: "HP 1200") For 
        /// Novell network printing use the path (example: \\server\printer). 
        /// You may have to add impersonation to your web.config file for Novell 
        /// network printing. One other note, the submit button must have an id equal
        /// to "Submit" or it will also be printed.
        /// Test.aspx:
        /// Conclusion 
        /// Printing a web form directly to a printer is easy and for some applications
        /// it is the best solution. The application included in this discussion has been 
        /// running in a medium sized organization for over a year now and they love it. 
        /// Because paperless organizations are not yet a reality, you may find a use for
        /// this application too. At the very least you can now add printers to the list 
        /// of destinations for web forms. 
        /// </summary>
        //<%@ Page Language="C#" %>
        //<%@ outputcache location="None" %>
        //<script runat="server">    
        //    void Submit_Click(object sender, EventArgs e) {
        //        CsXml.FormPrint.WebPrinting wp = new CsXml.FormPrint.WebPrinting();
        //        wp.PageCreate("HP 1200", "TEST FORM");
        //    }
        //</script>
        //<html>
        //<head>
        //    <title>Test Form</title>
        //</head>
        //<body>
        //    <form runat="server">
        //        <table>
        //            <tbody>
        //                <tr>
        //                    <td colspan="2">
        //                        <strong>Test Form</strong></td>
        //                </tr>
        //                <tr>
        //                    <td>
        //                        First&nbsp;Name</td>
        //                    <td>
        //                        <asp:TextBox id="FirstName" runat="server"></asp:TextBox>
        //                    </td>
        //                </tr>
        //                <tr>
        //                    <td>
        //                        Last&nbsp;Name</td>
        //                    <td>
        //                        <asp:TextBox id="LastName" runat="server"></asp:TextBox>
        //                    </td>
        //                </tr>
        //                <tr>
        //                    <td colspan="2">
        //                        <asp:Button id="Submit" onclick="Submit_Click" 
        //                              runat="server" Text="Submit"></asp:Button>
        //                    </td>
        //                </tr>
        //            </tbody>
        //        </table>
        //    </form>
        //</body>
        //</html>

        //Using a Results Page 
        //[ Back To Top ]


        //[Download Code]
        //The results page that I use simply iterates the querystring that was created by the web form printing class to display the results. One of the reasons for using a results page is that it allows the user to print a hard copy for their records. Yes, I know it's a waste of paper. The results page can easily be removed from the web form printing class if you do not need it for your application.

        //Results.aspx:


        //<%@ Page language="c#" %>
        //<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        //<html>
        // <head>
        //  <title>Results</title>
        // </head>
        // <body>
        //  <form runat="server" ID="Form1">
        //   <table cellspacing="1" cellpadding="1" border="0">
        //    <tr>
        //     <td bgcolor="navy" colspan="2">
        //      <font color="white" size="3">Results&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<% = 
        //         System.DateTime.Now.ToString() %></font></td>
        //    </tr>
        //    <% string fieldValue;
        //    foreach ( string fieldName in Request.QueryString ) {
        //    if ( Request.QueryString[fieldName] != "" ) fieldValue = 
        //        Request.QueryString[fieldName] ;
        //    else fieldValue = "&nbsp;"; 
        //    %>
        //    <tr>
        //     <td align="right" bgcolor="lightskyblue"><b><%= fieldName %></b></td>
        //     <td bgcolor="lightskyblue"><%= fieldValue %></td>
        //    </tr>
        //    <% } %>
        //   </table>
        //  </form>
        // </body>
        //</html> 
    }
 

}
