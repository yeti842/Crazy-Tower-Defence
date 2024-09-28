using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Funkcja, która za³aduje scenê z gr¹
    public void StartGame()
    {
        SceneManager.LoadScene("Game");  // Zast¹p "GameScene" nazw¹ sceny z rozgrywk¹
    }

    // Funkcja, która wy³¹czy grê
    public void QuitGame()
    {
        Application.Quit();
    }
}
