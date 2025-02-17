using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;

    public int damage = 10;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        animator.SetTrigger("Attack");

        Vector2 attackDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach(Collider2D collider in hitColliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                Vector2 directionToEnemy = (collider.transform.position - transform.position).normalized;

                if(Vector2.Dot(attackDirection, directionToEnemy) > 0)
                {
                    // Retirer des points de vie à l'ennemi
                    Debug.Log("L'attaque a touché l'ennemi !");
                    Destroy(collider.gameObject);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
