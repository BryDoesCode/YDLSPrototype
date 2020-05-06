using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public TextMeshProUGUI prepackagedMealQuantityText;
    public TextMeshProUGUI ingredientsSetQuantityText;
    public TextMeshProUGUI moneyQuantityText;


    public void UpdatePrepackagedFoodQuantity(int quantity)
    {
        prepackagedMealQuantityText.text = quantity.ToString();
    }

    public void UpdateIngredientsSet(int quantity)
    {
        ingredientsSetQuantityText.text = quantity.ToString();
    }

    public void UpdateMoneyQuantity(float quantity)
    {
        moneyQuantityText.text = "$" + quantity.ToString();
    }
}
