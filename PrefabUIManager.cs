using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PrefabUIManager : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab przycisku UI, kt�ry stworzy�e�
    public Transform contentPanel; // Panel, w kt�rym b�d� umieszczane przyciski
    public string prefabFolderPath = "Assets/Resources/Prefab/MapEditorPrefabs"; // �cie�ka do folderu z prefabami

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
        // Stw�rz przycisk dla ka�dego prefaba
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(contentPanel, false);

        // Ustaw nazw� prefab jako tekst na przycisku (opcjonalnie)
        button.GetComponentInChildren<Text>().text = prefab.name;

        // Dodaj obrazek jako ikona przycisku (je�li masz obrazki)
        // button.GetComponent<Image>().sprite = ...;

        // Dodaj listener na przycisk, kt�ry pozwala na klikni�cie
        button.GetComponent<Button>().onClick.AddListener(() => OnPrefabButtonClick(prefab));
        Debug.Log("4");
    }

    void OnPrefabButtonClick(GameObject prefab)
    {
        // Logika po klikni�ciu na przycisk prefaba
        // Mo�esz tutaj np. aktywowa� tryb budowania i umo�liwi� umieszczanie prefab�w na mapie
        Debug.Log("Wybrano prefab: " + prefab.name);
        // Tutaj mo�esz ustawi� wybrany prefab jako aktywny do umieszczenia na mapie
        Debug.Log("5");
    }
}
