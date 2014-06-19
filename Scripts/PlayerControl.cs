using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private Animator anim;
	private bool jumped = false;

	public bool hasStarCoin = false;
	public bool hasGun = false;
	public float speed = 5.0f;
	public bool facingRight = true;
	public bool grounded = false;
	public Transform groundCheck;
	public float minJumpDelay = 0.5f;
	public float jumpTime = 0.0f;
	public string axisName = "Horizontal";
	public string jumpButton = "KeyCode.Space";
	public AudioClip jumpSound;
	public float jumpPower = 500.0f;
	public Rigidbody2D rigidbody2d;
	public bool right = true;
	public int coinCount = 0;
	public int minCoins = 30;
	public AudioClip coinCollectedSound;
	public bool coinCollectedSoundPlayed;
	public bool alreadyDead = false;
	public GameObject blood;
	public AudioClip dead;
	public int playerHP = 3;
	public AudioClip scream;
	public AudioClip hurt;
	public AudioClip died;
	public string level;

	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
		coinCollectedSoundPlayed = false;
	}

	IEnumerator restart() {
		yield return new WaitForSeconds(3f);
		Application.LoadLevel(level);
	}

	IEnumerator wait() {
		yield return new WaitForSeconds(3f);
		killPlayer ();
	}

	void killPlayer() {
		if (!alreadyDead) {
			gameObject.renderer.material.color = Color.black;
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, 90f));
			Instantiate (blood, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
			audio.clip = dead;
			audio.PlayOneShot (dead);
			alreadyDead = true;
			StartCoroutine (restart ());
		}
	}

	public void increaseCoins() {
		++coinCount;
		if ((coinCount >= minCoins) && (!coinCollectedSoundPlayed)) {
			audio.clip = coinCollectedSound;
			audio.PlayOneShot(coinCollectedSound);
			coinCollectedSoundPlayed = true;
		}
	}

	public void applyDamge() {
		--playerHP;
		if (playerHP == 2) {
			gameObject.renderer.material.color = Color.yellow;
			audio.clip = hurt;
			audio.PlayOneShot (hurt);
		} 
		else if (playerHP == 1) {
			gameObject.renderer.material.color = Color.red;
			audio.clip = hurt;
			audio.PlayOneShot (hurt);
		} 
		else {
			if (!alreadyDead) {
				audio.clip = died;
				audio.PlayOneShot(died);
				rigidbody2D.isKinematic = true;
				StartCoroutine(wait());
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			right = false;
		}
		else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			right = true;
		}
		grounded = Physics2D.Linecast (transform.position, groundCheck.position);
		jumpTime -= Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.UpArrow) && !jumped) {
			jumped = true;
			grounded = false;
			anim.SetTrigger("Jump");
			rigidbody2d.AddForce(transform.up*jumpPower);
			audio.clip = jumpSound;
			audio.PlayOneShot(jumpSound);
			jumpTime = minJumpDelay;
		}
		if (grounded && jumpTime <= 0 && jumped) {
			jumped = false;
			anim.SetTrigger ("Land");
		}
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis (axisName)));
		flip ();
		transform.position += transform.right * Input.GetAxis (axisName) * speed * Time.deltaTime;
	}

	void flip() {
		if (Input.GetAxis (axisName) < 0) {
			Vector3 newScale = transform.localScale;
			newScale.x = -1.0f;
			transform.localScale = newScale;
			facingRight = !facingRight;
		} 
		else {
			Vector3 newScale = transform.localScale;
			newScale.x = 1.0f;
			transform.localScale = newScale;
		}
	}
}
