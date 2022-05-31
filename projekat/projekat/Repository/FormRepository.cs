using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Repository
{
    public class FormRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _formHospitalMaxId;
        private uint _formDoctorMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        public FormRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _formDoctorMaxId = GetMaxIdFormDoctor(GetAllDoctorForms());
            _formHospitalMaxId = GetMaxIdFormHospital(GetAllHospitalForms());
        }

        private uint GetMaxIdFormDoctor(IEnumerable<FormDoctorDTO> forms)
        {
            return forms.Count() == 0 ? 0 : forms.Max(form => form.Id);
        }

        private uint GetMaxIdFormHospital(IEnumerable<FormHospitalDTO> forms)
        {
            return forms.Count() == 0 ? 0 : forms.Max(form => form.Id);
        }
        public IEnumerable<FormHospitalDTO> GetAllHospitalForms()
        {
            string path_to_file = _projectPath + "\\Resources\\FormHospital.txt";
            return File.ReadAllLines(path_to_file)
              .Select(ConvertCSVFormatToFormHospital)
              .ToList();
        }

        public IEnumerable<FormDoctorDTO> GetAllDoctorForms()
        {
            string path_to_file = _projectPath + "\\Resources\\FormDoctor.txt";
            return File.ReadAllLines(path_to_file)
              .Select(ConvertCSVFormatToFormDoctor)
              .ToList();
        }

        private FormHospitalDTO ConvertCSVFormatToFormHospital(string CSVformat)
        {
            string [] tokens = CSVformat.Split(_delimeter.ToCharArray());
            uint Id = uint.Parse(tokens[0]);
            uint FormId = uint.Parse(tokens[1]);
            uint Grade = uint.Parse(tokens[2]);
            uint PatientId = uint.Parse(tokens[3]);

            return new FormHospitalDTO(
                Id,
                FormId,
                Grade,
                PatientId
                );
        }

        private FormDoctorDTO ConvertCSVFormatToFormDoctor(string CSVformat)
        {
            string[] tokens = CSVformat.Split(_delimeter.ToCharArray());
            uint Id = uint.Parse(tokens[0]);
            uint FormId = uint.Parse(tokens[1]);
            uint Grade = uint.Parse(tokens[2]);
            uint PatientId = uint.Parse(tokens[3]);
            uint DoctorId = uint.Parse(tokens[4]);

            return new FormDoctorDTO(
                Id,
                FormId,
                Grade,
                PatientId,
                DoctorId
                );
        }


    }
}
