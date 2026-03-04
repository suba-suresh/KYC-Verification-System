# 📌 KYC Verification System

A full-stack Identity Verification (KYC) platform built using ASP.NET Core and React, designed to simulate real-world verification workflows used in regulated and high-integrity systems.

This project demonstrates backend architecture design, RESTful API development, admin approval workflows, and full-stack integration.

---

## 🚀 Project Overview

The KYC Verification System allows users to:

- Submit identity verification details  
- Upload supporting documents (ID/Passport)  
- Upload selfie images  
- Track verification status (Pending / Approved / Rejected)  

It also includes an **Admin Dashboard** to:

- View all submissions  
- Review uploaded documents  
- Approve or reject verification requests  
- Manage the verification lifecycle  

The system follows clean architecture principles and simulates real-world verification platforms used in financial services and regulated industries.

---

## 🏗 Architecture

The backend follows a **Layered Architecture** approach:

Controller → Service Layer → Repository Layer → Database

- Controllers handle HTTP requests  
- Services contain business logic  
- Repositories manage database operations  
- Entity Framework Core handles ORM  
- SQL Server stores verification records  

### Frontend Architecture

Built using:

- React (Vite)
- REST API integration
- Role-based dashboard views (User/Admin)

---

## 🛠 Tech Stack

### 🔹 Backend

- C#  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- RESTful API design  
- Asynchronous programming (async/await)  
- Dependency Injection  

### 🔹 Frontend

- React  
- JavaScript  
- Axios / Fetch API integration  
- Conditional rendering  
- State management  

### 🔹 Tools

- Git  
- Postman  
- Visual Studio  
- VS Code  

---

## 🔁 Verification Workflow

1. User submits personal details and uploads documents.  
2. Submission is stored with status: `Pending (0)`.  
3. Admin reviews submission.  
4. Admin updates status:
   - `Approved (1)`
   - `Rejected (2)`  
5. User dashboard reflects updated status.  

---

## 📂 File Handling

Uploaded files (documents & selfies) are:

- Stored locally in an `Uploads` directory  
- Saved with unique GUID filenames  
- File paths stored in the database  
- Linked to verification records  

---

## 🔐 Key Features

- RESTful API with proper HTTP methods (GET, POST, PUT)  
- Clean separation between DTOs and domain entities  
- Async database operations for scalability  
- Role-based UI (User / Admin)  
- Approval & rejection lifecycle management  
- Structured error handling  
- Validation logic for user input  
- Git monorepo structure (Frontend + Backend)  

---

## 📊 Example API Endpoint

### `GET /api/verification/{id}`

**Response:**

```json
{
  "id": 5,
  "fullName": "Joe Paul",
  "documentType": "Passport",
  "status": 0,
  "createdAt": "2026-03-01T19:53:53.7710232"
}
```

---

## ⚙ How to Run the Project

### 🔹 Backend

```bash
cd VerificationApi
dotnet run
```

Runs on:

```
http://localhost:5001
```

---

### 🔹 Frontend

```bash
cd KYC-Frontend
npm install
npm run dev
```

Runs on:

```
http://localhost:5173
```

---

## 🧠 Design Considerations

- Used scoped `DbContext` to avoid concurrency issues.  
- Applied async methods to improve request handling efficiency.  
- Followed SOLID principles for maintainability.  
- Implemented separation of concerns for enterprise-style structure.  

---

## 📈 Future Improvements

- Cloud storage integration (Azure / AWS S3)  
- Event-driven processing 
- Facial recognition API integration  
- Authentication & role-based authorization (JWT)  
- Docker containerization  
- CI/CD pipeline automation  

---

## 🎯 Purpose of the Project

This project was built to:

- Demonstrate backend API architecture skills  
- Simulate real-world identity verification workflows  
- Practice full-stack integration  
- Explore scalable system design concepts  
- Strengthen understanding of regulated-domain systems  

---

## 👤 Author

**Suba Suresh**  
Backend-focused Software Developer
