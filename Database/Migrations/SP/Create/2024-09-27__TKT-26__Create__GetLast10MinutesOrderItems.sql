-- Script Name: 2024-09-27__TKT-26__Create__GetLast10MinutesOrderItems.sql
-- Author: Hardik Sharma
-- Date: 2024-09-27
-- Description: This script creates the `GetLast10MinutesOrderItems` stored procedure that retrieves the total quantity of order items created in the last 10 minutes.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-27__TKT-26__Create__GetLast10MinutesOrderItems.sql` on the target database.

CREATE PROCEDURE GetLast10MinutesOrderItems
AS
BEGIN
    -- Set NOCOUNT to prevent the message indicating the number of rows affected
    SET NOCOUNT ON;

    -- Declare variable to hold the current date and time
    DECLARE @CurrentDateTime DATETIME = GETDATE();

    -- Common Table Expression (CTE) to generate time intervals for the last 10 minutes
    WITH TimeIntervals AS (
        SELECT TOP 10
            DATEADD(MINUTE, -ROW_NUMBER() OVER (ORDER BY (SELECT NULL)), @CurrentDateTime) AS IntervalStart
        FROM master..spt_values
    )
    
    -- Select total quantity of order items for each minute interval in the last 10 minutes
    SELECT 
        ISNULL(SUM(OI.quantity), 0) AS TotalQuantity,
        TI.IntervalStart AS CurrentDateTime
    FROM 
        TimeIntervals TI
    LEFT JOIN 
        OrderItem OI ON OI.createdAt >= TI.IntervalStart AND OI.createdAt < DATEADD(MINUTE, 1, TI.IntervalStart)
    GROUP BY 
        TI.IntervalStart
    ORDER BY 
        TI.IntervalStart;

END;

--- Rollback Instructions
--- To rollback `2024-09-27__TKT-26__Create__GetLast10MinutesOrderItems.sql`, use the following SQL:
--- DROP PROCEDURE GetLast10MinutesOrderItems;
