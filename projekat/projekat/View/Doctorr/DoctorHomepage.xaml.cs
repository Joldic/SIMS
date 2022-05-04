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

namespace projekat.View.Doctorr
{
    /// <summary>
    /// Interaction logic for DoctorHomepage.xaml
    /// </summary>
    public partial class DoctorHomepage : Window
    {
        private uint _id_logged_in;
        public DoctorHomepage(uint id)
        {
            _id_logged_in = id;


            InitializeComponent();
            DataContext = this;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            _id_logged_in = 555;
            new MainWindow()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
