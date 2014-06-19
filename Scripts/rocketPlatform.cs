using UnityEngine;
using System.Collections;

public class rocketPlatform : MonoBehaviour {

	private PlayerControl player;
	private BanzaiLauncher launcher;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<BanzaiLauncher> ();
		renderer.material.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.coinCount >= player.minCoins) {
			launcher.deactivate ();
			launcher.rigidbody2D.isKinematic = false;
			Destroy (gameObject);
		}
	}
}
