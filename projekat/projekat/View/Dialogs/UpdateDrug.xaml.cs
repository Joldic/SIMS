using Model;
using projekat.Controller;
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

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for UpdateDrug.xaml
    /// </summary>
    public partial class UpdateDrug : Window
    {
        private DrugController _drugController;
        private Drug drug;
        public UpdateDrug(Drug tempDrug)
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _drugController = app.DrugController;


            drug = tempDrug;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = Name_tb.Text;
            uint Weight = uint.Parse(Weight_tb.Text);
            string Category = Category_tb.Text;
            uint Quantity = uint.Parse(Quantity_tb.Text);

            drug.Name = Name;
            drug.Weight = Weight;
            drug.Quantity = Quantity;
            drug.Category = Category;

            _drugController.ChangeDrug(drug);
        }

        private void InvalidButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = Name_tb.Text;
            uint Weight = uint.Parse(Weight_tb.Text);
            string Category = Category_tb.Text;
            uint Quantity = uint.Parse(Quantity_tb.Text);

            drug.Name = Name;
            drug.Weight = Weight;
            drug.Quantity = Quantity;
            drug.Category = Category;

            _drugController.CreateNewDrug(drug);

        }
    }
}
