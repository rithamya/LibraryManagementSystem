**LIBRARY MANAGEMENT SYSTEM:**
A simple .NET application built using Entity Framework Core (Code-First) that manages Books, Authors, and Borrowers.  
Includes unit tests.

**HOW TO RUN THE APPLICATION:**

**PRE-REQUISITE:**
1. Open the git code in vs -> create a repository, or download as a zip -> extract and load the solution.
2. Create a database - LIB_db in your system and change the server name to your local server name in ApplicationDbContext.cs file.
3. run the commands in the package manager console to create table in the db.
	Tools -> nuget package manager -> package manager console :
		EntityFrameworkCore\Add-Migration SyncPendingChanges (enter)
		EntityFrameworkCore\Update-Database (enter)
4. set LibraryManagementSystem as startup project, Build and launch solution. 

  LIBRARY MANAGEMENT SYSTEM Application ia available for your use.
  
**HOW TO RUN TEST:**
1. Navigate to LibraryManagementSystem.Test -> UnitTest1.cs
2. Right click and run test.

For more clarifictaions - reach out to email: rithmayaparasuraman@gmail.com or phone no:9361388533
