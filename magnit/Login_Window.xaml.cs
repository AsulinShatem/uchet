using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using magnit;
using magnit.Model;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TxbPass.IsEnabled = false;
        }
        public static class Globals
        {
            public static int UserRoles;
            public static user userinfo { get; set; }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.user.FirstOrDefault(u => u.login == TxbLogin.Text);
            if (CurrentUser != null)
            {
                TxbPass.IsEnabled = true;
                Auth_Btn.Visibility = Visibility.Hidden;
                Auth_Btn_2.Visibility = Visibility.Visible;
                TxbLogin.IsEnabled = false;
                TxbPass.Focus();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
            }

        }
        private async void Button_Click_22(object sender, RoutedEventArgs e)
        {
            var CurrentUser1 = AppData.db.user.FirstOrDefault(u => u.login == TxbLogin.Text && u.password == TxbPass.Password);
            if (CurrentUser1 != null)
            {
                if (Auth_Win_1.Visibility == Visibility.Hidden)
                    Auth_Win_1.Visibility = Visibility.Visible;
                TxbLogin.IsEnabled = false;
                TxbPass.IsEnabled = false;
                Auth_Btn_2.IsEnabled = false;
                VVOD.Focus();
                Globals.userinfo = CurrentUser1;
                while (true) //рандомизация кода и сброс кода каждые 10 секунд
                {
                    Random x = new Random();
                    int a = x.Next(1000, 9999);
                    CODE.Text = a.ToString();
                    await Task.Delay(10000);
                }
            }
            else //если пароль не верный то ошибка
            {
                MessageBox.Show("Пароль не верен!");
                TxbPass.Clear();
                TxbPass.IsEnabled = false;
                TxbLogin.IsEnabled = true;
                TxbLogin.Clear();
                Auth_Btn_2.Visibility = Visibility.Hidden;
                Auth_Btn.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Next_Btn(object sender, RoutedEventArgs e)
        {
            if (VVOD.Text == CODE.Text) //если код верный то переход на другое окно
            {
                var Main = new Main();
                Main.Show();
                Close();
            }
            else //если код не верный то ошибка
            {
                MessageBox.Show("Код подтверждения не верный!");
                VVOD.Clear();
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                Random x = new Random();
                int a = x.Next(1000, 9999);
                CODE.Text = a.ToString();
                await Task.Delay(10000);
            }
        }
    }
}
