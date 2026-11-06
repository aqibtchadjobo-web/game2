
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float hastighet = 2f;
    public float avstånd = 3f;

    Vector3 startPosition;
    bool gårÅtHöger = true;

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
            }
        }
        else
        {
            // går tillbaka åt vänster
            transform.position += Vector3.left * hastighet * Time.deltaTime;

            if (transform.position.x <= startPosition.x - avstånd)
            {
                gårÅtHöger = true;
            }
        }
    }
}