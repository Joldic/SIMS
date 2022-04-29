using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projekat.View.ModelView
{
    /// <summary>
    /// Interaction logic for AllergensView.xaml
    /// </summary>
    public partial class AllergensView : Window
    {
        private Patient patientTemp;
        private AllergenController _allergenController;



        public ObservableCollection<PatientAllergenDTO> PatientAllergens { get; set; }





        public AllergensView(Patient patient)
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            _allergenController = app.AllergenControler;

            PatientAllergens = new ObservableCollection<PatientAllergenDTO>(_allergenController.GetPatientsAllergens().ToList());

            patientTemp = patient;

            for(int i=0; i< PatientAllergens.Count; i++)
            {
                if(patientTemp.Id == PatientAllergens[i].PatientId)
                {
                    DataGridXAML.Items.Add(PatientAllergens[i]);
                }
            }

        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
