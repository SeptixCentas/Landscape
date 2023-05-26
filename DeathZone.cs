using UnityEngine;

public class DeathZone : MonoBehaviour
{

    private Transform PlayerSpawn;

    private void Awake()
    {
        PlayerSpawn = GameObject.FindGameObjectWithTag("CheckPoint").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameObject.FindGameObjectWithTag("CheckPoint").transform.position;
        }
    }
}