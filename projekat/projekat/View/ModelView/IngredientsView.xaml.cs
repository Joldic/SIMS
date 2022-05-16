using Model;
using projekat.Controller;
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
    /// Interaction logic for IngredientsView.xaml
    /// </summary>
    public partial class IngredientsView : Window
    {
        private Drug drug;
        private DrugController _drugController;
        private IngredientController _ingredientController;

        public ObservableCollection<DrugIngredientDTO> DrugIngredients { get; set; }
        public ObservableCollection<Ingredient> NameOfIngredients { get; set; }

        public IngredientsView(Drug temp)
        {
            InitializeComponent();
            var app = Application.Current as App;
            _drugController = app.DrugController;
            _ingredientController = app.IngredientController;

            DrugIngredients = new ObservableCollection<DrugIngredientDTO>(_drugController.GetDrugIngredients().ToList());


            drug = temp;

            for(int i=0; i < DrugIngredients.Count(); i++)
            {
                if(drug.Id == DrugIngredients[i].DrugId)
                {
                    DataGridXAML.Items.Add(DrugIngredients[i]);
                }
            }

            NameOfIngredients = new ObservableCollection<Ingredient>(_ingredientController.GetAll().ToList());
            Names.ItemsSource = NameOfIngredients;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //DrugIngredientDTO drugIngredient = DataGridXAML.SelectedItem as DrugIngredientDTO;
            Ingredient ingredientItem = Names.SelectedItem as Ingredient;
            string ingredientName = ingredientItem.Name;
            uint ingredientId = ingredientItem.Id;

            DrugIngredientDTO newDto = new DrugIngredientDTO(drug.Id, ingredientId, ingredientName);
            DrugIngredientDTO createdDto = _drugController.AddDrugIngredient(newDto);

            DataGridXAML.Items.Add(createdDto);


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DrugIngredientDTO selectedItem = DataGridXAML.SelectedItem as DrugIngredientDTO;

            for(int i=0; i< DrugIngredients.Count; i++)
            {
                if(selectedItem.Id == DrugIngredients[i].Id)
                {
                    DataGridXAML.Items.Remove(DrugIngredients[i]);
                }
            }

            _drugController.DeleteDrugIngredient(selectedItem.Id);
        }
    }
}
