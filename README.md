# URL Shortening Service

**Project Overview**
The URL Shortening Service is a full-stack web application built with ASP.NET Core for the back end and React for the front end. This service allows users to input a long URL, specify a desired short URL length, and receive a shortened URL that redirects to the original long URL.

## Features
1. Create and store shortened URLs.
2. Redirect to the original URL when the shortened URL is used.
3. Specify the length of the shortened URL.
4. User-friendly React-based UI.

## Table of Contents

- Technologies Used

- Architecture

- Prerequisites

- Setup and Installation

- Running the Project

- API Documentation

- Front-End Usage

- Troubleshooting

- License

## Technologies Used

## Back End (API)

- ASP.NET Core 7.0
- Entity Framework Core
- SQL Server for data persistence
## Front End
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
   1. Install dependencies: Ensure your .NET environment is set up and run:
        ``` git clone https://github.com/yourusername/url-shortener-api.git
        cd url-shortener-api
      
  2. **Install dependencies**: Ensure your .NET environment is set up and run:
      
