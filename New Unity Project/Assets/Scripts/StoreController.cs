using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StoreController : MonoBehaviour
{
    public InkTest inkInformation;
    public GameObject storeContainer;

    public TextMeshProUGUI prepackagedPriceLabel;
    public TMP_InputField prepackagedQuantity;


    public TextMeshProUGUI ingreidentsPriceLabel;
    public TMP_InputField ingredientsQuantity;

    public TextMeshProUGUI calculatedCosts;
    public TextMeshProUGUI purchaseResponseText;

    private int ingredientsPrice = 3;
    private int prepackedPrice = 5;

    public void PurchaseItems()
    {
        int ingredientsQuantityInt = Convert.ToInt32(ingredientsQuantity.text);
        int prepackagedQuantityInt = Convert.ToInt32(prepackagedQuantity.text);

        //inkInformation.CallInkFunction("PurchaseIngredients", ingredientsQuantityInt);
        //inkInformation.CallInkFunction("PurchasePrepackagedMeal", prepackagedQuantityInt);

        //inkInformation.CallInkFunction("PurchaseItems", prepackagedQuantityInt, ingredientsQuantityInt);

        if (inkInformation.CallInkPurchaseFunction(prepackagedQuantityInt, ingredientsQuantityInt))
        {
            ingredientsQuantity.text = "0";
            prepackagedQuantity.text = "0";
            calculatedCosts.text = "Total Cost: $0";
        }
        
    }

    public void CalculateCost()
    {
        int ingredientsQuantityInt = Convert.ToInt32(ingredientsQuantity.text);
        int prepackagedQuantityInt = Convert.ToInt32(prepackagedQuantity.text);


        calculatedCosts.text = "Total Cost: $" + ((ingredientsQuantityInt * ingredientsPrice) + (prepackagedQuantityInt * prepackedPrice));
    }

    public void UpdatePrices()
    {

    }

    public void UpdatePurchaseResponse(string text)
    {
        purchaseResponseText.text = text;
    }


    public void CloseStore()
    {
        storeContainer.SetActive(false);
        inkInformation.CallInkFunction("ExitStore");
    }

    public void OpenStore()
    {
        storeContainer.SetActive(true);
    }

    public void StoreState(int state)
    {
        if (state == 1)
        {
            OpenStore();
        }
        else
        {
            CloseStore();
        }
    }
}
