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
    public class UserRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _UserrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public UserRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _UserrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<User> Users)
        {
            return Users.Count() == 0 ? 0 : Users.Max(User => User.Id);
        }


        public User AddUser(User User)
        {
            User.Id = ++_UserrMaxId;
            AppendLineToFile(_path, ConvertUserToCSVFormat(User));
            return User;
        }

        public User GetUser(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(User => User.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public User FindUserByUsername(string username)
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

        public User UpdateUser(User User)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\User.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertUserToCSVFormat(User);
                    User tempApp = ConvertCSVFormatToUser(line);
                    if (User.Id != tempApp.Id)
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
            File.Delete(_file);
            File.Move(temp_file, _file);



            return User;
        }




        public Boolean RemoveUser(uint id)
        {
            Boolean retVal = false;
            IEnumerable<User> Users = GetAll();

            Users = Users.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempUser.txt";
            string User_file = _projectPath + "\\Resources\\user.txt";

            using (var sr = new StreamReader(User_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    User User = ConvertCSVFormatToUser(line);
                    if (User.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(User_file);
            File.Move(temp_file, User_file);

            return retVal;
        }




        public IEnumerable<User> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToUser)
             .ToList();
        }

        private User ConvertCSVFormatToUser(string UserCSVFormat)
        {
            User User = new User();
            string[] tokens = UserCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Username = tokens[1];
            string Password = tokens[2];
            string Name = tokens[3];
            string Surname = tokens[4];
            string Adress = tokens[5];
            string Email = tokens[6];

            Enum.TryParse(tokens[8], out Gender gender);
            Enum.TryParse(tokens[9], out Role role);
            Enum.TryParse(tokens[10], out Specialization specialization);
            // DateTime.Parse(tokens[8]);

            return new User(
                Id,
                Name,
                Surname,
                DateTime.Parse(tokens[7]),
                specialization,
                Adress,
                Email,
                gender,
                Username,
                Password,
                role
            );

        }


        private string ConvertUserToCSVFormat(User User)
        {
            return string.Join(_delimeter,
                User.Id,
                User.Username,
                User.Password,
                User.Name,
                User.Surname,
                User.Adress,
                User.Email,
                User.DateOfBirth,
                User.Gender,
                User.Role,
                User.Specialization
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
