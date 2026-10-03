from abc import ABC, abstractmethod
import os, json

class AccountInterface(ABC):

    isLoggedIn = False

    def login(self, username: str, password: str) -> bool:
        filePath = os.path.join("Data", "users.json")
        with open(filePath, "r") as f:
            users = json.load(f)
        
        for user in users:
            if user["username"] == username and user["password"] == password:
                self.username = user["username"]
                self._password = user["password"]
                self.id = user["userId"]
                self.isLoggedIn = True
                print(f"Welcome, {self.username}!")
                return user

        print("Login failed: Incorrect username or password.")
        return False
    
    def updateDetails(self, username=None, password=None):
        filePath = os.path.join("Data", "users.json")

        with open(filePath, "r") as f:
            users = json.load(f)

        # update current class variables
        if username:
            self.username = username
        if password:
            self._password = password

        # update json file
        for user in users:
            if user["userId"] == self.id:
                if username:
                    user["username"] = username
                if password:
                    user["password"] = password
                break

        with open(filePath, "w") as f:
            json.dump(users, f, indent=4)
        print("\nUser details updated successfully.")

    #@abstractmethod
    #def logout(self) -> None:
    #    pass

    #@abstractmethod
    #def getAccountDetails(self) -> dict:
    #    pass
