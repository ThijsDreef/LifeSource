using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContainer : MonoBehaviour {
	public static ParticleContainer Instance;

	[SerializeField]
	private GameObject walkParticle;
	[SerializeField]
	private GameObject interactParticle;

	private ParticleSystem[] walkParticles;
	private ParticleSystem[] interactParticles;
	private void Start() {
		if (Instance != null) {
			Destroy(this);
			return;
		}

		walkParticles = walkParticle.GetComponentsInChildren<ParticleSystem>();
		interactParticles = interactParticle.GetComponentsInChildren<ParticleSystem>();

		Instance = this;
	}

	private void EmitParticle(ParticleSystem system, Vector3 position) {
		system.transform.position = position;
		system.Emit(10);
	}

	/// emits the particle for the walk
	public void EmitWalkParticle(Vector3 position) {
		for (int i = 0; i < walkParticles.Length; i++)
			EmitParticle(walkParticles[i], position);
	}

	/// emits the particle for interacting
	public void EmitInteractParticle(Vector3 position) {
		for (int i = 0; i < interactParticles.Length; i++)
			EmitParticle(interactParticles[i], position);
	}

}
