using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    int timer;
    [SerializeField] TMP_Text incomeText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FloatAndDisappear());
    }

    IEnumerator FloatAndDisappear()
    {
        while (true)
        {
            timer++;
            transform.position += Vector3.up * 0.01f;
            if (timer > 60)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.03f);
        }
        
    }
    public void SetIncomeText(string text)
    {
        incomeText.text= text;
    }
}
