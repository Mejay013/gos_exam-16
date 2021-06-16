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
            InitializeComponent(); // инициализируем компоненты ( загружается форма) 
            db db = new db(); // создаем обьект бд
            admin_email = email;
            List<string[]> all_offices = db.get_offices(); // создаем список названий, всех офисов,полученных из бд
            foreach (string[] s in all_offices) // перебираем список
            {
                comboBox_offices.Items.Add(s[0]); // вносим название офиса в выпадающий список
            }
        }

        private void button_save_Click(object sender, EventArgs e) //при нажатии кнопки сохранить
        {
            db db = new db(); // создаем обьект бд

            string email = textBox_email.Text; // получем емаил
            string name = textBox_name.Text; // поолучаем имя
            string last_name = textBox_last_name.Text; // получаем фамилию
            string office = comboBox_offices.Text; // получаем офис
            string birthdate = dateTimePicker1.Text.ToLower(); // получаем текстом дату переводя в нижний регистр
            DateTime user_birthdate = DateTime.Parse(birthdate); // делаем из даты в виде строки дату в виде обьекта DateTime языка C# ( нужно для корректного внесения в БД)
            string password = textBox_password.Text; // получаем пароль
            if(check_add_user_valid(email, name, last_name, office, birthdate, password))
            {
                db.create_new_user(email, name, last_name, office, user_birthdate, password); // создаем нового пользователя передавая все полученные параметры
                MessageBox.Show("Пользователь добавлен"); // выводим сообщение о том
                this.Close(); // закрываем окно
                AdminForm admin = new AdminForm(admin_email); // создаем обьект панель админа
                admin.Show(); // выводим панель админа
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
        private void button_close_Click(object sender, EventArgs e)// при нажатии кнопки закрыть 
        {
            this.Close(); // закрываем окно
            AdminForm admin = new AdminForm(admin_email); // создаем обьект панель админа
            admin.Show(); // выводим панель админа
        }
    }
}
