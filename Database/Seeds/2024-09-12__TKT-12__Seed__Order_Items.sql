-- Script Name: 2024-09-12__TKT-12__Seed__Order_Items.sql
-- Author: Hardik Sharma
-- Date: 2024-09-12
-- Description: This script seeds the `ORDER_ITEM` table with items for each of the 100+ orders.
-- Dependencies: `ORDER_ITEM` table.
--
-- To apply this migration:
-- Run `2024-09-12__TKT-12__Seed__Order_Items.sql` on the target database.

-- Order ID 201
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(5, 201, 3, 0.00, 'Pending', 0.00),
(18, 201, 2, 0.00, 'Shipped', 0.00);

-- Order ID 202
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 202, 1, 0.00, 'Delivered', 0.00),
(29, 202, 4, 0.00, 'Pending', 0.00),
(33, 202, 2, 0.00, 'Returned', 0.00);

-- Order ID 203
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(10, 203, 5, 0.00, 'Shipped', 0.00),
(21, 203, 1, 0.00, 'Pending', 0.00),
(45, 203, 3, 0.00, 'Delivered', 0.00);

-- Order ID 204
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 204, 2, 0.00, 'Returned', 0.00),
(54, 204, 1, 0.00, 'Pending', 0.00),
(67, 204, 4, 0.00, 'Shipped', 0.00);

-- Order ID 205
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 205, 3, 0.00, 'Shipped', 0.00),
(41, 205, 2, 0.00, 'Delivered', 0.00);

-- Order ID 206
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 206, 2, 0.00, 'Pending', 0.00),
(28, 206, 1, 0.00, 'Returned', 0.00),
(55, 206, 3, 0.00, 'Shipped', 0.00);

-- Order ID 207
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(22, 207, 4, 0.00, 'Delivered', 0.00),
(38, 207, 1, 0.00, 'Pending', 0.00),
(48, 207, 2, 0.00, 'Shipped', 0.00);

-- Order ID 208
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(15, 208, 1, 0.00, 'Returned', 0.00),
(53, 208, 3, 0.00, 'Pending', 0.00),
(71, 208, 2, 0.00, 'Shipped', 0.00);

-- Order ID 209
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(9, 209, 1, 0.00, 'Shipped', 0.00),
(30, 209, 2, 0.00, 'Delivered', 0.00),
(60, 209, 4, 0.00, 'Pending', 0.00);

-- Order ID 210
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 210, 2, 0.00, 'Pending', 0.00),
(42, 210, 1, 0.00, 'Returned', 0.00),
(69, 210, 3, 0.00, 'Shipped', 0.00);

-- Order ID 211
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 211, 2, 0.00, 'Pending', 0.00),
(27, 211, 1, 0.00, 'Shipped', 0.00),
(45, 211, 3, 0.00, 'Delivered', 0.00);

-- Order ID 212
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 212, 4, 0.00, 'Returned', 0.00),
(34, 212, 2, 0.00, 'Pending', 0.00),
(56, 212, 1, 0.00, 'Shipped', 0.00);

-- Order ID 213
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(23, 213, 3, 0.00, 'Delivered', 0.00),
(42, 213, 1, 0.00, 'Pending', 0.00),
(59, 213, 2, 0.00, 'Returned', 0.00);

-- Order ID 214
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(4, 214, 1, 0.00, 'Shipped', 0.00),
(35, 214, 2, 0.00, 'Delivered', 0.00),
(63, 214, 3, 0.00, 'Pending', 0.00);

-- Order ID 215
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 215, 1, 0.00, 'Returned', 0.00),
(49, 215, 2, 0.00, 'Shipped', 0.00),
(64, 215, 4, 0.00, 'Delivered', 0.00);

-- Order ID 216
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(18, 216, 3, 0.00, 'Pending', 0.00),
(31, 216, 1, 0.00, 'Shipped', 0.00),
(50, 216, 2, 0.00, 'Returned', 0.00);

-- Order ID 217
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(5, 217, 2, 0.00, 'Delivered', 0.00),
(40, 217, 3, 0.00, 'Pending', 0.00);

-- Order ID 218
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 218, 1, 0.00, 'Returned', 0.00),
(47, 218, 4, 0.00, 'Shipped', 0.00),
(68, 218, 2, 0.00, 'Delivered', 0.00);

