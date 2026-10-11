# Telly: Television Store

Telly is an online TV store built with **ASP.NET Core MVC**, **Entity Framework Core** and **SQL Server Express**. Customers can browse a catalog of televisions and accessories, add items to a cart, and complete an order through a checkout form.

I built this project to practice full-stack web development with the .NET stack: database design, data access with EF Core, MVC architecture, and a working shopping flow from catalog to checkout.

## Demo Video

Watch a walkthrough of the project here:

**[Telly demo on YouTube (unlisted)](https://youtu.be/RoMRoDof4ZY)**

## Features

- Product catalog with televisions and accessories
- Shopping cart that persists in the browser using `localStorage`
- Checkout form for placing an order
- SQL Server database (`tellydb`) accessed through EF Core (database-first approach)
- Clean MVC structure: Models, Views and Controllers

## Tech Stack

| Layer | Technology |
|-------|------------|
| Framework | ASP.NET Core MVC |
| Language | C# |
| Data access | Entity Framework Core (database-first) |
| Database | SQL Server Express (`tellydb`) |
| Front end | Razor views, HTML, CSS, JavaScript |
| Cart storage | Browser `localStorage` |

## Project Structure

```
TelevisionStore/
├── Telly/                  # ASP.NET Core MVC application
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   └── wwwroot/
├── TELLYQUERIES.sql        # SQL script for the tellydb database
├── TelevisionStore.slnx    
└── README.md
```

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (the version used by the project)
- [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads)
- SQL Server Management Studio (SSMS) or any tool that can run `.sql` scripts
- Visual Studio (recommended) or VS Code

### 1. Clone the repository

```bash
git clone https://github.com/ali-533/telly-store.git
cd telly-store
```

### 2. Create the database

1. Open SQL Server Management Studio and connect to your local SQL Server Express instance.
2. Open `TELLYQUERIES.sql`.
3. Run the script to create the `tellydb` database and its tables, and to insert the sample data.

### 3. Configure the connection string

Open `Telly/appsettings.json` and make sure the connection string matches your SQL Server instance. For example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=tellydb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

> The exact key name may differ in your copy of the project. Keep the name that already exists in `appsettings.json` and only change the server name if needed.

### 4. Run the application

From Visual Studio, open `TelevisionStore.slnx` and press **F5**.

Or from the terminal:

```bash
cd Telly
dotnet run
```

Then open the URL shown in the terminal (usually `https://localhost:xxxx`).

## What I Learned

- Designing a relational database and writing SQL queries
- Using Entity Framework Core with a database-first workflow
- Structuring an application with the MVC pattern
- Managing a shopping cart on the client side with `localStorage`
- Handling form input and building a checkout flow
- Using Git and GitHub to version and publish a project

GitHub: [ali-533](https://github.com/ali-533)
