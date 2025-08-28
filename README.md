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


