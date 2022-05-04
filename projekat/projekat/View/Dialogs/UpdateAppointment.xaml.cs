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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        private string patient_username;
        private string doctor_username;
        private Appointment temp;
        private AppointmentController _appointmentController;
        private RoomControler _roomController;
        private DoctorController _doctorController;
        private PatientControler _patientControler;

        public string t;
        public string d;
        DateTime dt;

        public ObservableCollection<Model.Patient> Pat { get; set; }

        public ObservableCollection<Model.Doctor> Doc { get; set; }
        public UpdateAppointment(Appointment appointment)
        {
            InitializeComponent();
            var app = Application.Current as App;
            _appointmentController = app.AppointmentController;
            _roomController = app.RoomControler;
            _doctorController = app.DoctorController;
            _patientControler = app.PatientControler;
         
        //DataContext = this;
        //patient_username = appointment.PatientUsername;
        //doctor_username = appointment.DoctorUsername;
        //Patient_username.Text = appointment.PatientUsername;
        //Doctor_username.Text = appointment.DoctorUsername;
        temp = appointment;

            Pat = new ObservableCollection<Model.Patient>(_patientControler.GetAll());
            Doc = new ObservableCollection<Doctor>(_doctorController.GetAll());

            Patients.ItemsSource = Pat;
            Doctors.ItemsSource = Doc;
            DataContext = this;
        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
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

            Appointment appointment = new Appointment(temp.Id,date, end_date, doc.Id, p.Id, temp.IdRoom);
            _appointmentController.UpdateApointment(appointment);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
