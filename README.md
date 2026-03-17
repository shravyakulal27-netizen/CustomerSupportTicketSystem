Customer Support Ticket System using ASP.NET Web API, WinForms and MySQL

# Customer Support Ticket System

## Project Overview
This project is a Customer Support Ticket System built using ASP.NET Web API and a Windows Forms Desktop Application. 
Users can create support tickets and administrators can manage, assign, and update ticket statuses.

## Tech Stack
- Backend: ASP.NET Web API (C#)
- Frontend: Windows Forms (.NET Framework)
- IDE: Visual Studio 2019
- Database: MySQL
- JSON Handling: Newtonsoft.Json
- HTTP Communication: HttpClient

## Required NuGet Packages
The following NuGet packages must be installed:

- MySql.Data
- Newtonsoft.Json

## Prerequisites
Before running the project, ensure the following are installed:

- Visual Studio 2019
- MySQL Server
- .NET Framework

## Steps to Run the Project

1. Import the MySQL database using the provided SQL script.
2. Open the solution file in Visual Studio 2019.
3. Restore NuGet packages if required.
4. Run the ASP.NET Web API project.
5. Update the Windows Forms Desktop Application to point to the correct Web API port (see Web API Port Number section below).
6. Run the Windows Forms Desktop Application.
7. **Important:** Both the Web API project and the Desktop Application **must be running at the same time** for the application to work properly.
8. Login using valid user credentials.

**Folder Structure:**  
- TicketsystemFinal → Web API project  
- TicketSystemDesktop → Windows Forms Desktop Application  

**Steps to Find/Set the Port Number:**  
1. The ASP.NET Web API project runs on a local port. By default, Visual Studio assigns a port when you run the project.   
2. Look for **App URL**, e.g., "https://localhost:44366/".  
3. Update this port in the **Windows Forms Desktop Application**:  
   - Navigate to "TicketSystemDesktop\Service\AppService.cs" 
   - Replace the API URL with the current Web API port, for example: private string baseUrl = "https://localhost:44366/";    
   - This ensures the desktop app communicates with the correct Web API port.  

**Note:** The port may vary on your system; ensure the Windows Forms app’s API URL matches the port used by the Web API.

## Features
- User Login
- Create Ticket
- View Ticket Details
- Add Comments to Ticket
- Assign Ticket (Admin)
- Update Ticket Status
- View Ticket Status History

## Database
MySQL database script is included in the repository.

## Author
Shravya A
