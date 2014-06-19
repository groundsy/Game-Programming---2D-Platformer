using UnityEngine;
using System.Collections;

public class Banzai : MonoBehaviour {
		
		public GameObject explosion;	
		public GameObject smoke;
		public bool collided = false;
		
		private PlayerControl player;
		
		// Use this for initialization
		void Start () {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
			Destroy (gameObject, 30);
		    collided = false;
		}
		
		void OnExplode() {
			Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
			Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
		}
		
		void OnTriggerEnter2D (Collider2D col) 
		{
			if (col.tag == "Player") {
				if (!collided) {
					collided = true;
					col.gameObject.GetComponent<PlayerControl>().applyDamge();
				}
			}

			if (col.tag == "StarBlock") {
					col.gameObject.GetComponent<starBlock>().applyDamage();
			}
		}
	}
