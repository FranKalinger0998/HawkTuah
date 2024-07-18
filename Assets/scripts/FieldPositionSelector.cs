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
                if (hit.collider.gameObject !=null)
                {
                    selectedField = hit.collider.gameObject;         
                }
            }
        }
        else 
        {
            if(selectedField != null && !isStopped)
            {
                Instantiate(prefab, selectedField.transform.position, Quaternion.identity);
                isStopped = true;
            }
            
        }

        return lastPosition;
    }
}
