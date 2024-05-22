using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KURSUVA;
using static KURSUVA.Form3;

namespace KURSUVA
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();


            Card_number.Text = "Номер картки";
            Card_number.ForeColor = Color.Gray;

            TimeAction.Text = "Термін дії";
            TimeAction.ForeColor = Color.Gray;

            CodeSecurity.Text = "Код безпеки";
            CodeSecurity.ForeColor = Color.Gray;

        }

        private void ButtomRegisterCard_Click(object sender, EventArgs e)
        {
            if (Card_number.Text == "Номер картки" || TimeAction.Text == "Термін дії" || CodeSecurity.Text == "Код безпеки")
            {
                MessageBox.Show("Заповніть всі поля");
                return;
            }

            string currentphoneNumber = CurrentUser.numberPhone;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `bank_cards` (`numberPhone`, `CardNumber`, `ExpirationDate`, `SecurityCode`) VALUES (@numberPhone, @CardNumber, @ExpirationDate, @SecurityCode);", db.getConnection());
            command.Parameters.Add("@numberPhone", MySqlDbType.VarChar).Value = currentphoneNumber;
            command.Parameters.Add("@CardNumber", MySqlDbType.VarChar).Value = Card_number.Text;
            command.Parameters.Add("@ExpirationDate", MySqlDbType.VarChar).Value = TimeAction.Text;
            command.Parameters.Add("@SecurityCode", MySqlDbType.VarChar).Value = CodeSecurity.Text;
            db.OpenConnection();

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Картка додана");
            }
            else
            {
                MessageBox.Show("Помилка додавання карти");
            }

            db.CloseConnection();
            this.Hide();
            Form1 loginform = new Form1();
            loginform.Show();
            
            
        }

        private void Card_number_Enter(object sender, EventArgs e)
        {
            if (Card_number.Text == "Номер картки")
            {
                Card_number.Text = "";
                Card_number.ForeColor = Color.Black;
            }
        }

        private void Card_number_Leave(object sender, EventArgs e)
        {
            if (Card_number.Text == "")
            {
                Card_number.Text = "Номер картки";
                Card_number.ForeColor = Color.Gray;
            }
            else
            {
                string cardNumber = Card_number.Text.Replace(" ", ""); 
                if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
                {
                    MessageBox.Show("Номер картки повинен містити 16 цифр.");
                    Card_number.Text = "Номер картки";
                    Card_number.ForeColor = Color.Gray;
                }
                else
                {
                    Card_number.Text = string.Join(" ", Enumerable.Range(0, 16 / 4).Select(i => cardNumber.Substring(i * 4, 4)));
                }
            }
        }

        private void TimeAction_Enter(object sender, EventArgs e)
        {
            if (TimeAction.Text == "Термін дії")
            {
                TimeAction.Text = "";
                TimeAction.ForeColor = Color.Black;
            }
        }

        private void TimeAction_Leave(object sender, EventArgs e)
        {
            if (TimeAction.Text == "")
            {
                TimeAction.Text = "Термін дії";
                TimeAction.ForeColor = Color.Gray;
            }
            else
            {
                string expiryDate = TimeAction.Text.Replace("/", ""); 
                if (expiryDate.Length != 4 || !expiryDate.All(char.IsDigit))
                {
                    MessageBox.Show("Термін дії повинен бути у форматі MM/РР (наприклад, 01/25).");
                    TimeAction.Text = "Термін дії";
                    TimeAction.ForeColor = Color.Gray;
                }
                else
                {
                    TimeAction.Text = expiryDate.Insert(2, "/"); 
                }
            }
        }

        private void CodeSecurity_Enter(object sender, EventArgs e)
        {
            if (CodeSecurity.Text == "Код безпеки")
            {
                CodeSecurity.Text = "";
                CodeSecurity.ForeColor = Color.Black;
            }
        }

        private void CodeSecurity_Leave(object sender, EventArgs e)
        {
            if (CodeSecurity.Text == "")
            {
                CodeSecurity.Text = "Код безпеки";
                CodeSecurity.ForeColor = Color.Gray;
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(CodeSecurity.Text, @"^\d{3}$"))
                {
                    MessageBox.Show("Код безпеки повинен містити 3 цифри.");
                    CodeSecurity.Text = "Код безпеки";
                    CodeSecurity.ForeColor = Color.Gray;
                }
            }
        }

        private void ButtomExit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
