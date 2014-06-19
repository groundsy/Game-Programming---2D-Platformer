using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {

	public ParticleSystem flame;
	public ActivateRain rain;
	public bool ready = true;

	// Use this for initialization
	void Start () {
		Instantiate(flame, transform.position, Quaternion.Euler(new Vector3(-90f,0,0)));
		rain = GameObject.FindGameObjectWithTag("Rain").GetComponent<ActivateRain>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rain.activated)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player")
			col.gameObject.GetComponent<PlayerControl> ().applyDamge ();
	}
}
