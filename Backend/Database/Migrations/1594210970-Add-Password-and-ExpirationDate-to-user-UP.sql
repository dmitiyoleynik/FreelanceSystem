Use FreelanceSystem;

ALTER TABLE Users
ADD ExpirationDate DATETIME NULL;
ALTER TABLE Users
ADD "Password" NVARCHAR(256);
