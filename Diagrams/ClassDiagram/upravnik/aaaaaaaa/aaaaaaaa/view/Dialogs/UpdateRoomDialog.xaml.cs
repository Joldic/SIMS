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
using aaaaaaaa.model;
using aaaaaaaa.controller;
using aaaaaaaa.view.Model;
using System.Text.RegularExpressions;
using aaaaaaaa.view.Converter;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace aaaaaaaa.view.Dialogs
{
    /// <summary>
    /// Interaction logic for UpdateRoomDialog.xaml
    /// </summary>
    public partial class UpdateRoomDialog : Window
    {

        private const string ERROR_MESSAGE = "All fields are mandatory, please fill them!";
        private const string DATE_FORMAT_ERROR_MESSAGE = "Invalid date format. Valid format is: 15.05.2020. !";
        private const string INVALID_DEADLINE_ERROR_MESSAGE = "Invalid deadline value. Valid date starts from next month!";
        private static readonly Regex _decimalRegex = new Regex("[^0-9.-]+");

        private DataView _dataView;
        private string _roomName;
        private RoomType _roomType;
        private uint _squareFootage;

        private uint _id;

        public uint Id_to_change { get; set; }

        private RoomController _roomController;

        public UpdateRoomDialog()
        {
            InitializeComponent();
            DataContext = this;
            _dataView = (Application.Current.MainWindow as MainWindow).GetDataView();
            var app = Application.Current as App;
            _roomController = app.RoomController;

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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //UpdateDataView(UpdateRoom());
                UpdateRoom();
                Close();
                
            }
            catch
            {

            }

        }

        private Room UpdateRoom()
        {
            try
            {
                return _roomController.ChangeRoom(new Room(
                    Id_to_change,
                    _roomName,
                    _roomType,
                    _squareFootage));
            }
            catch
            {
                throw;
            }

        }

        private void UpdateDataView(Room room)
        {
           // _dataView.Data.Add(RoomConverter.ConvertRoomToRoomView(room));
          
        }

        private bool IsTextDecimal(string input) => !_decimalRegex.IsMatch(input);

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
