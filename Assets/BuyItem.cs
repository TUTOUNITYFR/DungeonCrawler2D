using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public int price;

    public float speedMultiplier;
    public int hpModifier;
    public float damageMultiplier;

    public Text priceText;

    void Start()
    {
        priceText.text = price.ToString();

        if(price > PlayerBase.Instance.playerMoney.currentCoins)
        {
            priceText.color = Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && price <= PlayerBase.Instance.playerMoney.currentCoins)
        {
            PlayerBase.Instance.playerMoney.AddCoin(-price);

            if(speedMultiplier != 0)
            {
                PlayerBase.Instance.playerMovement.MultiplySpeed(speedMultiplier);
            }

            if(damageMultiplier != 0)
            {
                PlayerBase.Instance.playerAttack.MultiplyDamages(damageMultiplier);
            }

            PlayerBase.Instance.playerHealth.IncreaseMaxHealth(hpModifier);
        }
    }
}
