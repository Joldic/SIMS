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
using sekretar.Model;
using sekretar.Controller;
using sekretar.View.Converter;
using sekretar.View.Dialogs;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using sekretar.View.Model;
using System.Text.RegularExpressions;
using sekretar.Exception;

namespace sekretar.View.Dialogs
{
    /// <summary>
    /// Interaction logic for UpdatePatientDialog.xaml
    /// </summary>
    public partial class UpdatePatientDialog : Window
    {

        private const string ERROR_MESSAGE = "All fields are mandatory, please fill them!";
        private const string DATE_FORMAT_ERROR_MESSAGE = "Invalid date format. Valid format is: 15.05.2020. !";
        private const string INVALID_DEADLINE_ERROR_MESSAGE = "Invalid deadline value. Valid date starts from next month!";
        private static readonly Regex _decimalRegex = new Regex("[^0-9.-]+");

        private PatientController _patientController;
        private DataView _dataView;
        private string _patientName;
        private string _patientSurname;
        private string _patientAdress;
        private string _patientEmail;
        private Gender _patientGender;
        private DateTime _patientDateOfBirth;
        private uint _id;

        public uint Id_to_change { get; set; }

        public UpdatePatientDialog()
        {
            InitializeComponent();
            DataContext = this;
            _dataView = (Application.Current.MainWindow as MainWindow).GetDataView();
            var app = Application.Current as App;
            _patientController = app.PatientController;
            DateOfBirth.Text = DateTime.Now.AddYears(0).ToString("dd.MM.yyyy.");
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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidDeadlineFormatDate())
            {
                ShowError(DATE_FORMAT_ERROR_MESSAGE);
            }

            else
            {
                try
                {
                    UpdatePatient();
                    Close();

                }
                catch (InvalidDateException error)
                {
                    ShowError(error.Message);
                }
            }

        }

      

        private bool IsValidDeadlineFormatDate()
        {
            if (!DateTime.TryParse(DateOfBirth.Text, out DateTime deadline))
            {
                return false;
            }
            else
            {
                _patientDateOfBirth = deadline;
                return true;
            }
        }

        private void ShowError(string s)
        {
            new MessageDialog(s, this).ShowDialog();
        }


        private Patient UpdatePatient()
        {
            try
            {
                return _patientController.UpdatePatient(new Patient(
                    Id_to_change,
                    _patientName,
                    _patientSurname,
                    _patientAdress,
                    _patientEmail,
                    _patientGender,
                    _patientDateOfBirth));
            }
            catch
            {
                throw;
            }

        }

        private void UpdateDataView(Patient patient)
        {

        }

        private bool IsTextDecimal(string input) => !_decimalRegex.IsMatch(input);

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
