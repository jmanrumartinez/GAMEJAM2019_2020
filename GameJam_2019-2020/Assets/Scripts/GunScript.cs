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

        GameObject projectile1 = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation);
        GameObject projectile2 = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation * Quaternion.Euler(1,1,20));
        GameObject projectile3 = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation * Quaternion.Euler(1,1,-20));

        projectile1.GetComponent<Rigidbody>().velocity += projectile1.transform.up * bulletSpeed;
        projectile2.GetComponent<Rigidbody>().velocity += projectile2.transform.up * bulletSpeed;
        projectile3.GetComponent<Rigidbody>().velocity += projectile3.transform.up * bulletSpeed;

        GetComponentInParent<Rigidbody>().velocity += -transform.parent.transform.up * bulletSpeed;
        
        yield return new WaitForSeconds(coolDown);
        GetComponentInParent<PlayerScript>().hasShot = false;

        Destroy(projectile1.gameObject);
        Destroy(projectile2.gameObject);
        Destroy(projectile3.gameObject);
    }
}
