-- Script Name: 2024-09-11__TKT-5__Create__ProductTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `Product` table with columns for ID, name, cost price, selling price, shipping cost, discount, net profit, threshold value, category ID, current stock, supplier ID, created at, and updated at.
-- Dependencies: Category table (Foreign Key reference to categoryId), Supplier table (Foreign Key reference to supplierId).
--
-- To apply this migration:
-- Run `2024-09-11__TKT-5__Create__ProductTable.sql` on the target database.

CREATE TABLE Product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    costPrice DECIMAL(10, 2) NOT NULL,
    sellingPrice DECIMAL(10, 2) NOT NULL,
    shippingCost DECIMAL(10, 2) DEFAULT 0.00,
    discount DECIMAL(10, 2) DEFAULT 0.00,
    netProfit AS (sellingPrice - costPrice - shippingCost - discount) PERSISTED,
    thresholdValue INT DEFAULT 0,
    categoryId INT NOT NULL,
    currentStock INT NOT NULL,
    supplierId INT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME NULL,
    FOREIGN KEY (categoryId) REFERENCES Category(id),
    FOREIGN KEY (supplierId) REFERENCES Supplier(id)
);

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-5__Create__ProductTable.sql`, use the following SQL:
--- DROP TABLE Product;
