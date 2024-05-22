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
using KURSUVA;

namespace KURSUVA
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            UserNameField.Text = "Ім\'я";
            UserNameField.ForeColor = Color.Gray;

            UserSurnameField.Text = "Прізвище";
            UserSurnameField.ForeColor = Color.Gray;

            Middlename.Text = "По-батькові";
            Middlename.ForeColor = Color.Gray;

            passwordField.Text = "Password";
            passwordField.ForeColor = Color.Gray;

            PasswordRetryField.Text = "retryPassword";
            PasswordRetryField.ForeColor = Color.Gray;

            NumberPhone.Text = "Номер телефону";
            NumberPhone.ForeColor = Color.Gray;

            Mail.Text = "Електронна почта";
            Mail.ForeColor = Color.Gray;
        }

        private void UserNameField_Enter(object sender, EventArgs e)
        {
            if (UserNameField.Text == "Ім\'я")
            {  
                UserNameField.Text = "";
                UserNameField.ForeColor = Color.Black;
            }
        }
        private void UserNameField_Leave(object sender, EventArgs e)
        {
            if (UserNameField.Text == "")
            {
                UserNameField.Text = "І\'мя";
                UserNameField.ForeColor = Color.Gray;
            }
        }

        private void UserSurnameField_Enter(object sender, EventArgs e)
        {
            if(UserSurnameField.Text == "Прізвище")
            {
                UserSurnameField.Text = "";
                UserSurnameField.ForeColor = Color.Black;
            }
        }

        private void UserSurnameField_Leave(object sender, EventArgs e)
        {
            if (UserSurnameField.Text == "")
            {
                UserSurnameField.Text = "Прізвище";
                UserSurnameField.ForeColor = Color.Gray;
            }
        }
        private void Middlename_Enter(object sender, EventArgs e)
        {
            {
                if (Middlename.Text == "По-батькові")
                {
                    Middlename.Text = "";
                    Middlename.ForeColor = Color.Black;
                }
            }
        }

        private void Middlename_Leave(object sender, EventArgs e)
        {
            if (Middlename.Text == "")
            {
                Middlename.Text = "По-батькові";
                Middlename.ForeColor = Color.Gray;
            }
        }

        private void passwordField_Enter(object sender, EventArgs e)
        {
            if(passwordField.Text == "Password")
            {
                passwordField.Text = "";
                passwordField.ForeColor = Color.Black;
            }
        }

        private void passwordField_Leave(object sender, EventArgs e)
        {
            if(passwordField.Text == "")
            {
                passwordField.Text = "Password";
                passwordField.ForeColor = Color.Gray;
            }
        }

        private void PasswordRetryField_Enter(object sender, EventArgs e)
        {
            if (PasswordRetryField.Text == "retryPassword")
            {
                PasswordRetryField.Text = "";
                PasswordRetryField.ForeColor = Color.Black;
            }
        }

        private void PasswordRetryField_Leave(object sender, EventArgs e)
        {
            if (PasswordRetryField.Text == "")
            {
                PasswordRetryField.Text = "retryPassword";
                PasswordRetryField.ForeColor = Color.Gray;
            }
        }

        private void NumberPhone_Enter(object sender, EventArgs e)
        {
            if(NumberPhone.Text == "Номер телефону")
            {
                NumberPhone.Text = "";
                NumberPhone.ForeColor = Color.Black;
            }
        }

        private void NumberPhone_Leave(object sender, EventArgs e)
        {
            if (NumberPhone.Text == "")
            {
                NumberPhone.Text = "Номер телефону";
                NumberPhone.ForeColor = Color.Gray;
            }
        }

        private void Mail_Enter(object sender, EventArgs e)
        {
            if (Mail.Text == "Електронна почта")
            {
                Mail.Text = "";
                Mail.ForeColor = Color.Black;
            }
        }

        private void Mail_Leave(object sender, EventArgs e)
        {
            if (Mail.Text == "")
            {
                Mail.Text = "Електронна почта";
                Mail.ForeColor = Color.Gray;
            }
        }

        private void ButtomRegister_Click(object sender, EventArgs e)
        {
            if (UserNameField.Text == "Ім\'я")
            {
                MessageBox.Show("Введіть Ім\'я");
                return;
            }


            if (UserSurnameField.Text == "Прізвище")
            {
                MessageBox.Show("Введіть прізвище");
                return;
            }
            if (Middlename.Text == "По-батькові")
            {
                MessageBox.Show("Введіть По-батькові");
                return;
            }
            if (passwordField.Text == "Password")
            {
                MessageBox.Show("Введіть Password");
                return;
            }
            if (PasswordRetryField.Text == "PasswordRetryField")
            {
                MessageBox.Show("Введіть пароль повторно");
                return;
            }

            if (string.IsNullOrWhiteSpace(NumberPhone.Text))
            {
                MessageBox.Show("Введіть номер телефону");
                return;
            }

            if (isUserExists())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`name`, `surname`, `middlename`, `password`, `numberPhone`, `mail`) VALUES (@name, @surname, @middlename,@password, @numberPhone, @mail );", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = UserNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = UserSurnameField.Text;
            command.Parameters.Add("@middlename", MySqlDbType.VarChar).Value = Middlename.Text;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = passwordField.Text;
            command.Parameters.Add("@numberPhone", MySqlDbType.VarChar).Value = NumberPhone.Text;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Mail.Text;
            db.OpenConnection();
        
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт зареєстрований");
            else
                MessageBox.Show("Аккаунт не Зареєстровано");


            db.CloseConnection();
        }

        public Boolean isUserExists()
        {
            String loginuser = NumberPhone.Text;
            String passworduser = passwordField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `numberPhone` = @np", db.getConnection());

            command.Parameters.Add("@np", MySqlDbType.VarChar).Value = NumberPhone.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Цей номер уже зареєстрований введіть будь ласка інший");
                return true;
            }
            else
                return false;
              
        }

        private void ButtomExit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginLabel(object sender, EventArgs e)
        {
            this.Hide();
            Form3 loginform = new Form3();
            loginform.Show();
        }
    }
}
