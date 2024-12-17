namespace DVLD_SE.Tests
{
    partial class frmScheduleTest
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
            this.ctrlTestSchedule1 = new DVLD_SE.Tests.Controls.ctrlTestSchedule();
            this.SuspendLayout();
            // 
            // ctrlTestSchedule1
            // 
            this.ctrlTestSchedule1.AutoSize = true;
            this.ctrlTestSchedule1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlTestSchedule1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ctrlTestSchedule1.Location = new System.Drawing.Point(14, 11);
            this.ctrlTestSchedule1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlTestSchedule1.Name = "ctrlTestSchedule1";
            this.ctrlTestSchedule1.Size = new System.Drawing.Size(616, 829);
            this.ctrlTestSchedule1.TabIndex = 0;
            this.ctrlTestSchedule1.TestTypeID = DVLD_Business.clsTestType.enTestType.VisionTest;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 845);
            this.Controls.Add(this.ctrlTestSchedule1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlTestSchedule ctrlTestSchedule1;
    }
}