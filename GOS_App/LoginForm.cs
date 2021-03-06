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
    public partial class LoginForm : Form
    {
        int value_errors = 0;
        int seconds_waiting = 10;
        public LoginForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button_login_Click(object sender, EventArgs e) // если нажата кнопка Login
        {

            db db = new db(); // создаем новый обьект класс  db( класс для работы с базой данных) 


            string username = textBox_username.Text.ToLower(); // получаем почту
            string password = textBox_password.Text.ToLower(); // получаем пароль

            if (check_valid(username, password)){ // если сообщения не пустые
                if (db.find_in_db(username, password)) // если пользователь найден в базе данных и данные совпадают
                {
                    if (db.get_user_block(username)[0][0] == "True") // если пользователь не заблокирован
                    {
                        if (check_user_last_logout_correct(username))
                        {
                            if (db.get_user_role(username)[0][0] == "1") // если роль пользователя - администратор
                            {
                                this.Hide(); // скрываем окно
                                AdminForm adminform = new AdminForm(username); // создаем обьект панели админа
                                adminform.Show(); // показываем панель админа
                            }
                            else // если роль пользователя - пользователь
                            {

                                UserForm user = new UserForm(username);
                                user.Show();
                                this.Hide(); // скрываем окно
                            }
                        }
                        else
                        {
                            this.Hide();
                            DiagnosForm diagnos = new DiagnosForm(username);
                            diagnos.Show();
                        }
                       
                        
                    }
                    else // если пользователь заблокирован
                    {
                        show_message("Пользователь заблокирован");
                    }
                 
                }
                else // если пользователя нет в БД
                {
                    show_message("Пользователь не найден");
                    value_errors += 1;
                }
            }
            else // если какое то поле пустое
            {
                show_message("Данные введены некорректно");
                value_errors += 1;
            }


        }

        public void show_message(string message) //  функция вывода сообщение с параметром - текст сообщения
        {
            MessageBox.Show(message); // выводим текст сообщения
        }
        private void button_exit_Click(object sender, EventArgs e) // если нажата кнопка закрыть окно
        {
            this.Close(); // закрываем окно
        }

        public bool check_valid(string username,string password) // проверка на пустоту true - поля корректны, false - одно из полей некорректно
        {
            if( username == ""){ // если поле емаил пустое
                return false;
            }
            else // если поле емаил не пустое
            {
                if (password == "") // если поле пароль пустое
                {
                    return false;
                }
                else // если поле пароль не пустое
                {
                    return true;
                }
            }
        }
        public bool check_user_last_logout_correct(string email)
        {
            db db = new db();
            int last_login_id = int.Parse(db.get_max_logs_user_id(email)[0][0]);

            try
            {
                DateTime logout_time = DateTime.Parse(db.get_logs_logout_time(last_login_id)[0][0].Replace(".", "/"));
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ( value_errors == 3 )
            {
                label_waiting.Text = string.Format("Слишком много неправильных вводов,ожидайте {0} секунд", seconds_waiting);
                textBox_username.Enabled = false;
                textBox_password.Enabled = false;
                if (seconds_waiting < 1)
                {
                    label_waiting.Text = "";
                    textBox_username.Enabled = true;
                    textBox_password.Enabled = true;
                    value_errors = 0;
                    seconds_waiting = 10;
                }
                else
                {
                    seconds_waiting -= 1;
                }
            }

        }
    }
}
