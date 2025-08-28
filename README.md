# <span style="color:#FF0000">**My App**</span> [![Build Status](https://travis-ci.org/username/myapp.svg?branch=master)](https://travis-ci.org/username/myapp)

**My App** is a web application built with [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) and [MongoDB](https://www.mongodb.com/). The application allows users to register and login, and it stores user data in a MongoDB database.

## Features

- **User Registration**: Users can register with a unique username and password.
- **User Login**: Users can login with their username and password.
- **Data Storage**: User data is stored in a MongoDB database.
- **Token-Based Authentication**: Users receive a JSON Web Token (JWT) upon successful login, which can be used to authenticate subsequent requests.

## Requirements

- .NET 9 or later
- MongoDB 6 or later

## Installation

1. Clone the repository: `git clone https://github.com/username/myapp.git`
2. Change into the project directory: `cd myapp`
3. Restore the NuGet packages: `dotnet restore`
4. Run the application: `dotnet run`

## Configuration

The application uses the following environment variables:

- `MONGO_DB_URI`: The URI of the MongoDB database.
- `JWT_SECRET`: The secret key used to sign the JSON Web Tokens.

You can set these environment variables using the following commands:

- `export MONGO_DB_URI="mongodb://localhost:27017"`
- `export JWT_SECRET="my_secret_key"`

## Usage

- Open a web browser and navigate to `http://localhost:5000`
- Register a new user by submitting the registration form.
- Login with the registered user credentials.
- The user data will be stored in the MongoDB database.
- The user will receive a JSON Web Token upon successful login, which can be used to authenticate subsequent requests.

## Testing

The application uses [xUnit](https://xunit.github.io/) for unit testing. To run the tests, use the following command:

- `dotnet test`

## Contributing

Contributions are welcome! If you'd like to contribute, please fork the repository and submit a pull request. Please make sure to add tests for any new functionality.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
