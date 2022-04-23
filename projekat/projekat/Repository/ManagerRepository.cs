using Model;
using projekat.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Repository
{
    public class ManagerRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _managerMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public ManagerRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _managerMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Manager> managers)
        {
            return managers.Count() == 0 ? 0 : managers.Max(manager => manager.Id);
        }


        public Manager AddManager(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Manager GetManager(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(manager => manager.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public Manager FindManagerByUsername(string username)
        {
            try
            {
                return GetAll().SingleOrDefault(user => user.Username == username);
            }
            catch (ArgumentException)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "username", username));
            }
        }

        public Manager UpdateManager(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Boolean RemoveManager(uint id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToManager)
             .ToList();
        }

        private Manager ConvertCSVFormatToManager(string managerCSVFormat)
        {
            Manager manager = new Manager();
            string[] tokens = managerCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Username = tokens[1];
            string Password = tokens[2];
            string Name = tokens[3];
            string Surname = tokens[4];
            string Adress = tokens[5];
            string Email = tokens[6];
            Enum.TryParse(tokens[7], out Gender gender);
            DateTime.Parse(tokens[8]);
            Enum.TryParse(tokens[9], out Specialization spec);

            return new Manager(
                Id,
                Username,
                Password,
                Name,
                Surname,
                Adress,
                Email,
                gender,
                DateTime.Parse(tokens[8])
            );


        }

        private string ConvertManagerToCSVFormat(Manager manager)
        {
            return string.Join(_delimeter,
                manager.Id,
                manager.Username,
                manager.Password,
                manager.Name,
                manager.Surname,
                manager.Adress,
                manager.Email,
                manager.Gender,
                manager.DateOfBirth);

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
