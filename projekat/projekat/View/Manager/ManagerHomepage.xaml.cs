﻿using projekat.View.Dialogs;
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
        public ManagerHomepage()
        {
            InitializeComponent();
            DataContext = this;
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
    }
}