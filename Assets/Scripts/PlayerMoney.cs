using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public Text coinText;
    public int currentCoins;

    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("CoinsText").GetComponent<Text>();
        UpdateCoinsCount();
    }

    void UpdateCoinsCount()
    {
        coinText.text = currentCoins.ToString();
    }

    public void AddCoin(int coinsCount = 1)
    {
        currentCoins = currentCoins + coinsCount;
        UpdateCoinsCount();
    }

}
