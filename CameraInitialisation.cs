using UnityEngine;

public class CameraInitialisation : MonoBehaviour
{
    private GameObject Camera;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        Camera.GetComponent<CameraFollow>().target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
