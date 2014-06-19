using UnityEngine;
using System.Collections;

public class exitLevel : MonoBehaviour {

	public AudioClip sound;
	public string level;

	void Start() {
		audio.clip = sound;
		audio.Play ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player") {
			Application.LoadLevel(level);
		}
	}
}
