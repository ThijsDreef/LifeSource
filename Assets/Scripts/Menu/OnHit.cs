using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {
    [SerializeField]
    private ParticleSystem touchParticle;
    [SerializeField]
    private GameObject touchParticleObject;
    [SerializeField]
    private RectTransform canvasRectTransform;

    private void Update() {
        //Camera.main.WorldToScreenPoint
        Vector3 hit;
        #if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR 
            if(Input.touches.Length > 0) {
                hit = new Vector3(((Input.mousePosition.x / Camera.main.pixelRect.width) - 0.5f) * canvasRectTransform.rect.width, ((Input.mousePosition.y / Camera.main.pixelRect.height) - 0.5f) * canvasRectTransform.rect.height, 0);
                touchParticleObject.transform.localPosition = hit;
                touchParticle.Play();
            }
            
        #else
            if(Input.GetMouseButtonDown(0)) {
                hit = new Vector3(((Input.mousePosition.x / Camera.main.pixelRect.width) - 0.5f) * canvasRectTransform.rect.width, ((Input.mousePosition.y / Camera.main.pixelRect.height) - 0.5f) * canvasRectTransform.rect.height, 0);
                touchParticleObject.transform.localPosition = hit;
                touchParticle.Play();
            }
        #endif

        
    }
}
