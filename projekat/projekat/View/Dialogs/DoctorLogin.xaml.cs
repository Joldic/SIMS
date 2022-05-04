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
using projekat.View.Doctorr;

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for DoctorLogin.xaml
    /// </summary>
    public partial class DoctorLogin : Window
    {
        private string _username;
        private string _password;
        private DoctorController _doctorController;
        public uint _IdLoggedIn;

        public DoctorLogin()
        {
            InitializeComponent();

            _IdLoggedIn = 555;

            var app = Application.Current as App;
            _doctorController = app.DoctorController;
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
            _doctorController = app.DoctorController;
            try
            {
                Doctor doctor = _doctorController.FindDoctorByUsername(username_doctor.Text);
                if (doctor == null)
                {
                    MessageBoxResult result = MessageBox.Show("Username " + Username + " doesn't exist");
                    return;
                }
                if (doctor.Password != Password)
                {
                    MessageBoxResult result;

                    result = MessageBox.Show("NE VALJA SIFRA");
                }
                else
                {
                    _IdLoggedIn = doctor.Id;

                    new DoctorHomepage(_IdLoggedIn)
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
