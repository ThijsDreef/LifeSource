using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairElement : MonoBehaviour {
    [SerializeField]
    private float beginHeight;
    [SerializeField]
    private float endHieght;
    [SerializeField]
    private Vector3 beginPos;
    [SerializeField]
    private Vector3 endPos;
    
    [SerializeField]
    private float raiseSpeed;

    private void Start() {
        raiseSpeed = Random.Range(1f, 2f);
        endPos = new Vector3(transform.localPosition.x, endHieght, transform.localPosition.z);
        beginPos = new Vector3(transform.localPosition.x, beginHeight, transform.localPosition.z);
        this.transform.localPosition = beginPos;
        RaiseStairElement();
    }
    
    private void RaiseStairElement(){
        StartCoroutine(Raise());
    }

    private IEnumerator Raise(){
        yield return new WaitForSeconds(3f);
        do{
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, raiseSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }while(this.transform.localPosition.y <= (endHieght - (endHieght/100)));
        Debug.Log("done");
    }
}
