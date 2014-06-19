using UnityEngine;
using System.Collections;

public class spikeBlock : MonoBehaviour {
	
	public float distance;
	public float minXPos;
	public float minYPos;
	public float maxXPos;
	public float maxYPos;
	public float attackRange = 5.0f;
	public float moveSpeed = 4.0f;
	public bool isAttacking = false;
	public bool alreadyCollided = false;
	public Transform player;
	public GameObject explosion;
	public AudioClip sound;

	public Vector3 originalPos;
	public Vector3 newPos;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		distance = Vector3.Distance(player.position, transform.position);
		originalPos = transform.position;
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		distance = Vector3.Distance(player.position, transform.position);
		newPos = transform.position;

		if (distance > attackRange) {
			renderer.material.color = Color.white;
			isAttacking = false;
		}
		
		if(distance < attackRange)
			attack ();

		if(isAttacking)
			renderer.material.color = Color.red;
	}

	void attack () {
		isAttacking = true;
		
		if (player.position.x < transform.position.x)
			transform.position -= transform.right * moveSpeed * Time.deltaTime;
		else
			transform.position += transform.right * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			if (!alreadyCollided) {
				alreadyCollided = true;
				audio.clip = sound;
				audio.PlayOneShot(sound);
				Instantiate (explosion, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
				player.gameObject.GetComponent<PlayerControl> ().applyDamge ();
				Destroy (gameObject);
				deactivate();
				StartCoroutine(reset());
			}
		} 
		if (col.tag == "Obstacle") {
			deactivate();
			StartCoroutine(reset());
		}
	}

	void deactivate() {
		moveSpeed = 0f;
		isAttacking = false;
		alreadyCollided = false;
		renderer.material.color = Color.white;
		transform.position = originalPos;
	}

	IEnumerator reset() {
		yield return new WaitForSeconds(1f);
		moveSpeed = 3f;
	}


}
