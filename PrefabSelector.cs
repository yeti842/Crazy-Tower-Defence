using UnityEngine;

public class PrefabSelector : MonoBehaviour
{
    public GameObject selectedPrefab;
    public GameObject previewInstance;

    void Update()
    {
        if (selectedPrefab != null)
        {
            if (previewInstance == null)
            {
                // Create a preview instance for the selected prefab
                previewInstance = new GameObject("PreviewInstance");
                SpriteRenderer renderer = previewInstance.AddComponent<SpriteRenderer>();
                renderer.sprite = selectedPrefab.GetComponent<SpriteRenderer>().sprite;
                renderer.color = new Color(1, 1, 1, 0.5f); // Semi-transparent preview
            }

            // Update preview position to follow the mouse cursor
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            previewInstance.transform.position = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));

            // Cancel selection with the right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(previewInstance);
                selectedPrefab = null;
            }
        }
    }

    // Method called by PrefabUIManager when a prefab button is clicked
    public void SelectPrefab(string prefabName)
    {
        selectedPrefab = Resources.Load<GameObject>("Prefab/MapEditorPrefabs/" + prefabName);
        if (selectedPrefab == null)
        {
            Debug.LogError("Prefab " + prefabName + " not found in the Resources folder.");
        }
        else
        {
            if (previewInstance != null)
            {
                Destroy(previewInstance);
            }
        }
    }
}
