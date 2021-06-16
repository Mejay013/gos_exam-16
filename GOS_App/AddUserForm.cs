using MySql.Data.MySqlClient;
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
    public partial class AddUserForm : Form
    {
        string admin_email;
        public AddUserForm(string email)
        {
            InitializeComponent();  
            db db = new db(); 
            admin_email = email;
            List<string[]> all_offices = db.get_offices(); 
            foreach (string[] s in all_offices)
            {
                comboBox_offices.Items.Add(s[0]); 
            }
        }

        private void button_save_Click(object sender, EventArgs e) 
        {
            db db = new db(); 

            string email = textBox_email.Text; 
            string name = textBox_name.Text; 
            string last_name = textBox_last_name.Text; 
            string office = comboBox_offices.Text; 
            string birthdate = dateTimePicker1.Text.ToLower(); 
            DateTime user_birthdate = DateTime.Parse(birthdate); 
            string password = textBox_password.Text; 
            if(check_add_user_valid(email, name, last_name, office, birthdate, password))
            {
                db.create_new_user(email, name, last_name, office, user_birthdate, password);
                MessageBox.Show("Пользователь добавлен"); 
                this.Close(); 
                AdminForm admin = new AdminForm(admin_email); 
                admin.Show(); 
                DateTime time_login = DateTime.Now;
                db.add_log_login(time_login, email);
            }
            else
            {
                MessageBox.Show("Некоторые поля не заполнены");
            }

            

        }
        public bool check_add_user_valid(string email, string name, string last_name, string office, string birthdate, string password)
        {
            if (email == "" || name == "" || last_name == "" || office == "" || birthdate == "" || password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button_close_Click(object sender, EventArgs e) 
        {
            this.Close(); 
            AdminForm admin = new AdminForm(admin_email); 
            admin.Show();
        }
    }
}
