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
                // Stworzenie obiektu podgl¹du dla wybranego prefaba
                previewInstance = new GameObject("PreviewInstance");
                SpriteRenderer renderer = previewInstance.AddComponent<SpriteRenderer>();
                renderer.sprite = selectedPrefab.GetComponent<SpriteRenderer>().sprite;
                renderer.color = new Color(1, 1, 1, 0.5f); // Pó³przezroczysty podgl¹d
            }

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            previewInstance.transform.position = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));

            if (Input.GetMouseButtonDown(1)) // Anulowanie prawego przycisku myszki
            {
                Destroy(previewInstance);
                selectedPrefab = null;
            }
        }
    }

    public void SelectPrefab(string prefabName)
    {
        selectedPrefab = Resources.Load<GameObject>("Prefab/MapEditorPrefabs/" + prefabName);
        if (selectedPrefab == null)
        {
            Debug.LogError("Prefab " + prefabName + " nie zosta³ znaleziony.");
        }
    }
}