-- Order ID 219
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(9, 219, 1, 0.00, 'Pending', 0.00),
(28, 219, 2, 0.00, 'Shipped', 0.00),
(57, 219, 3, 0.00, 'Delivered', 0.00);

-- Order ID 220
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(6, 220, 2, 0.00, 'Returned', 0.00),
(30, 220, 1, 0.00, 'Pending', 0.00),
(54, 220, 3, 0.00, 'Shipped', 0.00);

-- Order ID 221
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(16, 221, 1, 0.00, 'Shipped', 0.00),
(39, 221, 2, 0.00, 'Delivered', 0.00),
(65, 221, 1, 0.00, 'Pending', 0.00);

-- Order ID 222
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(3, 222, 2, 0.00, 'Returned', 0.00),
(20, 222, 4, 0.00, 'Shipped', 0.00),
(52, 222, 1, 0.00, 'Delivered', 0.00);

-- Order ID 223
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(26, 223, 2, 0.00, 'Pending', 0.00),
(37, 223, 1, 0.00, 'Returned', 0.00),
(58, 223, 3, 0.00, 'Shipped', 0.00);

-- Order ID 224
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 224, 3, 0.00, 'Delivered', 0.00),
(22, 224, 1, 0.00, 'Pending', 0.00),
(41, 224, 2, 0.00, 'Shipped', 0.00);

-- Order ID 225
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(24, 225, 2, 0.00, 'Returned', 0.00),
(43, 225, 1, 0.00, 'Shipped', 0.00),
(60, 225, 3, 0.00, 'Delivered', 0.00);

-- Order ID 226
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(10, 226, 1, 0.00, 'Pending', 0.00),
(33, 226, 2, 0.00, 'Returned', 0.00),
(48, 226, 4, 0.00, 'Shipped', 0.00);

-- Order ID 227
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(15, 227, 2, 0.00, 'Delivered', 0.00),
(38, 227, 3, 0.00, 'Pending', 0.00);

-- Order ID 228
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(2, 228, 1, 0.00, 'Shipped', 0.00),
(30, 228, 2, 0.00, 'Delivered', 0.00),
(52, 228, 4, 0.00, 'Returned', 0.00);

-- Order ID 229
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(4, 229, 3, 0.00, 'Pending', 0.00),
(29, 229, 1, 0.00, 'Shipped', 0.00),
(44, 229, 2, 0.00, 'Delivered', 0.00);

-- Order ID 230
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 230, 2, 0.00, 'Returned', 0.00),
(50, 230, 1, 0.00, 'Shipped', 0.00),
(65, 230, 3, 0.00, 'Pending', 0.00);

-- Order ID 231
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 231, 2, 0.00, 'Pending', 0.00),
(26, 231, 3, 0.00, 'Shipped', 0.00),
(45, 231, 1, 0.00, 'Delivered', 0.00);

-- Order ID 232
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 232, 4, 0.00, 'Returned', 0.00),
(31, 232, 2, 0.00, 'Shipped', 0.00),
(60, 232, 1, 0.00, 'Pending', 0.00);

-- Order ID 233
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 233, 3, 0.00, 'Delivered', 0.00),
(42, 233, 1, 0.00, 'Shipped', 0.00),
(51, 233, 2, 0.00, 'Returned', 0.00);

-- Order ID 234
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 234, 2, 0.00, 'Pending', 0.00),
(25, 234, 1, 0.00, 'Delivered', 0.00),
(39, 234, 3, 0.00, 'Shipped', 0.00);

-- Order ID 235
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(16, 235, 2, 0.00, 'Returned', 0.00),
(44, 235, 3, 0.00, 'Shipped', 0.00),
(53, 235, 1, 0.00, 'Pending', 0.00);

-- Order ID 236
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(3, 236, 1, 0.00, 'Delivered', 0.00),
(30, 236, 2, 0.00, 'Pending', 0.00),
(58, 236, 4, 0.00, 'Shipped', 0.00);

-- Order ID 237
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 237, 3, 0.00, 'Shipped', 0.00),
(33, 237, 1, 0.00, 'Delivered', 0.00),
(51, 237, 2, 0.00, 'Pending', 0.00);

-- Order ID 238
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 238, 2, 0.00, 'Returned', 0.00),
(42, 238, 4, 0.00, 'Shipped', 0.00),
(67, 238, 1, 0.00, 'Delivered', 0.00);

