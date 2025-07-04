# AIFitnessProject

[![.NET Build](https://github.com/your-username/AIFitnessProject/actions/workflows/dotnet.yml/badge.svg)](https://github.com/your-username/AIFitnessProject/actions/workflows/dotnet.yml)

A modern, AI-driven web application designed to provide users with personalized fitness and nutrition plans. This project connects users with trainers and dietitians to help them achieve their health goals.

## ✨ Key Features

- **User Roles:** Distinct roles for regular Users, Trainers, and Dietitians.
- **Personalized Plans:**
    - Users can request and receive custom training plans from trainers.
    - Users can request and receive tailored diet plans from dietitians.
- **Interactive Calendar:** View and manage daily workouts and meals.
- **Feedback System:** Users can provide feedback on individual meals and exercises.
- **Communication:** Direct messaging and notification system for seamless interaction between users and professionals.
- **Admin Areas:** Dedicated areas for trainers and dietitians to manage their clients and content.
- **Document Management:** Upload and manage relevant documents.

## 🛠️ Tech Stack

- **Backend:** C#, ASP.NET Core 8.0
- **Database:** Microsoft SQL Server with Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Frontend:** Razor Pages, HTML, CSS, JavaScript
- **Real-time Communication:** SignalR (for notifications)
- **Architecture:** Clean Architecture approach with distinct layers for Core, Infrastructure, and Web.

## 📂 Project Structure

The solution is organized into several projects, following Clean Architecture principles:

-   `AIFitnessProject/`: The main ASP.NET Core Web Application (UI Layer).
-   `AIFitnessProject.Core/`: Contains the core business logic, services, DTOs, and contracts (interfaces).
-   `AIFitnessProject.Infrastructure/`: Handles data access, including the `DbContext`, repositories, and database migrations.
-   `TestAiFiness/`: A dedicated project for unit and integration tests.

## 🚀 Getting Started

### Prerequisites

-   [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
-   A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).

### Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/AIFitnessProject.git
    cd AIFitnessProject
    ```

2.  **Configure Database Connection:**
    -   Open `AIFitnessProject/appsettings.json`.
    -   Update the `DefaultConnection` string to point to your local SQL Server instance.

3.  **Apply Database Migrations:**
    -   Open a terminal in the root directory.
    -   Run the following command to create the database and apply the schema:
    ```bash
    dotnet ef database update --project AIFitnessProject.Infrastructure
    ```

4.  **Run the Application:**
    -   You can run the project using your IDE (Visual Studio/VS Code) or via the command line:
    ```bash
    dotnet run --project AIFitnessProject
    ```
    The application will be available at `https://localhost:5001` (or a similar address).

## 🧪 Testing

The `TestAiFiness` project contains the tests for the application. To run the tests, execute the following command from the root directory:

```bash
dotnet test
```

## 🤝 Contributing

Contributions are welcome! If you have suggestions or want to improve the project, please feel free to:
1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## 📄 License

This project is licensed under the MIT License. See the `LICENSE.txt` file for details.
