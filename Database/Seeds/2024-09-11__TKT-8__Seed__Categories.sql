-- Script Name: 2024-09-11__TKT-8__Seed__Categories.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script seeds predefined categories into the `Category` table.
-- Dependencies: Category table.
--
-- To apply this migration:
-- Run `2024-09-11__TKT-8__Seed__Categories.sql` on the target database.

INSERT INTO Category (categoryName)
VALUES 
    ('Women’s Clothing'),
    ('Men’s Clothing'),
    ('Kids’ Clothing'),
    ('Accessories'),
    ('Footwear'),
    ('Home Textiles'),
    ('Activewear'),
    ('Sleepwear'),
    ('Outerwear'),
    ('Sustainable Collections');

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-8__Seed__Categories.sql`, use the following SQL:
--- DELETE FROM Category WHERE categoryName IN ('Women’s Clothing', 'Men’s Clothing', 'Kids’ Clothing', 'Accessories', 'Footwear', 'Home Textiles', 'Activewear', 'Sleepwear', 'Outerwear', 'Sustainable Collections');
