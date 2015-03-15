using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public Text TouchMessageBegin;
	public Text TouchMessageFinal;
	public float PlayerSpeed;

	Vector3 movement;
	Rigidbody playerRigidbody;
	body = GameObject.

	Vector2 touchBegin;
	Vector2 touchFinal; 

	int floorMask;
	//float camRayLength = 100f;

	void Awake(){

		playerRigidbody = GetComponent<Rigidbody> ();
	}
	

	// Update is called once per frame
	void FixedUpdate () {

		TouchControl ();

	}

	void Move (float h, float v){
		
		Vector3 targetPosition = new Vector3();
		targetPosition.x = h + transform.position.x;
		targetPosition.z = v + transform.position.z;

		float Step = PlayerSpeed * Time.deltaTime;
		body = transform.Find ("body");

		if (Input.touchCount > 0 && Input.GetTouch (0).phase != TouchPhase.Ended) {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, Step);	

			float rotationDegree = Mathf.Tan(h/v);

			body.transform.Rotate(0, rotationDegree, 0 );

		}
	}

	void TouchControl (){
	
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			touchBegin = Input.GetTouch(0).position;
		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			touchFinal = Input.GetTouch (0).position;
		}

		float h = touchFinal.x - touchBegin.x;
		float v = touchFinal.y - touchBegin.y;

		TouchMessageBegin.text = "Begin X:" + touchBegin.x + "Begin Y:" + touchBegin.y;
		TouchMessageFinal.text = "Final X:" + touchFinal.x + "Final Y:" +touchFinal.y;

		// Move the player around the scene.
		Move (h, v);
	}

}
