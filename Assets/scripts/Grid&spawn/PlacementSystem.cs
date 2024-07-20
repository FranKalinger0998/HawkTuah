using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndicator;
    [SerializeField] FieldPositionSelector fieldPositionSelector;
    private void Update()
    {
        Vector3 mousePosition = fieldPositionSelector.GetSelectedFieldPosition();
        //Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        //cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
