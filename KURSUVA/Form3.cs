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

namespace KURSUVA
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();

            numberPhone.Text = "Номер телефону";
            numberPhone.ForeColor = Color.Gray;

            passwordField.Text = "Password";
            passwordField.ForeColor = Color.Gray;
        }

        private void ButtomLogin_Click(object sender, EventArgs e)
        {

            String loginuser = numberPhone.Text;
            String passworduser = passwordField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command =  new MySqlCommand("SELECT * FROM `users` WHERE `numberPhone` = @np AND `password` = @up", db.getConnection());

            command.Parameters.Add("@np", MySqlDbType.VarChar).Value = loginuser;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passworduser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                CurrentUser.numberPhone = loginuser;

                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.Show();
            }
            else
                MessageBox.Show("Невірний логін або пароль");
        }

        public static class CurrentUser
        {
            internal static string numberPhone;
        }

        private void numberPhone_Enter(object sender, EventArgs e)
        {
            if (numberPhone.Text == "Номер телефону")
            {
                numberPhone.Text = "";
                numberPhone.ForeColor = Color.Black;
            }
        }

        private void passwordField_Enter(object sender, EventArgs e)
        {
            if (passwordField.Text == "Password")
            {
                passwordField.Text = "";
                passwordField.ForeColor = Color.Black;
            }
        }

        private void numberPhone_Leave(object sender, EventArgs e)
        {
            if (numberPhone.Text == "")
            {
                numberPhone.Text = "Номер телефону";
                numberPhone.ForeColor = Color.Gray;
            }
        }

        private void passwordField_Leave(object sender, EventArgs e)
        {
            if (passwordField.Text == "")
            {
                passwordField.Text = "Password";
                passwordField.ForeColor = Color.Gray;
            }
        }

        private void registerLabel(object sender, EventArgs e)
        {
            this.Hide();
            Form2 registerform = new Form2();
            registerform.Show();

        }

        private void ButtomExit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
