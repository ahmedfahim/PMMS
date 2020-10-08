using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace UtilitiesLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExceptionHandling
    {

        #region Public Methods
        /// <summary>
        /// When the FileUpload control is validated at the client,
        /// the FileName property being validated includes the complete path: C:\Images\MyFile.jpg.
        /// When it gets to the server, the FileUpload control's FileName property is MyFile.jpg.
        /// The path is removed.That's why the regular expression is failing.
        /// you can solve by use this ValidationExpression
        /// .*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])$
        /// or use this Method to solve any ValidationExpression when back to server 
        /// </summary>
        public static void ClientScriptValidator(Page PageAspx, RegularExpressionValidator Regular)
        {
            if (PageAspx != null && Regular != null)
            {
                string stordRegular = Regular.ValidationExpression;
                Regular.Enabled = false;
                PageAspx.Validate();
                Regular.Enabled = true;
                Regular.ValidationExpression = stordRegular;
            }


        }
        /// <summary>
        /// this metod to return previous Exception in html format
        /// </summary>
        /// <param name="PageAspx">Pass Your Page</param>
        /// <returns>False If Server.GetLastError is null</returns>
        public static string GetLastError(Page PageAspx)
        {
            StringBuilder sbErrorString = new StringBuilder();
            if (PageAspx != null && PageAspx.Server.GetLastError() != null)
            {
                Exception objErr = PageAspx.Server.GetLastError().GetBaseException();
                sbErrorString.Append("<b>Error Caught in Page_Error event</b><hr><br>");
                sbErrorString.Append("<br><b>Error in: </b>");
                sbErrorString.Append(PageAspx.Request.Url.ToString());
                sbErrorString.Append("<br><b>Error Message: </b>");
                sbErrorString.Append(objErr.Message.ToString());
                sbErrorString.Append("<br><b>Stack Trace:</b><br>");
                sbErrorString.Append(objErr.StackTrace.ToString());
                PageAspx.Server.ClearError();
                return sbErrorString.ToString();
            }
            else
                return false.ToString();


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objError"></param>
        /// <returns></returns>
        public static string QueryStringException(Exception objError)
        {
            StringBuilder sbQueryString = new StringBuilder(512);
            if (objError != null)
            {
                string errorPath = HttpContext.Current.Request.FilePath;
                sbQueryString.Append("?aspxerrorpath=");
                sbQueryString.Append(errorPath);
                sbQueryString.Append("&message=");
                sbQueryString.Append(objError.Message);
                sbQueryString.Append("&source=");
                sbQueryString.Append(objError.Source);
                sbQueryString.Append("&stacktrace=");
                sbQueryString.Append(HttpUtility.UrlEncode(objError.StackTrace));
                sbQueryString.Append("&errordate=");
                sbQueryString.Append(DateTime.Now.ToString(CultureInfo.InstalledUICulture));
            }
            return (sbQueryString.ToString());
        }
        /// <summary>
        /// This Method running at Global.asax To Cath MaxRequestException 
        /// and Redirect the user to RedirectPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="RedirectPage"></param>
        public static void CatchMaxRequestLength(HttpApplication sender, string RedirectPage)
        {
            HttpRuntimeSection runTime = (HttpRuntimeSection)
               WebConfigurationManager.GetSection("system.web/httpRuntime");

            //Approx 100 Kb(for page content) size has been deducted because
            //the maxRequestLength proprty is the page size, not only the file upload size
            int maxRequestLength = (runTime.MaxRequestLength - 100) * 1024;

            //This code is used to check the request length of the page
            //and if the request length is greater than MaxRequestLength then retrun 
            //to the same page with extra query string value action=exception
            HttpContext context = sender.Context;

            if (context.Request.ContentLength > maxRequestLength)
            {

                IServiceProvider provider = (IServiceProvider)context;

                HttpWorkerRequest workerRequest = (HttpWorkerRequest)provider.GetService(typeof(HttpWorkerRequest));

                // Check if body contains data
                if (workerRequest.HasEntityBody())
                {
                    // get the total body length
                    int requestLength = workerRequest.GetTotalEntityBodyLength();

                    // Get the initial bytes loaded
                    int initialBytes = 0;

                    if (workerRequest.GetPreloadedEntityBody() != null)

                        initialBytes = workerRequest.GetPreloadedEntityBody().Length;

                    if (!workerRequest.IsEntireEntityBodyIsPreloaded())
                    {
                        byte[] buffer = new byte[512000];

                        // Set the received bytes to initial bytes before start reading
                        int receivedBytes = initialBytes;

                        while (requestLength - receivedBytes >= initialBytes)
                        {
                            // Read another set of bytes
                            initialBytes = workerRequest.ReadEntityBody(buffer, buffer.Length);

                            // Update the received bytes
                            receivedBytes += initialBytes;
                        }
                        initialBytes = workerRequest.ReadEntityBody(buffer, requestLength - receivedBytes);
                    }
                }
                context.Response.Redirect(RedirectPage);
            }



        }
        /// <summary>
        /// This Method running at Global.asax To Cath MaxRequestException 
        /// and Redirect the user to the same page with querystring action=MaxRequestException
        /// </summary>
        /// <param name="sender"></param>
        public static void CatchMaxRequestLength(HttpApplication sender)
        {
            CatchMaxRequestLength(sender, sender.Context.Request.Path + "?action=MaxRequestException");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objError"></param>
        /// <returns></returns>
        public static bool WriteErrorToLog(Exception objError)
        {
            try
            {
                string strError = objError.ToString();
                string strEventLog = "Aspx Error";
                // Create the event log if it does not exist
                if (!EventLog.SourceExists(strEventLog))
                    EventLog.CreateEventSource(strEventLog, strEventLog);
                // Write to the event log
                EventLog objEventLog = new EventLog();
                objEventLog.Source = strEventLog;
                objEventLog.WriteEntry(strError, System.Diagnostics.EventLogEntryType.Error);
                return true;
            }
            catch
            {
                //Might not be able to write to the Event Log
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objError"></param>
        /// <param name="strTo"></param>
        /// <returns></returns>
        public static bool SendEmailError(Exception objError, string strTo)
        {
            try
            {
                string strError = objError.ToString();
                string strErrorPath = HttpContext.Current.Request.FilePath;
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.Append("\nError Occured: ");
                sbMessage.Append(DateTime.Now.ToString());
                sbMessage.Append("\nFile:");
                sbMessage.Append(strErrorPath);
                sbMessage.Append("\nError: \n");
                sbMessage.Append(strError);
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send("ASP.NET global.asax", strTo, "Unhandled ASP.NET Error", sbMessage.ToString());
                return true;
            }
            catch
            {
                //May not have SMTP service available
                return false;
            }

        }
        /// <summary>
        /// Get the HTTP status code from a URL
        /// What we really want is not a Boolean value telling us if the web server is
        /// responding or not. The best way is to get the HTTP status code so we
        /// can act appropriately. The status code for a properly working web 
        /// server is 200 and 404 if there is no reply.
        /// You can use it to write the status code to the response stream like this:
        /// Response.Write((int)HttpStatus("http://www.google.com"))
        /// </summary>
        /// <param name="url"></param>
        /// <returns>System.Net.HttpStatusCode enumeration value based on the specified URL</returns>
        public static HttpStatusCode HttpStatus(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode;
                }
            }
            catch (System.Net.WebException)
            {
                return HttpStatusCode.NotFound;
            }
        }
        #endregion

        #region Not Implemented
        public static String ErrorSerialize(Exception objError)
        {
            throw new NotImplementedException();
        }
        public static Exception ErrorDeserialize(String strError)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
