using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    private GridManager gridManager;
    private PrefabSelector prefabSelector;

    void Start()
    {
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        prefabSelector = GetComponent<PrefabSelector>();

        if (gridManager == null || prefabSelector == null)
        {
            Debug.LogError("Nie znaleziono wymaganych skryptów GridManager lub PrefabSelector!");
        }
    }

    void Update()
    {
        if (prefabSelector.selectedPrefab != null && Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gridPosition = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));

            GameObject tile = gridManager.GetTileAtPosition(gridPosition);
            if (tile != null)
            {
                SpriteRenderer tileRenderer = tile.GetComponent<SpriteRenderer>();
                tileRenderer.sprite = prefabSelector.selectedPrefab.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}
