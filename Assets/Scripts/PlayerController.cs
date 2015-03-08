using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public Text TouchMessage;
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


		//ControlTesting ();

		if (Input.touchCount >= 0 && (Input.GetTouch (0).phase == TouchPhase.Stationary || Input.GetTouch (0).phase == TouchPhase.Moved)) {

			Vector3 touchPosition = Input.GetTouch(0).position;
			float touchPositionX = touchPosition.x;

			Vector3 movePosition = Input.GetTouch(0).phase = TouchPhase.Moved;
			float movePositionX = movePosition.x;

			TouchMessage.text = "Touched";

			float h = 0f;
			float v = 5f;

			Move(h,v);

			if(movePositionX > touchPositionX){
				h += 5f;
			}else {
				h -=5f;
			}

			//playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y, speed);

		}else if (Input.touchCount < 0) {

			TouchMessage.text = "NoContact";
		}
	}

	void Move (float h, float v){

		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

	}

	void ControlTesting (){
	
		// Store the input axes.
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		// Move the player around the scene.
		Move (h, v);
	}
}
