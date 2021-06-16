using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GOS_App
{
    class db
    {  // строчкой ниже вводим параметры подключения к нашей базе данных MySQl
        MySqlConnection connection = new MySqlConnection("server=185.139.70.3;port=3306;user=seredina;password=some_pass;database=gos_seredina;");

        DataTable table = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        public void OpenConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed) // проверяем, что не существует другой активной сессии
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) // проверяем, что открыто соединение
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public bool find_in_db(string username, string password)
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @userLogin AND `password` = @userPass", getConnection());

            command.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@userPass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        

        public List <string[]> admin_panel_load()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT firstName,lastname,birthdate,roles.title as t_roles,email,offices.title,active from users inner join roles on users.roleid = roles.id inner join offices on users.officeid = offices.id ", getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> all_users_data = new List<string[]>();

            while (reader.Read())
            {
                var today = DateTime.Today;

                all_users_data.Add(new string[7]);

                all_users_data[all_users_data.Count - 1][0] = reader[0].ToString();
                all_users_data[all_users_data.Count - 1][1] = reader[1].ToString();
                // 13.01.1983 0:00:00
    
                DateTime date_birthdate = DateTime.Parse(reader[2].ToString().Replace(".", "/")); // создаем из строки даты из SQL формат DateTime в C#

                all_users_data[all_users_data.Count - 1][2] = (today.Year - date_birthdate.Year).ToString(); 
                all_users_data[all_users_data.Count - 1][3] = reader[3].ToString();
                all_users_data[all_users_data.Count - 1][4] = reader[4].ToString();
                all_users_data[all_users_data.Count - 1][5] = reader[5].ToString();
                all_users_data[all_users_data.Count - 1][6] = reader[6].ToString();
            }

            reader.Close();
            CloseConnection();

            return all_users_data;
        }
        public List<string[]> get_offices()
        {
            OpenConnection();
            string query = "SELECT title FROM offices";      //query the database
            MySqlCommand queryStatus = new MySqlCommand(query, getConnection());
            MySqlDataReader reader = queryStatus.ExecuteReader();


            List<string[]> all_ofices = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                all_ofices.Add(new string[1]);
                all_ofices[all_ofices.Count - 1][0] = reader[0].ToString();
            }

            CloseConnection();
            return all_ofices;
        }
        public void create_new_user(string email,string name,string last_name,string office, DateTime birthdate, string password)
        {
            
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`ID`, `RoleID`, `Email`, `Password`, `FirstName`, `LastName`, `OfficeID`, `Birthdate`, `Active`) VALUES (@userID,2,@userEmail,@userPass,"
                + "@userName,@userLastname,@userOffice_new,@userBirthdate,1) ", getConnection());

            command.Parameters.Add("@userEmail", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@userName", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@userLastname", MySqlDbType.VarChar).Value = last_name;
            command.Parameters.Add("@userBirthdate", MySqlDbType.Date).Value = birthdate;
            command.Parameters.Add("@userPass", MySqlDbType.VarChar).Value = password;

            string new_office = get_user_office(office)[0][0];
            int new_user_id = Int32.Parse(get_max_users_id()[0][0]) + 1;
            command.Parameters.Add("@userID", MySqlDbType.Int32).Value = new_user_id;

            Console.WriteLine(new_office);
            command.Parameters.Add("@userOffice_new", MySqlDbType.Int32).Value = new_office;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();

            CloseConnection();
        }
        public List<string[]> get_user_office(string office_title)
        {
            OpenConnection();
            MySqlCommand user_office = new MySqlCommand("SELECT id FROM offices where title = @userOffice", getConnection());
            user_office.Parameters.Add("@userOffice", MySqlDbType.VarChar).Value = office_title;
            Console.WriteLine(office_title);
            MySqlDataReader reader = user_office.ExecuteReader();

            List<string[]> select_office = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_office.Add(new string[1]);
                select_office[select_office.Count - 1][0] = reader[0].ToString() ; 
   
            }
            CloseConnection();
            Console.WriteLine(select_office);
            return select_office;
        }
        public List<string[]> get_user_block(string email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT active FROM users where email = @userEmail", getConnection());
            command.Parameters.Add("@userEmail", MySqlDbType.VarChar).Value = email;
            
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> select_block_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_block_id.Add(new string[1]);
                select_block_id[select_block_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            Console.WriteLine(select_block_id);
            return select_block_id;
        }
        
        public List<string[]> get_user_name(string email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT firstname FROM users where email = @userEmail", getConnection());
            command.Parameters.Add("@userEmail", MySqlDbType.VarChar).Value = email;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> select_block_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_block_id.Add(new string[1]);
                select_block_id[select_block_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            Console.WriteLine(select_block_id);
            return select_block_id;
        }
        public List<string[]> get_user_id(string email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT id FROM users where email = @userEmail", getConnection());
            command.Parameters.Add("@userEmail", MySqlDbType.VarChar).Value = email;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> select_block_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_block_id.Add(new string[1]);
                select_block_id[select_block_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            Console.WriteLine(select_block_id);
            return select_block_id;
        }
        public List<string[]> get_user_role(string email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT roleid FROM users where email = @userEmail", getConnection());
            command.Parameters.Add("@userEmail", MySqlDbType.VarChar).Value = email;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> select_role_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_role_id.Add(new string[1]);
                select_role_id[select_role_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            Console.WriteLine(select_role_id);
            return select_role_id;
        }
        public List<string[]> get_max_users_id()
        {
            OpenConnection();
            MySqlCommand max_id_command = new MySqlCommand("SELECT max(id) FROM users", getConnection());
            MySqlDataReader reader = max_id_command.ExecuteReader();

            List<string[]> max_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                max_id.Add(new string[1]);
                max_id[max_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            return max_id;
        }
        public List<string[]> get_max_logs_id()
        {
            OpenConnection();
            MySqlCommand max_id_command = new MySqlCommand("SELECT max(id) FROM logs", getConnection());
            MySqlDataReader reader = max_id_command.ExecuteReader();

            List<string[]> max_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                max_id.Add(new string[1]);
                max_id[max_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            return max_id;
        }
        public List<string[]> get_online_logs_last_hour()
        {
            OpenConnection();
            MySqlCommand max_id_command = new MySqlCommand("SELECT distinct user_id,max(time_login) FROM logs group by user_id", getConnection());
            MySqlDataReader reader = max_id_command.ExecuteReader();

            List<string[]> max_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                max_id.Add(new string[2]);
                max_id[max_id.Count - 1][0] = reader[0].ToString();
                max_id[max_id.Count - 1][1] = reader[1].ToString();

            }
            CloseConnection();
            return max_id;
        }
        public List<string[]> get_count_online_users()
        {
            OpenConnection();
            MySqlCommand count_id_command = new MySqlCommand("SELECT count(id) FROM users where online = 1", getConnection());
            MySqlDataReader reader = count_id_command.ExecuteReader();

            List<string[]> count_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                count_id.Add(new string[1]);
                count_id[count_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            return count_id;
        }
        public List<string[]> load_users_value(string select_email)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT email,firstName,lastname,offices.title,roleid from users inner join offices on users.officeid = offices.id where email = @select_email ", getConnection());
            command.Parameters.Add("@select_email", MySqlDbType.VarChar).Value = select_email;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> all_user_data = new List<string[]>();

            while (reader.Read())
            {

                all_user_data.Add(new string[5]);

                all_user_data[all_user_data.Count - 1][0] = reader[0].ToString();
                all_user_data[all_user_data.Count - 1][1] = reader[1].ToString();
                all_user_data[all_user_data.Count - 1][2] = reader[2].ToString();
                all_user_data[all_user_data.Count - 1][3] = reader[3].ToString();
                all_user_data[all_user_data.Count - 1][4] = reader[4].ToString();
            }

            reader.Close();
            CloseConnection();

            return all_user_data;
        }

        public bool update_user(string old_email,string email,string name, string last_name, string office , int roleid)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `RoleID`= @userRole,`Email`=@userEmail,`FirstName`=@userName," +
                " `LastName`=@userLastname,`OfficeID`=@userOffice_new WHERE email = @user_old_email", getConnection());

            command.Parameters.Add("@userEmail", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@userName", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@userRole", MySqlDbType.Int32).Value = roleid;
            command.Parameters.Add("@userLastname", MySqlDbType.VarChar).Value = last_name;
            command.Parameters.Add("@user_old_email", MySqlDbType.VarChar).Value = old_email;

            string new_office = get_user_office(office)[0][0];

            Console.WriteLine(new_office);
            command.Parameters.Add("@userOffice_new", MySqlDbType.Int32).Value = new_office;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();

            CloseConnection();
            return true;
        }
        public List<string[]> changed_admin_panel_load(string office)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT firstName,lastname,birthdate,roles.title as t_roles,email,offices.title,active from users inner join roles " +
                "on users.roleid = roles.id inner join offices on users.officeid = offices.id  where offices.title = @office_title", getConnection());
            command.Parameters.Add("@office_title", MySqlDbType.VarChar).Value = office;
            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> all_users_data = new List<string[]>();

            while (reader.Read())
            {
                var today = DateTime.Today;

                all_users_data.Add(new string[7]);

                all_users_data[all_users_data.Count - 1][0] = reader[0].ToString();
                all_users_data[all_users_data.Count - 1][1] = reader[1].ToString();
                // 13.01.1983 0:00:00

                DateTime date_birthdate = DateTime.Parse(reader[2].ToString().Replace(".", "/")); // создаем из строки даты из SQL формат DateTime в C#

                all_users_data[all_users_data.Count - 1][2] = (today.Year - date_birthdate.Year).ToString();
                all_users_data[all_users_data.Count - 1][3] = reader[3].ToString();
                all_users_data[all_users_data.Count - 1][4] = reader[4].ToString();
                all_users_data[all_users_data.Count - 1][5] = reader[5].ToString();
                all_users_data[all_users_data.Count - 1][6] = reader[6].ToString();
            }

            reader.Close();
            CloseConnection();

            return all_users_data;
        }
        public bool change_user_role( string email,int block)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `active`= @userblock WHERE email = @user_email", getConnection());

            command.Parameters.Add("@user_email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@userblock", MySqlDbType.Int32).Value = block;



            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();

            CloseConnection();
            return true;
        }
        public void set_user_online(int id)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `online`= 1 WHERE id = @user_id", getConnection());

            command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = id;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();

            CloseConnection();
        }
        public void set_user_ofline(int id)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `online`= 0 WHERE id = @user_id", getConnection());

            command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = id;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();

            CloseConnection();
        }
        public void add_log_login(DateTime login_time, string email)
        {
            
            int user_id = Int32.Parse(get_user_id(email)[0][0]);
            set_user_online(user_id);
            MySqlCommand command = new MySqlCommand("INSERT INTO `logs`(`user_id`, `time_login`) " +
                "VALUES(@userid,@loginDate)", getConnection());

            command.Parameters.Add("@userid", MySqlDbType.Int32).Value = user_id;
            command.Parameters.Add("@loginDate", MySqlDbType.DateTime).Value = login_time;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            CloseConnection();
        }
        public List<string[]> get_logs_login_time(int id)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT time_login FROM logs where id = @logs_id", getConnection());
            command.Parameters.Add("@logs_id", MySqlDbType.Int32).Value = id;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> select_login_time = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_login_time.Add(new string[1]);
                select_login_time[select_login_time.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            return select_login_time;
        }
        public List<string[]> get_logs_logout_time(int id)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT time_logout FROM logs where id = @logs_id", getConnection());
            command.Parameters.Add("@logs_id", MySqlDbType.Int32).Value = id;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> select_login_time = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_login_time.Add(new string[1]);
                select_login_time[select_login_time.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            return select_login_time;
        }
        public void add_log_logout(DateTime logout_time,string email)
        {
            set_user_ofline(int.Parse(get_user_id(email)[0][0]));
            int current_log_id = Int32.Parse(get_max_logs_user_id(email)[0][0]);

            DateTime login_time = DateTime.Parse(get_logs_login_time(current_log_id)[0][0].Replace(".", "/"));
             
            TimeSpan span = logout_time.Subtract(login_time);
            
            MySqlCommand command = new MySqlCommand("UPDATE `logs` SET `time_logout` = @logoutTime, `time_active` = @time_active where id = @log_id", getConnection());

            command.Parameters.Add("@logoutTime", MySqlDbType.DateTime).Value = logout_time;
            command.Parameters.Add("@time_active", MySqlDbType.VarChar).Value = span.ToString(@"h\:mm");
            command.Parameters.Add("@log_id", MySqlDbType.Int32).Value = current_log_id;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            CloseConnection();
        }
        public List<string[]> get_user_logs(string email)
        {
   

            int user_id = Int32.Parse(get_user_id(email)[0][0]);

            MySqlCommand user_logs = new MySqlCommand("SELECT time_login,time_logout,time_active,note FROM logs where user_id = @user_id order by time_login desc", getConnection());
            user_logs.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id;

            OpenConnection();
            MySqlDataReader reader = user_logs.ExecuteReader();

            List<string[]> select_logs = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                select_logs.Add(new string[6]);

                DateTime date_login = DateTime.Parse(reader[0].ToString().Replace(".", "/"));
                select_logs[select_logs.Count - 1][0] = date_login.ToString("d", DateTimeFormatInfo.InvariantInfo);  // date
                select_logs[select_logs.Count - 1][1] = date_login.ToString("t", DateTimeFormatInfo.InvariantInfo); // login time

                try{
                    DateTime date_logout = DateTime.Parse(reader[1].ToString().Replace(".", "/"));
                    select_logs[select_logs.Count - 1][2] = date_logout.ToString("t", DateTimeFormatInfo.InvariantInfo); // logout time
                }
                catch(System.FormatException)
                {
                    select_logs[select_logs.Count - 1][2] = ""; // logout time
                }
                Console.WriteLine(reader[3]);
                select_logs[select_logs.Count - 1][3] = reader[2].ToString(); // time_active
                select_logs[select_logs.Count - 1][4] = reader[3].ToString(); // note
                select_logs[select_logs.Count - 1][5] = reader[3].ToString(); // reason

            }
            CloseConnection();
            return select_logs;
        }
        public List<string[]> get_max_logs_user_id(string email)
        {
           
            int user_id = Int32.Parse(get_user_id(email)[0][0]);
            MySqlCommand max_id_command = new MySqlCommand("SELECT max(id) FROM logs where user_id = @user_id", getConnection());
            max_id_command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id;
            OpenConnection();
            MySqlDataReader reader = max_id_command.ExecuteReader();

            List<string[]> max_id = new List<string[]>();

            while (reader.Read())   //loop reader and fill the combobox
            {
                max_id.Add(new string[1]);
                max_id[max_id.Count - 1][0] = reader[0].ToString();

            }
            CloseConnection();
            return max_id;
        }

        public bool set_status_error_logut(int id, string note, string reason = "")
        {
            MySqlCommand command = new MySqlCommand("UPDATE `logs` SET `note` = @note, `reason` = @reason where id = @log_id", getConnection());

            command.Parameters.Add("@note", MySqlDbType.VarChar).Value = note;
            command.Parameters.Add("@reason", MySqlDbType.VarChar).Value = reason;
            command.Parameters.Add("@log_id", MySqlDbType.Int32).Value = id;
            OpenConnection();
            MySqlDataReader reader = command.ExecuteReader();
            CloseConnection();
            return true;
        }
        


    }
}
