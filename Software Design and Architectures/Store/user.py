from Store.accountInterface import AccountInterface
import os
import json 
from Store.shoppingCart import ShoppingCart

class User(AccountInterface):
    _instance = None

    def __new__(cls, *args, **kwargs):
        if cls._instance is None:
            cls._instance = super(User, cls).__new__(cls)
        return cls._instance

    def __init__(self, username, password, id):
        if hasattr(self, '_initialized') and self._initialized:
            return 

        self.username = username
        self._password = password
        self.id = id
        self.isLoggedIn = True
        self.cart = ShoppingCart(self.id)
        self.transactions = self.populateTransactions()
        self.registerAccount()
    
    def registerAccount(self):
        file_path = os.path.join("Data", "users.json")

        with open(file_path, "r") as f:
            users = json.load(f)

        for user in users:
            if user["userId"] == self.id or user['username'] == self.username:
                return
        
        new_user = {
            "userId": self.id,
            "username": self.username,
            "password": self._password,
            "type": "user"
        }
        users.append(new_user)

        # Write back to the JSON file
        with open(file_path, "w") as f:
            json.dump(users, f, indent=4)  

    def logout(self):
        self.username = None
        self._password = None
        self.id = None
        self.isLoggedIn = False
        self.transactions = []

    def populateTransactions(self):
        temp = []

        file_path = os.path.join("Data", "transactions.json")
        with open(file_path, "r") as f:
            transactions = json.load(f)
        
        for transaction in transactions:
            if transaction['userId'] == self.id:
                temp.append(transaction)
        
        return temp

    def getAccountDetails(self):
        return {
            "id": self.id,
            "username": self.username,
        }
