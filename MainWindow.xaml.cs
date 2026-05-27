using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avtorizatzia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int podtv=0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (UserDatabase.Users.ContainsKey(login))
            {
                if (UserDatabase.Users[login] == password)
                {
                    Account account = new Account(login);
                    account.Show();
                    podtv = 1;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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