This repository is a stripped version of the live project development [www.spaceflight.dev](https://www.spaceflight.dev). Folders/Files irrelevant of project's creation have been removed. In that sense, this repository is the site's custom C# implemented in the site.  

:::image type="content" source="Web capture_5-11-2023_10132_www.spaceflight.dev.jpeg" alt-text="www.spaceflight.dev":::

## Features: Blazor web application using:  
1. Components implementation using razor syntax (C#, HTML, CSS, CSHTML)  
2. Multi-project solution developed in Visual Studio  
2. ASP.NET API endpoint:  
   - Article fetch at /spaceflightAPI/articles  
   - APOD fetch at /spaceflightAPI/apod  
3. Bootstrap CSS  
4. C# MVC  
5. JSON file repository    

Projected features:  
- DB backend hosting articles (currently, the web app is storing API fetches to local (see Server/Services/JsonFileFetchService.cs), then fetched via API from client web assembly  
