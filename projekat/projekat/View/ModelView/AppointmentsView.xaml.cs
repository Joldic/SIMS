using System;
using System.Collections;
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
using Caliburn.Micro;
using Controller;
using Model;
using Prism.Commands;
using projekat.Controller;
using projekat.View.Converter;
using projekat.View.Dialogs;

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

        public string t;
        public string d;
        DateTime dt;

        public ObservableCollection<Appointment> Data { get; set; }

        public ObservableCollection<Model.Patient> People { get; set; }

        public ObservableCollection<Doctor> Doc { get; set; }

        public AppointmentsView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _roomController = app.RoomControler;
            _doctorController = app.DoctorController;
            _patientControler = app.PatientControler;

            People = new ObservableCollection<Model.Patient>(_patientControler.GetAll()); //**********************************************

            Data = new ObservableCollection<Appointment>(_appointmentController.GetAll().ToList());

            Patients.ItemsSource = People;

            for (int i = 0; i < Data.Count(); i++)
            {
                Room room = _roomController.FindRoom(Data[i].IdRoom);
                Doctor doctor = _doctorController.ReadDoctor(Data[i].IdDoctor);
                Model.Patient patient = _patientControler.ReadPatient(Data[i].IdPatient);
                Data[i].RoomName = room.Name;
                Data[i].DoctorName = doctor.Name;
                Data[i].DoctorSurname = doctor.Surname;
                Data[i].PatientUsername = patient.Username;
                Data[i].PatientName = patient.Name;
                Data[i].PatientSurname = patient.Surname;

                DataGridXAML.Items.Add(Data[i]);
        
            }


            // DataContext = this.Data;
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
            Appointment ap = DataGridXAML.SelectedItem as Appointment;
            Appointment temp = _appointmentController.GetApointment(ap.Id);

            new UpdateAppointment(temp)
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

        private void Appointment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            if(cboitem.Content != null)
            {
                t = cboitem.Content.ToString();
                d = DP1.Text;
               // MessageBoxResult result;
                //result = MessageBox.Show(d);
                dt = DateTime.Parse(d + " " + t);
                 MessageBoxResult result;
                result = MessageBox.Show(dt.ToString());
            }
        }

   



        private void OK_ButtonClick(object sender, RoutedEventArgs e)
        {
           // string patientUsername = (string)Patients.SelectedItem;
            Model.Patient patientItem = Patients.SelectedItem as Model.Patient;
            string patientUsername = patientItem.Username;

            Doctor doctorItem = Doctors.SelectedItem as Doctor;
            string doctorUsername = doctorItem.Username;

            DateTime date = dt;

            Model.Patient p = _patientControler.FindPatientByUsername(patientUsername);
            Doctor doc = _doctorController.FindDoctorByUsername(doctorUsername);

            string[] words = t.Split(':');
            string minutes = words[1];
            int numVal = int.Parse(minutes);
            numVal += 15;
            string final_minutes = words[0] + ":" + numVal.ToString();
            DateTime end_date = DateTime.Parse(d + " " + final_minutes);

            Appointment appointment = new Appointment(date, end_date, doc.Id, p.Id, 1);  //id sobe smo fiksirali
            _appointmentController.CreateNewAppointment(appointment);
            Room room = _roomController.FindRoom(1);


            appointment.RoomName = room.Name;
            appointment.DoctorName = doc.Name;
            appointment.DoctorSurname = doc.Surname;
            appointment.PatientName = p.Name;
            appointment.PatientSurname = p.Surname;


            DataGridXAML.Items.Add(appointment);


        }

     

  

        /* private void Button_Click(object sender, RoutedEventArgs e)
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
        */
    }
}
