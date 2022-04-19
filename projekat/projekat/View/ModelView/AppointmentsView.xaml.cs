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
using Controller;
using Model;
using projekat.View.Converter;

namespace projekat.View.ModelView
{
    /// <summary>
    /// Interaction logic for AppointmentsView.xaml
    /// </summary>
    public partial class AppointmentsView : Window
    {
        private AppointmentController _appointmentController;
        private uint _id;
        private DateTime _startAppointment;
        private DateTime _endAppointment;
        private uint _doctorId;
        private uint _patientId;
        private uint _roomId;

        public ObservableCollection<Appointment> Data { get; set; }
        public AppointmentsView()
        {
            InitializeComponent();
            //DataContext = this.Data;
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;

           // Data = new ObservableCollection<Window>(
           // AppointmentConverter.ConvertAppointmentListToAppointmentViewList(_appointmentController.GetAll().ToList()));

            Data = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());
            DataContext = this.Data;

        }

        public DateTime StartAppointment
        {
            get => _startAppointment;
            set
            {
                if (_startAppointment != value)
                {
                    _startAppointment = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime EndAppointment
        {
            get => _endAppointment;
            set
            {
                if (_endAppointment != value)
                {
                    _endAppointment = value;
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

        public uint IdDoctor
        {
            get => _doctorId;
            set
            {
                if (_doctorId != value)
                {
                    _doctorId = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint IdPatient
        {
            get => _patientId;
            set
            {
                if (_patientId != value)
                {
                    _patientId = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint IdRoom
        {
            get => _roomId;
            set
            {
                if (_roomId != value)
                {
                    _roomId = value;
                    OnPropertyChanged();
                }
            }
        }





        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Appointment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
