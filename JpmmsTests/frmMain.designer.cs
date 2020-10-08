namespace JpmmsTests
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtMain_ST_NO = new System.Windows.Forms.TextBox();
            this.btnMaintenanceDecision = new System.Windows.Forms.Button();
            this.radSecStreet = new System.Windows.Forms.RadioButton();
            this.radIntersection = new System.Windows.Forms.RadioButton();
            this.radLane = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(183, 291);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(130, 36);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "button1";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRegion);
            this.groupBox1.Controls.Add(this.txtMain_ST_NO);
            this.groupBox1.Controls.Add(this.btnMaintenanceDecision);
            this.groupBox1.Controls.Add(this.radSecStreet);
            this.groupBox1.Controls.Add(this.radIntersection);
            this.groupBox1.Controls.Add(this.radLane);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(183, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(577, 215);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حساب قرارات الصيانة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "رقم المنطقة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "رقم الشارع الرئيسي";
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(184, 121);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(100, 26);
            this.txtRegion.TabIndex = 5;
            // 
            // txtMain_ST_NO
            // 
            this.txtMain_ST_NO.Location = new System.Drawing.Point(184, 64);
            this.txtMain_ST_NO.Name = "txtMain_ST_NO";
            this.txtMain_ST_NO.Size = new System.Drawing.Size(100, 26);
            this.txtMain_ST_NO.TabIndex = 3;
            // 
            // btnMaintenanceDecision
            // 
            this.btnMaintenanceDecision.Location = new System.Drawing.Point(82, 173);
            this.btnMaintenanceDecision.Name = "btnMaintenanceDecision";
            this.btnMaintenanceDecision.Size = new System.Drawing.Size(442, 36);
            this.btnMaintenanceDecision.TabIndex = 2;
            this.btnMaintenanceDecision.Text = "حساب قرارات الصيانة";
            this.btnMaintenanceDecision.UseVisualStyleBackColor = true;
            this.btnMaintenanceDecision.Click += new System.EventHandler(this.btnMaintenanceDecision_Click);
            // 
            // radSecStreet
            // 
            this.radSecStreet.AutoSize = true;
            this.radSecStreet.Location = new System.Drawing.Point(446, 124);
            this.radSecStreet.Name = "radSecStreet";
            this.radSecStreet.Size = new System.Drawing.Size(116, 23);
            this.radSecStreet.TabIndex = 2;
            this.radSecStreet.Text = "للشوارع الفرعية";
            this.radSecStreet.UseVisualStyleBackColor = true;
            // 
            // radIntersection
            // 
            this.radIntersection.AutoSize = true;
            this.radIntersection.Location = new System.Drawing.Point(486, 77);
            this.radIntersection.Name = "radIntersection";
            this.radIntersection.Size = new System.Drawing.Size(76, 23);
            this.radIntersection.TabIndex = 1;
            this.radIntersection.Text = "للتقاطعات";
            this.radIntersection.UseVisualStyleBackColor = true;
            // 
            // radLane
            // 
            this.radLane.AutoSize = true;
            this.radLane.Checked = true;
            this.radLane.Location = new System.Drawing.Point(485, 37);
            this.radLane.Name = "radLane";
            this.radLane.Size = new System.Drawing.Size(77, 23);
            this.radLane.TabIndex = 0;
            this.radLane.TabStop = true;
            this.radLane.Text = "للمسارات";
            this.radLane.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 519);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTestConnection);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMaintenanceDecision;
        private System.Windows.Forms.RadioButton radSecStreet;
        private System.Windows.Forms.RadioButton radIntersection;
        private System.Windows.Forms.RadioButton radLane;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtMain_ST_NO;
        private System.Windows.Forms.Button button1;
    }
}

