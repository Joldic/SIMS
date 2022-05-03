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
using projekat.View.Dialogs;
using projekat.View.ModelView;

namespace projekat.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryHomepage.xaml
    /// </summary>
    public partial class SecretaryHomepage : Window
    {
        public uint _id_logged_in;
        public SecretaryHomepage(uint id)
        {

            _id_logged_in = id;

            InitializeComponent();
            DataContext = this;
        }

    

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            new AppointmentsView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
           
        }


        private void Operations_Click(object sender, RoutedEventArgs e)
        {
            new OperationsView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

    

        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            new PatientView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();

        }

        private void Guesst_Click(object sender, RoutedEventArgs e)
        {
            new GuesstAccount()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _id_logged_in = 555;
            new MainWindow()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }
    }
}
