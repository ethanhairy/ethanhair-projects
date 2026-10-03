import json
import os
from Store.product import Product

class Catalogue:
    def __init__(self):
        self.products = self.populateCatalogue()
        self.currentProducts = None # the products shown on the UI

    def populateCatalogue(self):
        filePath = os.path.join("Data", "products.json")
        with open(filePath, "r") as f:
            productList = json.load(f)
            self.products = [Product(**p) for p in productList]
        return self.products
    
    def displayCatalogue(self, products=None):
        self.currentProducts = products
        if products is None:
            products = self.getAllProducts()

        print("\n{:<4} {:<30} {:<10} {:<8} {:<6} {}".format(
            "id", "Name", "Category", "Price", "Stock", "Description"
        ))
        print("-" * 80)
        for p in products:
            print("{:<4} {:<30} {:<10} ${:<7.2f} {:<6} {}".format(
                p.id, p.name[:30], p.category[:10], p.price, p.stock, p.description[:40]
            ))
            
    def addProduct(self, product: Product):
        self.products.append(product)

        productFilePath = os.path.join("Data", "products.json")
        
        with open(productFilePath, "r") as f:
            productList = json.load(f)

        productList.append({
            "id": product.id,
            "name": product.name,
            "description": product.description,
            "category": product.category,
            "price": product.price,
            "rating": product.rating,
            "stock": product.stock
        })

        with open(productFilePath, "w") as f:
            json.dump(productList, f, indent=4)

    def getAllProducts(self):
        return self.products

    def findByCategory(self, category):
        return [product for product in self.products if product.category == category]

    def findByName(self, name):
        return [product for product in self.products if product.name == name]

    def findByPrice(self, price):
        return [product for product in self.products if product.price == price]

    def findById(self, productId):
        return [product for product in self.products if product.id == productId]

    def removeProduct(self, productId):
        self.products = [p for p in self.products if p.id != productId]
        productFilePath = os.path.join("Data", "products.json")

        products_data = [
            {
                "id": p.id,
                "name": p.name,
                "description": p.description,
                "category": p.category,
                "price": p.price,
                "rating": p.rating,
                "stock": p.stock
            }
            for p in self.products
        ]

        with open(productFilePath, "w") as f:
            json.dump(products_data, f, indent=4)

    def __str__(self):
        return "\n".join(str(product) for product in self.products)
