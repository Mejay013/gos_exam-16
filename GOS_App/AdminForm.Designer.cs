
namespace GOS_App
{
    partial class AdminForm
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
            this.strip_add_user = new System.Windows.Forms.ToolStripLabel();
            this.strip_exit = new System.Windows.Forms.ToolStripLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_last_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_office = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_change_role = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_count_online = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label_was_online = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_add_user,
            this.strip_exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // strip_add_user
            // 
            this.strip_add_user.Name = "strip_add_user";
            this.strip_add_user.Size = new System.Drawing.Size(54, 22);
            this.strip_add_user.Text = "Add user";
            this.strip_add_user.Click += new System.EventHandler(this.strip_add_user_Click);
            // 
            // strip_exit
            // 
            this.strip_exit.Name = "strip_exit";
            this.strip_exit.Size = new System.Drawing.Size(26, 22);
            this.strip_exit.Text = "Exit";
            this.strip_exit.Click += new System.EventHandler(this.strip_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Office:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_name,
            this.column_last_name,
            this.column_age,
            this.column_role,
            this.column_email,
            this.column_office});
            this.dataGridView1.Location = new System.Drawing.Point(0, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(876, 338);
            this.dataGridView1.TabIndex = 2;
            // 
            // column_name
            // 
            this.column_name.HeaderText = "Name";
            this.column_name.Name = "column_name";
            // 
            // column_last_name
            // 
            this.column_last_name.HeaderText = "Last Name";
            this.column_last_name.Name = "column_last_name";
            // 
            // column_age
            // 
            this.column_age.HeaderText = "Age";
            this.column_age.Name = "column_age";
            // 
            // column_role
            // 
            this.column_role.HeaderText = "User role";
            this.column_role.Name = "column_role";
            // 
            // column_email
            // 
            this.column_email.HeaderText = "Email Address";
            this.column_email.Name = "column_email";
            // 
            // column_office
            // 
            this.column_office.HeaderText = "Office";
            this.column_office.Name = "column_office";
            // 
            // button_change_role
            // 
            this.button_change_role.Location = new System.Drawing.Point(15, 476);
            this.button_change_role.Name = "button_change_role";
            this.button_change_role.Size = new System.Drawing.Size(108, 23);
            this.button_change_role.TabIndex = 3;
            this.button_change_role.Text = "Change Role";
            this.button_change_role.UseVisualStyleBackColor = true;
            this.button_change_role.Click += new System.EventHandler(this.button_change_role_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 476);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Enable/Disable Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(684, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Count online:";
            // 
            // label_count_online
            // 
            this.label_count_online.AutoSize = true;
            this.label_count_online.Location = new System.Drawing.Point(759, 12);
            this.label_count_online.Name = "label_count_online";
            this.label_count_online.Size = new System.Drawing.Size(0, 13);
            this.label_count_online.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Count was online last hour:";
            // 
            // label_was_online
            // 
            this.label_was_online.AutoSize = true;
            this.label_was_online.Location = new System.Drawing.Point(824, 32);
            this.label_was_online.Name = "label_was_online";
            this.label_was_online.Size = new System.Drawing.Size(0, 13);
            this.label_was_online.TabIndex = 9;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 511);
            this.Controls.Add(this.label_was_online);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_count_online);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_change_role);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(892, 550);
            this.MinimumSize = new System.Drawing.Size(892, 550);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel strip_add_user;
        private System.Windows.Forms.ToolStripLabel strip_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_last_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_age;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_role;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_office;
        private System.Windows.Forms.Button button_change_role;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_count_online;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_was_online;
    }
}