using UnityEngine;
using System.Collections;

public class exitSign : MonoBehaviour {
	public AudioClip sound;
	public bool alreadyCollided;
	
	void Start() {
		alreadyCollided = false;
	}
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Player" && (col.gameObject.GetComponent<PlayerControl>().hasStarCoin == true)) {
			if (!alreadyCollided) {
				audio.clip = sound;
				audio.Play();
				alreadyCollided = true;
			}
		}
	}
}
