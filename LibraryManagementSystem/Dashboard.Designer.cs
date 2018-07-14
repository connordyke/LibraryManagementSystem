namespace LibraryManagementSystem
{
    partial class Dashboard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.btnStudentSearch = new System.Windows.Forms.Button();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.btnUnavailable = new System.Windows.Forms.Button();
            this.btnAvail = new System.Windows.Forms.Button();
            this.btnBookSeach = new System.Windows.Forms.Button();
            this.btnStudenBorrow = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabBooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStudents);
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.btnStudenBorrow);
            this.tabStudents.Controls.Add(this.btnStudentSearch);
            this.tabStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStudents.Location = new System.Drawing.Point(4, 33);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Size = new System.Drawing.Size(767, 388);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Student Information";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // btnStudentSearch
            // 
            this.btnStudentSearch.Location = new System.Drawing.Point(22, 21);
            this.btnStudentSearch.Name = "btnStudentSearch";
            this.btnStudentSearch.Size = new System.Drawing.Size(162, 54);
            this.btnStudentSearch.TabIndex = 0;
            this.btnStudentSearch.Text = "Student Search";
            this.btnStudentSearch.UseVisualStyleBackColor = true;
            this.btnStudentSearch.Click += new System.EventHandler(this.btnStudentSearch_Click);
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.btnUnavailable);
            this.tabBooks.Controls.Add(this.btnAvail);
            this.tabBooks.Controls.Add(this.btnBookSeach);
            this.tabBooks.Location = new System.Drawing.Point(4, 33);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Size = new System.Drawing.Size(767, 388);
            this.tabBooks.TabIndex = 1;
            this.tabBooks.Text = "Book Information";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // btnUnavailable
            // 
            this.btnUnavailable.Location = new System.Drawing.Point(408, 21);
            this.btnUnavailable.Name = "btnUnavailable";
            this.btnUnavailable.Size = new System.Drawing.Size(172, 54);
            this.btnUnavailable.TabIndex = 3;
            this.btnUnavailable.Text = "Unavailable Books";
            this.btnUnavailable.UseVisualStyleBackColor = true;
            // 
            // btnAvail
            // 
            this.btnAvail.Location = new System.Drawing.Point(214, 21);
            this.btnAvail.Name = "btnAvail";
            this.btnAvail.Size = new System.Drawing.Size(162, 54);
            this.btnAvail.TabIndex = 2;
            this.btnAvail.Text = "Available Books";
            this.btnAvail.UseVisualStyleBackColor = true;
            // 
            // btnBookSeach
            // 
            this.btnBookSeach.Location = new System.Drawing.Point(22, 21);
            this.btnBookSeach.Name = "btnBookSeach";
            this.btnBookSeach.Size = new System.Drawing.Size(162, 54);
            this.btnBookSeach.TabIndex = 1;
            this.btnBookSeach.Text = "Book Search";
            this.btnBookSeach.UseVisualStyleBackColor = true;
            this.btnBookSeach.Click += new System.EventHandler(this.btnBookSeach_Click);
            // 
            // btnStudenBorrow
            // 
            this.btnStudenBorrow.Location = new System.Drawing.Point(214, 21);
            this.btnStudenBorrow.Name = "btnStudenBorrow";
            this.btnStudenBorrow.Size = new System.Drawing.Size(162, 54);
            this.btnStudenBorrow.TabIndex = 1;
            this.btnStudenBorrow.Text = "Student";
            this.btnStudenBorrow.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(557, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(2, 22);
            this.lblName.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 472);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xxx Library Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.Button btnStudentSearch;
        private System.Windows.Forms.Button btnBookSeach;
        private System.Windows.Forms.Button btnUnavailable;
        private System.Windows.Forms.Button btnAvail;
        private System.Windows.Forms.Button btnStudenBorrow;
        private System.Windows.Forms.Label lblName;
    }
}