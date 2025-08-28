# 🚀 User Management API

A clean and modular ASP.NET Core Web API for managing users, authentication, and secure access. Built with MongoDB, custom middleware, and token-based validation.

---

## 📁 Project Structure
├── connection/                 # MongoDB connection setup 
│   └── db.cs 
├── Controllers/               # API endpoints 
│   ├── AuthController.cs 
│   └── UserController.cs 
├── Helpers/                   # Utility classes 
│   └── JWTHelper.cs 
├── Hooks/                     # Custom validation logic 
│   └── CustomValidationResponse.cs 
├── Middlewares/              # Custom middleware components 
│   ├── ExceptionHandlingMiddleware.cs 
│   ├── RequestLoggingMiddleware.cs 
│   └── TokenValidationMiddleware.cs 
├── Models/                    # Data models and DTOs 
│   ├── LoginDto.cs 
│   ├── MongoDbSettings.cs 
│   └── User.cs 
├── Program.cs                 # App entry point 
├── appsettings.json           # Main configuration 
├── appsettings.Development.json 
├── .gitignore

---

## ⚙️ Features

- ✅ **User Authentication** with JWT
- 🔐 **Token Validation Middleware** for secure access
- 📊 **Request Logging Middleware** for observability
- 🛡️ **Exception Handling Middleware** for consistent error responses
- 🧾 **Custom Model Validation** with clean error formatting
- 🗃️ **MongoDB Integration** for persistent storage
- 🧪 **Swagger UI** for interactive API testing

---

## 🧰 Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/your-username/UserManagementAPI.git
cd UserManagementAPI


2. Install dependencies
Make sure you have .NET SDK and MongoDB installed.
dotnet restore


3. Configure MongoDB
Update your appsettings.json:
"MongoDbSettings": {
  "Connection": "mongodb://localhost:27017",
  "DatabaseName": "UserManagement"
}


4. Run the application
dotnet run

Visit https://localhost:5280/swagger to explore the API.

🔐 Authentication
This API uses a simple token-based authentication system. Add your token to the appsettings.json:

"Jwt": {
    "Secret": "your-super-secret-keysuper-long-secret-key-at-least-32-characters!"
}

Public endpoints:
- GET /
- GET /public/info
- POST /api/auth/login
Protected endpoints require a valid token.


🧪 Testing Endpoints
Use the included requests.http file or Swagger UI to test:
- GET /api/user
- POST /api/auth/login
- POST /api/user
- PUT /api/user/{id}
- DELETE /api/user/{id}


🤝 Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you’d like to change.


📜 License
This project is licensed under the MIT License.


# 🚀 Project Structure Overview

A clear view of all folders and files in this project, with icons and badges for quick understanding.

---

## 🔌 Connection
Database connection files:

- ![C#](https://img.shields.io/badge/C%23-db.cs-blue) `db.cs`

---

## 🗂️ Controllers
Handles routing and business logic:

- ![C#](https://img.shields.io/badge/C%23-AuthController.cs-blue) `AuthController.cs`  
- ![C#](https://img.shields.io/badge/C%23-UserController.cs-blue) `UserController.cs`

---

## 🛠️ Helpers
Utility functions:

- ![C#](https://img.shields.io/badge/C%23-JWTHelper.cs-blue) `JWTHelper.cs`

---

## 🪝 Hooks
Custom hooks for validation:

- ![C#](https://img.shields.io/badge/C%23-CustomValidationResponse.cs-blue) `CustomValidationResponse.cs`

---

## 🧩 Middlewares
Pipeline request/response logic:

- ![C#](https://img.shields.io/badge/C%23-ExceptionHandlingMiddleware.cs-blue) `ExceptionHandlingMiddleware.cs`  
- ![C#](https://img.shields.io/badge/C%23-RequestLoggingMiddleware.cs-blue) `RequestLoggingMiddleware.cs`  
- ![C#](https://img.shields.io/badge/C%23-TokenValidationMiddleware.cs-blue) `TokenValidationMiddleware.cs`

---

## 📦 Models
Data models and DTOs:

- ![C#](https://img.shields.io/badge/C%23-LoginDto.cs-blue) `LoginDto.cs`  
- ![C#](https://img.shields.io/badge/C%23-MongoDbSettings.cs-blue) `MongoDbSettings.cs`

---

## ⚙️ Properties
Project configuration:

- ![JSON](https://img.shields.io/badge/JSON-launchSettings.json-orange) `launchSettings.json`

---

## 🏠 Root Files
Main project files at root:

- ![Git](https://img.shields.io/badge/GIT-.gitignore-lightgrey) `.gitignore`  
- ![JSON](https://img.shields.io/badge/JSON-appsettings.Development.json-orange) `appsettings.Development.json`  
- ![JSON](https://img.shields.io/badge/JSON-appsettings.json-orange) `appsettings.json`  
- ![C#](https://img.shields.io/badge/C%23-Program.cs-blue) `Program.cs`

---

## 🗃️ Obj
Temporary build folder:

- `(empty / ignored)`

---

> 💡 **Tip:** Emojis and badges make it easy to quickly identify file types and purpose.  

---

### 🎨 Legend
- 🔌 Connection  
- 🗂️ Controllers  
- 🛠️ Helpers  
- 🪝 Hooks  
- 🧩 Middlewares  
- 📦 Models  
- ⚙️ Properties  
- 🏠 Root Files  
- 🗃️ Obj  

