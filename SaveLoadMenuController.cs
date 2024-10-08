using UnityEngine;

public class SaveLoadMenuController : MonoBehaviour
{
    public GameObject saveLoadMenu;  // Panel do zapisywania/³adowania mapy
    public GameObject canvasEditor;  // Panel g³ównego edytora mapy

    void Start()
    {
        // Upewnij siê, ¿e na pocz¹tku aktywny jest edytor, a menu zapisu/³adowania jest wy³¹czone
        saveLoadMenu.SetActive(false);
        canvasEditor.SetActive(true);
    }

    // Funkcja wywo³ywana, gdy u¿ytkownik kliknie przycisk otwieraj¹cy panel zapisu/³adowania
    public void OpenSaveLoadMenu()
    {
        saveLoadMenu.SetActive(true);  // Aktywuj panel zapisu/³adowania
        canvasEditor.SetActive(false); // Dezaktywuj g³ówny edytor
    }

    // Funkcja wywo³ywana przy zamykaniu menu zapisu/³adowania
    public void CloseSaveLoadMenu()
    {
        saveLoadMenu.SetActive(false); // Ukryj panel zapisu/³adowania
        canvasEditor.SetActive(true);  // Ponownie aktywuj g³ówny edytor
    }
}
