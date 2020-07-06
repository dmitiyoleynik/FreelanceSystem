USE FreelanceSystem;

CREATE TABLE TeamManagers
(
ManagerId INT,
Price INT
PRIMARY KEY(ManagerId),
FOREIGN KEY (ManagerId) REFERENCES Users (Id) 
	ON DELETE CASCADE 
	ON UPDATE CASCADE
);