namespace DVLD_SE.People.Controls
{
    partial class ctrlPersonFilterCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilterd = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.cbOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new DVLD_SE.People.Controls.ctrlPersonCard();
            this.gbFilterd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilterd
            // 
            this.gbFilterd.Controls.Add(this.btnAddPerson);
            this.gbFilterd.Controls.Add(this.btnFindPerson);
            this.gbFilterd.Controls.Add(this.tbFilterValue);
            this.gbFilterd.Controls.Add(this.cbOptions);
            this.gbFilterd.Controls.Add(this.label1);
            this.gbFilterd.Location = new System.Drawing.Point(4, 3);
            this.gbFilterd.Name = "gbFilterd";
            this.gbFilterd.Size = new System.Drawing.Size(794, 99);
            this.gbFilterd.TabIndex = 1;
            this.gbFilterd.TabStop = false;
            this.gbFilterd.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddPerson.Image = global::DVLD_SE.Properties.Resources.Add_Person_40;
            this.btnAddPerson.Location = new System.Drawing.Point(573, 27);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(64, 51);
            this.btnAddPerson.TabIndex = 5;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindPerson.Image = global::DVLD_SE.Properties.Resources.SearchPerson;
            this.btnFindPerson.Location = new System.Drawing.Point(498, 27);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(64, 51);
            this.btnFindPerson.TabIndex = 4;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Location = new System.Drawing.Point(303, 37);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(184, 30);
            this.tbFilterValue.TabIndex = 3;
            this.tbFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // cbOptions
            // 
            this.cbOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOptions.FormattingEnabled = true;
            this.cbOptions.Items.AddRange(new object[] {
            "Person ID",
            "National NO"});
            this.cbOptions.Location = new System.Drawing.Point(108, 36);
            this.cbOptions.Name = "cbOptions";
            this.cbOptions.Size = new System.Drawing.Size(184, 33);
            this.cbOptions.TabIndex = 2;
            this.cbOptions.SelectedIndexChanged += new System.EventHandler(this.cbOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By : ";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.AutoSize = true;
            this.ctrlPersonCard1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlPersonCard1.Location = new System.Drawing.Point(4, 110);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(794, 355);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // ctrlPersonFilterCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.gbFilterd);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlPersonFilterCard";
            this.Size = new System.Drawing.Size(802, 470);
            this.Load += new System.EventHandler(this.ctrlPersonFilterCard_Load);
            this.gbFilterd.ResumeLayout(false);
            this.gbFilterd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gbFilterd;
        private System.Windows.Forms.ComboBox cbOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Button btnAddPerson;
    }
}
