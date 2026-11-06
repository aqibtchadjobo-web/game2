using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2.5f;
    public float jumpDuration = 1.5f;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer = 0f;
    private float startY;
    public float Sprint = 10;
    private Rigidbody2D rb; // Ref till v�r rigidbody2D
    private Animator animator; // Ref till vår animator 
    public bool isDashing = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // H�mta v�r Rigidbody 2D
        animator = GetComponent<Animator>(); // Hämta vår Animator
    }
    



    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Sprint;
        }
        else 
        {
            speed = 5;
        }
            // Rörelse med A och D
            float x = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = 1f;
        }

        // Vänder spriten åt vänster
        if (x == -1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Vänder spriten åt höger
        if (x == 1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Flyttar spelaren åt sidorna
        transform.position += Vector3.right * x * speed * Time.deltaTime;

        // Startar hoppet med Space
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            jumpTimer = 0f;
            startY = transform.position.y;
        }
        animator.SetBool("Jump", !isGrounded);
        // Om spelaren hoppar
        if (isJumping == true)
        {
            jumpTimer += Time.deltaTime;

            // Räknar ut hur långt hoppet har kommit
            float progress = jumpTimer / jumpDuration;

            // Gör hoppet mjukt
            float jump = Mathf.Sin(progress * Mathf.PI) * jumpHeight;

            // Flyttar spelaren upp och ner
            transform.position = new Vector3(
                transform.position.x,
                startY + jump,
                transform.position.z
            );

            // När hoppet är klart
            if (progress >= 1f)
            {
                isJumping = false;

                transform.position = new Vector3(
                    transform.position.x,
                    startY,
                    transform.position.z
                );
            }
        }
    }
}