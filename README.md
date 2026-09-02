<div align="center">

<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg"
     width="160"
     alt="C#">

<h1>.NET Framework</h1>

<p>
  <img src="https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=csharp&logoColor=white">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=flat-square&logo=.net&logoColor=white">
  <img src="https://img.shields.io/badge/license-MIT-green?style=flat-square">
</p>

</div>

# Hotel Front Desk

## Database (Localhost)

Run these two scripts, in order:

1. `databaseSchema.sql` 
2. `seed_data.sql` — creates a default admin login, one staff login, 4 room types,
   and 8 sample rooms so the app isn't empty on first run.
   
Default logins: (see inside the seed_data.sql)

| Username   | Password  | Role     |
|------------|-----------|----------|
| admin      | ********  | EMPLOYER |
| frontdesk  | ********  | EMPLOYEE |

## Database connection

COnfigure your database connection in `App.config` and `Database/Dbconnection.cs`

Sample:

`connectionString="Data Source=[server_name];Initial Catalog=HotelSystem;Persist Security Info=True;User ID=[usr_id];Password=[usr_pwd];TrustServerCertificate=True" providerName="System.Data.SqlClient" />`

<br>Replace the `[server_name]` with your local DATABASE server.
<br>Replace the `[usr_name]` with your user name.
<br>Replace the `[usr_pwd]` with your password.

<b>⚠ Error note:</b> Having trouble connecting to the database, this is because of the permission error, wrong credentials, or SQL services are not running (Check your SQL services (local) in `services.msc`).

## Open in Visual Studio (2026) and run

Nothing else to configure — `Program.cs` now boots to the Login screen, and after a
successful sign-in it opens `MainForm`.

## What's in each module

- **Dashboard** — live stat cards (total guests, available/occupied rooms, active
  reservations, today's arrivals/departures, today's revenue), with a subtle hover
  tint on each card and a Refresh button.
- **Guest Lookup** — search box, Add/Edit/Delete via popup dialog, double-click a
  row to edit. Guests with existing reservations can't be deleted (referential
  integrity), the DAL just tells the user why.
- **Reservation** — search, Add/Edit/Delete, plus one-click Check-in / Check-out
  from the menu (which also updates the room status, see above).
- **Room Operation** — search, Add/Edit/Delete rooms, plus quick status actions
  (Mark Available/Cleaned, Mark Maintenance, Mark Out of Order) — every status
  change is logged to `RoomOperations`.
- **Payment** — search, Add/Edit/Delete payments tied to a reservation.
- **Report** — pick one of 3 reports + a date range, click Run Report:
  1. Guest Activity Report (reservations + total paid per guest)
  2. Reservation / Occupancy Report (nights + booked value per reservation)
  3. Revenue by Payment Method (grouped totals)
- **User** (EMPLOYER/Admin only) — search, Add/Edit/Delete staff accounts, role
  assignment, optional password reset on edit. The button is hidden entirely for
  non-admins, and the handler double-checks the role even if someone tries to
  trigger it another way.
- **Logout** — confirms, clears the session, and returns to the Sign In screen.
