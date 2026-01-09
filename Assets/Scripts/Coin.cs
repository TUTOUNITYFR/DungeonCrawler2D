using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            PlayerBase.Instance.playerMoney.AddCoin();
            Destroy(gameObject);
        }
    }
}
