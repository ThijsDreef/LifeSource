using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public List<GameObject> menus = new List<GameObject>();
    private int activeMenuIndex;

    private void Awake() {
        ChangeMenu(0);
    }

    /// Call this to Change the menu in the array to the given number.
    public void ChangeMenu(int menuIndex) {
        for(int i = 0; i < menus.Count; i++) {
            menus[i].SetActive(false);
        }
        if(menus[menuIndex] != null) {
            menus[menuIndex].SetActive(true);
            activeMenuIndex = menuIndex;
        }
    }

    public void NextMenu() {
        if(activeMenuIndex < menus.Count) {
            ChangeMenu(activeMenuIndex++);
        }
    }
    public void PreviousMenu() {
        if(activeMenuIndex > 0) {
            ChangeMenu(activeMenuIndex--);
        }
    }
}
