-- Script Name: 2024-09-11__TKT-9__Seed__Suppliers.sql
-- Author: Hardik Sharma
-- Date: 2024-09-11
-- Description: This script seeds the `Supplier` table with 10 entries.
-- Dependencies: Supplier table.
--
-- To apply this migration:
-- Run `2024-09-11__TKT-9__Seed__Suppliers.sql` on the target database.

INSERT INTO Supplier (name, contactInfo, address)
VALUES 
    ('Supplier A', 'contact@supplierA.com', '123 Supplier St, City, Country'),
    ('Supplier B', 'contact@supplierB.com', '456 Supplier Ave, City, Country'),
    ('Supplier C', 'contact@supplierC.com', '789 Supplier Blvd, City, Country'),
    ('Supplier D', 'contact@supplierD.com', '101 Supplier Rd, City, Country'),
    ('Supplier E', 'contact@supplierE.com', '202 Supplier Pkwy, City, Country'),
    ('Supplier F', 'contact@supplierF.com', '303 Supplier Ln, City, Country'),
    ('Supplier G', 'contact@supplierG.com', '404 Supplier Ct, City, Country'),
    ('Supplier H', 'contact@supplierH.com', '505 Supplier Dr, City, Country'),
    ('Supplier I', 'contact@supplierI.com', '606 Supplier Loop, City, Country'),
    ('Supplier J', 'contact@supplierJ.com', '707 Supplier Way, City, Country');

--- Rollback Instructions
--- To rollback `2024-09-11__TKT-9__Seed__Suppliers.sql`, use the following SQL:
--- DELETE FROM Supplier WHERE name IN ('Supplier A', 'Supplier B', 'Supplier C', 'Supplier D', 'Supplier E', 'Supplier F', 'Supplier G', 'Supplier H', 'Supplier I', 'Supplier J');
