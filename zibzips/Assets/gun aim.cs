using UnityEngine;

public class gunaim : MonoBehaviour
{
    public Transform gun;
    public Animator gunAnim;

    // Update is called once per frame
    void Update()
    {
        Vector3 musepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = musepos - gun.position;

        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();

    }
    public void Shoot()
    {
        gunAnim.SetTrigger("Shoot");
    }
}
