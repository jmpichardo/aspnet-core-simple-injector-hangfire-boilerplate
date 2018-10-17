# Boilerplate for ASP.Net Core + Simple Injector + Hangfire

## Description

A basic boilerplate that combines **ASP.Net Core 2.1** with **Simple Injector** for dependency injection and **Hangfire** to run jobs.
This project contains a basic integration of these three technologies running a recurring job with an injected service.

## Features

* Initialize Hangfire with the Dashboard.
* Initialize Simple Injector as a tool for dependency injection.
* Connects Hangfire with a SQL Server database.
* IoC container factory class to map all injectable classes.

## Stack

* ASP.Net Core 2.1
* Simple Injector 4.3.0
* Hangfire 1.6.20

## Requirements

* .Net Core 2.1 SDK
* SQL Server database

## Getting started

1. Clone or download the project in a folder
2. Go to project folder
3. Change the connection string to point your database
4. Build the project
```
dotnet build
```
5. Run the project
```
dotnet run
```
6. Go to http://localhost:5000/hangfire or https://localhost:5001/hangfire to see Hangfire's dashboard and all running jobs.

## Notes

This project doesn't include any example for Hangfire's dashboard authorization or any extra setup.

## License

The code is available under the [MIT license](https://github.com/jmpichardo/aspnet-core-simple-injector-hangfire-boilerplate/blob/master/LICENSE).
