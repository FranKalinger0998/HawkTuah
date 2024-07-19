using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FieldPositionSelector : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;
    Vector3 lastPosition;
    [SerializeField] LayerMask layermask;
    [SerializeField] GameObject prefab;
    bool isStopped;
    public Material material1;
    public Material material2;
    GameObject selectedField;
    public Vector3 GetSelectedFieldPosition()
    {
        if (Touchscreen.current.primaryTouch.press.IsPressed())
        {           
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPoint = sceneCamera.ScreenToWorldPoint(touchPosition);
            Ray ray = sceneCamera.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            GameObject temp;
            isStopped = false;
            if (Physics.Raycast(ray, out hit, 100, layermask))
            {
                lastPosition = hit.point;
                if (hit.collider.gameObject.CompareTag("Field"))
                {
                    if(selectedField !=hit.collider.gameObject && selectedField!=null)
                    {
                        selectedField.GetComponent<MeshRenderer>().material = material1;
                    }
                    selectedField = hit.collider.gameObject;    
                    selectedField.GetComponent<MeshRenderer>().material = material2;
                }
                else
                {         
                    selectedField = null;
                }
            }
        }
        else 
        {
            
            if (selectedField != null && !isStopped)
            {
                selectedField.GetComponent<MeshRenderer>().material = material1;
                Instantiate(prefab, selectedField.transform.position + new Vector3(0.4f,0.5f,-0.6f), prefab.transform.rotation);
                isStopped = true;
            }
            
        }

        return lastPosition;
    }
}
