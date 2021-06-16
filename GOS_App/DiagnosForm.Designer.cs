
namespace GOS_App
{
    partial class DiagnosForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.radioButton_software = new System.Windows.Forms.RadioButton();
            this.radioButton_system = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(115, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No logout detected on u last login 06/07/2020 at 8:22";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reason:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(565, 235);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(419, 353);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 3;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // radioButton_software
            // 
            this.radioButton_software.AutoSize = true;
            this.radioButton_software.Location = new System.Drawing.Point(77, 356);
            this.radioButton_software.Name = "radioButton_software";
            this.radioButton_software.Size = new System.Drawing.Size(97, 17);
            this.radioButton_software.TabIndex = 4;
            this.radioButton_software.TabStop = true;
            this.radioButton_software.Text = "Software Crash";
            this.radioButton_software.UseVisualStyleBackColor = true;
            // 
            // radioButton_system
            // 
            this.radioButton_system.AutoSize = true;
            this.radioButton_system.Location = new System.Drawing.Point(236, 356);
            this.radioButton_system.Name = "radioButton_system";
            this.radioButton_system.Size = new System.Drawing.Size(89, 17);
            this.radioButton_system.TabIndex = 5;
            this.radioButton_system.TabStop = true;
            this.radioButton_system.Text = "System Crash";
            this.radioButton_system.UseVisualStyleBackColor = true;
            // 
            // DiagnosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 400);
            this.Controls.Add(this.radioButton_system);
            this.Controls.Add(this.radioButton_software);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(608, 439);
            this.MinimumSize = new System.Drawing.Size(608, 439);
            this.Name = "DiagnosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No logout detected";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.RadioButton radioButton_software;
        private System.Windows.Forms.RadioButton radioButton_system;
    }
}