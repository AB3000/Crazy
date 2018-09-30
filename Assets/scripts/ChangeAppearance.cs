using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAppearance : MonoBehaviour {

	public SpriteRenderer part;//part we will change, i.e hair, clothes
	public Sprite[] options;
	public int index; 


	void Update(){
		for (int i = 0; i < options.Length; i++) {
			if (i == index) {
				part.sprite = options [i];
			}
		}
	}

	public void Swap(){
		if (index < options.Length - 1) {
			index++;
		} else {
			index = 0; 
		}
	}

}
