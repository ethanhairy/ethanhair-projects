from Store.catalogue import Catalogue
from Store.ui import UI
from Store.accountInterface import AccountInterface

def main():
    catalogue = Catalogue()
    catalogue.populateCatalogue()
    account = AccountInterface()

    ui = UI(catalogue=catalogue, account=account)
    ui.mainMenu()

if __name__ == "__main__":
    main()
