using UnityEngine;

public class droneflyscripts : MonoBehaviour
{
    public GameObject objectToSpawn;
    [SerializeField]
    float timer = 0;// timer till spawning enemys
    [SerializeField]
    float SPEED = 3; // snabhet
    Vector3 dir = new Vector3(1, 0, 0);// move xyz
    [SerializeField]
    float leftPositionClamp = 0f;
    [SerializeField]
    float rightPositionaClamp = 0f;
    [SerializeField]
    float tim = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * SPEED * Time.deltaTime;// psitionens formel
        if (Vector3.Distance(transform.position, new Vector3(-8, transform.position.y, 0)) < leftPositionClamp)// om den är nära 0.5 är den nära nog
        {
            dir.x = 1; // byt håll basicly
        }
        else if (Vector3.Distance(transform.position, new Vector3(8, transform.position.y, 0)) < rightPositionaClamp)//samma här
        {
            dir.x = -1; // byt håll fast tvärt om
        }

        timer += Time.deltaTime;
        if (timer > tim)// tim är sifran den räknar till
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);

            timer = 0;
        }
    }
}
