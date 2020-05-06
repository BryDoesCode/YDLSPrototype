=== store ===
~ location = "Convenience Store"
~ background = "convenienceStoreEveningExterior"
~ time = Evening

~ costPrepackagedMeal = 5.00
~ costFoodIngredients = 3.00

You've arrived at the convenience store.
+ [Go Inside]
You go inside. -> insideStore

+ [Go Home]
-> endofday

= insideStore
~ background = "convenienceStoreEvening"
You see rows and rows of items and a bored cashier at the register. 
+ [Shop]
~ storePrompt = true
~ purchaseResponse = "Please select your items. You have ${money}."
-> insideStore

+ [Go Home]
{ExitStore()}
-> endofday

=== function ExitStore
~ storePrompt = false


=== function PurchaseItems(prepackagedCount, ingredientsCount)
{
    - prepackagedCount < 0:
        ~ purchaseResponse = "You can't buy negative of an item. Try again. You currently have ${money}."
        ~ return false
    - ingredientsCount < 0:
        ~ purchaseResponse = "You can't buy negative of an item. Try again. You currently have ${money}."
        ~ return false
}


~ temp totalCost = (prepackagedCount * costPrepackagedMeal) + (ingredientsCount * costFoodIngredients)

{ 
    - totalCost <= money:
        ~ prepackagedMealCount += prepackagedCount
        ~ foodIngredientsCount += ingredientsCount
        ~ money -= totalCost

        ~ purchaseResponse = "Purchase Successful! You now have ${money}."
        ~ return true
      
        
    - else:
        ~purchaseResponse = "You don't have enough money to buy everything."
       ~ return false
}