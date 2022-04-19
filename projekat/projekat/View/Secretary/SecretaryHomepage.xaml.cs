﻿using System;
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
using projekat.View.ModelView;

namespace projekat.View.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryHomepage.xaml
    /// </summary>
    public partial class SecretaryHomepage : Window
    {
        public SecretaryHomepage()
        {
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
    }
}