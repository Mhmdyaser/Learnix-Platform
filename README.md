# 🎓 Learnix -- E-Learning Platform

Learnix is a **web-based e-learning platform** built using **ASP.NET
MVC**, designed to connect instructors and students through structured
online courses.\
It supports role-based access, course management, enrollment logic, and
progress tracking, following real-world software engineering practices.

## 📌 Project Overview

Learnix allows: - **Instructors** to create and manage courses,
sections, and lessons - **Students** to enroll in courses, access
content, and track their learning progress - **Admins** to oversee the
platform and manage system-level rules

The project was developed as part of a **Graduation / DEPI Project**,
focusing on clean architecture, business logic, and scalability.

## ✨ Key Features

### 🔐 Authentication & Authorization

-   Secure login and registration using **ASP.NET Core Identity**
-   Role-based access control (Student, Instructor, Admin)
-   Protected routes and actions per role

### 📚 Course Management

-   Courses contain multiple **Sections**
-   Each section contains multiple **Lessons**
-   Lessons support:
    -   Video content
    -   Downloadable materials

### 👨‍🏫 Instructor Dashboard

-   Create and manage courses
-   Add sections and lessons
-   View enrolled students
-   Monitor course activity

### 👨‍🎓 Student Experience

-   Browse available courses
-   Enroll in courses
-   Access lessons and materials
-   Track learning progress

### 💰 Enrollment & Payment Logic

-   Course enrollment logic with balance handling
-   Instructor and admin revenue distribution
-   Business rules enforced at service layer

### 📊 Progress Tracking

-   Track student progress per lesson/course
-   Completion status management

## 🛠 Technologies Used

-   ASP.NET MVC
-   C#
-   Entity Framework Core
-   LINQ
-   SQL Server
-   ASP.NET Core Identity
-   HTML, CSS, Bootstrap
-   Repository & Service Design Patterns

## 🧱 Architecture

Learnix follows a **layered architecture**: - Presentation Layer (MVC) -
Service Layer (Business Logic) - Repository Layer (Data Access) - Data
Layer (EF Core & SQL Server)

## 🗂 Main Entities

-   ApplicationUser
-   Student
-   Instructor
-   Admin
-   Course
-   Section
-   Lesson
-   Enrollment
-   StudentProgress
-   Payment

## 👥 Project Team

-   Abdelrahman Amr Abdelnaby Melhy 
-   Mohamed Yaser Salah Elnagar 
-   Ahmed Moustafa Gaber Elbhery 
-   Mohamed Atef Mohamed Abu-Yousef 
-   Abdelaziz Ahmed Saad Aresha 

## 🚀 Getting Started

1.  Clone the repository
2.  Update connection string
3.  Apply migrations
4.  Run the project

## 🌐 Live Demo

https://e-learnix.runasp.net

## 📈 Learning Outcomes

Hands-on experience with ASP.NET MVC, authentication, architecture, and
teamwork.

## 📄 License

Educational use only.
