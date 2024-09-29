using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PrefabUIManager : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab przycisku UI, który stworzy³eœ
    public Transform contentPanel; // Panel, w którym bêd¹ umieszczane przyciski
    public string prefabFolderPath = "Assets/Resources/Prefab/MapEditorPrefabs"; // Œcie¿ka do folderu z prefabami

    private List<GameObject> loadedPrefabs = new List<GameObject>();

    void Start()
    {
        LoadPrefabsFromFolder();
        Debug.Log("1");
    }

    void LoadPrefabsFromFolder()
    {
        // Pobierz wszystkie prefaby z folderu
        Object[] prefabObjects = Resources.LoadAll(prefabFolderPath, typeof(GameObject));
        Debug.Log("2");

        foreach (Object prefab in prefabObjects)
        {
            GameObject prefabGameObject = (GameObject)prefab;
            loadedPrefabs.Add(prefabGameObject);
            CreateButtonForPrefab(prefabGameObject);
            Debug.Log("3");
        }
    }

    void CreateButtonForPrefab(GameObject prefab)
    {
        // Stwórz przycisk dla ka¿dego prefaba
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(contentPanel, false);

        // Ustaw nazwê prefab jako tekst na przycisku (opcjonalnie)
        button.GetComponentInChildren<Text>().text = prefab.name;

        // Dodaj obrazek jako ikona przycisku (jeœli masz obrazki)
        // button.GetComponent<Image>().sprite = ...;

        // Dodaj listener na przycisk, który pozwala na klikniêcie
        button.GetComponent<Button>().onClick.AddListener(() => OnPrefabButtonClick(prefab));
        Debug.Log("4");
    }

    void OnPrefabButtonClick(GameObject prefab)
    {
        // Logika po klikniêciu na przycisk prefaba
        // Mo¿esz tutaj np. aktywowaæ tryb budowania i umo¿liwiæ umieszczanie prefabów na mapie
        Debug.Log("Wybrano prefab: " + prefab.name);
        // Tutaj mo¿esz ustawiæ wybrany prefab jako aktywny do umieszczenia na mapie
        Debug.Log("5");
    }
}
