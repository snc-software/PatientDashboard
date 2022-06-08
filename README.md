# PatientDashboard


Associated Services: 
 - [Fluent Assertions](https://github.com/fluentassertions/fluentassertions) (Unit Testing Assertions)
 - [Fast Endpoints](https://github.com/dj-nitehawk/FastEndpoints) (REPR API Pattern including Swagger documentation)
 - [Moq](https://github.com/moq/moq4) (Unit test mocking)
 - [CsvHelper](https://github.com/JoshClose/CsvHelper) (For reading csv files)
 - [Mapster](https://github.com/MapsterMapper/Mapster) (For mapping from domain to dto)
 - [MaterialUI](https://mui.com/) (React Components)
 - [MSW](https://mswjs.io/) (For mocking api requests in react)

# Next Steps if given more time

1) Finish off unit testing the home page
   i) add integration tests
   ii) test busy indicator is displayed
   iii) test table is created and populated
2) Add sorting to the table 
   i) I would have to read the header being clicked and then add a sorting function that allows the table to be sorted correctly
3) Add pagination to the table and API 
   i) As we have a lot of rows per clinic, i would have liked to add pagination to the table. This would ideally been done by reading pages from the api. This would in turn modify the sort function as we would want to sort the whole dataset, not just the page.
4) cache data instead of read on demand
   i) this goes hand in hand with the pagination/sorting. We could use an in memory cache or a distributed cache such as redis
   
# Additional Information
Ideally would have populated some sort of relational database such as MSSQL or PostgreSQL to store the data, this would remove any concerns of the file being locked by trying to access. This could be controlled by EFCore for small applications or a ORM such as 'Dapper'

