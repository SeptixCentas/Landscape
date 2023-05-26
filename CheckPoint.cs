using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector2 checkPointPosition;

    // Start is called before the first frame update
    void Start()
    {
        checkPointPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerSpawn ps))
        {
            ps.RecordNewCheckPoint(checkPointPosition);
        }

    }
}