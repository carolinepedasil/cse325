# WellnessTracker  
A personal wellness tracking application. Users can log daily wellness habits, set personal health goals, and visualize their weekly progress through a clean dashboard.

---

## 🚀 Features

### ✔ Create Account
Users can register securely using ASP.NET Identity with hashed passwords.

### ✔ Log In & Log Out
Authenticated sessions allow access to protected pages such as Dashboard, Habits, and Goals.

### ✔ Daily Wellness Tracking (CRUD)
Users can:
- Add daily entries (exercise, sleep, water intake, mood, notes)
- Edit existing entries
- Delete entries
- Filter entries by date range

### ✔ Weekly Dashboard
Displays:
- Exercise minutes per day (visual progress bars)
- Average sleep hours (last 7 days)
- Average water intake (last 7 days)

All dashboard data reflects the user’s saved daily entries.

### ✔ Goal Management
Users can:
- Create goals (category, target value, period)
- Edit existing goals
- Delete goals
- View active goals
- Automatically calculate progress based on daily entries

### ✔ Responsive Layout
Optimized for desktop and mobile using Bootstrap and Blazor’s layout system.

### ✔ Secure & Protected Pages
- Dashboard, Habits, and Goals require authentication.
- Unauthorized users see friendly messages guiding them to log in.

---

## 🛠 Technologies Used

- **ASP.NET Core 8 / Blazor Server**
- **C#**
- **Entity Framework Core + SQLite**
- **ASP.NET Identity**
- **Bootstrap 5**
- **LINQ for data aggregation**
- **Dependency Injection**

---

## 👤 How to Use the Application

### **Step 1 — Register an Account**
- Go to **Register**
- Create your user account
- You will be automatically logged in

---

### **Step 2 — Add Daily Wellness Entries**
- Go to **Habits**
- Add exercise minutes, sleep hours, water liters, mood, and notes
- Entries appear in a searchable/filterable table
- You can edit or delete entries at any time

---

### **Step 3 — View Weekly Dashboard**
- Go to **Dashboard**
- See exercise progress per day using visual progress bars
- View average sleep and water intake for the last 7 days
- Dashboard updates automatically as entries are added or modified

---

### **Step 4 — Set Personal Goals**
- Go to **Goals**
- Create new goals (e.g., *Exercise 30 minutes daily*)
- Edit or delete existing goals
- Track progress toward your health goals

---

## 📊 How the Dashboard Works

The dashboard retrieves the user’s last 7 days of `HabitEntry` data and calculates:

- **Daily exercise totals**
- **Average sleep hours**
- **Average water intake**

It then renders visual progress bars and summary text to help users quickly understand their habits.

---

## 🧪 Error Handling & Validation
- All forms use `<EditForm>` with built-in validation
- Data annotations ensure correct input ranges
- Login and Register pages display friendly error messages
- Protected pages use `<AuthorizeView>` to show “You need to log in…” for unauthorized users

---

## 🛡 Security
- Uses **ASP.NET Identity** for secure user authentication
- Passwords are hashed and never stored in plain text
- Dashboard, Habits, and Goals require authentication
- Custom `AuthenticationStateProvider` manages login/logout state

---

## 📌 Status

- ✔ All required project features completed  
- ✔ Authentication working  
- ✔ Full CRUD implemented  
- ✔ Dashboard fully functional  
- ✔ Responsive and accessible UI  

---

## 📝 How to Run the Project Locally

### 1. Clone the repository
```bash
git clone https://github.com/your-username/WellnessTracker.git
cd WellnessTracker

2. Restore dependencies
dotnet restore

3. Apply migrations
dotnet ef database update

4. Run the app
dotnet run

App will run at:
http://localhost:5270
```
