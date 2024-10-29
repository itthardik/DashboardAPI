-- Script Name: 2024-09-23__TKT-20__Create__UpdateAverageDailyUsageAndReorderPoint.sql
-- Author: Hardik Sharma
-- Date: 2024-09-23
-- Description: This script creates the `UpdateAverageDailyUsageAndReorderPoint` stored procedure, which updates the average daily usage and reorder point for all products based on the last 90 days of order data.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-23__TKT-20__Create__UpdateAverageDailyUsageAndReorderPoint.sql` on the target database.

CREATE PROCEDURE UpdateAverageDailyUsageAndReorderPoint
AS
BEGIN
    -- Update the average daily usage based on the last 90 days of order data
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
END;

--------------------------------------------------------------------------------

-- Rollback Instructions:
-- To rollback `2024-09-23__TKT-20__Create__UpdateAverageDailyUsageAndReorderPoint.sql`, use the following SQL:
-- DROP PROCEDURE IF EXISTS UpdateAverageDailyUsageAndReorderPoint;
