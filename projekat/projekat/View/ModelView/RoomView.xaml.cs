using Controller;
using Model;
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
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : Window
    {
        private RoomControler _roomController;
        private uint _id;
        private uint _squareFootage;
        private string _name;
        private RoomType _roomType;

        public ObservableCollection<Room> Data { get; set; }


        public RoomView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _roomController = app.RoomControler;
   

            Data = new ObservableCollection<Room>(_roomController.GetAll().ToList());



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

        public uint SquareFootage
        {
            get => _squareFootage;
            set
            {
                if (_squareFootage != value)
                {
                    _squareFootage = value;
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

        public RoomType Type
        {
            get => _roomType;
            set
            {
                if (_roomType != value)
                {
                    _roomType = value;
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
