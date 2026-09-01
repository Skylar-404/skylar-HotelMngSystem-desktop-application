-- user
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Phone VARCHAR(30),
    Email VARCHAR(100),
    Status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT CK_Users_Role
        CHECK (Role IN ('EMPLOYER', 'MANAGER', 'EMPLOYEE')),

    CONSTRAINT CK_Users_Status
        CHECK (Status IN ('ACTIVE', 'INACTIVE'))
);
-- room types
CREATE TABLE RoomTypes (
    RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName VARCHAR(50) NOT NULL,
    Description VARCHAR(255),
    Capacity INT NOT NULL,
    BasePrice DECIMAL(10,2) NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE',

    CONSTRAINT CK_RoomTypes_Capacity
        CHECK (Capacity > 0),

    CONSTRAINT CK_RoomTypes_BasePrice
        CHECK (BasePrice >= 0),

    CONSTRAINT CK_RoomTypes_Status
        CHECK (Status IN ('ACTIVE', 'INACTIVE'))
);
-- rooms
CREATE TABLE Rooms (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber VARCHAR(10) NOT NULL UNIQUE,
    RoomTypeID INT NOT NULL,
    FloorNumber INT,
    Status VARCHAR(20) NOT NULL DEFAULT 'AVAILABLE',

    CONSTRAINT FK_Rooms_RoomTypes
        FOREIGN KEY (RoomTypeID)
        REFERENCES RoomTypes(RoomTypeID),

    CONSTRAINT CK_Rooms_Status
        CHECK (
            Status IN (
                'AVAILABLE',
                'RESERVED',
                'OCCUPIED',
                'DIRTY',
                'MAINTENANCE',
                'OUT_OF_ORDER'
            )
        )
);
-- guests
CREATE TABLE Guests (
    GuestID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Gender VARCHAR(10),
    Phone VARCHAR(30),
    Email VARCHAR(100),
    Address VARCHAR(255),
    IDNumber VARCHAR(50),
    Nationality VARCHAR(50),
    Status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT CK_Guests_Status
        CHECK (Status IN ('ACTIVE', 'INACTIVE'))
);
-- reservation
CREATE TABLE Reservations (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationCode VARCHAR(30) NOT NULL UNIQUE,

    GuestID INT NOT NULL,
    RoomID INT NOT NULL,

    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,

    Adults INT NOT NULL DEFAULT 1,
    Children INT NOT NULL DEFAULT 0,

    RoomRate DECIMAL(10,2) NOT NULL,

    Status VARCHAR(20) NOT NULL DEFAULT 'PENDING',

    SpecialRequest VARCHAR(500),

    CreatedBy INT,

    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Reservations_Guests
        FOREIGN KEY (GuestID)
        REFERENCES Guests(GuestID),

    CONSTRAINT FK_Reservations_Rooms
        FOREIGN KEY (RoomID)
        REFERENCES Rooms(RoomID),

    CONSTRAINT FK_Reservations_Users
        FOREIGN KEY (CreatedBy)
        REFERENCES Users(UserID),

    CONSTRAINT CK_Reservations_Dates
        CHECK (CheckOutDate > CheckInDate),

    CONSTRAINT CK_Reservations_Adults
        CHECK (Adults > 0),

    CONSTRAINT CK_Reservations_Children
        CHECK (Children >= 0),

    CONSTRAINT CK_Reservations_RoomRate
        CHECK (RoomRate >= 0),

    CONSTRAINT CK_Reservations_Status
        CHECK (
            Status IN (
                'PENDING',
                'CONFIRMED',
                'CHECKED_IN',
                'CHECKED_OUT',
                'CANCELLED',
                'NO_SHOW'
            )
        )
);
-- payment
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,

    ReservationID INT NOT NULL,

    Amount DECIMAL(10,2) NOT NULL,

    PaymentMethod VARCHAR(20) NOT NULL,

    PaymentType VARCHAR(20) NOT NULL,

    TransactionReference VARCHAR(100),

    PaymentStatus VARCHAR(20) NOT NULL DEFAULT 'COMPLETED',

    ReceivedBy INT,

    PaymentDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Payments_Reservations
        FOREIGN KEY (ReservationID)
        REFERENCES Reservations(ReservationID),

    CONSTRAINT FK_Payments_Users
        FOREIGN KEY (ReceivedBy)
        REFERENCES Users(UserID),

    CONSTRAINT CK_Payments_Amount
        CHECK (Amount > 0),

    CONSTRAINT CK_Payments_Method
        CHECK (
            PaymentMethod IN (
                'CASH',
                'CARD',
                'BANK_TRANSFER',
                'ONLINE',
                'OTHER'
            )
        ),

    CONSTRAINT CK_Payments_Type
        CHECK (
            PaymentType IN (
                'DEPOSIT',
                'ROOM_PAYMENT',
                'EXTRA_CHARGE',
                'REFUND'
            )
        ),

    CONSTRAINT CK_Payments_Status
        CHECK (
            PaymentStatus IN (
                'PENDING',
                'COMPLETED',
                'REFUNDED',
                'VOID'
            )
        )
);
-- room operations
CREATE TABLE RoomOperations (
    OperationID INT IDENTITY(1,1) PRIMARY KEY,

    RoomID INT NOT NULL,

    ReservationID INT NULL,

    OperationType VARCHAR(20) NOT NULL,

    OldStatus VARCHAR(20),
    NewStatus VARCHAR(20),

    Description VARCHAR(500),

    PerformedBy INT NOT NULL,

    OperationDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_RoomOperations_Rooms
        FOREIGN KEY (RoomID)
        REFERENCES Rooms(RoomID),

    CONSTRAINT FK_RoomOperations_Reservations
        FOREIGN KEY (ReservationID)
        REFERENCES Reservations(ReservationID),

    CONSTRAINT FK_RoomOperations_Users
        FOREIGN KEY (PerformedBy)
        REFERENCES Users(UserID),

    CONSTRAINT CK_RoomOperations_Type
        CHECK (
            OperationType IN (
                'CHECK_IN',
                'CHECK_OUT',
                'ROOM_CHANGE',
                'CLEANING',
                'MAINTENANCE',
                'STATUS_CHANGE'
            )
        )
);
-- audit log
CREATE TABLE AuditLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,

    UserID INT NOT NULL,

    Action VARCHAR(100) NOT NULL,

    TableName VARCHAR(50),

    RecordID INT,

    Description VARCHAR(500),

    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_AuditLogs_Users
        FOREIGN KEY (UserID)
        REFERENCES Users(UserID)
);
-- indexes
CREATE INDEX IX_Guests_Phone
ON Guests(Phone);

CREATE INDEX IX_Guests_IDNumber
ON Guests(IDNumber);

CREATE INDEX IX_Reservations_CheckInDate
ON Reservations(CheckInDate);

CREATE INDEX IX_Reservations_CheckOutDate
ON Reservations(CheckOutDate);

CREATE INDEX IX_Reservations_Status
ON Reservations(Status);

CREATE INDEX IX_Payments_PaymentDate
ON Payments(PaymentDate);

CREATE INDEX IX_Rooms_Status
ON Rooms(Status);