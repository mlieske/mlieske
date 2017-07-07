SET NOCOUNT ON
GO
	
USE master;
GO

if exists (select * from sysdatabases where name='HotelReservation1')
begin
 DECLARE @kill varchar(8000) = ''; 
 SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';' 
 FROM sys.dm_exec_sessions
 WHERE database_id = db_id('HotelReservation1')
 EXEC(@kill)
 
 DROP DATABASE HotelReservation1
end
GO

CREATE DATABASE HotelReservation1
GO

USE HotelReservation1
GO

CREATE TABLE Customers (
	CustomerID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerFirstName nvarchar(30) NOT NULL,
	CustomerLastName nvarchar(30) NOT NULL,
	Email nvarchar(30) NOT NULL
)
GO

CREATE TABLE Phone (
	PhoneNumber varchar(15) PRIMARY KEY,
	PhoneType varchar(10) NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)
GO

CREATE TABLE Reservations (
	ReservationID INT IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL,
)
GO 

CREATE TABLE Guests (
	GuestID INT IDENTITY(1,1) PRIMARY KEY,
	GuestFirstName nvarchar(30) NOT NULL,
	GuestLastName nvarchar(30) NOT NULL,
	Age INT NOT NULL
)
GO 

CREATE TABLE GuestStays (
	ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID),
	GuestID INT FOREIGN KEY REFERENCES	Guests(GuestID)
)
GO

CREATE TABLE Promotions (
	PromotionID INT IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	PromotionName nvarchar(30) NOT NULL,
	PromoFlatAmount DECIMAL(7,2) NULL,
	PromoPercent INT NULL
)
GO 

CREATE TABLE RoomTypes (
	RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
	RoomTypeName varchar(30) NOT NULL
)
GO

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY,
	FloorNumber INT NOT NULL,
	Occupancy INT NOT NULL,
	RoomTypeID INT FOREIGN KEY REFERENCES RoomTypes(RoomTypeID) NOT NULL
)
GO 

CREATE TABLE AddOns(
	AddOnID INT IDENTITY(1,1) PRIMARY KEY,
	AddOnType varchar(20) NOT NULL
)
GO 

CREATE TABLE AddOnRates (
	AddOnRateID INT IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NULL,
	Price DECIMAL(6,2) NOT NULL,
	AddOnID INT FOREIGN KEY REFERENCES AddOns(AddOnID)
)
GO

CREATE TABLE RoomRates (
	RateID INT IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NULL,
	RateAmount DECIMAL(7,2) NOT NULL,
	RateType varchar(20) NOT NULL,
	RoomTypeID INT FOREIGN KEY REFERENCES RoomTypes(RoomTypeID)
)
GO 

CREATE TABLE Amenities (
	AmenityID INT IDENTITY(1,1) PRIMARY KEY,
	AmenityName nvarchar(30) NOT NULL
)
GO

CREATE TABLE RoomAmenities (
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	AmenityID INT FOREIGN KEY REFERENCES Amenities(AmenityID)
)
GO

CREATE TABLE AddOnsUsed (
	AddOns INT FOREIGN KEY REFERENCES AddOns(AddOnID),
	ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID)
)
GO

CREATE TABLE PromoApplied (
	ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID),
	PromotionID INT FOREIGN KEY REFERENCES Promotions(PromotionID)
)
GO

CREATE TABLE RoomsReserved (
	ReservationID INT FOREIGN KEY REFERENCES Reservations(ReservationID),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber)
)
GO

CREATE TABLE Bill (
	BillID INT IDENTITY(1,1) PRIMARY KEY,
	BillTotal DECIMAL(7,2) NOT NULL,
	Taxes DECIMAL(5,2) NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE BillDetail (
	BillDetailID INT IDENTITY(1,1) PRIMARY KEY,
	ChargeType nvarchar(30) NOT NULL,
	ChargeAmount DECIMAL(6,2) NOT NULL,
	BillID INT FOREIGN KEY REFERENCES Bill(BillID) NOT NULL
)
