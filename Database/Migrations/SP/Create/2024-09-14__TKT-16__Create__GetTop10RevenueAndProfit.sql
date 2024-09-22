-- Script Name: 2024-09-14__TKT-16__Create__GetTop10RevenueAndProfit.sql
-- Author: Hardik Sharma
-- Date: 2024-09-14
-- Description: This script creates the `GetTop10RevenueAndProfit` stored procedure that retrieves the top 10 product categories based on revenue and profit within a specified number of days.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-14__TKT-16__Create__GetTop10RevenueAndProfit.sql` on the target database.


CREATE PROCEDURE GetTop10RevenueAndProfit
    @DaysBack INT
AS
BEGIN
    
    DECLARE @StartDate DATETIME;
    SET @StartDate = DATEADD(DAY, -@DaysBack, CAST(GETDATE() AS DATE));

    SELECT TOP 10
        c.categoryName AS CategoryName, 
        ISNULL(SUM(p.sellingPrice * oi.quantity), 0) AS Revenue, 
        ISNULL(SUM(p.netProfit * oi.quantity), 0) AS Profit 
    FROM 
        Category c
    LEFT JOIN 
        Product p 
    ON 
        c.id = p.categoryId
    LEFT JOIN 
        OrderItem oi
    ON 
        p.id = oi.productId
    WHERE 
        oi.createdAt >= @StartDate OR oi.createdAt IS NULL
    GROUP BY 
        c.categoryName, c.id

END;


--- Rollback Instructions
--- To rollback `2024-09-14__TKT-16__Create__GetTop10RevenueAndProfit.sql`, use the following SQL:
--- DROP PROCEDURE GetTop10RevenueAndProfit;
