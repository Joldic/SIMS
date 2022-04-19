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
using projekat.View.Converter;
using Controller;
namespace projekat.View.ModelView
{
    /// <summary>
    /// Interaction logic for AppointmentDataView.xaml
    /// </summary>
    public partial class AppointmentDataView : Window
    {
        private AppointmentController _appointmentController;
        public ObservableCollection<Window> Data { get; set; }
        public AppointmentDataView()
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

            Data = new ObservableCollection<Window>(
            AppointmentConverter.ConvertAppointmentListToAppointmentViewList(_appointmentController.GetAll().ToList()));
        }
    }
}
