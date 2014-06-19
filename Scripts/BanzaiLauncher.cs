using UnityEngine;
using System.Collections;

public class BanzaiLauncher : MonoBehaviour {

	public Rigidbody2D banzai;			// Prefab of the bullet.
	public float speed = 10f;			// The speed the bullet will fire at.
	public PlayerControl playerCtrl;	// Reference to the PlayerControl script.
	public GameObject effect;
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public AudioClip sound;
	public PlayerControl player;

	
	void Start() {
		// Start calling the Spawn function repeatedly after a delay .
		player = player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

	void Update() {
		if (player.hasStarCoin)
			deactivate ();
	}

	void Spawn () {
		audio.clip = sound;
		audio.PlayOneShot (sound);
		Vector3 pos = new Vector3 (transform.position.x - 2.5f, transform.position.y, transform.position.z);
		Rigidbody2D banzaiInstance = Instantiate(banzai, pos, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		banzaiInstance.velocity = new Vector2(-speed, 0);
	}

	public void deactivate () {
		CancelInvoke ();
	}

	public void activate () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
}
