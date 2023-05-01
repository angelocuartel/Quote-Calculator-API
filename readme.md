# Quote Calculator API

**Project structure**

<img src='https://github.com/angelocuartel/Quote-Calculator-MVC/blob/master/quote%20calculator%20project%20structure.JPG'/>


# API Setup

**Database Migration**

1. Open the appsettings.json and place your server with your
own local or remote server, (if you are going to use a
remote make sure to provide username and password for
that server).
```json
"ConnectionStrings":{
"dbCon":"Server=YOUR LOCAL SERVER HERE; Database=QuoteCalculatorDB;Trusted_Connection=true;"
}
```

2. Open package Manager console and type update-database
to seed our database with our latest migration in
Migrations Folder.

```
PM > update-database
```

**API ENDPOINTS FOR QUOTECALCULATOR API**

POST

https://localhost:7065/api/Quote

REQUEST PARAMETERS : JSON 

```json
{
"AmountRequired":5000,
"Term":23,
"FirstName":"George",
"LastName":"Hammerstone",
"DateOfBirth":null,
"Email":"hammerstone@uk.co"
"MobileNo":"330439320"
"Title":"Mr."
}
```

**RESPONSE**

```json
{
"url":"https://localhost:7239/Quote?hashedId=5feceb66ffc86f38d952786c6d696c79c2dbc239dd4e91b46729d73a27fb57e9"
}
```

>**Note:** all endpoints consumed by QUOTECALCULATOR MVC
are blocked by CORS policy so that the endpoints are only
exclusive for QuoteCalculatorMVC.




**Project setup for QuoteCalculator MVC**

No setup required for our mvc project, just run the MVC solution and
you are good to go.

