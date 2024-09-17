-- Script Name: 2024-09-11__TKT-6__Create__OrderItemTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script creates the `OrderItem` table with columns for ID, product ID, order ID, quantity, price, status, discount, and created at.
-- Dependencies: Product table (Foreign Key reference to productId), Order table (Foreign Key reference to orderId).
--
-- To apply this migration:
-- Run `2024-09-11__TKT-6__Create__OrderItemTable.sql` on the target database.

CREATE TABLE OrderItem (
    id INT IDENTITY(1,1) PRIMARY KEY,
    productId INT NOT NULL,
    orderId INT NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    status NVARCHAR(50) CHECK (status IN ('Pending', 'Shipped', 'Delivered', 'Returned')),
    discount DECIMAL(10, 2) DEFAULT 0.00,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (productId) REFERENCES Product(id),
    FOREIGN KEY (orderId) REFERENCES Orders(id)
);

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-6__Create__OrderItemTable.sql`, use the following SQL:
--- DROP TABLE OrderItem;
