namespace DVLD_SE.Applications.Local_Driving_License_Application
{
    partial class frmAddEditLocalDrivingLicenseApplication
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
            this.tcApplication = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonFilterCard1 = new DVLD_SE.People.Controls.ctrlPersonFilterCard();
            this.tpApplication = new System.Windows.Forms.TabPage();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbApplicatoinID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcApplication.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcApplication
            // 
            this.tcApplication.Controls.Add(this.tabPage1);
            this.tcApplication.Controls.Add(this.tpApplication);
            this.tcApplication.Location = new System.Drawing.Point(18, 158);
            this.tcApplication.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcApplication.Name = "tcApplication";
            this.tcApplication.SelectedIndex = 0;
            this.tcApplication.Size = new System.Drawing.Size(832, 569);
            this.tcApplication.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.ctrlPersonFilterCard1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(824, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::DVLD_SE.Properties.Resources.Close_32;
            this.btnNext.Location = new System.Drawing.Point(668, 473);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(130, 58);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonFilterCard1
            // 
            this.ctrlPersonFilterCard1.AutoSize = true;
            this.ctrlPersonFilterCard1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonFilterCard1.FilterEndable = true;
            this.ctrlPersonFilterCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlPersonFilterCard1.Location = new System.Drawing.Point(8, 7);
            this.ctrlPersonFilterCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonFilterCard1.Name = "ctrlPersonFilterCard1";
            this.ctrlPersonFilterCard1.ShowAddPersonBtn = true;
            this.ctrlPersonFilterCard1.Size = new System.Drawing.Size(802, 470);
            this.ctrlPersonFilterCard1.TabIndex = 0;
            this.ctrlPersonFilterCard1.OnPersonSelected += new System.Action<int>(this.ctrlPersonFilterCard1_OnPersonSelected);
            // 
            // tpApplication
            // 
            this.tpApplication.Controls.Add(this.cbLicenseClasses);
            this.tpApplication.Controls.Add(this.pictureBox8);
            this.tpApplication.Controls.Add(this.label12);
            this.tpApplication.Controls.Add(this.lbApplicatoinID);
            this.tpApplication.Controls.Add(this.pictureBox4);
            this.tpApplication.Controls.Add(this.label7);
            this.tpApplication.Controls.Add(this.lbApplicationDate);
            this.tpApplication.Controls.Add(this.pictureBox3);
            this.tpApplication.Controls.Add(this.label5);
            this.tpApplication.Controls.Add(this.lbApplicationFees);
            this.tpApplication.Controls.Add(this.pictureBox2);
            this.tpApplication.Controls.Add(this.label3);
            this.tpApplication.Controls.Add(this.lbCreatedBy);
            this.tpApplication.Controls.Add(this.pictureBox1);
            this.tpApplication.Controls.Add(this.label1);
            this.tpApplication.Location = new System.Drawing.Point(4, 29);
            this.tpApplication.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpApplication.Name = "tpApplication";
            this.tpApplication.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpApplication.Size = new System.Drawing.Size(824, 536);
            this.tpApplication.TabIndex = 1;
            this.tpApplication.Text = "Application";
            this.tpApplication.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(237, 162);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(375, 28);
            this.cbLicenseClasses.TabIndex = 29;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_SE.Properties.Resources.License_Type_32;
            this.pictureBox8.Location = new System.Drawing.Point(199, 163);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 31;
            this.pictureBox8.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "License Class : ";
            // 
            // lbApplicatoinID
            // 
            this.lbApplicatoinID.AutoSize = true;
            this.lbApplicatoinID.Location = new System.Drawing.Point(237, 40);
            this.lbApplicatoinID.Name = "lbApplicatoinID";
            this.lbApplicatoinID.Size = new System.Drawing.Size(35, 20);
            this.lbApplicatoinID.TabIndex = 15;
            this.lbApplicatoinID.Text = "N/A";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_SE.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(199, 36);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "D.L. Application ID :";
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Location = new System.Drawing.Point(237, 103);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(35, 20);
            this.lbApplicationDate.TabIndex = 12;
            this.lbApplicationDate.Text = "N/A";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_SE.Properties.Resources.Calendar_32;
            this.pictureBox3.Location = new System.Drawing.Point(199, 99);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Application Date : ";
            // 
            // lbApplicationFees
            // 
            this.lbApplicationFees.AutoSize = true;
            this.lbApplicationFees.Location = new System.Drawing.Point(237, 233);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(35, 20);
            this.lbApplicationFees.TabIndex = 9;
            this.lbApplicationFees.Text = "N/A";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_SE.Properties.Resources.money_32;
            this.pictureBox2.Location = new System.Drawing.Point(199, 229);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Application Fees : ";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Location = new System.Drawing.Point(237, 293);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(35, 20);
            this.lbCreatedBy.TabIndex = 6;
            this.lbCreatedBy.Text = "N/A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_SE.Properties.Resources.Man_32;
            this.pictureBox1.Location = new System.Drawing.Point(199, 289);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Created By : ";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(75, 51);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(589, 39);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "Add Local Driving License Application";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Enabled = false;
            this.btnClose.Image = global::DVLD_SE.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(578, 737);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 58);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::DVLD_SE.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(716, 737);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 58);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddEditLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 809);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcApplication);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddEditLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Local Driving License Application";
            this.Load += new System.EventHandler(this.frmAddEditLocalDrivingLicenseApplication_Load);
            this.tcApplication.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpApplication.ResumeLayout(false);
            this.tpApplication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcApplication;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitle;
        private People.Controls.ctrlPersonFilterCard ctrlPersonFilterCard1;
        private System.Windows.Forms.Label lbApplicatoinID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnNext;
    }
}