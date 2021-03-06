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
    public partial class UserForm : Form
    {
        int count_error = 0;
        //DateTime time_now = DateTime.Now;
        TimeSpan all_time = TimeSpan.Zero;
        string user_email;
        public UserForm(string email)
        {
            
            InitializeComponent();
            db db = new db();
            user_email = email;

            DateTime time_login = DateTime.Now;
            //string hourMinute = time_login.ToString("HH:mm");
            db.add_log_login(time_login, user_email);

            reload_panel(user_email);
            label_crash.Text = count_error.ToString();
            label_welcome.Text = string.Format("Hi {0},Welcome to AMONIC Airlines Automation System", db.get_user_name(user_email)[0][0]);
            label_time.Text = all_time.ToString(@"h\:mm\:ss");
            timer1.Start();
        }

        private void toolStripLabel_exit_Click(object sender, EventArgs e)
        {
            db db = new db();
            DateTime time_logout = DateTime.Now;
            db.add_log_logout(time_logout,user_email);
            MessageBox.Show("Данные о выходе внесены");
            this.Close();
        }
        public void reload_panel(string user_email) // функция обновления панели 
        {
            db db = new db(); // создаем обьект бд
            dataGridView1.Rows.Clear(); // очищаем панель админа
            List<string[]> all_users_data; // создаем пустую список
            all_users_data = db.get_user_logs(user_email); // получем всех пользователей всех офисов

            foreach (string[] s in all_users_data) // перебираем весь список
            {
                if (s[1] != DateTime.Now.ToString("t", DateTimeFormatInfo.InvariantInfo))
                {
                    dataGridView1.Rows.Add(s); // выводим пользователей как таблицу
                }
                else
                {
                    continue;
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows) // перебираем все строки таблицы
            {
                try // строка отлова ошибок, если в коде блока try  возникает ошибка, то выполняется блок catch
                {
                    Console.WriteLine(all_users_data[row.Index][3]); // пробуем вывести роль,если выводится значит список не закончился и блок catch пропускается
                }
                catch (ArgumentOutOfRangeException) // если список закончился и в блоке try возникла ошибка ArgumentOutOfRangeException - выход за индекс массива
                {
                    break; // происходит выход из функции
                }
                //if ((all_users_data[row.Index][2]).ToString() == "" && (all_users_data[row.Index][1]).ToString() != DateTime.Now.ToString("t", DateTimeFormatInfo.InvariantInfo)) // если пользователь заблокирован ( значение в БД 0, что интерпретируется как False
                if (row.Cells[2].Value == "")
                {
                    row.DefaultCellStyle.BackColor = Color.Red; // помечаем строку красным цветом
                    //row.Cells[4].Value = all_users_data[row.Index][4];
                    count_error += 1;
                }
            
                else 
                {
                    row.DefaultCellStyle.BackColor = Color.White; // помечаем белым цветом( он по умолчанию белый, однако когда 
                    
                    IFormatProvider culture = CultureInfo.InvariantCulture; // системная штука 
                    DateTime dt = DateTime.ParseExact(row.Cells[0].Value.ToString().Replace('/', '.'), "MM.dd.yyyy", System.Globalization.CultureInfo.InvariantCulture);
      
                    TimeSpan span = DateTime.Now.Subtract(dt); // обьект разницы времен
                    if (row.Cells[3].Value.ToString() != "")
                    {
                        TimeSpan new_value = TimeSpan.Parse(row.Cells[3].Value.ToString());
                        if (span.Days < 30)
                        {
                            all_time += new_value;
                        }
                    }
                    
                    
                }
            }
        }


   

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime current_time = DateTime.Now;
      
            label_current_time.Text = current_time.ToString("g", DateTimeFormatInfo.InvariantInfo);
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db db = new db();

            db.set_user_ofline(int.Parse(db.get_user_id(user_email)[0][0]));
        }
    }
}
