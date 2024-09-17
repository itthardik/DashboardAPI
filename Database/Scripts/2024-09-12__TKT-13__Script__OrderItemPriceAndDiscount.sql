-- Script Name: 2024-09-12__TKT-13__Script__OrderItemPriceAndDiscount.sql
-- Author: Hardik Sharma
-- Date: 2024-09-12
-- Description: This script calculates and updates the price column in the `OrderItem` table based on product price and quantity,
--              and updates the discount column with a random value between 10% and 15% of the price.
-- Dependencies: OrderItem table, Product table.
--
-- To apply this migration:
-- Run `2024-09-12__TKT-13__Script__OrderItemPriceAndDiscount.sql` on the target database.

--------------------------------------------------------------------------------

-- Update the discount column
UPDATE OrderItem
SET discount = p.discount *oi.quantity
FROM OrderItem oi
JOIN Product p ON p.id = oi.productId;

-- Update the price in OrderItem based on product price and quantity
UPDATE OrderItem
SET price = p.sellingPrice*oi.quantity
FROM OrderItem oi
JOIN Product p ON p.id = oi.productId;

--------------------------------------------------------------------------------

--- Rollback Instructions
--- To rollback `2024-09-12__TKT-13__Script__OrderItemPriceAndDiscount.sql`, manually revert the price and discount columns to previous values.
