-- Script Name: 2024-09-21__TKT-19__Create__AlertTable.sql
-- Author: Hardik Sharma
-- Date: 2024-09-21
-- Description: This script creates the `Alert` table with columns for ID, product ID, alert level, notified at timestamp, and status.
-- Dependencies: ProductInventory table (Foreign Key reference to product_id).
--
-- To apply this migration:
-- Run `2024-09-21__TKT-19__Create__AlertTable.sql` on the target database.

CREATE TABLE Alert (
    id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT NOT NULL,
    alert_level INT NOT NULL,
    notified_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    status NVARCHAR(50) CHECK (status IN ('Pending', 'Resolved')) DEFAULT 'Pending',
    FOREIGN KEY (product_id) REFERENCES Product(id)
);

--- Rollback Instructions
--- To rollback `2024-09-21__TKT-19__Create__AlertTable.sql`, use the following SQL:
--- DROP TABLE Alert;
