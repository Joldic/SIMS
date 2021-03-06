using projekat.Controller;
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
        private string ROOM_FILE = _projectPath + "\\Resources\\room.txt";
        private string USER_FILE = _projectPath + "\\Resources\\user.txt";
        private string MANAGER_FILE = _projectPath + "\\Resources\\manager.txt";
        private string DOCTOR_FILE = _projectPath + "\\Resources\\doctor.txt";
        private string PATIENT_FILE = _projectPath + "\\Resources\\patient.txt";
        private string APPOINTMENT_FILE = _projectPath + "\\Resources\\appointment.txt";
        private string EQUIPMENT_FILE = _projectPath + "\\Resources\\equipment.txt";
        private string ALLERGEN_FILE = _projectPath + "\\Resources\\allergen.txt";
        private string DRUG_FILE = _projectPath + "\\Resources\\drug.txt";
        private string INGREDIENT_FILE = _projectPath + "\\Resources\\ingredient.txt";
        private string RENOVATION_FILE = _projectPath + "\\Resources\\renovation.txt";
        private string FORM_FILE = _projectPath + "\\Resources\\form.txt";

        private const string CSV_DELIMITER = ";";
        private const string DATETIME_FORMAT = "dd.MM.yyyy.";



 

        public SecretaryController SecretaryController { get; set; }
        public AppointmentController AppointmentController { get; set; }
        public ManagerController ManagerController  { get; set; }

        public EquipmentController EquipmentController { get; set; }

        public RoomControler RoomControler { get; set; }

        public DoctorController DoctorController { get; set; }
        public PatientControler PatientControler { get; set; }
        public AllergenController AllergenControler { get; set; }

        public UserController UserController { get; set; }  

        public DrugController DrugController { get; set; }

        public IngredientController IngredientController { get; set; }

        public RenovationController RenovationController { get; set; }

        public FormController FormController { get; set; }

        public App()
        {



            var appointmentRepo = new AppointmentRepository(APPOINTMENT_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            //var secretaryRepo = new SecretaryRepository(USER_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var roomRepo = new RoomRepository(ROOM_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var doctorRepo = new DoctorRepository(DOCTOR_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var patientRepo = new PatientRepository(PATIENT_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var managerRepo = new ManagerRepository(MANAGER_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var equipmentRepo = new EquipmentRepository(EQUIPMENT_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var allergenRepo = new AllergenRepository(ALLERGEN_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var userRepo = new UserRepository(USER_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var drugRepo = new DrugRepository(DRUG_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var ingredientRepo = new IngredientRepository(INGREDIENT_FILE, CSV_DELIMITER, DATETIME_FORMAT);
            var renovationRepo = new RenovationRepository(RENOVATION_FILE, CSV_DELIMITER);
            var formRepo = new FormRepository(FORM_FILE, CSV_DELIMITER);
     
            //var secretaryService = new SecretaryService(secretaryRepo);
            var appointmentService = new AppointmentService(appointmentRepo);
            var roomService = new RoomService(roomRepo);
            var doctorService = new DoctorService(doctorRepo);
            var patientService = new PatientService(patientRepo);
            var managerService = new ManagerService(managerRepo);
            var equipmentService = new EquipmentService(equipmentRepo);
            var allergenService = new AllergenService(allergenRepo);
            var userService = new UserService(userRepo);
            var drugService = new DrugService(drugRepo);
            var ingredientService = new IngredientService(ingredientRepo);
            var renovationService = new RenovationService(renovationRepo);
            var formService = new FormService(formRepo);

            //SecretaryController = new SecretaryController(secretaryService);
            AppointmentController = new AppointmentController(appointmentService);
            RoomControler = new RoomControler(roomService);
            DoctorController = new DoctorController(doctorService);
            PatientControler = new PatientControler(patientService);
            ManagerController = new ManagerController(managerService);
            EquipmentController = new EquipmentController(equipmentService);
            AllergenControler = new AllergenController(allergenService);
            UserController = new UserController(userService);
            DrugController = new DrugController(drugService);
            IngredientController = new IngredientController(ingredientService);
            RenovationController = new RenovationController(renovationService);
            FormController = new FormController(formService);

        }
    }
}
