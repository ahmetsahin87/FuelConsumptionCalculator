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
using Fahrkostenrechner.Model1;
using Fahrkostenrechner.Service;
using Newtonsoft.Json;

namespace Fahrkostenrechner.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Fahrkosten.xaml
    /// </summary>
    public partial class UC_Fahrkosten : UserControl
    {
        private CarService carService;
        private ApiService apiService;
        public UC_Fahrkosten()
        {
            InitializeComponent();
            carService = new CarService();
            carService.LoadCarData();
            apiService = new ApiService();
            BindDivisions();
        }

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
            // You can add any additional logic here if needed
        }

        private async void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Step 1: Get the distance from Textbox_km
            if (!double.TryParse(Textbox_km.Text, out double distance))
            {
                MessageBox.Show("Please enter a valid distance.");
                return;
            }

            // Step 2: Get selected car data
            string selectedDivision = DivisionComboBox.SelectedItem as string;
            string selectedCarline = CarlineComboBox.SelectedItem as string;
            if (selectedDivision == null || selectedCarline == null)
            {
                MessageBox.Show("Please select a car division and carline.");
                return;
            }

            CarData carData = carService.GetCarData(selectedCarline);
            if (carData == null)
            {
                MessageBox.Show("Car data not found.");
                return;
            }

            // Step 3: Get the selected location value
            double consumption = 0;
            if (City.IsChecked == true)
            {
                consumption = carData.City;
            }
            else if (Hwy.IsChecked == true)
            {
                consumption = carData.Hwy;
            }
            else if (Comb.IsChecked == true)
            {
                consumption = carData.Comb;
            }

            // Step 4: Get the fuel price from the API
            string apiUrl = "https://creativecommons.tankerkoenig.de/json/list.php?lat=51.444&lng=6.980&rad=1&sort=dist&type=all&apikey=21cf9e03-a3aa-0547-5bf2-78bd6f69accd"; // Replace with your actual API URL
            Station firstStation = await apiService.GetFirstStationAsync(apiUrl);
            if (firstStation == null)
            {
                MessageBox.Show("Failed to retrieve fuel prices from the API.");
                return;
            }

            double fuelPrice = 0;
            if (radiobutton_benzin.IsChecked == true)
            {
                fuelPrice = firstStation.E5;
            }
            else if (radiobutton_diesel.IsChecked == true)
            {
                fuelPrice = firstStation.Diesel;
            }

            // Step 5: Calculate the price of travel
            double cost = (distance / 100) * consumption * fuelPrice;

            string message = $"Distanz: {Textbox_km.Text} km\n" +
                             $"Marke: {selectedDivision}\n" +
                             $"Modell: {selectedCarline}\n" +
                             $"Preis : {fuelPrice:F2} EUR\n" +
                             $"Fahrkosten: {cost:F2} EUR";
                             
            MessageBox.Show(message, "The cost of travel");
        }

    }
}
