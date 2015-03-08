using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float EnemySpeed;
	public Transform Target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float Step = EnemySpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Target.position, Step);
	}
}
