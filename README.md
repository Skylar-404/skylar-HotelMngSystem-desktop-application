# Hotel Front Desk — What Was Built

This picks up your existing WinForms + .NET Framework 4.7.2 + SQL Server project and
finishes it into a working CRUD app for all 7 modules: Dashboard, Reservation, Guest
Lookup, Room Operation, Payment, Report, User, plus Logout.

## 1. Set up the database first

Run these two scripts, in order, against your SQL Server instance:

1. `databaseSchema.sql` — same as before, **plus a `Guests` table that was missing**
   (it was referenced by a foreign key in `Reservations` but never created).
2. `seed_data.sql` — creates a default admin login, one staff login, 4 room types,
   and 8 sample rooms so the app isn't empty on first run.

Default logins (password is the same for both, change it after first login):

| Username   | Password  | Role     |
|------------|-----------|----------|
| admin      | admin123  | EMPLOYER |
| frontdesk  | admin123  | EMPLOYEE |

The connection string is hard-coded in `Database/Dbconnection.cs` (this was already
the case in your original project) — update the server name / credentials there if
they differ from `.\SQLEXPRESS`, database `HotelSystem`, user `sa`.

## 2. Open in Visual Studio and run

Nothing else to configure — `Program.cs` now boots to the Login screen, and after a
successful sign-in it opens `MainForm`.

## Key assumptions I made (please double-check these)

- **No screenshot was actually attached** to the request — only the project zip came
  through. I kept the visual language your project already had (white background,
  `RoundedButton`/`RoundedTextBox`, AliceBlue grid headers) rather than inventing a
  new look.
- **"Admin" role mapping.** Your `Users.Role` check constraint only allows
  `EMPLOYER`, `MANAGER`, `EMPLOYEE` — there's no literal "Admin". I treated
  **EMPLOYER as the Admin-equivalent**: only EMPLOYER accounts can see the "User"
  button and manage other users. If you intended a different role to be the admin
  tier, it's a one-line change in `Helpers/SessionHelper.cs` (`IsAdmin`) and
  `Models/User.cs` (`IsAdmin`).
- **Guests table was added** (see above) with fields matching what `hotelDS.xsd`
  already expected (FirstName, LastName, Gender, Phone) plus Email, Address,
  IDNumber, Nationality, Status — reasonable fields for a real front desk guest
  record.
- **Data access approach.** Your original `hotelDS.xsd` typed DataSet only had a
  partial `Guests` table wired up. Hand-editing generated XSD/Designer XML for
  6 more entities without Visual Studio's designer tool is extremely fragile, so
  the rest of the DAL (`RoomDAL`, `ReservationDAL`, `PaymentDAL`, `UserDAL`,
  `RoomTypeDAL`, `RoomOperationDAL`, `DashboardDAL`, `ReportDAL`) uses plain
  ADO.NET (`SqlCommand` / `SqlDataAdapter`) through your existing `Dbconnection`
  helper — same pattern, no generated XML to fight with. `GuestsDAL.cs` was
  rewritten the same way for consistency (kept the original filename since the
  project already referenced it).
- **Password hashing** is a basic SHA-256 (`Helpers/PasswordHelper.cs`) — enough for
  a local demo/training app, not something I'd ship to production without adding a
  per-user salt and a slower algorithm (PBKDF2/BCrypt).
- **Login form** previously had no authentication logic at all (the Sign In button
  had no click handler, and `Program.cs` booted straight to `MainForm`, skipping
  login entirely). That's now fixed: `Program.cs` starts at `loginForm`, which
  authenticates against the `Users` table and only opens `MainForm` on success.
- **Room ↔ Reservation status sync.** When a reservation is marked `CHECKED_IN` the
  room automatically flips to `OCCUPIED`; `CHECKED_OUT` flips the room to `DIRTY`
  (needs cleaning) and logs an entry in `RoomOperations`. This isn't something you
  asked for explicitly, but it's the kind of behavior a real front desk needs and
  it reuses tables you already had (`RoomOperations`).

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

## Things intentionally left simple (per "avoid over-engineering")

- Room Types are seeded reference data, editable in the database directly rather
  than through a dedicated screen — Room Operation lets you assign an existing type
  to a room, which covers the day-to-day need.
- Reports are grid + summary line, not a formatted printable report — your project
  already has `Report1.rdlc` and the ReportViewer packages installed if you want to
  upgrade to a printable layout later.
- `AuditLogs` table exists in your schema but isn't wired up yet — it's there if you
  want to add change history later.

## Icons

All icon slots (dashboard cards, sidebar) use the `PictureBox` placeholders already
in your project — no new image assets were added, as requested.
