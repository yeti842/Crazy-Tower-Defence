using System.IO;
using UnityEngine;

public class MapSaver : MonoBehaviour
{
    private GridManager gridManager;

    void Start()
    {
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        if (gridManager == null)
        {
            Debug.LogError("GridManager nie zosta³ znaleziony!");
        }
    }

    public void SaveMap(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + ".txt");
        StreamWriter writer = new StreamWriter(path);

        foreach (var tile in gridManager.grid)
        {
            Sprite sprite = tile.Value.GetComponent<SpriteRenderer>().sprite;
            writer.WriteLine(tile.Key.x + "," + tile.Key.y + "," + sprite.name);
        }

        writer.Close();
        Debug.Log("Mapa zosta³a zapisana w " + path);
    }

    public void LoadMap(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + ".txt");
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                Vector2 position = new Vector2(float.Parse(data[0]), float.Parse(data[1]));
                string spriteName = data[2];

                GameObject tile = gridManager.GetTileAtPosition(position);
                if (tile != null)
                {
                    Sprite sprite = Resources.Load<Sprite>("Prefab/MapEditorPrefabs/" + spriteName);
                    if (sprite != null)
                    {
                        tile.GetComponent<SpriteRenderer>().sprite = sprite;
                    }
                }
            }

            reader.Close();
            Debug.Log("Mapa zosta³a wczytana z " + path);
        }
        else
        {
            Debug.LogError("Plik mapy nie istnieje: " + path);
        }
    }
}
