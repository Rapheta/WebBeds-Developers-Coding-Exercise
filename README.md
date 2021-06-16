## WebBeds Developers Coding Exercise

**About me**

- Name: Rafael Castellet Ginard
- Email: rafael.castelletginard@gmail.com
- LinkedIn: https://www.linkedin.com/in/rafael-castellet-ginard/

---------------------------------------------

**Installation**

- Visual Studio 2019

## Introduction

This is a resulting WebBeds Developers Coding Exercise required for joining the WebBeds IT team.  This is an opportunity to demonstrate my skills and experiences. The exercise is created using .NET Core and C#.

## Coding Exercise

**Task description**

You work for the Cheap Awesome travel company. Valentine’s day is arriving, and a new special landing page will be created on our website: http://cheapawesome.travel.
As part of the connectivity team, you have been tasked to create a service that will consume the Hotel Availability API from our new supplier Bargains for Couples. Bargains For Couples provides an API hosted at https://webbedsdevtest.azurewebsites.net/api/ as well as some documentation about its methods.
The endpoint for availability has the following specs:

- API Method: findBargain
- Query String Parameters:

| Name      | Type | Description |
| --------- | -----:|-----|
| destinationId  | Integer | Destination ID Ex: 279, 1419 |
| nights     |   Integer | Number of nights |
| code      |    String | Secret authentication code aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw== |

**Task objectives**

The goal is to consume this API and return a list of hotels with one final price per Board Type, with response time under 1 second.

The response will contain a list of hotels with rates.
The rates have a Board Type, Value and Rate Type (Per Night or Stay).
- If rate type is Per Night, you must calculate the final price (Value x Number of nights).
- If rate type is Stay, value is already the final price.

**Example Supplier API response**

```json
[
  {
    "hotel": {
      "propertyID": 79732,
      "name": "JAC Canada (CA$)8314",
      "geoId": 279,
      "rating": 3
    },
    "rates": [
      {
        "rateType": "PerNight",
        "boardType": "No Meals",
        "value": 207.6
      },
      {
        "rateType": "PerNight",
        "boardType": "Half Board",
        "value": 242.2
      },
      {
        "rateType": "PerNight",
        "boardType": "Full Board",
        "value": 276.8
      }
    ]
  },
  {
    "hotel": {
      "propertyID": 79821,
      "name": "JAC Canada (CA$)8555",
      "geoId": 279,
      "rating": 3
    },
    "rates": [
      {
        "rateType": "Stay",
        "boardType": "No Meals",
        "value": 590.4
      },
      {
        "rateType": "Stay",
        "boardType": "Half Board",
        "value": 688.8
      },
      {
        "rateType": "Stay",
        "boardType": "Full Board",
        "value": 787.2
      }
    ]
  }
]
```

## Methodology

**Architecture**

For the architecture of this project I have used a variant of "Clean Architecture" based on the book by Robert C. Martin. The objectives of this architecture are:

- Application independent of frameworks
- Testable
- Application independent of UI
- Application independent of database
- Application independent of external agency

We are going to handle three projects in Visual Studio as layers:

- **CheapAwesome.API**: The presentation project has our controllers, properties, settings and two important files (Startup.cs and Program.cs).
- **CheapAwesome.Infrastructure**: This project contains our repositories and mappings.
- **CheapAwesome.Core**: The Core project contains our entities, interfaces, services and DTOs.

We also have a folder in which the unit tests project is included. These tests will guarantee the correct functioning and quality of the generated code.

- **CheapAwesome.UnitTest**

The API project has access to the rest of the layers, while the infrastructure project also has access to the core or domain project. The core project has no dependencies.
