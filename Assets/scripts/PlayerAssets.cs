using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssets : MonoBehaviour {

	public float maxS = 11f;
	bool isRight = true;
	Animator a;

	bool isOnGround = false;
	public Transform GroundCheck;
	public PlayerController player;
	float groundRadius = 0.14f;
	public float jForce = 400f; 
	public LayerMask wiGround; 
	public float xOffset, yOffset;
	public GameObject playerextra;
	//public int[] originalXs;
	public float changeXMade, changeYMade;//refers to distance from original hair position
	public float xDownOffsets, xUpOffsets;
	public float yDownOffsets, yUpOffsets;
	public bool isDisappearingType;
	bool changeMade = false;
	bool happenedOnceDown = false;
	bool happenedOnceUp = false;
	bool happenedOnceWalk = false;
	//public bool hasOffset;

	void Start () {
		a = GetComponent <Animator> (); 
		player = FindObjectOfType <PlayerController> (); 
	    //changeXMade = changeYMade = 0; 
	}

	void Update(){
		if (player.a.GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
				//Debug.Log ("i is " + i);
				if (!player.isRight) {
					playerextra.transform.position = 
						new Vector3 (playerextra.transform.position.x - changeXMade,
							playerextra.transform.position.y - changeYMade,
							playerextra.transform.position.z); 
					if (changeXMade < 0) {
						Debug.Log ("LESS THAN 0 X IS");
					}
					//changeXMade [i] *= -1;
				} else {
					playerextra.transform.position = 
					new Vector3 (playerextra.transform.position.x - changeXMade,
						playerextra.transform.position.y - changeYMade,
						playerextra.transform.position.z); 
					
				}
				//happenedOnceDown = true;
				changeXMade = changeYMade = 0;

			happenedOnceDown = false;
			happenedOnceUp = false;

		}
		if (player.a.GetCurrentAnimatorStateInfo (0).IsName ("falling_down") && !happenedOnceDown) {
			//handle object's translation 
			happenedOnceUp = false;
				//Debug.Log ("i is " + i);
				if (!player.isRight) {
					playerextra.transform.position = 
					new Vector3 (playerextra.transform.position.x - xDownOffsets,
						playerextra.transform.position.y + yDownOffsets,
						playerextra.transform.position.z); 
					changeXMade += -xDownOffsets;
					changeYMade +=  yDownOffsets;
					Debug.Log ("The player is facing left");
					//Debug.Log ("The changeXMade facing left is " + changeXMade[i]);
				} else {
					playerextra.transform.position = 
					new Vector3 (playerextra.transform.position.x + xDownOffsets,
						playerextra.transform.position.y + yDownOffsets,
						playerextra.transform.position.z); 
					changeXMade += xDownOffsets;
					changeYMade += yDownOffsets;
					Debug.Log ("The changeXMade facing right is " + changeXMade);
				}
				happenedOnceDown = true;
		}
		if (player.a.GetCurrentAnimatorStateInfo (0).IsName ("jump_up") && !happenedOnceUp) {
			//handle object's translation 
			//happenedOnceWalk = false;
			happenedOnceDown = false;
			//Debug.Log ("i is " + i);
			if (!player.isRight) {
				playerextra.transform.position = 
					new Vector3 (playerextra.transform.position.x - xUpOffsets,
						playerextra.transform.position.y + yUpOffsets,
						playerextra.transform.position.z); 
				changeXMade += -xUpOffsets;
				changeYMade +=  yUpOffsets;
				Debug.Log ("The player is facing left");
				//Debug.Log ("The changeXMade facing left is " + changeXMade[i]);
			} else {
				playerextra.transform.position = 
					new Vector3 (playerextra.transform.position.x + xUpOffsets,
						playerextra.transform.position.y + yUpOffsets,
						playerextra.transform.position.z); 
				changeXMade += xUpOffsets;
				changeYMade += yUpOffsets;
				Debug.Log ("The changeXMade facing right is " + changeXMade);
			}
			happenedOnceUp = true;
		}

		if(isOnGround && Input.GetKeyDown(KeyCode.Space)){
			a.SetBool ("Ground", false); 
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jForce)); 
		}

	}
	//mainly for jumping
	void FixedUpdate(){
		isOnGround = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, wiGround);
		a.SetBool ("Ground", isOnGround); 
		a.SetFloat ("verticalSpeed", player.GetComponent<Rigidbody2D> ().velocity.y); 
		float move = Input.GetAxis ("Horizontal"); 
		a.SetFloat ("speed", Mathf.Abs(move));
		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxS,
			player.GetComponent<Rigidbody2D> ().velocity.y); 
		


	}
	



}







