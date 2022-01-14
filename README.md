# Movie API
### API that integrates imdb services

<br>

## Setup
* Install Docker
* Install Visual Studio 2022

<br>

## Steps
* **git clone https://github.com/frkn2076/Movie**
* **docker run --name postgre-instance -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -d postgres:13-alpine**
* **Add-Migration InitialCreate**
* **Update-Database**
* **run project**

<br>

## Technologies
* FluentValidation
* Hangfire
* Mapster
* EntityFrameworkCore
* Swagger
* Fluent API
* MailKit

<br>

## Database
* PostgreSQL

<br>

## Consumed Services
* IMDB services: https://imdb-api.com/api


