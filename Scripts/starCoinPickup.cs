using UnityEngine;
using System.Collections;

public class starCoinPickup : MonoBehaviour {

	public AudioClip starSound;
	public GameObject effect;
	public GameObject exitLevel;
	public bool alreadyCollided;
	public Vector3 exitPos;
	
	void Start() {
		alreadyCollided = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player") {
			if (!alreadyCollided) {
				if (col.gameObject.GetComponent<PlayerControl>().coinCount >= col.gameObject.GetComponent<PlayerControl>().minCoins ) {
					col.gameObject.GetComponent<PlayerControl>().hasStarCoin = true;
					audio.clip = starSound;
					audio.PlayOneShot(starSound);
					Color color = renderer.material.color;
					color.a = 0f;
					renderer.material.color = color;
					Destroy(gameObject, 5f);
					Instantiate(effect, transform.position, Quaternion.Euler(new Vector3(0f,0f,0f)));
					Instantiate(exitLevel, exitPos, Quaternion.Euler(new Vector3(0f,0f,0f)));
					alreadyCollided = true;
				}
			}
		}
	}
}

