using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnenyBulletScript : MonoBehaviour
{   private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public int damageOnCollision;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    }
    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.transform.CompareTag("Player"))
        {
            playerHealth = Col.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);

            Destroy(gameObject,0.4f);
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
    