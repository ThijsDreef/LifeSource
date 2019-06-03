using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {

    public ParticleSystem touchParticle;

    private void Update() {
        //Camera.main.WorldToScreenPoint
        Vector3 hit;
        #if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR 
            if(Input.touches.Length > 0) {
                hit = Camera.main.ViewportToWorldPoint(Input.touches[0].position);
                hit.z = 90;
                touchParticle.gameObject.transform.position = hit;
                touchParticle.Play();
            }
            
        #else
            if(Input.GetMouseButtonDown(0)) {
                print("Test");
                hit = Camera.main.ViewportToWorldPoint(Input.mousePosition);
                hit.z = 90;
                touchParticle.gameObject.transform.position = hit;
                touchParticle.Play();
            }
        #endif

        
    }
}
