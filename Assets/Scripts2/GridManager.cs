using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
        public GameObject squarePrefab;
        public int rows = 5;
        public int columns = 5;
        public float spacing = 1.1f; // Adjust the spacing between squares

        void Start()
        {
            GenerateGrid();
        }

        void GenerateGrid()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Vector3 position = new Vector3(i * spacing, 0, j * spacing);
                    Instantiate(squarePrefab, position, Quaternion.identity);
                }
            }
        }
}
