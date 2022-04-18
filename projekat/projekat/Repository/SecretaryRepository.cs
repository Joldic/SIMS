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
    public class SecretaryRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private uint _userMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public SecretaryRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _userMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Secretary> users)
        {
            return users.Count() == 0 ? 0 : users.Max(user => user.Id);
        }

        public Secretary GetSecretary(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(user => user.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public Secretary FindSecretaryByUsername(string username)
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

        public IEnumerable<Secretary> GetAll()
        {
            return File.ReadAllLines(_path)
                .Select(ConvertCSVFormatToSecretary)
                .ToList();
        }
        public Secretary CreateNewSecretary(Secretary secretary)
        {
            secretary.Id = ++_userMaxId;
            AppendLineToFile(_path, ConvertSecretaryToCSVFormat(secretary));
            return secretary;

        }

        private Secretary ConvertCSVFormatToSecretary(string roomCSVFormat)
        {
            Secretary user = new Secretary();
            string[] tokens = roomCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Username = tokens[1];
            string Password = tokens[2];
            string Name = tokens[3];
            string Surname = tokens[4];
            string Adress = tokens[5];
            string Email = tokens[6];
            Enum.TryParse(tokens[7], out Gender gender);
            DateTime.Parse(tokens[8]);
            Enum.TryParse(tokens[9], out Role role);

            return new Secretary(
                Id,
                Username,
                Password,
                Name,
                Surname,
                Adress,
                Email,
                gender,
                DateTime.Parse(tokens[8]),
                role
            );


        }

        private string ConvertSecretaryToCSVFormat(Secretary user)
        {
            return string.Join(_delimeter,
                user.Id,
                user.Username,
                user.Password,
                user.Name,
                user.Surname,
                user.Adress,
                user.Email,
                user.Gender,
                user.DateOfBirth,
                user.Role);
        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
