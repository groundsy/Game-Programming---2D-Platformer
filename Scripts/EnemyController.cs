using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float distance;
	public float range = 10.0f;
	public float speed = 2f;
	public int enemyHP = 2;
	public bool active = false;
	public bool alreadyCollided = false;
	public bool facingRight = false;
	public GameObject explosion;
	public GameObject deadExplosion;
	public AudioClip sound;
	public AudioClip dead;
	public Transform player;	

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			if (!alreadyCollided) {
				Color color = renderer.material.color;
				color.a = 0f;
				renderer.material.color = color;
				audio.clip = sound;
				audio.PlayOneShot (sound);
				Instantiate (explosion, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
				player.gameObject.GetComponent<PlayerControl> ().applyDamge ();
				Destroy (gameObject, 1f);
				alreadyCollided = true;
			}
		} 
		else if (col.tag == "Obstacle" || col.tag == "StarBlock") {
			flip ();
		}
	}

	public void applyDamage() {
		--enemyHP;
		if (enemyHP == 1) 
			renderer.material.color = Color.red;
		else {
			audio.clip = dead;
			audio.PlayOneShot(dead);
			Instantiate (deadExplosion, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
			Destroy(gameObject, .15f);
		}
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		distance = Vector3.Distance(player.position, transform.position);
		if (distance < range)
			active = true;
		if (active) {
			if (facingRight)
				transform.position += transform.right * speed * Time.deltaTime;
			else
				transform.position -= transform.right * speed * Time.deltaTime;
		}
	}

	void flip() {
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
		facingRight = !facingRight;
	}
}
