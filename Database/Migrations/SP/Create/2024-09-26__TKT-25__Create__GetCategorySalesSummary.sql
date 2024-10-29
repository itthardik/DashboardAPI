-- Script Name: 2024-09-26__TKT-25__Create__GetCategorySalesSummary.sql
-- Author: Hardik Sharma
-- Date: 2024-09-26
-- Description: This script creates the `GetCategorySalesSummary` stored procedure that retrieves the total sales for each category, ordered by total sales in descending order.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-26__TKT-25__Create__GetCategorySalesSummary.sql` on the target database.

CREATE PROCEDURE GetCategorySalesSummary
AS
BEGIN

    -- Select the total sales for each category, ordered by total sales in descending order.
    SELECT 
        p.categoryId AS Id, 
        c.categoryName AS Name, 
        SUM(oi.quantity) AS TotalSales
    FROM 
        OrderItem oi 
    JOIN 
        Product p ON p.id = oi.productId 
    JOIN 
        Category c ON c.id = p.categoryId
    GROUP BY 
        p.categoryId, c.categoryName
    ORDER BY 
        TotalSales DESC;

END;

--- Rollback Instructions
--- To rollback `2024-09-26__TKT-25__Create__GetCategorySalesSummary.sql`, use the following SQL:
--- DROP PROCEDURE GetCategorySalesSummary;
