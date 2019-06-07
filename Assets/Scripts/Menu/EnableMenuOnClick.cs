using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenuOnClick : MonoBehaviour
{
	[SerializeField]
	private int menuToEnable = 0;
	private MenuHandler menuController;
	
	void Awake() {
		GameObject menuObject = GameObject.FindGameObjectWithTag("Menu");
		if (menuObject != null) menuController = menuObject.GetComponent<MenuHandler>();
	}

	void OnMouseDown() {
		if (menuController != null) menuController.ChangeMenu(menuToEnable);
	}
}
