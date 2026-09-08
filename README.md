# Malaria Sample Tracking Application

A web-based laboratory sample management system developed to centralize and simplify the tracking of malaria blood samples across multiple research studies.

The application was designed to support the management of more than one million sample records stored at the Uganda Ministry of Health laboratory. It gives authorized researchers and laboratory personnel a structured way to locate samples, manage storage information, and maintain accurate sample records.

## Overview

Managing large collections of biological samples using spreadsheets and disconnected databases can make it difficult to locate specimens, maintain consistent records, and provide researchers with timely access to data.

This application provides a centralized system for managing malaria sample information, including:

- Sample barcodes
- Box numbers
- Box rows and columns
- Freezer locations
- Freezer compartments, racks, and positions
- Specimen types
- Collection or entry dates
- PCR plate information
- Aliquot plate numbers and positions
- Research study mappings

The system was developed to support sample records from more than 10 research studies and provide centralized access for medical researchers and study teams.

## Key Features

- Create, view, update, and delete sample records
- Track the physical location of samples in freezers
- Organize samples by box, row, and column
- Manage freezer, compartment, rack, and position information
- Manage specimen types and study mappings
- Import sample records from CSV files
- Export sample records to CSV
- Track PCR and aliquot plate information
- Generate and manage sample reports
- Register and authenticate users
- Store application data in Microsoft SQL Server
- Validate database changes through Entity Framework migrations

## Technologies

- C#
- ASP.NET Core MVC
- .NET 8
- Entity Framework Core
- Microsoft SQL Server
- ASP.NET Core Identity
- Razor Views
- Bootstrap
- JavaScript
- CsvHelper

## Application Structure

```text
Malaria-Sample-Tracking-Application/
├── Prismproject_A/
│   ├── Controllers/        # Request handling and application logic
│   ├── Data/               # Entity Framework database context
│   ├── Migrations/         # Database schema migrations
│   ├── Models/             # Sample, storage, report, and user models
│   ├── Views/              # Razor user-interface pages
│   ├── wwwroot/            # CSS, JavaScript, images, and libraries
│   ├── Program.cs          # Application configuration and startup
│   └── Prismproject_A.csproj
└── Prismproject_A.sln
```

## Main Data Components

| Component | Purpose |
|---|---|
| `BoxSubs` | Stores individual sample barcodes and their positions within boxes |
| `BoxMain` | Stores general box and sample-type information |
| `BoxLocations` | Connects boxes to freezer storage locations |
| `FreezerDetails` | Stores freezer, compartment, rack, and position details |
| `SpecimenTypes` | Defines specimen types, prefixes, and box dimensions |
| `ImmerseSamples` | Stores sample records associated with the IMMERSE study |
| `ZumbaSamples` | Stores sample records associated with the ZUMBA study |
| `MRCmapping` | Maintains mappings between research codes |
| `Report` | Stores combined sample and location information for reporting |
| `ApplicationUser` | Stores authenticated-user information |

## Getting Started

### Prerequisites

Install the following tools:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft SQL Server](https://www.microsoft.com/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or another C# IDE
- Entity Framework Core command-line tools

Install the Entity Framework CLI if it is not already available:

```bash
dotnet tool install --global dotnet-ef
```

### Installation

1. Clone the repository:

```bash
git clone https://github.com/mkamya20/Malaria-Sample-Tracking-Application.git
cd Malaria-Sample-Tracking-Application
```

2. Restore the project dependencies:

```bash
dotnet restore
```

3. Configure the SQL Server connection string.

The application expects a connection string named `Prismproject_A`. For local development, use .NET Secret Manager so that database credentials are not committed to GitHub:

```bash
cd Prismproject_A

dotnet user-secrets init

dotnet user-secrets set \
  "ConnectionStrings:Prismproject_A" \
  "Server=YOUR_SERVER;Database=MalariaSampleTracking;Trusted_Connection=True;TrustServerCertificate=True;"
```

Replace `YOUR_SERVER` with the name of your SQL Server instance.

4. Apply the database migrations:

```bash
dotnet ef database update
```

5. Start the application:

```bash
dotnet run
```

6. Open the local address displayed in the terminal, typically:

```text
https://localhost:7000
```

The exact port may be different depending on the local launch configuration.

## CSV Import and Export

The application supports CSV import and export for selected study tables.

CSV column names must match the fields expected by the application. For general and IMMERSE sample imports, the expected columns are:

```text
BoxNumber,Barcode,BoxRow,BoxColumn,TbldateAdded
```

For ZUMBA sample imports, the expected columns are:

```text
BoxNumber,Barcode,BoxRow,BoxColumn,dateAdded,Round
```

Review and validate all CSV files before importing them into a production database.

## Data Privacy

This repository contains application source code only. Real patient, participant, or biological-sample data should never be committed to the repository.

Any deployment using real research data should follow the applicable institutional policies, study protocols, access controls, and data-protection requirements.

## Project Impact

The application was developed to improve access to more than one million malaria sample records across multiple research studies. By bringing sample identifiers, study information, and physical storage locations into one system, it helps research teams locate and manage laboratory samples more efficiently.

## Future Improvements

Possible future enhancements include:

- Role-based authorization for administrators, laboratory staff, and researchers
- Advanced barcode and study search
- Paginated tables for large datasets
- Duplicate-record detection during CSV imports
- Improved validation and import-error reporting
- Audit logs for sample-record changes
- Dashboard summaries and visual reports
- Automated testing
- Docker-based deployment
- Cloud deployment and database backups

## Author

**Moses Kamya**

- GitHub: [@mkamya20](https://github.com/mkamya20)

## Disclaimer

This application is intended for research and laboratory sample-management purposes. It is not a medical diagnostic system and should not be used to make clinical decisions.
