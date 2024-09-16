# ToDo App

## Overview

The Todo App is a module designed to be integrated into the currently used budgeting application. It allows customers to log tasks through the support section when encountering issues. These tasks trigger notification emails to the Support Line or the Business Analysis Team Leader. Customers can add a title, description, and a photo related to the issue. When a task is logged, the creation date and time are recorded in the database.

Authorized personnel or team leaders can log into the system after receiving the notification email and view the task. They can assign the task to any employee within the company. The designated employee will receive a notification email. Employees can view only tasks assigned to them or their team. They can see the details of the issue and, if a photo was uploaded, view it in a larger format. After completing the task, employees can click the "Done" button, which records the completion time in the database. Upon task completion, the team leader will receive a notification email.

Additionally, the **Task Chat Feature** allows users to ask questions or request detailed information about a task.


## Features

- Customers can report issues with a title, description, and photo upload.
- Task assignment and notification email system.
- Photo upload and viewing feature.
- Task completion and email notification.
- Role-based task assignment and tracking.
- Ability to assign tasks to entire teams and group email notifications.
- **Task Chat Feature:** Allows users to ask questions or request detailed information about a task.

## Technologies Used

- **Programming Language:** Visual Basic (can also be implemented in C#)
- **Database:** Microsoft SQL Server (Managed via SQL Server Management Studio)
- **Database Integration:** Entity Framework Database First approach
- **Email Notifications:** SMTP protocol
- **UI Development:** DevExpress WinForms

## Database Tables

### tblTasks

| Column Name     | Data Type     |
|-----------------|---------------|
| TaskID          | int           |
| Title           | nvarchar(30)  |
| Description     | nvarchar(1000)|
| Photograph      | varbinary(MAX)|
| IsCompleted     | bit           |
| CreatedTime     | datetime      |
| CompletedTime   | datetime      |
| AssignedToUser  | int           |
| AssignedToTeam  | int           |
| Comment         | nvarchar(1000)|

### tblRoles

| Column Name | Data Type    |
|-------------|--------------|
| RoleID      | int          |
| RoleName    | nvarchar(100)|

### tblTeams

| Column Name | Data Type    |
|-------------|--------------|
| TeamID      | int          |
| TeamName    | nvarchar(100)|

### tblUsers

| Column Name | Data Type    |
|-------------|--------------|
| UserID      | int          |
| Username    | nvarchar(20) |
| Password    | nvarchar(20) |
| RoleID      | int          |
| Email       | nvarchar(100)|
| TeamID      | int          |

### tblMessages

| Column Name | Data Type    |
|-------------|--------------|
| MessageID   | int          |
| TaskID      | int          |
| UserID      | int          |
| Message     | nvarchar(1000)|
| Time        | datetime     |

The relationships between tables are illustrated in the diagram below:
![Database Diagram](/DatabaseDiagram.png)

## Installation

1. **Clone the Repository:**

    ```bash
    git clone https://github.com/username/todo-app.git
    ```

2. **Create the Database:**
   Set up the database, tables, and diagram.

3. **Configure Entity Framework:**
   Integrate the database using Entity Framework.

4. **Install DevExpress:**
   Add DevExpress to the project.

5. **SQL Connection Configuration:**
   Modify SQL connection queries with your database credentials.

6. **SMTP Settings:**
   Enter your SMTP configuration details and security token from your email provider.

7. **Run the Application:**
   Start the application after completing the necessary configurations.

## Dependencies

- **DevExpress:** Used for UI development.
- **Entity Framework:** Used for database connection management.
- **MsSQL Server:** Used for database management.
- **SMTP Protocol:** Used for sending email notifications.

## Developer

Sinem Arslan