-- Order ID 239
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 239, 3, 0.00, 'Pending', 0.00),
(39, 239, 2, 0.00, 'Returned', 0.00),
(54, 239, 1, 0.00, 'Shipped', 0.00);

-- Order ID 240
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(6, 240, 2, 0.00, 'Delivered', 0.00),
(29, 240, 1, 0.00, 'Pending', 0.00),
(49, 240, 3, 0.00, 'Shipped', 0.00);

-- Order ID 241
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(4, 241, 1, 0.00, 'Returned', 0.00),
(22, 241, 3, 0.00, 'Shipped', 0.00),
(47, 241, 2, 0.00, 'Delivered', 0.00);

-- Order ID 242
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(18, 242, 2, 0.00, 'Pending', 0.00),
(38, 242, 4, 0.00, 'Returned', 0.00),
(53, 242, 1, 0.00, 'Shipped', 0.00);

-- Order ID 243
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(5, 243, 1, 0.00, 'Shipped', 0.00),
(27, 243, 2, 0.00, 'Delivered', 0.00),
(43, 243, 3, 0.00, 'Pending', 0.00);

-- Order ID 244
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 244, 2, 0.00, 'Returned', 0.00),
(32, 244, 1, 0.00, 'Pending', 0.00),
(60, 244, 3, 0.00, 'Shipped', 0.00);

-- Order ID 245
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 245, 3, 0.00, 'Delivered', 0.00),
(21, 245, 2, 0.00, 'Pending', 0.00);

-- Order ID 246
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 246, 1, 0.00, 'Shipped', 0.00),
(40, 246, 2, 0.00, 'Delivered', 0.00),
(57, 246, 4, 0.00, 'Pending', 0.00);

-- Order ID 247
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 247, 2, 0.00, 'Returned', 0.00),
(35, 247, 1, 0.00, 'Shipped', 0.00),
(56, 247, 3, 0.00, 'Pending', 0.00);

-- Order ID 248
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 248, 4, 0.00, 'Delivered', 0.00),
(82, 248, 2, 0.00, 'Returned', 0.00);

-- Order ID 249
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(23, 249, 1, 0.00, 'Pending', 0.00),
(46, 249, 3, 0.00, 'Shipped', 0.00),
(62, 249, 2, 0.00, 'Delivered', 0.00);

-- Order ID 250
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 250, 2, 0.00, 'Returned', 0.00),
(33, 250, 1, 0.00, 'Shipped', 0.00),
(52, 250, 3, 0.00, 'Pending', 0.00);

-- Order ID 251
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 251, 2, 0.00, 'Shipped', 0.00),
(30, 251, 1, 0.00, 'Delivered', 0.00),
(48, 251, 3, 0.00, 'Pending', 0.00);

-- Order ID 252
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(18, 252, 1, 0.00, 'Returned', 0.00),
(35, 252, 4, 0.00, 'Shipped', 0.00),
(55, 252, 2, 0.00, 'Pending', 0.00);

-- Order ID 253
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 253, 3, 0.00, 'Delivered', 0.00),
(28, 253, 2, 0.00, 'Pending', 0.00),
(41, 253, 1, 0.00, 'Shipped', 0.00);

-- Order ID 254
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(20, 254, 2, 0.00, 'Returned', 0.00),
(32, 254, 1, 0.00, 'Delivered', 0.00),
(47, 254, 3, 0.00, 'Shipped', 0.00);

-- Order ID 255
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 255, 2, 0.00, 'Pending', 0.00),
(25, 255, 1, 0.00, 'Shipped', 0.00),
(43, 255, 4, 0.00, 'Delivered', 0.00);

-- Order ID 256
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(6, 256, 3, 0.00, 'Shipped', 0.00),
(29, 256, 2, 0.00, 'Pending', 0.00),
(44, 256, 1, 0.00, 'Delivered', 0.00);

-- Order ID 257
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 257, 1, 0.00, 'Returned', 0.00),
(34, 257, 3, 0.00, 'Shipped', 0.00),
(49, 257, 2, 0.00, 'Pending', 0.00);

-- Order ID 258
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 258, 2, 0.00, 'Delivered', 0.00),
(39, 258, 1, 0.00, 'Shipped', 0.00),
(52, 258, 3, 0.00, 'Pending', 0.00);

