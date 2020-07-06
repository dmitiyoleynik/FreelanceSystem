USE FreelanceSystem;

CREATE TABLE Projects
(
Id INT PRIMARY KEY IDENTITY,
CustomerCompanyId INT NOT NULL,
FOREIGN KEY (CustomerCompanyId) REFERENCES Companys(Id)
);