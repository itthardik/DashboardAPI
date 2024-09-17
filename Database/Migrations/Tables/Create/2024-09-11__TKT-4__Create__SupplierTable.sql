-- Script Name: 2024-09-11__TKT-4__Create__SupplierTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `Supplier` table with columns for ID, name, contact info, and address.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-11__TKT-4__Create__SupplierTable.sql` on the target database.

CREATE TABLE Supplier (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    contactInfo NVARCHAR(255) NOT NULL,
    address TEXT NOT NULL
);

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-4__Create__SupplierTable.sql`, use the following SQL:
--- DROP TABLE Supplier;
