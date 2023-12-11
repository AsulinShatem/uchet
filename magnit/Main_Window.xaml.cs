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
using System.Windows.Shapes;
using WpfApp;

namespace magnit
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            lblStatus.Content = MainWindow.Globals.role;
            lblname.Content = MainWindow.Globals.fullName;
        }

        private void Button_Click_Account(object sender, RoutedEventArgs e)
        {
            if (aye.Visibility == Visibility.Hidden)
                aye.Visibility = Visibility.Visible;
            else
                aye.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void Button_Click_Reports(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpen)
            {
                isWindowOpen = true;

                // Создаем новое окно и открываем его
                var newWindow = new LoadingWindow();
                newWindow.Show();

                // Блокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != newWindow)
                    {
                        window.IsEnabled = false;
                    }
                }

                // Ожидаем 5 секунд и закрываем окно
                await Task.Delay(500);
                newWindow.Close();

                // Разблокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    window.IsEnabled = true;
                }

                isWindowOpen = false;
            }
            rep_win reports = new rep_win();
            reports.Show();
            Close();

        }

        private async void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpen)
            {
                isWindowOpen = true;

                // Создаем новое окно и открываем его
                var newWindow = new LoadingWindow();
                newWindow.Show();

                // Блокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != newWindow)
                    {
                        window.IsEnabled = false;
                    }
                }

                // Ожидаем 5 секунд и закрываем окно
                await Task.Delay(500);
                newWindow.Close();

                // Разблокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    window.IsEnabled = true;
                }

                isWindowOpen = false;
            }
            var Main = new Main();
            Main.Show();
            this.Close();
        }



        private async void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpen)
            {
                isWindowOpen = true;

                // Создаем новое окно и открываем его
                var newWindow = new LoadingWindow();
                newWindow.Show();

                // Блокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != newWindow)
                    {
                        window.IsEnabled = false;
                    }
                }

                // Ожидаем 5 секунд и закрываем окно
                await Task.Delay(500);
                newWindow.Close();

                // Разблокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    window.IsEnabled = true;
                }

                isWindowOpen = false;
            }
            var staff = new staff();
            staff.Show();
            this.Close();
        }
        private bool isWindowOpen = false;
        private async void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpen)
            {
                isWindowOpen = true;

                // Создаем новое окно и открываем его
                var newWindow = new LoadingWindow();
                newWindow.Show();

                // Блокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != newWindow)
                    {
                        window.IsEnabled = false;
                    }
                }

                // Ожидаем 5 секунд и закрываем окно
                await Task.Delay(500);
                newWindow.Close();

                // Разблокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    window.IsEnabled = true;
                }

                isWindowOpen = false;
            }
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private async void Button_Click_Archive_Reports(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpen)
            {
                isWindowOpen = true;

                // Создаем новое окно и открываем его
                var newWindow = new LoadingWindow();
                newWindow.Show();

                // Блокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != newWindow)
                    {
                        window.IsEnabled = false;
                    }
                }

                // Ожидаем 5 секунд и закрываем окно
                await Task.Delay(500);
                newWindow.Close();

                // Разблокируем все остальные окна
                foreach (Window window in Application.Current.Windows)
                {
                    window.IsEnabled = true;
                }

                isWindowOpen = false;
            }
            var Archive_Reports = new ArchiveReports();
            Archive_Reports.Show();
            this.Close();
        }
    }
}
