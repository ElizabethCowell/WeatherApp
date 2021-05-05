using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherMap = new HttpClient();

            Console.WriteLine("What is your area code?");

            var zipCode = Console.ReadLine();

            Console.WriteLine("What is your APIKey?");

            var apiKey = Console.ReadLine();

            var myWeather = weatherMap.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?&units=imperial&zip={zipCode}&appid={apiKey}").Result;
            
            var city = JObject.Parse(myWeather).GetValue("name").ToString();

            //var description = JArray.Parse(JObject.Parse(myWeather).GetValue("weather").ToString()).ToString();
            var weatherOb = JToken.Parse(myWeather).SelectToken("weather[0].description");


            var current = JObject.Parse(myWeather).GetValue("main").ToString();
            var temp = JObject.Parse(current).GetValue("temp").ToString();

            Console.WriteLine($"Today in {city} the weather outside is {weatherOb} \n" +
            $"The current tempurature is {temp}");
        }
    }
}
