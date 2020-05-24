using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellphoneController : MonoBehaviour
{
    public GameObject cellphone;
    public GameObject homeScreen;
    public GameObject inventoryScreen;
    public GameObject contactScreen;

    public void CellphoneOnClick()
    {
        cellphone.SetActive(true);
    }

    public void CellphoneExitOnClick()
    {
        cellphone.SetActive(false);
    }

    public void InventoryOnClick()
    {
        homeScreen.SetActive(false);
        inventoryScreen.SetActive(true);
    }

    public void InventoryExitOnClick()
    {
        homeScreen.SetActive(true);
        inventoryScreen.SetActive(false);
    }

    public void ContactsOnClick()
    {
        homeScreen.SetActive(false);
        contactScreen.SetActive(true);
    }

    public void ContactExitOnClick()
    {
        homeScreen.SetActive(true);
        contactScreen.SetActive(false);
    }


}
