# TheShop

The idea of this refactored shop project is that there is data about customers, suppliers and articles in the database of shop.
When we want to order some article, we will first check if that article exists in our database (can we get it at all).
Articles don't have price in shop, which means that we will need to ask our suppliers every time when we want to order some article about it.
Also, we will get information about quantity in stock of that article from suppliers and we will check if that quantity is appropriate to quantity from customers will.
If all conditions are met (price of article is less than max expected price which customer will pay, and if supplier has desired quantity in the stock), order will be calculated and placed.