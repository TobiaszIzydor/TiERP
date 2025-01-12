# TiErp - Simple Management System

**TiErp** is a simple system designed to manage:  
- **Products**  
- **Employees**  
- **Production Lines**  
- **Orders**  

This project is easy to set up and use, ideal for small-scale production environments or as a starting point for further development.

---

## Installation Guide

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [PostgreSQL](https://www.postgresql.org/download/)  

### Steps to Install

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/your-repo/TiErp.git
   cd TiErp
   ```

2. **Configure the Database**  
   - Open `appsettings.json.dist`.  
   - Add your PostgreSQL connection string in the `ConnectionStrings` section, for example:  
     ```json
     {
       "ConnectionStrings": {
         "TiErp": "Host=localhost;Port=5432;Database=TiErpDB;Username=your_username;Password=your_password"
       }
     }
     ```  
   - Rename `appsettings.json.dist` to `appsettings.json`.  

3. **Apply Migrations**  
   Run the following command to create and update the database schema:  
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**  
   Start the system with:  
   ```bash
   dotnet run
   ```

   The app will be accessible at `http://localhost:5000` by default.

---

## Features
- Manage **products**, **employees**, **production lines**, and **orders**.  

---

## Contributing
Feel free to submit issues or pull requests to improve the system!

---

## License
This project is licensed under the [MIT License](LICENSE).

Enjoy using TiErp!