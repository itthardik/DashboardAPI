-- Script Name: 2024-09-11__TKT-10__Seed__Products.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script seeds the `Product` table with 82 entries.
-- Dependencies: Product table, Category table, Supplier table.
--
-- To apply this migration:
-- Run `2024-09-11__TKT-10__Seed__Products.sql` on the target database.

INSERT INTO Product (name, costPrice, sellingPrice, shippingCost, discount, thresholdValue, categoryId, currentStock, supplierId)
VALUES 
    ('Basic T-Shirt', 500.00, 1500.00, 200.00, 100.00, 10, 1, 100, 1),
    ('Classic Jeans', 2000.00, 5000.00, 500.00, 300.00, 15, 1, 50, 2),
    ('Elegant Dress', 3000.00, 7500.00, 800.00, 1000.00, 20, 2, 25, 3),
    ('Running Shoes', 2500.00, 6000.00, 600.00, 400.00, 10, 3, 75, 4),
    ('Winter Jacket', 4000.00, 9000.00, 1200.00, 1400.00, 5, 1, 30, 5),
    ('Leather Belt', 1000.00, 2500.00, 100.00, 200.00, 50, 4, 200, 6),
    ('Sunglasses', 1500.00, 3500.00, 120.00, 300.00, 25, 2, 60, 7),
    ('Stylish Hat', 1200.00, 2800.00, 100.00, 250.00, 20, 3, 85, 8),
    ('Casual Sneakers', 1800.00, 4500.00, 300.00, 300.00, 30, 4, 90, 9),
    ('Formal Shirt', 2000.00, 5000.00, 200.00, 400.00, 15, 2, 40, 10),
    ('Yoga Pants', 1500.00, 3500.00, 200.00, 100.00, 25, 1, 70, 1),
    ('Running Shorts', 1200.00, 3000.00, 150.00, 100.00, 20, 2, 55, 2),
    ('Cozy Blanket', 1800.00, 4000.00, 300.00, 100.00, 30, 3, 45, 3),
    ('Cotton Socks', 600.00, 1600.00, 100.00, 50.00, 100, 4, 200, 4),
    ('Handbag', 5000.00, 12000.00, 800.00, 1000.00, 10, 5, 20, 5),
    ('Wool Scarf', 2000.00, 5000.00, 200.00, 400.00, 30, 1, 80, 6),
    ('Glamorous Earrings', 1600.00, 4000.00, 200.00, 300.00, 50, 2, 100, 7),
    ('Warm Gloves', 2400.00, 5600.00, 300.00, 500.00, 20, 3, 75, 8),
    ('Raincoat', 5000.00, 11000.00, 700.00, 800.00, 10, 4, 40, 9),
    ('Leather Wallet', 1500.00, 3500.00, 200.00, 300.00, 25, 5, 60, 10),
    ('Designer Sunglasses', 3000.00, 7000.00, 600.00, 1000.00, 15, 1, 25, 1),
    ('Denim Jacket', 7000.00, 16000.00, 1000.00, 800.00, 20, 2, 35, 2),
    ('Floral Dress', 5600.00, 13000.00, 800.00, 1200.00, 15, 3, 30, 3),
    ('Sport Watch', 8000.00, 18000.00, 1200.00, 1400.00, 10, 4, 20, 4),
    ('Fleece Jacket', 4400.00, 10000.00, 600.00, 600.00, 15, 5, 40, 5),
    ('Stylish Backpack', 6000.00, 14000.00, 800.00, 1000.00, 10, 1, 15, 6),
    ('Casual Loafers', 3600.00, 8000.00, 500.00, 700.00, 25, 2, 65, 7),
    ('Soft Pajamas', 2400.00, 6000.00, 400.00, 500.00, 20, 3, 50, 8),
    ('Elegant Necklace', 4000.00, 9000.00, 400.00, 600.00, 15, 4, 30, 9),
    ('Luxury Pillow', 4400.00, 10000.00, 600.00, 700.00, 15, 5, 25, 10),
    ('Classic Blazer', 9000.00, 20000.00, 1200.00, 1600.00, 10, 1, 20, 1),
    ('Fashionable Skirt', 4000.00, 10000.00, 600.00, 400.00, 30, 2, 60, 2),
    ('Casual Hoodie', 5600.00, 13000.00, 800.00, 1000.00, 20, 3, 40, 3),
    ('Stylish Earrings', 3000.00, 7000.00, 400.00, 600.00, 25, 4, 75, 4),
    ('Comfortable Slippers', 2000.00, 5000.00, 300.00, 400.00, 30, 5, 100, 5),
    ('Chic Bracelet', 2400.00, 6000.00, 200.00, 500.00, 20, 1, 50, 6),
    ('Trendy Cap', 1600.00, 4000.00, 200.00, 300.00, 50, 2, 100, 7),
    ('Premium Jeans', 5000.00, 12000.00, 600.00, 800.00, 15, 3, 45, 8),
    ('Luxury Handbag', 10000.00, 24000.00, 1200.00, 1400.00, 10, 4, 20, 9),
    ('Soft Throw Blanket', 1800.00, 4000.00, 300.00, 400.00, 30, 5, 30, 10),
    ('Fashionable Watch', 7000.00, 16000.00, 800.00, 1000.00, 15, 1, 25, 1),
    ('Vintage Jacket', 2500.00, 6000.00, 400.00, 800.00, 20, 1, 35, 1),
    ('Elegant Skirt', 1500.00, 3500.00, 200.00, 400.00, 15, 2, 45, 2),
    ('Smartwatch', 4000.00, 9500.00, 500.00, 1000.00, 10, 3, 25, 3),
    ('Luxury Sofa', 20000.00, 45000.00, 2500.00, 5000.00, 5, 4, 10, 4),
    ('Modern Art Print', 3000.00, 7000.00, 300.00, 500.00, 25, 5, 40, 5),
    ('Chic Clutch', 1800.00, 4200.00, 150.00, 250.00, 30, 1, 60, 6),
    ('Premium Yoga Mat', 2200.00, 5000.00, 200.00, 400.00, 20, 2, 75, 7),
    ('Casual Shorts', 2000.00, 5000.00, 250.00, 300.00, 30, 3, 60, 8),
    ('Elegant Table Lamp', 2500.00, 6000.00, 300.00, 500.00, 25, 4, 50, 9),
    ('Designer Rug', 3500.00, 8000.00, 500.00, 700.00, 20, 5, 40, 10),
    ('Stylish Tableware', 5000.00, 12000.00, 800.00, 1000.00, 15, 1, 20, 1),
    ('Chic Pendant', 1500.00, 3500.00, 200.00, 300.00, 25, 2, 60, 2),
    ('Sport Jacket', 4000.00, 9500.00, 500.00, 600.00, 30, 3, 35, 3),
    ('High-End Speaker', 8000.00, 18000.00, 1000.00, 1200.00, 10, 4, 15, 4),
    ('Luxury Pen', 1200.00, 2800.00, 150.00, 200.00, 20, 5, 75, 5),
    ('Comfortable Mattress', 20000.00, 45000.00, 2000.00, 2500.00, 5, 1, 10, 1),
    ('Chic Dress', 3000.00, 7000.00, 500.00, 800.00, 25, 2, 30, 2),
    ('Casual Sneakers', 1800.00, 4500.00, 300.00, 200.00, 20, 3, 70, 3),
    ('Luxury Tablecloth', 1500.00, 3500.00, 100.00, 200.00, 30, 4, 80, 4),
    ('Glamorous Watch', 5000.00, 12000.00, 600.00, 800.00, 15, 5, 45, 5),
    ('Classic Tie', 1000.00, 2500.00, 100.00, 150.00, 40, 1, 90, 6),
    ('Designer Sunglasses', 2500.00, 6000.00, 250.00, 300.00, 25, 2, 50, 7),
    ('Fashionable Jacket', 6000.00, 14000.00, 800.00, 1000.00, 10, 3, 25, 8),
    ('Trendy Watch', 3000.00, 7000.00, 400.00, 600.00, 30, 4, 55, 9),
    ('Luxury Sofa Set', 25000.00, 60000.00, 3000.00, 4000.00, 5, 5, 15, 10),
    ('Elegant Shawl', 2000.00, 5000.00, 250.00, 300.00, 20, 1, 65, 1),
    ('Comfortable Chair', 5000.00, 12000.00, 800.00, 1000.00, 15, 2, 35, 2),
    ('Glamorous Necklace', 4500.00, 10000.00, 600.00, 800.00, 10, 3, 25, 3),
    ('Premium Pillow', 1800.00, 4000.00, 300.00, 200.00, 30, 4, 55, 4),
    ('Stylish Backpack', 4000.00, 9000.00, 500.00, 600.00, 20, 5, 40, 5),
    ('Luxury Watch', 10000.00, 24000.00, 1500.00, 2000.00, 10, 1, 20, 1),
    ('Elegant Bracelet', 3500.00, 8000.00, 400.00, 500.00, 25, 2, 60, 2),
    ('Designer Shoes', 4500.00, 10500.00, 600.00, 800.00, 15, 3, 40, 3),
    ('High-Quality Paintings', 8000.00, 18000.00, 1200.00, 1000.00, 10, 4, 25, 4),
    ('Premium Wine Glasses', 3000.00, 7000.00, 400.00, 600.00, 20, 5, 50, 5),
    ('Luxury Bed Linen', 6000.00, 14000.00, 800.00, 1000.00, 15, 1, 35, 1),
    ('Elegant Table Runner', 2200.00, 5000.00, 200.00, 300.00, 30, 2, 70, 2),
    ('Chic Handbag', 2500.00, 6000.00, 300.00, 400.00, 25, 3, 50, 3),
    ('High-End Coffee Maker', 10000.00, 24000.00, 2000.00, 1500.00, 10, 4, 10, 4),
    ('Designer Rug', 3000.00, 7000.00, 400.00, 500.00, 20, 5, 40, 5),
    ('Stylish Bedding Set', 5000.00, 12000.00, 600.00, 800.00, 15, 1, 25, 1);

