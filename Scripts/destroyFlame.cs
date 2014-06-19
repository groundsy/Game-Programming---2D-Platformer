using UnityEngine;
using System.Collections;

public class destroyFlame : MonoBehaviour {


	public ActivateRain rain;

	void Start () {
		rain = GameObject.FindGameObjectWithTag("Rain").GetComponent<ActivateRain>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rain.activated)
			Destroy (gameObject, 10f);
	
	}

	public void kill() {
		Destroy (gameObject, 15f);
	}
}
