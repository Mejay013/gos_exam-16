
namespace GOS_App
{
    partial class UserForm
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_exit = new System.Windows.Forms.ToolStripLabel();
            this.label_welcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogoutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSpentOnSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unsuccessful_logout_reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_time = new System.Windows.Forms.Label();
            this.label_crash = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_current_time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(953, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel_exit
            // 
            this.toolStripLabel_exit.Name = "toolStripLabel_exit";
            this.toolStripLabel_exit.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabel_exit.Text = "Exit";
            this.toolStripLabel_exit.Click += new System.EventHandler(this.toolStripLabel_exit_Click);
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_welcome.Location = new System.Drawing.Point(30, 52);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(270, 18);
            this.label_welcome.TabIndex = 1;
            this.label_welcome.Text = "Hi name ,Welcome to AMONIC airlanes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(368, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time spent on system:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(665, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Number of crashes:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.LoginTime,
            this.LogoutTime,
            this.TimeSpentOnSystem,
            this.Unsuccessful_logout_reason});
            this.dataGridView1.Location = new System.Drawing.Point(33, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(886, 383);
            this.dataGridView1.TabIndex = 4;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // LoginTime
            // 
            this.LoginTime.HeaderText = "LoginTime";
            this.LoginTime.Name = "LoginTime";
            this.LoginTime.ReadOnly = true;
            // 
            // LogoutTime
            // 
            this.LogoutTime.HeaderText = "LogoutTime";
            this.LogoutTime.Name = "LogoutTime";
            this.LogoutTime.ReadOnly = true;
            // 
            // TimeSpentOnSystem
            // 
            this.TimeSpentOnSystem.HeaderText = "TimeSpentOnSystem";
            this.TimeSpentOnSystem.Name = "TimeSpentOnSystem";
            this.TimeSpentOnSystem.ReadOnly = true;
            // 
            // Unsuccessful_logout_reason
            // 
            this.Unsuccessful_logout_reason.HeaderText = "Unsuccessful_logout_reason";
            this.Unsuccessful_logout_reason.Name = "Unsuccessful_logout_reason";
            this.Unsuccessful_logout_reason.ReadOnly = true;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_time.Location = new System.Drawing.Point(532, 97);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(36, 18);
            this.label_time.TabIndex = 5;
            this.label_time.Text = "0:14";
            // 
            // label_crash
            // 
            this.label_crash.AutoSize = true;
            this.label_crash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_crash.Location = new System.Drawing.Point(810, 97);
            this.label_crash.Name = "label_crash";
            this.label_crash.Size = new System.Drawing.Size(16, 18);
            this.label_crash.TabIndex = 6;
            this.label_crash.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(752, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(733, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Current time:";
            // 
            // label_current_time
            // 
            this.label_current_time.AutoSize = true;
            this.label_current_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_current_time.Location = new System.Drawing.Point(832, 21);
            this.label_current_time.Name = "label_current_time";
            this.label_current_time.Size = new System.Drawing.Size(0, 18);
            this.label_current_time.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 546);
            this.Controls.Add(this.label_current_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_crash);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(969, 585);
            this.MinimumSize = new System.Drawing.Size(969, 585);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_exit;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogoutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSpentOnSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unsuccessful_logout_reason;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_crash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_current_time;
        private System.Windows.Forms.Timer timer1;
    }
}