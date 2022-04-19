﻿using projekat.Controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using projekat.Repository;
using projekat.Service;
using Controller;
using Repository;
using Service;

namespace projekat
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
        private string ROOM_FILE = _projectPath + "\\Resources\\room.txt";
        private string USER_FILE = _projectPath + "\\Resources\\user.txt";
        private string APPOINTMENT_FILE = _projectPath + "\\Resources\\appointment.txt";

        private const string CSV_DELIMITER = ";";
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";



 

        public SecretaryController SecretaryController { get; set; }
        public AppointmentController AppointmentController { get; set; }

        public App()
        {



            var appointmentRepo = new AppointmentRepository(APPOINTMENT_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var secretaryRepo = new SecretaryRepository(USER_FILE, CSV_DELIMITER, DATETIME_FORMAT);


     
            var secretaryService = new SecretaryService(secretaryRepo);
            var appointmentService = new AppointmentService(appointmentRepo);
        

            SecretaryController = new SecretaryController(secretaryService);
            AppointmentController = new AppointmentController(appointmentService);
        }
    }
}
