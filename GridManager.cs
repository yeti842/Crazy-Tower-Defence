using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width; // szeroko�� siatki (ilo�� kolumn)
    public int height; // wysoko�� siatki (ilo�� wierszy)
    public float tileSize = 1.0f; // rozmiar pojedynczej kratki

    private int[,] grid; // dwuwymiarowa tablica reprezentuj�ca siatk�

    void Start()
    {
        // Inicjalizacja siatki (0 oznacza pust� kratk�)
        grid = new int[width, height];
    }

    // Rysowanie siatki w edytorze Unity, aby j� zobaczy�
    void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = GetWorldPosition(x, y);
                Gizmos.DrawWireCube(pos, new Vector3(tileSize, tileSize, 0));
            }
        }
    }

    // Przekszta�canie wsp�rz�dnych siatki na pozycj� w �wiecie gry
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0);
    }

    // Przekszta�canie wsp�rz�dnych �wiata na wsp�rz�dne siatki
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / tileSize);
        int y = Mathf.FloorToInt(worldPosition.y / tileSize);
        return new Vector2Int(x, y);
    }

    // Pr�ba umieszczenia obiektu w okre�lonej kratce
    public bool PlaceObject(Vector3 worldPosition)
    {
        Vector2Int gridPos = GetGridPosition(worldPosition);

        if (IsInBounds(gridPos) && grid[gridPos.x, gridPos.y] == 0)
        {
            // Kratka jest pusta, mo�na umie�ci� obiekt
            grid[gridPos.x, gridPos.y] = 1;
            return true;
        }
        else
        {
            // Kratka zaj�ta lub poza granicami siatki
            Debug.Log("Nie mo�na umie�ci� obiektu w tej kratce!");
            return false;
        }
    }

    // Sprawdzenie, czy wsp�rz�dne s� w granicach siatki
    private bool IsInBounds(Vector2Int gridPos)
    {
        return gridPos.x >= 0 && gridPos.x < width && gridPos.y >= 0 && gridPos.y < height;
    }
}
