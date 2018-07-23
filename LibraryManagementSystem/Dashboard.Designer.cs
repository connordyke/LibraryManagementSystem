namespace LibraryManagementSystem
{
    partial class frmDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabDashboard = new System.Windows.Forms.TabControl();
            this.tabDash = new System.Windows.Forms.TabPage();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.MaskedTextBox();
            this.lblEditStudent = new System.Windows.Forms.LinkLabel();
            this.lblNumRecords = new System.Windows.Forms.Label();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.btnClearStudent = new System.Windows.Forms.Button();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.btnSearchStudent = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.lblEditBook = new System.Windows.Forms.LinkLabel();
            this.dtpPubYear = new System.Windows.Forms.DateTimePicker();
            this.lblNumBooks = new System.Windows.Forms.Label();
            this.cmbOutOfStock = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearBook = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.txtISBN = new System.Windows.Forms.MaskedTextBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.tabDashboard.SuspendLayout();
            this.tabDash.SuspendLayout();
            this.tabStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.tabDash);
            this.tabDashboard.Controls.Add(this.tabStudents);
            this.tabDashboard.Controls.Add(this.tabBooks);
            this.tabDashboard.Controls.Add(this.tabAdmin);
            this.tabDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDashboard.Location = new System.Drawing.Point(12, 12);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.SelectedIndex = 0;
            this.tabDashboard.Size = new System.Drawing.Size(1089, 528);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.SelectedIndexChanged += new System.EventHandler(this.tabDashboard_SelectedIndexChanged);
            // 
            // tabDash
            // 
            this.tabDash.Controls.Add(this.btnAddBook);
            this.tabDash.Controls.Add(this.btnSignUp);
            this.tabDash.Controls.Add(this.lblName);
            this.tabDash.Location = new System.Drawing.Point(4, 33);
            this.tabDash.Name = "tabDash";
            this.tabDash.Size = new System.Drawing.Size(1081, 491);
            this.tabDash.TabIndex = 2;
            this.tabDash.Text = "Dashboard";
            this.tabDash.UseVisualStyleBackColor = true;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(45, 45);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(217, 58);
            this.btnSignUp.TabIndex = 2;
            this.btnSignUp.Text = "Sign Up New Student";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(794, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(2, 22);
            this.lblName.TabIndex = 1;
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.dtpDOB);
            this.tabStudents.Controls.Add(this.txtID);
            this.tabStudents.Controls.Add(this.lblEditStudent);
            this.tabStudents.Controls.Add(this.lblNumRecords);
            this.tabStudents.Controls.Add(this.dgvStudent);
            this.tabStudents.Controls.Add(this.btnClearStudent);
            this.tabStudents.Controls.Add(this.cmbGender);
            this.tabStudents.Controls.Add(this.btnSearchStudent);
            this.tabStudents.Controls.Add(this.cmbDepartment);
            this.tabStudents.Controls.Add(this.txtName);
            this.tabStudents.Controls.Add(this.label5);
            this.tabStudents.Controls.Add(this.label4);
            this.tabStudents.Controls.Add(this.label3);
            this.tabStudents.Controls.Add(this.label2);
            this.tabStudents.Controls.Add(this.label1);
            this.tabStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStudents.Location = new System.Drawing.Point(4, 33);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Size = new System.Drawing.Size(1081, 491);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Search Students";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(567, 33);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 26);
            this.dtpDOB.TabIndex = 34;
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(24, 35);
            this.txtID.Mask = "000000";
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(164, 26);
            this.txtID.TabIndex = 1;
            this.txtID.ValidatingType = typeof(int);
            // 
            // lblEditStudent
            // 
            this.lblEditStudent.AutoSize = true;
            this.lblEditStudent.Enabled = false;
            this.lblEditStudent.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblEditStudent.Location = new System.Drawing.Point(816, 132);
            this.lblEditStudent.Name = "lblEditStudent";
            this.lblEditStudent.Size = new System.Drawing.Size(139, 24);
            this.lblEditStudent.TabIndex = 33;
            this.lblEditStudent.TabStop = true;
            this.lblEditStudent.Text = "Edit Information";
            this.lblEditStudent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditStudent_LinkClicked);
            // 
            // lblNumRecords
            // 
            this.lblNumRecords.AutoSize = true;
            this.lblNumRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecords.Location = new System.Drawing.Point(104, 130);
            this.lblNumRecords.Name = "lblNumRecords";
            this.lblNumRecords.Size = new System.Drawing.Size(0, 20);
            this.lblNumRecords.TabIndex = 32;
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AllowUserToOrderColumns = true;
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvStudent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudent.Location = new System.Drawing.Point(108, 159);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.RowHeadersVisible = false;
            this.dgvStudent.Size = new System.Drawing.Size(847, 303);
            this.dgvStudent.TabIndex = 31;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            // 
            // btnClearStudent
            // 
            this.btnClearStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearStudent.Location = new System.Drawing.Point(544, 86);
            this.btnClearStudent.Name = "btnClearStudent";
            this.btnClearStudent.Size = new System.Drawing.Size(143, 47);
            this.btnClearStudent.TabIndex = 7;
            this.btnClearStudent.Text = "&Clear";
            this.btnClearStudent.UseVisualStyleBackColor = true;
            this.btnClearStudent.Click += new System.EventHandler(this.btnClearStudent_Click);
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(399, 33);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(117, 28);
            this.cmbGender.TabIndex = 3;
            // 
            // btnSearchStudent
            // 
            this.btnSearchStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchStudent.Location = new System.Drawing.Point(373, 86);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(143, 47);
            this.btnSearchStudent.TabIndex = 6;
            this.btnSearchStudent.Text = "&Search";
            this.btnSearchStudent.UseVisualStyleBackColor = true;
            this.btnSearchStudent.Click += new System.EventHandler(this.btnSearchStudent_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(804, 36);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(192, 28);
            this.cmbDepartment.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(217, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 26);
            this.txtName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(800, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Department:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(563, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Date of Birth:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Gender:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Student Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Student ID:";
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.txtISBN);
            this.tabBooks.Controls.Add(this.lblEditBook);
            this.tabBooks.Controls.Add(this.dtpPubYear);
            this.tabBooks.Controls.Add(this.lblNumBooks);
            this.tabBooks.Controls.Add(this.cmbOutOfStock);
            this.tabBooks.Controls.Add(this.label7);
            this.tabBooks.Controls.Add(this.btnClearBook);
            this.tabBooks.Controls.Add(this.cmbCategory);
            this.tabBooks.Controls.Add(this.label8);
            this.tabBooks.Controls.Add(this.cmbLang);
            this.tabBooks.Controls.Add(this.btnSearchBook);
            this.tabBooks.Controls.Add(this.txtTitle);
            this.tabBooks.Controls.Add(this.label9);
            this.tabBooks.Controls.Add(this.label10);
            this.tabBooks.Controls.Add(this.label11);
            this.tabBooks.Controls.Add(this.label12);
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 33);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Size = new System.Drawing.Size(1081, 491);
            this.tabBooks.TabIndex = 1;
            this.tabBooks.Text = "Search Books";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // lblEditBook
            // 
            this.lblEditBook.AutoSize = true;
            this.lblEditBook.Enabled = false;
            this.lblEditBook.LinkColor = System.Drawing.Color.RoyalBlue;
            this.lblEditBook.Location = new System.Drawing.Point(939, 125);
            this.lblEditBook.Name = "lblEditBook";
            this.lblEditBook.Size = new System.Drawing.Size(139, 24);
            this.lblEditBook.TabIndex = 51;
            this.lblEditBook.TabStop = true;
            this.lblEditBook.Text = "Edit Information";
            this.lblEditBook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditBook_LinkClicked);
            // 
            // dtpPubYear
            // 
            this.dtpPubYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPubYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPubYear.Location = new System.Drawing.Point(480, 35);
            this.dtpPubYear.Name = "dtpPubYear";
            this.dtpPubYear.Size = new System.Drawing.Size(188, 26);
            this.dtpPubYear.TabIndex = 50;
            this.dtpPubYear.ValueChanged += new System.EventHandler(this.dtpPubYear_ValueChanged);
            // 
            // lblNumBooks
            // 
            this.lblNumBooks.AutoSize = true;
            this.lblNumBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumBooks.Location = new System.Drawing.Point(5, 129);
            this.lblNumBooks.Name = "lblNumBooks";
            this.lblNumBooks.Size = new System.Drawing.Size(0, 20);
            this.lblNumBooks.TabIndex = 49;
            // 
            // cmbOutOfStock
            // 
            this.cmbOutOfStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutOfStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutOfStock.FormattingEnabled = true;
            this.cmbOutOfStock.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbOutOfStock.Location = new System.Drawing.Point(868, 33);
            this.cmbOutOfStock.Name = "cmbOutOfStock";
            this.cmbOutOfStock.Size = new System.Drawing.Size(170, 28);
            this.cmbOutOfStock.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(864, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Out Of Stock:";
            // 
            // btnClearBook
            // 
            this.btnClearBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBook.Location = new System.Drawing.Point(544, 86);
            this.btnClearBook.Name = "btnClearBook";
            this.btnClearBook.Size = new System.Drawing.Size(143, 47);
            this.btnClearBook.TabIndex = 46;
            this.btnClearBook.Text = "&Clear";
            this.btnClearBook.UseVisualStyleBackColor = true;
            this.btnClearBook.Click += new System.EventHandler(this.btnClearBook_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(686, 33);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(170, 28);
            this.cmbCategory.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(682, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "Category:";
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(342, 35);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(117, 28);
            this.cmbLang.TabIndex = 43;
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBook.Location = new System.Drawing.Point(373, 86);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(143, 47);
            this.btnSearchBook.TabIndex = 42;
            this.btnSearchBook.Text = "&Search";
            this.btnSearchBook.UseVisualStyleBackColor = true;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(184, 35);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(143, 26);
            this.txtTitle.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(476, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Publication Year:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(338, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "Language:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(189, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Book Title:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "ISBN:";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AllowUserToOrderColumns = true;
            this.dgvBooks.AllowUserToResizeColumns = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBooks.Location = new System.Drawing.Point(0, 152);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvBooks.Size = new System.Drawing.Size(1078, 303);
            this.dgvBooks.TabIndex = 35;
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Location = new System.Drawing.Point(4, 33);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Size = new System.Drawing.Size(1081, 491);
            this.tabAdmin.TabIndex = 3;
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // txtISBN
            // 
            this.txtISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISBN.Location = new System.Drawing.Point(24, 35);
            this.txtISBN.Mask = "000000";
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(139, 26);
            this.txtISBN.TabIndex = 52;
            this.txtISBN.ValidatingType = typeof(int);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(45, 119);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(217, 58);
            this.btnAddBook.TabIndex = 3;
            this.btnAddBook.Text = "Add New Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 551);
            this.Controls.Add(this.tabDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xxx Library Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.tabDashboard.ResumeLayout(false);
            this.tabDash.ResumeLayout(false);
            this.tabDash.PerformLayout();
            this.tabStudents.ResumeLayout(false);
            this.tabStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDashboard;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNumRecords;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Button btnClearStudent;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnSearchStudent;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabDash;
        private System.Windows.Forms.DateTimePicker dtpPubYear;
        private System.Windows.Forms.Label lblNumBooks;
        private System.Windows.Forms.ComboBox cmbOutOfStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClearBook;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.LinkLabel lblEditBook;
        private System.Windows.Forms.LinkLabel lblEditStudent;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.MaskedTextBox txtID;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.ToolTip tipEdit;
        private System.Windows.Forms.MaskedTextBox txtISBN;
        private System.Windows.Forms.Button btnAddBook;
    }
}