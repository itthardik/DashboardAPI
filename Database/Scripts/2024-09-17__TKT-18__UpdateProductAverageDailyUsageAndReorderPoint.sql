-- Script Name: 2024-09-17__TKT-18__UpdateProductAverageDailyUsageAndReorderPoint.sql
-- Author: Hardik Sharma
-- Date: 2024-09-17
-- Description: This script updates the `averageDailyUsage` column in the `Product` table based on the count of `OrderItem` entries from the past 90 days.
--              It also updates the `reorderPoint` based on the `averageDailyUsage` with an added safety stock of 10.
-- Dependencies: Product table, OrderItem table.
--
-- To apply this migration:
-- Run `2024-09-17__TKT-18__UpdateProductAverageDailyUsageAndReorderPoint.sql` on the target database.

--------------------------------------------------------------------------------

-- Update the averageDailyUsage in Product based on recent OrderItem entries
UPDATE Product
SET averageDailyUsage = ISNULL(subquery.orderCount / 90.0, 0)
FROM Product p
LEFT JOIN (
    SELECT oi.productId AS productId, COUNT(oi.id) AS orderCount
    FROM OrderItem oi
    WHERE oi.createdAt >= DATEADD(DAY, -90, GETDATE()) OR oi.createdAt IS NULL
    GROUP BY oi.productId
) AS subquery ON p.id = subquery.productId;

--------------------------------------------------------------------------------

-- Update the reorderPoint based on averageDailyUsage
UPDATE Product
SET reorderPoint = averageDailyUsage * 30 + 10  -- safety stock
FROM Product p;

--------------------------------------------------------------------------------

--- Rollback Instructions
--- To rollback `2024-09-17__TKT-18__UpdateProductAverageDailyUsageAndReorderPoint.sql`, manually revert the `averageDailyUsage` and `reorderPoint` columns to previous values.
