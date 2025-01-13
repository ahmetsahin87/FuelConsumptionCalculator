using System;
using System.Collections.Generic;
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
using Fahrkostenrechner.Model1;
using Fahrkostenrechner.Service;

namespace Fahrkostenrechner.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Kraftstoff.xaml
    /// </summary>
    public partial class UC_Kraftstoff : UserControl
    {
        private ApiService apiService;
        public UC_Kraftstoff()
        {
            InitializeComponent();
            apiService = new ApiService();
            LoadStationData();
        }
        private async void LoadStationData()
        {
            string apiUrl = "https://creativecommons.tankerkoenig.de/json/list.php?lat=51.444&lng=6.980&rad=1&sort=dist&type=all&apikey=21cf9e03-a3aa-0547-5bf2-78bd6f69accd"; // Replace with your actual API URL
            Station firstStation = await apiService.GetFirstStationAsync(apiUrl);

            if (firstStation != null)
            {
                label_e5.Content = firstStation.E5.ToString("F2");
                label_e10.Content = firstStation.E10.ToString("F2");
                label_diesel.Content = firstStation.Diesel.ToString("F2");
            }
            else
            {
                label_e5.Content = "N/A";
                label_e10.Content = "N/A";
                label_diesel.Content = "N/A";
            }
        }
    }
}
