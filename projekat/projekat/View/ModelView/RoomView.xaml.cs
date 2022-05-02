using Controller;
using Model;
using projekat.View.Dialogs;
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
        public ObservableCollection<string> RoomTypes { get; set; }

        public RoomView()
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _roomController = app.RoomControler;
   

            Data = new ObservableCollection<Room>(_roomController.GetAll().ToList());



            for (int i = 0; i < Data.Count(); i++)
            {
                DataGridXAML.Items.Add(Data[i]);
            }
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
            Room room = DataGridXAML.SelectedItem as Room;

            for(int i=0; i<Data.Count(); i++)
            {
                if(Data[i].Id == room.Id)
                {
                    DataGridXAML.Items.Remove(Data[i]);
                }
            }

            _roomController.DeleteRoom(room.Id);

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Room room = DataGridXAML.SelectedItem as Room;
            new UpdateRoomDialog(room)
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();

            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string room_name = Room_name.Text;
            RoomType roomType = FindRoom(Client.SelectedItem.ToString());
            uint square_footage = uint.Parse(Square_footage.Text);
            Boolean availability = true;

            Room room = new Room(room_name, roomType, square_footage, availability);
            Room x = _roomController.CreateNewRoom(room);

            DataGridXAML.Items.Add(x);

        }
    }
}
