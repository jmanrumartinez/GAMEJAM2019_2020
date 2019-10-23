﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject gun;

    public int healthPnt;
    public int scorePnt;

    public float angle;

    public bool hasShot;

    Vector2 mousePos;
    Vector2 myPos;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        
        myPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        mousePos.x = Input.mousePosition.x - myPos.x;
        mousePos.y = Input.mousePosition.y - myPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //Controls, remember z = up/down   x = left/right

        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasShot)
        {
            StartCoroutine(gun.GetComponent<GunScript>().Shoot());
        }

    }
}