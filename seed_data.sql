-- Default administrator account.
-- Username: admin   Password: admin123
-- (Role EMPLOYER = this application's "Admin" — see README_CHANGES.md)
INSERT INTO Users (Username, PasswordHash, FullName, Role, Phone, Email, Status)
VALUES ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
        'System Administrator', 'EMPLOYER', '000-000-0000', 'admin@hotel.local', 'ACTIVE');

-- A front-desk staff account for everyday testing.
-- Username: frontdesk   Password: admin123
INSERT INTO Users (Username, PasswordHash, FullName, Role, Phone, Email, Status)
VALUES ('frontdesk', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
        'Front Desk Staff', 'EMPLOYEE', '000-000-0001', 'frontdesk@hotel.local', 'ACTIVE');

-- Room types.
INSERT INTO RoomTypes (TypeName, Description, Capacity, BasePrice, Status) VALUES
('Standard', 'Standard room with one queen bed', 2, 49.00, 'ACTIVE'),
('Deluxe', 'Deluxe room with king bed and city view', 2, 79.00, 'ACTIVE'),
('Suite', 'Suite with separate living area', 4, 129.00, 'ACTIVE'),
('Family', 'Family room with two queen beds', 4, 99.00, 'ACTIVE');

-- Sample rooms.
INSERT INTO Rooms (RoomNumber, RoomTypeID, FloorNumber, Status) VALUES
('101', 1, 1, 'AVAILABLE'),
('102', 1, 1, 'AVAILABLE'),
('103', 2, 1, 'AVAILABLE'),
('201', 2, 2, 'AVAILABLE'),
('202', 3, 2, 'AVAILABLE'),
('203', 4, 2, 'AVAILABLE'),
('301', 1, 3, 'MAINTENANCE'),
('302', 3, 3, 'AVAILABLE');
