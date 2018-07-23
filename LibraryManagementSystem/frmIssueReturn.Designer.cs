namespace LibraryManagementSystem
{
    partial class frmIssueReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvIssueReturn = new System.Windows.Forms.DataGridView();
            this.btnIssueReturn = new System.Windows.Forms.Button();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIssueReturn
            // 
            this.dgvIssueReturn.AllowUserToAddRows = false;
            this.dgvIssueReturn.AllowUserToDeleteRows = false;
            this.dgvIssueReturn.AllowUserToResizeRows = false;
            this.dgvIssueReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIssueReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIssueReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIssueReturn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIssueReturn.Location = new System.Drawing.Point(12, 12);
            this.dgvIssueReturn.Name = "dgvIssueReturn";
            this.dgvIssueReturn.ReadOnly = true;
            this.dgvIssueReturn.RowHeadersVisible = false;
            this.dgvIssueReturn.Size = new System.Drawing.Size(1150, 306);
            this.dgvIssueReturn.TabIndex = 0;
            this.dgvIssueReturn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssue_CellClick);
            // 
            // btnIssueReturn
            // 
            this.btnIssueReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReturn.Location = new System.Drawing.Point(446, 345);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(290, 62);
            this.btnIssueReturn.TabIndex = 1;
            this.btnIssueReturn.Text = "Issue Book";
            this.btnIssueReturn.UseVisualStyleBackColor = true;
            this.btnIssueReturn.Click += new System.EventHandler(this.btnIssueReturn_Click);
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.Location = new System.Drawing.Point(774, 356);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(162, 31);
            this.lblStudentID.TabIndex = 2;
            this.lblStudentID.Text = "Student ID:";
            this.lblStudentID.Visible = false;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(942, 353);
            this.txtStudentID.Mask = "000000";
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(220, 38);
            this.txtStudentID.TabIndex = 3;
            this.txtStudentID.ValidatingType = typeof(int);
            this.txtStudentID.Visible = false;
            // 
            // frmIssueReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 450);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.btnIssueReturn);
            this.Controls.Add(this.dgvIssueReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmIssueReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue a Book";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIssueReturn_FormClosing);
            this.Load += new System.EventHandler(this.frmIssue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssueReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIssueReturn;
        private System.Windows.Forms.Button btnIssueReturn;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.MaskedTextBox txtStudentID;
    }
}