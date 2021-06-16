using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOS_App
{
    public partial class AdminForm : Form
    {
        string user_email;
        int count_online_last_hour;
        public AdminForm(string email)
        {
            
            InitializeComponent();
            db db = new db(); 
            user_email = email;
            List<string[]> all_offices = db.get_offices(); 
            comboBox1.Text = "All offices"; 
            comboBox1.Items.Add("All offices"); 
            foreach (string[] s in all_offices) 
            {
                comboBox1.Items.Add(s[0]);
            }
            DateTime time_login = DateTime.Now;
            db.add_log_login(time_login, user_email);
  
            reload_panel();

        }

        private void strip_exit_Click(object sender, EventArgs e) 
        {
            db db = new db();
            DateTime time_logout = DateTime.Now;
            db.add_log_logout(time_logout,user_email);
            MessageBox.Show("Данные о выходе внесены");
            this.Close();
        }

        private void strip_add_user_Click(object sender, EventArgs e)
        {
            
            AddUserForm add_user_form = new AddUserForm(user_email); 
            add_user_form.Show(); 
            this.Hide(); 


        }

        private void button_change_role_Click(object sender, EventArgs e) 
        {
            string select_email = dataGridView1.CurrentCell.Value.ToString();
            EditRoleForm editformrole = new EditRoleForm(user_email,select_email);
            editformrole.Show();
            this.Close(); 

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {  
            db db = new db(); 
            
            reload_panel(comboBox1.Text);  
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            db db = new db(); 
            string new_block; 
            string select_email = dataGridView1.CurrentCell.Value.ToString(); 
            string office = comboBox1.Text; 

            string old_block = db.get_user_block(select_email)[0][0]; 
            if(old_block == "True") 
            {
                new_block = "0"; 
            }
            else 
            {
                new_block = "1"; 
            }
            
            if (db.change_user_role(select_email,int.Parse(new_block))) 
            {
                MessageBox.Show("Изменения сохранены"); 
                
            }

            reload_panel(office); 
        }
        public void reload_panel(string flg = "All offices") 
        {
            db db = new db();

            dataGridView1.Rows.Clear(); 

            List<string[]> all_users_data;

            if (flg == "All offices") 
            {
                all_users_data = db.admin_panel_load();

                foreach (string[] s in all_users_data)
                {
                    dataGridView1.Rows.Add(s); 
                }
            }
            else
            {
                all_users_data = db.changed_admin_panel_load(flg); 
                foreach (string[] s in all_users_data) 
                {
                    dataGridView1.Rows.Add(s);
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    Console.WriteLine(all_users_data[row.Index][6]); 
                }
                catch (ArgumentOutOfRangeException) 
                {
                    break; 
                }
                if ((all_users_data[row.Index][6]).ToString() == "False") 
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else 
                {
                    row.DefaultCellStyle.BackColor = Color.White; 
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            db db = new db();
            reload_count_online_last_hour();
            label_count_online.Text = db.get_count_online_users()[0][0];
        }


        public void reload_count_online_last_hour()
        {
            db db = new db();
            count_online_last_hour = 0;
            List<string[]> all_online_asers_last = db.get_online_logs_last_hour();
            foreach (string[] s in all_online_asers_last) // перебираем список
            {
                DateTime date_login = DateTime.Parse(s[1].Replace(".", "/"));
                TimeSpan span = new TimeSpan();
                if(DateTime.Now.Subtract(date_login).Hours < 1)
                {
                    count_online_last_hour += 1;
                }
            }
            label_was_online.Text = count_online_last_hour.ToString();

        }
        

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db db = new db();

            db.set_user_ofline(int.Parse(db.get_user_id(user_email)[0][0]));
        }
    }
}
