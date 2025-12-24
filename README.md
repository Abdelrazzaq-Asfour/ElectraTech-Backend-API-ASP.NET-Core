# ⚙️ ElectraTech-Backend-API-ASP.NET-Core

 # Frontend-Angular 
 
<img width="1897" height="881" alt="image" src="https://github.com/user-attachments/assets/e33574d5-d40c-44f3-bbd1-257f0024df03" />

**ElectraTech Backend** is a robust RESTful API built with **ASP.NET Core 9.0.** It manages the core business logic and admin dashboard operations for the ElectraTech e-commerce platform, including secure authentication, user profile management, role-based access control, and seamless data persistence with **PostgreSQL**.

## 🚀 Key Features

* **User Authentication**: Secure endpoints for user Login and Registration with data validation.
* **Profile Management**: Dedicated API support for updating user information (Full Name, Email, and Password).
* **Database Integration**: Built-in support for **PostgreSQL** using **Entity Framework Core**.
* **CORS Policy**: Configured to allow secure requests from the Angular frontend running on port `4200`.
* **Optimized JSON**: Features CamelCase naming policies and reference handling to prevent object cycles.

## 🛠 Tech Stack

* **Framework**: ASP.NET Core 9.0 Web API.
* **ORM**: Entity Framework Core.
* **Database**: PostgreSQL.
* **Language**: C# 13.
* **Communication**: RESTful API Design.

## ⚙️ Installation & Setup

### Prerequisites

* **.NET 9.0 SDK**
* **PostgreSQL** Database

### Steps to Run

1. **Clone the Repository**:
```bash
git clone https://github.com/your-username/ElectraTech-Backend-API-ASP.NET-Core.git
cd ElectraTech-Backend-API-ASP.NET-Core

```


2. **Database Connection**:
Update the `DefaultConnection` string in `appsettings.json` with your PostgreSQL credentials.
3. **Apply Database Migrations**:
```bash
dotnet ef database update

```


4. **Run the API**:
```bash
dotnet run

```
The server will start at `http://localhost:5000`.

## 📡 API Endpoints

### Auth Controller

| Method | Endpoint | Description |
| --- | --- | --- |
| `POST` | `/api/Auth/login` | Authenticates user and returns ID, FullName, and Role. |
| `POST` | `/api/Auth/register` | Handles new user registration in PostgreSQL. |
| `PUT` | `/api/Auth/update/{id}` | Updates existing user profile data based on ID. |

---


