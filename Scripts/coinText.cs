using UnityEngine;
using System.Collections;

public class coinText : MonoBehaviour {
	
	private PlayerControl playerControl;	// Reference to the player control script.
	
	void Awake () {
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}
	
	
	void Update () {
		guiText.text = playerControl.GetComponent<PlayerControl> ().coinCount + "/" + playerControl.GetComponent<PlayerControl> ().minCoins;
	}
}
