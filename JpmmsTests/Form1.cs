using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maintenance_Decision;

namespace JpmmsTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string sql = string.Format("select (select nvl(sum(sample_length*sample_width), 0) from lane_samples where sample_id in (select distinct sample_id from distress where entry_date>=to_date('{0}', 'DD/MM/YYYY')  and entry_date<to_date('{1}', 'DD/MM/YYYY') and sample_id is not null))" +
                    "+ (select nvl(sum(intersec_samp_area), 0) from intersection_samples where inter_samp_id in (select distinct inter_samp_id from distress where entry_date>=to_date('{0}', 'DD/MM/YYYY')  and entry_date<to_date('{1}', 'DD/MM/YYYY') and inter_samp_id is not null)) " +
                    "+(select nvl(sum(second_st_length*second_st_width), 0) from streets where street_id in  (select distinct street_id from distress where entry_date>=to_date('{0}', 'DD/MM/YYYY')  and entry_date<to_date('{1}', 'DD/MM/YYYY') and second_id is not null)) " +
                    //"+(select nvl(sum(second_st_length*second_st_width), 0) from secondary_streets where second_id in  (select distinct second_id from distress where entry_date>=to_date('{0}', 'DD/MM/YYYY')  and entry_date<to_date('{1}', 'DD/MM/YYYY') and second_id is not null)) " +
                    " as total_entred_areas_distress from dual", dtpDate.Value.ToString("dd/MM/yyyy"), dtpDate.Value.AddDays(1).ToString("dd/MM/yyyy"));

                string cn = "DATA SOURCE=jpmms;PASSWORD=jpmms;USER ID=jpmms; ";
                double value = double.Parse(new OracleDatabaseClass(cn).ExecuteScalar(sql).ToString());
                txtArea.Text = value.ToString("N2");

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    

    }
}
