using UnityEngine;
using System.Collections;

public class SnowBall : MonoBehaviour {

	public GameObject explosion;		// Prefab of explosion effect.

	private PlayerControl player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		Destroy (gameObject, 3);
	}

	void OnExplode() {
		Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
		Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyController>().applyDamage();
			Destroy (gameObject);
		} 
		else if (col.tag == "StarBlock") {
			if (player.coinCount >= player.minCoins) {
				col.gameObject.GetComponent<starBlock>().applyDamage();
				Destroy (gameObject);
			}
			else {
				OnExplode ();
				Destroy (gameObject);
			}
		}
	}
}
