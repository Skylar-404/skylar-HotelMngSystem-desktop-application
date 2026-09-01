<div align="center">

  <table>
    <tr>
      <td>
        <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg"
             width="130"
             alt="C#">
      </td>
      <td>
        <h1>.NET Framework</h1>
      </td>
    </tr>
  </table>

  <br>

  <img src="https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=csharp&logoColor=white">
  <img src="https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=flat-square&logo=.net&logoColor=white">
  <img src="https://img.shields.io/badge/license-MIT-82B541?style=flat-square">

</div>



# Hotel Front Desk

## 1. Set up the database

Run these two scripts, in order, against your SQL Server instance:

1. `databaseSchema.sql` — same as before, **plus a `Guests` table that was missing**
   (it was referenced by a foreign key in `Reservations` but never created).
2. `seed_data.sql` — creates a default admin login, one staff login, 4 room types,
   and 8 sample rooms so the app isn't empty on first run.

Default logins (password is the same for both, change it after first login):

| Username   | Password  | Role     |
|------------|-----------|----------|
| admin      | ********  | EMPLOYER |
| frontdesk  | ********  | EMPLOYEE |

The connection string is hard-coded in `Database/Dbconnection.cs` (this was already
the case in your original project) — update the server name / credentials there if
they differ from `.\SQLEXPRESS`, database `HotelSystem`, user `sa`.

## 2. Open in Visual Studio and run

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
- **Logout** — confirms, clears the session, and returns to the Sign In screen
  (this flow already existed in your code — I left it as-is, just added the
  session clear).
