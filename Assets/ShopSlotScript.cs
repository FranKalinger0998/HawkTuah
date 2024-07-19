using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotScript : MonoBehaviour
{

    public void ShopCardClicked()
    {
        Debug.Log("Clicked");
        ShopController.Instance.BuyCard(transform.GetChild(0).gameObject);
    }
}
