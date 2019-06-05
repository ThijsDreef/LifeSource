using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ThirdPersonCharacter : MonoBehaviour {
	[SerializeField] 
	private float movingTurnSpeed = 360;
	[SerializeField] 
	private float stationaryTurnSpeed = 180;
	[SerializeField] 
	private float jumpPower = 6f;
	[Range(1f, 4f)][SerializeField] 
	private float gravityMultiplier = 2f;
	[SerializeField] 
	private float runCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
	[SerializeField] 
	private float animSpeedMultiplier = 1f;
	[SerializeField]
	private float groundCheckDistance = 0.2f;

	private Rigidbody playerRigidbody;
	private Animator animator;
	[SerializeField]
	private Animator wingAnimtor;
	private bool isGrounded;
	private	float startOriginGroundCheckDistance;
	private const float charachterHalf = 0.5f;
	private float turnAmount;
	private float forwardAmount;
	private Vector3 groundNormal;
	private float capsuleHeight;
	private Vector3 capsuleCenter;
	private CapsuleCollider capsuleCollider;
	private bool crouching;

	private Vector3 oldPosition;


	[SerializeField]
	private Transform ImageTarget;


	private void Start() {
		animator = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		capsuleCollider = GetComponent<CapsuleCollider>();
		capsuleHeight = capsuleCollider.height;
		capsuleCenter = capsuleCollider.center;
		playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		startOriginGroundCheckDistance = groundCheckDistance;
		oldPosition = ImageTarget.transform.position;
		animator.applyRootMotion = true;
	}

	/// moves the character based on root motion
	public void Move(Vector3 move, bool crouch, bool jump) {
		if(!animator.applyRootMotion){
			animator.applyRootMotion = true;
			playerRigidbody.isKinematic = false;
		}
		// convert the world relative moveInput vector into a local-relative
		// turn amount and forward amount required to head in the desired
		// direction.
		if (move.magnitude > 1f) move.Normalize();
		move = transform.InverseTransformDirection(move);
		CheckGroundStatus();
		move = Vector3.ProjectOnPlane(move, groundNormal);
		turnAmount = Mathf.Atan2(move.x, move.z);
		forwardAmount = move.z;

		ApplyExtraTurnRotation();
		
		// send input and other state parameters to the animator
		UpdateAnimator(move);
	}

	public void FlyUpAnimation(){
		playerRigidbody.isKinematic = true;
		animator.applyRootMotion = false;
		animator.SetBool("Landing", false);
		animator.SetTrigger("FlyUp");
		wingAnimtor.SetTrigger("FlyUp");
	}

	public void LandAnimation(){
		playerRigidbody.isKinematic = true;
		animator.applyRootMotion = false;
		animator.SetBool("Landing", true);
		wingAnimtor.SetTrigger("FlyLanding");
	}
	
	public void ResetMovement() {
		Debug.Log("reseted");
		animator.SetFloat("Forward", 0);
		animator.SetFloat("Turn", 0);
	}


	private void UpdateAnimator(Vector3 move) {
		// update the animator parameters
		animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
		animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
		//animator.SetBool("Crouch", crouching);
		animator.SetBool("OnGround", isGrounded);

		// calculate which leg is behind, so as to leave that leg trailing in the jump animation
		// (This code is reliant on the specific run cycle offset in our animations,
		// and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
		float runCycle = Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime + runCycleLegOffset, 1);
		float jumpLeg = (runCycle < charachterHalf ? 1 : -1) * forwardAmount;
		if (isGrounded) {
			animator.SetFloat("JumpLeg", jumpLeg);
		}

		// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
		// which affects the movement speed because of the root motion.
		if (isGrounded && move.magnitude > 0) {
			animator.speed = animSpeedMultiplier;
		}
		else {
			// don't use that while airborne
			animator.speed = 1;
		}
	}

	private void ApplyExtraTurnRotation() {
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
		transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
	}

	private void ReflectorRotation(){
		
	}

	private void CheckGroundStatus() {
		RaycastHit hitInfo;
#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));
#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance)) {
			groundNormal = hitInfo.normal;
			isGrounded = true;
			animator.applyRootMotion = true;
		}
		else {
			isGrounded = false;
			groundNormal = Vector3.up;
			//animator.applyRootMotion = false;
		}
	}
}
