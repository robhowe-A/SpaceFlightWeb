This repository is a stripped version of the live project development. Folders/Files irrelevant of project's creation have been removed. In that sense, this repository is the site's custom C# implemented in the site.  

## Note: The site [www.spaceflight.dev](https://www.spaceflight.dev) is OFFLINE/unreachable due to ISP change. Hopefully this is temporary, while I work with them.

## Features: Blazor web application using:  
1. Razor components implementation (C#, HTML, CSS)  
2. ASP.NET API endpoint fetch:  
   - Article fetch at /spaceflightAPI/articles  
   - APOD fetch at /spaceflightAPI/apod  
3. Bootstrap CSS framework  
4. C# MVC: client, server, and shared models  
5. JSON file repository serving recent articles/apod fetches  

Projected features:  
- DB backend hosting articles (currently, the web app is storing API fetches to local (see Server/Services/JsonFileFetchService.cs), then fetched via API from client web assembly, where users see it in the browser)  
- View previous articles  
- Rate the best articles  
