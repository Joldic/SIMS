using System;
using Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lekar.Exception;

namespace Repository
{
   public class PatientRepository
   {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _roomMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public PatientRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _roomMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Patient> patients)
        {
            return patients.Count() == 0 ? 0 : patients.Max(patient => patient.Id);
        }

        public Patient GetPatient(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(patient => patient.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public IEnumerable<Patient> GetAll()
        {
            return File.ReadAllLines(_path)
                .Select(ConvertCSVFormatToPatient)
                .ToList();
        }




        public Patient UpdatePatient(Patient patient)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string patient_file = _projectPath + "\\Resources\\patients.txt";

            using (var sr = new StreamReader(patient_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertPatientToCSVFormat(patient);
                    Patient tempPatient = ConvertCSVFormatToPatient(line);
                    if (patient.Id != tempPatient.Id)
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
            File.Delete(patient_file);
            File.Move(temp_file, patient_file);

            return patient;
        }

        public Boolean RemovePatient(uint id)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string patient_file = _projectPath + "\\Resources\\patients.txt";
            Boolean retVal = false;
            using (var sr = new StreamReader(patient_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Patient patient = ConvertCSVFormatToPatient(line);
                    if (patient.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(patient_file);
            File.Move(temp_file, patient_file);

            return retVal;
        }

        public Patient AddPatient(Patient patient)
        {
            patient.Id = ++_roomMaxId;
            AppendLineToFile(_path, ConvertPatientToCSVFormat(patient));
            return patient;

        }




        private Patient ConvertCSVFormatToPatient(string patientCSVFormat)
        {
            Patient patient = new Patient();
            string[] tokens = patientCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Name = tokens[1];
            string Surname = tokens[2];
            string Adress = tokens[3];
            string Email = tokens[4];
            Enum.TryParse(tokens[5], out Gender gender);
            DateTime.Parse(tokens[6]);

            return new Patient(
                Id,
                Name,
                Surname,
                Adress,
                Email,
                gender,
                DateTime.Parse(tokens[6])

            );


        }

        private string ConvertPatientToCSVFormat(Patient patient)
        {
            return string.Join(_delimeter,
                patient.Id,
                patient.Name,
                patient.Surname,
                patient.Adress,
                patient.Email,
                patient.Gender,
                patient.DateOfBirth);

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}