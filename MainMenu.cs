using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;

    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}

