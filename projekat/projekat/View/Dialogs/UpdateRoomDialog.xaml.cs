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
    /// Interaction logic for UpdateRoomDialog.xaml
    /// </summary>
    public partial class UpdateRoomDialog : Window
    {
        private RoomControler _roomController;
        private Room tempRoom;
        private uint _id;
        private uint _squareFootage;
        private string _name;
        private RoomType _roomType;

        
        public ObservableCollection<string> RoomTypes { get; set; }
        public UpdateRoomDialog(Room room)
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _roomController = app.RoomControler;

            tempRoom = room;

            RoomTypes = new ObservableCollection<string>(FindRoom());
        }

        private IList<string> FindRoom()
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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string room_name = Room_name.Text;
            RoomType roomType = FindRoom(Client.SelectedItem.ToString());
            uint square_footage = uint.Parse(Square_footage.Text);
            Boolean availability = true;

            //Room room = new Room(room_name, roomType, square_footage, availability);
            tempRoom.Name = room_name;
            tempRoom.Type = roomType;
            tempRoom.SquareFootage = square_footage;
            tempRoom.Availability = availability;
            _roomController.ChangeRoom(tempRoom);

        }
    }
}
