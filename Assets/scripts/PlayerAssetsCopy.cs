using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssetsCopy : MonoBehaviour {

	public float maxS = 11f;
	bool isRight = true;
	Animator a;

	bool isOnGround = false;
	//public Transform GroundCheck;
	public PlayerController player;
	float groundRadius = 0.14f;
	public float jForce = 400f; 
	public LayerMask wiGround; 
	public float xOffset, yOffset;
	public GameObject[] playerextras; 
	public GameObject playerextra;
	//public int[] originalXs;
	public float[] changeXMade, changeYMade;//refers to distance from original hair position
	public float[] xDownOffsets;
	public float[] yDownOffsets;
	public bool [] isDisappearingType;
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
		if (a.GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
			for (int i = 0; i < playerextras.Length; i++) {
				//Debug.Log ("i is " + i);
				if (!player.isRight) {
					playerextras [i].transform.position = 
						new Vector3 (playerextras [i].transform.position.x - changeXMade [i],
							playerextras [i].transform.position.y - changeYMade [i],
							playerextras [i].transform.position.z); 
					if (changeXMade [i] < 0) {
						Debug.Log ("LESS THAN 0 X IS");
					}
					//changeXMade [i] *= -1;
				} else {
					playerextras [i].transform.position = 
						new Vector3 (playerextras [i].transform.position.x - changeXMade [i],
							playerextras [i].transform.position.y - changeYMade [i],
							playerextras [i].transform.position.z); 

				}
				//happenedOnceDown = true;
				changeXMade [i] = changeYMade [i] = 0;
			}
			happenedOnceDown = false;

		}
		if (a.GetCurrentAnimatorStateInfo (0).IsName ("falling_down") && !happenedOnceDown) {
			//handle object's translation 
			happenedOnceWalk = false;
			happenedOnceUp = false;
			for (int i = 0; i < playerextras.Length; i++) {
				//Debug.Log ("i is " + i);
				if (!player.isRight) {
					playerextras [i].transform.position = 
						new Vector3 (playerextras [i].transform.position.x - xDownOffsets [i],
							playerextras [i].transform.position.y + yDownOffsets [i],
							playerextras [i].transform.position.z); 
					changeXMade[i] = -xDownOffsets [i];
					changeYMade[i] =  yDownOffsets [i];
					Debug.Log ("The player is facing left");
					//Debug.Log ("The changeXMade facing left is " + changeXMade[i]);
				} else {
					playerextras [i].transform.position = 
						new Vector3 (playerextras [i].transform.position.x + xDownOffsets [i],
							playerextras [i].transform.position.y + yDownOffsets [i],
							playerextras [i].transform.position.z); 
					changeXMade[i] = xDownOffsets [i];
					changeYMade[i] = yDownOffsets [i];
					Debug.Log ("The changeXMade facing right is " + changeXMade[i]);
				}
				happenedOnceDown = true;
				//changeXMade[i] = xDownOffsets [i];
				//changeYMade[i] = yDownOffsets [i];
			}
			//check if object needs to be rotated
		}

		/*if (a.GetCurrentAnimatorStateInfo (0).IsName ("jump_up") && !happenedOnceUp) {
			happenedOnceDown = false;
			happenedOnceWalk = false;

		}*/

		if(isOnGround && Input.GetKeyDown(KeyCode.Space)){
			a.SetBool ("Ground", false); 
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jForce)); 
		}

	}
	//mainly for jumping
	void FixedUpdate(){
		a.SetBool ("Ground", isOnGround); 
		a.SetFloat ("verticalSpeed", player.GetComponent<Rigidbody2D> ().velocity.y); 
		float move = Input.GetAxis ("Horizontal"); 
		a.SetFloat ("speed", Mathf.Abs(move));
		player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxS,
			player.GetComponent<Rigidbody2D> ().velocity.y); 
		/*if (move > 0 && !isRight) {
			Flip ();
		} else {
			if (move < 0 && isRight) {
				Flip ();
			}
		}*/
	}

	/*void Flip(){
	isRight = !isRight; 
	Vector3 scale = transform.localScale; 
	scale.x *= -1; 
	transform.localScale = scale; 
	Debug.Log ("is flipped!");
		for (int i = 0; i < playerextras.Length; i++) {
			xDownOffsets [i] *= -1;
			changeXMade [i] *= -1;
			playerextras[i].transform.position = new Vector3 (playerextras[i].transform.position.x + xOffset,
				playerextras[i].transform.position.y + yOffset,
				playerextras[i].transform.position.z); 
		}
}*/





}







