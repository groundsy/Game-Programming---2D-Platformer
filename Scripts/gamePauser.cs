using UnityEngine;
using System.Collections;

public class gamePauser : MonoBehaviour {

	public AudioClip pauseSound;
	private bool paused = false;

	void Update () {
		if (Input.GetKeyUp (KeyCode.P)) {
			paused = !paused;
			audio.clip = pauseSound;
			audio.PlayOneShot (pauseSound);
		}
		
		if (paused) 
			Time.timeScale = 0;
		else 
			Time.timeScale = 1;
				
	}
}
