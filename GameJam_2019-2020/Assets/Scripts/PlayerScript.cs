﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gun;

    public int healthPnt;
    public int scorePnt;

    private float angle;

   public bool hasShot;

    public bool hasShotgun;
    public bool hasAssault;

    Vector3 mousePos;
    Vector3 myPos;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (hasShotgun)
            {
                hasShot = false;
                hasShotgun = false;
                hasAssault = true;

            }

            else if (hasAssault)
            {
                hasShot = false;
                hasShotgun = true;
                hasAssault = false;

            }
        }

        
        myPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        mousePos.x = Input.mousePosition.x - myPos.x;
        mousePos.y = Input.mousePosition.y - myPos.y;


        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90);

        //Controls, remember z = up/down   x = left/right

        if (Input.GetMouseButtonDown(0) && !hasShot && hasShotgun)
        {
            StartCoroutine(gun.GetComponent<GunScript>().ShotgunShoot());
            
        }
        else if (Input.GetMouseButton(0) && hasAssault)
        {
            StartCoroutine(gun.GetComponent<GunScript>().AssaultShoot());
        }

    }
}
