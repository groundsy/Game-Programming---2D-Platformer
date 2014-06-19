using UnityEngine;
using System.Collections;

public class levelEnd : MonoBehaviour {

	public AudioClip sound;
	
	// Use this for initialization
	void Start () {
		audio.clip = sound;
		audio.Play();
	}
}
