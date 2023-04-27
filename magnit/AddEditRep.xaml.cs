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
            UsersCmb.ItemsSource = PROGADB1Entities2.GetContext().user.ToList();
            postCmb.ItemsSource = PROGADB1Entities2.GetContext().role.ToList();
            priceCmb.ItemsSource = PROGADB1Entities2.GetContext().role.ToList();
        }


        private void Otmena_CL(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_CL(object sender, RoutedEventArgs e)
        {
            
            var CurrentCar = UsersCmb.SelectedItem as user;
            var CurrentRole = postCmb.SelectedItem as role;
            var CurrentHrs = priceCmb.SelectedItem as reports;

            if (_currentreports.id >= 0)
                PROGADB1Entities2.GetContext().reports.AddOrUpdate(_currentreports);

            try
            {
                PROGADB1Entities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Close();
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
