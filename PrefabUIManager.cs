using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabUIManager : MonoBehaviour
{
    public Transform contentPanel; // Panel do umieszczenia przycisków
    public string prefabFolderPath = "Prefab/MapEditorPrefabs"; // Œcie¿ka do prefabów

    private List<GameObject> loadedPrefabs = new List<GameObject>();

    void Start()
    {
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
        // Tworzenie nowego przycisku w locie
        GameObject button = new GameObject(prefab.name);
        button.AddComponent<RectTransform>();
        button.AddComponent<CanvasRenderer>();
        Button uiButton = button.AddComponent<Button>();
        button.transform.SetParent(contentPanel, false);

        SpriteRenderer prefabSpriteRenderer = prefab.GetComponent<SpriteRenderer>();
        if (prefabSpriteRenderer != null)
        {
            // Jeœli prefab ma komponent Sprite Renderer, ustaw Sprite
            Image buttonImage = button.AddComponent<Image>();
            buttonImage.sprite = prefabSpriteRenderer.sprite;
            buttonImage.preserveAspect = true; // Zachowaj proporcje obrazu
        }
        else
        {
            // Jeœli prefab nie ma komponentu Sprite Renderer, ustaw bia³y kolor i wyœwietl komunikat w logu
            Image buttonImage = button.AddComponent<Image>();
            buttonImage.color = Color.white;
            Debug.LogWarning("Prefab " + prefab.name + " nie ma komponentu Sprite Renderer.");
        }

        // Ustaw rozmiar przycisku
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 100);

        // Dodaj listener na przycisk
        uiButton.onClick.AddListener(() => OnPrefabButtonClick(prefab));
    }

    void OnPrefabButtonClick(GameObject prefab)
    {
        // Logika po klikniêciu na przycisk prefaba
        Debug.Log("Wybrano prefab: " + prefab.name);
        // Mo¿esz tutaj dodaæ logikê, aby ustawiæ wybrany prefab do umieszczenia na mapie
    }
}
