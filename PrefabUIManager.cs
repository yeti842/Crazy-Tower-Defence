using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabUIManager : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab przycisku UI
    public Transform contentPanel; // Panel do umieszczenia przycisków
    public string prefabFolderPath = "Prefab/MapEditorPrefabs"; // Zmieniona œcie¿ka do prefabów

    private List<GameObject> loadedPrefabs = new List<GameObject>();

    void Start()
    {
        // Sprawdzamy, czy buttonPrefab i contentPanel s¹ przypisane
        if (buttonPrefab == null)
        {
            Debug.LogError("buttonPrefab nie jest przypisany!");
            return;
        }

        if (contentPanel == null)
        {
            Debug.LogError("contentPanel nie jest przypisany!");
            return;
        }

        LoadPrefabsFromFolder();
    }

    void LoadPrefabsFromFolder()
    {
        // £adowanie wszystkich prefabów z folderu w Resources
        Object[] prefabObjects = Resources.LoadAll(prefabFolderPath, typeof(GameObject));

        if (prefabObjects.Length == 0)
        {
            Debug.Log("Nie znaleziono ¿adnych prefabów w folderze: " + prefabFolderPath);
            return;
        }

        Debug.Log("Za³adowano " + prefabObjects.Length + " prefabów.");

        foreach (Object prefab in prefabObjects)
        {
            GameObject prefabGameObject = (GameObject)prefab;
            loadedPrefabs.Add(prefabGameObject);
            CreateButtonForPrefab(prefabGameObject);
        }
    }

    void CreateButtonForPrefab(GameObject prefab)
    {
        // Tworzenie przycisku dla ka¿dego prefaba
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(contentPanel, false);

        // Ustawienie nazwy prefab jako tekstu na przycisku
        Text buttonText = button.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = prefab.name;
        }

        // Dodaj listener na przycisk
        button.GetComponent<Button>().onClick.AddListener(() => OnPrefabButtonClick(prefab));
    }

    void OnPrefabButtonClick(GameObject prefab)
    {
        // Logika po klikniêciu na przycisk prefaba
        Debug.Log("Wybrano prefab: " + prefab.name);
        // Mo¿esz tutaj dodaæ logikê, aby ustawiæ wybrany prefab do umieszczenia na mapie
    }
}
