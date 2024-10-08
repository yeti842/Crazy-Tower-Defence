using UnityEngine;

public class SaveLoadMenuController : MonoBehaviour
{
    public GameObject saveLoadMenu;  // Panel do zapisywania/�adowania mapy
    public GameObject canvasEditor;  // Panel g��wnego edytora mapy

    void Start()
    {
        // Upewnij si�, �e na pocz�tku aktywny jest edytor, a menu zapisu/�adowania jest wy��czone
        saveLoadMenu.SetActive(false);
        canvasEditor.SetActive(true);
    }

    // Funkcja wywo�ywana, gdy u�ytkownik kliknie przycisk otwieraj�cy panel zapisu/�adowania
    public void OpenSaveLoadMenu()
    {
        saveLoadMenu.SetActive(true);  // Aktywuj panel zapisu/�adowania
        canvasEditor.SetActive(false); // Dezaktywuj g��wny edytor
    }

    // Funkcja wywo�ywana przy zamykaniu menu zapisu/�adowania
    public void CloseSaveLoadMenu()
    {
        saveLoadMenu.SetActive(false); // Ukryj panel zapisu/�adowania
        canvasEditor.SetActive(true);  // Ponownie aktywuj g��wny edytor
    }
}
