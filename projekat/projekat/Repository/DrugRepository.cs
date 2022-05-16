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
    public class DrugRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _DrugrMaxId;
        private uint _dtoMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public DrugRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _DrugrMaxId = GetMaxId(GetAll());
            _dtoMaxId = GetMaxIdDrugIngredient(GetDrugIngredients());
        }

        private uint GetMaxId(IEnumerable<Drug> Drugs)
        {
            return Drugs.Count() == 0 ? 0 : Drugs.Max(drug => drug.Id);
        }

        private uint GetMaxIdDrugIngredient(IEnumerable<DrugIngredientDTO> dto)
        {
            return dto.Count() == 0 ? 0 : dto.Max(dtos => dtos.Id);
        }

        public Drug AddDrug(Drug Drug)
        {
            Drug.Id = ++_DrugrMaxId;
            AppendLineToFile(_path, ConvertDrugToCSVFormat(Drug));
            return Drug;
        }

        public DrugIngredientDTO AddDrugIngredient(DrugIngredientDTO dto)
        {
            dto.Id = ++_dtoMaxId;
            string path_dto = _projectPath + "\\Resources\\DrugIngredient.txt";
            AppendLineToFile(path_dto, ConvertDrugIngredientToCSVFormat(dto));
            return dto;
        }

        public Drug GetDrug(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(Drug => Drug.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public IEnumerable<DrugIngredientDTO> GetDrugIngredients()
        {
            string path_to_file = _projectPath + "\\Resources\\DrugIngredient.txt";
            return File.ReadAllLines(path_to_file)
                .Select(ConvertCSVFormatToDrugIngredient).ToList();

        }

        public DrugIngredientDTO AddDrugIngredients(DrugIngredientDTO dto)
        {
            dto.Id = ++_dtoMaxId;
            string path_dto = _projectPath + "\\Resources\\DrugIngredient.txt";
            AppendLineToFile(path_dto, ConvertDrugIngredientToCSVFormat(dto));
            return dto;
        }

        public Drug FindDrugByDrugname(string username)
        {
            try
            {
                return GetAll().SingleOrDefault(user => user.Name == username);
            }
            catch (ArgumentException)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "username", username));
            }
        }

        public Drug UpdateDrug(Drug Drug)
        {
            string temp_file = _projectPath + "\\Resources\\tempDR.txt";
            string _file = _projectPath + "\\Resources\\drug.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertDrugToCSVFormat(Drug);
                    Drug tempApp = ConvertCSVFormatToDrug(line);
                    if (Drug.Id != tempApp.Id)
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



            return Drug;
        }


        public Boolean DeleteDrugIngredient(uint id)
        {
            Boolean retVal = false;
            string temp_file = _projectPath + "\\Resources\\tempDrugIng.txt";
            string Drug_file = _projectPath + "\\Resources\\DrugIngredient.txt";

            using (var sr = new StreamReader(Drug_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    DrugIngredientDTO dto = ConvertCSVFormatToDrugIngredient(line);
                    if (dto.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(Drug_file);
            File.Move(temp_file, Drug_file);

            return retVal;
        }

        public Boolean RemoveDrug(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Drug> Drugs = GetAll();

            Drugs = Drugs.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempDrug.txt";
            string Drug_file = _projectPath + "\\Resources\\drug.txt";

            using (var sr = new StreamReader(Drug_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Drug Drug = ConvertCSVFormatToDrug(line);
                    if (Drug.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(Drug_file);
            File.Move(temp_file, Drug_file);

            return retVal;
        }




        public IEnumerable<Drug> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToDrug)
             .ToList();
        }

        private Drug ConvertCSVFormatToDrug(string DrugCSVFormat)
        {
            Drug Drug = new Drug();
            string[] tokens = DrugCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Name = tokens[1];
            uint Weight = uint.Parse(tokens[2]);
            string Category = tokens[3];
            uint Quantity = uint.Parse(tokens[4]);


            return new Drug(
                Id,
                Name,
                Weight,
                Category,
                Quantity
            );

        }

        private DrugIngredientDTO ConvertCSVFormatToDrugIngredient(string csvFormav)
        {
            DrugIngredientDTO dto = new DrugIngredientDTO();
            string [] tokens = csvFormav.Split(_delimeter.ToCharArray());
            uint Id = uint.Parse(tokens[0]);
            uint DrugId = uint.Parse(tokens[1]);
            uint IngredientId = uint.Parse(tokens[2]);
            string Name = tokens[3];

            return new DrugIngredientDTO(
                Id,
                DrugId,
                IngredientId,
                Name
                );
        }

        private string ConvertDrugIngredientToCSVFormat(DrugIngredientDTO dto)
        {
            return string.Join(_delimeter,
                dto.Id,
                dto.DrugId,
                dto.IngredientId,
                dto.Name
                );
        }


        private string ConvertDrugToCSVFormat(Drug Drug)
        {
            return string.Join(_delimeter,
                Drug.Id,
                Drug.Name,
                Drug.Weight,
                Drug.Category,
                Drug.Quantity
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
