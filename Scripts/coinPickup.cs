using UnityEngine;
using System.Collections;

public class coinPickup : MonoBehaviour {

	public AudioClip coinSound;
	private bool alreadyCollided = false;
	public GameObject effect; 
	
	void OnTriggerEnter2D(Collider2D col){
		
		if(col.tag == "Player") {
			if (!alreadyCollided) {
				col.gameObject.GetComponent<PlayerControl>().increaseCoins();
				audio.clip = coinSound;
				audio.PlayOneShot(coinSound);
				Color color = renderer.material.color;
				color.a = 0f;
				renderer.material.color = color;
				Instantiate(effect, transform.position, Quaternion.Euler(new Vector3(0,0,0f)));
				Destroy(gameObject, 1f);
				alreadyCollided = true;
			}
		}
	}
}