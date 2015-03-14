using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float EnemySpeed;
	public GameObject Target;
	public float CloseDistance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 trigger = Target.transform.position - transform.position;
		float sqrtTrigger = trigger.sqrMagnitude;

		//Debug.Log (sqrtTrigger);

		if (sqrtTrigger < CloseDistance * CloseDistance) {
			float Step = EnemySpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, Step);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject == Target)
		{

			//Destroy(gameObject);
		}
	}

}
