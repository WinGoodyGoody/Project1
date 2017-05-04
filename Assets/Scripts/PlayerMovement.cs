using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//Movement speed 
	public float moveSpeed;

	public GameObject deathParticles;

	private float maxSpeed = 5f;

	private Vector3 spawn;


	//Location in 3D space
	private Vector3 input;

	// Use this for initialization
	void Start () 
	{
		// Recording the start position of the player as the spawn position
		// so that can return to here after a collision with the enemy
		spawn = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));

		if (GetComponent<Rigidbody> ().velocity.magnitude < maxSpeed) 
		{
			//print (input);

			GetComponent<Rigidbody> ().AddForce (input * moveSpeed);
		}

		if (transform.position.y < -2)
		{
			Die ();
		}
			
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag=="Enemy")
		{
			Die ();
		}
	}

	void Die()
	{
		Instantiate (deathParticles, transform.position, Quaternion.identity);
		transform.position = spawn;
	}
		
}
