using magnit.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
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

    public partial class AddEditPage : Window
    {
        private user _currentuser = new user();
        public AddEditPage(user selecteduser)
        {
            InitializeComponent();
            if (selecteduser != null)
            {
                _currentuser = selecteduser;
            }
            DataContext = _currentuser;
            Post.ItemsSource = PROGADB1Entities2.GetContext().role.ToList();
        }

        private void Otmena_CL(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_CL(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var CurrentCar = Post.SelectedItem as role;

            if (string.IsNullOrWhiteSpace(_currentuser.login))
                errors.AppendLine("Введите логин");

            if (string.IsNullOrWhiteSpace(_currentuser.password))
                errors.AppendLine("Введите пароль");

            if (string.IsNullOrWhiteSpace(_currentuser.fullName))
                errors.AppendLine("Введите ФИО");

            if (_currentuser.dateOfBirth == null)
                errors.AppendLine("Выберите дату");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentuser.id >= 0)
                PROGADB1Entities2.GetContext().user.AddOrUpdate(_currentuser);

            try
            {
                PROGADB1Entities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
