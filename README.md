
# Boilerplate - Clean Architecture




## How About

This is a sample project with clean architecture base on .Net C# API. Project building with modular services and RESTful API.


## Installation

Use Visual Studio 2022 or newer to running project.

## What's included

 - Active Directory (AD) Authentication
 - JWT Authorization
 - Swagger Doc
 - User Management
 - Role Management
 - Menu Management
 - Sql Server Configuration
 - Postgre Sql Configuration
 - Filestore Alfresco
 - Filestore OneDrive
 - Hangfire


## Make a Feature as Modular

To run make a new feature or module, follow this instructions on below

- Right Click on ```Modules```.

![App Screenshot](https://media.discordapp.net/attachments/942967848727363665/964072710143623168/unknown.png?width=759&height=427)
- You can choise a ```Class Library``` type. 
- Project Name must related with existing project, example ```Garuda.Modules.ManageProject```.
- The location project must on ```Modules``` folder.
![App Screenshot](https://media.discordapp.net/attachments/942967848727363665/964072955380400178/unknown.png?width=759&height=427)
- Doble Click on your main project.
- Make sure a Sdk project is ```Microsoft.NET.Sdk```
```bash
  <Project Sdk="Microsoft.NET.Sdk">
```
- Make sure a project included inherit stylecops. If not yet to included, you can added manualy.
```bash
  <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
```
- Try set up your dependencies to other project by yourself. Dont make your dependencies is circular with other project.
- Try set up your packages by yourself. Make sure packages are same with other project.
- Build your skeleton folder on your project.
- Add your project as injection dependencies on ```Garuda.Host```, you can follow next instructions.
- Right Click on ```Garuda.Host``` -> ```Dependencies``` -> ```Projects```.
- Select ```Add Project References```.
- Make sure your project has been selected, after that click ```Ok```.
![App Screenshot](https://media.discordapp.net/attachments/951446971732860971/965432932598702080/unknown.png?width=603&height=427)
- Make sure ```Garuda.Host``` set as Startup Project.
- Make sure your configuration ```appsetting``` has been added.
- Clean and Rebuild Project.
- Finally, you can run this Project.
- Happy to help! 
> Note: `Garuda.Modules.Common` dont make injection dependencies with other project.


## Authors

- [@ihksans](https://github.com/ihksans)


## History
- Last updated 18-04-2022.



