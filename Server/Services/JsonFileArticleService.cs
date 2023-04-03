using Microsoft.AspNetCore.Hosting;
using SpaceFlightWeb.Shared;
using System.Text.Json;

namespace SpaceFlightWeb.Server.Services
{
    public class JsonFileArticleService
    {
        private string JsonAPODName
        {
            get { return Path.Combine("Assets", "js", JsonFileFetchService.ApodFilePath); }
        }

        private string JsonRandAPODName
        {
            get { return Path.Combine("Assets", "js", getRandAPOD.ApodFilePathRandom); }
        }

        private string JsonFileName
        {
            get { return Path.Combine("Assets", "js", JsonFileFetchService.PreviousArticleDateTime); }
        }

        public IEnumerable<APOD> getAPOD()
        {
            string FileName = JsonAPODName;


            using (var jsonFileReader = System.IO.File.OpenText(FileName))
            {
                return JsonSerializer.Deserialize<APOD[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            
        }
        public IEnumerable<APOD> getRandomAPOD()
        {
            using (var jsonFileReader = System.IO.File.OpenText(JsonRandAPODName))
            {
                return JsonSerializer.Deserialize<APOD[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

        }
        public IEnumerable<Article> getArticles()
        {
            using (var jsonFileReader = System.IO.File.OpenText(JsonFileName))
            {
                //Bad date format error is not handled. Ex: 10-24-2022 --blazor component
                //Missing JSON entry is not handled. Ex: "temperatureF: ," --json file format
                return JsonSerializer.Deserialize<Article[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

    }
}
