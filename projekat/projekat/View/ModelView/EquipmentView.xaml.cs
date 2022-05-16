using Model;
using projekat.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for EquipmentView.xaml
    /// </summary>
    public partial class EquipmentView : Window
    {
        private uint _id;
        private EquipmentController _equipmentController;
        private string _name;
        private EquipmentType _type;
        private uint _quantity;
        private string _textToFilter;

        public ObservableCollection<Equipment> Data { get; set; }

        public EquipmentView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _equipmentController = app.EquipmentController;


            Data = new ObservableCollection<Equipment>(_equipmentController.GetAll().ToList());



            for (int i = 0; i < Data.Count(); i++)
            {
                DataGridXAML.Items.Add(Data[i]);
            }
        }

        public uint Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

   

        public EquipmentType tYPE
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      
    }
}
