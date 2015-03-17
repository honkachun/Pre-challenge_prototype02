using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class OwnerHealth : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 1;
	bool playerInRange;
	float timer;

	public Image damageImage;
	public Image comingLeft;
	public Image comingRight;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Color flashComingColour = new Color(1f, 0f, 0f, 0.1f);
	bool isDead;
	bool damaged;
	bool EnemyComingLeft;
	bool EnemyComingRight;

	public GameObject Enemy;

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

		EnemyCome ();

		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;


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

	void EnemyCome(){
	
		//EnemyComing = true;
		timer = 0f;

		if (Enemy.transform.position.z < this.transform.position.z + 20 && Enemy.transform.position.z > this.transform.position.z && Enemy.transform.position.x < Screen.width / 2) {
			EnemyComingLeft = true;
		}else if(Enemy.transform.position.z < this.transform.position.z + 20 && Enemy.transform.position.z > this.transform.position.z && Enemy.transform.position.x > Screen.width /2){
			EnemyComingRight = true;
		}

		if (EnemyComingLeft == true) {
			comingLeft.color = flashComingColour;
			EnemyComingLeft = false;

		}else if(EnemyComingRight == true){
			comingRight.color = flashComingColour;
			EnemyComingRight = false;

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
