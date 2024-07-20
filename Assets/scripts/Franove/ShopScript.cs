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
    [SerializeField] int baseCardCost = 10;
    [SerializeField] int baseRefilCost = 30;
    [SerializeField] int baseShopUpgradeCost = 300;
    [SerializeField] GameObject[] shopPrefab;
    public int shopLevel = 1;
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

    public bool BuyCard(GameObject card, int cardLevel)
    {
        if (GameManager.Instance.TrySpendMoney(baseCardCost * cardLevel))
        {
            card.transform.SetParent(hand);
            RectTransform rect = card.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(0, 517f);
            return true;
        }
        else { return false; }
    }

    public void BuyUpgradeShop()
    {
        if(GameManager.Instance.TrySpendMoney(shopLevel * baseShopUpgradeCost))
        {
            shopLevel++;
            RefillShop();
        }
        
    }
    public void BuyRefillShop()
    {
        if (GameManager.Instance.TrySpendMoney(baseCardCost * shopLevel))
        {
            RefillShop();
        }
    }
    public void RefillShop()
    {
        RemoveShopSelection();
        for (int i = 0; i < 4; i++)
        {
            
            GameObject card = Instantiate(shopPrefab[Random.Range(0, shopPrefab.Length)], shop);
            //Debug.Log(shopLevel);
            CardLamaScript cardScript = card.transform.GetChild(0).GetComponent<CardLamaScript>();
            cardScript.SetLevel(shopLevel);
        }
    }

    private void RemoveShopSelection()
    {
        foreach(Transform transform in transform)
        {
            Destroy(transform.gameObject);
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
