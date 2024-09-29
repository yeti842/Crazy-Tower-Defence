using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabUIManager : MonoBehaviour
{
    public Transform contentPanel; // Panel, where buttons for prefabs will be displayed
    public string prefabFolderPath = "Prefab/MapEditorPrefabs"; // Path to the folder containing prefabs
    private PrefabSelector prefabSelector;

    void Start()
    {
        prefabSelector = FindObjectOfType<PrefabSelector>(); // Automatically find PrefabSelector script
        if (prefabSelector == null)
        {
            Debug.LogError("PrefabSelector not found in the scene.");
            return;
        }

        LoadPrefabsFromFolder();
    }

    void LoadPrefabsFromFolder()
    {
        Object[] prefabObjects = Resources.LoadAll(prefabFolderPath, typeof(GameObject));

        if (prefabObjects.Length == 0)
        {
            Debug.LogError("No prefabs found in the folder: " + prefabFolderPath);
            return;
        }

        foreach (Object prefab in prefabObjects)
        {
            GameObject prefabGameObject = (GameObject)prefab;
            CreateButtonForPrefab(prefabGameObject);
        }
    }

    void CreateButtonForPrefab(GameObject prefab)
    {
        GameObject button = new GameObject(prefab.name);
        button.AddComponent<RectTransform>();
        button.AddComponent<CanvasRenderer>();
        Button uiButton = button.AddComponent<Button>();
        button.transform.SetParent(contentPanel, false);

        // Add an image to the button
        Image buttonImage = button.AddComponent<Image>();
        buttonImage.sprite = prefab.GetComponent<SpriteRenderer>().sprite;
        buttonImage.preserveAspect = true;

        // Add listener to button to select the prefab on click
        uiButton.onClick.AddListener(() => prefabSelector.SelectPrefab(prefab.name));
    }
}
