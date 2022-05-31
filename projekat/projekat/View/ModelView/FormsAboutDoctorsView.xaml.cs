using Model;
using projekat.Controller;
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
    /// Interaction logic for FormsAboutDoctorsView.xaml
    /// </summary>
    public partial class FormsAboutDoctorsView : Window
    {
        private FormController _formController;
        private DoctorController _doctorController;

        public ObservableCollection<FormDoctorDTO> Data { get; set; }
        public ObservableCollection<Doctor> Doc { get; set; }


        public FormsAboutDoctorsView()
        {
            InitializeComponent();
            DataContext = this;

            var app = Application.Current as App;
            _formController = app.FormController;
            _doctorController = app.DoctorController;

            Doc = new ObservableCollection<Doctor>(_doctorController.GetAll());


            Doctors.ItemsSource = Doc;

        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAML.Items.Clear();
            Doctor doctor = Doctors.SelectedItem as Doctor;
            Data = new ObservableCollection<FormDoctorDTO>(_formController.GetAllDoctorForms().ToList());


            for (int i=0; i<Data.Count(); i++)
            {
                if(Data[i].DoctorId == doctor.Id)
                {
                    DataGridXAML.Items.Add(Data[i]);
                }
            }
        }
    }
}
