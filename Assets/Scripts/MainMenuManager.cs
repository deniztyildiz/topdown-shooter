using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // This function will be called by our Start button.
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // This function will be called by our Quit button.
    public void QuitGame()
    {
        // This line writes a message to the console so we can see it's working.
        Debug.Log("Quitting game...");

        Application.Quit();
    }
}