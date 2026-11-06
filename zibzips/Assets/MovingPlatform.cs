
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float hastighet = 2f;
    public float stracka = 3f;

    private Vector3 startPosition;
    private Transform player;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // räknar ut rörelsen fram och tillbaka
        float rorelse = Mathf.PingPong(Time.time * hastighet, stracka);

        // gör så att plattformen saktar ner vid vändningen
        float smoothRorelse = Mathf.SmoothStep(0f, stracka, rorelse / stracka);

        // flyttar plattformen
        transform.position = startPosition + new Vector3(smoothRorelse, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // kollar om spelaren nuddar plattformen uppifrån
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D kontakt in collision.contacts)
            {
                if (kontakt.normal.y < -0.5f)
                {
                    player = collision.transform;
                    player.SetParent(transform);
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // släpper spelaren när den lämnar plattformen
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            player = null;
        }
    }
}
