using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public Text coinText;
    public int currentCoins;

    public static PlayerMoney Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("Money"))
        {
            currentCoins = PlayerPrefs.GetInt("Money");
        }

        coinText = GameObject.FindGameObjectWithTag("CoinsText").GetComponent<Text>();
        UpdateCoinsCount();
    }

    void UpdateCoinsCount()
    {
        coinText.text = currentCoins.ToString();
    }

    public void AddCoin()
    {
        currentCoins++;
        UpdateCoinsCount();
    }

}
