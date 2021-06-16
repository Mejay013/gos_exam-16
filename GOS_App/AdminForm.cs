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
            db db = new db(); // создаем новый обьект класс  db( класс для работы с базой данных) 
            user_email = email;
            List<string[]> all_offices = db.get_offices(); // получаем список всез офисов, которые в БД 
            comboBox1.Text = "All offices"; // устанавливаем в выпадающий список текст "All offices" ( типо как по умолчанию)
            comboBox1.Items.Add("All offices"); // добавляем в выпадающий список  значение  "All offices"
            foreach (string[] s in all_offices) // перебираем все строчки списка офисов
            {
                comboBox1.Items.Add(s[0]); // заносим название каждого офиса в выпадающий список
            }
            DateTime time_login = DateTime.Now;
            db.add_log_login(time_login, user_email);
  
            reload_panel(); // обновляем панель

        }

        private void strip_exit_Click(object sender, EventArgs e) // при нажатии на кнопку exit
        {
            db db = new db();
            DateTime time_logout = DateTime.Now;
            db.add_log_logout(time_logout,user_email);
            MessageBox.Show("Данные о выходе внесены");
            this.Close();
        }

        private void strip_add_user_Click(object sender, EventArgs e) // при нажатии на кнопку добавления пользователя
        {
            
            AddUserForm add_user_form = new AddUserForm(user_email); // создаем обьект окна с добавлением
            add_user_form.Show(); // показываем окно
            this.Hide(); // скрываем окно с админ панелью


        }

        private void button_change_role_Click(object sender, EventArgs e) // при нажатии на кнопку изменения роли
        {
            string select_email = dataGridView1.CurrentCell.Value.ToString(); // получаем почту пользователя, который был выделен
            EditRoleForm editformrole = new EditRoleForm(user_email,select_email); // создаем обьект окна изменения роли 
            editformrole.Show(); // открываем окно изменения роли
            this.Close(); // закрываем окно админа

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // при изменении элемента выпадающего списка офисов
        {  
            db db = new db(); // создаем обьект базы данных
            
            reload_panel(comboBox1.Text); //обновляем панель выводя только выбранный офис 
        }

        private void button2_Click(object sender, EventArgs e) // при нажатии на кнопку блокировки
        {
            db db = new db(); // создаем подключение к бд
            string new_block; // создаем пустую строку
            string select_email = dataGridView1.CurrentCell.Value.ToString(); // получаем почту, которая выбрана пользователем
            string office = comboBox1.Text; // получаем название офиса из выпадающего списка, для фильтрации при обновлении панели

            string old_block = db.get_user_block(select_email)[0][0]; // получаем значени,заблокирован пользователь или нет
            if(old_block == "True") // если разблокирован ( в БД значение 1 )
            {
                new_block = "0"; // отправляем значение 0 (блокируем)
            }
            else // иначе
            {
                new_block = "1"; //отправляем значение 1 ( разблокируем) 
            }
            
            if (db.change_user_role(select_email,int.Parse(new_block))) // изменяем роль пользователя в базе данных
            {
                MessageBox.Show("Изменения сохранены"); // выводим сообщение
                
            }

            reload_panel(office); // перезаполняем панель админа с фильтрацией по офису
        }
        public void reload_panel(string flg = "All offices") // функция обновления панели с заданной ПЕРЕМЕННОЙ ПО УМОЛЧАНИЮ
        {
            db db = new db(); // создаем обьект бд

            dataGridView1.Rows.Clear(); // очищаем панель админа

            List<string[]> all_users_data; // создаем пустую строку

            if (flg == "All offices") // если значение не было передано или передано значение всех офисов
            {
                all_users_data = db.admin_panel_load(); // получем всех пользователей всех офисов

                foreach (string[] s in all_users_data) // перебираем весь список
                {
                    dataGridView1.Rows.Add(s); // выводим пользователей как таблицу
                }
            }
            else // если передан какой-либо конкретный офис 
            {
                all_users_data = db.changed_admin_panel_load(flg); // получаем всех пользователей,привязанных к данному офису
                foreach (string[] s in all_users_data) // перебираем список
                {
                    dataGridView1.Rows.Add(s); // выводим пользователей как таблицу
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows) // перебираем все строки таблицы
            {
                try // строка отлова ошибок, если в коде блока try  возникает ошибка, то выполняется блок catch
                {
                    Console.WriteLine(all_users_data[row.Index][6]); // пробуем вывести роль,если выводится значит список не закончился и блок catch пропускается
                }
                catch (ArgumentOutOfRangeException) // если список закончился и в блоке try возникла ошибка ArgumentOutOfRangeException - выход за индекс массива
                {
                    break; // происходит выход из функции
                }
                if ((all_users_data[row.Index][6]).ToString() == "False") // если пользователь заблокирован ( значение в БД 0, что интерпретируется как False
                {
                    row.DefaultCellStyle.BackColor = Color.Red; // помечаем строку красным цветом
                }
                else // если пользователь не заблокирован
                {
                    row.DefaultCellStyle.BackColor = Color.White; // помечаем белым цветом( он по умолчанию белый, однако когда мы разблокируем пользователя
                                                                        // надо нативно поменять красный цвет на белый (наверное, лень проверять, оно работает)
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
