using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OwnerHealth : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 1;
	bool playerInRange;
	float timer;

	bool isDead;
	bool damaged;
	public GameObject playerBody;
	Rigidbody player;
	public Slider healthSlider;

	public int playerHealth = 10;
	public int currentHealth;
	public Text playerHealthIndex;
	
	void Awake (){
	
		currentHealth = playerHealth;
		player = GetComponent<Rigidbody> ();
	}

	// Check contact between Player and Enemy
	void OnTriggerEnter(Collider collider) {

		if (collider.gameObject.tag == "Enemy") {

			Debug.Log (playerHealth);

			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		
		if (collider.gameObject.tag == "Enemy") {
			
			playerInRange = false;
		}
	}

	void Update (){

		playerHealthIndex.text = "HealthIndex"+ " " + currentHealth;

		timer += Time.deltaTime;
		
		if(timer >= timeBetweenAttacks && playerInRange == true)
		{
			Attack ();

			Debug.Log ("AfterAttack" + playerHealth);
		}

		if(this.currentHealth <= 0)
		{
			player.isKinematic = true;
			Destroy(playerBody);
		}

		//Debug.Log (playerHealth);
	}

	public void TakeDamage (int amount){
		damaged = true;
		currentHealth -= amount;

		healthSlider.value = playerHealth;

		if(currentHealth <= 0 && !isDead){
			Death ();
		}
	}

	void Death (){
		isDead = true;	
	}

	void Attack (){
		timer = 0f;
		
		if(this.currentHealth > 0){

			this.TakeDamage(attackDamage);
			this.playerHealth = currentHealth - 1;
		}
	}

}
