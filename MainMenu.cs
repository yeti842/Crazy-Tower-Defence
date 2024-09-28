using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Funkcja, kt�ra za�aduje scen� z gr�
    public void StartGame()
    {
        SceneManager.LoadScene("Game");  // Zast�p "GameScene" nazw� sceny z rozgrywk�
    }

    // Funkcja, kt�ra wy��czy gr�
    public void QuitGame()
    {
        Application.Quit();
    }
}
