using Controller;
using Model;
using projekat.Controller;
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
using System.Windows.Shapes;

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for UpdateOperation.xaml
    /// </summary>
    public partial class UpdateOperation : Window
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
        public UpdateOperation(Appointment appointment )
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                t = cboitem.Content.ToString();
                d = DP1.Text;
              
                dt = DateTime.Parse(d + " " + t);
               
            }
        }
    }
}
