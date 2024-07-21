using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FieldPositionSelector : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;
    Vector3 lastPosition;
    [SerializeField] LayerMask layermask;
    [SerializeField] GameObject GoldPrefab;
    [SerializeField] GameObject BluePrefab;
    [SerializeField] GameObject GreenPrefab;
    [SerializeField] GameObject RedPrefab;
    bool isStopped;
    public Material material1;
    public Material material2;
    GameObject selectedField;
    bool selectedAtLeastOnce;
    public Vector3 GetSelectedFieldPosition()
    {
        if (Touchscreen.current.primaryTouch.press.IsPressed())
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPoint = sceneCamera.ScreenToWorldPoint(touchPosition);
            Ray ray = sceneCamera.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            isStopped = false;
            if (Physics.Raycast(ray, out hit, 100, layermask))
            {
                lastPosition = hit.point;
                if (hit.collider.gameObject.CompareTag("Field"))
                {

                    if (selectedField != hit.collider.gameObject && selectedField != null)
                    {
                        selectedField.GetComponent<MeshRenderer>().material = material1;
                        selectedField.GetComponent<MeshRenderer>().enabled = false;
                    }
                    selectedField = hit.collider.gameObject;
                    selectedAtLeastOnce = true;
                    selectedField.GetComponent<MeshRenderer>().enabled = true;
                    if (selectedField.transform.childCount == 1)
                    {

                        selectedField.GetComponent<MeshRenderer>().material = material2;
                    }
                }
                else
                {
                    selectedField = null;
                }
            }
        }
        else
        {
            if (selectedAtLeastOnce)
            {
                selectedField.GetComponent<MeshRenderer>().enabled = false;
            }
            
            if (selectedField != null && !isStopped)
            {
                if (selectedField.transform.childCount != null)
                {
                    if (selectedField.transform.childCount == 0)
                    {
                        selectedField.GetComponent<MeshRenderer>().material = material1;
                        GameObject lastLamaDragged = CardContainer.Instance.lastDraggedObject;
                        if (lastLamaDragged != null)
                        {
                            CardLamaScript LamaCard = lastLamaDragged.GetComponent<CardLamaScript>();
                            if (LamaCard != null)
                            {
                                if (LamaCard.data.lamaType == LamaType.Gold)
                                {
                                    GameObject goldLama = Instantiate(GoldPrefab, selectedField.transform.position + new Vector3(0.4f, 0.1f, 0), GoldPrefab.transform.rotation, selectedField.transform);
                                    goldLama.GetComponent<LlamaScript>().level = LamaCard.data.level;

                                    CardContainer.Instance.lastDraggedObject = null;
                                    isStopped = true; // Što ovo radi ?
                                }
                                else if (LamaCard.data.lamaType == LamaType.Blue)
                                {
                                    GameObject blueLama = Instantiate(BluePrefab, selectedField.transform.position + new Vector3(0.4f, 0.1f, 0), BluePrefab.transform.rotation, selectedField.transform);
                                    //Set Lama Level equal to LamaCard.data.level;
                                    blueLama.GetComponent<LlamaScript>().level = LamaCard.data.level;
                                    CardContainer.Instance.lastDraggedObject = null;
                                    isStopped = true; // Što ovo radi ?
                                }
                                else if (LamaCard.data.lamaType == LamaType.Green)
                                {
                                    GameObject greenLama = Instantiate(GreenPrefab, selectedField.transform.position + new Vector3(0.4f, 0.1f, 0), GreenPrefab.transform.rotation, selectedField.transform);
                                    //Set Lama Level equal to LamaCard.data.level;
                                    greenLama.GetComponent<LlamaScript>().level = LamaCard.data.level;
                                    CardContainer.Instance.lastDraggedObject = null;
                                    isStopped = true; // Što ovo radi ?
                                }
                                else if (LamaCard.data.lamaType == LamaType.Red)
                                {
                                    //Debug.Log("in red");
                                    GameObject redLama = Instantiate(RedPrefab, selectedField.transform.position + new Vector3(0.4f, 0.1f, 0), RedPrefab.transform.rotation, selectedField.transform);
                                    //Set Lama Level equal to LamaCard.data.level;
                                    redLama.GetComponent<LlamaScript>().level = LamaCard.data.level;
                                    CardContainer.Instance.lastDraggedObject = null;
                                    isStopped = true; // Što ovo radi ?
                                }


                            }
                            Destroy(lastLamaDragged);

                        }

                    }
                }
                

            }
        }

        return lastPosition;
    }
}

