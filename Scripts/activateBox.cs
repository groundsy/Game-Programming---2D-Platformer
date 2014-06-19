using UnityEngine;
using System.Collections;

public class activateBox : MonoBehaviour {

	public bool activated = false;
	public PlayerControl player;
	public BanzaiLauncher launcher;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		launcher = launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<BanzaiLauncher> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		if (!activated) {
			activated = true;
			audio.clip = sound;
			audio.PlayOneShot(sound);
			renderer.material.color = Color.gray;
			launcher.activate();
		}
	}
}
