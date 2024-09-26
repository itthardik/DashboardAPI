-- Script Name: 2024-09-24__TKT-22__Create__GetOrderItemsByDate.sql
-- Author: Hardik Sharma
-- Date: 2024-09-24
-- Description: This script creates the `GetOrderItemsByDate` stored procedure that retrieves all order items for a specified date.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-24__TKT-22__Create__GetOrderItemsByDate.sql` on the target database.

CREATE PROCEDURE GetOrderItemsByDate
    @SelectedDate DATE
AS
BEGIN

    -- Select all order items created on the specified date.
    SELECT * 
    FROM OrderItem 
    WHERE 
        createdAt >= @SelectedDate 
        AND createdAt < DATEADD(DAY, 1, @SelectedDate);

END;

--- Rollback Instructions
--- To rollback `2024-09-24__TKT-22__Create__GetOrderItemsByDate.sql`, use the following SQL:
--- DROP PROCEDURE GetOrderItemsByDate;
