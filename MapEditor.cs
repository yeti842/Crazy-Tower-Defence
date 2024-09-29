using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour
{
    public GameObject grid; // Siatka powinna byæ prefabem, np. zbiór linii
    public LayerMask selectableLayer; // Warstwa obiektów, które mo¿na zaznaczyæ
    public List<GameObject> mapObjects = new List<GameObject>(); // Lista obiektów na mapie

    private GameObject selectedObject;
    private Stack<GameObject> undoStack = new Stack<GameObject>();
    private Stack<GameObject> redoStack = new Stack<GameObject>();

    void Update()
    {
        HandleSelection();
        HandleDeletion();
        HandleUndoRedo();
        HandleGridToggle();
        HandleObjectRotation();
    }

    // 1. Zaznaczanie obiektów
    void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, selectableLayer))
            {
                if (selectedObject != null)
                {
                    DeselectObject();
                }

                selectedObject = hit.collider.gameObject;
                SelectObject(selectedObject);
            }
        }
    }

    void SelectObject(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = Color.yellow;
    }

    void DeselectObject()
    {
        selectedObject.GetComponent<Renderer>().material.color = Color.white;
        selectedObject = null;
    }

    // 2. Usuwanie obiektów
    void HandleDeletion()
    {
        if (Input.GetKeyDown(KeyCode.Delete) && selectedObject != null)
        {
            AddToUndoStack(selectedObject);
            Destroy(selectedObject);
            selectedObject = null;
        }
    }

    // 3. Cofnij / Ponów
    void HandleUndoRedo()
    {
        if (Input.GetKeyDown(KeyCode.Z) && undoStack.Count > 0) // Cofnij
        {
            GameObject obj = undoStack.Pop();
            redoStack.Push(obj);
            obj.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Y) && redoStack.Count > 0) // Ponów
        {
            GameObject obj = redoStack.Pop();
            undoStack.Push(obj);
            obj.SetActive(true);
        }
    }

    void AddToUndoStack(GameObject obj)
    {
        undoStack.Push(obj);
        redoStack.Clear();
    }

    // 4. W³¹czanie/wy³¹czanie siatki
    void HandleGridToggle()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            grid.SetActive(!grid.activeSelf);
        }
    }

    // 5. Obracanie obiektów
    void HandleObjectRotation()
    {
        if (Input.GetKeyDown(KeyCode.R) && selectedObject != null)
        {
            selectedObject.transform.Rotate(0, 90, 0);
        }
    }

    // 6. Zapisywanie mapy
    public void SaveMap()
    {
        foreach (GameObject obj in mapObjects)
        {
            PlayerPrefs.SetFloat(obj.name + "_posX", obj.transform.position.x);
            PlayerPrefs.SetFloat(obj.name + "_posY", obj.transform.position.y);
            PlayerPrefs.SetFloat(obj.name + "_posZ", obj.transform.position.z);
        }
        PlayerPrefs.Save();
    }

    // 7. Wczytywanie mapy
    public void LoadMap()
    {
        foreach (GameObject obj in mapObjects)
        {
            float x = PlayerPrefs.GetFloat(obj.name + "_posX");
            float y = PlayerPrefs.GetFloat(obj.name + "_posY");
            float z = PlayerPrefs.GetFloat(obj.name + "_posZ");
            obj.transform.position = new Vector3(x, y, z);
        }
    }

    // 8. Resetowanie mapy
    public void ResetMap()
    {
        foreach (GameObject obj in mapObjects)
        {
            Destroy(obj);
        }
        mapObjects.Clear();
    }
}
