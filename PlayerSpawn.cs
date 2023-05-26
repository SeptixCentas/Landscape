using UnityEngine;

public class PlayerSpawn : MonoBehaviour

{
    private Vector2 lastCheckPointPosition;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        RecordNewCheckPoint(transform.position);
    }
    
    public void RespawnToLastCheckPointPosition()
    {
        transform.position =lastCheckPointPosition;
        animator.SetTrigger("Respawn");
    }
    public void RecordNewCheckPoint(Vector2 newPosition)
    {
        lastCheckPointPosition = newPosition;
    }
}