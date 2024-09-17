-- Script Name: 2024-09-12__TKT-15__Seed__OrderTotalPrice.sql
-- Author: Hardik Sharma
-- Date: 2024-09-12
-- Description: This script seeds the `OrderItem` table with data and calculates the `totalPrice` for each order in the `Orders` table.
-- Dependencies: Orders table, OrderItem table.
--
-- To apply this migration:
-- Run `2024-09-12__TKT-15__Seed__OrderTotalPrice.sql` on the target database.

-- Note: This script should be applied after seeding the OrderItem table.

UPDATE o
SET o.totalPrice = subquery.total
FROM Orders o
JOIN (
    SELECT oi.orderId, SUM(oi.price - oi.discount) AS total
    FROM OrderItem oi
    GROUP BY oi.orderId
) AS subquery ON o.id = subquery.orderId;

--- Rollback Instructions
--- To rollback `2024-09-12__TKT-15__Seed__OrderTotalPrice.sql`, use the following SQL:
--- -- Unfortunately, rolling back this update requires restoring the `totalPrice` values from a backup or previous state.
