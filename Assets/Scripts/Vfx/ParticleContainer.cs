using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContainer : MonoBehaviour {
	public static ParticleContainer Instance;

	[SerializeField]
	private ParticleSystem walkParticle;
	[SerializeField]
	private ParticleSystem interactParticle;


	private void Start() {
		if (Instance != null) {
			Destroy(this);
			return;
		}
		Instance = this;
	}

	private void EmitParticle(ParticleSystem system, Vector3 position) {
		system.transform.position = position;
		system.Emit(10);
	}

	/// emits the particle for the walk
	public void EmitWalkParticle(Vector3 position) {
		EmitParticle(walkParticle, position);
	}

	/// emits the particle for interacting
	public void EmitInteractParticle(Vector3 position) {
		EmitParticle(interactParticle, position);
	}

}
