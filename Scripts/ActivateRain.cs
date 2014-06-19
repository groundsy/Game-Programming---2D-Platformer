using UnityEngine;
using System.Collections;

public class ActivateRain : MonoBehaviour {

	public bool activated = false;
	public bool ready = false;
	public PlayerControl player;
	public GameObject flame;
	public AudioClip sound;
	public AudioClip secretSound;
	public GameObject rain;
	public AudioClip readySound;
	public bool alreadyPlayed = false;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.coinCount >= player.minCoins) {
						ready = true;
			if (!alreadyPlayed) {
				audio.clip = readySound;
				audio.PlayOneShot(readySound);
				alreadyPlayed = true;
			}
		}
	}

	IEnumerator wait() {
		yield return new WaitForSeconds(6f);
		playSecret ();
	}

	void playSecret() {
		Instantiate(rain, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
		audio.clip = secretSound;
		audio.PlayOneShot (secretSound);

	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		if (ready) {
			if (!activated) {
				activated = true;
				audio.clip = sound;
				audio.PlayOneShot (sound);
				renderer.material.color = Color.gray;
				StartCoroutine(wait ());
			}
		}
	}
}
