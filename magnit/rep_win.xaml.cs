﻿using magnit.Model;
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
using Word = Microsoft.Office.Interop.Word;

namespace magnit
{
    public partial class rep_win : Window
    {
        public rep_win()
        {
            InitializeComponent();
            lblStatus.Content = MainWindow.Globals.role;
            lblname.Content = MainWindow.Globals.fullName;
            if (MainWindow.Globals.role != "Администратор")
            {
                Add_Btn.Visibility = Visibility.Hidden;
                Del_Btn.Visibility = Visibility.Hidden;
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
            rep_win rep_win = new rep_win();
            rep_win.Show();
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
            Reports_DataGrid.ItemsSource = AppData.db.reports.ToList();
        }

        private async void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentCar = Reports_DataGrid.SelectedItem as reports;
                AppData.db.reports.Remove(CurrentCar);
                AppData.db.SaveChanges();
                MessageBox.Show("Вы успешно удалили запись!");
                Reports_DataGrid.ItemsSource = AppData.db.reports.ToList();
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
            Reports_DataGrid.ItemsSource = AppData.db.reports.ToList();
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

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Globals.role != "Администратор")
            {
                MessageBox.Show("Вам не доступно редактирование. Обратитесь к администратору для редактирования");
            }
            else
            {
                AddEditRep addPage = new AddEditRep((sender as Button).DataContext as reports);
                addPage.Show();
            }
        }
        private bool isWindowOpen = false;
        private async void export_Btn_Click(object sender, RoutedEventArgs e)
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
            var allRequest = PROGADB1Entities.GetContext().reports.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчёт о зарплатах";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 6);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Номер по порядку";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "ФИО";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Должность";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Отработанных часов";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Ставка в час";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Зарплата";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];
                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = Convert.ToString(currentCategory.id);
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = Convert.ToString(currentCategory.role);

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = Convert.ToString(currentCategory.fullName);

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = Convert.ToString(currentCategory.hours);

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = Convert.ToString(currentCategory.priceForHour);

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = Convert.ToString(currentCategory.zarplata);
            }

            application.Visible = true;
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
            ArchiveReports archiveReports = new ArchiveReports();
            archiveReports.Show();
            this.Close();
        }

        private void Archive_Click_Btn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите архивировать запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //говно не работает(((
                /*var CurrentCar = Reports_DataGrid.SelectedItem as reports;
                AppData.db.archiveReports.Add(CurrentCar);
                AppData.db.SaveChanges();
                MessageBox.Show("Информация архивирована!");
                Close();*/
            }
        }
    }
}