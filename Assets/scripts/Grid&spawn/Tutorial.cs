using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Transform[] instructionboxPositions;
    [SerializeField] GameObject button;
    [SerializeField] TMP_Text instructionText;
    [SerializeField] string[] instructionTexts;
    int instructionCount=0;
    public void GoThroughTutorial()
    {
        button.transform.position = instructionboxPositions[instructionCount].position;
        instructionText.text = instructionTexts[instructionCount];
        instructionCount++;

    }
}
