using UnityEngine;

public class TouchAndHold : MonoBehaviour
{
    private TouchAndHoldDetector touchAndHoldDetector;

    [SerializeField] Camera sceneCamera;
    [SerializeField] LayerMask layermask;
    [SerializeField] GameObject GoldPrefab;
    [SerializeField] GameObject BluePrefab;
    [SerializeField] GameObject GreenPrefab;
    [SerializeField] GameObject RedPrefab;
    [SerializeField] RectTransform hand;
    




    void Start()
    {
        touchAndHoldDetector = new TouchAndHoldDetector();
        touchAndHoldDetector.OnTouchAndHold += HandleLamaTouchAndHold;
    }

    void Update()
    {
        touchAndHoldDetector.Update();
    }

    private void HandleLamaTouchAndHold(Vector2 position)
    {
        Vector3 worldPoint = sceneCamera.ScreenToWorldPoint(position);
        Ray ray = sceneCamera.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layermask))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log(hitObject.name);
            if (hitObject.CompareTag("Llama"))
            {
                LlamaScript lama = hitObject.GetComponent<LlamaScript>();

                if (lama.lamaType == LamaType.Gold)
                {
                    GameObject goldLamaCard=Instantiate(GoldPrefab,hand);
                    goldLamaCard.GetComponent<CardLamaScript>().SetLevel(lama.level);
                    Destroy(hitObject);
                }
                else if (lama.lamaType == LamaType.Red)
                {
                    GameObject redLamaCard=Instantiate(RedPrefab, hand);
                    redLamaCard.GetComponent<CardLamaScript>().SetLevel(lama.level);
                    Destroy(hitObject);
                }
                else if (lama.lamaType == LamaType.Blue)
                {
                    GameObject blueLamaCard = Instantiate(BluePrefab, hand);
                    blueLamaCard.GetComponent<CardLamaScript>().SetLevel(lama.level);
                    Destroy(hitObject);
                }
                else if (lama.lamaType == LamaType.Green)
                {
                    GameObject greenLamaCard = Instantiate(GreenPrefab, hand);
                    greenLamaCard.GetComponent<CardLamaScript>().SetLevel(lama.level);
                    Destroy(hitObject);
                }
            }
        }
            // Add your logic here for what should happen when touch and hold is detected
            Debug.Log($"Touch and hold action executed at position: {position}");
    }
}