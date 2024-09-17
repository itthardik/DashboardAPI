-- Script Name: 2024-09-11__TKT-1__Create__UsersTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `Users` table with columns for ID, username, password, role, email, last login, session token, token expiration time, and other related fields.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-11__TKT-1__Create__UsersTable.sql` on the target database.


CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(50) NOT NULL CHECK (role IN ('admin', 'sales', 'inventory', 'revenue', 'support')),
    email VARCHAR(100) NOT NULL,
    last_login DATETIME NULL,
    session_token NVARCHAR(255) NULL,
    token_expiration_time DATETIME NULL,
    is_token_active BIT DEFAULT 0,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);



--- Rollback Instructions
--- To rollback `2024-09-11__TKT-1__Create__UsersTable.sql`, use the following SQL:
--- DROP TABLE Users;
