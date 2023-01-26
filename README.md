<div align="center">
    <h1>Noroff Assignment 2: Data Persistence and Access</h1>
    <img src="https://cdn-icons-png.flaticon.com/512/4248/4248443.png" width="128" alt="SQL">
</div>

[![license](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![standard-readme compliant](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)

## Background information
This assignment is divided into two sections: creating database with SQL scripts and reading data with SQL client.

1. The SQL scripts to create a database is located in the 'Backend_Assignment_2_Appendix_B' folder. It holds one individual SQL script containing all the sequantial SQL queries, and in the 'SqlScripts' folder it has all the commands in separate SQL scripts.  These queries allow you to create a database, setup some tables in the database, add relationships to the tables, and then populate the tables with data. The database and its theme are surrounding **superheroes**.
2. The **ChinookReader** is located in the 'Backend_Assignment_2_Appendix_B' folder. It holds a C# console application that connects to a local database (**Chinook**) and executes **CRUD** queries. The app also uses the implementation of the repository pattern and is used to interact with the database.

## Install
Download and install: 
* [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
* [.Net 4.5.1 or later](https://dotnet.microsoft.com/en-us/download/dotnet)

## How to run

### SQL Superheroes
Creating the database can be done in three ways:
* Open in Visual Studio the 'Backend_Assignment_2_Appendix_A.cs.proj' solution. Run the program by clicking on F5 or on start debugging.
* Open the '10_completeScript.sql' file in MSSM and execute it.
* Open the 'SqlScripts' folder and open the individual files and execute them in order.


### Chinook Reader

1. Create **Chinook** database by executing the **Chinook_SqlServer_AutoIncrementPKs.sql** file with **SQL Server Management Studio**.

2. Navigate to **Backend_Assignment_2_Appendix_B/DataAccess/** and open **SqlHelper.cs** file and change **DataSource** to your own server name.  
  You can find this name in **SQL Server Management Studio**:
    1. Right click on your server inside the **Object Explorer**
    2. Click on **Properties**
    3. Copy the value of the **Name** field

3. Open in Visual Studio the 'Backend_Assignment_2_Appendix_B.csproj' solution. Run the program by clicking on F5 or on start debugging.




## Maintainers

[@AhmadKhodabaks](https://github.com/AhmadKhodabaks/)\
[@Richard Stølen](https://gitlab.com/richardstolen)

## Contributing

PRs accepted.

Small note: If editing the Readme, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT](../LICENSE) © Richard Stølen, Ahmad Khodabaks
