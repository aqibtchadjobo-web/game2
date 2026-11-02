using UnityEngine;

public class shot : MonoBehaviour
{
    [SerializeField]
    float Speed = 9f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(2, 0, 0) * Speed * Time.deltaTime;
    }
}
