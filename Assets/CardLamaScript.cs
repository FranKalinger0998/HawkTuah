using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LamaType
{
    Gold,
    White,
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
