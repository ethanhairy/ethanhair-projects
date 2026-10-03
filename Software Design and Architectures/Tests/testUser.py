import sys
import os
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))

import unittest
from unittest.mock import mock_open, patch
from Store.user import User  

class TestUser(unittest.TestCase):
    def setUp(self):
        self.mockUsers = [
            {"userId": 1, "username": "existingUser", "password": "pass123", "type": "user"}
        ]
        self.mockTransactions = [
            {"userId": 99, "transactionId": 1, "details": "Test Transaction"},
            {"userId": 1, "transactionId": 2, "details": "Other Transaction"}
        ]
        self.mockCartData = [
            {
                "userId": 1,
                "products": [
                    {"id": 101, "quantity": 2}
                ]
            }
        ]
        self.mockProductData = [
            {
                "id": 101,
                "name": "Wireless Bluetooth Headphones",
                "description": "High-quality over-ear Bluetooth headphones with noise cancellation and 20-hour battery life.",
                "category": "Electronics",
                "price": 79.99,
                "rating": 4.5,
                "stock": 24
            }
        ]

    @patch("builtins.open", new_callable=mock_open)
    @patch("json.load")
    @patch("json.dump")
    def testRegisterAccountNewUser(self, mockDump, mockJsonLoad, mockFile):
        mockJsonLoad.side_effect = lambda f: self.mockUsers
        User(username="newUser", password="secret", id=99)
        self.assertEqual(len(self.mockUsers), 2)

    def testGetAccountDetails(self):
        user = User(username="testUser", password="abc", id=50)
        details = user.getAccountDetails()
        self.assertEqual(details["id"], 50)
        self.assertEqual(details["username"], "testUser")

    @patch("builtins.open", new_callable=mock_open)
    @patch("json.load")
    @patch("json.dump")
    def testUpdateDetails(self, mockDump, mockJsonLoad, mockFile):
        mockJsonLoad.side_effect = [
            self.mockCartData,   # For shopping cart
            self.mockTransactions,
            self.mockUsers,  
            self.mockUsers, 
        ]
        user = User(username="existingUser", password="pass123", id=1)
        user.updateDetails(username="updatedUser", password="newPass")
        self.assertEqual(user.username, "updatedUser")
        self.assertEqual(user._password, "newPass")
        mockDump.assert_called_once()

    def testLogout(self):
        user = User(username="testUser", password="abc", id=50)
        user.logout()
        self.assertFalse(user.isLoggedIn)
        self.assertIsNone(user.username)
        self.assertEqual(user.transactions, [])

    def tearDown(self):
        # Reset the singleton instance to avoid test interference
        User._instance = None

if __name__ == "__main__":
    unittest.main()
