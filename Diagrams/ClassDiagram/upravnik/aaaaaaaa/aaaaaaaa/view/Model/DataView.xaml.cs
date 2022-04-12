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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using aaaaaaaa.controller;
using aaaaaaaa.view.Converter;

namespace aaaaaaaa.view.Model
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        private RoomController _roomController;
        public ObservableCollection<UserControl> Data { get; set; }
        public DataView()
        {
            InitializeComponent();

            DataContext = this;
            var app = Application.Current as App;
            _roomController = app.RoomController;

            Data = new ObservableCollection<UserControl>(
               RoomConverter.ConvertRoomListToRoomViewList(_roomController.GetAll().ToList()));

            //RoomConverter
               // .ConvertRoomListToRoomViewList(_roomController.GetAll().ToList())
               // .ToList()
              //  .ForEach(Data.Add);
        }
    }
}
