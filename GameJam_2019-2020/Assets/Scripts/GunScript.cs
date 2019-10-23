using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    private float coolDown;

    public GameObject bullet;

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


        GameObject projectile = (GameObject)Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        

        yield return new WaitForSeconds(coolDown);
        GetComponentInParent<PlayerScript>().hasShot = false;
    }
}
