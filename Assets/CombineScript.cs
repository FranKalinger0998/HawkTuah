using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineScript : MonoBehaviour
{
    public static CombineScript Instance;
    [SerializeField] GameObject blueLamaCard;
    [SerializeField] GameObject redLamaCard;
    [SerializeField] GameObject greenLamaCard;
    [SerializeField] GameObject goldLamaCard;

    List<Transform> blueLamaCards = new List<Transform>();
    List<Transform> redLamaCards = new List<Transform>();
    List<Transform> greenLamaCards = new List<Transform>();
    List<Transform> goldLamaCards = new List<Transform>();

    Dictionary<int, int> blueLamaLevelCount = new Dictionary<int, int>();
    Dictionary<int, int> redLamaLevelCount = new Dictionary<int, int>();
    Dictionary<int, int> greenLamaLevelCount = new Dictionary<int, int>();
    Dictionary<int, int> goldLamaLevelCount = new Dictionary<int, int>();

    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        CombineCards();
    }
    public void CombineCards()
    {
        // Reset the lists and dictionaries
        blueLamaCards = new List<Transform>();
        redLamaCards = new List<Transform>();
        greenLamaCards = new List<Transform>();
        goldLamaCards = new List<Transform>();

        blueLamaLevelCount = new Dictionary<int, int>();
        redLamaLevelCount = new Dictionary<int, int>();
        greenLamaLevelCount = new Dictionary<int, int>();
        goldLamaLevelCount = new Dictionary<int, int>();

        // Populate the lists and dictionaries
        foreach (Transform tran in transform)
        {
            CardLamaScript card = tran.GetComponent<CardLamaScript>();
            LamaType type = card.data.lamaType;
            int level = card.data.level;

            switch (type)
            {
                case LamaType.Gold:
                    goldLamaCards.Add(tran);
                    if (goldLamaLevelCount.ContainsKey(level))
                        goldLamaLevelCount[level]++;
                    else
                        goldLamaLevelCount.Add(level, 1);
                    break;

                case LamaType.Blue:
                    blueLamaCards.Add(tran);
                    if (blueLamaLevelCount.ContainsKey(level))
                        blueLamaLevelCount[level]++;
                    else
                        blueLamaLevelCount.Add(level, 1);
                    break;

                case LamaType.Red:
                    redLamaCards.Add(tran);
                    if (redLamaLevelCount.ContainsKey(level))
                        redLamaLevelCount[level]++;
                    else
                        redLamaLevelCount.Add(level, 1);
                    break;

                case LamaType.Green:
                    greenLamaCards.Add(tran);
                    if (greenLamaLevelCount.ContainsKey(level))
                        greenLamaLevelCount[level]++;
                    else
                        greenLamaLevelCount.Add(level, 1);
                    break;
            }
        }

        // Check each dictionary for levels with a count of 3 or more
        DestroyAndSpawnCards(blueLamaCards, blueLamaLevelCount, blueLamaCard);
        DestroyAndSpawnCards(redLamaCards, redLamaLevelCount, redLamaCard);
        DestroyAndSpawnCards(greenLamaCards, greenLamaLevelCount, greenLamaCard);
        DestroyAndSpawnCards(goldLamaCards, goldLamaLevelCount, goldLamaCard);

        
    }

    private void DestroyAndSpawnCards(List<Transform> cards, Dictionary<int, int> levelCount, GameObject cardPrefab)
    {
        foreach (var pair in levelCount)
        {
            int level = pair.Key;
            int count = pair.Value;

            if (count >= 3)
            {
                int destroyCount = 0;

                for (int i = cards.Count - 1; i >= 0 && destroyCount < 3; i--)
                {
                    CardLamaScript card = cards[i].GetComponent<CardLamaScript>();
                    if (card.data.level == level)
                    {
                        Destroy(cards[i].gameObject);
                        destroyCount++;
                    }
                }

                // Spawn a new card with a higher level
                if (destroyCount == 3)
                {
                    SpawnNewCard(cardPrefab, level + 1);
                }
            }
        }
    }

    private void SpawnNewCard(GameObject cardPrefab, int newLevel)
    {
        GameObject newCard = Instantiate(cardPrefab, transform);
        CardLamaScript newCardScript = newCard.GetComponent<CardLamaScript>();
        newCardScript.data.level = newLevel;
    }
}