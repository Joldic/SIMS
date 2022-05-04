using Controller;
using Model;
using projekat.View.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : Window   
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

        public ObservableCollection<Model.Patient> People { get; set; }

        public PatientView()
        {
            InitializeComponent();
            DataContext = this;

            var app = Application.Current as App;
            _patientController = app.PatientControler;

            People = new ObservableCollection<Model.Patient>(_patientController.GetAll().ToList());


            for(int i=0; i< People.Count(); i++)
            {
                DataGridXAML.Items.Add(People[i]);
            }

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
            string[] words = d.Split('/');
            string new_date = "";
            new_date += words[1] + "/" + words[0] + "/" + words[2];
            //MessageBoxResult result = MessageBox.Show(new_date);
            _patientBirthDate = DateTime.Parse(d);

        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            DataContext = this;

            Model.Patient patient = DataGridXAML.SelectedItem as Model.Patient;
            

            for(int i=0; i<People.Count(); i++)
            {
                if(People[i].Id == patient.Id)
                {
                    DataGridXAML.Items.Remove(People[i]);
                }
            }

            _patientController.DeletePatient(patient.Id);

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Patient patient = DataGridXAML.SelectedItem as Model.Patient;
            Model.Patient tempPatient = _patientController.ReadPatient(patient.Id);

            new UpdatePatient(tempPatient)
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();

            this.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _patientName = Name.Text;
            _patientSurname = Surname.Text;
            _patientAdress = Adress.Text;
            _patientEmail = Email.Text;

            _patientGender = FindGender(Client.SelectedItem.ToString());

            string username = _patientName;
            Random rnd = new Random();
            username += rnd.Next(0, 9).ToString();
            username += rnd.Next(0, 9).ToString();
            username += rnd.Next(0, 9).ToString();

            Model.Patient p = new Model.Patient(_patientName, _patientSurname, _patientBirthDate, _patientAdress,  _patientEmail, _patientGender, "123", username);
            Model.Patient x = _patientController.CreateNewPatient(p);

            DataGridXAML.Items.Add(x);

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

        private void AllergensButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Patient patient = DataGridXAML.SelectedItem as Model.Patient;
            Model.Patient tempPatient = _patientController.ReadPatient(patient.Id);

            new AllergensView(tempPatient)
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();

            this.Close();
        }
    }
}
