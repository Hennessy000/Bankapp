using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace KURSUVA
{

    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення і відображення другої форми без потреби відображення першої
            Application.Run(new Form3());

            
            // Запуск приложения Windows Forms
        }

    }
}