-- Order ID 259
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(21, 259, 2, 0.00, 'Returned', 0.00),
(37, 259, 3, 0.00, 'Shipped', 0.00),
(59, 259, 1, 0.00, 'Delivered', 0.00);

-- Order ID 260
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(5, 260, 4, 0.00, 'Pending', 0.00),
(30, 260, 2, 0.00, 'Returned', 0.00);

-- Order ID 261
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(9, 261, 1, 0.00, 'Shipped', 0.00),
(28, 261, 3, 0.00, 'Pending', 0.00),
(46, 261, 2, 0.00, 'Delivered', 0.00);

-- Order ID 262
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(10, 262, 2, 0.00, 'Returned', 0.00),
(33, 262, 1, 0.00, 'Shipped', 0.00),
(53, 262, 4, 0.00, 'Delivered', 0.00);

-- Order ID 263
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 263, 2, 0.00, 'Pending', 0.00),
(38, 263, 1, 0.00, 'Delivered', 0.00),
(50, 263, 3, 0.00, 'Shipped', 0.00);

-- Order ID 264
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 264, 3, 0.00, 'Shipped', 0.00),
(27, 264, 2, 0.00, 'Pending', 0.00),
(41, 264, 1, 0.00, 'Delivered', 0.00);

-- Order ID 265
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 265, 2, 0.00, 'Returned', 0.00),
(35, 265, 3, 0.00, 'Shipped', 0.00),
(56, 265, 1, 0.00, 'Pending', 0.00);

-- Order ID 266
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(6, 266, 2, 0.00, 'Delivered', 0.00),
(29, 266, 1, 0.00, 'Shipped', 0.00),
(45, 266, 3, 0.00, 'Pending', 0.00);

-- Order ID 267
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 267, 1, 0.00, 'Returned', 0.00),
(32, 267, 4, 0.00, 'Shipped', 0.00),
(50, 267, 2, 0.00, 'Pending', 0.00);

-- Order ID 268
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(18, 268, 2, 0.00, 'Delivered', 0.00),
(41, 268, 1, 0.00, 'Returned', 0.00),
(55, 268, 3, 0.00, 'Shipped', 0.00);

-- Order ID 269
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 269, 3, 0.00, 'Pending', 0.00),
(22, 269, 2, 0.00, 'Shipped', 0.00),
(36, 269, 1, 0.00, 'Delivered', 0.00);

-- Order ID 270
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(20, 270, 4, 0.00, 'Returned', 0.00),
(31, 270, 2, 0.00, 'Pending', 0.00);

-- Order ID 271
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 271, 1, 0.00, 'Shipped', 0.00),
(38, 271, 2, 0.00, 'Delivered', 0.00),
(55, 271, 3, 0.00, 'Pending', 0.00);

-- Order ID 272
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(9, 272, 2, 0.00, 'Returned', 0.00),
(34, 272, 1, 0.00, 'Shipped', 0.00),
(48, 272, 4, 0.00, 'Delivered', 0.00);

-- Order ID 273
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 273, 3, 0.00, 'Pending', 0.00),
(29, 273, 2, 0.00, 'Shipped', 0.00),
(44, 273, 1, 0.00, 'Delivered', 0.00);

-- Order ID 274
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 274, 2, 0.00, 'Returned', 0.00),
(30, 274, 1, 0.00, 'Shipped', 0.00),
(52, 274, 3, 0.00, 'Pending', 0.00);

-- Order ID 275
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 275, 1, 0.00, 'Delivered', 0.00),
(25, 275, 2, 0.00, 'Shipped', 0.00),
(39, 275, 4, 0.00, 'Pending', 0.00);

-- Order ID 276
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 276, 2, 0.00, 'Returned', 0.00),
(32, 276, 1, 0.00, 'Shipped', 0.00),
(50, 276, 3, 0.00, 'Pending', 0.00);

-- Order ID 277
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(10, 277, 3, 0.00, 'Delivered', 0.00),
(29, 277, 1, 0.00, 'Pending', 0.00),
(46, 277, 2, 0.00, 'Shipped', 0.00);

-- Order ID 278
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 278, 2, 0.00, 'Returned', 0.00),
(36, 278, 4, 0.00, 'Shipped', 0.00),
(51, 278, 1, 0.00, 'Pending', 0.00);

-- Order ID 279
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 279, 2, 0.00, 'Shipped', 0.00),
(28, 279, 3, 0.00, 'Delivered', 0.00),
(45, 279, 1, 0.00, 'Pending', 0.00);

