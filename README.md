## 🔐 Authentication
 
JWT-based login system is implemented:
 
- `POST /auth/login`: Logs in a user, returns JWT
- Secure endpoints require `Authorization: Bearer <token>`
- The frontend securely stores the authentication token in localStorage and attaches it to protected API requests.
 
---
 
## 🌱 Seed Data
 
The initial database migration includes seeded data:
 
### 🔹 Properties & Spaces
- **10 Properties** are created with realistic data.
- **2-5 Spaces** are linked to some of those properties.
 
### 🌍 Location Data
- Sample **Country** and **State** data is seeded for use in property location selection..
### 🔐 Default User
For testing the authentication and authorization features:
 
- **Email:** `Admin@gmail.com`  
- **Password:** `Pass@123`
---
 
## 📄 API Endpoints
 
### 🔑 Auth
- `POST /auth/login` - Authenticate and return JWT token
- `POST /auth/logout` - Invalidate the current user session (e.g., clear client-side stored tokens).  
 
 
### 🏘 Properties
- `GET /properties` - List all properties with filters (`type`, `min_price`, `max_price`)
- `GET /properties/{id}` - Get property by ID (includes spaces)
- `POST /properties` - Add new property (with optional nested spaces)
 
### 🛏 Spaces
- `GET /spaces` - List spaces with filters (`property_id`, `type`, `min_size`)
 
### 🌍 Locations
- `GET /countries` - List all countries
- `GET /states` - List all states
 
---
 
## 🧾 Data Model
 
### Property
| Field       | Type     | Description                                    |
|-------------|----------|------------------------------------------------|
| Id          | GUID     | Primary Key                                    |
| Type        | string   | Property type (max 50 chars, e.g., "house")    |
| Price       | decimal  | Sale/rent price in USD                         |
| Description | string   | Property description   (nullable)              |
| Address     | string   | Full address (max 255 chars)                   |
| City        | string   | City name (max 255 chars)                      |
| PostalCode  | string   | Postal/ZIP code (max 10 chars)                 |
| StateId     | GUID     | Foreign key to State                           |
| State       | State    | Navigation property                            |
| CountryId   | GUID     | Foreign key to Country                         |
| Country     | Country  | Navigation property                            |
| Spaces      | ICollection<Space> | Collection of spaces within property |
 
---
 
### Space
| Field       | Type     | Description                                |
|-------------|----------|--------------------------------------------|
| Id          | GUID     | Primary Key                                |
| Type        | string   | Space type (max 50 chars, e.g., "bedroom") |
| Size        | float    | Size in square feet                        |
| Description | string   | Space description   (nullable)             |
| PropertyId  | GUID?    | Foreign key to Property (nullable)         |
| Property    | Property?| Navigation property                        |
 
---
 
### Country
| Field       | Type     | Description                          |
|-------------|----------|--------------------------------------|
| Id          | GUID     | Primary Key                          |
| Name        | string   | Country name (max 100 chars)         |
| Code        | string   | Country code (max 3 chars)           |
| Properties  | ICollection<Property> | Properties located here |
| States      | ICollection<State>    | States within country   |
 
---
 
### State
| Field       | Type     | Description                          |
|-------------|----------|--------------------------------------|
| Id          | GUID     | Primary Key                          |
| Name        | string   | State name (max 100 chars)           |
| Code        | string   | State code (max 3 chars)             |
| CountryId   | GUID     | Foreign key to Country               |
| Country     | Country  | Navigation property                  |
| Properties  | ICollection<Property> | Properties in this state|
 
---
 
## 🌐 CORS Policy
 
To enable communication between the React frontend and the ASP.NET Core backend, a **CORS policy** is configured in the API.
 
---
 
## 🚀 How to Run the Project
 
Follow these steps to set up and run the Property Search Web App locally:
 
### 1. Clone the Repository
 
- git clone https://github.com/rishal-aspirefox/PropertySearch.git
cd PropertySearchApp
 
### 2. Open the Project in Visual Studio
 
- Launch Visual Studio 2022 (or later).
- Select Open a project or solution.
- Navigate to the cloned folder and open the PropertySearchBackend.sln solution file.
 
### 3. Configure Database Connection
 
- Open appsettings.json file inside the PropertySearch project.
- Update the connection string to point to your local database instance.
- Example connection string format:
 
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server={{YOUR_SERVER}};Database=PropertySearchDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```
 
### 4. Apply Entity Framework Migrations
 
- Open Package Manager Console **(Tools > NuGet Package Manager > Package Manager Console)**.
- Set the Default project dropdown to PropertySearch.Infrastructure.
- Run the following command to create or update the database schema:
```bash
Update-Database
```
### 5. Run the Frontend React Application
 
- Open a terminal or command prompt.
 
- Install frontend dependencies:
```bash
npm install
```
 
- Start the React development server:
```bash
npm run dev
```
- Open your browser and go to:
```bash
http://localhost:5173
```
