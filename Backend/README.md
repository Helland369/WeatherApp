# Backend

## ENV variables

You will need to make a ".env" file with these variabel; WEATHERKEY, IPKEY, MS_SQL

The env variables may look something like this;

WEATHERKEY='123123abcd123aa12bb33cc'
IPKEY='123123abcd123aa12bb33cc'
MS_SQL='Server=localhost, 1234;Database=NameOfDB;User Id=sa;Password=SuperSeacretPassword;Encrypt=False;'


# api endpoints


## Using the endpoints


### http://localhost:5285/api/weather/

This endpoint will retrun the contents of the database.

### http://localhost:5285/api/weather/live

This endpoint will return the current weather for your location.

### http://localhost:5285/api/weather/{id}

With this endpoint you may search the database based on the id and it will retrun the contents of the column with that id.
Remember to change "{id}" with an actuall id.


## About the endpoints

You can find the endpoints in:

UNIX file path: "~/WeatherApp/Backend/Controllers/WeatherController.cs"

MS-Windows file path: "...\WeatherApp\Backend\Controllers\WeatherController.cs"

The "WeatherController.cs" file contains the endpoints for the api.


## WeatherController.cs


### public async Task<ActionResult<IEnumerable<WeatherData>>> GetWeatherData()

Retrives all weather data that is stroed in the database.


### public async Task<ActionResult<WeatherData>> GetWeatherDataById(int id)

Retrives all weather data from the database asisiated with the selected id.


### public async Task<ActionResult<WeatherData>> GetWeatherDataById(int id)

Retrives the current weather from the OpenWeather api.

