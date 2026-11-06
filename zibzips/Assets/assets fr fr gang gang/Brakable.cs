using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float durability = 3;
    [SerializeField]
    public GameObject particle;
    void OnCollisionEnter(Collision collision)
    {
       
        // kollar om skottet har taggen shot
        if (collision.gameObject.tag == "shot")
        {
            durability = -1;
   
        }
        
    }
    private void Update()
    {
        if (durability == 0)
        {
            Destroy(gameObject);
        }
    }
}