-- Order ID 280
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 280, 1, 0.00, 'Returned', 0.00),
(33, 280, 2, 0.00, 'Shipped', 0.00),
(52, 280, 3, 0.00, 'Pending', 0.00);

-- Order ID 281
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(9, 281, 2, 0.00, 'Shipped', 0.00),
(27, 281, 1, 0.00, 'Delivered', 0.00),
(44, 281, 3, 0.00, 'Pending', 0.00);

-- Order ID 282
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(16, 282, 1, 0.00, 'Returned', 0.00),
(34, 282, 2, 0.00, 'Shipped', 0.00),
(53, 282, 3, 0.00, 'Delivered', 0.00);

-- Order ID 283
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 283, 2, 0.00, 'Pending', 0.00),
(30, 283, 1, 0.00, 'Shipped', 0.00),
(46, 283, 3, 0.00, 'Delivered', 0.00);

-- Order ID 284
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(5, 284, 1, 0.00, 'Returned', 0.00),
(26, 284, 2, 0.00, 'Shipped', 0.00),
(39, 284, 4, 0.00, 'Pending', 0.00);

-- Order ID 285
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(7, 285, 3, 0.00, 'Delivered', 0.00),
(21, 285, 2, 0.00, 'Pending', 0.00),
(36, 285, 1, 0.00, 'Shipped', 0.00);

-- Order ID 286
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 286, 2, 0.00, 'Shipped', 0.00),
(38, 286, 1, 0.00, 'Pending', 0.00),
(55, 286, 3, 0.00, 'Delivered', 0.00);

-- Order ID 287
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(8, 287, 1, 0.00, 'Returned', 0.00),
(24, 287, 2, 0.00, 'Shipped', 0.00),
(45, 287, 3, 0.00, 'Pending', 0.00);

-- Order ID 288
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 288, 2, 0.00, 'Delivered', 0.00),
(29, 288, 1, 0.00, 'Shipped', 0.00),
(48, 288, 4, 0.00, 'Pending', 0.00);

-- Order ID 289
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 289, 3, 0.00, 'Pending', 0.00),
(32, 289, 2, 0.00, 'Shipped', 0.00),
(54, 289, 1, 0.00, 'Delivered', 0.00);

-- Order ID 290
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 290, 1, 0.00, 'Returned', 0.00),
(33, 290, 3, 0.00, 'Shipped', 0.00),
(50, 290, 2, 0.00, 'Delivered', 0.00);

-- Order ID 291
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 291, 2, 0.00, 'Pending', 0.00),
(26, 291, 3, 0.00, 'Shipped', 0.00),
(45, 291, 1, 0.00, 'Delivered', 0.00);

-- Order ID 292
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(15, 292, 2, 0.00, 'Returned', 0.00),
(32, 292, 1, 0.00, 'Shipped', 0.00),
(53, 292, 3, 0.00, 'Pending', 0.00);

-- Order ID 293
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(6, 293, 1, 0.00, 'Delivered', 0.00),
(21, 293, 2, 0.00, 'Shipped', 0.00),
(42, 293, 3, 0.00, 'Pending', 0.00);

-- Order ID 294
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 294, 2, 0.00, 'Returned', 0.00),
(30, 294, 1, 0.00, 'Shipped', 0.00),
(46, 294, 4, 0.00, 'Delivered', 0.00);

-- Order ID 295
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(9, 295, 2, 0.00, 'Pending', 0.00),
(33, 295, 3, 0.00, 'Delivered', 0.00),
(50, 295, 1, 0.00, 'Shipped', 0.00);

-- Order ID 296
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 296, 1, 0.00, 'Shipped', 0.00),
(28, 296, 2, 0.00, 'Pending', 0.00),
(47, 296, 3, 0.00, 'Delivered', 0.00);

-- Order ID 297
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(10, 297, 2, 0.00, 'Returned', 0.00),
(31, 297, 3, 0.00, 'Shipped', 0.00),
(52, 297, 1, 0.00, 'Pending', 0.00);

-- Order ID 298
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(20, 298, 2, 0.00, 'Shipped', 0.00),
(34, 298, 1, 0.00, 'Pending', 0.00),
(45, 298, 3, 0.00, 'Delivered', 0.00);

