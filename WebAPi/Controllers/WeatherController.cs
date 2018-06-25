using System.Collections.Generic;
using System.Web.Http;
using WebAPi.Models;

namespace WebAPi.Controllers
{
    public class WeatherController : ApiController
    {
        //The data should come from database but here I am hard coding it.    
        public static List<Weather> reports = new List<Weather>
        {
            new Weather { id = 1, City = "Islamabad", Temperature = "25 f", Humidity = "70%", Precipitation = "0%", Wind = "15mph" },
            new Weather { id = 2, City = "Karachi", Temperature = "40 f", Humidity = "80%", Precipitation = "0%", Wind = "40mph" },
            new Weather { id = 3, City = "Lahore", Temperature = "35 f", Humidity = "50%", Precipitation = "0%", Wind = "10mph" },
            new Weather { id = 4, City = "Peshawar", Temperature = "25 f", Humidity = "65%", Precipitation = "0%", Wind = "15mph" },
            new Weather { id = 5, City = "Quetta", Temperature = "40 f", Humidity = "50%", Precipitation = "0%", Wind = "20mph" },
        };

        [HttpGet]
        public List<Weather> Get()
        {
            return reports;
        }

        [HttpGet]
        public Weather Get(int id)
        {
            return reports.Find((r) => r.id == id);
        }

        [HttpPost]
        public bool Post(Weather report)
        {
            try
            {
                reports.Add(report);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                var itemToRemove = reports.Find((r) => r.id == id);
                reports.Remove(itemToRemove);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
