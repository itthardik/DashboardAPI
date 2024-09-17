-- Script Name: 2024-09-11__TKT-3__Create__CategoryTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `Category` table with columns for ID and category name.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-11__TKT-3__Create__CategoryTable.sql` on the target database.

CREATE TABLE Category (
    id INT IDENTITY(1,1) PRIMARY KEY,
    categoryName NVARCHAR(100) NOT NULL
);

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-3__Create__CategoryTable.sql`, use the following SQL:
--- DROP TABLE Category;
