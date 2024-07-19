using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    private bool isShopOpen = false;
    [SerializeField] RectTransform shop;
    [SerializeField] RectTransform shopSection;
    [SerializeField] RectTransform hand;
    [SerializeField] GameObject[] shopPrefab;
    int shopLevel = 1;
    public void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        RefillShop();
        OnClickShop(); 
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
   
    public void BuyCard(GameObject card)
    {
        card.transform.SetParent(hand);
        RectTransform rect=card.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(0, 517f);
    }
    public void BuyRefillShop()
    {
        if (true)
        {
            RefillShop();
        }
    }
    public void RefillShop()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject card = Instantiate(shopPrefab[Random.Range(0, shopPrefab.Length)], shop);
            //Debug.Log(shopLevel);
            CardLamaScript cardScript = card.transform.GetChild(0).GetComponent<CardLamaScript>();
            cardScript.SetLevel(shopLevel);
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
