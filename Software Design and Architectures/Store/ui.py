from Store.accountInterface import AccountInterface
from Store.catalogue import Catalogue
from Store.user import User
from Store.admin import Admin
from Store.salesData import SalesData
from Store.checkout import Checkout
from Store.product import Product
import random

class UI:
    def __init__(self, catalogue: Catalogue, account: AccountInterface):
        self.catalogue = catalogue 
        self.account = account

    def mainMenu(self):
        isLoggedIn = self.account.isLoggedIn
        
        print("\nWelcome to AWE Electronics!")
        print("Select one of the following options:")
        print("1: Go to Catalogue")
        if isLoggedIn:
            print("2: Account Details")
        
        elif not isLoggedIn:
            print("2: Log in or Register Account")    
        
        if isinstance(self.account, Admin) and isLoggedIn:
            print("3: Go to Admin Statistics Menu")
            print("4: Update Catalogue")
        
        print("0: Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            self.searchCatalogueMenu()
        elif choice == "2":
            if isLoggedIn:
                self.accountDetailsMenu()
            else:
                self.accountMenu()
        elif choice == "3":
            print(f"\nWelcome to the AWS Store Admin Menu!")
            self.showStatisticsMenu()
        elif choice == "4":
            self.updateCatalogueMenu()
        elif choice == "0":
            print("Goodbye!")
        else:
            print("Invalid option. Please try again.")
            self.mainMenu()
    
    def updateCatalogueMenu(self):
        self.catalogue.displayCatalogue()

        print("\n Update Catalogue")
        print("1: Remove Product")
        print("2: Add Product")
        print("0: Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            self.removeProductMenu()
        elif choice == "2":
            self.addProductMenu()
        elif choice == "0":
            self.mainMenu()
        else:
            print("Invalid option. Please try again.")
            self.updateCatalogueMenu()
    
    def removeProductMenu(self):
        id = input("Enter product id: ")
        self.catalogue.removeProduct(int(id))
        print("removed product")
        self.updateCatalogueMenu()
    
    def addProductMenu(self):
        name = input("Enter product name: ")
        description = input("Enter product description: ")
        category = input("Enter product category: ")
        
        try:
            price = float(input("Enter product price: "))
        except ValueError:
            print("Invalid price. Setting to 0.0")
            price = 0.0

        try:
            rating = float(input("Enter product rating (0-5): "))
        except ValueError:
            print("Invalid rating. Setting to 0.0")
            rating = 0.0

        try:
            stock = int(input("Enter product stock quantity: "))
        except ValueError:
            print("Invalid stock. Setting to 0")
            stock = 0

        try:
            product_id = int(input("Enter product ID: "))
        except ValueError:
            print("Invalid ID. Setting to 0")
            product_id = 0

        product = Product(
            id=product_id,
            name=name,
            description=description,
            category=category,
            price=price,
            rating=rating,
            stock=stock
        )

        self.catalogue.addProduct(product)
        print(f"Added product {product.name} to catalogue")
        self.updateCatalogueMenu()

    def loginMenu(self):
        username = input("Enter username: ")
        password = input("Enter password: ")

        account = self.account.login(username, password)
        if account:
            if account['type'] == "user":
                self.account = User(account['username'], account['password'], account['userId'])
                print("you are now logged in as user")
            elif account['type'] == "admin":
                self.account = Admin(account['username'], account['password'], account['userId'])
                print("you are now logged in as admin")
            self.mainMenu()
        else:
            self.accountMenu()

    def updateDetailsMenu(self):
        newUsername = input("New username: ")
        newPassword = input("New password: ")
        self.account.updateDetails(newUsername, newPassword)
        print("updated account details!")
        self.mainMenu()
    
    def accountDetailsMenu(self):
        print(f"\nhi, {self.account.username}")
        print("1: Update Details")
        print("2: Log out")
        if isinstance(self.account, User):
            print("3: Transactions")
            print("4: Cart")
        print("0: Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            self.updateDetailsMenu()
        elif choice == "2":
            self.account.logout()
            self.mainMenu()
        elif isinstance(self.account, User) and choice == "3":
            self.showTransactions()
        elif isinstance(self.account, User) and choice == "4":
            self.cartMenu()
        elif choice == "0":
            self.mainMenu()
        else:
            print("Invalid option. Please try again.")
            self.accountDetailsMenu()
    
    def cartMenu(self):
        print("\n Items in Cart:")
        for item in self.account.cart.cartItems:
            itemId = item['id']
            itemQuantity = item['quantity']
            product = self.account.cart.getProduct(itemId)
            if product:
                print(f"{itemId} - {product.name} - ${product.price} - {itemQuantity}")
        
        print("\n Manage Cart")
        print("1: Update Quantity")
        print("2: Remove Item")
        print("3: Checkout")
        print("0: Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            self.updateQuantityMenu()
        elif choice == "2":
            self.removeProductCartMenu()
        elif choice == "3" and self.account.cart.cartItems:
            self.checkoutMenu()
        elif choice == "0":
            self.accountDetailsMenu()
    
    def updateQuantityMenu(self):
        productId = input("\nEnter product id: ")
        newQuantity = input("Enter new quantity: ")
        outcome = self.account.cart.updateQuantity(int(productId), int(newQuantity))
        if outcome:
            print("successfully changed quantity")
        else:
            print("could not change quantity")
        self.cartMenu()
    
    def removeProductCartMenu(self):
        productId = input("Enter product id: ")
        self.account.cart.removeProduct(int(productId))
        self.cartMenu()

    def showTransactions(self):
        transactions = self.account.transactions
        if len(transactions) == 0:
            print("\nNo Transactions for this account yet")
        else:
            print(f"\nTransactions for {self.account.username}")

        for transaction in transactions:
            date = transaction['timestamp']
            total = transaction['total']
            products = transaction['products']

            print("\n")
            print("-" * 80)
            print(f"Date: {date}")
            print("-" * 80)
            print("{:<20} {:<10} {:<10}".format("Item", "Price", "Quantity"))
            print("-" * 80)

            for product in products:
                name = product['name']
                price = product['price']
                quantity = product['quantity']  
                print("{:<20} ${:<9.2f} {:<10}".format(name, price, quantity))

            print("-" * 80)
            print("Total: ${:.2f}".format(total))
            print("=" * 80)
            print("\n")
        
        print("0: Exit")
        choice = input("Enter your choice: ")
        if choice == "0":
            self.accountDetailsMenu()

    def accountMenu(self): 
        print("\nLog in or register")
        print("1: Login")
        print("2: Register")
        print("0: Exit")

        choice = input("Enter your choice: ")

        if choice == "1":
            self.loginMenu()
        elif choice == "2":
            self.registerMenu()
        elif choice == "0":
            self.mainMenu()
        else:
            print("Invalid option. Please try again.")
            self.accountMenu()
    
    def registerMenu(self):
        username = input("\nEnter username: ")
        password = input("Enter password: ")
        confirmPassword = input("Confirm password: ")

        userId = random.randint(1000, 9999)
        if username == "" or password == "":
            print("username or password missing")
            self.accountMenu()

        if password == confirmPassword:
            self.account = User(username, password, userId)
            self.mainMenu()
        else:
            print("Passwords do not match")
            self.accountMenu()

    def searchCatalogueMenu(self):
        print("\nSearch Options:")
        print("1: Search by Category")
        print("2: Search by Name")
        print("3: Search by Price")
        print("4: Show all products")
        if self.account.isLoggedIn and self.catalogue.currentProducts is not None:
            print("5: Add product(s) to cart")
        print("0: Exit Search")

        choice = input("Choose an option: ").strip()

        if choice == "1":
            cat = input("Enter category: ")
            results = self.catalogue.findByCategory(cat)
            self.catalogue.displayCatalogue(results)
            self.searchCatalogueMenu()

        elif choice == "2":
            name = input("Enter product name: ")
            results = self.catalogue.findByName(name)
            self.catalogue.displayCatalogue(results)
            self.searchCatalogueMenu()

        elif choice == "3":
            try:
                price = float(input("Enter price: "))
                results = self.catalogue.findByPrice(price)
                self.catalogue.displayCatalogue(results)
                self.searchCatalogueMenu()
            except ValueError:
                print("Please enter a valid price.")
        
        elif choice == "4":
            self.catalogue.displayCatalogue()
            self.searchCatalogueMenu()
        
        elif choice == "5":
            products = self.catalogue.currentProducts
            for product in products:
                self.account.cart.addProduct(product.id)
                print(f"Added {product.name} to cart")
            self.searchCatalogueMenu()

        elif choice == "0":
            self.catalogue.currentProducts = None # reset currently shown products
            self.mainMenu()

        else:
            print("Invalid choice. Try again.")
            self.searchCatalogueMenu()

    def showStatisticsMenu(self):
        print("Select one of the following options:")
        print("1: Display Daily Sales Graph")
        print("2: Show Product Stock")
        print("3: Edit Stock Level")
        print("0: Exit")

        choice = input("Enter your choice: ")

        if isinstance(self.account, Admin) and choice  == "1":
            SalesData.displayGraph()
            self.showStatisticsMenu()
        elif choice == "2":
            SalesData.fetchProductStock()
            self.showStatisticsMenu()
        elif choice == "3":
            SalesData.editStockLevels()
            self.showStatisticsMenu()
        elif choice == "0":
            self.mainMenu()
        else:
            print("Invalid option. Please try again.")
            self.accountDetailsMenu()


    def checkoutMenu(self):
        print("\nProceeding to checkout...")

        checkout = Checkout(self.account.id, self.account.cart)
        checkout.cart = self.account.cart
        
        checkout.printCurrentCart()

        confirm = input("Would you like to proceed to shipping and payment? (y/n): ").lower()
        if confirm == 'y':
            checkout.completeCheckout()
            self.account.cart.cartItems.clear()
        elif confirm == "n":
            print("Checkout canceled.")
            self.cartMenu()
        else:
            print("Invalid option. Please try again.")
        
