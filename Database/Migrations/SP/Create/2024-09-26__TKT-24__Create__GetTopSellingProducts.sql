-- Script Name: 2024-09-26__TKT-24__Create__GetTopSellingProducts.sql
-- Author: Hardik Sharma
-- Date: 2024-09-26
-- Description: This script creates the `GetTopSellingProducts` stored procedure that retrieves the total sales of each product, ordered by total sales in descending order.
-- Dependencies: None.
--
-- To apply this migration:
-- Run `2024-09-26__TKT-24__Create__GetTopSellingProducts.sql` on the target database.

CREATE PROCEDURE GetTopSellingProducts
AS
BEGIN

    -- Select the total sales of each product, ordered by total sales in descending order.
    SELECT 
        oi.productId AS Id, 
        p.name AS Name, 
        SUM(oi.quantity) AS TotalSales
    FROM 
        OrderItem oi 
    JOIN 
        Product p ON p.id = oi.productId
    GROUP BY 
        oi.productId, p.name
    ORDER BY 
        TotalSales DESC;

END;

--- Rollback Instructions
--- To rollback `2024-09-26__TKT-24__Create__GetTopSellingProducts.sql`, use the following SQL:
--- DROP PROCEDURE GetTopSellingProducts;
