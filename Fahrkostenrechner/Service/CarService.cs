using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrkostenrechner.Model;
using Newtonsoft.Json;


namespace Fahrkostenrechner.Service
{
    internal class CarService
    {
        public List<CarData> carDataList;

         public void LoadCarData()
        {
            string json = File.ReadAllText("C:\\Users\\49176\\source\\repos\\Fahrkostenrechner\\Fahrkostenrechner\\Data\\CarData.json");
            carDataList = JsonConvert.DeserializeObject<List<CarData>>(json);
        }

        public List<string> GetDivisions()
        {
            return carDataList.Select(cd => cd.Division).Distinct().ToList();
        }

        public List<string> GetCarLines(string division)
        {
            return carDataList
                .Where(cd => cd.Division == division)
                .Select(cd => cd.Carline)
                .Distinct()
                .ToList();
        }

        public CarData GetCarData(string carline)
        {
            return carDataList.FirstOrDefault(cd => cd.Carline == carline);
        }



    }
}