-- Order ID 299
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(17, 299, 1, 0.00, 'Delivered', 0.00),
(39, 299, 2, 0.00, 'Pending', 0.00),
(53, 299, 3, 0.00, 'Shipped', 0.00);

-- Order ID 300
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(6, 300, 4, 0.00, 'Returned', 0.00),
(29, 300, 1, 0.00, 'Shipped', 0.00),
(44, 300, 2, 0.00, 'Delivered', 0.00);

-- Order ID 301
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 301, 3, 25.00, 'Pending', 0.00),
(45, 301, 1, 15.50, 'Shipped', 2.00);

-- Order ID 302
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(25, 302, 4, 10.00, 'Delivered', 1.00),
(38, 302, 2, 30.00, 'Returned', 0.00),
(57, 302, 1, 5.00, 'Pending', 0.00);

-- Order ID 303
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(33, 303, 3, 20.00, 'Shipped', 3.00),
(50, 303, 2, 12.75, 'Delivered', 1.00);

-- Order ID 304
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 304, 1, 22.00, 'Pending', 0.00),
(64, 304, 2, 40.00, 'Shipped', 5.00);

-- Order ID 305
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(40, 305, 5, 8.00, 'Delivered', 2.00),
(78, 305, 1, 15.00, 'Returned', 0.00);

-- Order ID 306
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(22, 306, 2, 18.50, 'Shipped', 1.00),
(55, 306, 3, 30.00, 'Pending', 2.00);

-- Order ID 307
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(11, 307, 1, 25.00, 'Delivered', 0.00),
(37, 307, 4, 20.00, 'Shipped', 3.00);

-- Order ID 308
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(15, 308, 2, 12.00, 'Returned', 0.00),
(48, 308, 1, 10.00, 'Pending', 1.00);

-- Order ID 309
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(30, 309, 3, 7.00, 'Delivered', 2.00),
(49, 309, 1, 14.00, 'Shipped', 1.00);

-- Order ID 310
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(27, 310, 4, 20.00, 'Pending', 0.00),
(52, 310, 2, 30.00, 'Returned', 3.00);

-- Order ID 311
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(18, 311, 5, 12.00, 'Shipped', 2.00),
(65, 311, 1, 22.00, 'Delivered', 0.00);

-- Order ID 312
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(36, 312, 3, 17.00, 'Pending', 1.00),
(68, 312, 2, 8.00, 'Shipped', 0.00);

-- Order ID 313
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(43, 313, 1, 20.00, 'Delivered', 0.00),
(72, 313, 3, 15.00, 'Returned', 2.00);

-- Order ID 314
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(29, 314, 2, 25.00, 'Shipped', 1.00),
(56, 314, 1, 10.00, 'Pending', 0.00);

-- Order ID 315
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 315, 4, 18.00, 'Delivered', 0.00),
(47, 315, 2, 22.00, 'Shipped', 3.00);

-- Order ID 316
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(21, 316, 3, 14.00, 'Returned', 2.00),
(66, 316, 1, 11.00, 'Pending', 0.00);

-- Order ID 317
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(31, 317, 2, 30.00, 'Shipped', 1.00),
(53, 317, 4, 20.00, 'Delivered', 3.00);

-- Order ID 318
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(24, 318, 5, 12.50, 'Pending', 0.00),
(71, 318, 1, 19.00, 'Shipped', 2.00);

-- Order ID 319
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(26, 319, 2, 15.00, 'Delivered', 0.00),
(44, 319, 3, 25.00, 'Returned', 3.00);

-- Order ID 320
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 320, 1, 22.00, 'Shipped', 2.00),
(57, 320, 2, 17.00, 'Pending', 0.00);

-- Order ID 321
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(34, 321, 4, 10.00, 'Returned', 1.00),
(62, 321, 1, 24.00, 'Delivered', 0.00);

-- Order ID 322
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(20, 322, 2, 25.00, 'Shipped', 3.00),
(60, 322, 1, 13.00, 'Pending', 0.00);

-- Order ID 323
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(39, 323, 3, 14.00, 'Delivered', 2.00),
(67, 323, 2, 19.00, 'Shipped', 1.00);

-- Order ID 324
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(28, 324, 4, 18.00, 'Returned', 0.00),
(46, 324, 1, 22.00, 'Pending', 2.00);

-- Order ID 325
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(16, 325, 2, 20.00, 'Shipped', 1.00),
(54, 325, 3, 15.00, 'Delivered', 3.00);

