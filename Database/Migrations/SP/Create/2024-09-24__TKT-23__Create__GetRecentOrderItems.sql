-- Script Name: 2024-09-24__TKT-23__Create__GetRecentOrderItems.sql
-- Author: Hardik Sharma
-- Date: 2024-09-24
-- Description: This script creates the `GetRecentOrderItems` stored procedure that retrieves the total quantity of order items created in the last 60 seconds.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-24__TKT-23__Create__GetRecentOrderItems.sql` on the target database.

CREATE PROCEDURE GetRecentOrderItems
AS
BEGIN

    -- Select total quantity of order items created in the last 60 seconds.
    SELECT ISNULL(SUM(quantity),0) AS TotalQuantity, GETDATE() AS CurrentDateTime
    FROM OrderItem
    WHERE createdAt >= DATEADD(SECOND, -60, GETDATE());

END;

--- Rollback Instructions
--- To rollback `2024-09-24__TKT-23__Create__GetRecentOrderItems.sql`, use the following SQL:
--- DROP PROCEDURE GetRecentOrderItems;
