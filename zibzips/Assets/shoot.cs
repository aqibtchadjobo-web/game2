using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    public GameObject Bullet;
    [SerializeField]
    KeyCode shoot = KeyCode.F;
    [SerializeField]
    float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(shoot))
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                Instantiate(Bullet, transform.position, transform.rotation);
                timer = 0;

            }


        }

    }
}
