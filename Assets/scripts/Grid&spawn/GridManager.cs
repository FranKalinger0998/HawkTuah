using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
        public GameObject squarePrefab;
        public int rows = 5;
        public int columns = 6;
        public float spacing = 0.1f; // Adjust the spacing between squares

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
                    Vector3 position = new Vector3(i*2-spacing, 0, j*2-spacing);
                    Instantiate(squarePrefab, position - new Vector3(6.9f,0,2.9f), Quaternion.identity);
                }
            }
        }
}
