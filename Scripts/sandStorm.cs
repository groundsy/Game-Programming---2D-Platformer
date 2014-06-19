using UnityEngine;
using System.Collections;

public class sandStorm : MonoBehaviour {

	public GameObject sandstorm;

	// Use this for initialization
	void Start () {
		Instantiate(sandstorm, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
	}
}
