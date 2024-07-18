using UnityEngine;

public class ShopController : MonoBehaviour
{
    private bool isShopOpen = false;
    [SerializeField] RectTransform shop;
    [SerializeField] RectTransform shopSection;

    private void Start()
    {
        OnClickShop(); // This will open the shop at the start
    }

    public void OnClickShop()
    {
        if (isShopOpen)
        {
            CloseShop();
            isShopOpen = false;
        }
        else
        {
            OpenShop();
            isShopOpen = true;
        }
    }

    private void CloseShop()
    {
        shopSection.position = new Vector3(shopSection.position.x, shopSection.position.y + shop.rect.height, shopSection.position.z);
    }

    private void OpenShop()
    {
        shopSection.position = new Vector3(shopSection.position.x, shopSection.position.y - shop.rect.height, shopSection.position.z);
    }
}
