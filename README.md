# Northwind Backend API

This project is a layered architecture backend developed with .NET and C#.  
It includes features like AOP (Aspect Oriented Programming), Validation, Caching, and Transaction Management.

## 🚀 Technologies Used

- **.NET 8 & C#**  
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Autofac** for Dependency Injection
- **FluentValidation** for input validation
- **JWT** for authentication and token-based security
- **Custom Result Types** for structured error/success handling
- **AOP (Aspect-Oriented Programming)** via dynamic proxies
- **Caching** using MemoryCache
- **Transactional operations** using Autofac interceptors

## 🧱 Project Structure

- `Business/` → Business logic and services  
- `Core/` → Cross-cutting concerns (logging, caching, etc.)  
- `DataAccess/` → Database operations (EF Core)  
- `Entities/` → Data models  
- `WebAPI/` → API endpoints (controllers)

## ⚙️ How to Run

1. Clone the repo  
2. Open `NorthwindBackend.sln` in Visual Studio  
3. Set `WebAPI` as Startup Project  
4. Run with IIS Express or `dotnet run`

---

## 🧪 Upcoming Features

- Unit Tests  
- Swagger Documentation  
- Docker Support  
