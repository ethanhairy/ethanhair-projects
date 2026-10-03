import sys
import os
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))

import unittest
from unittest.mock import patch, mock_open
from Store.catalogue import Catalogue
from Store.product import Product
import json

# Sample product data
sampleProducts = [
    {"id": 1, "name": "Apple", "category": "Fruit", "price": 0.5, "stock": 100, "description": "Fresh apple", "rating": 4.5},
    {"id": 2, "name": "Banana", "category": "Fruit", "price": 0.3, "stock": 150, "description": "Ripe banana", "rating": 4.0},
]

class TestCatalogue(unittest.TestCase):

    @patch("builtins.open", new_callable=mock_open, read_data=json.dumps(sampleProducts))
    @patch("os.path.join", return_value="fake_path/products.json")
    def setUp(self, mockPath, mockFile): #runs before every test
        self.catalogue = Catalogue()

    def testGetAllProducts(self):
        products = self.catalogue.getAllProducts()
        self.assertEqual(len(products), 2)
        self.assertEqual(products[0].name, "Apple")

    def testFindByCategory(self):
        fruits = self.catalogue.findByCategory("Fruit")
        self.assertEqual(len(fruits), 2)

    def testFindByName(self):
        result = self.catalogue.findByName("Banana")
        self.assertEqual(len(result), 1)
        self.assertEqual(result[0].description, "Ripe banana")

    def testFindByPrice(self):
        result = self.catalogue.findByPrice(0.5)
        self.assertEqual(len(result), 1)
        self.assertEqual(result[0].name, "Apple")

    def testFindById(self):
        result = self.catalogue.findById(1)
        self.assertEqual(len(result), 1)
        self.assertEqual(result[0].name, "Apple")

    def testAddProduct(self):
        newProduct = Product(id=3, name="Orange", category="Fruit", price=0.6, stock=120, description="Juicy orange", rating="3.0")
        self.catalogue.addProduct(newProduct)
        self.assertEqual(len(self.catalogue.getAllProducts()), 3)

    def testRemoveProduct(self):
        self.catalogue.removeProduct(1)
        remaining = self.catalogue.getAllProducts()
        self.assertEqual(len(remaining), 1)
        self.assertEqual(remaining[0].id, 2)

if __name__ == "__main__":
    unittest.main()
