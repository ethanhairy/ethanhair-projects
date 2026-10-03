import json
import os
from Store.product import Product

class ShoppingCart:
    def __init__(self, userId):
        self.cartItems = self.populateCart(userId)
        self.userId = userId

    def populateCart(self, userId):
        cartFilePath = os.path.join("Data", "carts.json")

        with open(cartFilePath, "r") as f:
            carts = json.load(f)

        for cart in carts:
            if cart.get("userId") == userId:
                return [{"id": p["id"], "quantity": p["quantity"]} for p in cart.get("products", [])]

        return []

        #for cartProduct in products:
        #    prodId = cartProduct['id']
        #    quantity = cartProduct['quantity']
        #    product = self.getProduct(prodId)
        #    if product:
        #        currentCart.append({"product": product, "quantity": quantity})
        
        #return currentCart

    def getProduct(self, productId):
        productFilePath = os.path.join("Data", "products.json")

        with open(productFilePath, "r") as f:
            products = json.load(f)
        
        for product in products:
            if product['id'] == productId:
                return Product(
                    id=product['id'],
                    name=product['name'], 
                    description=product['description'], 
                    category=product['category'], 
                    price=product['price'], 
                    rating=product['rating'],
                    stock=product['stock']
                )
        return False
    
    def addProduct(self, productId, quantity=1):        
        if quantity <= 0:
            print("Quantity must be at least 1.")
            return False
        
        # if product is already in cart
        for item in self.cartItems:
            if item['id'] == productId:
                totalQuantity = item['quantity'] + quantity
                item['quantity'] = totalQuantity
        
        self.cartItems.append({"id": productId, "quantity": quantity})
    
        cartFilePath = os.path.join("Data", "carts.json")
        with open(cartFilePath, "r") as f:
            carts = json.load(f)
                
        for cart in carts:
            if cart["userId"] == self.userId:
                cart['products'] = self.cartItems
        
        with open(cartFilePath, "w") as f:
            json.dump(carts, f, indent=4)  
        return True
    
    def removeProduct(self, productId): 
        self.cartItems = [item for item in self.cartItems if item["id"] != productId]
        cartFilePath = os.path.join("Data", "carts.json")

        with open(cartFilePath, "r") as f:
            carts = json.load(f)
                
        for cart in carts:
            if cart["userId"] == self.userId:
                cart['products'] = self.cartItems

        with open(cartFilePath, "w") as f:
            json.dump(carts, f, indent=4)  
            
    def updateQuantity(self, product_id, new_quantity):
        if new_quantity <= 0:
            self.removeProduct(product_id)
            return True
        
        found = False
        for item in self.cartItems:
            if item["id"] == product_id:
                found = True
                item["quantity"] = new_quantity
        
        if not found:
            return False
                
        cartFilePath = os.path.join("Data", "carts.json")
        
        with open(cartFilePath, "r") as f:
            carts = json.load(f)
                
        for cart in carts:
            if cart["userId"] == self.userId:
                cart['products'] = self.cartItems

        with open(cartFilePath, "w") as f:
            json.dump(carts, f, indent=4) 
        
        return True
    
    # havent tested these
    def viewCart(self):
        return self.cartItems

    # def clearCart(self):
    #     self.cart_items.clear()
    #     print("Cart cleared.")

    def clearCart(self):
        self.cartItems.clear()

        cartFilePath = os.path.join("Data", "carts.json") #updates json to reflect cart being cleared
        with open(cartFilePath, "r") as f:
            carts = json.load(f)

        for cart in carts:
            if cart["userId"] == self.userId:
                cart["products"] = []

        with open(cartFilePath, "w") as f:
            json.dump(carts, f, indent=4)

        print("Cart cleared.")