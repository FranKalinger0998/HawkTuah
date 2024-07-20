using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    /*
    [SerializeField] GameObject[] instructionBoxes;
    int instructionCount = 0;
    GameObject lastInstruction;
    public void GoThroughTutorial()
    {
        if(lastInstruction != null)
        {
            Destroy(lastInstruction);
        }
        GameObject temp = Instantiate(instructionBoxes[instructionCount]);
        lastInstruction = temp;
        instructionCount++;
    }
    */
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
