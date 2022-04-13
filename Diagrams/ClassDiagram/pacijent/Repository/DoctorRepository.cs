using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using lekar.Exception;
using Model;

namespace lekar.Repository
{
    public class DoctorRepository
    {

        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _doctorMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public DoctorRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _doctorMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(List<Doctor> doctors)
        {
            return doctors.Count() == 0 ? 0 : doctors.Max(doctor => doctor.IdDoctor);
        }

        public Doctor GetDoctor(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(doctor => doctor.IdDoctor == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public List<Doctor> GetAll()
        {
            return File.ReadAllLines(_path)
                .Select(ConvertCSVFormatToDoctor)
                .ToList();
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string doctor_file = _projectPath + "\\Resources\\doctors.txt";

            using (var sr = new StreamReader(doctor_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertDoctorToCSVFormat(doctor);
                    Doctor tempDoctor = ConvertCSVFormatToDoctor(line);
                    if (doctor.IdDoctor != tempDoctor.IdDoctor)
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
            File.Delete(doctor_file);
            File.Move(temp_file, doctor_file);

            return doctor;
        }

        public Boolean RemoveDoctor(uint id)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string doctor_file = _projectPath + "\\Resources\\doctors.txt";
            Boolean retVal = false;
            using (var sr = new StreamReader(doctor_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Doctor doctor = ConvertCSVFormatToDoctor(line);
                    if (doctor.IdDoctor != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(doctor_file);
            File.Move(temp_file, doctor_file);

            return retVal;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            doctor.IdDoctor = ++_doctorMaxId;
            AppendLineToFile(_path, ConvertDoctorToCSVFormat(doctor));
            return doctor;

        }

        private Doctor ConvertCSVFormatToDoctor(string doctorCSVFormat)
        {
            Doctor doctor = new Doctor();
            string[] tokens = doctorCSVFormat.Split(_delimeter.ToCharArray());

            uint IdDoctor = uint.Parse(tokens[0]);
            string Name = tokens[1];
            string Surname = tokens[2];
            DateTime.Parse(tokens[3]);
            Enum.TryParse(tokens[5], out Specialization specialization);

            return new Doctor(
                IdDoctor,
                Name,
                Surname,              
                DateTime.Parse(tokens[6]),
                specialization

            );

        }

        private string ConvertDoctorToCSVFormat(Doctor doctor)
        {
            return string.Join(_delimeter,
                doctor.IdDoctor,
                doctor.Name,
                doctor.Surname,
                doctor.DateOfBirth,
                doctor.Specialization);

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }








    }
}