-- To apply this rollback:
-- Run `2024-09-11__TKT-11__Rollback__Products_Seed.sql` on the target database.

--DELETE FROM Product WHERE CreatedAt >= '2024-09-11T00:00:00'  AND CreatedAt < '2024-09-12T00:00:00';

select * from Category

select * from Product

-- Updating categories based on the provided range from 1 to 10
---UPDATE Product SET categoryId = 1 WHERE id = 1;  -- Basic T-Shirt
---UPDATE Product SET categoryId = 1 WHERE id = 2;  -- Classic Jeans
---UPDATE Product SET categoryId = 2 WHERE id = 3;  -- Elegant Dress
---UPDATE Product SET categoryId = 3 WHERE id = 4;  -- Running Shoes
---UPDATE Product SET categoryId = 4 WHERE id = 5;  -- Winter Jacket
---UPDATE Product SET categoryId = 5 WHERE id = 6;  -- Leather Belt
---UPDATE Product SET categoryId = 6 WHERE id = 7;  -- Sunglasses
---UPDATE Product SET categoryId = 7 WHERE id = 8;  -- Stylish Hat
---UPDATE Product SET categoryId = 8 WHERE id = 9;  -- Casual Sneakers
---UPDATE Product SET categoryId = 9 WHERE id = 10; -- Formal Shirt
---UPDATE Product SET categoryId = 10 WHERE id = 11; -- Yoga Pants
---UPDATE Product SET categoryId = 1 WHERE id = 12; -- Running Shorts
---UPDATE Product SET categoryId = 2 WHERE id = 13; -- Cozy Blanket
---UPDATE Product SET categoryId = 3 WHERE id = 14; -- Cotton Socks
---UPDATE Product SET categoryId = 4 WHERE id = 15; -- Handbag
---UPDATE Product SET categoryId = 5 WHERE id = 16; -- Wool Scarf
---UPDATE Product SET categoryId = 6 WHERE id = 17; -- Glamorous Earrings
---UPDATE Product SET categoryId = 7 WHERE id = 18; -- Warm Gloves
---UPDATE Product SET categoryId = 8 WHERE id = 19; -- Raincoat
---UPDATE Product SET categoryId = 9 WHERE id = 20; -- Leather Wallet
---UPDATE Product SET categoryId = 10 WHERE id = 21; -- Designer Sunglasses
---UPDATE Product SET categoryId = 1 WHERE id = 22; -- Denim Jacket
---UPDATE Product SET categoryId = 2 WHERE id = 23; -- Floral Dress
---UPDATE Product SET categoryId = 3 WHERE id = 24; -- Sport Watch
---UPDATE Product SET categoryId = 4 WHERE id = 25; -- Fleece Jacket
---UPDATE Product SET categoryId = 5 WHERE id = 26; -- Stylish Backpack
---UPDATE Product SET categoryId = 6 WHERE id = 27; -- Casual Loafers
---UPDATE Product SET categoryId = 7 WHERE id = 28; -- Soft Pajamas
---UPDATE Product SET categoryId = 8 WHERE id = 29; -- Elegant Necklace
---UPDATE Product SET categoryId = 9 WHERE id = 30; -- Luxury Pillow
---UPDATE Product SET categoryId = 10 WHERE id = 31; -- Classic Blazer
---UPDATE Product SET categoryId = 1 WHERE id = 32; -- Fashionable Skirt
---UPDATE Product SET categoryId = 2 WHERE id = 33; -- Casual Hoodie
---UPDATE Product SET categoryId = 3 WHERE id = 34; -- Stylish Earrings
---UPDATE Product SET categoryId = 4 WHERE id = 35; -- Comfortable Slippers
---UPDATE Product SET categoryId = 5 WHERE id = 36; -- Chic Bracelet
---UPDATE Product SET categoryId = 6 WHERE id = 37; -- Trendy Cap
---UPDATE Product SET categoryId = 7 WHERE id = 38; -- Premium Jeans
---UPDATE Product SET categoryId = 8 WHERE id = 39; -- Luxury Handbag
---UPDATE Product SET categoryId = 9 WHERE id = 40; -- Soft Throw Blanket
---UPDATE Product SET categoryId = 10 WHERE id = 41; -- Fashionable Watch
---UPDATE Product SET categoryId = 1 WHERE id = 42; -- Vintage Jacket
---UPDATE Product SET categoryId = 2 WHERE id = 43; -- Elegant Skirt
---UPDATE Product SET categoryId = 3 WHERE id = 44; -- Smartwatch
---UPDATE Product SET categoryId = 4 WHERE id = 45; -- Luxury Sofa
---UPDATE Product SET categoryId = 5 WHERE id = 46; -- Modern Art Print
---UPDATE Product SET categoryId = 6 WHERE id = 47; -- Chic Clutch
---UPDATE Product SET categoryId = 7 WHERE id = 48; -- Premium Yoga Mat
---UPDATE Product SET categoryId = 8 WHERE id = 49; -- Casual Shorts
---UPDATE Product SET categoryId = 9 WHERE id = 50; -- Elegant Table Lamp
---UPDATE Product SET categoryId = 10 WHERE id = 51; -- Designer Rug
---UPDATE Product SET categoryId = 1 WHERE id = 52; -- Stylish Tableware
---UPDATE Product SET categoryId = 2 WHERE id = 53; -- Chic Pendant
---UPDATE Product SET categoryId = 3 WHERE id = 54; -- Sport Jacket
---UPDATE Product SET categoryId = 4 WHERE id = 55; -- High-End Speaker
---UPDATE Product SET categoryId = 5 WHERE id = 56; -- Luxury Pen
---UPDATE Product SET categoryId = 6 WHERE id = 57; -- Comfortable Mattress
---UPDATE Product SET categoryId = 7 WHERE id = 58; -- Chic Dress
---UPDATE Product SET categoryId = 8 WHERE id = 59; -- Casual Sneakers
---UPDATE Product SET categoryId = 9 WHERE id = 60; -- Luxury Tablecloth
---UPDATE Product SET categoryId = 10 WHERE id = 61; -- Glamorous Watch
---UPDATE Product SET categoryId = 1 WHERE id = 62; -- Classic Tie
---UPDATE Product SET categoryId = 2 WHERE id = 63; -- Designer Sunglasses
---UPDATE Product SET categoryId = 3 WHERE id = 64; -- Fashionable Jacket
---UPDATE Product SET categoryId = 4 WHERE id = 65; -- Trendy Watch
---UPDATE Product SET categoryId = 5 WHERE id = 66; -- Luxury Sofa Set
---UPDATE Product SET categoryId = 6 WHERE id = 67; -- Elegant Shawl
---UPDATE Product SET categoryId = 7 WHERE id = 68; -- Comfortable Chair
---UPDATE Product SET categoryId = 8 WHERE id = 69; -- Glamorous Necklace
---UPDATE Product SET categoryId = 9 WHERE id = 70; -- Premium Pillow
---UPDATE Product SET categoryId = 10 WHERE id = 71; -- Stylish Backpack
---UPDATE Product SET categoryId = 1 WHERE id = 72; -- Luxury Watch
---UPDATE Product SET categoryId = 2 WHERE id = 73; -- Elegant Bracelet
---UPDATE Product SET categoryId = 3 WHERE id = 74; -- Designer Shoes
---UPDATE Product SET categoryId = 4 WHERE id = 75; -- High-Quality Paintings
---UPDATE Product SET categoryId = 5 WHERE id = 76; -- Premium Wine Glasses
---UPDATE Product SET categoryId = 6 WHERE id = 77; -- Luxury Bed Linen
---UPDATE Product SET categoryId = 7 WHERE id = 78; -- Elegant Table Runner
---UPDATE Product SET categoryId = 8 WHERE id = 79; -- Chic Handbag
---UPDATE Product SET categoryId = 9 WHERE id = 80; -- High-End Coffee Maker
---UPDATE Product SET categoryId = 10 WHERE id = 81; -- Designer Rug
---UPDATE Product SET categoryId = 1 WHERE id = 82; -- Stylish Bedding Set
