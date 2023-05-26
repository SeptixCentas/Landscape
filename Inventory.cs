
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountText;
    public TextMeshProUGUI TimeCountText;

    public static Inventory instance;
    public float timer;
    public float timerMax = 5f;
    public GameObject Player;
    private PlayerHealth scriptHp;
        private void Start()
    {
        timer = timerMax;
    }
    public void Update()
    {
        timer -= Time.deltaTime;
        
        TimeCountText.text = Mathf.Round(timer).ToString();
        if (timer <= 0)
        {
            scriptHp = Player.GetComponent<PlayerHealth>();
            scriptHp.TakeDamage(scriptHp.maxHealth);
            scriptHp.Die();
            timer = timerMax;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y  a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        timer += count * 5f;
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
        TimeCountText.text = timer.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }


}