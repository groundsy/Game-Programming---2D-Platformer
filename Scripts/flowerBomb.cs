using UnityEngine;
using System.Collections;

public class flowerBomb : MonoBehaviour {
	public float distance;
	public float fuseDistance = 8.0f;
	public float attackRange = 3.0f;
	public float bombRadius = 5f;
	public float bombForce = 100f;
	public Transform player;
	public GameObject explosion;
	public GameObject flash;
	public GameObject fire;
	public GameObject smoke;
	public AudioClip kaboom;
	public AudioClip fuse;
	public AudioClip boom;
	public bool alreadyPlayed = false;
	public bool fuseDone = false;
	public bool detonateDone = false;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		distance = Vector3.Distance(player.position, transform.position);
	}

	IEnumerator detonate() {
		audio.clip = kaboom;
		audio.PlayOneShot(kaboom);
		yield return new WaitForSeconds(1.25f);
		explode ();
	}

	void explode() {
		if (!alreadyPlayed) {
			
			Vector3 rad = new Vector3(bombRadius,bombRadius,bombRadius);
			distance = Vector3.Distance(player.position, transform.position);
			
			if (distance < bombRadius) {
				Vector3 deltaPos = player.transform.position - transform.position;
				Vector3 force = deltaPos.normalized * bombForce * 5;
				player.rigidbody2D.AddForce(force);
				audio.clip = boom;
				audio.PlayOneShot(boom);
				Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0f,0f,0f)));
				Instantiate(flash, transform.position, Quaternion.Euler(new Vector3(0f,0f,0f)));
				alreadyPlayed = true;
				player.gameObject.GetComponent<PlayerControl>().applyDamge();
				Color color = renderer.material.color;
				color.a = 0f;
				renderer.material.color = color;
				Destroy(gameObject, 5f);
			}
		}
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		distance = Vector3.Distance(player.position, transform.position);

		if(distance < fuseDistance) {
			if (!fuseDone) {
				audio.clip = fuse;
				audio.PlayOneShot(fuse);
				fuseDone = true;
			}
		}

		if(distance < attackRange) {
			if (!detonateDone) {
				StartCoroutine(detonate());
				detonateDone = true;
			}
		}
	}
}