using Unity.VisualScripting;
using UnityEngine;

public class shot : MonoBehaviour
{
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
       
       
       
        // transform.Rotate(new Vector3(0, 0, 90 ));// savin this for later frfr
    }
}

