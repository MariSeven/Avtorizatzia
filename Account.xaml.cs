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
        private string _currentLogin;
        public Account(string currentLogin)
        {
            InitializeComponent();
            _currentLogin = currentLogin;
            txtWelcome.Text = $"Добро пожаловать, {_currentLogin}!";
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Введите новый пароль:", "Смена пароля", "");

            if (!string.IsNullOrEmpty(newPassword))
            {
                UserDatabase.Users[_currentLogin] = newPassword;
                MessageBox.Show("Пароль успешно изменен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Вы точно хотите выйти из аккаунта?", "Подтверждение выхода", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
        }

        private void Close_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите закрыть приложение?", "Подтверждение закрытия", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
