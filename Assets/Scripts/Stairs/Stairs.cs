using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {
    [SerializeField]
    private StairElement[] stairs;
    [SerializeField]
    private float stairRaiseDelay;
    
    private void Start() {
        stairs = GetComponentsInChildren<StairElement>();
        EnableStairs();
    }

    private void EnableStairs(){
        StartCoroutine(StairRaise());
    }

    private IEnumerator StairRaise(){
        for (int i = 0; i < stairs.Length; i++) {
            stairs[i].RaiseStairElement();
            yield return new WaitForSeconds(stairRaiseDelay);
        }
    }
}
