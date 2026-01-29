# Mini-DARMAS: Digital Meeting Recording & Transcript Management System

Mini-DARMAS is a comprehensive **WinForms-based desktop application** designed to digitize the end-to-end workflow of institutional meetings. The system supports everything from **initial meeting creation and audio recording management** to **professional transcription, editorial review**, and **final digital archiving with mouse-driven signatures**.

---

## 🚀 Project Overview

This system is built using **C# and .NET 9.0** following a **Three-Tier Architecture** (Presentation, Logic, and Data Access Layers). It ensures institutional data integrity through **centralized SQL storage** and **role-based access control**.

---

## 👥 User Roles & Workflow

- **Admin:** Manages user accounts and system security.  
- **Operator:** Creates meetings, attaches audio files, and assigns tasks.  
- **Transcriber:** Listens to audio and produces the initial text transcript.  
- **Editor:** Performs quality control, corrects text, and provides feedback.  
- **Approver:** Generates the final document, applies a digital signature, and exports to PDF/RTF.  

---

## 🛠 Technology Stack

- **Language:** C# (WinForms)  
- **Framework:** .NET 9.0  
- **Database:** Microsoft SQL Server (LocalDB / Express)  
- **Data Access:** ADO.NET with Parameterized Queries (SQL Injection protection)  
- **Audio Engine:** NAudio (for precision scrubbing and playback)  
- **Document Engine:** iText7 (for programmatic PDF generation)  

---

## 📁 Project Structure

Mini-DARMAS/
-**├── Forms/ # UI Layer (Windows Forms)
-**├── Models/ # Logic Layer (POCO Data Classes)
-**├── DAL/ # Data Access Layer (SQL logic)
*--├── Resources/ # UI Assets (Logos, Icons, Images)
*--├── App.config # Database Connection String
**-└── Program.cs # Role-based Routing Logic
---

## ⚙️ Setup & Installation

### Database Setup
1. Open **SQL Server Management Studio (SSMS)**.  
2. Execute the provided `MiniDarmasDB.sql` script to **create tables and seed initial data**.

### Configuration
1. Open the solution in **Visual Studio 2022**.  
2. Update the `connectionString` in `App.config` to match your **local SQL Server instance name**.

### Dependencies
Restore the following NuGet packages:
- `NAudio`
- `itext7`
- `itext7.bouncy-castle-adapter`

### Run
1. Build the solution (`Ctrl+Shift+B`).  
2. Press `F5` to launch the application.

---

## ✨ Key Features

- **Event-Driven Search:** Live user filtering in the Admin module.  
- **Advanced Audio Player:** Incremental seeking (+5s/-5s), progress slider, and time-stamping.  
- **Editorial Loop:** Bidirectional workflow allowing Editors to return work to Transcribers with red-highlighted feedback.  
- **Digital Signature:** Interactive panel capturing mouse-drawn signatures for legal archiving.  
- **Multi-Format Export:** Finalized minutes can be exported to PDF, RTF, or Plain Text.  

---

## ⚖️ Academic Integrity

This project was developed as a **Capstone** for the **Event-Driven Programming** course.  
