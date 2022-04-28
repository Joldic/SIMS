using Controller;
using Model;
using projekat.Controller;
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
    /// Interaction logic for OperationsView.xaml
    /// </summary>
    public partial class OperationsView : Window
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

        public string t;
        public string t2;
        public string d;
        DateTime dt;
        DateTime dt_end;

        public ObservableCollection<Appointment> Data { get; set; }

        public ObservableCollection<Patient> People { get; set; }

        public ObservableCollection<Doctor> Doc { get; set; }


        public OperationsView()
        {
            InitializeComponent();
            InitializeComponent();
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _roomController = app.RoomControler;
            _doctorController = app.DoctorController;
            _patientControler = app.PatientControler;

            People = new ObservableCollection<Patient>(_patientControler.GetAll()); //**********************************************

            Data = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());

            Patients.ItemsSource = People;

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

            Doc = new ObservableCollection<Doctor>(_doctorController.GetAll());

            Doctors.ItemsSource = Doc;

            Appointment ap = DataGridXAML.SelectedItem as Appointment;
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
            _appointmentController.DeleteOperation(ap.Id);

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
            Appointment ap = DataGridXAML.SelectedItem as Appointment;
            Appointment temp = _appointmentController.GetApointment(ap.Id);

            new UpdateOperation(temp)
            {
                Owner = Application.Current.MainWindow
            }
                .ShowDialog();
            this.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            ComboBoxItem cboitem2 = cboTP_Copy.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                t = cboitem.Content.ToString();
                t2 = cboitem2.Content.ToString();
                d = DP1.Text;
                
                dt = DateTime.Parse(d + " " + t);
                dt_end = DateTime.Parse(d + " " + t2);
            }
        }


        private void OK_ButtonClick(object sender, RoutedEventArgs e)
        {
            Patient patientItem = Patients.SelectedItem as Patient;
            string patientUsername = patientItem.Username;

            Doctor doctorItem = Doctors.SelectedItem as Doctor;
            string doctorUsername = doctorItem.Username;

            DateTime date_begin = dt;
            DateTime date_end = dt_end;

            Patient p = _patientControler.FindPatientByUsername(patientUsername);
            Doctor doc = _doctorController.FindDoctorByUsername(doctorUsername);


            Appointment appointment = new Appointment(date_begin, date_end, doc.Id, p.Id, 2);       //id sobe smo fiksirali
            _appointmentController.CreateNewOperation(appointment);

            Room room = _roomController.FindRoom(2);

            appointment.RoomName = room.Name;
            appointment.DoctorName = doctorUsername;
            appointment.DoctorSurname = doc.Surname;
            appointment.PatientName = p.Name;
            appointment.PatientSurname = p.Surname;


            DataGridXAML.Items.Add(appointment);

        }

    }

    
}
