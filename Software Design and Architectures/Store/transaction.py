from dataclasses import dataclass
from Store.product import Product
from typing import List

@dataclass
class Transaction:
    transactionId: str
    userId: str
    products: List[Product]
    price: float
    quantity: int
    timestamp: str
