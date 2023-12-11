using magnit.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
using Word = Microsoft.Office.Interop.Word;

namespace magnit
{
    public partial class ArchiveReports : Window
    {
        public ArchiveReports()
        {
            InitializeComponent();
            lblStatus.Content = MainWindow.Globals.role;
            lblname.Content = MainWindow.Globals.fullName;
            if (MainWindow.Globals.role != "Администратор")
            {
                //Add_Btn.Visibility = Visibility.Hidden;
                //Del_Btn.Visibility = Visibility.Hidden;
            }

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
            rep_win rep_Win = new rep_win();
            rep_Win.Show();
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
            var Main_Window = new Main();
            Main_Window.Show();
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
            staff staff = new staff();
            staff.Show();
            this.Close();
        }

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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Archive_Reports_DataGrid.ItemsSource = AppData.db.archiveReports.ToList();
        }

        private async void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentCar = Archive_Reports_DataGrid.SelectedItem as reports;
                AppData.db.reports.Remove(CurrentCar);
                AppData.db.SaveChanges();
                MessageBox.Show("Вы успешно удалили запись!");
                Archive_Reports_DataGrid.ItemsSource = AppData.db.reports.ToList();
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
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddEditRep addEditPage = new AddEditRep(null);
            addEditPage.Show();
        }

        private async void refresh_Btn_Click(object sender, RoutedEventArgs e)
        {
            Archive_Reports_DataGrid.ItemsSource = AppData.db.reports.ToList();
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
        }

        private bool isWindowOpen = false;

        private void Button_Click_Archive_Reports(object sender, RoutedEventArgs e)
        {

        }

        private void Archive_Click_Btn(object sender, RoutedEventArgs e)
        {
        }
    }
}