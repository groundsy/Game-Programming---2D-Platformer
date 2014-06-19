using UnityEngine;
using System.Collections;

public class starBlock : MonoBehaviour {
	
	public GameObject blockExplosion;
	public AudioClip explosionSound;
	private PlayerControl player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl>();
	}

	void Update () {
		if (player.coinCount >= player.minCoins) 
			renderer.material.color = Color.white;
		else 
			renderer.material.color = Color.gray;
	}

	public void applyDamage() {
		Instantiate (blockExplosion, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
		audio.clip = explosionSound;
		audio.PlayOneShot(explosionSound);
		Color color = renderer.material.color;
		color.a = 0f;
		renderer.material.color = color;
		Destroy (gameObject, 0.36f);
	}
}