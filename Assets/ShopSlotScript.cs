using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotScript : MonoBehaviour
{
    bool isBought;
    public void ShopCardClicked()
    {
        Debug.Log("Clicked");
        if (!isBought)
        {
            if(ShopController.Instance.BuyCard(transform.GetChild(0).gameObject, transform.GetChild(0).GetComponent<CardLamaScript>().data.level))
            {
                isBought = true;
            }
        }
    }
}
