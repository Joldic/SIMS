using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Repository
{
    public class RenovationRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private uint _renovationMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private FileStream temp;

        public RenovationRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;

            _renovationMaxId = GetMaxRenovationId(GetAllRenovation());

        }

        private uint GetMaxRenovationId(IEnumerable<RoomRenovationDTO> dtos)
        {
            return dtos.Count() == 0 ? 0 : dtos.Max(dto => dto.Id);
        }

        public IEnumerable<RoomRenovationDTO> GetAllRenovation()
        {
            string path_to_file = _projectPath + "\\Resources\\renovation.txt";
            return File.ReadAllLines(path_to_file)
                    .Select(ConvertCSVFormatToRoomRenovation)
                    .ToList();
        }

        public RoomRenovationDTO AddRenovation(RoomRenovationDTO r)
        {
            r.Id = ++_renovationMaxId;
            string path_to_file = _projectPath + "\\Resources\\renovation.txt";
            AppendLineToFile(path_to_file, ConvertRoomRenovationToCSVFormat(r));
            return r;
        }

        public RoomRenovationDTO ConvertCSVFormatToRoomRenovation(string CSVFormat)
        {
            Room room = new Room();
            string[] tokens = CSVFormat.Split(";".ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            uint RoomId = uint.Parse(tokens[1]);



            return new RoomRenovationDTO(
                Id,
                RoomId,
                DateTime.Parse(tokens[2]),
                DateTime.Parse(tokens[3])
            );
        }

        public string ConvertRoomRenovationToCSVFormat(RoomRenovationDTO dto)
        {
            return string.Join(";",
           dto.Id,
           dto.IdRoom,
           dto.Start,
           dto.End);

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
