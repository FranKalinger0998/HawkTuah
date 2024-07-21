using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;
public enum LamaType
{
    Gold,
    Red,
    Blue,
    Green
}
[System.Serializable]
public class CardLamaData 
{
    public int level;
    public LamaType lamaType;

}
public class CardLamaScript : MonoBehaviour
{
    public CardLamaData data;
    public TMP_Text lvlText;
    public TMP_Text costText;


    // Start is called before the first frame update
    private void Awake()
    {
        SetLevel(data.level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetLevel(int level)
    {
        //Debug.Log(level);
        data.level = level;
        lvlText.text = level.ToString();
        costText.text = (level*ShopController.Instance.baseCardCost).ToString();
    }
}
