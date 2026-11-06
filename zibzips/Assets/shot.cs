using Unity.VisualScripting;
using UnityEngine;

public class shot : MonoBehaviour
{
    float timer = 0;
    [SerializeField]
    float Speed = 9f;

    float dira = 2;
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dira, 0, 0) * Speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);

            timer = 0;
        }


        // transform.Rotate(new Vector3(0, 0, 90 ));// savin this for later frfr
    }
}

