using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float coolDown;

    [SerializeField]private int bulletSpeed;

    public GameObject bullet;

    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shoot()
    {
        

        GetComponentInParent<PlayerScript>().hasShot = true;
        // do the shootie
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        Vector2 direction = target - new Vector2(transform.position.x, transform.position.y);
        //direction.Normalize();

        GameObject projectile = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation);



        projectile.GetComponent<Rigidbody>().velocity += transform.right * bulletSpeed;

        
        yield return new WaitForSeconds(coolDown);
        GetComponentInParent<PlayerScript>().hasShot = false;

        //Destroy(projectile.gameObject);
    }
}
