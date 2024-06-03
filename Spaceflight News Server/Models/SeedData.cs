using Microsoft.EntityFrameworkCore;
using Spaceflight_News_Server.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spaceflight_News_Server.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new Spaceflight_News_MySQLContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Spaceflight_News_MySQLContext>>());
      
            using (context)
            {
                // Look for any articles.
                if (!context.Article.Any())
                {
                    context.Article.AddRange(
                        new Article
                        {
                            id = 21508,
                            title = "Rocket Factory Augsburg perceives historic moment for European launch industry",
                            url = "https://spacenews.com/rocket-factory-augsburg-perceives-historic-moment-for-european-launch-industry/",
                            textURL = "https://spacenews.com/wp-content/uploads/2023/10/RFA_LaunchPad_1-scaled-1-300x165.jpeg",
                            summary = "Startup Rocket Factory Augsburg perceive an historic shift has occurred in Europe launch, just as the firm closes in on its first orbital launch attempt.",
                            date = new DateTime(
                                2023, 11, 15,
                                20, 19, 22, 000),
                            featured = false
                        }
                    );
                }

                // Look for any APODs.
                if (context.APOD.Any())
                {
                    return;   // DB has been seeded
                }
                context.APOD.AddRange(
                    new APOD
                    {
                        apodtitle = "Daytime Moon Meets Morning Star",
                        date = "2023-11-16",
                        hdurl = "https://apod.nasa.gov/apod/image/2311/Katarzyna20.jpg",
                        description = "Venus now appears as Earth's brilliant morning star, shining above the southeastern horizon before dawn. For early morning risers, the silvery celestial beacon rose predawn in a close pairing with a waning crescent Moon on Thursday, November 9. But from some northern locations, the Moon was seen to occult or pass in front of Venus. From much of Europe, the lunar occultation could be viewed in daylight skies. This time series composite follows the daytime approach of Moon and morning star in blue skies from Warsaw, Poland. The progression of eight sharp telescopic snapshots, made between 10:56am and 10:58am local time, runs from left to right, when Venus winked out behind the bright lunar limb.",
                        media = "image"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
