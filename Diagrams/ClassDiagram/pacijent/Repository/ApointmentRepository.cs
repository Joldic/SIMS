using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using lekar.Exception;
namespace Repository
{
   public class ApointmentRepository
   {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _appointmentMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public ApointmentRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _appointmentMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(List<Appointment> appointments)
        {
            return appointments.Count() == 0 ? 0 : appointments.Max(appointment => appointment.IdAppointment);
        }

        public Appointment GetAppointment(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(appointment => appointment.IdAppointment == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public List<Appointment> GetAll()
        {
            return File.ReadAllLines(_path)
                .Select(ConvertCSVFormatToAppointment)
                .ToList();
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string appointment_file = _projectPath + "\\Resources\\appointments.txt";

            using (var sr = new StreamReader(appointment_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertAppointmentToCSVFormat(appointment);
                    Appointment tempAppointment = ConvertCSVFormatToAppointment(line);
                    if (appointment.IdAppointment != tempAppointment.IdAppointment)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(lineToWrite);
                    }
                    //sw.WriteLine(lineToWrite);
                }
            }
            File.Delete(appointment_file);
            File.Move(temp_file, appointment_file);

            return appointment;
        }

        public Boolean RemoveAppointment(uint id)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string appointment_file = _projectPath + "\\Resources\\appointments.txt";
            Boolean retVal = false;
            using (var sr = new StreamReader(appointment_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Appointment appointment = ConvertCSVFormatToAppointment(line);
                    if (appointment.IdAppointment != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(appointment_file);
            File.Move(temp_file, appointment_file);

            return retVal;
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            appointment.IdAppointment = ++_appointmentMaxId;
            AppendLineToFile(_path, ConvertAppointmentToCSVFormat(appointment));
            return appointment;

        }

        private Appointment ConvertCSVFormatToAppointment(string appointmentCSVFormat)
        {
            Appointment appointment = new Appointment();
            string[] tokens = appointmentCSVFormat.Split(_delimeter.ToCharArray());

            return new Appointment(
            uint.Parse(tokens[0]),
            DateTime.Parse(tokens[1]),
            DateTime.Parse(tokens[2]),
            new Doctor(uint.Parse(tokens[3])),
            new Patient(uint.Parse(tokens[4]))              
            );


        }

        private string ConvertAppointmentToCSVFormat(Appointment appointment)
        {
            return string.Join(_delimeter,
                appointment.IdAppointment,
                appointment.StartAppointment,
                appointment.EndAppointment,
                appointment.doctor,
                appointment.patient);
                
        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }



}
        
