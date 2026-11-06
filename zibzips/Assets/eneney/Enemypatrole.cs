using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float hastighet = 2f;
    public float avstånd = 3f;
    public float life = 2;
    Vector3 startPosition;
    bool gårÅtHöger = true;
    FlipYTool flip;
    void Start()
    {
        // sparar fiendens startposition
        startPosition = transform.position;
    }

    void Update()
    {
        // kollar om fienden ska gå åt höger
        if (gårÅtHöger == true)
        {
            transform.position += Vector3.right * hastighet * Time.deltaTime;

            // byter riktning när fienden kommit till slutet
            if (transform.position.x >= startPosition.x + avstånd)
            {
                gårÅtHöger = false;
                if (gårÅtHöger == false)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        else
        {
            // går tillbaka åt vänster
            transform.position += Vector3.left * hastighet * Time.deltaTime;

            if (transform.position.x <= startPosition.x - avstånd)
            {
                gårÅtHöger = true;
                if (gårÅtHöger == true)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LaserShot")
        {
            print("lasser hit");
            life -= 1;
            if (life == 0)
            {
                print("me is dead");
                Destroy(gameObject);
            }
        }
        if (collision.tag == "player")
        {
            print("player hit");
        }
    }
}