using Controller;
using Model;
using projekat.Controller;
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
    /// Interaction logic for UpdateOperation.xaml
    /// </summary>
    public partial class UpdateOperation : Window
    {
        private Appointment temp;
        private AppointmentController _appointmentController;
        private RoomControler _roomController;
        private DoctorController _doctorController;
        private PatientControler _patientControler;


        /*private uint _id;
        private DateTime _startAppointment;
        private DateTime _endAppointment;
        private uint _doctorId;
        private uint _patientId;
        private uint _roomId;
        private uint _idDelete;
        */

        public string t;
        public string t2;
        public string d;
        DateTime dt;
        DateTime dt_end;

        public ObservableCollection<Patient> Pat { get; set; }

        public ObservableCollection<Doctor> Doc { get; set; }


        public UpdateOperation(Appointment appointment )
        {
            InitializeComponent();
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _roomController = app.RoomControler;
            _doctorController = app.DoctorController;
            _patientControler = app.PatientControler;

            temp = appointment;

            Pat = new ObservableCollection<Patient>(_patientControler.GetAll());
            Doc = new ObservableCollection<Doctor>(_doctorController.GetAll());

            Patients.ItemsSource = Pat;
            Doctors.ItemsSource = Doc;
            DataContext = this;
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
                // MessageBoxResult result;
                //result = MessageBox.Show(d);
                dt = DateTime.Parse(d + " " + t);
                dt_end = DateTime.Parse(d + " " + t2);
                //MessageBoxResult result;
                //result = MessageBox.Show(dt.ToString());
            }
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Patient patientItem = Patients.SelectedItem as Patient;
            string patientUsername = patientItem.Username;

            Doctor doctorItem = Doctors.SelectedItem as Doctor;
            string doctorUsername = doctorItem.Username;

            DateTime date_begin = dt;
            DateTime date_end = dt_end;

            Patient p = _patientControler.FindPatientByUsername(patientUsername);
            Doctor doc = _doctorController.FindDoctorByUsername(doctorUsername);


            Appointment appointment = new Appointment(temp.Id, date_begin, date_end, doc.Id, p.Id, temp.IdRoom);     
            _appointmentController.UpdateOperation(appointment);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
