using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2.5f;
    public float jumpDuration = 1.5f;

    private bool isJumping = false;
    private float jumpTimer = 0f;
    private float startY;
    

    void Update()
    {
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