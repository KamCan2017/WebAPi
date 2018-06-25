using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weather_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Action:");
                string id = Console.ReadLine();

                GetRequest(id).Wait();
                Console.ReadKey();
                Console.Clear();


            }
        }

        static async Task GetRequest(string ID)
        {
            switch (ID)
            {
                //Get Request    
                case "Get":
                    Console.WriteLine("Enter id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    using (var client = WebClientFactory.GetHttpClient())
                    {
                        HttpResponseMessage response;

                        //id == 0 means select all records    
                        if (id == 0)
                        {
                            response = await client.GetAsync("api/Weather");
                            if (response.IsSuccessStatusCode)
                            {
                                var reports = await response.Content.ReadAsAsync<WeatherClient[]>();
                                foreach (var report in reports)
                                {
                                    Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}", report.City, report.Temperature, report.Humidity, report.Precipitation, report.Wind);
                                }
                            }
                        }
                        else
                        {
                            response = await client.GetAsync("api/Weather/" + id);
                            if (response.IsSuccessStatusCode)
                            {
                                var report = await response.Content.ReadAsAsync<WeatherClient>();
                                Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}", report.City, report.Temperature, report.Humidity, report.Precipitation, report.Wind);
                            }
                        }
                    }
                    break;

                //Post Request    
                case "Post":
                    var newReport = new WeatherClient();
                    Console.WriteLine("Enter data:");
                    Console.WriteLine("Enter City:");
                    newReport.City = Console.ReadLine();
                    Console.WriteLine("Enter Temperature:");
                    newReport.Temperature = Console.ReadLine();
                    Console.WriteLine("Enter Precipitation:");
                    newReport.Precipitation = Console.ReadLine();
                    Console.WriteLine("Enter Humidity:");
                    newReport.Humidity = Console.ReadLine();
                    Console.WriteLine("Enter Wind:");
                    newReport.Wind = Console.ReadLine();

                    using (var client = WebClientFactory.GetHttpClient())
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync("api/Weather", newReport);

                        if (response.IsSuccessStatusCode)
                        {
                            bool result = await response.Content.ReadAsAsync<bool>();
                            if (result)
                                Console.WriteLine("Report Submitted");
                            else
                                Console.WriteLine("An error has occurred");
                        }
                    }

                    break;

                //Delete Request    
                case "Delete":
                    Console.WriteLine("Enter id:");
                    int delete = Convert.ToInt32(Console.ReadLine());
                    using (var client = WebClientFactory.GetHttpClient())
                    {
                       HttpResponseMessage response = await client.DeleteAsync("api/Weather/" + delete);

                        if (response.IsSuccessStatusCode)
                        {
                            bool result = await response.Content.ReadAsAsync<bool>();
                            if (result)
                                Console.WriteLine("Report Deleted");
                            else
                                Console.WriteLine("An error has occurred");
                        }
                    }
                    break;
            }
        }
    }
}
