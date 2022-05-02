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

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for RenovationDialog.xaml
    /// </summary>
    public partial class RenovationDialog : Window
    {
        private RoomControler _roomController;
        public string t;
        public string t2;
        public string d;
        public string d2;
        DateTime dt;
        DateTime dt_end;

        public ObservableCollection<Room> Roomss { get; set; }
        public RenovationDialog()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _roomController = app.RoomControler;

            Roomss = new ObservableCollection<Room>(_roomController.GetAll().ToList());
            Rooms.ItemsSource = Roomss;

        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                t = cboitem.Content.ToString();
                //t2 = cboitem2.Content.ToString();
                d = DP1.Text;

                dt = DateTime.Parse(d + " " + t);
               // dt_end = DateTime.Parse(d + " " + t2);
            }

        }

        private void DP1_SelectedDateChanged_Copy(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP1.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                t2 = cboitem.Content.ToString();
                //t2 = cboitem2.Content.ToString();
                d2 = DP1.Text;

                dt_end = DateTime.Parse(d + " " + t2);
                // dt_end = DateTime.Parse(d + " " + t2);
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room roomItem = Rooms.SelectedItem as Room;
            DateTime date_begin = dt;
            DateTime date_end = dt_end;

            RoomRenovationDTO dto = new RoomRenovationDTO(roomItem.Id , date_begin, date_end);

            _roomController.AddRenovation(dto);
            MessageBoxResult result = MessageBox.Show("Uspesno zakazano renoviranje");


        }
    }
}
