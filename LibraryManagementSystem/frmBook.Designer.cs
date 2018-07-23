namespace LibraryManagementSystem
{
    partial class frmBook
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
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBinding = new System.Windows.Forms.ComboBox();
            this.nudCopies = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpPubYear = new System.Windows.Forms.DateTimePicker();
            this.cmbFloorNo = new System.Windows.Forms.ComboBox();
            this.cmbShelfNo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // txtISBN
            // 
            this.txtISBN.Enabled = false;
            this.txtISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISBN.Location = new System.Drawing.Point(229, 23);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.ShortcutsEnabled = false;
            this.txtISBN.Size = new System.Drawing.Size(199, 26);
            this.txtISBN.TabIndex = 21;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(226, 502);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(203, 48);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit Book Information";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.Location = new System.Drawing.Point(227, 275);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 28);
            this.cmbCategory.TabIndex = 17;
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLang.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbLang.Location = new System.Drawing.Point(229, 120);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(200, 28);
            this.cmbLang.TabIndex = 13;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(229, 70);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 26);
            this.txtTitle.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 444);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Shelf Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(107, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Category:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Language:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Publication Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Book Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "ISBN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(58, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Binding Name:";
            // 
            // cmbBinding
            // 
            this.cmbBinding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBinding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBinding.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbBinding.Location = new System.Drawing.Point(229, 170);
            this.cmbBinding.Name = "cmbBinding";
            this.cmbBinding.Size = new System.Drawing.Size(200, 28);
            this.cmbBinding.TabIndex = 24;
            // 
            // nudCopies
            // 
            this.nudCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCopies.Location = new System.Drawing.Point(229, 223);
            this.nudCopies.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopies.Name = "nudCopies";
            this.nudCopies.Size = new System.Drawing.Size(200, 26);
            this.nudCopies.TabIndex = 26;
            this.nudCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Number of Copies:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(60, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Floor Number:";
            // 
            // dtpPubYear
            // 
            this.dtpPubYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPubYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPubYear.Location = new System.Drawing.Point(227, 331);
            this.dtpPubYear.Name = "dtpPubYear";
            this.dtpPubYear.Size = new System.Drawing.Size(200, 26);
            this.dtpPubYear.TabIndex = 29;
            this.dtpPubYear.ValueChanged += new System.EventHandler(this.dtpPubYear_ValueChanged);
            // 
            // cmbFloorNo
            // 
            this.cmbFloorNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloorNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFloorNo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbFloorNo.Location = new System.Drawing.Point(228, 389);
            this.cmbFloorNo.Name = "cmbFloorNo";
            this.cmbFloorNo.Size = new System.Drawing.Size(200, 28);
            this.cmbFloorNo.TabIndex = 30;
            this.cmbFloorNo.SelectedIndexChanged += new System.EventHandler(this.cmbFloorNo_SelectedIndexChanged);
            // 
            // cmbShelfNo
            // 
            this.cmbShelfNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShelfNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShelfNo.Location = new System.Drawing.Point(226, 444);
            this.cmbShelfNo.Name = "cmbShelfNo";
            this.cmbShelfNo.Size = new System.Drawing.Size(200, 28);
            this.cmbShelfNo.TabIndex = 31;
            // 
            // frmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 610);
            this.Controls.Add(this.cmbShelfNo);
            this.Controls.Add(this.cmbFloorNo);
            this.Controls.Add(this.dtpPubYear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudCopies);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbBinding);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbLang);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a New Book";
            this.Load += new System.EventHandler(this.frmBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBinding;
        private System.Windows.Forms.NumericUpDown nudCopies;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpPubYear;
        private System.Windows.Forms.ComboBox cmbFloorNo;
        private System.Windows.Forms.ComboBox cmbShelfNo;
    }
}