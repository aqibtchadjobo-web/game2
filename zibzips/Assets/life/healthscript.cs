using UnityEngine;
using UnityEngine.UI;
public class healthscript : MonoBehaviour
{
    
   public GameObject [] Hearts;
    [SerializeField]
    public int hp = 5; 
    public Image[] hearts;
    private bool dead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(hp ==0)
        {
            Destroy(Hearts[5].gameObject);
        } else if (hp == 1)
        {
            Destroy(Hearts[4].gameObject);

        }else if (hp == 2)
        {
            Destroy(Hearts[3].gameObject);

        }else if (hp == 3)
        {
            Destroy(Hearts[2].gameObject);

        } else if (hp == 4)
        {
            Destroy(Hearts[1].gameObject);

        }

    }
    public void takeDamage(int d)
    {
        hp -= d;
        
    }
}
// public Sprite sprite_5;
   // public Sprite sprite_4;
  //  public Sprite sprite_3;
  //  public Sprite sprite_2;
  //  public Sprite sprite_1;
  //  public Sprite sprite_0;