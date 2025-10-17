// You must add this line to use SceneManager
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // This function will be called by our Start button.
    public void StartGame()
    {
        // "GameScene" is the name of the scene we want to load.
        // Make sure your game scene is named this, or change the text to match.
        SceneManager.LoadScene("GameScene");
    }

    // This function will be called by our Quit button.
    public void QuitGame()
    {
        // This line writes a message to the console so we can see it's working.
        Debug.Log("Quitting game...");

        // This closes the application. It only works in a built game, not in the Unity Editor.
        Application.Quit();
    }
}