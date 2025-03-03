using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public bool isAlive = true;

    public Transform healthbarUI;
    public GameObject hpPrefab;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthbarUI();
    }

    public void TakeDamage(int damage)
    {
        if(isAlive)
        {
            currentHealth -= damage;
            UpdateHealthbarUI();

            if(currentHealth <= 0)
            {
                isAlive = false;
                animator.SetTrigger("Die");
            }
        }
    }

    public void UpdateHealthbarUI()
    {
        foreach (Transform child in healthbarUI)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(hpPrefab, healthbarUI);
        }
    }

    public void DisablePlayerVisual()
    {
        spriteRenderer.enabled = false;
    }
}
