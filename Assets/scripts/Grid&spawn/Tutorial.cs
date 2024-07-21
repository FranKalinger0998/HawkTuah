using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] TMP_Text instructionText;
    [SerializeField] string[] instructionTexts;
    [SerializeField] GameObject[] circlePositions;
    int instructionCount=0;
    public void GoThroughTutorial()
    {
        instructionText.text = instructionTexts[instructionCount];
        instructionCount++;
    }
}
