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
    private bool firstTouch = true;

    private void Update() {
        TouchDetection();
    }

    /// Checks if there is a input on screen and displays a particle on that position.
    private void TouchDetection() {
        Vector3 hit;
        #if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR 
            if(Input.touches.Length > 0 && firstTouch) {
                firstTouch = false;
                hit = new Vector3(((Input.mousePosition.x / Camera.main.pixelRect.width) - 0.5f) * canvasRectTransform.rect.width, ((Input.mousePosition.y / Camera.main.pixelRect.height) - 0.5f) * canvasRectTransform.rect.height, 0);
                touchParticleObject.transform.localPosition = hit;
                touchParticle.Play();
                
            }
            if(Input.touches.Length == 0) {
                firstTouch = true;
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
