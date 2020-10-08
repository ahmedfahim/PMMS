using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace UtilitiesLibrary
{
    namespace Controls
    {
        public class OneClickButton : Button
        {
            private string replaceTitleTo;

            public string ReplaceTitleTo
            {
                get { return this.replaceTitleTo; }
                set { this.replaceTitleTo = value; }
            }

            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);

                StringBuilder script = new StringBuilder();
                script.Append("if (typeof(Page_ClientValidate) == 'function') { ");
                script.Append("if (Page_ClientValidate() == false) { return false; }} ");

                if (!String.IsNullOrEmpty(this.replaceTitleTo))
                {
                    script.Append("this.value = '");
                    script.Append(this.replaceTitleTo);
                    script.Append("';");
                }

                script.Append("this.disabled = true;");
                script.Append(this.Page.GetPostBackEventReference(this));
                script.Append(";");
                this.Attributes.Add("onclick", script.ToString());
            }
        }
    }
}