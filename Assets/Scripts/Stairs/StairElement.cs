﻿using System.Collections;
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
	
	private void OnEnable() {
		raiseSpeed = Random.Range(1.5f, 3f);
		endPos = new Vector3(transform.localPosition.x, endHieght, transform.localPosition.z);
		beginPos = new Vector3(transform.localPosition.x, beginHeight, transform.localPosition.z);
		this.transform.localPosition = beginPos;
	}
	
	///Starts a coroutine to lerp the position of invidual stair objects from begin position to end position.
	public void RaiseStairElement() {
		StartCoroutine(Raise());
	}
	
	private IEnumerator Raise() {
		do {
			transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, raiseSpeed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}while (this.transform.localPosition.y <= (endHieght - (endHieght /100)));
	}
}
