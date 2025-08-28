# 🟦 .NET Web API Project

A clean and modular **.NET 6/7 Web API** project with authentication, middlewares, MongoDB integration, and reusable components.  
This project is designed to be a starting point for building scalable backend applications.

---

## 📂 Project Structure

```plaintext
├── connection/
│   └── db.cs                # Database connection logic
│
├── Controllers/
│   ├── AuthController.cs    # Authentication endpoints
│   └── UserController.cs    # User management endpoints
│
├── Helpers/
│   └── JWTHelper.cs         # JWT token generation & validation
│
├── Hooks/
│   └── CustomValidationResponse.cs # Custom validation handling
│
├── Middlewares/
│   ├── ExceptionHandlingMiddleware.cs  # Global exception handling
│   ├── RequestLoggingMiddleware.cs     # Logs incoming requests
│   └── TokenValidationMiddleware.cs    # Token validation middleware
│
├── Models/
│   ├── LoginDto.cs          # DTO for login requests
│   ├── MongoDbSettings.cs   # MongoDB configuration model
│   └── User.cs              # User entity model
│
├── Properties/
│   └── launchSettings.json  # Local run configuration
│
├── appsettings.json         # Main configuration
├── appsettings.Development.json
├── Program.cs               # Entry point of the API
└── .gitignore

