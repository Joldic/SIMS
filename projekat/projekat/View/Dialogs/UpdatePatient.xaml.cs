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

namespace projekat.View.Dialogs
{
    /// <summary>
    /// Interaction logic for UpdatePatient.xaml
    /// </summary>
    public partial class UpdatePatient : Window  
    {
        private PatientControler _patientController;
        public ObservableCollection<string> Genders { get; set; }

        private string _patientName;
        private string _patientSurname;
        private DateTime _patientBirthDate;
        private Gender _patientGender;
        private string _patientAdress;
        private string _patientEmail;
        private Model.Patient temp;

        public string d;
    
        public UpdatePatient(Model.Patient patient)
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _patientController = app.PatientControler;


            temp = patient;

            Genders = new ObservableCollection<string>(FindGender());
        }

        private IList<string> FindGender()
        {
            List<string> ret_val = new List<string>();
            ret_val.Add(Gender.m.ToString());
            ret_val.Add(Gender.f.ToString());

            return ret_val;
        }
        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
                           
                d = DP1.Text;
                _patientBirthDate = DateTime.Parse(d);
            
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            _patientName = Name.Text;
            _patientSurname = Surname.Text;
            _patientAdress = Adress.Text;
            _patientEmail = Email.Text;

            _patientGender = FindGender(Client.SelectedItem.ToString());


            temp.Name = _patientName;
            temp.Surname = _patientSurname;
            temp.Adress = _patientAdress;
            temp.Email = _patientEmail;
            temp.Gender = _patientGender;
            temp.DateOfBirth = _patientBirthDate;

            _patientController.UpdatePatient(temp);
             

        }

        public Gender FindGender(string _patientGender)
        {
            if (Gender.m.ToString() == _patientGender)
            {
                return Gender.m;
            }
            else
            {
                return Gender.f;
            }
        }
    }
}
