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

⚙️ Installation
1️⃣ Prerequisites

.NET 6 or later

MongoDB
 (local or cloud - MongoDB Atlas)

Visual Studio
 or VS Code

2️⃣ Clone the repository
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name

3️⃣ Restore dependencies
dotnet restore

4️⃣ Configure environment variables

Update appsettings.json or appsettings.Development.json with your MongoDB connection string:

"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "YourDatabaseName"
},
"Jwt": {
  "Secret": "your-super-secret-keysuper-long-secret-key-at-least-32-characters!"
}

🚀 Running the Project

Development mode
dotnet run

Build & run
dotnet build
dotnet run

API will be available at:
https://localhost:7145
http://localhost:5280

🛠 Technologies Used

.NET 6/7 Web API

MongoDB for database

JWT Authentication

Custom Middlewares (logging, exception handling, token validation)

📌 Usage Notes

✅ Use AuthController to login & retrieve JWT token.

✅ Attach the token in the Authorization: Bearer <token> header for protected routes.

✅ Extend UserController for CRUD operations with your User model.

✅ Middlewares handle logging, error responses, and authentication globally.

🤝 Contribution

Contributions, issues, and feature requests are welcome!
Feel free to open a PR or issue to improve this project.

📜 License

Distributed under the MIT License. See LICENSE for more information.
