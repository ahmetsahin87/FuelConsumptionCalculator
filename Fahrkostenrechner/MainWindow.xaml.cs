using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Fahrkostenrechner.Model;
using Fahrkostenrechner.UserControls;
using Newtonsoft.Json;

namespace Fahrkostenrechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
          
        }
        private void Row_Auto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main_Spalte.Children.Clear();
            Main_Spalte.Children.Add(new Autos());
        }

        private void Row_Krafftstoff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main_Spalte.Children.Clear();
            Main_Spalte.Children.Add(new UC_Kraftstoff());
        }

        private void Row_Fahrkosten_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Main_Spalte.Children.Clear();
            Main_Spalte.Children.Add(new UC_Fahrkosten());
        }
       
    }
}
