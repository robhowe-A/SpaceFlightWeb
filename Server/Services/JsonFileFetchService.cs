using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using System.IO;

namespace SpaceFlightWeb.Server.Services
{
    public class JsonFileFetchService
    {
        public string ApodRandomUrl => apodbaseRandomUrl;
        public static string ApodFilePath => apodFilePath;
        public static string PreviousArticleDateTime => previousArticleDateTime;
        private static string baseUrl = "https://api.spaceflightnewsapi.net/v3/articles";
        private static string apodUrl = "https://api.nasa.gov/planetary/apod?api_key=REDACTEDFORPRIVACY";
        private static string apodbaseRandomUrl = "https://api.nasa.gov/planetary/apod?api_key=REDACTEDFORPRIVACY&date=";
        private static string previousArticleDateTime;
        private static string previousAPODDateTime;
        private static string apodFilePath;
        private static string dateYear;
        private static string dateMonth;
        private static string dateDay;
        private static string dateHour;
        private static string dateMinute;

        public static async void GetArticle()
        {
            DateTime dateToday = DateTime.Now;
            int todayYear = dateToday.Year;
            int todayMonth = dateToday.Month;
            int todayDay = dateToday.Day;
            int todayHour = dateToday.Hour;
            int todayMinute = dateToday.Minute;

            if (todayMinute >= 0 && todayMinute < 15)
                todayMinute = 0;
            else if (todayMinute >= 15 && todayMinute < 30)
                todayMinute = 15;
            else if (todayMinute >= 30 && todayMinute < 45)
                todayMinute = 30;
            else if (todayMinute > 45 && todayMinute < 60)
                todayMinute = 45;

            dateYear = todayYear.ToString();
            dateMonth = todayMonth.ToString();
            dateDay = todayDay.ToString();
            dateHour = todayHour.ToString();
            dateMinute = todayMinute.ToString();

            if (todayMonth < 10)
                dateMonth = "0" + dateMonth;
            if (todayDay < 10)
                dateDay = "0" + dateDay;
            if (todayMinute < 10)
                dateMinute = "0" + dateMinute;

            string fileToday = dateYear + dateMonth + dateDay + ".json";

            //get newest json file
            var path = new DirectoryInfo("~\\..\\assets\\js");
            string searchfor = "*.json";
            if (path.GetFiles().Length > 0)
            {
                var myFile = path.GetFiles(searchfor).OrderByDescending(f => f.LastWriteTime).First();
                var currentFilePathName = myFile.Name;
                string currentFilePath = currentFilePathName.ToString();
                previousArticleDateTime = currentFilePath;
            }
            createFilePath();

            //fetch the APOD file today
            string apodPath = "~\\..\\assets\\js\\APOD\\apod" + fileToday;

            //get newest APOD file
            var path2 = new DirectoryInfo("~\\..\\assets\\js\\APOD");
            string searchterm = "*.json";
            if (path2.GetFiles().Length > 0)
            {
                var myAPODFile = path2.GetFiles(searchterm).OrderByDescending(f => f.Name).First();
                var currentAPODFilePathName = myAPODFile.Name;
                string currentAPODFilePath = currentAPODFilePathName.ToString();
                apodFilePath = "APOD\\" + currentAPODFilePath;
            }
            if (!File.Exists(apodPath))
            {
                createAPOD(apodPath, apodUrl);
            }
        }
        protected static async void createAPOD(string path, string urls)
        {
            HttpClient client = new HttpClient();
            string responseBodyAPOD = await client.GetStringAsync(urls);
            File.WriteAllText(path, "[" + responseBodyAPOD + "]");
        }

        private static void createFilePath()
        {
            string todayPathRoot = "~\\..\\assets\\js\\";
            string articleDateTimeToday = dateYear + dateMonth + dateDay + ".json";
            string todayPath = todayPathRoot + articleDateTimeToday;

            string articleDateTimeNow = dateYear + dateMonth + dateDay + "_" + dateHour + "_" + dateMinute + ".json";
            string todayPathNow = todayPathRoot + articleDateTimeNow;
            if (!File.Exists(todayPath))
            {
                createArticle(todayPath);
            }
            if(!File.Exists(todayPathNow))
            {
                createArticle(todayPathNow);
            }
        }
        private static async void createArticle(string filePath)
        {
            HttpClient client = new HttpClient();
            string responseBody = await client.GetStringAsync(baseUrl);
            File.WriteAllText(filePath, responseBody);
        }
    }
}
