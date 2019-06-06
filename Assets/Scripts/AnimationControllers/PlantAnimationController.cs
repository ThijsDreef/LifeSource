using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimationController : MonoBehaviour {
  [SerializeField]
  private Animator animator;
  private PlantRotationInteraction plantRotationInteraction;

  private void Start() {
    plantRotationInteraction = this.GetComponent<PlantRotationInteraction>();
    plantRotationInteraction.shootStart += ShootStartAnim;
    plantRotationInteraction.shootStop += ShootEndAnim;
  }

  private void ShootStartAnim() {
    animator.SetTrigger("Shoot");
    animator.SetBool("Shooting", true);
  }

  private void ShootEndAnim(){
    animator.SetBool("Shooting", false);
  }

  private void OnDestroy() {
    plantRotationInteraction.shootStart -= ShootStartAnim;
    plantRotationInteraction.shootStop -= ShootEndAnim;
  }

}


