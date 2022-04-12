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
using System.Windows.Navigation;
using System.Windows.Shapes;
using sekretar.Controller;
using sekretar.View.Converter;

namespace sekretar.View.Model
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        private PatientController _patientController;

        public ObservableCollection<UserControl> Data { get; set; }

        public DataView()
        {
            InitializeComponent();

            DataContext = this;
            var app = Application.Current as App;
            _patientController = app.PatientController;

            Data = new ObservableCollection<UserControl>(
               PatientConverter.ConvertPatientListToPatientViewList(_patientController.GetAll().ToList()));
        }
    }
}
