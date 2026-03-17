
namespace TicketSystemDesktop
{
    partial class TicketDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.txtNewComment = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblAssignedTo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAssignTo = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelTicketInfo = new System.Windows.Forms.Panel();
            this.panelComments = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panelAdmin = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.panelTicketInfo.SuspendLayout();
            this.panelComments.SuspendLayout();
            this.panelHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panelAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket Info:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Tag = "";
            this.label2.Text = "Ticket Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Priority:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Created On:";
            // 
            // dgvComments
            // 
            this.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Location = new System.Drawing.Point(8, 24);
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.Size = new System.Drawing.Size(738, 76);
            this.dgvComments.TabIndex = 7;
            // 
            // btnAddComment
            // 
            this.btnAddComment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.Location = new System.Drawing.Point(322, 117);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(107, 28);
            this.btnAddComment.TabIndex = 8;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = false;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // txtNewComment
            // 
            this.txtNewComment.Location = new System.Drawing.Point(8, 105);
            this.txtNewComment.Multiline = true;
            this.txtNewComment.Name = "txtNewComment";
            this.txtNewComment.Size = new System.Drawing.Size(301, 42);
            this.txtNewComment.TabIndex = 9;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(563, 22);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(69, 24);
            this.btnSaveChanges.TabIndex = 10;
            this.btnSaveChanges.Text = "Save ";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(566, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Assigned To :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 61);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(260, 42);
            this.txtDescription.TabIndex = 12;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(429, 110);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(24, 13);
            this.lblPriority.TabIndex = 13;
            this.lblPriority.Text = "ans";
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Location = new System.Drawing.Point(93, 31);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(24, 13);
            this.lblTicketNumber.TabIndex = 14;
            this.lblTicketNumber.Text = "ans";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(235, 31);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(24, 13);
            this.lblSubject.TabIndex = 15;
            this.lblSubject.Text = "ans";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(72, 110);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(24, 13);
            this.lblCreatedDate.TabIndex = 16;
            this.lblCreatedDate.Text = "ans";
            // 
            // lblAssignedTo
            // 
            this.lblAssignedTo.AutoSize = true;
            this.lblAssignedTo.Location = new System.Drawing.Point(638, 110);
            this.lblAssignedTo.Name = "lblAssignedTo";
            this.lblAssignedTo.Size = new System.Drawing.Size(24, 13);
            this.lblAssignedTo.TabIndex = 17;
            this.lblAssignedTo.Text = "ans";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(257, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(24, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "ans";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Admin Action";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Assigned To:";
            // 
            // cmbAssignTo
            // 
            this.cmbAssignTo.FormattingEnabled = true;
            this.cmbAssignTo.Location = new System.Drawing.Point(79, 25);
            this.cmbAssignTo.Name = "cmbAssignTo";
            this.cmbAssignTo.Size = new System.Drawing.Size(185, 21);
            this.cmbAssignTo.TabIndex = 22;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Open",
            "In Progress",
            "Closed"});
            this.cmbStatus.Location = new System.Drawing.Point(370, 22);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(168, 21);
            this.cmbStatus.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Change Status:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-1, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Status History";
            // 
            // panelTicketInfo
            // 
            this.panelTicketInfo.AutoSize = true;
            this.panelTicketInfo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelTicketInfo.Controls.Add(this.label1);
            this.panelTicketInfo.Controls.Add(this.label2);
            this.panelTicketInfo.Controls.Add(this.lblTicketNumber);
            this.panelTicketInfo.Controls.Add(this.label3);
            this.panelTicketInfo.Controls.Add(this.lblSubject);
            this.panelTicketInfo.Controls.Add(this.label4);
            this.panelTicketInfo.Controls.Add(this.txtDescription);
            this.panelTicketInfo.Controls.Add(this.label5);
            this.panelTicketInfo.Controls.Add(this.lblStatus);
            this.panelTicketInfo.Controls.Add(this.lblPriority);
            this.panelTicketInfo.Controls.Add(this.label11);
            this.panelTicketInfo.Controls.Add(this.label6);
            this.panelTicketInfo.Controls.Add(this.lblAssignedTo);
            this.panelTicketInfo.Controls.Add(this.lblCreatedDate);
            this.panelTicketInfo.Controls.Add(this.label8);
            this.panelTicketInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTicketInfo.Location = new System.Drawing.Point(0, 0);
            this.panelTicketInfo.Name = "panelTicketInfo";
            this.panelTicketInfo.Size = new System.Drawing.Size(924, 123);
            this.panelTicketInfo.TabIndex = 27;
            // 
            // panelComments
            // 
            this.panelComments.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panelComments.Controls.Add(this.label7);
            this.panelComments.Controls.Add(this.dgvComments);
            this.panelComments.Controls.Add(this.txtNewComment);
            this.panelComments.Controls.Add(this.btnAddComment);
            this.panelComments.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelComments.Location = new System.Drawing.Point(0, 123);
            this.panelComments.Name = "panelComments";
            this.panelComments.Size = new System.Drawing.Size(924, 153);
            this.panelComments.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Comments";
            // 
            // panelHistory
            // 
            this.panelHistory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelHistory.Controls.Add(this.dgvHistory);
            this.panelHistory.Controls.Add(this.label13);
            this.panelHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistory.Location = new System.Drawing.Point(0, 333);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(924, 110);
            this.panelHistory.TabIndex = 10;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(8, 21);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.Size = new System.Drawing.Size(742, 77);
            this.dgvHistory.TabIndex = 27;
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelAdmin.Controls.Add(this.label9);
            this.panelAdmin.Controls.Add(this.label10);
            this.panelAdmin.Controls.Add(this.cmbAssignTo);
            this.panelAdmin.Controls.Add(this.label12);
            this.panelAdmin.Controls.Add(this.btnSaveChanges);
            this.panelAdmin.Controls.Add(this.cmbStatus);
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdmin.Location = new System.Drawing.Point(0, 276);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(924, 57);
            this.panelAdmin.TabIndex = 10;
            this.panelAdmin.Visible = false;
            // 
            // TicketDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 489);
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.panelComments);
            this.Controls.Add(this.panelTicketInfo);
            this.Name = "TicketDetailsForm";
            this.Text = "TicketDetailsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.panelTicketInfo.ResumeLayout(false);
            this.panelTicketInfo.PerformLayout();
            this.panelComments.ResumeLayout(false);
            this.panelComments.PerformLayout();
            this.panelHistory.ResumeLayout(false);
            this.panelHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.TextBox txtNewComment;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblAssignedTo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbAssignTo;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panelTicketInfo;
        private System.Windows.Forms.Panel panelComments;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelAdmin;
    }
}