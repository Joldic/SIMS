using Model;
using projekat.Controller;
using projekat.View.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projekat.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _username;
        private string _password;
        private SecretaryController _secretaryController;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

        



            var app = Application.Current as App;
            _secretaryController = app.SecretaryController;
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
            _secretaryController = app.SecretaryController;
            try
            {
                Model.Secretary secretary = _secretaryController.FindSecretaryByUsername(Username);
                //Secretary secretary = _secretaryController.GetSecretary(1);
                if (secretary.Password != Password)
                {
                    MessageBoxResult result;

                    result = MessageBox.Show("NE VALJA SIFRA");
                }
                else
                {
                    MessageBoxResult result;

                    result = MessageBox.Show("DOBRA SIFRA");
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

        

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            new ManagerLogin()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            new SecretaryLogin()
            {
                Owner = Application.Current.MainWindow
            }
               .ShowDialog();
            this.Close();
            
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {

            new PatientLogin()
            {
                Owner = Application.Current.MainWindow
            }
               .ShowDialog();
            this.Close();
        }
    }
}
