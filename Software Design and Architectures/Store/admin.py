from Store.accountInterface import AccountInterface
import os
import json 

class Admin(AccountInterface):
    _instance = None

    def __new__(cls, *args, **kwargs):
        if cls._instance is None:
            cls._instance = super(Admin, cls).__new__(cls)
        return cls._instance

    def __init__(self, username, password, id):
        if hasattr(self, '_initialized') and self._initialized:
            return 
    
        self.username = username
        self._password = password
        self.id = id
        self.isLoggedIn = True

    def logout(self):
        self.username = None
        self._password = None
        self.id = None
        self.isLoggedIn = False