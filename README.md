# 🌾 Smart Agriculture Backend

Smart Agriculture Backend is a modular, scalable system built with **.NET 8**, designed to manage and optimize agricultural operations, such as farms, fields, soil conditions, weather insights, and crop recommendations.

---

## 🧠 Overview

This backend solution follows modern architectural patterns and uses:
- **.NET 8**
- **Clean Architecture**
- **CQRS (Command Query Responsibility Segregation)**
- **Entity Framework Core**
- **MediatR** for command/query handling
- **AutoMapper** 
- **JWT Authentication**
- **Swagger** for API documentation

---

## 🚀 Features

- ✅ Create and manage Farms, Fields, Users
- ✅ Record Soil Data and Weather Metrics
- ✅ Generate AI-driven crop Recommendations
- ✅ Query weather conditions by field
- ✅ Decoupled architecture via repositories and interfaces
- ✅ Secure API with JWT Authentication

---

## 📁 Project Structure

/src
│
├── SmartAgriculture.API/ # Web API layer (Presentation)
│ ├── Controllers/   # REST API endpoints
│ ├── Program.cs  # Entry point for .NET 8
│ └── appsettings.json  # Configuration file
│
├── SmartAgriculture.Core.Application/ # Application layer (Use cases)
│ ├── Commands/  # CQRS commands
│ ├── Queries/  # CQRS queries
│ ├── Handlers/   # Command/query handlers
│ └── Interfaces/  # Service contracts
│
├── SmartAgriculture.Core.Domain/ # Domain layer (Entities + contracts)
│ ├── Entities/   # Core domain models (Farm, Field, etc.)
│ └── Interfaces/  # Repository contracts
│
├── SmartAgriculture.Infrastructure/ # Infrastructure layer (EF Core, Repos)
│ ├── Persistence/  # EF Core DbContext and configurations
│ └── Repositories/  # Repository implementations
│
└── SmartAgriculture.sln # Solution file

---

## 📘 API Documentation

SmartAgriculture provides interactive API documentation via Swagger.

🔗 **Live Swagger UI**:  
[https://smartagriculture-api-dev-gkbkhpc9cqaretc3.israelcentral-01.azurewebsites.net/swagger/index.html](https://smartagriculture-api-dev-gkbkhpc9cqaretc3.israelcentral-01.azurewebsites.net/swagger/index.html)

You can:
- Explore available endpoints
- Authenticate using JWT tokens
- Test requests with live data

---

## 🧰 Technologies

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://automapper.org/) *(optional)*
- [JWT Authentication](https://jwt.io/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)
- [Swagger](https://swagger.io/)

---

## ⚙️ Getting Started

### ✅ Prerequisites

- .NET 8 SDK
- SQL Server

### 🚀 Setup Instructions

1. **Clone the repository**

```bash
git clone https://github.com/your-org/smart-agriculture-backend.git
cd smart-agriculture-backend

