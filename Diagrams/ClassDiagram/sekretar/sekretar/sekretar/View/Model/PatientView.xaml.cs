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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using sekretar.Model;
using sekretar.Controller;
using sekretar.View.Converter;
using sekretar.View.Dialogs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace sekretar.View.Model
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        private PatientController _patientController;
        private string _patientName;
        private string _patientSurname;
        private string _patientAdress;
        private string _patientEmail;
        private Gender _patientGender;
        private DateTime _patientDateOfBirth;
        private uint _id;

        public ObservableCollection<UserControl> Data { get; set; }

        public PatientView()
        {
            InitializeComponent();
            DataContext = this;
        }

       
        public string PatientName
        {
            get => _patientName;
            set
            {
                if (_patientName != value)
                {
                    _patientName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PatientSurname
        {
            get => _patientSurname;
            set
            {
                if (_patientSurname != value)
                {
                    _patientSurname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PatientAdress
        {
            get => _patientAdress;
            set
            {
                if (_patientAdress != value)
                {
                    _patientAdress = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PatientEmail
        {
            get => _patientEmail;
            set
            {
                if (_patientEmail != value)
                {
                    _patientEmail = value;
                    OnPropertyChanged();
                }
            }
        }

        public Gender PatientGender
        {
            get => _patientGender;
            set
            {
                if (_patientGender != value)
                {
                    _patientGender = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime PatientDateOfBirth
        {
            get => _patientDateOfBirth;
            set
            {
                if (_patientDateOfBirth != value)
                {
                    _patientDateOfBirth = value;
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



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            InitializeComponent();
            DataContext = this;

            var app = Application.Current as App;
            _patientController = app.PatientController;
            Patient patient = _patientController.ReadPatient(Id);

            _patientController.DeletePatient(Id);

            Data = new ObservableCollection<UserControl>(
               PatientConverter.ConvertPatientListToPatientViewList(_patientController.GetAll().ToList()));


        }




        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            new UpdatePatientDialog
            {
                Owner = Application.Current.MainWindow,
                Id_to_change = Id
            }
            .ShowDialog();

        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
