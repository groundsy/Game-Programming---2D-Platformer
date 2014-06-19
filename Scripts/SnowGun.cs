using UnityEngine;
using System.Collections;

public class SnowGun : MonoBehaviour {

	public Rigidbody2D snowBall;			// Prefab of the bullet.
	public float speed = 5f;				// The speed the bullet will fire at.
	public PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	public bool hasGun = false;
	public GameObject effect;

	void Start() {
		playerCtrl = transform.root.GetComponent<PlayerControl>();
	}

	void Update () {
		hasGun = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ().hasGun;
		if(Input.GetKeyDown (KeyCode.Z) && hasGun) {
			audio.Play();
			if(playerCtrl.right) {
				Rigidbody2D	 bulletInstance = Instantiate(snowBall, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else {
				Rigidbody2D bulletInstance = Instantiate(snowBall, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
		    }
		}
	}
}