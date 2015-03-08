using UnityEngine;
using System.Collections;

public class WallPos : MonoBehaviour {

	public bool wallLeft;
	private float wallLeftPosX = Screen.width * -1;
	private float wallRightPosX = Screen.width;

	void Awake(){

		if (this.transform.position.x <= -1) {
			wallLeft = true;
		}else if (this.transform.position.x >= 1){
			wallLeft = false;
		}
	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (wallLeft == true) {
			transform.position = new Vector3 (wallLeftPosX, this.transform.position.y, this.transform.position.z);
		} else {
			transform.position = new Vector3 (wallRightPosX, this.transform.position.y, this.transform.position.z);
		}

	}
}
