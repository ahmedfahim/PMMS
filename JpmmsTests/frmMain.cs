using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintenance_Decision.DB;
using Maintenance_Decision;
using JpmmsClasses.BL.AhmedYousif;

namespace JpmmsTests
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Maintenance_Decision.DB.DBConnection.OpenConnection() + "");
        }

        private void btnMaintenanceDecision_Click(object sender, EventArgs e)
        {
            //C_Maint_Decision m_C_Maint_Decision = new C_Maint_Decision();

            //if (radLane.Checked)
            //{
            //    string MAIN_NO = txtMain_ST_NO.Text.Trim();
            //    m_C_Maint_Decision.CalculateMD_4_StreetLanes(MAIN_NO, 1);
            //    MessageBox.Show("انتهى الحساب");
            //}
            //else if (radIntersection.Checked)
            //{
            //    string MAIN_NO = txtMain_ST_NO.Text.Trim();
            //    m_C_Maint_Decision.CalculateMD_4_StreetIntersections(MAIN_NO, 1);
            //}
            //else if (radSecStreet.Checked)
            //{
            //    string SUb_REG_NO = txtRegion.Text.Trim();
            //    m_C_Maint_Decision.CalculateMD_4_SEC_Street(SUb_REG_NO);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

    }
}
