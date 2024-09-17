-- Script Name: 2024-09-11__TKT-7__Create__CustomerSearchTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `CustomerSearch` table with columns for ID, search term, count, user ID, and searched at.
-- Dependencies: User table (Foreign Key reference to userId).
--
-- To apply this migration:
-- Run `2024-09-11__TKT-7__Create__CustomerSearchTable.sql` on the target database.

CREATE TABLE CustomerSearch (
    id INT IDENTITY(1,1) PRIMARY KEY,
    searchTerm NVARCHAR(255) NOT NULL,
    count INT DEFAULT 1,
    userId INT NOT NULL,
    searchedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (userId) REFERENCES Users(id)
);

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-7__Create__CustomerSearchTable.sql`, use the following SQL:
--- DROP TABLE CustomerSearch;
