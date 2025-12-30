# SpaceFlightWeb  
SpaceflightWeb is a website created to showcase the application of developer skill sets. Details are written below about the project, from its creation.  

## 7-1-2024 Update  
This site is now live! This code repository serves to host the previous iteration of the site's live code. Today, the code and code stack is very different and is not open source. The site, however, is available for public viewing and querying the database.  

## Archive  
**Everything below is an archive version of this repository**  
This repository is a stripped version of the live project development [www.rh-snapi-site.com](https://www.rh-snapi-site.com/) . Folders/Files irrelevant of project's creation have been removed. In that sense, this repository is the site's custom C#, CSHTML, CSS, etc. implemented in the site.  
****Note: This website's domain is moving away from [www.roberthowell.dev](https://www.roberthowell.dev/) and remains active; however, this is temporary and the contents on `www.roberthowell.dev` will be replaced. At current, both domains share the same content. This also means both domains function the same.**   

<img src="./readme/Web_capture_5-11-2023_10132_www.spaceflight.dev.jpeg" alt="www.spaceflight.dev_11=5=23" width="75%" margin="auto" />

## Features  
This is a blazor web application using:  
1. Components implementation using razor syntax (C#, HTML, CSS, CSHTML)
2. Multi-project solution developed in Visual Studio
3. ASP.NET API endpoint:
   - Article fetch at /spaceflightAPI/articles
   - APOD fetch at /spaceflightAPI/apod
4. Bootstrap CSS
5. C# MVC
6. JSON file  (Backend)  
7. API fetches of article data in JSON format (see Server/Services/JsonFileFetchService.cs) provide the content used in the web assembly page


## Upcoming  
- Database backend:  
 > <img src="readme\WebFarm.drawio.svg" alt="Website topology www.spaceflight.dev_11-17-23" width="75%" margin="auto" />  
 > 
 > <br>
 >  
 > <img src="readme\3d-fluency-database.png" alt="icon8 database icon" width="50px" margin="auto" />  
 > 
 > Database illustration by <a href="https://icons8.com/illustrations/author/zD2oqC8lLBBA">Icons 8</a> from <a href="https://icons8.com/illustrations">Ouch!</a>  
 > 
 > <img src="readme\icons8-cloudflare-48.png" alt="icon8 cloudflare icon" width="50px" margin="auto" />  
 > 
 > <a target="_blank" href="https://icons8.com/icon/13682/cloudflare">CloudFlare</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>  
 > 
 > <img src="readme\icons8-article-48.png" alt="icon8 article icon" width="50px" margin="auto" />  
 > 
 > <a target="_blank" href="https://icons8.com/icon/13620/page">Article</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>  
 > 
 > <img src="readme\icons8-article-48-red.png" alt="icon8 red article icon" width="50px" margin="auto" />  
 > 
 > <a target="_blank" href="https://icons8.com/icon/13119/news">Article</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>  
 > 
 > Remaining icons from <a target="_blank" href="https://app.diagrams.net/">draw.io</a>  
 > Diagram created at <a target="_blank" href="https://app.diagrams.net/">draw.io</a>  
