class Shipping:
    def __init__(self):
        self.cost = 0.0
        self.timemin = 0
        self.timemax = 0
        self.type = "normal" #default type normal
        self.location = ""
        
    def setLocation(self):
        loc = input('Please Input Shipping Location: ')
        self.location = loc
        
    def getLocation(self):
        return self.location
        
    def shippingCost(self):
        type = input('What type of shipping?  Normal($10) or Express($20) (1/2): ')
        if type == "1":
            self.type = "normal"
            self.cost = 10
        elif type == "2":
            self.type = "express"
            self.cost = 20
        
    def shippingTime(self):
        if self.type == "express":
            self.timemin = 3
            self.timemax = 5
        elif self.type == "normal":
            self.timemin = 7
            self.timemax = 10
        
    def createShippingSlip(self):
        print("\n=== Shipping Slip ===")
        print(f"Ship to: {self.getLocation()}")
        print(f"Shipping type: {self.type}")
        print(f"Estimated delivery: {self.timemin} to {self.timemax} days")
        print("=====================\n")