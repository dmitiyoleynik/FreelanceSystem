USE FreelanceSystem;

CREATE TABLE RolesPermissions
(
RoleId INT NOT NULL,
PermissionId INT NOT NULL
FOREIGN KEY (PermissionId) REFERENCES UsersPermissions(Id),
FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);