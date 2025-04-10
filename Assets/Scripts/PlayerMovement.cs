using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D rigidbody;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private Vector2 movement;

    public PlayerHealth playerHealth;

    void Update()
    {
        if(playerHealth.isAlive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            movement = movement.normalized;

            animator.SetFloat("Speed", movement.sqrMagnitude);

            if(movement.x != 0)
            {
                spriteRenderer.flipX = movement.x < 0;
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = movement * moveSpeed;
    }
}