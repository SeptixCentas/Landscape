using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthBar;
    public HealthBar healthBarScript;
    public bool isInvicible = false;
    public SpriteRenderer graphics;
    public float invincibilityFlashDelay = 0.2f;
    public float invincibleTiming = 1f;
    public float invincibleTimer = 0f;
    public Animator playerAnimator;
    public AudioClip hitSound;
    public PauseMenu pm;
    public Ennemy ennemy;


    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y  a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
        playerAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBarScript = healthBar.GetComponent<HealthBar>();
        healthBarScript.SetMaxHealth(maxHealth);
        graphics = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(500);
        }

        if (isInvicible)
        {
            invincibleTimer += Time.deltaTime;
            if(invincibleTimer >= invincibleTiming)
            {
                isInvicible = false;
                StopCoroutine(InvincibilityFlash());
                invincibleTimer = 0;
            }
        }
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        currentHealth += amount;
        healthBarScript.SetHealth(currentHealth);
    }
    public void TakeDamage(int Damage)
    {
        if (!isInvicible)
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= Damage;
            healthBarScript.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die(); // Change this line from PlayerDie() to Die()
                return;
            }

            isInvicible = true;
            StartCoroutine(InvincibilityFlash());
            playerAnimator.SetTrigger("hurt");
        }
    }


    public void Die()
    {
        playerAnimator.SetTrigger("PlayerDie");
        Debug.Log("Le joueur est éliminé");
        PlayerMovement.instance.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
        //pm.Paused();
    }

    public void Respawn()
    {

        Debug.Log("Le joueur respawn");
        PlayerMovement.instance.enabled = true;
        playerAnimator.SetTrigger("Respawn");
        currentHealth = maxHealth;
        healthBarScript.SetHealth(currentHealth);
    }


    public IEnumerator InvincibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }
}