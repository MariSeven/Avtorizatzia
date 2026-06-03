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
        // Маркер определяющий вызов подтверждения закрытия
        public int podtv=0;
        public MainWindow()
        {
            InitializeComponent();
        }
        // Метод кнопки авторизации
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Запись в переменные значений полей в текст боксов
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password;

            // Проверка заполнения полей
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Вход в личный кабинет
            if (UserDatabase.Users.ContainsKey(login))
            {
                if (UserDatabase.Users[login] == password)
                {
                    Account account = new Account(login);
                    account.Show();
                    podtv = 1;
                    this.Close();
                }
                
                // Действие при неверном пароле
                else
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                }
            }

            // Действие при неверном логине
            else
            {
                MessageBox.Show("Пользователь не найден!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Метод кнопки выхода
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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