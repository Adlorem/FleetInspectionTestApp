# Test App

Application API is made with core minimal API. Database access with Dapper. For testing purposes change "DefaultConnection" string in appsettings.json in API project to match your db connection. DB dump with example data is included in file DB_Dump.sql. To connect to API service with mobile app, localhost connection configuration is required in Android emulator. 

## Installation

This application is not meant to be tested in production environment. It's made for local tests only. 

## ToDo
Mobile app UI is basic. Code rework is needed. Could use some custom controls like nullable date picker. Some optimization in loading data is also needed like lazy load in larger data set.

## License
[MIT](https://choosealicense.com/licenses/mit/)