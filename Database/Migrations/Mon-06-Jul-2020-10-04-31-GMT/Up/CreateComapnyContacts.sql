USE FreelanceSystem;

CREATE TABLE CompanyContacts
(
UserId INT PRIMARY KEY,
FOREIGN KEY (UserId) REFERENCES Users(Id)
);