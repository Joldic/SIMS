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
using System.Windows.Navigation;
using System.Windows.Shapes;
using aaaaaaaa.view.Dialogs;

namespace aaaaaaaa.view.Util
{
    /// <summary>
    /// Interaction logic for MenuSideBar.xaml
    /// </summary>
    public partial class MenuSideBar : UserControl
    {
        public MenuSideBar()
        {
            InitializeComponent();
        }

        private void AddLoan_Click(object sender, RoutedEventArgs e)
        {
            new AddRoomDialog
            {
                Owner = Application.Current.MainWindow
            }
                .ShowDialog();
        }
    }
}
