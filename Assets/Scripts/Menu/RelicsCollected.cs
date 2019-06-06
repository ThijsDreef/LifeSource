using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicsCollected : MonoBehaviour {
	public static RelicsCollected Instance;
	[SerializeField]
	private Sprite[] collected = new Sprite[3];
	[SerializeField]
	private Sprite[] uncollected = new Sprite[3];
	[SerializeField]
	private Image[] displayImages = new Image[3];

	private void Start() {
		if (Instance != null) return;
		Instance = this;
		OverlayController.Instance.onEndOverlay.AddListener(this.Reset);
	}

	private void Reset() {
		for (int i = 0; i < displayImages.Length; i++) displayImages[i].sprite = uncollected[i];
	}

	public void CollectPiece(TemplePieceType type) {
		displayImages[(int)type - 1].sprite = collected[(int)type - 1];
	}

}
