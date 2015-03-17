using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		
		if (collider.gameObject.tag == "Enemy")
			Debug.Log ("Enemy is Entering to the attacking area");
	}
}
