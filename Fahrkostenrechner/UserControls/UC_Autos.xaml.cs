using System;
using System.Collections.Generic;
using System.IO;
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
using Fahrkostenrechner.Model;
using Fahrkostenrechner.Service;
using Newtonsoft.Json;


namespace Fahrkostenrechner.UserControls
{
    /// <summary>
    /// Interaction logic for Autos.xaml
    /// </summary>
    public partial class Autos : UserControl
    {
        //private List<CarData> carDataList;
        private CarService carService;

        public Autos()
        {
            InitializeComponent();
            carService = new CarService();
            carService.LoadCarData();
           // LoadCarData();
            BindDivisions();
        }
        //private void LoadCarData()
        //{
        //    string json = File.ReadAllText("C:\\Users\\49176\\source\\repos\\Fahrkostenrechner\\Fahrkostenrechner\\Data\\CarData.json");
        //    carDataList = JsonConvert.DeserializeObject<List<CarData>>(json);
        //}

        private void BindDivisions()
        {
            var divisions = carService.GetDivisions();
            DivisionComboBox.ItemsSource = divisions;
        }
        private void DivisionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDivision = DivisionComboBox.SelectedItem as string;
            if (selectedDivision != null)
            {
                var carlines = carService.GetCarLines(selectedDivision);
                CarlineComboBox.ItemsSource = carlines;
            }
        }

        private void CarlineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCarline = CarlineComboBox.SelectedItem as string;
            if (selectedCarline != null)
            {
                var carData = carService.GetCarData(selectedCarline);
                if (carData != null)
                {
                    label_city.Content = Math.Round(carData.City, 2).ToString();
                    label_hwy.Content = Math.Round(carData.Hwy, 2).ToString();
                    label_comb.Content = Math.Round(carData.Comb, 2).ToString();
                }
            }
        }
    }
}
