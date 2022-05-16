using Model;
using projekat.Controller;
using projekat.View.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace projekat.View.ModelView
{
    /// <summary>
    /// Interaction logic for DrugsView.xaml
    /// </summary>
    public partial class DrugsView : Window
    {
        private uint _id;
        private DrugController _drugController;
        private string _name;
        public ObservableCollection<Drug> Data { get; set; }
        public DrugsView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _drugController = app.DrugController;

            Data = new ObservableCollection<Drug>(_drugController.GetAll().ToList());

            for (int i=0; i < Data.Count; i++)
            {
                DataGridXAML.Items.Add(Data[i]);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {


            Drug ap = DataGridXAML.SelectedItem as Drug;
            _drugController.DeleteDrug(ap.Id);

            for (int i = 0; i < Data.Count(); i++)
            {
                if (Data[i].Id == ap.Id)
                {
                    DataGridXAML.Items.Remove(Data[i]);
                }
            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {


            Model.Drug drug = DataGridXAML.SelectedItem as Model.Drug;
            Model.Drug tempDrug = _drugController.FindDrug(drug.Id);

            new UpdateDrug(tempDrug)
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();

            this.Close();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = Name_tb.Text;
            uint Weight = uint.Parse(Weight_tb.Text);
            string Category = Category_tb.Text;
            uint Quantity = uint.Parse(Quantity_tb.Text);
            Drug drug = new Drug(Name, Weight, Category, Quantity);

            _drugController.CreateNewDrug(drug);

            DataGridXAML.Items.Add(drug);

        }

        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {
            Model.Drug drug = DataGridXAML.SelectedItem as Model.Drug;
            Model.Drug tempDrug = _drugController.FindDrug(drug.Id);

            new IngredientsView(tempDrug)
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();

            this.Close();

        }


    }
}
