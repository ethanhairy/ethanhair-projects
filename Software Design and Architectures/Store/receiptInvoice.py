import json
import os
from datetime import datetime
import uuid

class ReceiptInvoice:
    def createReceipt(self, userId, cartItems, total, shippingCost):
        self.userId = userId
        self.cartItems = cartItems
        self.total = total
        self.shippingCost = shippingCost

    def printReceipt(self):
        print("\n==== Receipt ====")
        print(f"User ID: {self.userId}")
        for item in self.cartItems:
            print(f"Product ID: {item['id']}, Quantity: {item['quantity']}")
        print(f"Subtotal: ${self.total:.2f}")
        print(f"Shipping: ${self.shippingCost:.2f}")
        print(f"Total: ${self.total + self.shippingCost:.2f}")
        print("=================\n")
        
    def saveTransaction(self):
        #get path directories
        dataDir = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', 'data'))
        transactionsPath = os.path.join(dataDir, 'transactions.json')
        productPath = os.path.join(dataDir, 'products.json')
        
        try: #load transactions
            with open(transactionsPath, 'r') as file:
                transactions = json.load(file)
        except (FileNotFoundError, json.JSONDecodeError):
            transactions = []

        try: #load catalogue
            with open(productPath, 'r') as f:
                catalog = json.load(f)
        except Exception:
            catalog = []

        fullProducts = []
        for item in self.cartItems:
            productInfo = next((p for p in catalog if p['id'] == item['id']), {})
            fullProducts.append({
                "id": item['id'],
                "name": productInfo.get('name', 'Unknown'),
                "category": productInfo.get('category', 'Unknown'),
                "quantity": item['quantity'],
                "price": productInfo.get('price', 0.0)
            })

        #generates new unique transaction
        newTransaction = {
            "transactionId": f"TXN{1000 + len(transactions) + 1}",
            "userId": str(self.userId),
            "products": fullProducts,
            "total": round(self.total, 2),
            "timestamp": datetime.now().strftime("%Y-%m-%dT%H:%M:%S")
        }

        #add transaction and save
        transactions.append(newTransaction)
        with open(transactionsPath, 'w') as file:
            json.dump(transactions, file, indent=2)