using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float maxS = 11f;
	public bool isRight = true;
	public Animator a;

	bool isOnGround = false;
	public Transform GroundCheck;
	float groundRadius = 0.14f;
	public float jForce = 400f; 
	public LayerMask wiGround;
	public bool CanMove;
	private int number;
	int[] objects = {4, 6, 7 , 4, 3};
	int objectIndex;
	//Vector3 notFlipScale;

	//public GameObject notFlippedObject;//children that won't be flipped


	void Start () {
		a = GetComponent <Animator> (); 
		number = 0;
		objectIndex = 0;
		//notFlipScale = notFlippedObject.transform.localScale;
	

	}

	void Update(){
		if(isOnGround && Input.GetKeyDown(KeyCode.Space)){
			a.SetBool ("Ground", false); 
			//notFlippedObject.transform.parent = null;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jForce)); 
		}

	}
	//mainly for jumping
	void FixedUpdate(){
		isOnGround = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, wiGround);
		a.SetBool ("Ground", isOnGround); 
		//Debug.Log ("is on ground is " + isOnGround);
		// velocity = 0 then switch to downward animation?
		a.SetFloat ("verticalSpeed", GetComponent<Rigidbody2D> ().velocity.y); 
		//Debug.Log (a.GetFloat ("verticalSpeed") + " is the current vertical speed"); 
		float move = Input.GetAxis ("Horizontal"); 
		a.SetFloat ("speed", Mathf.Abs(move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxS,
			GetComponent<Rigidbody2D> ().velocity.y); 
		
		if (move > 0 && !isRight) {
			//notFlippedObject.transform.parent = null;
			Flip ();
			//notFlippedObject.transform.parent = this.transform;
			/*notFlipScale = notFlippedObject.transform.localScale;
			notFlipScale.x *= -1;
			notFlippedObject.transform.localScale = notFlipScale;*/
		} else {
			if (move < 0 && isRight){
				//notFlippedObject.transform.parent = null;
				Flip ();
				//notFlippedObject.transform.parent = this.transform;
				/*notFlipScale = notFlippedObject.transform.localScale;
				notFlipScale.x *= -1;
				notFlippedObject.transform.localScale = notFlipScale;*/
			}
		}

	}

	void Flip(){
		isRight = !isRight; 
		Vector3 scale = transform.localScale; 
		scale.x *= -1; 
		transform.localScale = scale; 
	}


	/*void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "object") {
			GameObject holder = GameObject.Find ("Object" + number);
			holder.GetComponent<SpriteRenderer>().sprite = 
				other.gameObject.GetComponent<SpriteRenderer> ().sprite;
			holder.transform.localScale = new Vector3 (other.transform.localScale.x * 5,
				other.transform.localScale.y * 5, other.transform.localScale.z); 

			//other.gameObject.GetComponent<SpriteRenderer>().sprite = 
			Destroy (other.gameObject); //UNCOMMENT WHEN FINISH DESTROY
			Debug.Log("This is number " + number);
			if(objects[objectIndex] == number){
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
				objectIndex++;
				number = 0;
			}

		}
	}*/



}


















