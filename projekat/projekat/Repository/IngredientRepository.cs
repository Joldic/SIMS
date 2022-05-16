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
    public class IngredientRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _ingredientMaxId;
        private uint _ingredientDTOMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private FileStream temp;

        private String fileName;

        public IngredientRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _ingredientMaxId = GetMaxId(GetAll());
        }



        private uint GetMaxId(IEnumerable<Ingredient> ingredients)
        {
            return ingredients.Count() == 0 ? 0 : ingredients.Max(ingredient => ingredient.Id);
        }

   


        public IEnumerable<Ingredient> GetAll()
        {
            return File.ReadAllLines(_path)
                  .Select(ConvertCSVFormatToIngredient)
                  .ToList();
        }



        public Model.Ingredient CreateNewIngredient(Model.Ingredient ingredient)
        {
            ingredient.Id = ++_ingredientMaxId;
            AppendLineToFile(_path, ConvertIngredientToCSVFormat(ingredient));
            return ingredient;
        }





        public Model.Ingredient GetIngredient(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(ingredient => ingredient.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }



        public Model.Ingredient UpdateIngredient(Model.Ingredient ingredient)
        {
            string temp_file = _projectPath + "\\Resources\\tempALR.txt";
            string _file = _projectPath + "\\Resources\\ingredient.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertIngredientToCSVFormat(ingredient);
                    Ingredient tempApp = ConvertCSVFormatToIngredient(line);
                    if (ingredient.Id != tempApp.Id)
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



            return ingredient;
        }




        public Boolean DeleteIngredient(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Ingredient> ingredients = GetAll();

            ingredients = ingredients.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempAlr.txt";
            string ingredient_file = _projectPath + "\\Resources\\ingredient.txt";

            using (var sr = new StreamReader(ingredient_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Ingredient ingredient = ConvertCSVFormatToIngredient(line);
                    if (ingredient.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(ingredient_file);
            File.Move(temp_file, ingredient_file);

            return retVal;
        }






        //public Boolean DeletePatiensIngredient(uint id)
        //{
        //    Boolean retval = false;

        //    string temp_file = _projectPath + "\\Resources\\tempPatAler.txt";
        //    string patientIngredients_file = _projectPath + "\\Resources\\PatientIngredient.txt";

        //    using (var sr = new StreamReader(patientIngredients_file))
        //    using (var sw = new StreamWriter(temp_file))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            PatientIngredientDTO patientAll = ConvertCSVFormatToPatientIngredient(line);
        //            if (patientAll.Id != id)
        //            {
        //                retval = true;
        //                sw.WriteLine(line);
        //            }
        //        }
        //    }

        //    File.Delete(patientIngredients_file);
        //    File.Move(temp_file, patientIngredients_file);

        //    return retval;
        //}



        private Ingredient ConvertCSVFormatToIngredient(string ingredientCSVFormat)
        {
            Ingredient ingredient = new Ingredient();
            string[] tokens = ingredientCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Name = tokens[1];

            return new Ingredient(
                Id,
                Name
            );

        }

      


  

        private string ConvertIngredientToCSVFormat(Ingredient ingredient)
        {
            return string.Join(_delimeter,
                ingredient.Id,
                ingredient.Name
            );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
