import os
import json
from collections import defaultdict
from datetime import datetime
import plotext as plt


class SalesData:

    def __init__():
        return

    def fetchProductStock():
        filePath = os.path.join("Data", "products.json")
        with open(filePath, 'r') as f:
            products = json.load(f)
    
        stockDict = {
        f"Product {product['name']} (ID: {product['id']}) Has remaining stock of {product['stock']}"
        + (" - ### LOW STOCK ### " if product['stock'] < 25 else "")
        + "\n"
        for product in products
        }
        print("".join(stockDict))
        return
        
    def displayGraph():
        filePath = os.path.join("Data", "transactions.json")
        print(filePath)

        if not os.path.exists(filePath):
            print("Transaction file not found.")
            return

        with open(filePath, "r") as f:
            transactions = json.load(f)

        dailySales = defaultdict(float)
        for trn in transactions:
            timestamp = trn['timestamp']
            dateOnly = datetime.fromisoformat(timestamp).date().isoformat()
            dailySales[dateOnly] += trn['total']

        sortedDates = sorted(dailySales.keys())
        yData = [dailySales[date] for date in sortedDates]
        xData = list(range(len(sortedDates)))

        plt.clear_data()
        plt.title("Daily Sales Totals")
        plt.xlabel("Date")
        plt.ylabel("Total Sales ($)")
        plt.plot(xData, yData)

        plt.xticks(xData, sortedDates)
        plt.grid(True)
        plt.show()

    def editStockLevels():
        filePath = os.path.join("Data", "products.json")

        with open(filePath, 'r') as f:
            products = json.load(f)

        try:
            productId = int(input("Select Product ID: "))
            stockLevel = int(input("Select New Stock Amount: "))
        except ValueError:
            print("Invalid input! Please enter valid numbers.")
            return False

        isUpdated = False
        for product in products:
            if product['id'] == productId:
                product['stock'] = stockLevel
                isUpdated = True
                break

        if isUpdated:
            with open(filePath, 'w') as f:
                json.dump(products, f, indent=4)
            print(f"Stock for product ID {productId} updated to {stockLevel}.")
            return True
        else:
            print("Product ID not found!")
            return False
