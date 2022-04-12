using aaaaaaaa.controller;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using aaaaaaaa.repository;
using aaaaaaaa.service;

namespace aaaaaaaa
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
        private const string CSV_DELIMITER = ";";
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";

     

        public RoomController RoomController { get; set; }

        public App()
        {
          

            var roomRepo = new RoomRepository(ROOM_FILE, CSV_DELIMITER, DATETIME_FORMAT);

       

            var roomService = new RoomService(roomRepo);


            RoomController = new RoomController(roomService);
        }
    }
}
