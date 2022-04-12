using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using aaaaaaaa.model;
using aaaaaaaa.controller;
using aaaaaaaa.view.Converter;
using aaaaaaaa.view.Dialogs;
using System.Collections.ObjectModel;
using System.Linq;

namespace aaaaaaaa.view.Model
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl
    {
        private string _roomName;
        private RoomController _roomController;
        private DataView _dataView;
        private RoomType _roomType;
        private uint _squareFootage;
        private uint _id;

        public ObservableCollection<UserControl> Data { get; set; }
        public RoomView()
        {
            InitializeComponent();
            DataContext = this;
            //_dataView = (Application.Current.MainWindow as MainWindow).GetDataView();
        }

        public string RoomName
        {
            get => _roomName;
            set
            {
                if (_roomName != value)
                {
                    _roomName = value;
                    OnPropertyChanged();
                }
            }
        }

        public RoomType RoomType
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            InitializeComponent();

            DataContext = this;

            

            var app = Application.Current as App;
            _roomController = app.RoomController;
            Room room = _roomController.FindRoom(Id);


            _roomController.DeleteRoom(Id);

           // InitializeComponent();
           
             
        

            Data = new ObservableCollection<UserControl>(
               RoomConverter.ConvertRoomListToRoomViewList(_roomController.GetAll().ToList()));

            // Room room = _roomController.FindRoom(Id);


        }


      

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
           
            new UpdateRoomDialog
            {
                Owner = Application.Current.MainWindow,
                Id_to_change = Id
            }
            .ShowDialog();
          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
