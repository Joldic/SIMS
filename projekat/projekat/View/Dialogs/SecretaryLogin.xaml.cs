using Model;
using projekat.Controller;
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
using projekat.View.Secretary;




namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for SecretaryLogin.xaml
    /// </summary>
    public partial class SecretaryLogin : Window
    {
        private string _username;
        private string _password;
        private SecretaryController _secretaryController;
        public SecretaryLogin()
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
                    
                    new SecretaryHomepage()
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


