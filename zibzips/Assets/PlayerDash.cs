using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashTime = 0.2f;
    private float dashTimeLeft;

    private bool isDashing = false;
    private int dashDirection;  // 1 = h�ger, -1 = v�nster

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Om A h�lls ner samtidigt med E -> dasha �t v�nster
                if (Input.GetKey(KeyCode.A))
                {
                    StartDash(-1);
                }
                // Om D h�lls ner samtidigt med E -> g� �t v�nster (inte dash)
                else if (Input.GetKey(KeyCode.D))
                {
                    // G� �t v�nster (vanlig r�relse)
                    StartDash(1);
                }
                else
                {
                    // Kan l�gga till dash eller andra funktioner f�r E utan A eller D
                }
            }
        }
        else
        {
            if (dashTimeLeft > 0)
            {
                dashTimeLeft -= Time.deltaTime;
                rb.linearVelocity = new Vector2(dashDirection * dashSpeed, rb.linearVelocity.y);
            }
            else
            {
                isDashing = false;
                rb.linearVelocity = Vector2.zero; // Stanna efter dash
            }
        }
    }

    void StartDash(int direction)
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        dashDirection = direction;

        // V�nd sprite beroende p� dash riktning
        spriteRenderer.flipX = (dashDirection == -1);
    }

    void MoveLeft()
    {
        // Flytta spelaren �t v�nster lite l�ngsammare �n dash
        float moveSpeed = 5f;
        rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);

        // V�nd sprite �t v�nster
        spriteRenderer.flipX = true;
    }
}
