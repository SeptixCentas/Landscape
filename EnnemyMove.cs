using UnityEngine;

public class EnnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int waypointIndex = 0;
    private float health = 3f; // Enemy's health
    private int damageOnCollision;
    public Animator EnnemyAnimator;
    public float timer;
    public float timerMax = 5f;
    public static EnnemyMove instance;
    private bool isDead = false;

    private void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y  a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
        transform.position = waypoints[waypointIndex].transform.position;
        EnnemyAnimator = GetComponent<Animator>();
        timer = timerMax;
    }

    private void die()
    {
        isDead = true;
        EnnemyAnimator.SetBool("Ennemy Die", true);
        Debug.Log("L'ennemie est éliminé");
        Destroy(gameObject, 1f);

    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 waypoints[waypointIndex].transform.position,
                                                 moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
            if (waypointIndex == waypoints.Length)
                waypointIndex = 0;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            die();
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);

            }
        }
    }

        


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
