-- Script Name: 2024-09-11__TKT-2__Create__OrdersTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `Orders` table with columns for order ID, user ID, total price, status, created at, and updated at.
-- Dependencies: Users table (Foreign Key reference to user_id).
--
-- To apply this migration:
-- Run `2024-09-11__TKT-2__Create__OrdersTable.sql` on the target database.

CREATE TABLE Orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    userId INT NOT NULL,
    totalPrice DECIMAL(10, 2) NOT NULL,
    status NVARCHAR(50) NOT NULL CHECK (status IN ('Pending', 'Completed', 'Cancelled')),
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME NULL,
    FOREIGN KEY (userId) REFERENCES Users(id)
);

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-2__Create__OrdersTable.sql`, use the following SQL:
--- DROP TABLE Orders;
