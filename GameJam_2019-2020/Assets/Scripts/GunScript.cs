using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float shotgunCooldown;
    public float assaultCooldown;

    public float shotgunBulletSpread;
    public float assaultBulletSpread;

    [SerializeField] private int shotgunBulletSpeed;
    [SerializeField] private int assaultBulletSpeed;

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

    public IEnumerator ShotgunShoot()
    {
        

        GetComponentInParent<PlayerScript>().hasShot = true;

        // do the shootie
        //Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        //Vector2 direction = target - new Vector2(transform.position.x, transform.position.y);
        

        GameObject projectile1 = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation);
        GameObject projectile2 = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation * Quaternion.Euler(1,1,shotgunBulletSpread));
        GameObject projectile3 = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation * Quaternion.Euler(1,1,-shotgunBulletSpread));

        projectile1.GetComponent<Rigidbody>().velocity += projectile1.transform.up * shotgunBulletSpeed;
        projectile2.GetComponent<Rigidbody>().velocity += projectile2.transform.up * shotgunBulletSpeed;
        projectile3.GetComponent<Rigidbody>().velocity += projectile3.transform.up * shotgunBulletSpeed;

        GetComponentInParent<Rigidbody>().velocity += -transform.parent.transform.up * shotgunBulletSpeed;
        
        yield return new WaitForSeconds(shotgunCooldown);
        GetComponentInParent<PlayerScript>().hasShot = false;

        Destroy(projectile1.gameObject);
        Destroy(projectile2.gameObject);
        Destroy(projectile3.gameObject);
    }

    public IEnumerator AssaultShoot()
    {
        GetComponentInParent<PlayerScript>().hasShot = true;

        GameObject projectile = (GameObject)Instantiate(bullet, gameObject.transform.position, gameObject.transform.parent.transform.rotation * Quaternion.Euler(1,1,Random.Range(1,assaultBulletSpread)));

        projectile.GetComponent<Rigidbody>().velocity += projectile.transform.up * shotgunBulletSpeed;

        GetComponentInParent<Rigidbody>().velocity += -transform.parent.transform.up * (assaultBulletSpeed/8);

        yield return new WaitForSeconds(assaultCooldown);

        GetComponentInParent<PlayerScript>().hasShot = false;

        Destroy(projectile.gameObject);
    }
}
