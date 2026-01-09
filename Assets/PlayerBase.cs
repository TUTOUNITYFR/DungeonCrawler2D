using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public PlayerMoney playerMoney;

    public static PlayerBase Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Money", PlayerBase.Instance.playerMoney.currentCoins);
        PlayerPrefs.SetInt("Attack", PlayerBase.Instance.playerAttack.damage);
        PlayerPrefs.SetFloat("Speed", PlayerBase.Instance.playerMovement.moveSpeed);
        PlayerPrefs.SetInt("MaxHP", PlayerBase.Instance.playerHealth.maxHealth);
        PlayerPrefs.SetInt("CurrentHP", PlayerBase.Instance.playerHealth.currentHealth);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        if(PlayerPrefs.HasKey("Money"))
        {
            playerMoney.currentCoins = PlayerPrefs.GetInt("Money");
        }

        if(PlayerPrefs.HasKey("Attack"))
        {
            playerAttack.damage = PlayerPrefs.GetInt("Attack");
        }

        if(PlayerPrefs.HasKey("Speed"))
        {
            playerMovement.moveSpeed = PlayerPrefs.GetFloat("Speed");
        }

        if(PlayerPrefs.HasKey("MaxHP"))
        {
            playerHealth.maxHealth = PlayerPrefs.GetInt("MaxHP");
        }

        if(PlayerPrefs.HasKey("CurrentHP"))
        {
            playerHealth.currentHealth = PlayerPrefs.GetInt("CurrentHP");
        }

        playerHealth.UpdateHealthbarUI();
    }
}
