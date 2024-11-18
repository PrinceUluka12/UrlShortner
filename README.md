# URL Shortening Service

**Project Overview**
The URL Shortening Service is a full-stack web application built with ASP.NET Core for the back end and React for the front end. This service allows users to input a long URL, specify a desired short URL length, and receive a shortened URL that redirects to the original long URL.

## Features
1. Create and store shortened URLs.
2. Redirect to the original URL when the shortened URL is used.
3. Specify the length of the shortened URL.
4. User-friendly React-based UI.

## Table of Contents

- [Technologies Used](#technologies-used)

- [Architecture](#architecture)

- [Prerequisites](#prerequisites)

- [Setup and Installation](#setup-and-installation)

- [Running the Project](#running-the-project)

- [API Documentation](#api-documentation)

- [Front-End Usage](#front-end-usage)

- [Troubleshooting](#troubleshooting)

## Technologies Used

  **Back End (API)**

- ASP.NET Core 7.0
- Entity Framework Core
- SQL Server for data persistence
   **Front End**
- React (Create React App)
- Axios for HTTP requests
- Bootstrap 4.5 for styling

## Architecture
The project follows a client-server architecture:

- API (ASP.NET Core): Handles URL creation, storage, and redirection.
- Front End (React): Provides a user interface for inputting and displaying URLs.

## Prerequisites
Before setting up the project, ensure you have:

- .NET SDK 7.0 or later
- Node.js (version 16.x or later)
- SQL Server installed locally or on a server
- Visual Studio 2022 or Visual Studio Code

## Setup and Installation 
## 1. Back-End (API)
   1. Clone the repository:
        ```
        git clone https://github.com/PrinceUluka12/UrlShortner.git
        cd UrlShortener.API
        ```
      
  2. **Install dependencies**: Ensure your .NET environment is set up and run:
        
     
           dotnet restore
        
  3. **Configure the database:**
      - Update the connection string in `appsettings.json`:
        ```
         "ConnectionStrings": {"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Url_Shorter;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"} ```

  4. **Run the API:**
      ```
     dotnet run
      ```
The API should be accessible at https://localhost:7038. 

## 2. Front-End (React)
   1. **Navigate to the React project:**
         ```
         cd UrlShortener.Frontend
         ```
   2. **Install dependencies:**
         ```
         npm install
         ```
   3. **Configure the API endpoint:**
         - Update `App.jsx` or create a configuration file to set the API base URL to `https://localhost:7038`.
   4. **Run the React development server:**
         ```
         npm start
         ```
         The React app should be accessible at `http://localhost:5173`.


# Running the Project
**Running Both Projects Simultaneously**
1. Ensure the API (`https://localhost:7038`) is running.
2. Run the React front-end (`http://localhost:5173`).
   
Note: CORS policies should be configured to allow requests from the React app to the API.


# API Documentation 

**Endpoint:** POST /api/UrlShortener/shorten

- **Description:** Creates a shortened URL.

- **Request Body:**
  ```
     {
  "userName": "JohnDoe",
  "longUrl": "https://example.com/long-url-example",
  "length": 8
     }
  ```
  
- **Response:**
   ```
  {
    "isSuccess": true,
    "message": "Successful",
    "result": {
        "shortUrl": "vcmNEFgs"
    }
  }
   ```

**Endpoint:** `GET /redirect/{shortUrl}`
- **Description**: Uses to short url to fetch the long url from the database.
  
- **Path Parameter**:
   - shortUrl: The generated shortened URL.  Example  -  https://localhost:7038/api/UrlShortener/vcmNEFgs
- **Response**:
     ```
     {
    "isSuccess": true,
    "message": "Successful",
    "result": {
       "longUrl": "https://example.com/long-url-example"
      }
     }
     ```

# **Front-End Usage**
     
1. **Access the React App** at `http://localhost:5173`.
   
2. **Input the required data:**
   - Enter your user name.
   - Enter the long URL to be shortened.
   - Specify the desired length of the shortened URL.
3. **Submit the form** to receive a generated short URL.
4. **Click the generated short URL** to be redirected to the original URL.
       
# Troubleshooting

**Common Issues**

- **CORS Policy Errors:** Ensure the CORS policy in `Program.cs` allows requests from `https://localhost:5173`.
- **Database Connection:** Verify that the SQL Server is running and the connection string in `appsettings.json` is correct.
- **Port Mismatches:** Ensure the API and React app are configured on the correct ports (`7038` for the API, `5173` for the React app).

  
**Additional Debugging Tips**
- **Inspect the browser console** for network errors.
- **Check the Network tab** in developer tools to verify API requests and responses.
      
