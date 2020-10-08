﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections;
using System.Data;
using JpmmsClasses;
using JpmmsClasses.BL.UDI;

public partial class ASPX_Operations_ResultMd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Guid id = new Guid(Request.QueryString["id"]);

            // Check the thread result collection
            if (ThreadResults.Contains(id))
            {
                // The worker thread has finished

                // Get the result from the thread result collection
                //int authorizationId = (int)ThreadResults.Get(id);
                DataTable dt = (DataTable)ThreadResults.Get(id);

                // Remove the result from the collection
                ThreadResults.Remove(id);

                lblMessage.Text = "انتهى حساب حالة الرصف وقرارات الصيانة بنجاح";
                lblMessage.ForeColor = Color.Green;

                UdiShared.StartShapeFileAutoCreationProgram();
            }
            else
            {
                lblMessage.Text = "يجري الآن حساب حالة الرصف وقرارات الصيانة، الرجاء الانتظار";
                lblMessage.ForeColor = Color.Black;

                Response.AddHeader("Refresh", "2");
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}