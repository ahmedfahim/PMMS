using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JpmmsClasses.BL.Lookups;

public partial class ASPX_Intersections_LoadIntersectTypeImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["typeID"] != null)
            {
                Byte[] bytes = new IntersectType().LoadPhoto(int.Parse(Request.QueryString["typeID"]));

                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = @"image/gif";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception)
        {

        }
    }

}
