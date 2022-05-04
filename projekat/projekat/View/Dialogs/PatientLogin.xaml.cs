using projekat.Controller;
using projekat.View.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Model;
using Controller;
using projekat.View.Patientt;
//using projekat.View.Patient;

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientLogin.xaml
    /// </summary>
    public partial class PatientLogin : Window
    {
        private string _username;
        private string _password;
        private PatientControler _patientController;
        public uint _IdLoggedIn;

        public PatientLogin()
        {
            InitializeComponent();
            DataContext = this;


            _IdLoggedIn = 555;


            var app = Application.Current as App;
            _patientController = app.PatientControler;
        }
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

    

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        private void Execute(object sender, RoutedEventArgs e)
        {

            var app = Application.Current as App;
            _patientController = app.PatientControler;
            try
            {
                //Model.Patient patient = _patientController.FindPatientByUsername(Username);
                Model.Patient patient = _patientController.FindPatientByUsername(Username);
                if (patient == null)
                {
                    MessageBoxResult result = MessageBox.Show("Username " + Username + " doesn't exist");
                    return;
                }
                if (patient.Password != Password)
                {
                    MessageBoxResult result;

                    result = MessageBox.Show("NE VALJA SIFRA");
                }
                else
                {
                    _IdLoggedIn = patient.Id;

                    new PatientHomepage(_IdLoggedIn)
                    {
                        Owner = Application.Current.MainWindow
                    }
                    .ShowDialog();
                    this.Close();

                }
            }
            catch
            {
                throw;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
