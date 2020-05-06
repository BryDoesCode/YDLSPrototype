using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [Header("Apartment Sprites")]
    public Sprite apartmentMorning;
    public Sprite apartmentKitchenMorning;
    public Sprite apartmentEvening;
    public Sprite apartmentKitchenEvening;

    [Header("Work Sprites")]
    public Sprite retailWorkFront;
    public Sprite retailWorkRegister;

    [Header("Store Sprites")]
    public Sprite convenienceStoreEvening;
    public Sprite convenienceStoreEveningExterior;

    [Header("UI Components")]
    public Image backgroundImage;

    public void ChangeBackgroundImage(string imageName)
    {
        switch(imageName)
        {
            case "apartmentMorning":
                backgroundImage.sprite = apartmentMorning;
                break;
            case "apartmentKitchenMorning":
                backgroundImage.sprite = apartmentKitchenMorning;
                break;
            case "retailWorkFront":
                backgroundImage.sprite = retailWorkFront;
                break;
            case "retailWorkRegister":
                backgroundImage.sprite = retailWorkRegister;
                break;
            case "apartmentEvening":
                backgroundImage.sprite = apartmentEvening;
                break;
            case "apartmentKitchenEvening":
                backgroundImage.sprite = apartmentKitchenEvening;
                break;
            case "convenienceStoreEveningExterior":
                backgroundImage.sprite = convenienceStoreEveningExterior;
                break;
            case "convenienceStoreEvening":
                backgroundImage.sprite = convenienceStoreEvening;
                break;
            default:
                Debug.Log("Unknown Image: " + imageName);
                break;
        }
    }
}
