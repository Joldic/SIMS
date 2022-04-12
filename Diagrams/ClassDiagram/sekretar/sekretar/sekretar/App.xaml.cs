using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using sekretar.Controller;
using sekretar.Repository;
using sekretar.Service;

namespace sekretar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
         .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private string CLIENT_FILE = _projectPath + "\\Resources\\Data\\clients.csv";
        private string ACCOUNT_FILE = _projectPath + "\\Resources\\Data\\accounts.csv";
        private string LOAN_FILE = _projectPath + "\\Resources\\Data\\loans.csv";
        private string TRANSACTION_FILE = _projectPath + "\\Resources\\Data\\transactions.csv";
        private string ROOM_FILE = _projectPath + "\\Resources\\patients.txt";
        private const string CSV_DELIMITER = ";";
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";



        public PatientController PatientController { get; set; }

        public App()
        {


            var patientRepo = new PatientRepository(ROOM_FILE, CSV_DELIMITER, DATETIME_FORMAT);



            var patientService = new PatientService(patientRepo);


            PatientController = new PatientController(patientService);
        }
    }
}
