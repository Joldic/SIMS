using Controller;
using Model;
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

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for SeperateDialog.xaml
    /// </summary>
    public partial class SeperateDialog : Window
    {
        private RoomControler _roomController;
        private uint _id;
        private uint _squareFootage;
        private string _name;
        private RoomType _roomType;

        public ObservableCollection<string> RoomTypes { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public SeperateDialog()
        {
            InitializeComponent();
            DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomControler;

            RoomTypes = new ObservableCollection<string>(GetRooms());
            Rooms = new ObservableCollection<Room>(_roomController.GetAll().ToList());

            Rooms_tb.ItemsSource = Rooms;

        }

        private IList<string> GetRooms()
        {
            List<string> ret_val = new List<string>();
            ret_val.Add(RoomType.operatingRoom.ToString());
            ret_val.Add(RoomType.relaxationRoom.ToString());
            ret_val.Add(RoomType.ordinaryRoom.ToString());

            return ret_val;
        }

        public RoomType FindRoom(string _room_type)
        {
            if (RoomType.operatingRoom.ToString() == _room_type)
            {
                return RoomType.operatingRoom;
            }
            else if (RoomType.relaxationRoom.ToString() == _room_type)
            {
                return RoomType.relaxationRoom;
            }
            else
            {
                return RoomType.ordinaryRoom;
            }
        }

        private void SeperateButton_Click(object sender, RoutedEventArgs e)
        {
            Room room = Rooms_tb.SelectedItem as Room;
            if (_roomController.AvailableForDeletion(room.Id))
            {
                CreateNewRooms(room);
            }
            else
            {
                ShowError();
            }
        }
        private void CreateNewRooms(Room room)
        {
            _roomController.DeleteRoom(room.Id);

            string room1_name = Room1_name.Text;
            uint room1_square_ft = uint.Parse(Room1_square_footage.Text);
            RoomType room1_Type = FindRoom(Client1.SelectedItem.ToString());
            Room room1 = new Room(room1_name, room1_Type, room1_square_ft, true);

            string room2_name = Room2_name.Text;
            uint room2_square_ft = uint.Parse(Room2_square_footage.Text);
            RoomType room2_type = FindRoom(Client2.SelectedItem.ToString());
            Room room2 = new Room(room2_name, room2_type, room2_square_ft, true);
            _roomController.CreateNewRoom(room1);
            _roomController.CreateNewRoom(room2);

            Success();
        }
        private void ShowError()
        {
            MessageBoxResult result = MessageBox.Show("Room can't be seperated because it's in use!!!");
        }

        private void Success()
        {
            MessageBoxResult result = MessageBox.Show("Seperation executed");
        }
    }
}
