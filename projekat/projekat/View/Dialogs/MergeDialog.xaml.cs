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
    /// Interaction logic for MergeDialog.xaml
    /// </summary>
    public partial class MergeDialog : Window
    {
        private RoomControler _roomController;
        public string time;
        public string time_end;
        public string date;
        public string date_end;

        DateTime date_time;
        DateTime date_time_end;

        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<string> RoomTypes { get; set; }
        public MergeDialog()
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _roomController = app.RoomControler;

            Rooms = new ObservableCollection<Room>(_roomController.GetAll().ToList());
            Rooms_1.ItemsSource = Rooms;
            Rooms_2.ItemsSource = Rooms;

            RoomTypes = new ObservableCollection<string>(GetTypes());
        }

        private IList<string> GetTypes()
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

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                time = cboitem.Content.ToString();
                date = DP1.Text;

                date_time = DateTime.Parse(date + " " + time);
            }
        }

        private void DP1_SelectedDateChanged_Copy(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP1.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                time_end= cboitem.Content.ToString();
                //t2 = cboitem2.Content.ToString();
                date_end = DP1.Text;

                date_time_end = DateTime.Parse(date_end + " " + time_end);
                // dt_end = DateTime.Parse(d + " " + t2);
            }

        }

        private void MergeButton_Click(object sender, RoutedEventArgs e)
        {
            Room room_1 = Rooms_1.SelectedItem as Room;
            Room room_2 = Rooms_2.SelectedItem as Room;

            Room new_room = new Room();

            DateTime start_date = date_time;
            DateTime end_date = date_time_end;
            uint squareFootage = room_1.SquareFootage + room_2.SquareFootage;


            if (isMergePossible(room_1, room_2))
            {
                string room_name = Room_name.Text;
                RoomType roomType = FindRoom(Client.SelectedItem.ToString());

                _roomController.DeleteRoom(room_1.Id);
                _roomController.DeleteRoom(room_2.Id);

                new_room.Name = room_name;
                new_room.Type = roomType;
                new_room.SquareFootage = squareFootage;
                new_room.Availability = true;
                new_room = _roomController.CreateNewRoom(new_room);
                SetRenovation(new_room.Id, start_date, end_date);
                
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("This rooms cant be merged because they are in use!!!");
            }



        }

        private void SetRenovation(uint id, DateTime start, DateTime end)
        {
            RoomRenovationDTO dto = new RoomRenovationDTO(id, start, end);
            Success();
        }

        private void Success()
        {
            MessageBoxResult result = MessageBox.Show("Merge succesfully done");
        }
        

        private Boolean isMergePossible(Room room1, Room room2)
        {
            bool retVal = false;
            int counter = 0;
            retVal = _roomController.AvailableForDeletion(room1.Id);
            if (retVal == false)
            {
                counter++;
            }
            retVal = _roomController.AvailableForDeletion(room2.Id);
            if(retVal == false)
            {
                counter++;
            }

            if(counter > 0)
            {
                return false;
            }

            return true;
                  
            
        }
    }
}
