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
    /// Interaction logic for InvalidDrugsView.xaml
    /// </summary>
    public partial class InvalidDrugsView : Window
    {
        private DrugController _drugController;

        public ObservableCollection<Drug> Data { get; set; }
        
        public InvalidDrugsView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _drugController = app.DrugController;

            Data = new ObservableCollection<Drug>(_drugController.GetAllInvalidDrugs().ToList());

            for(int i= 0; i < Data.Count; i++)
            {
                DataGridXAML.Items.Add(Data[i]);
            }
            


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {


            //Drug ap = DataGridXAML.SelectedItem as Drug;
            //_drugController.DeleteDrug(ap.Id);

            //for (int i = 0; i < Data.Count(); i++)
            //{
            //    if (Data[i].Id == ap.Id)
            //    {
            //        DataGridXAML.Items.Remove(Data[i]);
            //    }
            //}

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            Drug drug = DataGridXAML.SelectedItem as Drug;
            _drugController.DeleteInvalidDrug(drug.Id);

            new UpdateDrug(drug)
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
            this.Close();
        }
    }
}
