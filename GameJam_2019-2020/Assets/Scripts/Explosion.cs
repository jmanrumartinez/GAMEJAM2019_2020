using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float time = 0;

    private void Update() {
        time += Time.deltaTime;

        if (time >= 0.5f) {
            Destroy(this.gameObject); 
        }
    }

}