-- Order ID 326
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(41, 326, 5, 10.00, 'Pending', 0.00),
(58, 326, 2, 12.00, 'Shipped', 1.00);

-- Order ID 327
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(23, 327, 3, 30.00, 'Returned', 2.00),
(52, 327, 1, 20.00, 'Delivered', 0.00);

-- Order ID 328
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(32, 328, 4, 12.00, 'Shipped', 1.00),
(51, 328, 2, 22.00, 'Pending', 0.00);

-- Order ID 329
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(42, 329, 3, 15.00, 'Delivered', 2.00),
(68, 329, 1, 25.00, 'Shipped', 1.00);

-- Order ID 330
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(37, 330, 2, 22.00, 'Returned', 0.00),
(63, 330, 3, 30.00, 'Pending', 3.00);

-- Order ID 331
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 331, 1, 20.00, 'Shipped', 1.00),
(55, 331, 4, 15.00, 'Delivered', 2.00);

-- Order ID 332
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(46, 332, 3, 18.00, 'Pending', 0.00),
(64, 332, 1, 22.00, 'Shipped', 1.00);

-- Order ID 333
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 333, 2, 20.00, 'Delivered', 2.00),
(56, 333, 3, 14.00, 'Shipped', 1.00);

-- Order ID 334
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(24, 334, 1, 30.00, 'Returned', 0.00),
(49, 334, 2, 22.00, 'Pending', 3.00);

-- Order ID 335
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(28, 335, 3, 18.00, 'Shipped', 2.00),
(42, 335, 2, 20.00, 'Delivered', 1.00);

-- Order ID 336
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(13, 336, 4, 22.00, 'Pending', 0.00),
(58, 336, 1, 15.00, 'Shipped', 3.00);

-- Order ID 337
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(35, 337, 2, 12.00, 'Delivered', 0.00),
(47, 337, 3, 18.00, 'Returned', 1.00);

-- Order ID 338
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(21, 338, 4, 20.00, 'Shipped', 2.00),
(59, 338, 2, 22.00, 'Pending', 1.00);

-- Order ID 339
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(33, 339, 1, 18.00, 'Delivered', 0.00),
(62, 339, 3, 12.00, 'Shipped', 2.00);

-- Order ID 340
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(14, 340, 2, 25.00, 'Pending', 0.00),
(60, 340, 1, 15.00, 'Delivered', 1.00);

-- Order ID 341
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(29, 341, 4, 10.00, 'Shipped', 3.00),
(52, 341, 2, 22.00, 'Pending', 0.00);

-- Order ID 342
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(18, 342, 3, 12.00, 'Delivered', 2.00),
(43, 342, 1, 20.00, 'Shipped', 1.00);

-- Order ID 343
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(25, 343, 2, 22.00, 'Pending', 0.00),
(54, 343, 3, 15.00, 'Delivered', 3.00);

-- Order ID 344
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(37, 344, 1, 20.00, 'Shipped', 2.00),
(66, 344, 4, 10.00, 'Returned', 1.00);

-- Order ID 345
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(31, 345, 2, 25.00, 'Delivered', 0.00),
(59, 345, 3, 18.00, 'Shipped', 2.00);

-- Order ID 346
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(12, 346, 4, 22.00, 'Pending', 1.00),
(68, 346, 2, 17.00, 'Delivered', 0.00);

-- Order ID 347
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(33, 347, 1, 30.00, 'Returned', 0.00),
(45, 347, 3, 15.00, 'Shipped', 1.00);

-- Order ID 348
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(28, 348, 2, 22.00, 'Shipped', 2.00),
(57, 348, 1, 10.00, 'Delivered', 0.00);

-- Order ID 349
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(41, 349, 3, 25.00, 'Returned', 1.00),
(63, 349, 2, 18.00, 'Pending', 0.00);

-- Order ID 350
INSERT INTO OrderItem (productId, orderId, quantity, price, status, discount) VALUES
(19, 350, 2, 30.00, 'Shipped', 0.00),
(48, 350, 4, 12.00, 'Delivered', 2.00);
x

--- Rollback Instructions
--- To rollback `2024-09-12__TKT-12__Seed__Order_Items.sql`, use the following SQL:
--- DELETE FROM `ORDER_ITEM` WHERE order_id IN (SELECT id FROM `ORDER` WHERE user_id = 3);
