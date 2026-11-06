
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashTime = 0.2f;

    private float dashTimeLeft;
    private int dashDirection;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (movement.isDashing == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    StartDash(-1);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    StartDash(1);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (movement.isDashing)
        {
            dashTimeLeft -= Time.fixedDeltaTime;

            rb.linearVelocity = new Vector2(
                dashDirection * dashSpeed,
                rb.linearVelocity.y
            );

            if (dashTimeLeft <= 0)
            {
                movement.isDashing = false;
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
    }

    void StartDash(int direction)
    {
        movement.isDashing = true;
        dashTimeLeft = dashTime;
        dashDirection = direction;

        spriteRenderer.flipX = (direction == -1);
    }
}
