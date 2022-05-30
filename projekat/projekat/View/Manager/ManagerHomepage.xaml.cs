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

namespace projekat.View.Manager
{
    /// <summary>
    /// Interaction logic for ManagerHomepage.xaml
    /// </summary>
    public partial class ManagerHomepage : Window
    {
        private uint _id_logged_in;
        public ManagerHomepage(uint id)
        {

            _id_logged_in = id;


            InitializeComponent();
            DataContext = this;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void RenovationButton_Click(object sender, RoutedEventArgs e)
        {
            new RenovationDialog()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void EquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            new EquipmentView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void RoomButton_Click(object sender, RoutedEventArgs e)
        {
            new RoomView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void RealocationButton_Click(object sender, RoutedEventArgs e)
        {
            new EquipmentRelocation()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void DrugsButton_Click(object sender, RoutedEventArgs e)
        {
            new DrugsView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
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

        private void MergeButton_Click(object sender, RoutedEventArgs e)
        {
            new MergeDialog()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }

        private void SeparateButton_Click(object sender, RoutedEventArgs e)
        {
            new SeperateDialog()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }

        private void InvalidDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            new InvalidDrugsView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }
    }
}
