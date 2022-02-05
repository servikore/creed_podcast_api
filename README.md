# CREED Podcasts API

## Requirements

* .Net core 6
* Sql Server

## Run Migrations

* Compile project Creed.Podcast.DataMigration
* Navigate to bin folder
* Run Creed.Podcast.DataMigration.exe passing the connectionstring to the database

Example: 
    .\Creed.Podcast.DataMigration.exe "Server=localhost;Database=db_podcasts;Integrated Security=True;"
Note:
    Database user must have privilege for creating database and related objects
    When finished, a db_podcasts database is created with sample data.

## Run Creed.Podcast.WebApi

* Set database connection string in appsettings.json
* Example: "PodcastConnectionString": "Server=localhost;Database=db_podcasts;Integrated Security=True;MultipleActiveResultSets=true"
* A friendly swagger page will show up.
* Get access token at api/authentication/login, use "admin" for both username and password.
* Use api/potcast/best_podcasts endpoint to search for best postcasts.

Notes:
    token returned from login must be added as bare token authentication header
Example:
curl -X 'GET' \
  'https://localhost:7242/api/potcast/best_podcasts?genre_id=93&page=1&region=us&safe_mode=0' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwibmJmIjoxNjQ0MDgxMjc4LCJleHAiOjE2NDQwODQ4NzgsImlhdCI6MTY0NDA4MTI3OH0.CdzCR8qHMIHAiDmqdaU8CgVG7uuOeib7VRxlh5-uaWw'