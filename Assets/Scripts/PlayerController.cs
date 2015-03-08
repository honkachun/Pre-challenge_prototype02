using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	

	public float speed = 6f;

	Vector3 movement;
	Rigidbody playerRigidbody;

	int floorMask;
	//float camRayLength = 100f;

	void Awake(){

		playerRigidbody = GetComponent<Rigidbody> ();
	}
	

	// Update is called once per frame
	void FixedUpdate () {

		//Movement of the character
		/*if(!Input.GetKey(KeyCode.S)){
			float move = Input.GetAxis ("Horizontal");
		}*/
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){


		}
	}
}
