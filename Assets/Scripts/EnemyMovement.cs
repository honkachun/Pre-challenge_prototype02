using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float EnemySpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
}
