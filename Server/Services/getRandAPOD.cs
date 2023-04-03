using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpaceFlightWeb.Server.Services
{
    public class getRandAPOD : JsonFileFetchService
    {
        public static string ApodFilePathRandom => apodFilePathRandom;
        private static string apodFilePathRandom;

        public static async void newRandArticle()
        {
            DateTime now = DateTime.Now;
            int todayYear = now.Year;

            //fetch a random APOD file by picking a random date and adding it to URL search parameter
            Random rand = new Random();
            int rdYear = rand.Next(1995, todayYear);
            int rdMonth = rand.Next(1, 12);
            int rdDay = 0;
            if (rdMonth == 2)
            {
                rdDay = rand.Next(1, 28);
            }
            else if (rdMonth == 1 || rdMonth == 3 || rdMonth == 5 || rdMonth == 7
                || rdMonth == 8 || rdMonth == 10 || rdMonth == 12)
            {
                rdDay = rand.Next(1, 31);
            }
            else if (rdMonth == 4 || rdMonth == 6 || rdMonth == 9 || rdMonth == 11)
            {
                rdDay = rand.Next(1, 30);
            }

            string rdYearurl = rdYear.ToString();
            string rdMonthurl = rdMonth.ToString();
            string rdDayurl = rdDay.ToString();
            if (rdMonth < 10)
                rdMonthurl = "0" + rdMonthurl;
            if (rdDay < 10)
                rdDayurl = "0" + rdDayurl;

            //random APOD naming(random) date and path
            string rootPath = "~\\..\\Assets\\js\\APOD\\";
            string randomDate = rdYearurl + "-" + rdMonthurl + "-" + rdDayurl;
            string apodrandPath = rootPath + "apod" + randomDate + ".json";
            
            //create a new APOD file to JSON library
            JsonFileFetchService apodrandFileFetch = new JsonFileFetchService();
            string apodRandomUrl = apodrandFileFetch.ApodRandomUrl + randomDate;
            if (!File.Exists(apodrandPath))
            {
                JsonFileFetchService.createAPOD(apodrandPath, apodRandomUrl);
            }
            
            //get a random file from JSON library already in existance
            apodFilePathRandom = getrandomfile2(rootPath);
            return;
        }
        private static string getrandomfile2(string path)
        {
            string file = null;
            if (!string.IsNullOrEmpty(path))
            {
                var extensions = new string[] { ".json" };
                try
                {
                    var di = new DirectoryInfo(path);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                catch { }
            }
            return file;
        }
    }
}
