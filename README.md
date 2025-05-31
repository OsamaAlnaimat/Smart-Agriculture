# 🌱 Smart Agriculture System

A .NET-based Smart Agriculture system designed using **Clean Architecture** principles. It provides farm and field management, soil and weather data recording, and AI-based crop recommendations using CQRS and MediatR.

---

## 📦 Project Structure

SmartAgriculture/
├── SmartAgriculture.API # ASP.NET Core Web API (Presentation Layer)
├── SmartAgriculture.Application # Application Layer (CQRS, Handlers, DTOs)
├── SmartAgriculture.Domain # Core Entities, Enums, Interfaces
├── SmartAgriculture.Infrastructure # DB, Repositories, External Services
├── SmartAgriculture.Tests # Unit & Integration Tests

yaml
Copy
Edit

---

## 🔧 Technologies Used

- **.NET 8 / ASP.NET Core**
- **Entity Framework Core**
- **MediatR (CQRS Pattern)**
- **AutoMapper**
- **FluentValidation**
- **RestSharp (AI Service Integration)**
- **SQL Server / SQLite**
- **xUnit, Moq, FluentAssertions**

---

## 🚀 Features

- 🌾 Manage farms and fields
- 📊 Record soil data and weather conditions
- 💡 Generate AI-based crop recommendations
- 🔒 Identity features (Registration, Reset Password)
- ✅ Clean Architecture with CQRS + MediatR
- 📡 External API Integration (AI & Weather)

---

## 📥 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/SmartAgriculture.git
cd SmartAgriculture