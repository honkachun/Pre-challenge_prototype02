using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

	private bool attack = false;
	public Text textacc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = Vector3.zero;
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		
		if (dir.sqrMagnitude > 1) {
			attack = true;
			textacc.text = "attack";
		} else {
			attack = false;
		}
	}

	void onTriggerEnter (Collider col){


		
		if (col.gameObject.tag == "Enemy" ) {
			Debug.Log ("enter");
			textacc.text = "hit";
			Destroy(col.gameObject);
		}
		
	}
}
