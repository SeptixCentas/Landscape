using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de DontDestroyOnLoadScene dans la scène");
            Destroy(instance);
            return;
        }
        else
        {
            instance = this;
            
        }



        DontDestroyOnLoad(gameObject);

        foreach (var obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }

    public static void RemoveObjectsFromDontDestroyOnLoad()
    {
        if (instance == null)
        {
            Debug.LogWarning("Aucune instance de DontDestroyOnLoadScene n'existe dans la scène");
            return;
        }

        foreach (var obj in instance.objects)
        {
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
        }

        Destroy(instance.gameObject);
    }
}
