Fahrkostenrechner

Fahrkostenrechner is a WPF application designed to calculate the cost of travel based on various parameters such as car model, fuel type, and distance. The application fetches real-time fuel prices from an external API and uses car data to provide accurate travel cost estimations.

Features

•	Car Selection: Users can select a car division and carline from the provided options.  
•	Distance Input: Users can input the distance they plan to travel.  
•	Location Selection: Users can choose the type of location (City, Highway, Combined) to get the appropriate fuel consumption rate.  
•	Fuel Type Selection: Users can select the type of fuel (Benzin or Diesel) they plan to use.  
•	Real-time Fuel Prices: The application fetches real-time fuel prices from an external API.  
•	Travel Cost Calculation: The application calculates the cost of travel based on the selected parameters and displays a detailed summary.  

Project Structure

Model: Contains the data models used in the application.  
  •	CarData.cs: Represents the car data model.  
  •	ApiResponse.cs: Represents the API response model.  
  •	Station.cs: Represents the fuel station data model.  
  
Service: Contains the service classes used to fetch data.  
  •	CarService.cs: Provides methods to load car data and retrieve car divisions and carlines.  
  •	ApiService.cs: Provides methods to fetch fuel prices from the external API. 
  
•	UserControls: Contains the user controls used in the application.  
  •	UC_Fahrkosten.xaml and UC_Fahrkosten.xaml.cs: User control for calculating travel costs.  
  •	UC_Kraftstoff.xaml and UC_Kraftstoff.xaml.cs: User control for displaying fuel prices.  

  Configuration
  
  The application uses a configuration file (appsettings.json) to store the API URL. This file is not included in the version control to keep the API key secure. Make sure to create this file in the root of your project with the following content:  
     {  
       "ApiUrl": "https://creativecommons.tankerkoenig.de/json/list.php?lat=51.444&lng=6.980&rad=1&sort=dist&type=all&apikey=YOUR_API_KEY"  
     }    
     
Getting Started

1.	Clone the repository  
2.	2.	Open the project in Visual Studio.  
3.	Restore NuGet packages:  
    •	Right-click on the solution in Solution Explorer.  
    •	Select "Restore NuGet Packages".  
4.	Create the appsettings.json file in the root of your project with the API URL.  
5.	Run the application.    

License

This project is licensed under the MIT License.
