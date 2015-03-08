using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumCheck : MonoBehaviour {

	public Text TxtAcc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float accx = Input.acceleration.x;
		float accy = Input.acceleration.y;
		TxtAcc.text = "AcceX :" + accx + "    " + "AcceY :" + accy;

	}
}
