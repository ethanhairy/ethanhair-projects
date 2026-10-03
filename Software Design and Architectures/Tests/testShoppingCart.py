import sys
import os
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))

import unittest
from unittest.mock import mock_open, patch
from Store.shoppingCart import ShoppingCart
from Store.product import Product

class TestShoppingCart(unittest.TestCase):
    def setUp(self):
        self.mockCarts = [
            {"id": 101, "quantity": 2}
        ]

        self.mockProducts = [
            {"id": 101, "name": "Product A", "price": 10.0, "stock": 5, "description": "test", "rating": 2.0, "category": "test"},
            {"id": 102, "name": "Product B", "price": 20.0, "stock": 1, "description": "test", "rating": 2.0, "category": "test"}
        ]

    @patch("builtins.open", new_callable=mock_open)
    @patch("json.load")
    def testGetProduct(self, mockJsonLoad, mockFile):
        mockJsonLoad.side_effect = [
            self.mockProducts,
            self.mockProducts
        ]
        
        cart = ShoppingCart.__new__(ShoppingCart)

        product = cart.getProduct(101)
        self.assertIsNotNone(product)
        self.assertEqual(product.name, "Product A")

        product = cart.getProduct(999)
        self.assertFalse(product)

    @patch("builtins.open", new_callable=mock_open)
    @patch("json.load")
    @patch("json.dump")
    def testAddProduct(self, mock_json_dump, mock_json_load, mock_file):
        mock_json_load.return_value = [
            {
                "userId": 1,
                "products": [{"id": 101, "quantity": 1}]
            }
        ]

        cart = ShoppingCart.__new__(ShoppingCart)
        cart.userId = 1
        cart.cartItems = []
        productId = 101

        added = cart.addProduct(productId, 2)
        self.assertTrue(added)
        self.assertEqual(cart.cartItems[0]["quantity"], 2)
        self.assertEqual(cart.cartItems[0]["id"], productId)

    @patch("builtins.open", new_callable=mock_open)
    @patch("json.load")
    @patch("json.dump")
    def testRemoveProductFromCart(self, mock_json_dump, mock_json_load, mock_file):
        mock_json_load.return_value = [
            {
                "userId": 1,
                "products": [{"id": 101, "quantity": 1}]
            }
        ]

        cart = ShoppingCart.__new__(ShoppingCart)
        cart.userId = 1
        cart.cartItems = self.mockCarts

        self.assertEqual(len(cart.cartItems), 1)
        cart.removeProduct(101)
        self.assertEqual(len(cart.cartItems), 0)

    @patch("builtins.open", new_callable=mock_open)
    @patch("json.load")
    @patch("json.dump")
    def testUpdateQuantity(self, mock_json_dump, mock_json_load, mock_file):
        mock_json_load.return_value = [
            {
                "userId": 1,
                "products": [{"id": 101, "quantity": 1}]
            }
        ]
        cart = ShoppingCart.__new__(ShoppingCart)
        cart.userId = 1
        cart.cartItems = self.mockCarts.copy()

        cart.updateQuantity(101, 4)
        self.assertEqual(cart.cartItems[0]["quantity"], 4)

        cart.updateQuantity(101, 0)
        self.assertEqual(len(cart.cartItems), 0)

if __name__ == "__main__":
    unittest.main()
