-- Script Name: 2024-09-17__TKT-17__Update__AddAvgDailyUsageAndRenameThresholdValue.sql
-- Author: Hardik Sharma
-- Date: 2024-09-17
-- Description: This script adds a new column `averageDailyUsage` and renames the existing `thresholdValue` column to `reorderPoint` in the `Product` table.
-- Dependencies: Product table.
--
-- To apply this migration:
-- Run `2024-09-17__TKT-17__Update__AddAvgDailyUsageAndRenameThresholdValue.sql` on the target database.

-- Add the new column `averageDailyUsage`
ALTER TABLE Product
ADD averageDailyUsage DECIMAL(10, 5);

-- Rename the existing column `thresholdValue` to `reorderPoint`
EXEC sp_rename 'Product.dbo.thresholdValue', 'reorderPoint', 'COLUMN';

--- Rollback Instructions
--- To rollback `2024-09-17__TKT-17__Update__AddAvgDailyUsageAndRenameThresholdValue.sql`, use the following SQL:
--- -- Drop the `averageDailyUsage` column (if needed)
--- ALTER TABLE Product
--- DROP COLUMN averageDailyUsage;
--- -- Rename the column `reorderPoint` back to `thresholdValue`
--- EXEC sp_rename 'Product.reorderPoint', 'thresholdValue', 'COLUMN';
