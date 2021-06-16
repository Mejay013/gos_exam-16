using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS_App
{
    public partial class EditRoleForm : Form
    {
        string select_email; 
        string admin_email;
        public EditRoleForm(string email,string qs)
        {
           
            InitializeComponent();
            db db = new db(); 

            select_email = qs; 
            admin_email = email;
            List<string[]> all_user_data = db.load_users_value(select_email); 

            List<string[]> all_offices = db.get_offices(); 
            foreach (string[] s in all_offices) 
            {
                comboBox1.Items.Add(s[0]);
            }

            foreach (string[] s in all_user_data) 
            {

                textBox_email.Text = s[0]; 
                textBox_name.Text = s[1];
                textBox_last_name.Text = s[2];
                comboBox1.Text = s[3];  
                if (s[4].ToString() == "1")
                {
                    radioButton_admin.Checked = true;
                }
                else 
                {
                    radioButton_user.Checked = true;
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e) { 

            db db = new db(); 
           
            string email = textBox_email.Text; 
            string name = textBox_name.Text;
            string lastname = textBox_last_name.Text;
            string office = comboBox1.Text;
            int roleid; 
            if (radioButton_admin.Checked) 
            {
                roleid = 1; 
            }
            else 
            {
                roleid = 2;
            }

            if(db.update_user(select_email, email, name, lastname, office, roleid)) 
            {
                MessageBox.Show("Изменения сохранены"); 
                AdminForm adminform = new AdminForm(admin_email); 
                adminform.Show(); 
                this.Hide(); 
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            this.Close(); 
            AdminForm admin = new AdminForm(admin_email);
            admin.Show(); 
        }
    }
}
