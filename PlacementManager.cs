using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GridManager gridManager; // Referencja do GridManagera
    public GameObject objectToPlace; // Prefab obiektu do umieszczenia

    void Update()
    {
        // Sprawdzanie, czy klikniêto lewy przycisk myszy
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            if (gridManager.PlaceObject(mousePosition))
            {
                // Jeœli umieszczanie by³o mo¿liwe, instancjujemy obiekt
                Instantiate(objectToPlace, SnapToGrid(mousePosition), Quaternion.identity);
            }
        }
    }

    // Przekszta³canie pozycji myszy na pozycjê w œwiecie gry
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    // Zaokr¹glanie pozycji obiektu do siatki
    private Vector3 SnapToGrid(Vector3 worldPosition)
    {
        Vector2Int gridPos = gridManager.GetGridPosition(worldPosition);
        return gridManager.GetWorldPosition(gridPos.x, gridPos.y);
    }
}
