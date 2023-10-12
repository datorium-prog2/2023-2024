```sql
PRAGMA foreign_keys = 1;

--DROP TABLE Clients;
--DROP TABLE Items;
--DROP TABLE Rents;

CREATE TABLE IF NOT EXISTS Items (
    item_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT,
    description TEXT,
    quantity INTEGER,
    rental_price DECIMAL(10, 2)
);

CREATE TABLE IF NOT EXISTS Clients (
    client_id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT,
    surname TEXT,
    phone TEXT,
    email TEXT
);

CREATE TABLE IF NOT EXISTS Rents (
    rent_id INTEGER PRIMARY KEY AUTOINCREMENT,
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    item_id INTEGER,
    client_id INTEGER,
    duration_in_days INTEGER,
    price_per_day DECIMAL(10, 2),
  	FOREIGN KEY (item_id) REFERENCES Items(item_id),
  	FOREIGN KEY (client_id) REFERENCES Clients(client_id)
);

--INSERT INTO Items (name, description, quantity, rental_price)
--VALUES ("Hammer", "A hand tool used for driving nails", 5, 2.99);

--INSERT INTO Clients (name, surname, phone, email)
--VALUES ("Anna", "Jhonson", "+37123456789", "annaj@someemail.com");

-- INSERT INTO Rents (item_id, client_id, duration_in_days, price_per_day)
-- VALUES (3, 3, 4, 3.99);

SELECT Rents.*, Clients.email
FROM Rents
INNER JOIN Clients ON Rents.client_id = Clients.client_id;
```
