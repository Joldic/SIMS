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
    public class EquipmentRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _equipmentMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;


        public EquipmentRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _equipmentMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Equipment> equipments)
        {
            return equipments.Count() == 0 ? 0 : equipments.Max(equipment => equipment.Id);
        }


        public Equipment GetEquipment(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(equipment => equipment.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public Equipment UpdateEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public Boolean RemoveEquipment(uint id)
        {
            throw new NotImplementedException();
        }

        public Equipment AddEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> GetAll()
        {
            return File.ReadAllLines(_path)
                  .Select(ConvertCSVFormatToEquipment)
                  .ToList();
        }

        private Equipment ConvertCSVFormatToEquipment(string equipmentCSVFormat)
        {
            Equipment equipment = new Equipment();
            string[] tokens = equipmentCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            uint Quantity = uint.Parse(tokens[1]);
            string Name = tokens[2];
            Enum.TryParse(tokens[3], out EquipmentType type);

            return new Equipment(
                Id,
                Quantity,
                Name,
                type
            );


        }

        private string ConvertEquipmentToCSVFormat(Equipment equipment)
        {
            return string.Join(_delimeter,
                equipment.Id,
                equipment.Quantity,
                equipment.Name,
                equipment.Type
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
