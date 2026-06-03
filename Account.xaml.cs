using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avtorizatzia
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        // Переменная, отвечающая за логин
        string _currentLogin;
        public int podtv = 0;

        // Конструктор (принимает логин из окна MainWindow)
        public Account(string currentLogin)
        {
            InitializeComponent();
            _currentLogin = currentLogin;
            // Замена текста в текст блоке на сообщение
            txtWelcome.Text = $"Добро пожаловать, {_currentLogin}!";
        }

        // Метод кнопки смена пароля
        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Введите новый пароль:", "Смена пароля", "");

            // Проверка заполнения нового пароля
            if (!string.IsNullOrEmpty(newPassword))
            {
                UserDatabase.Users[_currentLogin] = newPassword;
                MessageBox.Show("Пароль успешно изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Метод кнопки выхода из аккаунта
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Вы точно хотите выйти из аккаунта?", "Подтверждение выхода", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                podtv = 1;
                this.Close();
                main.Show();
            }

        }

        // Метод обработки закрытия
        private void Close_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (podtv == 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите закрыть приложение?", "Подтверждение закрытия", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }

            }
            
        }
    }
}
