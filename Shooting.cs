using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public GameObject player; // Reference to the Player
    public float bulletSpeed = 10f; // Speed at which the bullet will travel
    public float fireRate = 0.5f; // Time between shots
    private float nextFireTime; // Time at which the next shot can be fired
    public Animator animator; // Reference to the Animator component


    private Rigidbody2D rb2d;

    private void Start()
    {
        // Get a reference to the Rigidbody2D component
        rb2d = GetComponent<Rigidbody2D>();
        bulletPrefab.SetActive(false);
    }

    private void Update()
    {
        // Check if it's time to fire a shot
        if (Time.time > nextFireTime)
        {
            // Check for input to fire a shot
            if (Input.GetButtonDown("Fire1"))
            {
                bulletPrefab.SetActive(true);
                animator.SetTrigger("attack");

                // Update the time at which the next shot can be fired
                nextFireTime = Time.time + fireRate;

                // Create a new bullet object
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                // Set the bullet's velocity to the direction the shooting sprite is facing
                bullet.GetComponent<Rigidbody2D>().velocity = rb2d.transform.right * bulletSpeed * player.gameObject.transform.localScale.x;
            }
            else
            {
                bulletPrefab.SetActive(false);

                {
                    if (Time.time > nextFireTime)
                    {
       
                    }
                }

            }
        }
    }
}
