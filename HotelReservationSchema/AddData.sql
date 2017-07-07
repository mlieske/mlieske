USE HotelReservation1
GO

INSERT INTO RoomTypes
	VALUES('Double'),('Single'),('Queen'),('King'),('Suite');

INSERT INTO Amenities
	VALUES('Refrigerator'),('HotTub'),('Coffee Maker'),('Microwave');

INSERT INTO AddOns
	VALUES ('Room Service'),('Wireless'),('Movie');

INSERT INTO Customers
	VALUES('Bob','Jones','bj@mail.com'),('Mary','Smith','ms@mail.com'),('Beth','Jones','bej@mail.com')

INSERT INTO Phone
	VALUES ('612-555-4444','Mobile',1),('763-444-3333','Home', 1),('952-555-5555','Mobile',2);

INSERT INTO Rooms
	VALUES (100,1,4,1),(200,2,6,3),(300,3,2,2),(400,4,4,2);

INSERT INTO Reservations
	VALUES ('3/12/2017','3/17/2017',1),('6/22/2017','6/30/2017',2),('8/1/2017','8/15/2017',1),
	('7/13/2017','7/16/2017',3),('2/5/2017','2/8/2017',2)

INSERT INTO RoomsReserved
	VALUES(1,200),(1,300),(2,100),(3,400),(2,300)

INSERT INTO Guests
	VALUES('Sam','Jones',5),('Abby','Jones', 7),('Don','Johnson',35),('Michael','Smith',15),('Jerry','Thompson',42),
	('Tom','Simpson',52),('Jim','Smith',47),('James','Wilson',28),('Jimmy','Butler',29)

INSERT INTO GuestStays
	VALUES(1,1),(1,2),(1,3),(2,9),(3,6),(3,7),(4,4),(4,5),(5,8),(5,5)

INSERT INTO RoomRates
	VALUES('1/1/2017','5/31/2017',145,'Spring',1),
	('5/31/2017',NULL,180,'Summer',1),
	('1/1/2017','3/31/2017',125,'Spring',2),
	('4/1/2017',NULL,130,'Summer',2),
	('1/1/2017','3/31/2017',125,'Spring',3),
	('4/1/2017',NULL,130,'Summer',3),	
	('1/1/2017','3/31/2017',125,'Spring',3),
	('4/1/2017',NULL,130,'Summer',3),
	('1/1/2017','3/31/2017',125,'Spring',4),
	('4/1/2017',NULL,130,'Summer',4),
	('1/1/2017','3/31/2017',125,'Spring',5),
	('4/1/2017',NULL,130,'Summer',5)

INSERT INTO AddOnRates
	VALUES ('2017-6-1',NULL,25.00,1),
	('2017-1-1','2017-5-31',20.00,1),
	('2017-1-1','2017-5-31',5.00,2),
	('2016-6-1','2016-12-31',8.00,2),
	('2017-1-1',NULL,15.00,3);

INSERT INTO AddOnsUsed
	VALUES (1,1),(1,4),(2,1),(2,3),(3,5)
	
 INSERT INTO Promotions
	VALUES('1/1/2017','3/31/2017','Rotary Club',100,NULL),
	('5/1/2017','6/30/2017','Software  Guild',NULL,25),
	('1/1/2017','5/31/2017','Summer Special',NULL,15);

INSERT INTO PromoApplied
	VALUES(2,1),(3,2)

INSERT INTO Bill
	VALUES(0,1,11.5),(0,2,11.5),(0,3,15)
