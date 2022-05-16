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
namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for ManagerLogin.xaml
    /// </summary>
    public partial class ManagerLogin : Window
    {
        private string _username;
        private string _password;
        private ManagerController _managerController;
        private UserController _userController;
        public uint _IdLoggedIn;

        public ManagerLogin()
        {
            InitializeComponent();
            DataContext = this;


            _IdLoggedIn = 555;


            var app = Application.Current as App;
            _managerController = app.ManagerController;
            _userController = app.UserController;
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
            _managerController = app.ManagerController;
            try
            {
                //Model.Manager manager = _managerController.FindManagerByUsername(Username);
                Model.User user = _userController.FindUserByUsername(Username);
                if (user == null)
                {
                    MessageBoxResult result = MessageBox.Show("Username " + Username + " doesn't exist");
                    return;
                }
                if (user.Password != Password)
                {
                    MessageBoxResult result;

                    result = MessageBox.Show("NE VALJA SIFRA");
                }
                else
                {
                    _IdLoggedIn = user.Id;

                    new ManagerHomepage(_IdLoggedIn)
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
