using Model;
using Controller;
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
using System.Collections.ObjectModel;

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : Window
    {
        private string name;
        private uint quantity;
        private RoomControler _roomController;
        public EquipmentRelocation()
        {
            InitializeComponent();
            DataContext = this;

            var app = Application.Current as App;
            _roomController = app.RoomControler;
        }


        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAML.Items.Clear();
            name = Name.Text;
            quantity = uint.Parse(Quantityy.Text);
            IList<RoomEquipmentDTO> temp = new List<RoomEquipmentDTO>();

            IEnumerable<RoomEquipmentDTO> room_equipment_list = _roomController.GetAllRoomAndEquipment();
            var Data = new ObservableCollection<RoomEquipmentDTO>();

            foreach (RoomEquipmentDTO room_equipment in room_equipment_list)
            {
                int result = (int)room_equipment.Quantity - (int)quantity;
                if (room_equipment.EquipmentName == name & result >= 0)
                {
                    //MessageBoxResult result = MessageBox.Show(room_equipment.RoomName);
                    Data.Add(room_equipment);
                    room_equipment.Quantity -= quantity;
                }
                temp.Add(room_equipment);
            }

            for (int i = 0; i < Data.Count(); i++)
            {
                DataGridXAML.Items.Add(Data[i]);
            }



        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
