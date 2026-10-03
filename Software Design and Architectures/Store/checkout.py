import os
import time
import json
from Store.product import Product
from Store.shipping import Shipping
from Store.shoppingCart import ShoppingCart
from Store.receiptInvoice import ReceiptInvoice

class Checkout:
    def __init__(self, userId, cart=None):
        self.userId = userId
        self.cart = cart if cart else ShoppingCart(userId)
        self.totalPrice = 0.0
        self.shipping = Shipping()
        self.receipt = ReceiptInvoice()

    def getCart(self):
        return self.cart.viewCart()

    def calculateTotal(self):
        self.totalPrice = 0.0
        for item in self.cart.cartItems:
            product = self.cart.getProduct(item['id'])
            if product:
                self.totalPrice += product.price * item['quantity']
        return self.totalPrice

    def printCurrentCart(self):
            print(f"\nCart for user {self.userId}:")
            print("-" * 20)
            for item in self.cart.cartItems:
                product = self.cart.getProduct(item['id'])
                if product:
                    subtotal = product.price * item['quantity']
                    print(f"{product.name} (x{item['quantity']}) - ${product.price:.2f} each | Subtotal: ${subtotal:.2f}")
            print("-" * 20)
            print(f"Total: ${self.calculateTotal():.2f}")
        
    def generateReceipt(self):
        self.receipt.createReceipt(
            self.userId,
            self.cart.viewCart(),
            self.calculateTotal(),
            self.shipping.cost
        )
        self.receipt.printReceipt()
        self.receipt.saveTransaction()

    def completeCheckout(self):
        if not self.cart.cartItems:
            print("Cart is empty. Cannot checkout.")
            return

        self.shipping.setLocation()
        self.shipping.shippingCost()
        self.shipping.shippingTime()
        total = self.calculateTotal()

        print("\nProcessing checkout...")
        self.generateReceipt()
        self.shipping.createShippingSlip()

        # Clear the cart
        self.cart.cartItems.clear()
        cartFilePath = os.path.join("Data", "carts.json")
        with open(cartFilePath, "r") as f:
            carts = json.load(f)
        for cart in carts:
            if cart["userId"] == self.userId:
                cart["products"] = []
        with open(cartFilePath, "w") as f:
            json.dump(carts, f, indent=4)
        print("Checkout complete. Cart cleared.\n")
