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
    
    public partial class DiagnosForm : Form
    {
        int last_login_id;
        string user_email;
        public DiagnosForm(string email)
        {
            InitializeComponent();
            richTextBox1.Enabled = false;
            db db = new db();
            user_email = email;
            last_login_id = int.Parse(db.get_max_logs_user_id(user_email)[0][0]);
          
            DateTime login_time = DateTime.Parse(db.get_logs_login_time(last_login_id)[0][0].Replace(".", "/"));

            string login_date = login_time.ToString("d", DateTimeFormatInfo.InvariantInfo);
            string login_times = login_time.ToString("t", DateTimeFormatInfo.InvariantInfo);
            label1.Text = string.Format("No logout detected on u last login {0} at {1}", login_date, login_times);


            
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            db db = new db();

            //string reason_text = richTextBox1.Text;
            string note ="";
            if (radioButton_software.Enabled)
            {
                note = "Software Crash";
            }
            if(radioButton_system.Enabled)
            {
                note = "System Crash";
            }

            if (db.set_status_error_logut(last_login_id, note))
            {
                MessageBox.Show("Причина ошибки добавлена");
            }

            if (db.get_user_role(user_email)[0][0] == "1") // если роль пользователя - администратор
            {
                this.Hide(); // скрываем окно
                AdminForm adminform = new AdminForm(user_email); // создаем обьект панели админа
                adminform.Show(); // показываем панель админа
            }
            else // если роль пользователя - пользователь
            {

                UserForm user = new UserForm(user_email);
                user.Show();
                this.Hide(); // скрываем окно
            }
        }
    }
}
