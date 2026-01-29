
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
