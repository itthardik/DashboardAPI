-- Script Name: 2024-09-24__TKT-21__Create__GetTotalSalesByCategory.sql
-- Author: Hardik Sharma
-- Date: 2024-09-24
-- Description: This script creates the `GetTotalSalesByCategory` stored procedure that retrieves total sales quantities for each product category for today.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-24__TKT-21__Create__GetTotalSalesByCategory.sql` on the target database.

CREATE PROCEDURE GetTotalSalesByCategory
    @DaysBack INT
AS
BEGIN

    DECLARE @StartDate DATETIME;
    SET @StartDate = DATEADD(DAY, -@DaysBack, CAST(GETDATE() AS DATE));

    -- Select total sales and category name for each category, including those with no sales.
    SELECT 
        c.id AS CategoryId,
        ISNULL(SUM(oi.quantity), 0) AS TotalSales, 
        c.categoryName AS Category
    FROM 
        Category c
    LEFT JOIN 
        Product p ON c.id = p.categoryId 
    LEFT JOIN 
        OrderItem oi ON p.id = oi.productId 
    AND 
        oi.createdAt >= @StartDate
    GROUP BY 
        c.categoryName, c.id
    ORDER BY 
        c.categoryName;

END;


--- Rollback Instructions
--- To rollback `2024-09-24__TKT-21__Create__GetTotalSalesByCategory.sql`, use the following SQL:
--- DROP PROCEDURE GetTotalSalesByCategory;
