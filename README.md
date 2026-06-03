# MiniEMR - Backend API

## Tech Stack
- .NET 8 Web API
- Entity Framework Core 8
- SQL Server
- JWT Authentication
- BCrypt Password Hashing
- Swagger

## Project Structure

MiniEMR.API/
├── Controllers/
├── Services/
│   ├── Interfaces/
│   └── Implementations/
├── Repositories/
│   ├── Interfaces/
│   └── Implementations/
├── Entities/
├── DTOs/
├── Mappings/
├── Configurations/
├── Data/
├── Constants/


## Setup
1. Update `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=MiniEMR;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyAtLeast32CharactersLong",
    "Issuer": "MiniEMR_API",
    "Audience": "MiniEMR_Angular",
    "ExpiryInMinutes": 480
  }
}
```
2. Run SQL DDL script, then seed data for Users and Medicines.
3. Run:
```bash
dotnet restore
dotnet run
```
- API: `https://localhost:7001`
- Swagger: `https://localhost:7001/swagger`

## API Endpoints

### Auth
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/auth/login | User login |
| POST | /api/auth/logout | User logout |

### Patients
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/patients | Get all patients |
| GET | /api/patients/{id} | Get patient by ID |
| POST | /api/patients | Register patient |
| PUT | /api/patients/{id} | Update patient |
| GET | /api/patients/{id}/visits | Get visit history |

### Appointments
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/appointments | Get by date |
| GET | /api/appointments/doctor/today | Doctor's today |
| GET | /api/appointments/{id} | Get by ID |
| POST | /api/appointments | Book appointment |
| PUT | /api/appointments/{id}/checkin | Check-in |
| PUT | /api/appointments/{id}/cancel | Cancel |
| GET | /api/appointments/status-counts | Dashboard stats |

### Visits
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/visits | Create visit |
| GET | /api/visits/{appointmentId} | Get by appointment |

### Medicines
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/medicines | Get all medicines |

### Doctors
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/doctors | Get all doctors |

## Test Accounts
| Username | Password | Role |
|----------|----------|------|
| dr.ahmed | Doctor@123 | Doctor |
| dr.fatima | Doctor@123 | Doctor |
| recep.ali | Recep@123 | Receptionist |
| recep.sara | Recep@123 | Receptionist |

## Auth Header
├── Middleware/
├── Helpers/
└── Extensions/
