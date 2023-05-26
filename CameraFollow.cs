using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * 5f),
                                         Mathf.Lerp(transform.position.y, target.position.y, Time.deltaTime * 5f),
                                         transform.position.z);
    }
}
