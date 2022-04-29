using Controller;
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
using projekat.View.Patient;






namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string _username;
        private string _password;
        private PatientControler _patientControler;
        public PatientLogin()
        {
            InitializeComponent();
            DataContext = this;





            var app = Application.Current as App;
            _patientControler = app.PatientControler;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
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

        void Execute(object parameter, RoutedEventArgs e)
        {

            //DataContext = this;


            var app = Application.Current as App;
            _patientControler = app.PatientControler;
            try
            {
                Model.Patient patient = _patientControler.FindPatientByUsername(Username);
                //Secretary secretary = _secretaryController.GetSecretary(1);
                if (patient.Password != Password)
                {
                    MessageBoxResult result;

                    result = MessageBox.Show("POGRESNA SIFRA");
                }
                else
                {

                    new PatientHomepage()
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
