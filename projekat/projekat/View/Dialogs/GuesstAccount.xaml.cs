using Controller;
using Model;
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

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for GuesstAccount.xaml
    /// </summary>
    public partial class GuesstAccount : Window
    {
        private PatientControler _patientController;
        public GuesstAccount()
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _patientController = app.PatientControler;
        }

        private void AddGuesst_Click(object sender, RoutedEventArgs e)
        {
            string Username = User.Text;
            string Password = Pass.Text;

            DateTime date_of_birth = DateTime.Now;
            string Name = "N";
            string Surname = "N";
            string Adress = "Xxxx";
            string Email = "someone@gmail.com";
            Gender G = Gender.m;

            if(_patientController.FindPatientByUsername(Username) == null)
            {
                Patient p = new Patient(Name, Surname, date_of_birth, Adress, Email, G, Password, Username);
                _patientController.CreateNewPatient(p);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Username " + Username + " already exists!");
            }

            



        }
    }
}
