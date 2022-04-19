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
using Prism.Commands;
using projekat.Controller;
using projekat.View.Converter;

namespace projekat.View.ModelView
{
    /// <summary>
    /// Interaction logic for AppointmentsView.xaml
    /// </summary>
    public partial class AppointmentsView : Window
    {
        private AppointmentController _appointmentController;
        private RoomControler _roomController;
        private DoctorController _doctorController;
        private PatientControler _patientControler;


        private uint _id;
        private DateTime _startAppointment;
        private DateTime _endAppointment;
        private uint _doctorId;
        private uint _patientId;
        private uint _roomId;
        private uint _idDelete;

        public ObservableCollection<Appointment> Data { get; set; }
        public AppointmentsView()
        {
            InitializeComponent();
            //DataContext = this.Data;
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _roomController = app.RoomControler;
            _doctorController = app.DoctorController;
            _patientControler = app.PatientControler;
            
           // Data = new ObservableCollection<Window>(
           // AppointmentConverter.ConvertAppointmentListToAppointmentViewList(_appointmentController.GetAll().ToList()));

            Data = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());
           // DataGridXAML.ItemsSource = Data;
            for (int i = 0; i < Data.Count(); i++)
            {
                Room room = _roomController.FindRoom(Data[i].IdRoom);
                Doctor doctor = _doctorController.ReadDoctor(Data[i].IdDoctor);
                Patient patient = _patientControler.ReadPatient(Data[i].IdPatient);
                Data[i].RoomName = room.Name;
                Data[i].DoctorName = doctor.Name;
                Data[i].DoctorSurname = doctor.Surname;
                Data[i].PatientName = patient.Name;
                Data[i].PatientSurname = patient.Surname;

                DataGridXAML.Items.Add(Data[i]);
        
            }
                
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

        public uint IdDelete
        {
            get => _idDelete;
            set
            {
                if (_idDelete != value)
                {
                    _idDelete = value;
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
            InitializeComponent();
            DataContext = this;

            Appointment ap = DataGridXAML.SelectedItem as Appointment;
            _appointmentController.DeleteApointment(ap.Id);

            for (int i = 0; i < Data.Count(); i++)
            {
                if (Data[i].Id == ap.Id)
                {
                    DataGridXAML.Items.Remove(Data[i]);
                }
            }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = IdToDelete.Text;
            uint ID = uint.Parse(content);

            _appointmentController.DeleteApointment(ID);

            for (int i = 0; i < Data.Count(); i++)
            {
                if(Data[i].Id == ID)
                {
                    DataGridXAML.Items.Remove(Data[i]);
                }
            }

        }
    }
}
