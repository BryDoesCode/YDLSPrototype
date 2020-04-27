using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public Sprite apartmentMorning;
    public Sprite apartmentKitchenMorning;
    public Sprite retailWork;
    public Sprite apartmentEvening;
    public Sprite apartmentKitchenEvening;

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
            case "retailWork":
                backgroundImage.sprite = retailWork;
                break;
            case "apartmentEvening":
                backgroundImage.sprite = apartmentEvening;
                break;
            case "apartmentKitchenEvening":
                backgroundImage.sprite = apartmentKitchenEvening;
                break;
            default:
                Debug.Log("Unknown Image: " + imageName);
                break;
        }
    }
}
