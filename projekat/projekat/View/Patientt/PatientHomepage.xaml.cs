using projekat.View.Dialogs;
using projekat.View.ModelView;
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

namespace projekat.View.Patientt
{
    /// <summary>
    /// Interaction logic for ManagerHomepage.xaml
    /// </summary>
    public partial class PatientHomepage : Window
    {
        private uint _id_logged_in;
        public PatientHomepage(uint id)
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
    }
}
