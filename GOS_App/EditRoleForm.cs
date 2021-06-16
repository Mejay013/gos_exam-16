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
        string select_email; // получаем старую почту
        string admin_email;
        public EditRoleForm(string email,string qs)
        {
           
            InitializeComponent();
            db db = new db(); // создаем обьект бд

            select_email = qs; // получаем переданный в форму пароль ( когда администратор нажимает кнопку Change Role и выбирает пользователя,сюда передается email выбранного
            admin_email = email;
            List<string[]> all_user_data = db.load_users_value(select_email); // получаем все данные выбранного пользователя

            List<string[]> all_offices = db.get_offices(); // получаем список всех офисов
            foreach (string[] s in all_offices) // перебираем список офисов
            {
                comboBox1.Items.Add(s[0]); // добавляем название офиса в выпадающий список
            }

            foreach (string[] s in all_user_data) // перебираем список пользовательских данных
            {

                textBox_email.Text = s[0]; // устанавливаем в поле email значение email из бд
                textBox_name.Text = s[1]; // устанавливаем в поле name значение first name из бд
                textBox_last_name.Text = s[2]; // устанавливаем в поле last name значение last name из бд
                comboBox1.Text = s[3];  // устанавливаем в выпадающий список office значение office из бд
                if (s[4].ToString() == "1") // если роль пользователя - администратор
                {
                    radioButton_admin.Checked = true; // ставим галочку на чекере админа ( что бы там сразу был кружок при входе)
                }
                else // если роль - пользователь 
                {
                    radioButton_user.Checked = true; // ставим галочку на чекере пользователя
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e) // если кнопка сохранить нажата
        {
            db db = new db(); // сохздаем обьект бд
            // ДАЛЕЕ ЕСЛИ ПОЛЬЗОВАТЕЛЬ НЕ ИЗМЕНИЛ ПОКАЗАТЕЛЬ,У НАС ОСТАНУТЬСЯ ТЕ ЖЕ САМЫЕ ДАННЫЕ,КОТОРЫЕ БЫЛИ В БД, ЕСЛИ ОН ИЗМЕНИЛ,ТО ДАННЫЕ ИЗМЕНЯТСЯ
            string email = textBox_email.Text; // получаем емеил
            string name = textBox_name.Text;// получаем имя
            string lastname = textBox_last_name.Text;// получаем фамилию
            string office = comboBox1.Text;// получаем офис
            int roleid; // создаем пустую переменную
            if (radioButton_admin.Checked) // если выбран чекер админа
            {
                roleid = 1; // роли присваивается значение 1 - админ
            }
            else // если выбран чекер пользователя
            {
                roleid = 2;// роли присваивается значение 2 - польщователь
            }

            if(db.update_user(select_email, email, name, lastname, office, roleid)) // изменяем все данные пользователя
            {
                MessageBox.Show("Изменения сохранены"); // выводим сообщение
                AdminForm adminform = new AdminForm(admin_email); // создаем обьект панели админа
                adminform.Show(); // открываем панель админа
                this.Hide(); // скрываем окно изменения роли
            }
        }

        private void button2_Click(object sender, EventArgs e) // если нажата кнопка закрытия окна
        {
            this.Close(); // закрываем окно
            AdminForm admin = new AdminForm(admin_email); // создаем обьект панели админа
            admin.Show(); // показываем панель админа
        }
    }
}
