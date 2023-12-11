using magnit.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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

namespace magnit
{
    /// <summary>
    /// Логика взаимодействия для AddEditRep.xaml
    /// </summary>
    public partial class AddEditRep : Window
    {
        private reports _currentreports = new reports();
        public AddEditRep(reports selectedreports)
        {
            InitializeComponent();
            if (selectedreports != null)
            {
                _currentreports = selectedreports;
            }
            DataContext = _currentreports;
            UsersCmb.ItemsSource = PROGADB1Entities.GetContext().userloggs.ToList();
            postCmb.ItemsSource = PROGADB1Entities.GetContext().role.ToList();
            priceCmb.ItemsSource = PROGADB1Entities.GetContext().role.ToList();
        }


        private void Otmena_CL(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private bool isWindowOpen = false;
        private async void Add_CL(object sender, RoutedEventArgs e)
        {
            
            var CurrentCar = UsersCmb.SelectedItem as userloggs;
            var CurrentRole = postCmb.SelectedItem as role;
            var CurrentHrs = priceCmb.SelectedItem as reports;

            if (_currentreports.id >= 0)
                PROGADB1Entities.GetContext().reports.AddOrUpdate(_currentreports);

            try
            {
                PROGADB1Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Close();
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
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }
        }

        private void Ras_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(agg.Text, out int inputNumber))
            {
                MessageBox.Show("Пожалуйста, введите кол-во отработанных часов.");
                return;
            }
            if (!int.TryParse(priceCmb.Text, out int priceNumber))
            {
                MessageBox.Show("Пожалуйста, выберите ставку.");
                return;
            }
            int result = inputNumber * priceNumber;
            resultTextBox.Text = result.ToString();
            resultTextBox.Focus();
        }
    }
}
