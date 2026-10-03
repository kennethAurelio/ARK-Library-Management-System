# ARK (Archive & Resource Keeper)

A C# Windows Forms library management system with MySQL integration for students and librarians.

## Overview

ARK streamlines book searching, loan requests, and inventory management through a role-based login for students and librarians.

## Features

- Role-based login (student and librarian/admin)
- Book search by title or author, with cover and synopsis display
- Newest books showcase on the home page
- Loan request and approval workflow
- Inventory and availability tracking
- MySQL database integration

## Tech Stack

- C# / Windows Forms (.NET)
- MySQL
- Visual Studio

## Requirements

- Visual Studio 2022 or later (with .NET desktop development workload)
- MySQL Server 8.0+

## Installation

1. Clone the repository:
   `git clone https://github.com/<your-username>/ARK-Library-Management-System.git`
2. Open the solution in Visual Studio.
3. Import `ark_db_dump.sql` into MySQL.
4. Update the database connection settings with your credentials.
5. Build and run the project.

## Usage

- **Students:** log in with your student ID and password to search books and request loans.
- **Librarians:** log in with admin credentials to manage books and loan requests.

## Contributing

Fork the repo, create a branch (`feature-xyz`), and submit a pull request.

## License

This project is licensed under the MIT License.

## Development Team
- Andrea Ella Toralde — Project Leader & Documentation
- Crisha Jane Amarado — Database Administrator & Documentation
- Kenneth Aurelio — Backend & System Architect
- King Joshsana Tocop — UI/UX Designer
