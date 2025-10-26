# Advanced Full-Stack CMS Platform

This repository showcases a modern, **decoupled three-tier architecture** built on industry best practices for scalability, testability, and performance.

---

## 🏗️ Architectural Highlights

### 1. Decoupled Architecture (API-First)

The project cleanly separates the **Presentation Tier** (Angular) from the **Logic/Data Tier** (ASP.NET Core Web API), ensuring maximum flexibility. Communication is handled exclusively via secure **RESTful** endpoints.

### 2. Design Patterns & OOP

* **Generic Repository Pattern:** Implemented using the **`IRepository<T>`** interface, which enforces **Abstraction** and **Separation of Concerns**. This pattern ensures the API Controllers are completely agnostic to the underlying database technology (SQL Server).
* **Dependency Inversion Principle (DIP):** Achieved through **Dependency Injection (DI)**, where services (like the data access layer) are provided via contracts, promoting **loose coupling** and enabling straightforward unit testing.
* **Generics (`<T>`):** Utilized in the Repository to create a single set of reusable CRUD methods that work for all entities.

### 3. Scalability & Performance

* **Asynchronous Programming:** All database I/O operations (via EF Core) use **`async`** and **`await`** keywords, optimizing server thread utilization and improving throughput for concurrent users.
* **Modern Data Access:** Leverages **Entity Framework Core (EF Core)** for robust, code-first data management and schema versioning via Migrations.

### 4. Frontend Standards

* **Standalone Components:** Uses the modern Angular standard for simplified structure and component organization.
* **Signals:** Employs reactive **Signals** for efficient, explicit, and high-performance state management within the components.

---

## 💻 Tech Stack

| Layer | Technology | Key Version | Core Purpose |
| :--- | :--- | :--- | :--- |
| **Frontend** | **Angular** | v17+ | Presentation, UI/UX |
| **Backend** | **ASP.NET Core Web API** | .NET 8 / 9 | Business Logic, Security |
| **Database** | **SQL Server** | - | Data Persistence |
| **Styling** | **Tailwind CSS / Angular Material** | - | Utility-First Styling & UI Components |

---

## 🛠️ Getting Started

To run this project, ensure you have the .NET SDK and Node.js installed.

1.  **Clone the Repository:** `git clone ...`
2.  **Run Migrations:** Configure your database connection string and run `Update-Database`.
3.  **Start Backend:** Navigate to the API folder and run `dotnet run`.
4.  **Start Frontend:** Navigate to the Angular folder and run `ng serve --open`.
