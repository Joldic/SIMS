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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
        

        }
    }
}
