using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10; // szeroko�� siatki
    public int height = 10; // wysoko�� siatki
    public float cellSize = 1f; // rozmiar kom�rki

    public Dictionary<Vector2, GameObject> grid = new Dictionary<Vector2, GameObject>();

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        // Automatyczne �adowanie prefabu "BasicSquare" z Resources
        GameObject basicSquarePrefab = Resources.Load<GameObject>("Prefab/MapEditorPrefabs/BasicSquare");

        if (basicSquarePrefab == null)
        {
            Debug.LogError("Prefab 'BasicSquare' nie zosta� znaleziony w folderze Resources.");
            return;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 position = new Vector2(x * cellSize, y * cellSize);
                GameObject terrainTile = Instantiate(basicSquarePrefab, position, Quaternion.identity);
                terrainTile.transform.SetParent(transform);
                grid[position] = terrainTile;
            }
        }
    }

    public GameObject GetTileAtPosition(Vector2 position)
    {
        if (grid.ContainsKey(position))
        {
            return grid[position];
        }
        return null;
    }
}
