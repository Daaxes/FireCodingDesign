# Firecoding Design ASP.NET MVC Identity kopplad till MS SQL Server
OBS Master1 är den senaste

Beskrivning av mitt slutprojekt webbplatsen Firecoding Design som använder ASP.NET MVC Identity för användarhantering.
Min hemsida har jag tänk att den skall vara riktad till både till företag och privatsom kan lägga ordrar,
ladda upp bilder till databasen, skriva beskrivning av hemsidanSätta ett Orderdatum (Automatiskt till dagens datum), Datum för önskad leverans.
Detta sparas i en Order tabellen och kan sedan plockas upp av användare. Order visas alltid på hemsidan men om man klickar på den och inte är inloggad
så kommer inloggning fönster upp där man också kan skapa ett konto.
Administration klassen hanterar användarna, och kopplas samman med Identity. I denna kan jag ge olika användare olika roller.
Om en användare har rollen user så kommer den åt det som user rollen kan hantera.
Vid skapande av databas tabeller kommer exempela data läggas in i samt skapande av FirstName, LastName och Mobile i AspNetUsers tabellen
Exempeldata ligger i AspNetRoles, Company, Department
Vid start så kommer ett SuperAdmin konto skapas, Detta måste man logga in med för att komma åt visa viewer och Controllers
Kontot: superadmin@firecoding.se
password: p@sSw0rd
Detta bör bytas ut direkt
Via Administration viewn så kan man lägga roller på användarna. 

## Funktioner

- **Användarhantering**: Registrering, inloggning, glömt lösenord, hantering av användarroller.
- **Orderhantering**: Skapa, redigera och visa ordrar.
- **Avdelningshantering**: Hantera olika avdelningar för orderna.
- **Bilduppladdning**: Ladda upp bilder för ordrar.
- **Authentication: Hantering av inloggning på siten.
- **Athorization: Hantering av rollerna på siten.
  
## Teknikstack

- ASP.NET MVC
- ASP.NET Identity
- Entity Framework
- 
- Javaskript för hantering av inladdning av bilder till till siten som sedan lagras i databasen

## Installation

1. Klona projektet från GitHub-repositoriet.
2. Konfigurera din databasanslutning i `appsettings.json`.
3. Kör migrationskommandon för att skapa databasen.
4. Starta webbplatsen.

Från Visual Studio
Skapa en Asp.Net MVC Webbapp
Lägg till Identity genom att klicka på Projektnamnet och välj Scaffolder item och Identity
Installera NuGet Package
- Microsoft.AspNet.Identity.Core
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
  
Starta Tool/NuGet/Package Manager Console
Kör kommandena
add-migration addingTables
update-database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run

Hav fun!!!
