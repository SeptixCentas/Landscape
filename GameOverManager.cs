using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de GameOverManager dans la scène");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        DontDestroyOnLoadScene.RemoveObjectsFromDontDestroyOnLoad();
        gameOverUI.SetActive(true);
    }

    public void RestartButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
